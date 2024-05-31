using PJ24_010_Auto_Focus_CCD.SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Extensions = PJ24_010_Auto_Focus_CCD.Utilities.Extensions;

namespace PJ24_010_Auto_Focus_CCD.Forms
{
    public partial class Products : Form
    {
        public Products()
        {
            InitializeComponent();
        }
        private int onnx_id = -1;
        private int id = -1;
        private string typePVM = "PVM(4.6V)";
        private void Products_Load(object sender, EventArgs e)
        {
            cbType.SelectedIndex = 0;
            RenderTable();
        }

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
            dt.Columns.Add("type", typeof(string));
            dt.Columns.Add("voltage_min", typeof(string));
            dt.Columns.Add("voltage_max", typeof(string));
            dt.Columns.Add("current_min", typeof(string));
            dt.Columns.Add("current_max", typeof(string));
            dt.Columns.Add("onnx_model_name", typeof(string));
            dt.Columns.Add("updated_at", typeof(string));
            return dt;
        }


        private void PopulateDataTableFromDatabase(DataTable dt)
        {
            totalData = Product.Count();
            totalPages = (int)Math.Ceiling((double)totalData / pageSize);

            List<Product> products = Product.Search(name: txtSearch.Text, start: (currentPage - 1) * pageSize, limit: pageSize);
            int no = (currentPage - 1) * pageSize;
            foreach (Product product in products)
            {
                if (product == null) continue;
                no++;
                int onnx_id = product.onnx_model_id;
                OnnxModel onnx = OnnxModel.Get(onnx_id);
                dt.Rows.Add(product.id, no, product.name, product.type == 1 ? "PVM(4.6V)" : "NONE(6.0V)", $"{(double)product.voltage_min / 1000:f2}", $"{(double)product.voltage_max / 1000:f2}", $"{(double)product.current_min / 1000:f2}", $"{(double)product.current_max / 1000:f2}", onnx == null?"-": onnx.name, product.updated_at);
            }
        }

        private void SetDataSourceAndUpdateSelection(DataTable dt)
        {

            int selectedRow = Extensions.GetSelectedRowIndex(dgvProduct);
            dgvProduct.ClearSelection();
            dgvProduct.DataSource = dt;

            // Select old row
            Extensions.SelectedRow(dgvProduct, selectedRow);
        }

        private void ConfigureDataGridViewDisplayProperties()
        {
            dgvProduct.Columns["id"].Visible = false;
            dgvProduct.Columns["no"].Width = 30;
            SetDataGridViewColumnHeaders();
        }
        private void SetDataGridViewColumnHeaders()
        {
            dgvProduct.Columns["name"].HeaderText = "Name";
            dgvProduct.Columns["name"].HeaderText = "Name";
            dgvProduct.Columns["type"].HeaderText = "Type";
            dgvProduct.Columns["voltage_min"].HeaderText = "Voltage Min";
            dgvProduct.Columns["voltage_max"].HeaderText = "Voltage Max";
            dgvProduct.Columns["current_min"].HeaderText = "Current Min (mA)";
            dgvProduct.Columns["current_max"].HeaderText = "Current Max (mA)";
            dgvProduct.Columns["onnx_model_name"].HeaderText = "Onnx Model";
            dgvProduct.Columns["updated_at"].HeaderText = "Updated At";

            // Enable and disable buttons
            btnPrevious.Enabled = currentPage > 1;
            btnNext.Enabled = currentPage < totalPages;

            lbPage.Text = $"Page {currentPage} of {totalPages}";
        }

        private SelectOnnxModels selectOnnxModels;
        private void btnOnnxSelect_Click(object sender, EventArgs e)
        {
            selectOnnxModels?.Dispose();
            selectOnnxModels = new SelectOnnxModels();

            selectOnnxModels.OnSelected += selectModels;
            selectOnnxModels.ShowDialog();

        }

        private void selectModels(int id, string name)
        {
            onnx_id = id;
            txtOnnx.Text = name;
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            txtName.Text = string.Empty;
            cbType.SelectedIndex = 0;
            onnx_id = -1;
            id = -1;

            txtMinVoltage.Value = 0;
            txtMaxVoltage.Value = 10;
            txtMinAmp.Value = 0;
            txtMaxAmp.Value = 1000;

            btnSave.Text = "Save";
            btnSave.Enabled = true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!ValidateInputs()) return;

