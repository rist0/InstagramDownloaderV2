using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using InstagramDownloaderV2.Classes.Downloader;
using InstagramDownloaderV2.Classes.Objects.OtherObjects;
using InstagramDownloaderV2.Classes.Requests;
using InstagramDownloaderV2.Classes.Settings;
using InstagramDownloaderV2.Classes.Validation;
using InstagramDownloaderV2.Classes.WorkClasses;
using InstagramDownloaderV2.Enums;

namespace InstagramDownloaderV2.Forms
{
    public partial class frmMain : Form
    {
        private CancellationTokenSource _cancellationTokenSource;
        private CancellationToken _cancellationToken;
        private ProxyObject _proxy;
        private CookieContainer _cookies;

        public frmMain()
        {
            InitializeComponent();
            _cookies = new CookieContainer();
        }

        #region Logs Tab Menu
        private void btnClearLogs_Click(object sender, EventArgs e)
        {
            txtLogs.Clear();
        }

        private void btnExportLogs_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog sfd = new SaveFileDialog
                {
                    Filter = @"Text files (.txt)|*.txt",
                    Title = @"Logs Export File",
                    RestoreDirectory = true
                })
            {
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    File.WriteAllLines(sfd.FileName, txtLogs.Lines);
                }
            }
        }
        #endregion

        #region ContextMenuStrip Events For ListView Input
        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            var selectedItems = lvInput.SelectedItems;

            for (int i = selectedItems.Count - 1; i >= 0; i--)
            {
                lvInput.Items.Remove(selectedItems[i]);
            }
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            lvInput.Items.Clear();
        }

        private void editSelectedRowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (lvInput.SelectedItems.Count != 1)
            {
                MessageBox.Show(@"Can't edit more/less than one row at the same time.");
                return;
            }
            using (EditInputRow editInput = new EditInputRow(lvInput))
            {
                editInput.ShowDialog();
            }
        }

        private void exportSelectedRowsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var output = InputValidation.ValidExportFile();

            if (output.Item1 == false) return;

            var outputFile = output.Item2;

            foreach (ListViewItem row in lvInput.SelectedItems)
            {
                var fileContent =
                    row.SubItems[0].Text + "|" +
                    row.SubItems[1].Text + "|" +
                    row.SubItems[2].Text + Environment.NewLine;

                File.AppendAllText(outputFile, fileContent);
            }
        }

        private void exportAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var output = InputValidation.ValidExportFile();

            if (output.Item1 == false) return;

            var outputFile = output.Item2;

            foreach (ListViewItem row in lvInput.Items)
            {
                var fileContent =
                    row.SubItems[0].Text + "|" +
                    row.SubItems[1].Text + "|" +
                    row.SubItems[2].Text + Environment.NewLine;

                File.AppendAllText(outputFile, fileContent);
            }
        }
        #endregion

        #region MenuStrip Filters
        // Reset all filter settings
        private void resetAllFilterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!InputValidation.ConfirmUserAction(resetAllFilterToolStripMenuItem)) return;

            foreach (Control c in gbMediaFilters.Controls)
            {
                if (c is CheckBox cb)
                    cb.Checked = false;
                if (c is TextBox tb)
                    tb.Clear();
                if (c is ComboBox comboBox)
                    comboBox.Text = "";
            }
        }
        #endregion

        #region User Input
        /// <summary>
        /// Adds a new input to the list view control.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddInput_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtInput.Text)) return;
            if (rbUsername.Checked && !InputValidation.IsValidInstagramUsername(txtInput.Text)) return;

            if (rbUrl.Checked) lvInput.Items.Add(new ListViewItem(new[] { "Url", txtInput.Text, "1"}));
            if (rbUsername.Checked) lvInput.Items.Add(new ListViewItem(new[] { "Username", txtInput.Text, numTotalDownloads.Text }));
            if (rbHashtag.Checked) lvInput.Items.Add(new ListViewItem(new[] { "Hashtag", txtInput.Text, numTotalDownloads.Text }));
            if (rbLocation.Checked) lvInput.Items.Add(new ListViewItem(new[] { "Location", txtInput.Text, numTotalDownloads.Text }));

            txtInput.Clear();
            txtInput.Focus();
        }

        /// <summary>
        /// Clears all input (text box and list view).
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClearAllInput_Click(object sender, EventArgs e)
        {
            if (!InputValidation.ConfirmUserAction(btnClearAllInput)) return;

            txtInput.Clear();
            lvInput.Items.Clear();
        }
        #endregion

        #region Download Process
        /// <summary>
        /// Starts the download process.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void btnStartDownloading_Click(object sender, EventArgs e)
        {
            //var items = lvInput.Items.Cast<ListViewItem>();
            //var list = items.Where(x => x.Text == "Url");

            //foreach (var s in list)
            //{
            //    Console.WriteLine(s.SubItems[1].Text);
            //}

            // Input validation
            if (!InputValidation.ValidateWebSettings(txtUserAgent.Text, txtRequestTimeout.Text, txtProxy.Text, ':', txtThreads.Text)) return;
            if (!InputValidation.ValidateDownloadSettings(txtDownloadFolder.Text, cbSaveStats.Checked, txtDelimiter.Text)) return;
            if (lvInput.Items.Count == 0) return;
            if (!InputValidation.IsInt(txtThreads.Text)) return;

            // Proxy initialization
            _proxy = new ProxyObject(txtProxy.Text, ':');

            // Filters initialization
            var descriptionStrings = new List<string>();
            foreach (string s in txtSkipDescriptionStrings.Lines)
            {
                descriptionStrings.Add(s);
            }

            MediaFilter mediaFilter = new MediaFilter
            {
                SkipTopPosts = cbSkipTopPosts.Checked,
                SkipMediaIfVideo = cbSkipVideos.Checked,
                SkipMediaIfPhoto = cbSkipPhotos.Checked,
                SkipMediaComments = cbSkipMediaComments.Checked,
                SkipMediaCommentsMore = cbSkipMediaCommentsMoreLess.Text == @"more",
                SkipMediaCommentsCount = !String.IsNullOrEmpty(txtSkipMediaCommentsCount.Text) ? int.Parse(txtSkipMediaCommentsCount.Text) : 0,
                SkipMediaLikes = cbSkipMediaLikes.Checked,
                SkipMediaLikesMore = cbSkipMediaLikesMoreLess.Text == @"more",
                SkipMediaLikesCount = !String.IsNullOrEmpty(txtSkipMediaLikesCount.Text) ? int.Parse(txtSkipMediaLikesCount.Text) : 0,
                SkipMediaIfDescriptionContans = cbSkipMediaDescription.Checked,
                DescriptionStrings = descriptionStrings,
                SkipMediaUploadDateEnabled = cbSkipMediaUploadDate.Checked,
                SkipMediaUploadDateNewer = cbSkipMediaUploadDateMoreLess.Text == @"newer",
                SkipMediaUploadDate = ((DateTimeOffset)dtUpladTime.Value).ToUnixTimeSeconds(),
                SkipMediaVideoViews = cbSkipVideoViews.Checked,
                SkipMediaVideoViewsMore = cbSkipVideoViewsMoreLess.Text == @"more",
                SkipMediaVideoViewsCount = !String.IsNullOrEmpty(txtSkipVideoViewsCount.Text) ? int.Parse(txtSkipVideoViewsCount.Text) : 0,
                CustomFolder = cbCreateNewFolder.Checked,
                SaveStatsInCsvFile = cbSaveStats.Checked
            };

            // Download process
            if (!InputValidation.IsDouble(txtRequestTimeout.Text)) return;

            _cancellationTokenSource = new CancellationTokenSource();
            _cancellationToken = _cancellationTokenSource.Token;
            var requestTimeout = double.Parse(txtRequestTimeout.Text);

            // Initialize downloader object
            InstagramDownload downloader = new InstagramDownload(txtUserAgent.Text, _proxy.GetWebProxy(), requestTimeout, txtDownloadFolder.Text, _cancellationToken, _cookies, txtDelimiter.Text[0]);

            // Set downloader properties
            downloader.IsTotalDownloadsEnabled = cbTotalDownloads.Checked;
            if (!String.IsNullOrEmpty(txtTotalDownloads.Text)) downloader.TotalDownloads = int.Parse(txtTotalDownloads.Text);
            downloader.CustomFolder = cbCreateNewFolder.Checked;

            // Update form controls
            btnStartDownloading.Enabled = false;
            btnStopDownloading.Enabled = true;

            // Upload logs
            Log(@"Started downloading...", nameof(LogType.Success));

            // Start all tasks
            using (SemaphoreSlim semaphore = new SemaphoreSlim(int.Parse(txtThreads.Text)))
            {
                var tasks = new List<Task>();
                foreach (ListViewItem item in lvInput.Items)
                {
                    await semaphore.WaitAsync();

                    try
                    {
                        tasks.Add(
                            Task.Run(async () =>
                            {
                                switch (item.SubItems[0].Text)
                                {
                                    case "Url":
                                        try
                                        {
                                            await downloader.Download(item.SubItems[1].Text, InputType.Url,
                                                mediaFilter);
                                        }
                                        catch (OperationCanceledException ex)
                                        {
                                            Log(ex.Message, nameof(LogType.Error));
                                        }

                                        break;
                                    case "Username":
                                        try
                                        {
                                            await downloader.Download(item.SubItems[1].Text, InputType.Username,
                                                mediaFilter, item.SubItems[2].Text);
                                        }
                                        catch (OperationCanceledException ex)
                                        {
                                            Log(ex.Message, nameof(LogType.Error));
                                        }

                                        break;
                                    case "Hashtag":
                                        try
                                        {
                                            await downloader.Download(item.SubItems[1].Text, InputType.Hashtag,
                                                mediaFilter, item.SubItems[2].Text);
                                        }
                                        catch (OperationCanceledException ex)
                                        {
                                            Log(ex.Message, nameof(LogType.Error));
                                        }

                                        break;
                                    case "Location":
                                        try
                                        {
                                            await downloader.Download(item.SubItems[1].Text, InputType.Location,
                                                mediaFilter, item.SubItems[2].Text);
                                        }
                                        catch (OperationCanceledException ex)
                                        {
                                            Log(ex.Message, nameof(LogType.Error));
                                        }

                                        break;
                                }
                            }, _cancellationToken)
                        );
                    }
                    catch (Exception ex)
                    {
                        Log(ex.Message, nameof(LogType.Error));
                    }
                    finally
                    {
                        semaphore.Release();
                    }
                }

                // Wait for tasks to finish
                await Task.WhenAll(tasks); // might throw an exception if something goes wrong during tasks
                Log(@"Finished downloading.", nameof(LogType.Success));

                // Update form controls when tasks are finished
                btnStartDownloading.Enabled = true;
                btnStopDownloading.Enabled = false;
            }
        }

        /// <summary>
        /// Stops the download process.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnStopDownloading_Click(object sender, EventArgs e)
        {
            if (!InputValidation.ConfirmUserAction(btnStopDownloading)) return;

            _cancellationTokenSource.Cancel();
            btnStartDownloading.Enabled = true;
            btnStopDownloading.Enabled = false;
        }
        #endregion

        #region Logs
        /// <summary>
        /// Logs a message.
        /// </summary>
        /// <param name="message"></param>
        /// <param name="logType"></param>
        public void Log(string message, string logType)
        {
            Invoke((MethodInvoker)delegate
            {
                txtLogs.AppendText($@"{DateTime.Now} - {logType}: {message}{Environment.NewLine}");
            });
        }
        #endregion

        #region Load from file methods
        /// <summary>
        /// Loads input to list view from file.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLoadInputFromFile_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = 
                new OpenFileDialog
                {
                    Filter = @"Text Files (*.txt)|*.txt|CSV Files (.csv)|*.csv"
                })
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    Log(@"Attempting to load input from file...", nameof(LogType.Info));
                    string[] lines = File.ReadAllLines(ofd.FileName);
                    List<string> allowedType = new List<string>
                    {
                        "Url",
                        "Username",
                        "Hashtag",
                        "Location"
                    };

                    foreach (string s in lines)
                    {
                        if (s.Split('|').Length == 2)
                        {
                            if (allowedType.Any(type => s.Split('|')[0].Contains(type)))
                            {
                                lvInput.Items.Add(new ListViewItem(new[] { s.Split('|')[0], s.Split('|')[1], s.Split('|')[0] == "Url" ? "1" : "0" }));
                                Log($@"Successfully added input '{s.Split('|')[1]}' of type '{s.Split('|')[0]}'", nameof(LogType.Success));
                            }
                            else
                            {
                                Log($@"Failed to load string '{s}' due to bad type...", nameof(LogType.Fail));
                            }
                        }
                        else if (s.Split('|').Length == 3)
                        {
                            if (allowedType.Any(type => s.Split('|')[0].Contains(type)))
                            {
                                lvInput.Items.Add(new ListViewItem(new[] { s.Split('|')[0], s.Split('|')[1], s.Split('|')[2] }));
                                Log($@"Successfully added input '{s.Split('|')[1]}' of type '{s.Split('|')[0]}'", nameof(LogType.Success));
                            }
                            else
                            {
                                Log($@"Failed to load string '{s}' due to bad type...", nameof(LogType.Fail));
                            }
                        }
                        else
                        {
                            Log($@"Failed to load line '{s}' due to bad format...", nameof(LogType.Fail));
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Load description strings for filter
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLoadDescriptionStrings_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd =
                new OpenFileDialog
                {
                    Filter = @"Text Files (*.txt)|*.txt|CSV Files (.csv)|*.csv"
                })
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    Log(@"Attempting to load input from file...", nameof(LogType.Info));
                    string[] lines = File.ReadAllLines(ofd.FileName);

                    foreach (string s in lines)
                    {
                        txtSkipDescriptionStrings.AppendText(s + Environment.NewLine);
                    }

                    // remove the last line after importing (because it'll be an empty cause of new line)
                    txtSkipDescriptionStrings.Text = txtSkipDescriptionStrings.Text.Remove(txtSkipDescriptionStrings.Text.Length - 1);
                    Log(@"Successfully loaded input from file...", nameof(LogType.Info));
                }
            }
        }
        #endregion

        #region RadioButton Events
        // Make sure that skip photos is unchecked if skip video is checked
        private void cbSkipVideos_CheckedChanged(object sender, EventArgs e)
        {
            if (cbSkipVideos.Checked)
            {
                cbSkipPhotos.Checked = false;
            }
        }

        // Make sure that skip videos is unchecked if skip photos is checked
        private void cbSkipPhotos_CheckedChanged(object sender, EventArgs e)
        {
            if (cbSkipPhotos.Checked)
            {
                cbSkipVideos.Checked = false;
            }
        }

        // Disable total downloads if url is checked, because it's only one anyways.
        private void rbUrl_CheckedChanged(object sender, EventArgs e)
        {
            if (rbUrl.Checked)
            {
                lblTotalDownloads.Enabled = false;
                numTotalDownloads.Enabled = false;
            }
            else
            {
                lblTotalDownloads.Enabled = true;
                numTotalDownloads.Enabled = true;
            }
        }
