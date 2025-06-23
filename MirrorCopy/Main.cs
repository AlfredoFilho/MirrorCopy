using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MirrorCopy
{
    public partial class Main : Form
    {
        private bool darkModeEnabled = false;
        private const string ConfigFileName = "MirrorCopy.config";
        private string configFilePath;

        public Main(string[] args = null)
        {
            InitializeComponent();

            string appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            string appConfigDir = Path.Combine(appDataPath, "MirrorCopy");
            if (!Directory.Exists(appConfigDir))
            {
                Directory.CreateDirectory(appConfigDir);
            }
            configFilePath = Path.Combine(appConfigDir, ConfigFileName);

            LoadLastConfig();

            this.Resize += new EventHandler(Main_Resize);
            notifyIcon.MouseDoubleClick += new MouseEventHandler(notifyIcon_MouseDoubleClick);
            notifyIcon.BalloonTipClicked += new EventHandler(notifyIcon_BalloonTipClicked);

            if (args != null && args.Length > 0)
            {
                string sourcePath = string.Empty;
                string destinationPath = string.Empty;

                for (int i = 0; i < args.Length; i++)
                {
                    if (args[i].Equals("/source", StringComparison.OrdinalIgnoreCase) && i + 1 < args.Length)
                    {
                        sourcePath = args[++i];
                    }
                    else if (args[i].Equals("/destination", StringComparison.OrdinalIgnoreCase) && i + 1 < args.Length)
                    {
                        destinationPath = args[++i];
                    }
                }

                if (Directory.Exists(sourcePath))
                {
                    txtSource.Text = sourcePath;
                }
                if (Directory.Exists(destinationPath))
                {
                    txtDestination.Text = destinationPath;
                }

                if (!string.IsNullOrEmpty(txtSource.Text) && !string.IsNullOrEmpty(txtDestination.Text))
                {
                    this.Shown += async (sender, e) =>
                    {
                        this.Hide();
                        await ExecuteBackupFromCli();
                        Application.Exit();
                    };
                }
            }
        }

        private class MirrorCopyConfig
        {
            public string Source { get; set; }
            public string Destination { get; set; }
            public string Log { get; set; }
            public bool DarkModeEnabled { get; set; }
        }

        private void LoadLastConfig()
        {
            if (!File.Exists(configFilePath)) return;

            try
            {
                string json = File.ReadAllText(configFilePath);
                var cfg = System.Text.Json.JsonSerializer.Deserialize<MirrorCopyConfig>(json);
                if (cfg == null) return;

                txtSource.Text = cfg.Source ?? string.Empty;
                txtDestination.Text = cfg.Destination ?? string.Empty;
                txtLog.Text = cfg.Log ?? string.Empty;
                if (cfg.DarkModeEnabled != darkModeEnabled)
                {
                    ToggleTheme();
                }
            }
            catch { }
        }

        private void SaveConfig(string source, string destination, string log)
        {
            var cfg = new MirrorCopyConfig
            {
                Source = source,
                Destination = destination,
                Log = Path.GetDirectoryName(log) ?? string.Empty,
                DarkModeEnabled = darkModeEnabled
            };

            string json = System.Text.Json.JsonSerializer.Serialize(
                cfg,
                new System.Text.Json.JsonSerializerOptions { WriteIndented = true });

            File.WriteAllText(configFilePath, json);
        }

        private void btnToggleTheme_Click(object sender, EventArgs e)
        {
            ToggleTheme();
        }

        private void ToggleTheme()
        {
            darkModeEnabled = !darkModeEnabled;

            Color backColor = darkModeEnabled ? Color.FromArgb(30, 30, 30) : SystemColors.Control;
            Color foreColor = darkModeEnabled ? Color.White : SystemColors.ControlText;

            this.BackColor = backColor;

            foreach (Control ctrl in this.Controls)
            {
                if (ctrl is TextBox || ctrl is RichTextBox)
                {
                    ctrl.BackColor = darkModeEnabled ? Color.FromArgb(45, 45, 45) : Color.White;
                    ctrl.ForeColor = foreColor;
                }
                else if (ctrl is Button || ctrl is Label)
                {
                    ctrl.BackColor = backColor;
                    ctrl.ForeColor = foreColor;
                }
            }

            btnToggleTheme.Text = darkModeEnabled ? "Light Mode" : "Dark Mode";
        }

        private void Main_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.ShowInTaskbar = false;
                notifyIcon.Visible = true;

                notifyIcon.BalloonTipTitle = "MirrorCopy";
                notifyIcon.BalloonTipText = "MirrorCopy is running in the background.";
                notifyIcon.ShowBalloonTip(3000);
            }
        }

        private void notifyIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.ShowInTaskbar = true;
            notifyIcon.Visible = false;
            this.WindowState = FormWindowState.Normal;
            this.Activate();
        }

        private void notifyIcon_BalloonTipClicked(object sender, EventArgs e)
        {
            this.ShowInTaskbar = true;
            notifyIcon.Visible = false;
            this.WindowState = FormWindowState.Normal;
            this.Activate();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.ShowInTaskbar = true;
            notifyIcon.Visible = false;
            this.WindowState = FormWindowState.Normal;
            this.Activate();
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnBrowseOrig_Click(object sender, EventArgs e)
        {
            using (var dlg = new FolderBrowserDialog())
            {
                dlg.Description = "Select the source folder";
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    txtSource.Text = dlg.SelectedPath;
                }
            }
        }

        private void btnBrowseDest_Click(object sender, EventArgs e)
        {
            using (var dlg = new FolderBrowserDialog())
            {
                dlg.Description = "Select the destination folder";
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    txtDestination.Text = dlg.SelectedPath;
                }
            }
        }

        private void btnBrowseLog_Click(object sender, EventArgs e)
        {
            using (var dlg = new FolderBrowserDialog())
            {
                dlg.Description = "Select the folder to save logs";
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    txtLog.Text = dlg.SelectedPath;
                }
            }
        }

        private async void btnExecute_Click(object sender, EventArgs e)
        {
            string source = txtSource.Text.Trim();
            string destination = txtDestination.Text.Trim();
            string log = txtLog.Text.Trim();

            if (string.IsNullOrEmpty(source) || string.IsNullOrEmpty(destination))
            {
                MessageBox.Show("Source and destination folders are required.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (string.IsNullOrWhiteSpace(log) || !Directory.Exists(log))
            {
                log = AppDomain.CurrentDomain.BaseDirectory;
            }

            log = Path.Combine(log, $"backup_log_{DateTime.Now:yyyyMMdd_HHmmss}.txt");

            bool confirm = await PreviewBackup(source, destination);
            if (!confirm)
            {
                txtOutput.AppendText("-------------------------------------------------------------------------------");
                txtOutput.AppendText(Environment.NewLine + "Backup cancelled by the user.");
                return;
            }

            await ExecuteBackup(source, destination, log);
        }

        private async Task ExecuteBackupFromCli()
        {
            string source = txtSource.Text.Trim();
            string destination = txtDestination.Text.Trim();
            string log = txtLog.Text.Trim();

            if (string.IsNullOrWhiteSpace(log) || !Directory.Exists(log))
            {
                log = AppDomain.CurrentDomain.BaseDirectory;
            }

            log = Path.Combine(log, $"backup_log_{DateTime.Now:yyyyMMdd_HHmmss}.txt");

            await ExecuteBackup(source, destination, log);
        }

        private async Task<bool> PreviewBackup(string source, string destination)
        {
            txtOutput.Clear();

            var psiPreview = new ProcessStartInfo
            {
                FileName = "robocopy",
                Arguments = $"\"{source}\" \"{destination}\" /E /MIR /L /V",
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                UseShellExecute = false,
                CreateNoWindow = true,
                StandardOutputEncoding = Encoding.UTF8,
                StandardErrorEncoding = Encoding.UTF8
            };

            try
            {
                using var process = new Process { StartInfo = psiPreview };
                process.Start();

                string output = await process.StandardOutput.ReadToEndAsync();
                string error = await process.StandardError.ReadToEndAsync();

                process.WaitForExit();

                if (!string.IsNullOrWhiteSpace(error))
                    output += Environment.NewLine + "ERROR:" + Environment.NewLine + error;

                using var previewForm = new PreviewForm(output);
                previewForm.ShowDialog(this);

                return previewForm.Confirmed;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while executing RoboCopy Preview: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private async Task ExecuteBackup(string source, string destination, string log)
        {
            txtOutput.Clear();

            var psi = new ProcessStartInfo
            {
                FileName = "robocopy",
                Arguments = $"\"{source}\" \"{destination}\" /E /MIR /Z /V",
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                UseShellExecute = false,
                CreateNoWindow = true,
                StandardOutputEncoding = Encoding.UTF8,
                StandardErrorEncoding = Encoding.UTF8
            };

            try
            {
                using var writer = new StreamWriter(log, append: false, Encoding.UTF8);
                using var process = new Process { StartInfo = psi };

                process.OutputDataReceived += (s, ea) =>
                {
                    if (!string.IsNullOrEmpty(ea.Data))
                    {
                        this.Invoke((MethodInvoker)(() =>
                            txtOutput.AppendText(ea.Data + Environment.NewLine)));

                        writer.WriteLine(ea.Data);
                    }
                };

                process.ErrorDataReceived += (s, ea) =>
                {
                    if (!string.IsNullOrEmpty(ea.Data))
                    {
                        this.Invoke((MethodInvoker)(() =>
                            txtOutput.AppendText("ERROR: " + ea.Data + Environment.NewLine)));

                        writer.WriteLine("ERROR: " + ea.Data);
                    }
                };

                notifyIcon.Visible = true;

                process.Start();
                process.BeginOutputReadLine();
                process.BeginErrorReadLine();

                await process.WaitForExitAsync();

                this.Invoke((MethodInvoker)(() =>
                {
                    txtOutput.AppendText(Environment.NewLine + "Backup completed!" + Environment.NewLine);
                    txtOutput.AppendText("Log saved at: " + log + Environment.NewLine);
                }));

                SaveConfig(source, destination, log);

                notifyIcon.BalloonTipText = "Backup completed successfully.";
                notifyIcon.ShowBalloonTip(3000);

            }
            catch (Exception ex)
            {
                this.Invoke((MethodInvoker)(() =>
                {
                    MessageBox.Show("Error while executing RoboCopy: " + ex.Message,
                                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }));

                notifyIcon.Icon = SystemIcons.Error;
                notifyIcon.BalloonTipText = "Backup failed: " + ex.Message;
                notifyIcon.ShowBalloonTip(4000);
            }
        }
    }
}