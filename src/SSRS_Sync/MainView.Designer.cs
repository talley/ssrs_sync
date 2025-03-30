namespace SSRS_Sync
{
    partial class MainView
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainView));
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.btnDest = new DevExpress.XtraEditors.SimpleButton();
            this.txtLocalPath = new DevExpress.XtraEditors.TextEdit();
            this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
            this.btnSync = new DevExpress.XtraEditors.SimpleButton();
            this.btnUpload = new DevExpress.XtraEditors.SimpleButton();
            this.btnDownload = new DevExpress.XtraEditors.SimpleButton();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.btnmapds = new DevExpress.XtraEditors.SimpleButton();
            this.pbSource = new System.Windows.Forms.ProgressBar();
            this.rptSourceTree = new System.Windows.Forms.TreeView();
            this.btnSourceLoad = new DevExpress.XtraEditors.SimpleButton();
            this.chkSaveSource = new DevExpress.XtraEditors.CheckEdit();
            this.txtSourcePassword = new DevExpress.XtraEditors.TextEdit();
            this.txtSourceUser = new DevExpress.XtraEditors.TextEdit();
            this.txtSourceUrl = new DevExpress.XtraEditors.TextEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.groupControl3 = new DevExpress.XtraEditors.GroupControl();
            this.pbDest = new System.Windows.Forms.ProgressBar();
            this.rptDestTree = new System.Windows.Forms.TreeView();
            this.btnDestLoad = new DevExpress.XtraEditors.SimpleButton();
            this.chkSaveDest = new DevExpress.XtraEditors.CheckEdit();
            this.txtDestPassword = new DevExpress.XtraEditors.TextEdit();
            this.txtDestUser = new DevExpress.XtraEditors.TextEdit();
            this.txtDestUrl = new DevExpress.XtraEditors.TextEdit();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.bwDownload = new System.ComponentModel.BackgroundWorker();
            this.dlgDest = new System.Windows.Forms.FolderBrowserDialog();
            this.bwUpload = new System.ComponentModel.BackgroundWorker();
            this.bwSync = new System.ComponentModel.BackgroundWorker();
            this.dlgSaveFile = new System.Windows.Forms.SaveFileDialog();
            this.dlgOpenFile = new System.Windows.Forms.OpenFileDialog();
            this.mvvmContext1 = new DevExpress.Utils.MVVM.MVVMContext(this.components);
            this.toastNotificationsManager1 = new DevExpress.XtraBars.ToastNotifications.ToastNotificationsManager(this.components);
            this.alertControl1 = new DevExpress.XtraBars.Alerter.AlertControl(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtLocalPath.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkSaveSource.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSourcePassword.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSourceUser.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSourceUrl.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl3)).BeginInit();
            this.groupControl3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkSaveDest.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDestPassword.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDestUser.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDestUrl.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mvvmContext1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.toastNotificationsManager1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.btnDest);
            this.groupControl1.Controls.Add(this.txtLocalPath);
            this.groupControl1.Controls.Add(this.labelControl7);
            this.groupControl1.Controls.Add(this.btnSync);
            this.groupControl1.Controls.Add(this.btnUpload);
            this.groupControl1.Controls.Add(this.btnDownload);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupControl1.Location = new System.Drawing.Point(0, 922);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(1211, 103);
            this.groupControl1.TabIndex = 0;
            this.groupControl1.Text = "Options";
            // 
            // btnDest
            // 
            this.btnDest.Location = new System.Drawing.Point(441, 44);
            this.btnDest.Name = "btnDest";
            this.btnDest.Size = new System.Drawing.Size(93, 26);
            this.btnDest.TabIndex = 5;
            this.btnDest.Text = "Set Local Path";
            this.btnDest.Click += new System.EventHandler(this.btnDest_Click);
            // 
            // txtLocalPath
            // 
            this.txtLocalPath.Location = new System.Drawing.Point(108, 48);
            this.txtLocalPath.Name = "txtLocalPath";
            this.txtLocalPath.Size = new System.Drawing.Size(316, 22);
            this.txtLocalPath.TabIndex = 4;
            // 
            // labelControl7
            // 
            this.labelControl7.Location = new System.Drawing.Point(12, 51);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new System.Drawing.Size(90, 16);
            this.labelControl7.TabIndex = 3;
            this.labelControl7.Text = "Local Save Path";
            // 
            // btnSync
            // 
            this.btnSync.Location = new System.Drawing.Point(929, 44);
            this.btnSync.Name = "btnSync";
            this.btnSync.Size = new System.Drawing.Size(269, 29);
            this.btnSync.TabIndex = 2;
            this.btnSync.Text = "Sync Reports Between Servers";
            this.btnSync.Click += new System.EventHandler(this.btnSync_Click);
            // 
            // btnUpload
            // 
            this.btnUpload.Location = new System.Drawing.Point(762, 44);
            this.btnUpload.Name = "btnUpload";
            this.btnUpload.Size = new System.Drawing.Size(161, 29);
            this.btnUpload.TabIndex = 1;
            this.btnUpload.Text = "Upload Reports";
            this.btnUpload.Click += new System.EventHandler(this.btnUpload_Click);
            // 
            // btnDownload
            // 
            this.btnDownload.Location = new System.Drawing.Point(595, 44);
            this.btnDownload.Name = "btnDownload";
            this.btnDownload.Size = new System.Drawing.Size(161, 29);
            this.btnDownload.TabIndex = 0;
            this.btnDownload.Text = "Download Reports";
            this.btnDownload.Click += new System.EventHandler(this.btnDownload_Click);
            // 
            // groupControl2
            // 
            this.groupControl2.Controls.Add(this.btnmapds);
            this.groupControl2.Controls.Add(this.pbSource);
            this.groupControl2.Controls.Add(this.rptSourceTree);
            this.groupControl2.Controls.Add(this.btnSourceLoad);
            this.groupControl2.Controls.Add(this.chkSaveSource);
            this.groupControl2.Controls.Add(this.txtSourcePassword);
            this.groupControl2.Controls.Add(this.txtSourceUser);
            this.groupControl2.Controls.Add(this.txtSourceUrl);
            this.groupControl2.Controls.Add(this.labelControl3);
            this.groupControl2.Controls.Add(this.labelControl2);
            this.groupControl2.Controls.Add(this.labelControl1);
            this.groupControl2.Location = new System.Drawing.Point(0, 6);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(596, 936);
            this.groupControl2.TabIndex = 1;
            this.groupControl2.Text = "Source Web Service Information";
            // 
            // btnmapds
            // 
            this.btnmapds.Location = new System.Drawing.Point(147, 141);
            this.btnmapds.Name = "btnmapds";
            this.btnmapds.Size = new System.Drawing.Size(430, 26);
            this.btnmapds.TabIndex = 10;
            this.btnmapds.Text = "Map Data Sources";
            this.btnmapds.Click += new System.EventHandler(this.btnmapds_Click);
            // 
            // pbSource
            // 
            this.pbSource.Location = new System.Drawing.Point(0, 897);
            this.pbSource.Name = "pbSource";
            this.pbSource.Size = new System.Drawing.Size(584, 34);
            this.pbSource.TabIndex = 9;
            // 
            // rptSourceTree
            // 
            this.rptSourceTree.Location = new System.Drawing.Point(5, 173);
            this.rptSourceTree.Name = "rptSourceTree";
            this.rptSourceTree.Size = new System.Drawing.Size(584, 725);
            this.rptSourceTree.TabIndex = 8;
            // 
            // btnSourceLoad
            // 
            this.btnSourceLoad.Location = new System.Drawing.Point(388, 109);
            this.btnSourceLoad.Name = "btnSourceLoad";
            this.btnSourceLoad.Size = new System.Drawing.Size(189, 29);
            this.btnSourceLoad.TabIndex = 7;
            this.btnSourceLoad.Text = "Load Reports";
            this.btnSourceLoad.Click += new System.EventHandler(this.btnSourceLoad_Click);
            // 
            // chkSaveSource
            // 
            this.chkSaveSource.EditValue = true;
            this.chkSaveSource.Location = new System.Drawing.Point(388, 76);
            this.chkSaveSource.Name = "chkSaveSource";
            this.chkSaveSource.Properties.Caption = "Save Username";
            this.chkSaveSource.Size = new System.Drawing.Size(174, 24);
            this.chkSaveSource.TabIndex = 6;
            // 
            // txtSourcePassword
            // 
            this.txtSourcePassword.Location = new System.Drawing.Point(147, 113);
            this.txtSourcePassword.Name = "txtSourcePassword";
            this.txtSourcePassword.Properties.PasswordChar = '*';
            this.txtSourcePassword.Size = new System.Drawing.Size(235, 22);
            this.txtSourcePassword.TabIndex = 5;
            // 
            // txtSourceUser
            // 
            this.txtSourceUser.EditValue = "Administrator";
            this.txtSourceUser.Location = new System.Drawing.Point(147, 77);
            this.txtSourceUser.Name = "txtSourceUser";
            this.txtSourceUser.Size = new System.Drawing.Size(235, 22);
            this.txtSourceUser.TabIndex = 4;
            // 
            // txtSourceUrl
            // 
            this.txtSourceUrl.Location = new System.Drawing.Point(147, 38);
            this.txtSourceUrl.Name = "txtSourceUrl";
            this.txtSourceUrl.Size = new System.Drawing.Size(430, 22);
            this.txtSourceUrl.TabIndex = 3;
            this.txtSourceUrl.EditValueChanged += new System.EventHandler(this.textEdit1_EditValueChanged);
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(20, 116);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(101, 16);
            this.labelControl3.TabIndex = 2;
            this.labelControl3.Text = "System Password";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(20, 80);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(72, 16);
            this.labelControl2.TabIndex = 1;
            this.labelControl2.Text = "System User";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(20, 41);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(40, 16);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "WS Url";
            // 
            // groupControl3
            // 
            this.groupControl3.Controls.Add(this.pbDest);
            this.groupControl3.Controls.Add(this.rptDestTree);
            this.groupControl3.Controls.Add(this.btnDestLoad);
            this.groupControl3.Controls.Add(this.chkSaveDest);
            this.groupControl3.Controls.Add(this.txtDestPassword);
            this.groupControl3.Controls.Add(this.txtDestUser);
            this.groupControl3.Controls.Add(this.txtDestUrl);
            this.groupControl3.Controls.Add(this.labelControl4);
            this.groupControl3.Controls.Add(this.labelControl5);
            this.groupControl3.Controls.Add(this.labelControl6);
            this.groupControl3.Location = new System.Drawing.Point(595, 6);
            this.groupControl3.Name = "groupControl3";
            this.groupControl3.Size = new System.Drawing.Size(610, 936);
            this.groupControl3.TabIndex = 2;
            this.groupControl3.Text = "Destination Web Service Information";
            // 
            // pbDest
            // 
            this.pbDest.Location = new System.Drawing.Point(0, 897);
            this.pbDest.Name = "pbDest";
            this.pbDest.Size = new System.Drawing.Size(596, 34);
            this.pbDest.TabIndex = 17;
            // 
            // rptDestTree
            // 
            this.rptDestTree.Location = new System.Drawing.Point(0, 173);
            this.rptDestTree.Name = "rptDestTree";
            this.rptDestTree.Size = new System.Drawing.Size(603, 718);
            this.rptDestTree.TabIndex = 16;
            // 
            // btnDestLoad
            // 
            this.btnDestLoad.Location = new System.Drawing.Point(375, 109);
            this.btnDestLoad.Name = "btnDestLoad";
            this.btnDestLoad.Size = new System.Drawing.Size(220, 29);
            this.btnDestLoad.TabIndex = 15;
            this.btnDestLoad.Text = "Load Reports";
            // 
            // chkSaveDest
            // 
            this.chkSaveDest.EditValue = true;
            this.chkSaveDest.Location = new System.Drawing.Point(375, 76);
            this.chkSaveDest.Name = "chkSaveDest";
            this.chkSaveDest.Properties.Caption = "Save Username";
            this.chkSaveDest.Size = new System.Drawing.Size(174, 24);
            this.chkSaveDest.TabIndex = 14;
            // 
            // txtDestPassword
            // 
            this.txtDestPassword.Location = new System.Drawing.Point(134, 113);
            this.txtDestPassword.Name = "txtDestPassword";
            this.txtDestPassword.Properties.PasswordChar = '*';
            this.txtDestPassword.Size = new System.Drawing.Size(235, 22);
            this.txtDestPassword.TabIndex = 13;
            // 
            // txtDestUser
            // 
            this.txtDestUser.EditValue = "Administrator";
            this.txtDestUser.Location = new System.Drawing.Point(134, 77);
            this.txtDestUser.Name = "txtDestUser";
            this.txtDestUser.Size = new System.Drawing.Size(235, 22);
            this.txtDestUser.TabIndex = 12;
            // 
            // txtDestUrl
            // 
            this.txtDestUrl.Location = new System.Drawing.Point(134, 38);
            this.txtDestUrl.Name = "txtDestUrl";
            this.txtDestUrl.Size = new System.Drawing.Size(461, 22);
            this.txtDestUrl.TabIndex = 11;
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(7, 116);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(101, 16);
            this.labelControl4.TabIndex = 10;
            this.labelControl4.Text = "System Password";
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(7, 80);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(72, 16);
            this.labelControl5.TabIndex = 9;
            this.labelControl5.Text = "System User";
            // 
            // labelControl6
            // 
            this.labelControl6.Location = new System.Drawing.Point(7, 41);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(40, 16);
            this.labelControl6.TabIndex = 8;
            this.labelControl6.Text = "WS Url";
            // 
            // bwDownload
            // 
            this.bwDownload.WorkerReportsProgress = true;
            // 
            // bwUpload
            // 
            this.bwUpload.WorkerReportsProgress = true;
            // 
            // bwSync
            // 
            this.bwSync.WorkerReportsProgress = true;
            // 
            // dlgSaveFile
            // 
            this.dlgSaveFile.FileName = "ReportSync.rsn";
            this.dlgSaveFile.Filter = "ReportSync Files | *.rsn";
            this.dlgSaveFile.Title = "Save ReportSync selection";
            // 
            // dlgOpenFile
            // 
            this.dlgOpenFile.FileName = "ReportSync.rsn";
            this.dlgOpenFile.Filter = "ReportSync Files | *.rsn";
            this.dlgOpenFile.Title = "Open ReportSync file";
            // 
            // mvvmContext1
            // 
            this.mvvmContext1.ContainerControl = this;
            this.mvvmContext1.ViewModelType = typeof(SSRS_Sync.MainViewModel);
            // 
            // toastNotificationsManager1
            // 
            this.toastNotificationsManager1.ApplicationId = "f76dce02-7ae9-4fad-85d5-628d90458980";
            this.toastNotificationsManager1.Notifications.AddRange(new DevExpress.XtraBars.ToastNotifications.IToastNotificationProperties[] {
            new DevExpress.XtraBars.ToastNotifications.ToastNotification("1e1b8651-0e6f-4f9d-88af-035f844c0547", ((System.Drawing.Image)(resources.GetObject("toastNotificationsManager1.Notifications"))), "Pellentesque lacinia tellus eget volutpat", "Please make sure the SSRS Web Service URL is correct", "Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor i" +
                    "ncididunt ut labore et dolore magna aliqua.", DevExpress.XtraBars.ToastNotifications.ToastNotificationTemplate.Text01)});
            // 
            // MainView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1211, 1025);
            this.Controls.Add(this.groupControl3);
            this.Controls.Add(this.groupControl2);
            this.Controls.Add(this.groupControl1);
            this.IconOptions.Image = ((System.Drawing.Image)(resources.GetObject("MainView.IconOptions.Image")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SSRS Sync Manager";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainView_FormClosed);
            this.Load += new System.EventHandler(this.MainView_Load);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtLocalPath.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            this.groupControl2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkSaveSource.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSourcePassword.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSourceUser.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSourceUrl.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl3)).EndInit();
            this.groupControl3.ResumeLayout(false);
            this.groupControl3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkSaveDest.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDestPassword.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDestUser.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDestUrl.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mvvmContext1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.toastNotificationsManager1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.Utils.MVVM.MVVMContext mvvmContext1;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.GroupControl groupControl3;
        private DevExpress.XtraEditors.GroupControl groupControl2;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.TextEdit txtSourceUrl;
        private DevExpress.XtraEditors.TextEdit txtSourceUser;
        private DevExpress.XtraEditors.TextEdit txtSourcePassword;
        private DevExpress.XtraEditors.CheckEdit chkSaveSource;
        private DevExpress.XtraEditors.SimpleButton btnSourceLoad;
        private DevExpress.XtraEditors.SimpleButton btnDestLoad;
        private DevExpress.XtraEditors.CheckEdit chkSaveDest;
        private DevExpress.XtraEditors.TextEdit txtDestPassword;
        private DevExpress.XtraEditors.TextEdit txtDestUser;
        private DevExpress.XtraEditors.TextEdit txtDestUrl;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraEditors.SimpleButton btnDownload;
        private System.Windows.Forms.TreeView rptSourceTree;
        private System.Windows.Forms.TreeView rptDestTree;
        private DevExpress.XtraEditors.SimpleButton btnUpload;
        private DevExpress.XtraEditors.SimpleButton btnSync;
        private DevExpress.XtraEditors.TextEdit txtLocalPath;
        private DevExpress.XtraEditors.LabelControl labelControl7;
        private DevExpress.XtraEditors.SimpleButton btnDest;
        private System.Windows.Forms.ProgressBar pbSource;
        private System.Windows.Forms.ProgressBar pbDest;
        private System.ComponentModel.BackgroundWorker bwDownload;
        private System.Windows.Forms.FolderBrowserDialog dlgDest;
        private System.ComponentModel.BackgroundWorker bwUpload;
        private System.ComponentModel.BackgroundWorker bwSync;
        private System.Windows.Forms.SaveFileDialog dlgSaveFile;
        private System.Windows.Forms.OpenFileDialog dlgOpenFile;
        private DevExpress.XtraEditors.SimpleButton btnmapds;
        private DevExpress.XtraBars.ToastNotifications.ToastNotificationsManager toastNotificationsManager1;
        private DevExpress.XtraBars.Alerter.AlertControl alertControl1;
    }
}

