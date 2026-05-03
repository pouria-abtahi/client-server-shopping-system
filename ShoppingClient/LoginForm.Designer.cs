namespace ShoppingClient
{
    partial class LoginForm
    {
        private System.ComponentModel.IContainer components = null;

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
            lblHostname = new Label();
            txtHostname = new TextBox();
            lblAccountNumber = new Label();
            txtAccountNumber = new TextBox();
            btnConnect = new Button();
            SuspendLayout();
            // 
            // lblHostname
            // 
            lblHostname.AutoSize = true;
            lblHostname.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblHostname.Location = new Point(69, 34);
            lblHostname.Name = "lblHostname";
            lblHostname.Size = new Size(85, 20);
            lblHostname.TabIndex = 0;
            lblHostname.Text = "Hostname:";
            // 
            // txtHostname
            // 
            txtHostname.Location = new Point(160, 27);
            txtHostname.Name = "txtHostname";
            txtHostname.Size = new Size(275, 27);
            txtHostname.TabIndex = 1;
            txtHostname.Text = "localhost";
            // 
            // lblAccountNumber
            // 
            lblAccountNumber.AutoSize = true;
            lblAccountNumber.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblAccountNumber.Location = new Point(20, 80);
            lblAccountNumber.Name = "lblAccountNumber";
            lblAccountNumber.Size = new Size(134, 20);
            lblAccountNumber.TabIndex = 2;
            lblAccountNumber.Text = "Account Number:";
            // 
            // txtAccountNumber
            // 
            txtAccountNumber.Location = new Point(160, 77);
            txtAccountNumber.Name = "txtAccountNumber";
            txtAccountNumber.Size = new Size(275, 27);
            txtAccountNumber.TabIndex = 3;
            // 
            // btnConnect
            // 
            btnConnect.BackColor = SystemColors.Highlight;
            btnConnect.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnConnect.Location = new Point(327, 143);
            btnConnect.Name = "btnConnect";
            btnConnect.Size = new Size(116, 46);
            btnConnect.TabIndex = 4;
            btnConnect.Text = "Connect";
            btnConnect.UseVisualStyleBackColor = false;
            btnConnect.Click += btnConnect_Click;
            // 
            // LoginForm
            // 
            ClientSize = new Size(455, 201);
            Controls.Add(btnConnect);
            Controls.Add(txtAccountNumber);
            Controls.Add(lblAccountNumber);
            Controls.Add(txtHostname);
            Controls.Add(lblHostname);
            Name = "LoginForm";
            Text = "Login";
            Load += LoginForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        private System.Windows.Forms.Label lblHostname;
        private System.Windows.Forms.TextBox txtHostname;
        private System.Windows.Forms.Label lblAccountNumber;
        private System.Windows.Forms.TextBox txtAccountNumber;
        private System.Windows.Forms.Button btnConnect;
    }
}
