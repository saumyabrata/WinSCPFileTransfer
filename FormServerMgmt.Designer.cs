
namespace WinSCPFileTransfer
{
    partial class FormServerMgmt
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panelServer = new System.Windows.Forms.Panel();
            this.comboFilter = new System.Windows.Forms.ComboBox();
            this.textBoxFilter = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textStoreName = new System.Windows.Forms.TextBox();
            this.textRegion = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.checkFingerprint = new System.Windows.Forms.CheckBox();
            this.checkSSH = new System.Windows.Forms.CheckBox();
            this.checkConnectivity = new System.Windows.Forms.CheckBox();
            this.textPassword = new System.Windows.Forms.TextBox();
            this.textUser = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.btnCheck = new FontAwesome.Sharp.IconButton();
            this.label6 = new System.Windows.Forms.Label();
            this.comboCategory = new System.Windows.Forms.ComboBox();
            this.comboStore = new System.Windows.Forms.ComboBox();
            this.textIP = new System.Windows.Forms.TextBox();
            this.textServerName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panelButton = new System.Windows.Forms.Panel();
            this.btnDelete = new FontAwesome.Sharp.IconButton();
            this.btnClear = new FontAwesome.Sharp.IconButton();
            this.btnSave = new FontAwesome.Sharp.IconButton();
            this.panelGrid = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dgvSrv = new System.Windows.Forms.DataGridView();
            this.panelServer.SuspendLayout();
            this.panelButton.SuspendLayout();
            this.panelGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSrv)).BeginInit();
            this.SuspendLayout();
            // 
            // panelServer
            // 
            this.panelServer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(25)))), ((int)(((byte)(72)))));
            this.panelServer.Controls.Add(this.comboFilter);
            this.panelServer.Controls.Add(this.textBoxFilter);
            this.panelServer.Controls.Add(this.label5);
            this.panelServer.Controls.Add(this.textStoreName);
            this.panelServer.Controls.Add(this.textRegion);
            this.panelServer.Controls.Add(this.label9);
            this.panelServer.Controls.Add(this.label8);
            this.panelServer.Controls.Add(this.checkFingerprint);
            this.panelServer.Controls.Add(this.checkSSH);
            this.panelServer.Controls.Add(this.checkConnectivity);
            this.panelServer.Controls.Add(this.textPassword);
            this.panelServer.Controls.Add(this.textUser);
            this.panelServer.Controls.Add(this.label7);
            this.panelServer.Controls.Add(this.btnCheck);
            this.panelServer.Controls.Add(this.label6);
            this.panelServer.Controls.Add(this.comboCategory);
            this.panelServer.Controls.Add(this.comboStore);
            this.panelServer.Controls.Add(this.textIP);
            this.panelServer.Controls.Add(this.textServerName);
            this.panelServer.Controls.Add(this.label4);
            this.panelServer.Controls.Add(this.label3);
            this.panelServer.Controls.Add(this.label2);
            this.panelServer.Controls.Add(this.label1);
            this.panelServer.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelServer.Location = new System.Drawing.Point(0, 0);
            this.panelServer.Margin = new System.Windows.Forms.Padding(4);
            this.panelServer.Name = "panelServer";
            this.panelServer.Size = new System.Drawing.Size(905, 307);
            this.panelServer.TabIndex = 83;
            this.panelServer.Paint += new System.Windows.Forms.PaintEventHandler(this.panelServer_Paint);
            // 
            // comboFilter
            // 
            this.comboFilter.BackColor = System.Drawing.Color.AliceBlue;
            this.comboFilter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboFilter.FormattingEnabled = true;
            this.comboFilter.IntegralHeight = false;
            this.comboFilter.ItemHeight = 18;
            this.comboFilter.Location = new System.Drawing.Point(252, 280);
            this.comboFilter.Margin = new System.Windows.Forms.Padding(2);
            this.comboFilter.Name = "comboFilter";
            this.comboFilter.Size = new System.Drawing.Size(200, 26);
            this.comboFilter.TabIndex = 104;
            // 
            // textBoxFilter
            // 
            this.textBoxFilter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxFilter.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxFilter.ForeColor = System.Drawing.Color.DarkRed;
            this.textBoxFilter.Location = new System.Drawing.Point(32, 279);
            this.textBoxFilter.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxFilter.Name = "textBoxFilter";
            this.textBoxFilter.PasswordChar = '*';
            this.textBoxFilter.Size = new System.Drawing.Size(220, 28);
            this.textBoxFilter.TabIndex = 103;
            this.textBoxFilter.TextChanged += new System.EventHandler(this.textBoxFilter_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Gainsboro;
            this.label5.Location = new System.Drawing.Point(470, 186);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(74, 18);
            this.label5.TabIndex = 102;
            this.label5.Text = "Password:";
            // 
            // textStoreName
            // 
            this.textStoreName.Location = new System.Drawing.Point(161, 89);
            this.textStoreName.Margin = new System.Windows.Forms.Padding(2);
            this.textStoreName.Name = "textStoreName";
            this.textStoreName.Size = new System.Drawing.Size(288, 26);
            this.textStoreName.TabIndex = 101;
            // 
            // textRegion
            // 
            this.textRegion.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textRegion.Location = new System.Drawing.Point(558, 40);
            this.textRegion.Margin = new System.Windows.Forms.Padding(2);
            this.textRegion.Name = "textRegion";
            this.textRegion.Size = new System.Drawing.Size(305, 28);
            this.textRegion.TabIndex = 100;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.Gainsboro;
            this.label9.Location = new System.Drawing.Point(35, 92);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(91, 18);
            this.label9.TabIndex = 99;
            this.label9.Text = "Store Name:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Gainsboro;
            this.label8.Location = new System.Drawing.Point(470, 45);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(56, 18);
            this.label8.TabIndex = 98;
            this.label8.Text = "Region:";
            // 
            // checkFingerprint
            // 
            this.checkFingerprint.AutoSize = true;
            this.checkFingerprint.ForeColor = System.Drawing.Color.Gainsboro;
            this.checkFingerprint.Location = new System.Drawing.Point(537, 231);
            this.checkFingerprint.Name = "checkFingerprint";
            this.checkFingerprint.Size = new System.Drawing.Size(194, 22);
            this.checkFingerprint.TabIndex = 97;
            this.checkFingerprint.Text = "Generate SHA Fingerprint";
            this.checkFingerprint.UseVisualStyleBackColor = true;
            // 
            // checkSSH
            // 
            this.checkSSH.AutoSize = true;
            this.checkSSH.ForeColor = System.Drawing.Color.Gainsboro;
            this.checkSSH.Location = new System.Drawing.Point(406, 231);
            this.checkSSH.Name = "checkSSH";
            this.checkSSH.Size = new System.Drawing.Size(102, 22);
            this.checkSSH.TabIndex = 96;
            this.checkSSH.Text = "SSH Status";
            this.checkSSH.UseVisualStyleBackColor = true;
            // 
            // checkConnectivity
            // 
            this.checkConnectivity.AutoSize = true;
            this.checkConnectivity.ForeColor = System.Drawing.Color.Gainsboro;
            this.checkConnectivity.Location = new System.Drawing.Point(271, 232);
            this.checkConnectivity.Name = "checkConnectivity";
            this.checkConnectivity.Size = new System.Drawing.Size(108, 22);
            this.checkConnectivity.TabIndex = 95;
            this.checkConnectivity.Text = "Connectivity";
            this.checkConnectivity.UseVisualStyleBackColor = true;
            // 
            // textPassword
            // 
            this.textPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textPassword.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textPassword.ForeColor = System.Drawing.Color.DarkRed;
            this.textPassword.Location = new System.Drawing.Point(561, 182);
            this.textPassword.Margin = new System.Windows.Forms.Padding(2);
            this.textPassword.Name = "textPassword";
            this.textPassword.PasswordChar = '*';
            this.textPassword.Size = new System.Drawing.Size(302, 28);
            this.textPassword.TabIndex = 94;
            this.textPassword.UseSystemPasswordChar = true;
            // 
            // textUser
            // 
            this.textUser.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textUser.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textUser.ForeColor = System.Drawing.Color.Black;
            this.textUser.Location = new System.Drawing.Point(161, 182);
            this.textUser.Margin = new System.Windows.Forms.Padding(2);
            this.textUser.Name = "textUser";
            this.textUser.Size = new System.Drawing.Size(288, 28);
            this.textUser.TabIndex = 93;
            this.textUser.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Gainsboro;
            this.label7.Location = new System.Drawing.Point(35, 184);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(87, 18);
            this.label7.TabIndex = 92;
            this.label7.Text = "User Name:";
            // 
            // btnCheck
            // 
            this.btnCheck.IconChar = FontAwesome.Sharp.IconChar.Link;
            this.btnCheck.IconColor = System.Drawing.Color.Maroon;
            this.btnCheck.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnCheck.IconSize = 20;
            this.btnCheck.Location = new System.Drawing.Point(161, 227);
            this.btnCheck.Margin = new System.Windows.Forms.Padding(4);
            this.btnCheck.Name = "btnCheck";
            this.btnCheck.Size = new System.Drawing.Size(91, 29);
            this.btnCheck.TabIndex = 91;
            this.btnCheck.Text = "Check";
            this.btnCheck.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCheck.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Gainsboro;
            this.label6.Location = new System.Drawing.Point(34, 232);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(88, 18);
            this.label6.TabIndex = 89;
            this.label6.Text = "Reachability:";
            // 
            // comboCategory
            // 
            this.comboCategory.FormattingEnabled = true;
            this.comboCategory.Location = new System.Drawing.Point(561, 92);
            this.comboCategory.Margin = new System.Windows.Forms.Padding(2);
            this.comboCategory.Name = "comboCategory";
            this.comboCategory.Size = new System.Drawing.Size(302, 26);
            this.comboCategory.TabIndex = 86;
            this.comboCategory.SelectionChangeCommitted += new System.EventHandler(this.comboCategory_SelectionChangeCommitted);
            // 
            // comboStore
            // 
            this.comboStore.FormattingEnabled = true;
            this.comboStore.Location = new System.Drawing.Point(161, 42);
            this.comboStore.Margin = new System.Windows.Forms.Padding(2);
            this.comboStore.Name = "comboStore";
            this.comboStore.Size = new System.Drawing.Size(288, 26);
            this.comboStore.TabIndex = 85;
            this.comboStore.SelectionChangeCommitted += new System.EventHandler(this.comboStore_SelectionChangeCommitted);
            // 
            // textIP
            // 
            this.textIP.Location = new System.Drawing.Point(561, 136);
            this.textIP.Margin = new System.Windows.Forms.Padding(2);
            this.textIP.Name = "textIP";
            this.textIP.Size = new System.Drawing.Size(302, 26);
            this.textIP.TabIndex = 84;
            // 
            // textServerName
            // 
            this.textServerName.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textServerName.Location = new System.Drawing.Point(161, 134);
            this.textServerName.Margin = new System.Windows.Forms.Padding(2);
            this.textServerName.Name = "textServerName";
            this.textServerName.Size = new System.Drawing.Size(288, 28);
            this.textServerName.TabIndex = 83;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Gainsboro;
            this.label4.Location = new System.Drawing.Point(470, 92);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(72, 18);
            this.label4.TabIndex = 82;
            this.label4.Text = "Category:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Gainsboro;
            this.label3.Location = new System.Drawing.Point(35, 45);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(85, 18);
            this.label3.TabIndex = 81;
            this.label3.Text = "Store Code:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Gainsboro;
            this.label2.Location = new System.Drawing.Point(470, 140);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 18);
            this.label2.TabIndex = 80;
            this.label2.Text = "IP Address:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Gainsboro;
            this.label1.Location = new System.Drawing.Point(35, 134);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(106, 18);
            this.label1.TabIndex = 79;
            this.label1.Text = "System Name:";
            // 
            // panelButton
            // 
            this.panelButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(25)))), ((int)(((byte)(72)))));
            this.panelButton.Controls.Add(this.btnDelete);
            this.panelButton.Controls.Add(this.btnClear);
            this.panelButton.Controls.Add(this.btnSave);
            this.panelButton.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelButton.Location = new System.Drawing.Point(0, 566);
            this.panelButton.Margin = new System.Windows.Forms.Padding(4);
            this.panelButton.Name = "panelButton";
            this.panelButton.Size = new System.Drawing.Size(905, 54);
            this.panelButton.TabIndex = 84;
            // 
            // btnDelete
            // 
            this.btnDelete.FlatAppearance.BorderSize = 0;
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnDelete.IconChar = FontAwesome.Sharp.IconChar.TrashAlt;
            this.btnDelete.IconColor = System.Drawing.Color.MediumPurple;
            this.btnDelete.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnDelete.IconSize = 32;
            this.btnDelete.Location = new System.Drawing.Point(506, -3);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(2);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(116, 46);
            this.btnDelete.TabIndex = 85;
            this.btnDelete.Text = "Delete";
            this.btnDelete.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnClear
            // 
            this.btnClear.FlatAppearance.BorderSize = 0;
            this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClear.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClear.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnClear.IconChar = FontAwesome.Sharp.IconChar.Edit;
            this.btnClear.IconColor = System.Drawing.Color.MediumPurple;
            this.btnClear.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnClear.IconSize = 32;
            this.btnClear.Location = new System.Drawing.Point(381, -3);
            this.btnClear.Margin = new System.Windows.Forms.Padding(2);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(120, 46);
            this.btnClear.TabIndex = 84;
            this.btnClear.Text = "Clear";
            this.btnClear.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnSave
            // 
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnSave.IconChar = FontAwesome.Sharp.IconChar.Save;
            this.btnSave.IconColor = System.Drawing.Color.MediumPurple;
            this.btnSave.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnSave.IconSize = 32;
            this.btnSave.Location = new System.Drawing.Point(268, -3);
            this.btnSave.Margin = new System.Windows.Forms.Padding(2);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(108, 46);
            this.btnSave.TabIndex = 83;
            this.btnSave.Text = "Save";
            this.btnSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // panelGrid
            // 
            this.panelGrid.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(25)))), ((int)(((byte)(72)))));
            this.panelGrid.Controls.Add(this.panel2);
            this.panelGrid.Controls.Add(this.panel1);
            this.panelGrid.Controls.Add(this.dgvSrv);
            this.panelGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelGrid.Location = new System.Drawing.Point(0, 307);
            this.panelGrid.Margin = new System.Windows.Forms.Padding(4);
            this.panelGrid.Name = "panelGrid";
            this.panelGrid.Size = new System.Drawing.Size(905, 313);
            this.panelGrid.TabIndex = 85;
            // 
            // panel2
            // 
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(873, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(32, 313);
            this.panel2.TabIndex = 82;
            // 
            // panel1
            // 
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(33, 313);
            this.panel1.TabIndex = 81;
            // 
            // dgvSrv
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.LightSteelBlue;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.NullValue = null;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Gainsboro;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvSrv.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvSrv.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvSrv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSrv.Location = new System.Drawing.Point(40, 8);
            this.dgvSrv.Margin = new System.Windows.Forms.Padding(4);
            this.dgvSrv.Name = "dgvSrv";
            this.dgvSrv.RowHeadersVisible = false;
            this.dgvSrv.RowHeadersWidth = 51;
            this.dgvSrv.Size = new System.Drawing.Size(826, 242);
            this.dgvSrv.TabIndex = 80;
            this.dgvSrv.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSrv_CellDoubleClick);
            // 
            // FormServerMgmt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(25)))), ((int)(((byte)(72)))));
            this.ClientSize = new System.Drawing.Size(905, 620);
            this.Controls.Add(this.panelButton);
            this.Controls.Add(this.panelGrid);
            this.Controls.Add(this.panelServer);
            this.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "FormServerMgmt";
            this.Text = "FormServerMgmt";
            this.Load += new System.EventHandler(this.FormServerMgmt_Load);
            this.panelServer.ResumeLayout(false);
            this.panelServer.PerformLayout();
            this.panelButton.ResumeLayout(false);
            this.panelGrid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSrv)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelServer;
        private FontAwesome.Sharp.IconButton btnCheck;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox comboCategory;
        private System.Windows.Forms.ComboBox comboStore;
        private System.Windows.Forms.TextBox textIP;
        private System.Windows.Forms.TextBox textServerName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panelButton;
        private FontAwesome.Sharp.IconButton btnDelete;
        private FontAwesome.Sharp.IconButton btnClear;
        private FontAwesome.Sharp.IconButton btnSave;
        private System.Windows.Forms.Panel panelGrid;
        private System.Windows.Forms.DataGridView dgvSrv;
        private System.Windows.Forms.TextBox textUser;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.CheckBox checkFingerprint;
        private System.Windows.Forms.CheckBox checkSSH;
        private System.Windows.Forms.CheckBox checkConnectivity;
        private System.Windows.Forms.TextBox textPassword;
        private System.Windows.Forms.TextBox textBoxFilter;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textStoreName;
        private System.Windows.Forms.TextBox textRegion;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox comboFilter;
    }
}