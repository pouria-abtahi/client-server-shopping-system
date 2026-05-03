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
    public partial class MainForm : Form
    {
        private TcpClient client;
        private StreamReader reader;
        private StreamWriter writer;
        private bool isDisconnected = false; // Flag to prevent actions after disconnect

        public MainForm(TcpClient client, StreamReader reader, StreamWriter writer)

        {
            InitializeComponent();
            this.client = client;
            this.reader = reader;
            this.writer = writer;
        }

        private async void MainForm_Load(object sender, EventArgs e)

        {
            await LoadProducts();

            // Refresh product list whenever the form gains focus
            this.Activated += async (s, ev) =>
            {
                if (!isDisconnected)
                {
                    await LoadProducts();
                }
            };
        }

        private async System.Threading.Tasks.Task LoadProducts()
        {
            try
            {
                if (isDisconnected || client == null || !client.Connected)
                {
                    return; // Exit if disconnected
                }

                await writer.WriteLineAsync("GET_PRODUCTS");
                string response = await reader.ReadLineAsync();

                if (response.StartsWith("PRODUCTS:"))
                {
                    dgvProducts.Rows.Clear();
                    string[] products = response.Substring(9).Split('|');
                    foreach (var product in products)
                    {
                        string[] details = product.Split(',');
                        dgvProducts.Rows.Add(details[0], details[1]);
                    }
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show($"Error loading products: {ex.Message}");
            }
        }

        private async void btnPurchase_Click(object sender, EventArgs e)

        {
            if (isDisconnected || dgvProducts.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a product.");
                return;
            }

            string productName = dgvProducts.SelectedRows[0].Cells[0].Value.ToString();

            try

            {
                await writer.WriteLineAsync($"PURCHASE:{productName}");
                string response = await reader.ReadLineAsync();

                if (response == "DONE")
                {
                    MessageBox.Show("Purchase successful!");
                    await LoadProducts();
                }
                else if (response == "NOT_AVAILABLE")
                {
                    MessageBox.Show("Product not available.");
                }
                else if (response == "NOT_VALID")
                {
                    MessageBox.Show("Invalid product.");
                }
            }

            catch (Exception ex)

            {
                MessageBox.Show($"Error making purchase: {ex.Message}");
            }
        }

        private async void btnViewOrders_Click(object sender, EventArgs e)
        {
            if (isDisconnected) return;

            try

            {
                await writer.WriteLineAsync("GET_USER_ORDERS");
                string response = await reader.ReadLineAsync();

                if (response.StartsWith("ORDERS:"))
                {
                    string[] orders = response.Substring(7).Split('|');
                    string orderList = string.Join(Environment.NewLine, orders);

                    if (orders.Length > 0)
                    {
                        MessageBox.Show(orderList, "Your Orders");
                    }
                    else
                    {
                        MessageBox.Show("You have not placed any orders yet.", "Your Orders");
                    }

                    await LoadProducts();
                }

                else if (response == "USER_NOT_CONNECTED")
                {
                    MessageBox.Show("You are not connected to the server.");
                }

                else
                {
                    MessageBox.Show("Error fetching your orders.");
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show($"Error fetching orders: {ex.Message}");
            }
        }

        private async void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            await DisconnectClient();
        }

        private async void btnDisconnect_Click(object sender, EventArgs e)
        {
            await DisconnectClient();
        }

        private async Task DisconnectClient()
        {
            if (isDisconnected) return; // Prevent duplicate disconnect logic

            isDisconnected = true;

            try
            {
                if (writer != null && client != null && client.Connected)
                {
                    await writer.WriteLineAsync("DISCONNECT"); // Send the DISCONNECT command
                }
            }
            catch (ObjectDisposedException)
            {
                // Ignore, the client is already disposed
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error while disconnecting: {ex.Message}");
            }
            finally
            {
                // Safely dispose all resources
                reader?.Dispose();
                writer?.Dispose();
                client?.Close();

                MessageBox.Show("Disconnected from the server.");
                this.Close(); // Close the form
            }
        }

        private void dgvProducts_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }
    }
}
