namespace MirrorCopy
{
    partial class Main
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Label labelSource;
        private System.Windows.Forms.TextBox txtSource;
        private System.Windows.Forms.Button btnBrowseSource;

        private System.Windows.Forms.Label labelDestination;
        private System.Windows.Forms.TextBox txtDestination;
        private System.Windows.Forms.Button btnBrowseDestination;

        private System.Windows.Forms.Label lblWarning;

        private System.Windows.Forms.Label labelLog;
        private System.Windows.Forms.TextBox txtLog;
        private System.Windows.Forms.Button btnBrowseLog;

        private System.Windows.Forms.Button btnExecute;
        private System.Windows.Forms.TextBox txtOutput;

        private System.Windows.Forms.NotifyIcon notifyIcon;
        private System.Windows.Forms.Button btnToggleTheme;

        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            labelSource = new Label();
            txtSource = new TextBox();
            btnBrowseSource = new Button();
            labelDestination = new Label();
            txtDestination = new TextBox();
            btnBrowseDestination = new Button();
            lblWarning = new Label();
            labelLog = new Label();
            txtLog = new TextBox();
            btnBrowseLog = new Button();
            btnExecute = new Button();
            txtOutput = new TextBox();
            btnToggleTheme = new Button();
            notifyIcon = new NotifyIcon(components);
            components = new System.ComponentModel.Container();
            contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            SuspendLayout();

            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.closeToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(181, 70);

            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.openToolStripMenuItem.Text = "View";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);

            this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            this.closeToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.closeToolStripMenuItem.Text = "Exit";
            this.closeToolStripMenuItem.Click += new System.EventHandler(this.closeToolStripMenuItem_Click);

            this.notifyIcon.ContextMenuStrip = this.contextMenuStrip1;
            // 
            // labelSource
            // 
            labelSource.AutoSize = true;
            labelSource.Location = new Point(10, 15);
            labelSource.Name = "labelSource";
            labelSource.Size = new Size(82, 15);
            labelSource.TabIndex = 0;
            labelSource.Text = "Source Folder:";
            // 
            // txtSource
            // 
            txtSource.Location = new Point(110, 12);
            txtSource.Name = "txtSource";
            txtSource.Size = new Size(450, 23);
            txtSource.TabIndex = 1;
            // 
            // btnBrowseSource
            // 
            btnBrowseSource.Location = new Point(570, 11);
            btnBrowseSource.Name = "btnBrowseSource";
            btnBrowseSource.Size = new Size(90, 25);
            btnBrowseSource.TabIndex = 2;
            btnBrowseSource.Text = "Browse...";
            btnBrowseSource.UseVisualStyleBackColor = true;
            btnBrowseSource.Click += btnBrowseOrig_Click;
            // 
            // labelDestination
            // 
            labelDestination.AutoSize = true;
            labelDestination.Location = new Point(10, 50);
            labelDestination.Name = "labelDestination";
            labelDestination.Size = new Size(106, 15);
            labelDestination.TabIndex = 3;
            labelDestination.Text = "Destination Folder:";
            // 
            // txtDestination
            // 
            txtDestination.Location = new Point(110, 47);
            txtDestination.Name = "txtDestination";
            txtDestination.Size = new Size(450, 23);
            txtDestination.TabIndex = 4;
            // 
            // btnBrowseDestination
            // 
            btnBrowseDestination.Location = new Point(570, 46);
            btnBrowseDestination.Name = "btnBrowseDestination";
            btnBrowseDestination.Size = new Size(90, 25);
            btnBrowseDestination.TabIndex = 5;
            btnBrowseDestination.Text = "Browse...";
            btnBrowseDestination.UseVisualStyleBackColor = true;
            btnBrowseDestination.Click += btnBrowseDest_Click;
            // 
            // lblWarning
            // 
            lblWarning.AutoSize = true;
            lblWarning.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblWarning.ForeColor = Color.Red;
            lblWarning.Location = new Point(10, 155);
            lblWarning.Name = "lblWarning";
            lblWarning.Size = new Size(456, 15);
            lblWarning.TabIndex = 1;
            lblWarning.Text = "⚠ Warning: Files in the destination that don't exist in the source will be DELETED.";
            // 
            // labelLog
            // 
            labelLog.AutoSize = true;
            labelLog.Location = new Point(10, 85);
            labelLog.Name = "labelLog";
            labelLog.Size = new Size(66, 15);
            labelLog.TabIndex = 6;
            labelLog.Text = "Log Folder:";
            // 
            // txtLog
            // 
            txtLog.Location = new Point(110, 82);
            txtLog.Name = "txtLog";
            txtLog.Size = new Size(450, 23);
            txtLog.TabIndex = 7;
            // 
            // btnBrowseLog
            // 
            btnBrowseLog.Location = new Point(570, 81);
            btnBrowseLog.Name = "btnBrowseLog";
            btnBrowseLog.Size = new Size(90, 25);
            btnBrowseLog.TabIndex = 8;
            btnBrowseLog.Text = "Browse...";
            btnBrowseLog.UseVisualStyleBackColor = true;
            btnBrowseLog.Click += btnBrowseLog_Click;
            // 
            // btnExecute
            // 
            btnExecute.Location = new Point(10, 120);
            btnExecute.Name = "btnExecute";
            btnExecute.Size = new Size(650, 30);
            btnExecute.TabIndex = 9;
            btnExecute.Text = "Run Backup";
            btnExecute.UseVisualStyleBackColor = true;
            btnExecute.Click += btnExecute_Click;
            // 
            // txtOutput
            // 
            txtOutput.Location = new Point(10, 173);
            txtOutput.Multiline = true;
            txtOutput.Name = "txtOutput";
            txtOutput.ReadOnly = true;
            txtOutput.ScrollBars = ScrollBars.Vertical;
            txtOutput.Size = new Size(652, 215);
            txtOutput.TabIndex = 10;
            // 
            // btnToggleTheme
            // 
            btnToggleTheme.Location = new Point(527, 357);
            btnToggleTheme.Name = "btnToggleTheme";
            btnToggleTheme.Size = new Size(110, 25);
            btnToggleTheme.TabIndex = 0;
            btnToggleTheme.Text = "Dark Mode";
            btnToggleTheme.Click += btnToggleTheme_Click;
            // 
            // notifyIcon
            // 
            notifyIcon.BalloonTipTitle = "MirrorCopy";
            notifyIcon.Icon = (Icon)resources.GetObject("notifyIcon.Icon");
            notifyIcon.Visible = true;
            // 
            // Main
            // 
            ClientSize = new Size(674, 400);
            Controls.Add(btnToggleTheme);
            Controls.Add(lblWarning);
            Controls.Add(txtOutput);
            Controls.Add(btnExecute);
            Controls.Add(btnBrowseLog);
            Controls.Add(txtLog);
            Controls.Add(labelLog);
            Controls.Add(btnBrowseDestination);
            Controls.Add(txtDestination);
            Controls.Add(labelDestination);
            Controls.Add(btnBrowseSource);
            Controls.Add(txtSource);
            Controls.Add(labelSource);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Main";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "MirrorCopy - A Folder Mirroring Tool Using Windows RoboCopy";
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