            btnSave.Enabled = false;
            try
            {
                if (btnSave.Text == "Save")
                {
                    if (Product.IsNameExist(txtName.Text))
                    {
                        throw new Exception("Name already exists.");
                    }
                    // Save new
                    Product product = new Product();
                    product.name = txtName.Text;
                    product.type = cbType.SelectedIndex;
                    product.voltage_min = Convert.ToInt32(txtMinVoltage.Value * 1000);
                    product.voltage_max = Convert.ToInt32(txtMaxVoltage.Value * 1000);
                    product.current_min = Convert.ToInt32(txtMinAmp.Value * 1000);
                    product.current_max = Convert.ToInt32(txtMaxAmp.Value * 1000);
                    product.onnx_model_id = onnx_id;
                    product.Save();

                    MessageBox.Show("Saved successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (btnSave.Text == "Update")
                {
                    if (Product.IsNameExist(txtName.Text, this.id))
                    {
                        throw new Exception("Name already exists.");
                    }

                    // Update
                    Product? product = Product.Get(id);
                    if (product != null)
                    {
                        product.name = txtName.Text;
                        product.type = cbType.SelectedIndex;
                        product.voltage_min = Convert.ToInt32(txtMinVoltage.Value * 1000);
                        product.voltage_max = Convert.ToInt32(txtMaxVoltage.Value * 1000);
                        product.current_min = Convert.ToInt32(txtMinAmp.Value * 1000);
                        product.current_max = Convert.ToInt32(txtMaxAmp.Value * 1000);
                        product.onnx_model_id = onnx_id;
                        product.Update();
                    }

                    MessageBox.Show("Updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnSave.Enabled = true;
                btnSave.Text = dgvProduct.SelectedRows.Count > 0 ? "Update" : "Save";
                txtName.ReadOnly = false;
            }
            finally
            {
                btnSave.Enabled = true;
                RenderTable();
            }

        }

        private bool ValidateInputs()
        {
            // Validate inputs txtName, txtOnnx, onnx_id
            if (txtName.Text == "")
            {
                MessageBox.Show("Name is required.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (onnx_id == -1)
            {
                MessageBox.Show("Onnx model is required.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        private void dgvProduct_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvProduct.SelectedRows.Count > 0)
            {
                int selectedRow = Extensions.GetSelectedRowIndex(dgvProduct);
                id = Convert.ToInt32(dgvProduct.Rows[selectedRow].Cells["id"].Value);
                txtName.Text = dgvProduct.Rows[selectedRow].Cells["name"].Value.ToString();
                cbType.SelectedIndex = dgvProduct.Rows[selectedRow].Cells["type"].Value.ToString() == typePVM ? 1 : 0;
                txtMinVoltage.Value = Convert.ToDecimal(dgvProduct.Rows[selectedRow].Cells["voltage_min"].Value);
                txtMaxVoltage.Value = Convert.ToDecimal(dgvProduct.Rows[selectedRow].Cells["voltage_max"].Value);
                txtMinAmp.Value = Convert.ToDecimal(dgvProduct.Rows[selectedRow].Cells["current_min"].Value);
                txtMaxAmp.Value = Convert.ToDecimal(dgvProduct.Rows[selectedRow].Cells["current_max"].Value);
                onnx_id = Product.Get(id).onnx_model_id;
                OnnxModel onnx = OnnxModel.Get(onnx_id);
                txtOnnx.Text = onnx == null ?"-":onnx.name;
                
                btnSave.Text = "Update";
                btnSave.Enabled = true;
            }
            else
            {
                btnSave.Text = "Save";
                btnSave.Enabled = true;
                id = -1;
                onnx_id = -1;
                txtOnnx.Text = "";
            }
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {
            if (Product.IsNameExist(txtName.Text, this.id))
            {
                txtName.BackColor = Color.Red;
            }
            else
            {
                txtName.BackColor = Color.White;
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvProduct.SelectedRows.Count > 0)
            {
                if (MessageBox.Show("Are you sure you want to delete this record?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    Product? product = Product.Get(id);
                    if (product != null)
                    {
                        product.Delete();
                    }
                    RenderTable();
                }
            }
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            if(currentPage > 1)
            {
                currentPage--;
                RenderTable();
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if(currentPage < totalPages)
            {
                currentPage++;
                RenderTable();
            }
        }
    }
}
