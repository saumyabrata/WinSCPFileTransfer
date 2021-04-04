
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
            this.ListCategory = new System.Windows.Forms.CheckedListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnSelectMultiple = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.dgvFiles = new System.Windows.Forms.DataGridView();
            this.Check = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colFilename = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColLocation = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DestPath = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BtnTransfer = new System.Windows.Forms.Button();
            this.ListLocation = new System.Windows.Forms.CheckedListBox();
            this.checkLocation = new System.Windows.Forms.CheckBox();
            this.checkCategory = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.ListPOS = new System.Windows.Forms.CheckedListBox();
            this.checkPOS = new System.Windows.Forms.CheckBox();
            this.BttnPOSList = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFiles)).BeginInit();
            this.SuspendLayout();
            // 
            // ListCategory
            // 
            this.ListCategory.BackColor = System.Drawing.Color.Azure;
            this.ListCategory.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ListCategory.FormattingEnabled = true;
            this.ListCategory.Location = new System.Drawing.Point(277, 65);
            this.ListCategory.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ListCategory.Name = "ListCategory";
            this.ListCategory.Size = new System.Drawing.Size(241, 193);
            this.ListCategory.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Gainsboro;
            this.label1.Location = new System.Drawing.Point(15, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "Location:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Gainsboro;
            this.label2.Location = new System.Drawing.Point(273, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "Category:";
            // 
            // btnSelectMultiple
            // 
            this.btnSelectMultiple.Location = new System.Drawing.Point(562, 675);
            this.btnSelectMultiple.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSelectMultiple.Name = "btnSelectMultiple";
            this.btnSelectMultiple.Size = new System.Drawing.Size(116, 33);
            this.btnSelectMultiple.TabIndex = 6;
            this.btnSelectMultiple.Text = "Select Files";
            this.btnSelectMultiple.UseVisualStyleBackColor = true;
            this.btnSelectMultiple.Click += new System.EventHandler(this.btnSelectMultiple_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.Multiselect = true;
            // 
            // dgvFiles
            // 
            this.dgvFiles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvFiles.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Check,
            this.colFilename,
            this.ColLocation,
            this.DestPath});
            this.dgvFiles.Location = new System.Drawing.Point(19, 317);
            this.dgvFiles.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgvFiles.Name = "dgvFiles";
            this.dgvFiles.RowHeadersVisible = false;
            this.dgvFiles.RowHeadersWidth = 62;
            this.dgvFiles.RowTemplate.Height = 28;
            this.dgvFiles.Size = new System.Drawing.Size(790, 343);
            this.dgvFiles.TabIndex = 7;
            // 
            // Check
            // 
            this.Check.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.Check.HeaderText = "Check";
            this.Check.MinimumWidth = 8;
            this.Check.Name = "Check";
            this.Check.Width = 53;
            // 
            // colFilename
            // 
            this.colFilename.HeaderText = "File Name";
            this.colFilename.MinimumWidth = 8;
            this.colFilename.Name = "colFilename";
            this.colFilename.Width = 150;
            // 
            // ColLocation
            // 
            this.ColLocation.HeaderText = "Source Path";
            this.ColLocation.MinimumWidth = 8;
            this.ColLocation.Name = "ColLocation";
            this.ColLocation.Width = 300;
            // 
            // DestPath
            // 
            this.DestPath.HeaderText = "Destination Path";
            this.DestPath.MinimumWidth = 6;
            this.DestPath.Name = "DestPath";
            this.DestPath.Width = 300;
            // 
            // BtnTransfer
            // 
            this.BtnTransfer.Location = new System.Drawing.Point(684, 675);
            this.BtnTransfer.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.BtnTransfer.Name = "BtnTransfer";
            this.BtnTransfer.Size = new System.Drawing.Size(116, 33);
            this.BtnTransfer.TabIndex = 8;
            this.BtnTransfer.Text = "Transfer";
            this.BtnTransfer.UseVisualStyleBackColor = true;
            this.BtnTransfer.Click += new System.EventHandler(this.BtnTransfer_Click);
            // 
            // ListLocation
            // 
            this.ListLocation.BackColor = System.Drawing.Color.Gainsboro;
            this.ListLocation.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ListLocation.FormattingEnabled = true;
            this.ListLocation.Location = new System.Drawing.Point(19, 65);
            this.ListLocation.Margin = new System.Windows.Forms.Padding(4);
            this.ListLocation.Name = "ListLocation";
            this.ListLocation.Size = new System.Drawing.Size(251, 193);
            this.ListLocation.TabIndex = 9;
            // 
            // checkLocation
            // 
            this.checkLocation.AutoSize = true;
            this.checkLocation.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkLocation.ForeColor = System.Drawing.Color.Gainsboro;
            this.checkLocation.Location = new System.Drawing.Point(109, 25);
            this.checkLocation.Margin = new System.Windows.Forms.Padding(4);
            this.checkLocation.Name = "checkLocation";
            this.checkLocation.Size = new System.Drawing.Size(102, 24);
            this.checkLocation.TabIndex = 10;
            this.checkLocation.Text = "Select All";
            this.checkLocation.UseVisualStyleBackColor = true;
            this.checkLocation.CheckedChanged += new System.EventHandler(this.checkLocation_CheckedChanged);
            // 
            // checkCategory
            // 
            this.checkCategory.AutoSize = true;
            this.checkCategory.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkCategory.ForeColor = System.Drawing.Color.Gainsboro;
            this.checkCategory.Location = new System.Drawing.Point(370, 25);
            this.checkCategory.Margin = new System.Windows.Forms.Padding(4);
            this.checkCategory.Name = "checkCategory";
            this.checkCategory.Size = new System.Drawing.Size(102, 24);
            this.checkCategory.TabIndex = 11;
            this.checkCategory.Text = "Select All";
            this.checkCategory.UseVisualStyleBackColor = true;
            this.checkCategory.CheckedChanged += new System.EventHandler(this.checkCategory_CheckedChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Gainsboro;
            this.label4.Location = new System.Drawing.Point(525, 25);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(97, 20);
            this.label4.TabIndex = 12;
            this.label4.Text = "Target POS";
            // 
            // ListPOS
            // 
            this.ListPOS.BackColor = System.Drawing.SystemColors.Info;
            this.ListPOS.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ListPOS.FormattingEnabled = true;
            this.ListPOS.Location = new System.Drawing.Point(525, 65);
            this.ListPOS.Margin = new System.Windows.Forms.Padding(4);
            this.ListPOS.Name = "ListPOS";
            this.ListPOS.Size = new System.Drawing.Size(284, 193);
            this.ListPOS.TabIndex = 13;
            // 
            // checkPOS
            // 
            this.checkPOS.AutoSize = true;
            this.checkPOS.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkPOS.ForeColor = System.Drawing.Color.Gainsboro;
            this.checkPOS.Location = new System.Drawing.Point(707, 25);
            this.checkPOS.Margin = new System.Windows.Forms.Padding(4);
            this.checkPOS.Name = "checkPOS";
            this.checkPOS.Size = new System.Drawing.Size(102, 24);
            this.checkPOS.TabIndex = 14;
            this.checkPOS.Text = "Select All";
            this.checkPOS.UseVisualStyleBackColor = true;
            this.checkPOS.CheckedChanged += new System.EventHandler(this.checkPOS_CheckedChanged);
            // 
            // BttnPOSList
            // 
            this.BttnPOSList.Location = new System.Drawing.Point(580, 264);
            this.BttnPOSList.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.BttnPOSList.Name = "BttnPOSList";
            this.BttnPOSList.Size = new System.Drawing.Size(169, 33);
            this.BttnPOSList.TabIndex = 15;
            this.BttnPOSList.Text = "Populate POS List";
            this.BttnPOSList.UseVisualStyleBackColor = true;
            this.BttnPOSList.Click += new System.EventHandler(this.BttnPOSList_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(19, 680);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(276, 23);
            this.progressBar1.TabIndex = 16;
            // 
            // FormPatchApply
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(25)))), ((int)(((byte)(72)))));
            this.ClientSize = new System.Drawing.Size(827, 733);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.BttnPOSList);
            this.Controls.Add(this.checkPOS);
            this.Controls.Add(this.ListPOS);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.checkCategory);
            this.Controls.Add(this.checkLocation);
            this.Controls.Add(this.ListLocation);
            this.Controls.Add(this.BtnTransfer);
            this.Controls.Add(this.dgvFiles);
            this.Controls.Add(this.btnSelectMultiple);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ListCategory);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "FormPatchApply";
            this.Text = "FormPatchApply";
            this.Load += new System.EventHandler(this.FormPatchApply_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvFiles)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.CheckedListBox ListCategory;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnSelectMultiple;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.DataGridView dgvFiles;
        private System.Windows.Forms.Button BtnTransfer;
        private System.Windows.Forms.CheckedListBox ListLocation;
        private System.Windows.Forms.CheckBox checkLocation;
        private System.Windows.Forms.CheckBox checkCategory;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckedListBox ListPOS;
        private System.Windows.Forms.CheckBox checkPOS;
        private System.Windows.Forms.Button BttnPOSList;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Check;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFilename;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColLocation;
        private System.Windows.Forms.DataGridViewTextBoxColumn DestPath;
        private System.Windows.Forms.ProgressBar progressBar1;
    }
}