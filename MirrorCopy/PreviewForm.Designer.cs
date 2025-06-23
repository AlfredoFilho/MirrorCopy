namespace MirrorCopy
{
    partial class PreviewForm
    {
        private System.ComponentModel.IContainer components = null;

        private TextBox txtPreview;
        private Button btnConfirm;
        private Button btnCancel;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.txtPreview = new TextBox();
            this.btnConfirm = new Button();
            this.btnCancel = new Button();

            this.SuspendLayout();

            this.txtPreview.Location = new System.Drawing.Point(12, 12);
            this.txtPreview.Multiline = true;
            this.txtPreview.ScrollBars = ScrollBars.Both;
            this.txtPreview.ReadOnly = true;
            this.txtPreview.WordWrap = false;
            this.txtPreview.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            this.txtPreview.Size = new System.Drawing.Size(560, 350);
            this.txtPreview.Font = new System.Drawing.Font("Consolas", 9F);

            this.btnConfirm.Location = new System.Drawing.Point(395, 370);
            this.btnConfirm.Size = new System.Drawing.Size(85, 30);
            this.btnConfirm.Text = "Confirm";
            this.btnConfirm.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);

            this.btnCancel.Location = new System.Drawing.Point(485, 370);
            this.btnCancel.Size = new System.Drawing.Size(85, 30);
            this.btnCancel.Text = "Cancel";
            this.btnCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);

            this.ClientSize = new System.Drawing.Size(584, 411);
            this.Controls.Add(this.txtPreview);
            this.Controls.Add(this.btnConfirm);
            this.Controls.Add(this.btnCancel);
            this.MinimumSize = new System.Drawing.Size(400, 300);
            this.Name = "PreviewForm";
            this.Text = "Backup Preview";
            this.StartPosition = FormStartPosition.CenterParent;
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
