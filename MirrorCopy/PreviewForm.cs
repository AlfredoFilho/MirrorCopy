using System;
using System.Windows.Forms;

namespace MirrorCopy
{
    public partial class PreviewForm : Form
    {
        public bool Confirmed { get; private set; } = false;

        public PreviewForm(string previewText)
        {
            InitializeComponent();

            txtPreview.Text = previewText;

            txtPreview.SelectionStart = txtPreview.Text.Length;
            txtPreview.SelectionLength = 0;
            txtPreview.HideSelection = false;
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            Confirmed = true;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Confirmed = false;
            this.Close();
        }
    }
}
