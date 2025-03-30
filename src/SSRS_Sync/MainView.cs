using System;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.IO;
using System.Web;
using System.Threading;
using System.Diagnostics;
using SSRS_Sync.ReportService;
using DevExpress.XtraEditors;
using Telerik.WinControls.UI;

namespace SSRS_Sync
{
    public partial class MainView : DevExpress.XtraEditors.XtraForm
    {
        const string ROOT_FOLDER = "/";
        const string PATH_SEPERATOR = "/";

        const string SOURCE_SELECTION_START = "ReportSyncSource:";

        const string DEST_SELECTION_START = "ReportSyncDest:";

        const string MAPPING_START = "ReportSyncMap:";
        string baseSrvUrl = "http://localhost:80/ReportServer";


        ReportingService2005 sourceRS;
        ReportingService2005 destRS;

        Dictionary<string, string> sourceDS;
        Dictionary<string, string> destDS;

        string pathOnDisk;

        string uploadPath = ROOT_FOLDER;
        List<string> existingPaths;

        int selectedNodeCount;

        int processedNodeCount;
        public MainView()
        {
            InitializeComponent();
            if (!mvvmContext1.IsDesignMode)
                InitializeBindings();

            bwDownload.DoWork += new DoWorkEventHandler(bwDownload_DoWork);
            bwDownload.ProgressChanged += new ProgressChangedEventHandler(bwDownload_ProgressChanged);
            bwDownload.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bwDownload_RunWorkerCompleted);

            bwUpload.DoWork += new DoWorkEventHandler(bwUpload_DoWork);
            bwUpload.ProgressChanged += new ProgressChangedEventHandler(bwUpload_ProgressChanged);
            bwUpload.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bwUpload_RunWorkerCompleted);

