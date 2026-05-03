namespace ShoppingClient
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                // Dispose of UI components
                components?.Dispose();

                // Dispose of TcpClient and related resources
                if (client != null)
                {
                    client.Close(); // Close the TcpClient connection
                    client = null;  // Prevent further use
                }

                writer?.Dispose(); // Dispose of StreamWriter
                reader?.Dispose(); // Dispose of StreamReader
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            dgvProducts = new DataGridView();
            colProductName = new DataGridViewTextBoxColumn();
            colQuantity = new DataGridViewTextBoxColumn();
            btnPurchase = new Button();
            btnViewOrders = new Button();
            errorProvider1 = new ErrorProvider(components);
            btnDisconnect = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvProducts).BeginInit();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
            SuspendLayout();
            // 
            // dgvProducts
            // 
            dgvProducts.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvProducts.Columns.AddRange(new DataGridViewColumn[] { colProductName, colQuantity });
            dgvProducts.Location = new Point(12, 12);
            dgvProducts.Name = "dgvProducts";
            dgvProducts.ReadOnly = true;
            dgvProducts.RowHeadersWidth = 62;
            dgvProducts.RowTemplate.Height = 28;
            dgvProducts.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvProducts.Size = new Size(621, 257);
            dgvProducts.TabIndex = 0;
            dgvProducts.CellContentClick += dgvProducts_CellContentClick;
            // 
            // colProductName
            // 
            colProductName.HeaderText = "Product Name";
            colProductName.MinimumWidth = 8;
            colProductName.Name = "colProductName";
            colProductName.ReadOnly = true;
            colProductName.Width = 200;
            // 
            // colQuantity
            // 
            colQuantity.HeaderText = "Quantity";
            colQuantity.MinimumWidth = 8;
            colQuantity.Name = "colQuantity";
            colQuantity.ReadOnly = true;
            colQuantity.Width = 125;
            // 
            // btnPurchase
            // 
            btnPurchase.BackColor = SystemColors.ActiveCaption;
            btnPurchase.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnPurchase.Location = new Point(21, 285);
            btnPurchase.Name = "btnPurchase";
            btnPurchase.Size = new Size(110, 46);
            btnPurchase.TabIndex = 1;
            btnPurchase.Text = "Purchase";
            btnPurchase.UseVisualStyleBackColor = false;
            btnPurchase.Click += btnPurchase_Click;
            // 
            // btnViewOrders
            // 
            btnViewOrders.BackColor = Color.YellowGreen;
            btnViewOrders.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnViewOrders.Location = new Point(495, 285);
            btnViewOrders.Name = "btnViewOrders";
            btnViewOrders.Size = new Size(120, 46);
            btnViewOrders.TabIndex = 2;
            btnViewOrders.Text = "View Orders";
            btnViewOrders.UseVisualStyleBackColor = false;
            btnViewOrders.Click += btnViewOrders_Click;
            // 
            // errorProvider1
            // 
            errorProvider1.ContainerControl = this;
            // 
            // btnDisconnect
            // 
            btnDisconnect.BackColor = SystemColors.ButtonShadow;
            btnDisconnect.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnDisconnect.Location = new Point(495, 360);
            btnDisconnect.Name = "btnDisconnect";
            btnDisconnect.Size = new Size(120, 45);
            btnDisconnect.TabIndex = 3;
            btnDisconnect.Text = "Disconnect";
            btnDisconnect.UseVisualStyleBackColor = false;
            btnDisconnect.Click += btnDisconnect_Click;
            // 
            // MainForm
            // 
            ClientSize = new Size(660, 417);
            Controls.Add(btnDisconnect);
            Controls.Add(btnViewOrders);
            Controls.Add(btnPurchase);
            Controls.Add(dgvProducts);
            Name = "MainForm";
            Text = "Shopping Client";
            FormClosing += MainForm_FormClosing;
            Load += MainForm_Load;
            ((System.ComponentModel.ISupportInitialize)dgvProducts).EndInit();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
            ResumeLayout(false);
        }

        private System.Windows.Forms.DataGridView dgvProducts;
        private System.Windows.Forms.DataGridViewTextBoxColumn colProductName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colQuantity;
        private System.Windows.Forms.Button btnPurchase;
        private System.Windows.Forms.Button btnViewOrders;
        private ErrorProvider errorProvider1;
        private Button btnDisconnect;
    }
}