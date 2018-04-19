using System;
using System.Windows.Forms;
using InstagramDownloaderV2.Classes.Validation;

namespace InstagramDownloaderV2.Forms
{
    public partial class EditInputRow : Form
    {
        private readonly ListView _listView;

        public EditInputRow(ListView item)
        {
            InitializeComponent();

            _listView = item;
            cbType.Text = item.SelectedItems[0].SubItems[0].Text;
            txtInput.Text = item.SelectedItems[0].SubItems[1].Text;
            txtDownloadLimit.Text = item.SelectedItems[0].SubItems[2].Text;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(@"Are you sure you want to exit the form?", "", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Close();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (_listView.SelectedItems.Count != 1) return;

            if (String.IsNullOrEmpty(cbType.Text) || String.IsNullOrEmpty(txtInput.Text) ||
                String.IsNullOrEmpty(txtDownloadLimit.Text) || !InputValidation.IsInt(txtDownloadLimit.Text)) return;

            _listView.SelectedItems[0].SubItems[0].Text = cbType.Text;
            _listView.SelectedItems[0].SubItems[1].Text = txtInput.Text;
            _listView.SelectedItems[0].SubItems[2].Text = txtDownloadLimit.Text;

            Close();
        }

    }
}
