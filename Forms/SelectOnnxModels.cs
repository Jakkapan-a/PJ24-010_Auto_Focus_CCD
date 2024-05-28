using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using Extensions = PJ24_010_Auto_Focus_CCD.Utilities.Extensions;

namespace PJ24_010_Auto_Focus_CCD.Forms
{
    public partial class SelectOnnxModels : Form
    {
        public Action<int, string> OnSelected; // Id, Name

        public SelectOnnxModels()
        {
            InitializeComponent();
        }

        private void SelectOnnxModels_Load(object sender, EventArgs e)
        {
            RenderTable();
        }

        private int? id = -1;
        private int pageSize = 100; // จำนวนข้อมูลต่อหน้า
        private int currentPage = 1; // หน้าปัจจุบัน
        private int totalData;
        private int totalPages;
        private void RenderTable()
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
            dt.Columns.Add("path_model", typeof(string));
            dt.Columns.Add("path_label", typeof(string));
            dt.Columns.Add("updated_at", typeof(string));
            return dt;
        }

        private void PopulateDataTableFromDatabase(DataTable dt)
        {
            totalData = SQLite.OnnxModel.Count();
            totalPages = (int)Math.Ceiling((double)totalData / pageSize);

            List<SQLite.OnnxModel> onnxes = SQLite.OnnxModel.Search(name: txtSearch.Text, start: (currentPage - 1) * pageSize, limit: pageSize);
            int no = (currentPage - 1) * pageSize;
            foreach (SQLite.OnnxModel onnx in onnxes)
            {
                no++;
                dt.Rows.Add(onnx.id, no, onnx.name, onnx.path_model, onnx.path_label, onnx.updated_at);
            }
        }

        private void SetDataSourceAndUpdateSelection(DataTable dt)
        {

            int selectedRow = Extensions.GetSelectedRowIndex(dgvOnnx);
            dgvOnnx.ClearSelection();
            dgvOnnx.DataSource = dt;

            // Select old row
            Extensions.SelectedRow(dgvOnnx, selectedRow);
        }

        private void ConfigureDataGridViewDisplayProperties()
        {
            dgvOnnx.Columns["id"].Visible = false;
            dgvOnnx.Columns["no"].Width = 30;
            dgvOnnx.Columns["path_model"].Visible = false;
            dgvOnnx.Columns["path_label"].Visible = false;
            dgvOnnx.Columns["updated_at"].Visible = false;
            SetDataGridViewColumnHeaders();
        }
        private void SetDataGridViewColumnHeaders()
        {

            dgvOnnx.Columns["no"].HeaderText = "No";
            dgvOnnx.Columns["name"].HeaderText = "Name";

            // Enable and disable btn previous,next
            btnPrevious.Enabled = currentPage > 1;
            btnNext.Enabled = currentPage < totalPages;

            lbPage.Text = $"Page {currentPage} of {totalPages} ({totalData} records)";
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            currentPage++;
            this.RenderTable();
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            currentPage--;
            this.RenderTable();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            this.RenderTable();
        }

        private void dgvOnnx_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (dgvOnnx.SelectedRows.Count > 0)
            {
                int id = Convert.ToInt32(dgvOnnx.SelectedRows[0].Cells["id"].Value);
                string name = dgvOnnx.SelectedRows[0].Cells["name"].Value.ToString();
                OnSelected?.Invoke(id, name);
                this.Close();
            }
        }
    }
}