#endregion

        #region LOGIN
        /// <summary>
        /// Hide password characters if enabled.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbHidePassword_CheckedChanged(object sender, EventArgs e)
        {
            txtAccountPassword.PasswordChar = cbHidePassword.Checked ? '*' : '\0';
        }

        /// <summary>
        /// Attempts to log in to an Instagram account.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void btnAccountLogin_Click(object sender, EventArgs e)
        {
            // Proxy initialization
            _proxy = new ProxyObject(txtProxy.Text, ':');

            // Account initialization
            InstagramAccount instagramAccount =
                new InstagramAccount(txtAccountUsername.Text, txtAccountPassword.Text, _proxy.GetWebProxy());

            // Login object initialization
            var instagramLogin = new InstagramLogin(instagramAccount, txtUserAgent.Text, double.Parse(txtRequestTimeout.Text));

            // Calls the login method and checks the cookies
            _cookies = await instagramLogin.Login();
            if (_cookies != null)
            {
                lblAccountLoginStatus.Text = @"Status: Logged in.";
                lblAccountLoginStatus.ForeColor = Color.Green;
                Log($@"Successfully logged in as {txtAccountUsername.Text}.", nameof(LogType.Success));
            }
            else
            {
                lblAccountLoginStatus.Text = @"Status: Failed to log in.";
                lblAccountLoginStatus.ForeColor = Color.Red;
                Log($@"Failed to log in as {txtAccountUsername.Text}.", nameof(LogType.Fail));
            }
        }

        #endregion

        #region SETTINGS
        /// <summary>
        /// Generates a random UA and sets it to the UA textbox.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRandomizeUserAgent_Click(object sender, EventArgs e)
        {
            txtUserAgent.Text = UserAgentGenerator.Generate();
        }

        /// <summary>
        /// Sets the folder where downloaded images will be downloaded.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnBrowseDownloadDirectory_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog fbd = new FolderBrowserDialog()
            {
                ShowNewFolderButton = true,
                Description = @"Download folder for medias"
            })
            {
                if (fbd.ShowDialog() == DialogResult.OK)
                {
                    txtDownloadFolder.Text = fbd.SelectedPath;
                    Log(@"Successfully initialized a download folder to save photos.", nameof(LogType.Success));
                }
            }
        }

        /// <summary>
        /// Main form load method - loads the settings from a file.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmMain_Load(object sender, EventArgs e)
        {
            Log(@"Successfully initialized form components and loaded software.", nameof(LogType.Success));
            try
            {
                Log(@"Attempting to load application settings...", nameof(LogType.Info));

                Settings settings = SettingsSerialization.Load();

                txtUserAgent.Text = !String.IsNullOrEmpty(settings.UserAgent) ? settings.UserAgent : UserAgentGenerator.Generate();
                txtRequestTimeout.Text = !String.IsNullOrEmpty(settings.RequestTimeout) ? settings.RequestTimeout : "150";
                txtThreads.Text = !String.IsNullOrEmpty(settings.Threads) ? settings.Threads : "1";
                txtProxy.Text = settings.Proxy;
                txtDownloadFolder.Text = !String.IsNullOrEmpty(settings.DownloadFolder) ? settings.DownloadFolder : Application.StartupPath;
                cbCreateNewFolder.Checked = settings.CreateNewFolder;
                cbRemoveEmoji.Checked = settings.RemoveEmoji;
                cbSaveStats.Checked = settings.SaveStats;
                txtDelimiter.Text = settings.Delimiter;
                cbSkipMediaDescription.Checked = settings.SkipDescription;
                cbSkipPhotos.Checked = settings.SkipPhotos;
                cbSkipVideos.Checked = settings.SkipVideos;
                cbSkipMediaLikes.Checked = settings.SkipLikes;
                cbSkipMediaLikesMoreLess.Text = settings.SkipLikesMoreLess;
                txtSkipMediaLikesCount.Text = settings.SkipLikesCount;
                cbSkipMediaComments.Checked = settings.SkipComments;
                cbSkipMediaCommentsMoreLess.Text = settings.SkipCommentsMoreLess;
                txtSkipMediaCommentsCount.Text = settings.SkipCommentsCount;
                cbSkipMediaUploadDate.Checked = settings.SkipUploadDate;
                cbTotalDownloads.Checked = settings.TotalDownloadsEnabled;
                txtTotalDownloads.Text = settings.TotalDownloads;

                Log(@"Successfully loaded application settings.", nameof(LogType.Success));
            }
            catch (Exception ex)
            {
                Log(ex.Message, nameof(LogType.Error));
            }
        }

        /// <summary>
        /// Main form closing - saves the settings to a file.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            Settings settings = new Settings(txtUserAgent.Text,
                                            txtRequestTimeout.Text,
                                            txtProxy.Text,
                                            txtThreads.Text,
                                            txtDownloadFolder.Text,
                                            cbCreateNewFolder.Checked,
                                            cbRemoveEmoji.Checked,
                                            cbSaveStats.Checked,
                                            txtDelimiter.Text,
                                            cbSkipMediaDescription.Checked,
                                            cbSkipPhotos.Checked,
                                            cbSkipVideos.Checked,
                                            cbSkipMediaLikes.Checked,
                                            cbSkipMediaLikesMoreLess.Text,
                                            txtSkipMediaLikesCount.Text,
                                            cbSkipMediaComments.Checked,
                                            cbSkipMediaCommentsMoreLess.Text,
                                            txtSkipMediaCommentsCount.Text,
                                            cbSkipMediaUploadDate.Checked,
                                            cbTotalDownloads.Checked,
                                            txtTotalDownloads.Text
                                            );
            SettingsSerialization.Save(settings);
        }

        #endregion
    }
}