            bwSync.DoWork += new DoWorkEventHandler(bwSync_DoWork);
            bwSync.ProgressChanged += new ProgressChangedEventHandler(bwSync_ProgressChanged);
            bwSync.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bwSync_RunWorkerCompleted);
        }


        void bwDownload_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            pbSource.Value = e.ProgressPercentage;
        }

        void bwUpload_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            pbDest.Value = e.ProgressPercentage;
        }

        void bwSync_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            pbSource.Value = e.ProgressPercentage;
            pbDest.Value = e.ProgressPercentage;
        }

        void bwSync_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            unCheckTreeNodes(rptSourceTree.Nodes);
            loadDestTree();
            XtraMessageBox.Show("Sync completed successfully.", "Sync complete");
        }

        void bwSync_DoWork(object sender, DoWorkEventArgs e)
        {
            processedNodeCount = 0;
            var destPath = ROOT_FOLDER;
            if (!string.IsNullOrEmpty(uploadPath))
                destPath = uploadPath;
            syncTreeNodes(destPath, rptSourceTree.Nodes);
            bwSync.ReportProgress(100);
        }

        void bwUpload_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            loadDestTree();
            XtraMessageBox.Show("Upload completed successfully.", "Upload complete");
        }

        void bwUpload_DoWork(object sender, DoWorkEventArgs e)
        {
            var files = Directory.GetFiles(txtLocalPath.Text, "*.rdl", SearchOption.AllDirectories);
            selectedNodeCount = files.Length;
            processedNodeCount = 0;
            foreach (var file in files)
            {
                var fullPath = file.Replace(txtLocalPath.Text, "").TrimStart('\\');
                int breakAt = fullPath.LastIndexOf('\\');
                string filePath;
                if (breakAt == -1)
                    filePath = string.Empty;
                else
                    filePath = fullPath.Substring(0, breakAt).Replace("\\", PATH_SEPERATOR); ;
                var fileName = fullPath.Substring(breakAt + 1, fullPath.Length - 5 - breakAt); //remove the .rdl
                var reportPath = uploadPath;
                if (reportPath.EndsWith(PATH_SEPERATOR))
                    reportPath += filePath.TrimStart('/');
                else
                    reportPath += "/" + filePath.TrimStart('/');
                reportPath = reportPath.TrimEnd('/');
                XmlDocument report = new XmlDocument();
                report.Load(file);
                var reportDef = Encoding.Default.GetBytes(report.OuterXml);
                if (!existingPaths.Contains(reportPath))
                {
                    EnsureDestDir(reportPath);
                    existingPaths.Add(reportPath);
                }
                uploadReport(reportPath, fileName, reportDef);
                processedNodeCount++;
                bwUpload.ReportProgress(processedNodeCount * 100 / selectedNodeCount);
            }
            bwUpload.ReportProgress(100);
        }

        void bwDownload_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            unCheckTreeNodes(rptSourceTree.Nodes);
            XtraMessageBox.Show("Report files downloaded successfully.", "Download complete");

        }

        void bwDownload_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                processedNodeCount = 0;
                saveTreeNodes(rptSourceTree.Nodes);
                bwDownload.ReportProgress(100);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Download failed." + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        void InitializeBindings()
        {
            var fluent = mvvmContext1.OfType<MainViewModel>();
        }

        private void textEdit1_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void btnSync_Click(object sender, EventArgs e)
        {
            try
            {
                selectedNodeCount = 0;
                checkTreeNodes(rptSourceTree.Nodes, false);
                existingPaths = new List<string>();
                bwSync.RunWorkerAsync();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Sync failed." + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void MainView_Load(object sender, EventArgs e)
        {

            this.Text = "SSRS Sync Manager by Talley Ouro(talleyouro@gmail.com)";
            var localPath = @"C:\temp\SSRS_Downloads";
            if (!Directory.Exists(localPath))
            {
                Directory.CreateDirectory(localPath);
            }
            txtLocalPath.Text = localPath;
            txtSourceUrl.Text = baseSrvUrl;

           XtraMessageBox.Show("Please make sure the SSRS Web Service URL is correct", ApplicationManager.AppName);
            toastNotificationsManager1.ShowNotification(Guid.NewGuid());
            Message msg = new Message();
            alertControl1.ControlBoxPosition = DevExpress.XtraBars.Alerter.AlertFormControlBoxPosition.Top;
            alertControl1.Show(this, msg.Caption, msg.Text, "", msg.Image, msg);
        }

        private bool checkTreeNodes(TreeNodeCollection nodes, bool parentChecked)
        {
            var isChecked = parentChecked;
            foreach (TreeNode node in nodes)
            {
                if (node.Checked || parentChecked)
                {
                    checkTreeNodes(node.Nodes, true);
                    node.Checked = true;
                    node.Tag = true;
                    isChecked = true;
                    selectedNodeCount++;
                }
                else
                {
                    node.Tag = checkTreeNodes(node.Nodes, false);
                    isChecked = isChecked || (bool)node.Tag;
                }
            }
            return isChecked;
        }

        private void unCheckTreeNodes(TreeNodeCollection nodes)
        {
            foreach (TreeNode node in nodes)
            {
                if (node.Tag != null)
                {
                    node.Tag = null;
                }
                unCheckTreeNodes(node.Nodes);
            }
        }

        private void saveTreeNodes(TreeNodeCollection nodes)
        {
            foreach (TreeNode node in nodes)
            {
                var destPath = txtLocalPath.Text + "\\" + node.FullPath;
                if (node.Checked)
                {
                    if (node.Nodes.Count > 0)
                    {
                        //check if dir exists
                        if (!Directory.Exists(destPath))
                            Directory.CreateDirectory(destPath);
                        saveTreeNodes(node.Nodes);
                    }
                    else
                    {
                        var itemPath = ROOT_FOLDER + node.FullPath.Replace("\\", "/");
                        var itemType = sourceRS.GetItemType(itemPath);
                        if (itemType == ItemTypeEnum.Resource)
                        {
                            //Download the resource
                            string resourceType;
                            var contents = sourceRS.GetResourceContents(itemPath, out resourceType);
                            File.WriteAllBytes(destPath, contents);
                            continue;
                        }
                        else if (itemType == ItemTypeEnum.Report || itemType == ItemTypeEnum.LinkedReport)
                        {
                            var reportDef = sourceRS.GetReportDefinition(itemPath);
                            XmlDocument rdl = new XmlDocument();
                            rdl.Load(new MemoryStream(reportDef));
                            rdl.Save(destPath + ".rdl");
                        }
                    }
                    processedNodeCount++;
                    bwDownload.ReportProgress(processedNodeCount * 100 / selectedNodeCount);
                }

            }
        }

        private void loadDestTree()
        {
            uploadPath = ROOT_FOLDER;
            rptDestTree.Nodes.Clear();
            destDS = new Dictionary<string, string>();
            loadTreeNode(ROOT_FOLDER, rptDestTree.Nodes, destRS, destDS);
        }

        private void btnUpload_Click(object sender, EventArgs e)
        {
            existingPaths = new List<string>();
            if (string.IsNullOrEmpty(txtLocalPath.Text))
            {
                XtraMessageBox.Show("Please select the folder to upload.",ApplicationManager.AppName);
                return;
            }
            bwUpload.RunWorkerAsync();
        }

        private void btnDownload_Click(object sender, EventArgs e)
        {
            selectedNodeCount = 0;
            checkTreeNodes(rptSourceTree.Nodes, false);
            bwDownload.RunWorkerAsync();
        }

        private void loadTreeNode(string path, TreeNodeCollection nodes, ReportingService2005 rs, Dictionary<string, string> dataSources)
        {
            CatalogItem[] items = rs.ListChildren(path, false);
            foreach (var item in items)
            {
                TreeNode t = new TreeNode();
                t.Text = item.Name;
                t.Name = item.Name;
                if (item.Type == ItemTypeEnum.DataSource)
                {
                    if (!dataSources.ContainsKey(item.Name))
                        dataSources.Add(item.Name, item.Path);
                }
                if (item.Type != ItemTypeEnum.Model && item.Type != ItemTypeEnum.DataSource)
                {
                    nodes.Add(t);
                }
                if (item.Type == ItemTypeEnum.Folder)
                    loadTreeNode(item.Path, t.Nodes, rs, dataSources);
                else
                {

                }
            }
        }

        private void syncTreeNodes(string destPath, TreeNodeCollection nodes)
        {
            foreach (TreeNode node in nodes)
            {
                if ((bool)node.Tag)
                {
                    if (node.Nodes.Count > 0)
                    {
                        var childPath = destPath;
                        if (node.Checked)
                        {
                            if (destPath.Equals(ROOT_FOLDER))
                                childPath = ROOT_FOLDER + node.Text;
                            else
                                childPath = destPath + PATH_SEPERATOR + node.Text;
                        }
                        syncTreeNodes(childPath, node.Nodes);
                    }
                    else
                    {
                        if (!existingPaths.Contains(destPath))
                        {
                            EnsureDestDir(destPath);
                            existingPaths.Add(destPath);
                        }
                        var itemPath = ROOT_FOLDER + node.FullPath.Replace("\\", PATH_SEPERATOR);
                        var itemType = sourceRS.GetItemType(itemPath);
                        if (itemType == ItemTypeEnum.Resource)
                        {
                            //Download the resource
                            string resourceType;
                            var contents = sourceRS.GetResourceContents(itemPath, out resourceType);
                            uploadResource(destPath, node.Text, resourceType, contents);
                            processedNodeCount++;
                            continue;
                        }
                        var reportDef = sourceRS.GetReportDefinition(itemPath);
                        uploadReport(destPath, node.Text, reportDef);

                        //Sync subscriptions
                        ExtensionSettings extSettings;
                        string desc;
                        ActiveState active;
                        string status;
                        string eventType;
                        string matchData;
                        ParameterValue[] values = null;
                        Subscription[] subscriptions = null;
                        ParameterValueOrFieldReference[] extensionParams = null;

                        var destReportPath = destPath;
                        if (destReportPath.EndsWith("/"))
                            destReportPath += node.Text;
                        else
                            destReportPath += "/" + node.Text;

                        subscriptions = sourceRS.ListSubscriptions(itemPath, txtSourceUser.Text);
                        foreach (var subscription in subscriptions)
                        {
                            sourceRS.GetSubscriptionProperties(subscription.SubscriptionID, out extSettings, out desc, out active, out status, out eventType, out matchData, out values);
                            if (extSettings.Extension == "Report Server FileShare")
                            {
                                ParameterValue para = new ParameterValue();
                                para.Name = "PASSWORD";
                                para.Value = txtDestPassword.Text;
                                ParameterValueOrFieldReference[] exParams = new ParameterValueOrFieldReference[extSettings.ParameterValues.Length + 1];
                                Array.Copy(extSettings.ParameterValues, exParams, extSettings.ParameterValues.Length);
                                exParams[extSettings.ParameterValues.Length] = para;
                                extSettings.ParameterValues = exParams;
                            }
                            destRS.CreateSubscription(destReportPath, extSettings, desc, eventType, matchData, values);
                        }

                        processedNodeCount++;
                        bwSync.ReportProgress(processedNodeCount * 100 / selectedNodeCount);
                    }
                }
            }
        }

        private void uploadResource(string destinationPath, string resourceName, string resourceType, byte[] contents)
        {
            destRS.CreateResource(resourceName, destinationPath, true, contents, resourceType, null);
        }

        private void uploadReport(string destinationPath, string reportName, byte[] reportDef)
        {
            try
            {
                //Create report
                destRS.CreateReport(reportName, destinationPath, true, reportDef, null);

                //Link datasources
                var reportPath = destinationPath;
                if (reportPath.EndsWith("/"))
                    reportPath += reportName;
                else
                    reportPath += "/" + reportName;
                var reportDss = destRS.GetItemDataSources(reportPath);
                List<DataSource> dataSources = new List<DataSource>();
                foreach (var reportDs in reportDss)
                {

                    if (destDS.ContainsKey(reportDs.Name))
                    {
                        DataSourceReference reference = new DataSourceReference();
                        reference.Reference = destDS[reportDs.Name];
                        var ds = new DataSource();
                        ds.Item = (DataSourceDefinitionOrReference)reference;
                        ds.Name = reportDs.Name;
                        dataSources.Add(ds);
                    }
                }
                destRS.SetItemDataSources(reportPath, dataSources.ToArray());
            }
            catch (Exception e)
            {
                XtraMessageBox.Show("Upload " + reportName + " failed." + e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void EnsureDestDir(string path)
        {
            try
            {
                destRS.ListChildren(path, false);
            }
            catch (Exception)
            {
                //ensure parent folder
                var breatAt = path.LastIndexOf(PATH_SEPERATOR);
                var folder = path.Substring(breatAt + 1);
                var parent = path.Substring(0, breatAt);
                if (string.IsNullOrEmpty(parent))
                    parent = ROOT_FOLDER;
                EnsureDestDir(parent);
                destRS.CreateFolder(folder, parent, null);
            }
        }

        private void MainView_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (!chkSaveSource.Checked)
                Properties.Settings.Default.SourcePassword = "";
            if (!chkSaveDest.Checked)
                Properties.Settings.Default.DestPassword = "";
            Properties.Settings.Default.Save();
        }

        void checkNodeIfPathExists(TreeNodeCollection nodes, string path)
        {
            var parts = path.Split(new char[] { '\\' }, 2);
            var key = parts[0];
            if (nodes.ContainsKey(key))
            {
                if (parts.Length == 1)
                    nodes[key].Checked = true;
                else
                {
                    nodes[key].Expand();
                    checkNodeIfPathExists(nodes[key].Nodes, parts[1]);
                }
            }
        }

        private string saveCheckedNodes(TreeNodeCollection nodes)
        {
            var data = "";
            foreach (TreeNode node in nodes)
            {
                if (node.Checked)
                    data += node.FullPath + Environment.NewLine;
                data += saveCheckedNodes(node.Nodes);
            }
            return data;
        }

        void SetPathAndSave()
        {
            var res = dlgSaveFile.ShowDialog();
            if (res == DialogResult.OK)
            {
                pathOnDisk = dlgSaveFile.FileName;
                SaveSelectedNodesToDisk();
            }
        }

        void SaveSelectedNodesToDisk()
        {
            if (!string.IsNullOrEmpty(pathOnDisk))
            {
                // save tree to disk
                string data = SOURCE_SELECTION_START + Environment.NewLine;
                data += saveCheckedNodes(rptSourceTree.Nodes);
                data += DEST_SELECTION_START + Environment.NewLine;
                data += saveCheckedNodes(rptDestTree.Nodes);
                data += MAPPING_START + Environment.NewLine;
                //save mapping
                foreach (var entry in destDS)
                {
                    data += entry.Key + "=" + entry.Value + Environment.NewLine;
                }
                File.WriteAllText(pathOnDisk, data);
            }
            else
            {
                SetPathAndSave();
            }
        }

        private void btnSourceLoad_Click(object sender, EventArgs e)
        {
            txtSourceUrl.Text = baseSrvUrl;
            try
            {
                if (txtSourceUrl.Text.Length == 0)
                {
                    XtraMessageBox.Show("Please enter the source SSRS Web Service URL", ApplicationManager.AppName);
                }
                else if(txtSourcePassword.Text.Length == 0 )
                {
                    XtraMessageBox.Show("Please enter the source admin password", ApplicationManager.AppName);
                }
                else
                {
                    sourceRS = new  ReportingService2005();
                    string reportServerURI = baseSrvUrl;
                    if (!string.IsNullOrEmpty(txtSourceUrl.Text))
                    {
                        reportServerURI = txtSourceUrl.Text;
                    }

                    sourceRS.Url = reportServerURI + "/ReportService2005.asmx";// "/ReportService2005.asmx";

                    if (!string.IsNullOrEmpty(txtSourceUser.Text))
                    {
                        var userName = txtSourceUser.Text;
                        var nameParts = userName.Split('\\', '/');
                        if (nameParts.Length > 2)
                        {
                            XtraMessageBox.Show("Incorrect source user name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        else if (nameParts.Length == 2)
                        {
                            userName = nameParts[1];
                            sourceRS.Credentials = new System.Net.NetworkCredential(userName, txtSourcePassword.Text, nameParts[0]);
                        }
                        else
                        {
                            sourceRS.Credentials = new System.Net.NetworkCredential(userName, txtSourcePassword.Text);
                        }
                    }
                    else
                    {
                        sourceRS.Credentials = System.Net.CredentialCache.DefaultCredentials;
                    }

                    rptSourceTree.Nodes.Clear();
                    sourceDS = new Dictionary<string, string>();
                    loadTreeNode(ROOT_FOLDER, rptSourceTree.Nodes, sourceRS, sourceDS);
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Loading failed." + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDest_Click(object sender, EventArgs e)
        {
            DialogResult result = dlgDest.ShowDialog();
            if (result == DialogResult.OK)
            {
                txtLocalPath.Text = dlgDest.SelectedPath;
            }
        }

        private void btnmapds_Click(object sender, EventArgs e)
        {
            if(rptDestTree.Nodes.Count==0 || rptSourceTree.Nodes.Count==0)
            {
                XtraMessageBox.Show("Please load source and destination directories before you can map data sources", ApplicationManager.AppName);
            }
            else
            {
                var frmMapDS = new MapDatasources();
                frmMapDS.sourceDS = sourceDS;
                frmMapDS.destDS = destDS;
                var result = frmMapDS.ShowDialog();
            }
        }
    }

    public class Message
    {
        public Message()
        {
            this.Caption = ApplicationManager.AppName;
            this.Text = "Please load source and destination directories before you can map data sources";
            this.Image = Image.FromFile("report.ico");
        }
        public string Caption { get; set; }
        public string Text { get; set; }
        public Image Image { get; set; }
    }
}
