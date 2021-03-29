
namespace WinSCPFileTransfer
{
    partial class MainMenu
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
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.TileTargetServer = new MetroFramework.Controls.MetroTile();
            this.metroTile2 = new MetroFramework.Controls.MetroTile();
            this.metroTile3 = new MetroFramework.Controls.MetroTile();
            this.metroTile4 = new MetroFramework.Controls.MetroTile();
            this.metroTile5 = new MetroFramework.Controls.MetroTile();
            this.bttnAbout = new System.Windows.Forms.Button();
            this.statusStrip.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip
            // 
            this.statusStrip.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel});
            this.statusStrip.Location = new System.Drawing.Point(13, 363);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(622, 22);
            this.statusStrip.TabIndex = 2;
            this.statusStrip.Text = "StatusStrip";
            // 
            // toolStripStatusLabel
            // 
            this.toolStripStatusLabel.Name = "toolStripStatusLabel";
            this.toolStripStatusLabel.Size = new System.Drawing.Size(39, 17);
            this.toolStripStatusLabel.Text = "Status";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.BackColor = System.Drawing.Color.LightSteelBlue;
            this.flowLayoutPanel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.flowLayoutPanel1.Controls.Add(this.TileTargetServer);
            this.flowLayoutPanel1.Controls.Add(this.metroTile2);
            this.flowLayoutPanel1.Controls.Add(this.metroTile3);
            this.flowLayoutPanel1.Controls.Add(this.metroTile4);
            this.flowLayoutPanel1.Controls.Add(this.metroTile5);
            this.flowLayoutPanel1.Controls.Add(this.bttnAbout);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(13, 52);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(211, 311);
            this.flowLayoutPanel1.TabIndex = 4;
            // 
            // TileTargetServer
            // 
            this.TileTargetServer.ActiveControl = null;
            this.TileTargetServer.BackColor = System.Drawing.Color.SteelBlue;
            this.TileTargetServer.ForeColor = System.Drawing.Color.GhostWhite;
            this.TileTargetServer.Location = new System.Drawing.Point(2, 2);
            this.TileTargetServer.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.TileTargetServer.Name = "TileTargetServer";
            this.TileTargetServer.Size = new System.Drawing.Size(200, 44);
            this.TileTargetServer.TabIndex = 0;
            this.TileTargetServer.Text = "Target Server";
            this.TileTargetServer.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.TileTargetServer.TileTextFontSize = MetroFramework.MetroTileTextSize.Tall;
            this.TileTargetServer.TileTextFontWeight = MetroFramework.MetroTileTextWeight.Bold;
            this.TileTargetServer.UseCustomBackColor = true;
            this.TileTargetServer.UseCustomForeColor = true;
            this.TileTargetServer.UseSelectable = true;
            this.TileTargetServer.UseTileImage = true;
            // 
            // metroTile2
            // 
            this.metroTile2.ActiveControl = null;
            this.metroTile2.BackColor = System.Drawing.Color.SteelBlue;
            this.metroTile2.ForeColor = System.Drawing.Color.GhostWhite;
            this.metroTile2.Location = new System.Drawing.Point(2, 50);
            this.metroTile2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.metroTile2.Name = "metroTile2";
            this.metroTile2.Size = new System.Drawing.Size(200, 43);
            this.metroTile2.TabIndex = 1;
            this.metroTile2.Text = "Download Patch";
            this.metroTile2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.metroTile2.TileTextFontSize = MetroFramework.MetroTileTextSize.Tall;
            this.metroTile2.TileTextFontWeight = MetroFramework.MetroTileTextWeight.Bold;
            this.metroTile2.UseCustomBackColor = true;
            this.metroTile2.UseCustomForeColor = true;
            this.metroTile2.UseSelectable = true;
            this.metroTile2.UseTileImage = true;
            // 
            // metroTile3
            // 
            this.metroTile3.ActiveControl = null;
            this.metroTile3.BackColor = System.Drawing.Color.SteelBlue;
            this.metroTile3.ForeColor = System.Drawing.Color.GhostWhite;
            this.metroTile3.Location = new System.Drawing.Point(2, 97);
            this.metroTile3.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.metroTile3.Name = "metroTile3";
            this.metroTile3.Size = new System.Drawing.Size(200, 48);
            this.metroTile3.TabIndex = 2;
            this.metroTile3.Text = "Schedule Update";
            this.metroTile3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.metroTile3.TileTextFontSize = MetroFramework.MetroTileTextSize.Tall;
            this.metroTile3.TileTextFontWeight = MetroFramework.MetroTileTextWeight.Bold;
            this.metroTile3.UseCustomBackColor = true;
            this.metroTile3.UseCustomForeColor = true;
            this.metroTile3.UseSelectable = true;
            this.metroTile3.UseTileImage = true;
            // 
            // metroTile4
            // 
            this.metroTile4.ActiveControl = null;
            this.metroTile4.BackColor = System.Drawing.Color.SteelBlue;
            this.metroTile4.ForeColor = System.Drawing.Color.GhostWhite;
            this.metroTile4.Location = new System.Drawing.Point(2, 149);
            this.metroTile4.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.metroTile4.Name = "metroTile4";
            this.metroTile4.Size = new System.Drawing.Size(200, 49);
            this.metroTile4.TabIndex = 3;
            this.metroTile4.Text = "Apply Patch";
            this.metroTile4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.metroTile4.TileTextFontSize = MetroFramework.MetroTileTextSize.Tall;
            this.metroTile4.TileTextFontWeight = MetroFramework.MetroTileTextWeight.Bold;
            this.metroTile4.UseCustomBackColor = true;
            this.metroTile4.UseCustomForeColor = true;
            this.metroTile4.UseSelectable = true;
            this.metroTile4.UseTileImage = true;
            // 
            // metroTile5
            // 
            this.metroTile5.ActiveControl = null;
            this.metroTile5.BackColor = System.Drawing.Color.SteelBlue;
            this.metroTile5.ForeColor = System.Drawing.Color.GhostWhite;
            this.metroTile5.Location = new System.Drawing.Point(2, 202);
            this.metroTile5.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.metroTile5.Name = "metroTile5";
            this.metroTile5.Size = new System.Drawing.Size(200, 40);
            this.metroTile5.TabIndex = 4;
            this.metroTile5.Text = "Log && Report";
            this.metroTile5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.metroTile5.TileTextFontSize = MetroFramework.MetroTileTextSize.Tall;
            this.metroTile5.TileTextFontWeight = MetroFramework.MetroTileTextWeight.Bold;
            this.metroTile5.UseCustomBackColor = true;
            this.metroTile5.UseCustomForeColor = true;
            this.metroTile5.UseSelectable = true;
            this.metroTile5.UseTileImage = true;
            // 
            // bttnAbout
            // 
            this.bttnAbout.BackColor = System.Drawing.Color.SteelBlue;
            this.bttnAbout.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bttnAbout.ForeColor = System.Drawing.Color.White;
            this.bttnAbout.Location = new System.Drawing.Point(2, 246);
            this.bttnAbout.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.bttnAbout.Name = "bttnAbout";
            this.bttnAbout.Size = new System.Drawing.Size(200, 45);
            this.bttnAbout.TabIndex = 5;
            this.bttnAbout.Text = "About";
            this.bttnAbout.UseVisualStyleBackColor = false;
            // 
            // MainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(648, 398);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.statusStrip);
            this.HelpButton = true;
            this.IsMdiContainer = true;
            this.Name = "MainMenu";
            this.Padding = new System.Windows.Forms.Padding(13, 52, 13, 13);
            this.Text = "MainMenu";
            this.TransparencyKey = System.Drawing.Color.Empty;
            this.Load += new System.EventHandler(this.MainMenu_Load);
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private MetroFramework.Controls.MetroTile TileTargetServer;
        private MetroFramework.Controls.MetroTile metroTile2;
        private MetroFramework.Controls.MetroTile metroTile3;
        private MetroFramework.Controls.MetroTile metroTile4;
        private MetroFramework.Controls.MetroTile metroTile5;
        private System.Windows.Forms.Button bttnAbout;
    }
}



