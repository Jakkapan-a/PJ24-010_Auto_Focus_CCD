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

        private int pageSize = 100; // จำนวนข้อมูลต่อหน้า
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
    }
}
