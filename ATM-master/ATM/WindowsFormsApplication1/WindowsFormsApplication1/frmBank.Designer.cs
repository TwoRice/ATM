namespace WindowsFormsApplication1
{
    partial class frmBank
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBank));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.accountToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.createToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.findToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.raceConditionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lagToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fixToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnBank = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.accountToolStripMenuItem,
            this.raceConditionToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(784, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // accountToolStripMenuItem
            // 
            this.accountToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.createToolStripMenuItem,
            this.deleteToolStripMenuItem,
            this.findToolStripMenuItem});
            this.accountToolStripMenuItem.Name = "accountToolStripMenuItem";
            this.accountToolStripMenuItem.Size = new System.Drawing.Size(64, 20);
            this.accountToolStripMenuItem.Text = "Account";
            // 
            // createToolStripMenuItem
            // 
            this.createToolStripMenuItem.Name = "createToolStripMenuItem";
            this.createToolStripMenuItem.Size = new System.Drawing.Size(108, 22);
            this.createToolStripMenuItem.Text = "Create";
            this.createToolStripMenuItem.Click += new System.EventHandler(this.createToolStripMenuItem_Click);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(108, 22);
            this.deleteToolStripMenuItem.Text = "Delete";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // findToolStripMenuItem
            // 
            this.findToolStripMenuItem.Name = "findToolStripMenuItem";
            this.findToolStripMenuItem.Size = new System.Drawing.Size(108, 22);
            this.findToolStripMenuItem.Text = "Find..";
            // 
            // raceConditionToolStripMenuItem
            // 
            this.raceConditionToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lagToolStripMenuItem,
            this.fixToolStripMenuItem});
            this.raceConditionToolStripMenuItem.Name = "raceConditionToolStripMenuItem";
            this.raceConditionToolStripMenuItem.Size = new System.Drawing.Size(100, 20);
            this.raceConditionToolStripMenuItem.Text = "Race Condition";
            // 
            // lagToolStripMenuItem
            // 
            this.lagToolStripMenuItem.Name = "lagToolStripMenuItem";
            this.lagToolStripMenuItem.Size = new System.Drawing.Size(131, 22);
            this.lagToolStripMenuItem.Text = "Enable Lag";
            this.lagToolStripMenuItem.Click += new System.EventHandler(this.lagToolStripMenuItem_Click);
            // 
            // fixToolStripMenuItem
            // 
            this.fixToolStripMenuItem.Name = "fixToolStripMenuItem";
            this.fixToolStripMenuItem.Size = new System.Drawing.Size(131, 22);
            this.fixToolStripMenuItem.Text = "Enable Fix";
            this.fixToolStripMenuItem.Click += new System.EventHandler(this.fixToolStripMenuItem_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Trajan Pro", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(154, 102);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(491, 34);
            this.label1.TabIndex = 2;
            this.label1.Text = "Syro Central Banking Systems";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Trajan Pro", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(322, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(155, 34);
            this.label2.TabIndex = 3;
            this.label2.Text = "Welcome";
            // 
            // btnBank
            // 
            this.btnBank.BackgroundImage = global::WindowsFormsApplication1.Properties.Resources.bank;
            this.btnBank.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnBank.Location = new System.Drawing.Point(350, 175);
            this.btnBank.Name = "btnBank";
            this.btnBank.Size = new System.Drawing.Size(100, 100);
            this.btnBank.TabIndex = 0;
            this.btnBank.UseVisualStyleBackColor = true;
            this.btnBank.Click += new System.EventHandler(this.btnBank_Click);
            // 
            // frmBank
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 461);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnBank);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximumSize = new System.Drawing.Size(800, 500);
            this.MinimumSize = new System.Drawing.Size(800, 500);
            this.Name = "frmBank";
            this.Text = "Bank Computer";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmBank_FormClosing);
            this.Load += new System.EventHandler(this.frmBank_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnBank;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem accountToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem createToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem findToolStripMenuItem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ToolStripMenuItem raceConditionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem lagToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fixToolStripMenuItem;
    }
}