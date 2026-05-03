using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Sockets;

namespace ShoppingClient
{
    public partial class LoginForm : Form
    {
        private TcpClient client;
        private StreamReader reader;
        private StreamWriter writer;

        public LoginForm()
        {
            InitializeComponent();
        }

        private async void btnConnect_Click(object sender, EventArgs e)
        {
            // Validate Account Number
            if (string.IsNullOrWhiteSpace(txtAccountNumber.Text) || !int.TryParse(txtAccountNumber.Text, out _))
            {
                MessageBox.Show("Please enter a valid account number.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                string hostname = txtHostname.Text;
                int port = 5000;
                client = new TcpClient(hostname, port);

                var stream = client.GetStream();
                reader = new StreamReader(stream);
                writer = new StreamWriter(stream) { AutoFlush = true };

                string accountNumber = txtAccountNumber.Text;
                await writer.WriteLineAsync($"CONNECT:{accountNumber}");
                string response = await reader.ReadLineAsync();

                if (response.StartsWith("CONNECTED"))
                {
                    string userName = response.Substring(10);
                    MessageBox.Show($"Welcome, {userName}!");

                    var mainForm = new MainForm(client, reader, writer);
                    mainForm.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Invalid account number.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error connecting to server: {ex.Message}");
            }
        }

        private async void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                // Send DISCONNECT command if the writer and client are still active
                if (writer != null && client != null && client.Connected)
                {
                    await writer.WriteLineAsync("DISCONNECT");
                }

                // Safely close the client connection
                client?.Close();
                client = null;
            }
            catch (ObjectDisposedException)
            {
                // This occurs if the client or stream is already disposed; ignore it
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error while closing the application: {ex.Message}");
            }
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {

        }
    }
}
