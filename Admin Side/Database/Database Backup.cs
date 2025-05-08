using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sims.Admin_Side.Database
{
    public partial class Database_Backup : Form
    {
        public Database_Backup()
        {
            InitializeComponent();
        }

        private void backUpBtn_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "SQL Files (*.sql)|*.sql",
                Title = "Save Backup File",
                FileName = "backup.sql"
            };

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string backupFilePath = saveFileDialog.FileName;
                string server = "localhost";
                string database = "your_database_name";
                string user = "root";
                string password = "";

                try
                {
                    string command = $@"-u{user} {(string.IsNullOrEmpty(password) ? "" : $"-p{password}")} -h{server} {database} > ""{backupFilePath}""";

                    ProcessStartInfo processInfo = new ProcessStartInfo
                    {
                        FileName = "cmd.exe",
                        RedirectStandardInput = true,
                        RedirectStandardOutput = true,
                        UseShellExecute = false,
                        CreateNoWindow = true
                    };

                    Process process = new Process
                    {
                        StartInfo = processInfo
                    };

                    process.Start();

                    using (var writer = process.StandardInput)
                    {
                        if (writer.BaseStream.CanWrite)
                        {
                            writer.WriteLine($@"cd ""{@"C:\xampp\mysql\bin"}""");
                            writer.WriteLine($"mysqldump {command}");
                        }
                    }

                    process.WaitForExit();
                    process.Close();

                    MessageBox.Show("Backup completed successfully!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error: {ex.Message}");
                }
            }
        }

        private void restoreBtn_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "SQL Files (*.sql)|*.sql",
                Title = "Select Backup File"
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string backupFilePath = openFileDialog.FileName;
                string server = "localhost";
                string database = "your_database_name";
                string user = "root";
                string password = "";

                try
                {
                    string command = $@"-u{user} {(string.IsNullOrEmpty(password) ? "" : $"-p{password}")} -h{server} {database} < ""{backupFilePath}""";

                    ProcessStartInfo processInfo = new ProcessStartInfo
                    {
                        FileName = "cmd.exe",
                        RedirectStandardInput = true,
                        RedirectStandardOutput = true,
                        UseShellExecute = false,
                        CreateNoWindow = true
                    };

                    Process process = new Process
                    {
                        StartInfo = processInfo
                    };

                    process.Start();

                    using (var writer = process.StandardInput)
                    {
                        if (writer.BaseStream.CanWrite)
                        {
                            writer.WriteLine($@"cd ""{@"C:\xampp\mysql\bin"}""");
                            writer.WriteLine($"mysql {command}");
                        }
                    }

                    process.WaitForExit();
                    process.Close();

                    MessageBox.Show("Restore completed successfully!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error: {ex.Message}");
                }
            }
        }
    }
}
