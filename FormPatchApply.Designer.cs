
namespace WinSCPFileTransfer
{
    partial class FormPatchApply
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
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.pagePatch = new System.Windows.Forms.TabPage();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.BttnPOSList = new System.Windows.Forms.Button();
            this.checkPOS = new System.Windows.Forms.CheckBox();
            this.ListPOS = new System.Windows.Forms.CheckedListBox();
            this.label4 = new System.Windows.Forms.Label();
            this.checkCategory = new System.Windows.Forms.CheckBox();
            this.checkLocation = new System.Windows.Forms.CheckBox();
            this.ListLocation = new System.Windows.Forms.CheckedListBox();
            this.BtnTransfer = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.ListCategory = new System.Windows.Forms.CheckedListBox();
            this.pageTask = new System.Windows.Forms.TabPage();
            this.dgvFiles = new System.Windows.Forms.DataGridView();
            this.label6 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tabTask = new System.Windows.Forms.TabControl();
            this.dataGridViewImageColumn1 = new System.Windows.Forms.DataGridViewImageColumn();
            this.tabMapping = new System.Windows.Forms.TabPage();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.colFilename = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColLocation = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DestPath = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.remove = new System.Windows.Forms.DataGridViewImageColumn();
            this.btnSave = new FontAwesome.Sharp.IconButton();
            this.label5 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.btnSelectFiles = new FontAwesome.Sharp.IconButton();
            this.pagePatch.SuspendLayout();
            this.pageTask.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFiles)).BeginInit();
            this.tabTask.SuspendLayout();
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.Multiselect = true;
            // 
            // pagePatch
            // 
            this.pagePatch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(25)))), ((int)(((byte)(72)))));
            this.pagePatch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pagePatch.Controls.Add(this.progressBar1);
            this.pagePatch.Controls.Add(this.BttnPOSList);
            this.pagePatch.Controls.Add(this.checkPOS);
            this.pagePatch.Controls.Add(this.ListPOS);
            this.pagePatch.Controls.Add(this.label4);
            this.pagePatch.Controls.Add(this.checkCategory);
            this.pagePatch.Controls.Add(this.checkLocation);
            this.pagePatch.Controls.Add(this.ListLocation);
            this.pagePatch.Controls.Add(this.BtnTransfer);
            this.pagePatch.Controls.Add(this.label2);
            this.pagePatch.Controls.Add(this.label1);
            this.pagePatch.Controls.Add(this.ListCategory);
            this.pagePatch.ForeColor = System.Drawing.Color.Gainsboro;
            this.pagePatch.Location = new System.Drawing.Point(4, 44);
            this.pagePatch.Name = "pagePatch";
            this.pagePatch.Padding = new System.Windows.Forms.Padding(3);
            this.pagePatch.Size = new System.Drawing.Size(1202, 630);
            this.pagePatch.TabIndex = 1;
            this.pagePatch.Text = "Apply Patch";
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(277, 672);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(276, 23);
            this.progressBar1.TabIndex = 44;
            // 
            // BttnPOSList
            // 
            this.BttnPOSList.ForeColor = System.Drawing.Color.Black;
            this.BttnPOSList.Location = new System.Drawing.Point(838, 256);
            this.BttnPOSList.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.BttnPOSList.Name = "BttnPOSList";
            this.BttnPOSList.Size = new System.Drawing.Size(169, 33);
            this.BttnPOSList.TabIndex = 43;
            this.BttnPOSList.Text = "Populate POS List";
            this.BttnPOSList.UseVisualStyleBackColor = true;
            // 
            // checkPOS
            // 
            this.checkPOS.AutoSize = true;
            this.checkPOS.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkPOS.ForeColor = System.Drawing.Color.Gainsboro;
            this.checkPOS.Location = new System.Drawing.Point(965, 17);
            this.checkPOS.Margin = new System.Windows.Forms.Padding(4);
            this.checkPOS.Name = "checkPOS";
            this.checkPOS.Size = new System.Drawing.Size(102, 24);
            this.checkPOS.TabIndex = 42;
            this.checkPOS.Text = "Select All";
            this.checkPOS.UseVisualStyleBackColor = true;
            // 
            // ListPOS
            // 
            this.ListPOS.BackColor = System.Drawing.SystemColors.Info;
            this.ListPOS.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ListPOS.FormattingEnabled = true;
            this.ListPOS.Location = new System.Drawing.Point(783, 57);
            this.ListPOS.Margin = new System.Windows.Forms.Padding(4);
            this.ListPOS.Name = "ListPOS";
            this.ListPOS.Size = new System.Drawing.Size(284, 193);
            this.ListPOS.TabIndex = 41;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Gainsboro;
            this.label4.Location = new System.Drawing.Point(783, 17);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(97, 20);
            this.label4.TabIndex = 40;
            this.label4.Text = "Target POS";
            // 
            // checkCategory
            // 
            this.checkCategory.AutoSize = true;
            this.checkCategory.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkCategory.ForeColor = System.Drawing.Color.Gainsboro;
            this.checkCategory.Location = new System.Drawing.Point(628, 17);
            this.checkCategory.Margin = new System.Windows.Forms.Padding(4);
            this.checkCategory.Name = "checkCategory";
            this.checkCategory.Size = new System.Drawing.Size(102, 24);
            this.checkCategory.TabIndex = 39;
            this.checkCategory.Text = "Select All";
            this.checkCategory.UseVisualStyleBackColor = true;
            // 
            // checkLocation
            // 
            this.checkLocation.AutoSize = true;
            this.checkLocation.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkLocation.ForeColor = System.Drawing.Color.Gainsboro;
            this.checkLocation.Location = new System.Drawing.Point(367, 17);
            this.checkLocation.Margin = new System.Windows.Forms.Padding(4);
            this.checkLocation.Name = "checkLocation";
            this.checkLocation.Size = new System.Drawing.Size(102, 24);
            this.checkLocation.TabIndex = 38;
            this.checkLocation.Text = "Select All";
            this.checkLocation.UseVisualStyleBackColor = true;
            // 
            // ListLocation
            // 
            this.ListLocation.BackColor = System.Drawing.Color.Gainsboro;
            this.ListLocation.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ListLocation.FormattingEnabled = true;
            this.ListLocation.Location = new System.Drawing.Point(277, 57);
            this.ListLocation.Margin = new System.Windows.Forms.Padding(4);
            this.ListLocation.Name = "ListLocation";
            this.ListLocation.Size = new System.Drawing.Size(251, 193);
            this.ListLocation.TabIndex = 37;
            // 
            // BtnTransfer
            // 
            this.BtnTransfer.ForeColor = System.Drawing.Color.Black;
            this.BtnTransfer.Location = new System.Drawing.Point(911, 442);
            this.BtnTransfer.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.BtnTransfer.Name = "BtnTransfer";
            this.BtnTransfer.Size = new System.Drawing.Size(116, 33);
            this.BtnTransfer.TabIndex = 36;
            this.BtnTransfer.Text = "Transfer";
            this.BtnTransfer.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Gainsboro;
            this.label2.Location = new System.Drawing.Point(531, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 20);
            this.label2.TabIndex = 33;
            this.label2.Text = "Category:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Gainsboro;
            this.label1.Location = new System.Drawing.Point(273, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 20);
            this.label1.TabIndex = 32;
            this.label1.Text = "Location:";
            // 
            // ListCategory
            // 
            this.ListCategory.BackColor = System.Drawing.Color.Azure;
            this.ListCategory.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ListCategory.FormattingEnabled = true;
            this.ListCategory.Location = new System.Drawing.Point(535, 57);
            this.ListCategory.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ListCategory.Name = "ListCategory";
            this.ListCategory.Size = new System.Drawing.Size(241, 193);
            this.ListCategory.TabIndex = 31;
            // 
            // pageTask
            // 
            this.pageTask.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(25)))), ((int)(((byte)(72)))));
            this.pageTask.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pageTask.Controls.Add(this.btnSelectFiles);
            this.pageTask.Controls.Add(this.comboBox1);
            this.pageTask.Controls.Add(this.label5);
            this.pageTask.Controls.Add(this.btnSave);
            this.pageTask.Controls.Add(this.textBox3);
            this.pageTask.Controls.Add(this.label8);
            this.pageTask.Controls.Add(this.textBox2);
            this.pageTask.Controls.Add(this.dgvFiles);
            this.pageTask.Controls.Add(this.label6);
            this.pageTask.Controls.Add(this.label3);
            this.pageTask.ForeColor = System.Drawing.Color.Gainsboro;
            this.pageTask.Location = new System.Drawing.Point(4, 44);
            this.pageTask.Name = "pageTask";
            this.pageTask.Padding = new System.Windows.Forms.Padding(3);
            this.pageTask.Size = new System.Drawing.Size(1202, 630);
            this.pageTask.TabIndex = 0;
            this.pageTask.Text = "Create Task";
            // 
            // dgvFiles
            // 
            this.dgvFiles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvFiles.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colFilename,
            this.ColLocation,
            this.DestPath,
            this.remove});
            this.dgvFiles.Location = new System.Drawing.Point(46, 116);
            this.dgvFiles.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgvFiles.Name = "dgvFiles";
            this.dgvFiles.RowHeadersVisible = false;
            this.dgvFiles.RowHeadersWidth = 62;
            this.dgvFiles.RowTemplate.Height = 28;
            this.dgvFiles.Size = new System.Drawing.Size(1093, 434);
            this.dgvFiles.TabIndex = 36;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(42, 61);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(99, 21);
            this.label6.TabIndex = 2;
            this.label6.Text = "Task Name:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(141, 209);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(0, 21);
            this.label3.TabIndex = 0;
            // 
            // tabTask
            // 
            this.tabTask.Controls.Add(this.pageTask);
            this.tabTask.Controls.Add(this.tabMapping);
            this.tabTask.Controls.Add(this.pagePatch);
            this.tabTask.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabTask.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabTask.ItemSize = new System.Drawing.Size(85, 40);
            this.tabTask.Location = new System.Drawing.Point(0, 0);
            this.tabTask.Margin = new System.Windows.Forms.Padding(0);
            this.tabTask.Multiline = true;
            this.tabTask.Name = "tabTask";
            this.tabTask.Padding = new System.Drawing.Point(20, 10);
            this.tabTask.SelectedIndex = 0;
            this.tabTask.Size = new System.Drawing.Size(1210, 678);
            this.tabTask.TabIndex = 0;
            // 
            // dataGridViewImageColumn1
            // 
            this.dataGridViewImageColumn1.HeaderText = "Remove";
            this.dataGridViewImageColumn1.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.dataGridViewImageColumn1.MinimumWidth = 6;
            this.dataGridViewImageColumn1.Name = "dataGridViewImageColumn1";
            this.dataGridViewImageColumn1.Width = 125;
            // 
            // tabMapping
            // 
            this.tabMapping.Location = new System.Drawing.Point(4, 44);
            this.tabMapping.Name = "tabMapping";
            this.tabMapping.Padding = new System.Windows.Forms.Padding(3);
            this.tabMapping.Size = new System.Drawing.Size(1202, 630);
            this.tabMapping.TabIndex = 2;
            this.tabMapping.Text = "Task Mapping";
            this.tabMapping.UseVisualStyleBackColor = true;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(147, 58);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(319, 28);
            this.textBox2.TabIndex = 43;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(492, 61);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(105, 21);
            this.label8.TabIndex = 44;
            this.label8.Text = "App Version:";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(603, 61);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(94, 28);
            this.textBox3.TabIndex = 45;
            // 
            // colFilename
            // 
            this.colFilename.HeaderText = "File Name";
            this.colFilename.MinimumWidth = 8;
            this.colFilename.Name = "colFilename";
            this.colFilename.Width = 250;
            // 
            // ColLocation
            // 
            this.ColLocation.HeaderText = "Source Path";
            this.ColLocation.MinimumWidth = 8;
            this.ColLocation.Name = "ColLocation";
            this.ColLocation.Width = 400;
            // 
            // DestPath
            // 
            this.DestPath.HeaderText = "Destination Path";
            this.DestPath.MinimumWidth = 6;
            this.DestPath.Name = "DestPath";
            this.DestPath.Width = 400;
            // 
            // remove
            // 
            this.remove.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.remove.HeaderText = "";
            this.remove.Image = global::WinSCPFileTransfer.Properties.Resources.delete;
            this.remove.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.remove.MinimumWidth = 6;
            this.remove.Name = "remove";
            this.remove.Width = 24;
            // 
            // btnSave
            // 
            this.btnSave.ForeColor = System.Drawing.Color.DarkViolet;
            this.btnSave.IconChar = FontAwesome.Sharp.IconChar.Save;
            this.btnSave.IconColor = System.Drawing.Color.MediumPurple;
            this.btnSave.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnSave.IconSize = 32;
            this.btnSave.Location = new System.Drawing.Point(561, 559);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(108, 51);
            this.btnSave.TabIndex = 46;
            this.btnSave.Text = "Save";
            this.btnSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(716, 65);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(91, 21);
            this.label5.TabIndex = 47;
            this.label5.Text = "Target OS:";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "32 Bit",
            "64 Bit"});
            this.comboBox1.Location = new System.Drawing.Point(814, 60);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 29);
            this.comboBox1.TabIndex = 48;
            // 
            // btnSelectFiles
            // 
            this.btnSelectFiles.ForeColor = System.Drawing.Color.DarkViolet;
            this.btnSelectFiles.IconChar = FontAwesome.Sharp.IconChar.FileUpload;
            this.btnSelectFiles.IconColor = System.Drawing.Color.MediumPurple;
            this.btnSelectFiles.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnSelectFiles.IconSize = 32;
            this.btnSelectFiles.Location = new System.Drawing.Point(957, 56);
            this.btnSelectFiles.Name = "btnSelectFiles";
            this.btnSelectFiles.Size = new System.Drawing.Size(140, 37);
            this.btnSelectFiles.TabIndex = 49;
            this.btnSelectFiles.Text = "Select Files";
            this.btnSelectFiles.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSelectFiles.UseVisualStyleBackColor = true;
            this.btnSelectFiles.Click += new System.EventHandler(this.btnSelectFiles_Click);
            // 
            // FormPatchApply
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(25)))), ((int)(((byte)(72)))));
            this.ClientSize = new System.Drawing.Size(1210, 678);
            this.Controls.Add(this.tabTask);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "FormPatchApply";
            this.Text = "FormPatchApply";
            this.Load += new System.EventHandler(this.FormPatchApply_Load);
            this.pagePatch.ResumeLayout(false);
            this.pagePatch.PerformLayout();
            this.pageTask.ResumeLayout(false);
            this.pageTask.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFiles)).EndInit();
            this.tabTask.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.TabPage pagePatch;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Button BttnPOSList;
        private System.Windows.Forms.CheckBox checkPOS;
        private System.Windows.Forms.CheckedListBox ListPOS;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox checkCategory;
        private System.Windows.Forms.CheckBox checkLocation;
        private System.Windows.Forms.CheckedListBox ListLocation;
        private System.Windows.Forms.Button BtnTransfer;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckedListBox ListCategory;
        private System.Windows.Forms.TabPage pageTask;
        private System.Windows.Forms.DataGridView dgvFiles;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TabControl tabTask;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn1;
        private FontAwesome.Sharp.IconButton btnSelectFiles;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label5;
        private FontAwesome.Sharp.IconButton btnSave;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFilename;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColLocation;
        private System.Windows.Forms.DataGridViewTextBoxColumn DestPath;
        private System.Windows.Forms.DataGridViewImageColumn remove;
        private System.Windows.Forms.TabPage tabMapping;
    }
}