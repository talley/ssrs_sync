﻿using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SSRS_Sync
{
    public partial class MapDatasources : DevExpress.XtraEditors.XtraForm
    {
        public Dictionary<string, string> sourceDS;
        public Dictionary<string, string> destDS;

        public MapDatasources()
        {
            InitializeComponent();
        }

        private void MapDatasources_Load(object sender, EventArgs e)
        {
            if (sourceDS == null || destDS == null)
            {
                MessageBox.Show("Please load source and destination directories before you can map datasources.", "Datasources not loaded", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
            }
            else
            {
                dataSourcesGrid.DataSource = new BindingSource(sourceDS, "");
                ((DataGridViewComboBoxColumn)dataSourcesGrid.Columns["Destination"]).DataSource = new BindingSource(destDS, "");
                ((DataGridViewComboBoxColumn)dataSourcesGrid.Columns["Destination"]).DisplayMember = "Value";
                ((DataGridViewComboBoxColumn)dataSourcesGrid.Columns["Destination"]).ValueMember = "Value";
                dataSourcesGrid.DataError += new DataGridViewDataErrorEventHandler(dataSourcesGrid_DataError);
            }
        }

        void dataSourcesGrid_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.ToString();
        }

        private void btnSet_Click(object sender, EventArgs e)
        {
            int i = 0;
            foreach (var entry in sourceDS)
            {
                if (dataSourcesGrid["Destination", i].Value != null)
                {
                    var destPath = dataSourcesGrid["Destination", i].Value.ToString();

                    if (destDS.ContainsKey(entry.Key))
                        destDS[entry.Key] = destPath;
                    else
                        destDS.Add(entry.Key, destPath);
                }
                i++;
            }
            DialogResult = DialogResult.OK;
        }

        private void dataSourcesGrid_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            int i = 0;
            foreach (var entry in sourceDS)
            {
                if (destDS.ContainsKey(entry.Key))
                {
                    dataSourcesGrid["Destination", i].Value = destDS[entry.Key];
                }
                i++;
            }
        }
    }
}