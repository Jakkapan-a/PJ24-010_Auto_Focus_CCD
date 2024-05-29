using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PJ24_010_Auto_Focus_CCD.Utilities;
namespace PJ24_010_Auto_Focus_CCD.Forms
{
    public partial class Historys : Form
    {
        public Historys()
        {
            InitializeComponent();
        }

        private int pageSize = 250; // จำนวนข้อมูลต่อหน้า
        private int currentPage = 1; // หน้าปัจจุบัน

        private int totalData;
        private int totalPages;
        private void Historys_Load(object sender, EventArgs e)
        {
            RenderDGVHistory();
            cbUseDate.Checked = Properties.Settings.Default.IsUseDate;
        }

        private void RenderDGVHistory()
        {
            DataTable dt = CreateDataTable();
            PopulateDataTableFromDatabase(dt);
            SetDataSourceAndUpdateSelection(dt);
            ConfigureDataGridViewDisplayProperties();
        }


        private DataTable CreateDataTable()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("id", typeof(int));
            dt.Columns.Add("no", typeof(int));
            dt.Columns.Add("name", typeof(string));
            dt.Columns.Add("qr_code", typeof(string));
            dt.Columns.Add("model", typeof(string));
            dt.Columns.Add("folder", typeof(string));
            dt.Columns.Add("result", typeof(string));
            dt.Columns.Add("reconfirm", typeof(string));
            dt.Columns.Add("created_at", typeof(string));
            return dt;
        }

        private void PopulateDataTableFromDatabase(DataTable dt)
        {
            List<SQLite.History> data = GetData();
            int i = (currentPage - 1) * pageSize;
            foreach (var item in data)
            {
                i++;
                dt.Rows.Add(item.id, i, item.employee, item.qr_code, item.model_name, item.path_folder, item.result, item.re_judgment, item.created_at);
            }
        }

        private List<SQLite.History> GetData()
        {
            string date = string.Empty;
            if (cbUseDate.Checked)
            {
                date = dateTimePicker1.Value.ToString("yyyy-MM-dd");
            }

            totalData = SQLite.History.Count(txtEmp.Text, txtModel.Text, txtQrCode.Text, txtResult.Text, txtReJudg.Text, date);
            totalPages = (int)Math.Ceiling((double)totalData / pageSize);

            return SQLite.History.Search(txtEmp.Text, txtModel.Text, txtQrCode.Text, txtResult.Text, txtReJudg.Text, date, (currentPage - 1) * pageSize, pageSize);

        }

        private void SetDataSourceAndUpdateSelection(DataTable dt)
        {
            int selectedRow = Extensions.GetSelectedRowIndex(dgvHistory);
            dgvHistory.ClearSelection();
            dgvHistory.DataSource = dt;
            Extensions.SelectedRow(dgvHistory, selectedRow);
        }

        private void ConfigureDataGridViewDisplayProperties()
        {
            dgvHistory.Columns["id"].Visible = false;
            SetDataGridViewColumnHeaders();
        }
        private void SetDataGridViewColumnHeaders()
        {
            dgvHistory.Columns["no"].HeaderText = "No.";
            dgvHistory.Columns["name"].HeaderText = "Employee";
            dgvHistory.Columns["qr_code"].HeaderText = "QR Code";
            dgvHistory.Columns["model"].HeaderText = "Model";
            dgvHistory.Columns["folder"].HeaderText = "Folder";
            dgvHistory.Columns["result"].HeaderText = "Result";
            dgvHistory.Columns["reconfirm"].HeaderText = "Reconfirm";
            dgvHistory.Columns["created_at"].HeaderText = "Created At";


            lbPage.Text = $"Page {currentPage} of {totalPages} ({totalData} records)";
            // Enable and disable btn previous,next
            btnPrevious.Enabled = currentPage > 1;
            btnNext.Enabled = currentPage < totalPages;
            // Enable and disable btnExport 
            btnExportCSV.Enabled = totalData > 0;
            //btnExportExcel.Enabled = totalData > 0;
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            currentPage = 1;
            RenderDGVHistory();
        }

