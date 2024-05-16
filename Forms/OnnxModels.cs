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
using PJ24_010_Auto_Focus_CCD.Utilities;
using System.Xml.Linq;
using PJ24_010_Auto_Focus_CCD.SQLite;
using Emgu.CV.Dnn;
using Extensions = PJ24_010_Auto_Focus_CCD.Utilities.Extensions;
using System.Diagnostics;
namespace PJ24_010_Auto_Focus_CCD.Forms
{
    public partial class OnnxModels : Form
    {
        public OnnxModels()
        {
            InitializeComponent();
        }

        private void OnnxModels_Load(object sender, EventArgs e)
        {
            RenderTable();
        }

        private int id = -1;
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
            dgvOnnx.Columns["no"].Width = 50;

            SetDataGridViewColumnHeaders();
        }
        private void SetDataGridViewColumnHeaders()
        {

            dgvOnnx.Columns["no"].HeaderText = "No";
            dgvOnnx.Columns["name"].HeaderText = "Name";
            dgvOnnx.Columns["path_model"].HeaderText = "Model";
            dgvOnnx.Columns["path_label"].HeaderText = "Label";
            dgvOnnx.Columns["updated_at"].HeaderText = "Date";
            // Enable and disable btn previous,next
            btnPrevious.Enabled = currentPage > 1;
            btnNext.Enabled = currentPage < totalPages;

            lbPage.Text = $"Page {currentPage} of {totalPages} ({totalData} records)";
        }
        public async Task StartCopyingFiles(string sourcePath, string destinationPath)
        {
            // Use a Progress<T> to report progress updates
            var progressReporter = new Progress<int>(value =>
            {
                // Update your UI progress bar or any UI element here
                Debug.WriteLine($"Progress: {value}%");

                if (InvokeRequired)
                {
                    Invoke(new Action(() =>
                    {
                        toolStripProgressBar1.Value = value;
                        toolStripStatusLabel.Text = $"{value}%";
                    }));
                }
                else
                {
                    toolStripProgressBar1.Value = value;
                    toolStripStatusLabel.Text = $"{value}%";
                }
            });

            await Utilities.CopyFile.CopyFileWithProgressAsync(sourcePath, destinationPath, progressReporter);
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            txtName.Text = string.Empty;
            txtOnnx.Text = string.Empty;
            txtLabel.Text = string.Empty;
            txtSearch.Text = string.Empty;

            dgvOnnx.ClearSelection();
            btnSave.Text = "Save";
            btnSave.Enabled = true;
            btnOnnx.Enabled = true;
            btnLabel.Enabled = true;
            txtName.ReadOnly = false;

            this.id = -1;
            btnDelete.Enabled = false;

        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            // Validate data
            if (!ValidateInputs()) return;
            btnSave.Enabled = false;
            toolStripProgressBar1.Visible = true;
            try
            {
                if (btnSave.Text == "Save")
                {
                    if (OnnxModel.IsNameExist(txtName.Text))
                    {
                        throw new Exception("Name already exists.");
                    }
                    await CreateNewModel();
                }
                else if (btnSave.Text == "Update")
                {
                    if (OnnxModel.IsNameExist(txtName.Text, this.id))
                    {
                        throw new Exception("Name already exists.");
                    }
                    await UpdateModel();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnSave.Enabled = true;
                btnSave.Text = dgvOnnx.SelectedRows.Count > 0 ? "Update" : "Save";
                txtName.ReadOnly = false;
            }
            finally
            {
                toolStripProgressBar1.Visible = false;
                toolStripStatusLabel.Text = "-";
            }
        }

        private async Task CreateNewModel()
        {
            btnSave.Text = "Saving..";
            btnSave.Enabled = false;

            string dateStr = DateTime.Now.ToString("yyyyMMddHHmmss");
            string newFilename = dateStr + "_" + System.IO.Path.GetFileName(txtOnnx.Text);
            OnnxModel onnx = new OnnxModel();
            onnx.name = txtName.Text;
            Directory.CreateDirectory(Properties.Resources.path_models);

            // ONNX
            string sourcePath = txtOnnx.Text;
            string destinationPath = System.IO.Path.Combine(Properties.Resources.path_models, newFilename);
            await StartCopyingFiles(sourcePath, destinationPath);

            onnx.path_model = newFilename;

            // Label
            newFilename = dateStr + "_" + System.IO.Path.GetFileName(txtLabel.Text);
            onnx.path_label = newFilename;
            sourcePath = txtLabel.Text;
            destinationPath = System.IO.Path.Combine(Properties.Resources.path_models, newFilename);
            await StartCopyingFiles(sourcePath, destinationPath);

            // Save
            onnx.Save();
            MessageBox.Show("Save success.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

            this.RenderTable();
            // Reset button
            btnSave.Text = "Save";
            btnSave.Enabled = false;
            btnOnnx.Enabled = false;
            btnLabel.Enabled = false;
            txtName.ReadOnly = true;
        }

        private async Task UpdateModel()
        {
            btnSave.Enabled = true;
            btnSave.Text = "Updating..";

            OnnxModel? onnx = OnnxModel.Get(id);

            if (onnx == null)
            {
                throw new Exception("Model not found.");
            }

            if (onnx.name != txtName.Text)
            {
                onnx.name = txtName.Text;
            }

            if (onnx.path_model != txtOnnx.Text)
            {
                string dateStr = DateTime.Now.ToString("yyyyMMddHHmmss");
                string newFilename = dateStr + "_" + System.IO.Path.GetFileName(txtOnnx.Text);
                Directory.CreateDirectory(Properties.Resources.path_models);

                // ONNX
                string sourcePath = txtOnnx.Text;
                string destinationPath = System.IO.Path.Combine(Properties.Resources.path_models, newFilename);
                await StartCopyingFiles(sourcePath, destinationPath);

                onnx.path_model = newFilename;
            }

            if (onnx.path_label != txtLabel.Text)
            {
                string dateStr = DateTime.Now.ToString("yyyyMMddHHmmss");
                string newFilename = dateStr + "_" + System.IO.Path.GetFileName(txtLabel.Text);
                Directory.CreateDirectory(Properties.Resources.path_models);

                // Label
                string sourcePath = txtLabel.Text;
                string destinationPath = System.IO.Path.Combine(Properties.Resources.path_models, newFilename);
                await StartCopyingFiles(sourcePath, destinationPath);

                onnx.path_label = newFilename;
            }

            // Save
            onnx.Update();

            MessageBox.Show("Update success.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

            btnSave.Text = "Save";

            this.RenderTable();
            // Reset button
            btnSave.Enabled = false;
            btnOnnx.Enabled = false;
            btnLabel.Enabled = false;
            txtName.ReadOnly = true;
        }

        private bool ValidateInputs()
        {
            return ValidateTextBox(txtName, "Please enter name.") &&
                   ValidateTextBox(txtOnnx, "Please select onnx file.") &&
                   ValidateTextBox(txtLabel, "Please select label file.");
        }
        private bool ValidateTextBox(System.Windows.Forms.TextBox textBox, string errorMessage)
        {
            if (string.IsNullOrWhiteSpace(textBox.Text))
            {
                ShowError(errorMessage, textBox);
                return false;
            }
            return true;
        }


        private void ShowError(string message, System.Windows.Forms.Control? control = null)
        {
            MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            if (control != null)
            {
                ActiveControl = control;
                control.Focus();
            }
        }

        private void btnOnnx_Click(object sender, EventArgs e)
        {
            // Open file dialog
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "ONNX files (*.onnx)|*.onnx";
            openFileDialog.RestoreDirectory = true;

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                // Get file path
                string filePath = openFileDialog.FileName;
                // Get file name
                string fileName = openFileDialog.SafeFileName;

                // Add file name to txtModel
                txtOnnx.Text = filePath;
            }
        }

        private void btnLabel_Click(object sender, EventArgs e)
        {
            // Open file dialog
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Label files (*.txt)|*.txt";
            openFileDialog.RestoreDirectory = true;
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                // Get file path
                string filePath = openFileDialog.FileName;
                // Get file name
                string fileName = openFileDialog.SafeFileName;
                // Add file name to txtLabel
                txtLabel.Text = filePath;
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            this.RenderTable();
        }

        private void dgvOnnx_SelectionChanged(object sender, EventArgs e)
        {
            // Get id from selected row
            if (dgvOnnx.SelectedRows.Count > 0)
            {
                this.id = Convert.ToInt32(dgvOnnx.SelectedRows[0].Cells["id"].Value);
                btnDelete.Enabled = true;
                btnSave.Text = "Update";
                btnSave.Enabled = true;
                btnOnnx.Enabled = true;
                btnLabel.Enabled = true;
                txtName.ReadOnly = false;

                txtName.Text = dgvOnnx.SelectedRows[0].Cells["name"].Value.ToString();
                txtOnnx.Text = dgvOnnx.SelectedRows[0].Cells["path_model"].Value.ToString();
                txtLabel.Text = dgvOnnx.SelectedRows[0].Cells["path_label"].Value.ToString();

                string path_label = System.IO.Path.Combine(Properties.Resources.path_models, txtLabel.Text);

                // Read label file
                if (System.IO.File.Exists(path_label))
                {
                    string[] lines = System.IO.File.ReadAllLines(path_label);
                    string label = string.Join("\n", lines);
                    // txtLabel.Text = label;
                    txtDetailLabel.Text = label;
                }
            }
            else
            {
                this.id = -1;
                btnDelete.Enabled = false;
                btnSave.Text = "Save";
                btnSave.Enabled = true;
                btnOnnx.Enabled = true;
                btnLabel.Enabled = true;
                txtName.ReadOnly = true;
                txtDetailLabel.Text = string.Empty;
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (this.id != -1)
            {
                OnnxModel? onnx = OnnxModel.Get(this.id);
                if (onnx != null)
                {
                    onnx.Delete();
                    this.RenderTable();
                }
            }
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

        private void txtName_TextChanged(object sender, EventArgs e)
        {
            if(OnnxModel.IsNameExist(txtName.Text, this.id))
            {
                txtName.BackColor = Color.Red;
            }
            else
            {
                txtName.BackColor = Color.White;
            }
        }
    }
}