        private void txtModel_TextChanged(object sender, EventArgs e)
        {
            currentPage = 1;
            RenderDGVHistory();
        }

        private void txtEmp_TextChanged(object sender, EventArgs e)
        {
            currentPage = 1;
            RenderDGVHistory();
        }

        private void txtQrCode_TextChanged(object sender, EventArgs e)
        {
            currentPage = 1;
            RenderDGVHistory();
        }

        private void txtResult_TextChanged(object sender, EventArgs e)
        {
            currentPage = 1;
            RenderDGVHistory();
        }

        private void txtReJudg_TextChanged(object sender, EventArgs e)
        {
            currentPage = 1;
            RenderDGVHistory();
        }

        private void cbUseDate_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.IsUseDate = cbUseDate.Checked;
            Properties.Settings.Default.Save();
            RenderDGVHistory();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (currentPage < totalPages)
            {
                currentPage++;
            }
            RenderDGVHistory();
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            if (currentPage > 1)
            {
                currentPage--;
            }
            RenderDGVHistory();
        }

        private void btnExportCSV_Click(object sender, EventArgs e)
        {
            ExportDataGridViewToCSV();
        }
        private async void ExportDataGridViewToCSV()
        {
            if (dgvHistory.Rows.Count > 0)
            {
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "CSV (*.csv)|*.csv";
                sfd.FileName = DateTime.Now.ToString("yyyyMMdd_HHmmssffff") + ".csv";
                bool fileError = false;
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    if (File.Exists(sfd.FileName))
                    {
                        try
                        {
                            File.Delete(sfd.FileName);
                        }
                        catch (IOException ex)
                        {
                            fileError = true;
                            MessageBox.Show("It's not possible to write the data to the disk." + ex.Message);
                        }
                    }
                    if (!fileError)
                    {
                        toolStripProgressBar.Visible = true;
                        toolStripProgressBar.Minimum = 1;
                        toolStripProgressBar.Maximum = dgvHistory.Rows.Count;
                        toolStripProgressBar.Value = 1;

                        await Task.Run(() =>
                        {
                            try
                            {
                                using (StreamWriter sw = new StreamWriter(sfd.FileName))
                                {
                                    StringBuilder sb = new StringBuilder();

                                    //Header
                                    for (int i = 1; i < dgvHistory.Columns.Count; i++)
                                    {
                                        sb.Append(dgvHistory.Columns[i].HeaderText);
                                        if (i != dgvHistory.Columns.Count - 1)
                                        {
                                            sb.Append(",");
                                        }
                                    }
                                    sw.WriteLine(sb.ToString());

                                    //Data
                                    for (int i = 1; i < dgvHistory.Rows.Count; i++)
                                    {
                                        sb.Clear();
                                        for (int j = 1; j < dgvHistory.Columns.Count; j++)
                                        {
                                            sb.Append(dgvHistory.Rows[i].Cells[j].Value);
                                            if (j != dgvHistory.Columns.Count - 1)
                                            {
                                                sb.Append(",");
                                            }
                                        }
                                        sw.WriteLine(sb.ToString());

                                        // Update the progress bar on the UI thread
                                        this.Invoke((Action)(() =>
                                        {
                                            toolStripProgressBar.Value = i + 1;
                                        }));
                                    }
                                }
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("Error :" + ex.Message);
                            }
                        });

                        toolStripProgressBar.Visible = false;
                        MessageBox.Show("Data exported successfully.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            else
            {
                MessageBox.Show("No records to export.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private SelectOnnxModels onnxModels;
        private void btnSelectModel_Click(object sender, EventArgs e)
        {
            onnxModels?.Dispose();
            onnxModels = new SelectOnnxModels();
            onnxModels.OnSelected += OnSelectModel;
            onnxModels.Show();
        }

        private void OnSelectModel(int arg1, string arg2)
        {
            txtModel.Text = arg2;
        }
    }
}
