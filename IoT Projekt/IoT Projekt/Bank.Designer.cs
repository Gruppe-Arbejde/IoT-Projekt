
namespace IoT_Projekt
{
    partial class Bank
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.labelBalance = new System.Windows.Forms.Label();
            this.labelAccountName = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.listBoxTransactions = new System.Windows.Forms.ListBox();
            this.buttonSend = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.textBoxSendAmount = new System.Windows.Forms.TextBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.labelTransactions = new System.Windows.Forms.Label();
            this.labelMoneyTransfer = new System.Windows.Forms.Label();
            this.labelTransferMoneyTo = new System.Windows.Forms.Label();
            this.labelTransferAmount = new System.Windows.Forms.Label();
            this.labelTargetMissing = new System.Windows.Forms.Label();
            this.labelAmountMissing = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Control;
            this.panel1.Controls.Add(this.labelBalance);
            this.panel1.Controls.Add(this.labelAccountName);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(723, 69);
            this.panel1.TabIndex = 0;
            // 
            // labelBalance
            // 
            this.labelBalance.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.labelBalance.Font = new System.Drawing.Font("Arial", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelBalance.ForeColor = System.Drawing.Color.Black;
            this.labelBalance.Location = new System.Drawing.Point(385, 20);
            this.labelBalance.Name = "labelBalance";
            this.labelBalance.Size = new System.Drawing.Size(317, 32);
            this.labelBalance.TabIndex = 1;
            this.labelBalance.Text = "0,00 kr.";
            this.labelBalance.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labelAccountName
            // 
            this.labelAccountName.AutoSize = true;
            this.labelAccountName.Font = new System.Drawing.Font("Arial", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelAccountName.ForeColor = System.Drawing.Color.Black;
            this.labelAccountName.Location = new System.Drawing.Point(19, 20);
            this.labelAccountName.Name = "labelAccountName";
            this.labelAccountName.Size = new System.Drawing.Size(226, 32);
            this.labelAccountName.TabIndex = 0;
            this.labelAccountName.Text = "(Account Name)";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.Control;
            this.panel2.Controls.Add(this.labelTransactions);
            this.panel2.Controls.Add(this.listBoxTransactions);
            this.panel2.Location = new System.Drawing.Point(12, 101);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(415, 362);
            this.panel2.TabIndex = 0;
            // 
            // listBoxTransactions
            // 
            this.listBoxTransactions.FormattingEnabled = true;
            this.listBoxTransactions.Location = new System.Drawing.Point(4, 43);
            this.listBoxTransactions.Name = "listBoxTransactions";
            this.listBoxTransactions.Size = new System.Drawing.Size(407, 316);
            this.listBoxTransactions.TabIndex = 0;
            // 
            // buttonSend
            // 
            this.buttonSend.Location = new System.Drawing.Point(22, 258);
            this.buttonSend.Name = "buttonSend";
            this.buttonSend.Size = new System.Drawing.Size(247, 61);
            this.buttonSend.TabIndex = 1;
            this.buttonSend.Text = "Send Money";
            this.buttonSend.UseVisualStyleBackColor = true;
            this.buttonSend.Click += new System.EventHandler(this.buttonSend_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(22, 97);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(247, 21);
            this.comboBox1.TabIndex = 2;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // textBoxSendAmount
            // 
            this.textBoxSendAmount.Location = new System.Drawing.Point(22, 181);
            this.textBoxSendAmount.Name = "textBoxSendAmount";
            this.textBoxSendAmount.Size = new System.Drawing.Size(247, 20);
            this.textBoxSendAmount.TabIndex = 3;
            this.textBoxSendAmount.TextChanged += new System.EventHandler(this.textBoxSendAmount_TextChanged);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.Control;
            this.panel3.Controls.Add(this.labelAmountMissing);
            this.panel3.Controls.Add(this.labelTargetMissing);
            this.panel3.Controls.Add(this.labelTransferAmount);
            this.panel3.Controls.Add(this.labelTransferMoneyTo);
            this.panel3.Controls.Add(this.labelMoneyTransfer);
            this.panel3.Controls.Add(this.buttonSend);
            this.panel3.Controls.Add(this.comboBox1);
            this.panel3.Controls.Add(this.textBoxSendAmount);
            this.panel3.Location = new System.Drawing.Point(445, 101);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(290, 359);
            this.panel3.TabIndex = 1;
            // 
            // labelTransactions
            // 
            this.labelTransactions.AutoSize = true;
            this.labelTransactions.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTransactions.ForeColor = System.Drawing.Color.Black;
            this.labelTransactions.Location = new System.Drawing.Point(3, 11);
            this.labelTransactions.Name = "labelTransactions";
            this.labelTransactions.Size = new System.Drawing.Size(161, 29);
            this.labelTransactions.TabIndex = 2;
            this.labelTransactions.Text = "Transactions";
            // 
            // labelMoneyTransfer
            // 
            this.labelMoneyTransfer.AutoSize = true;
            this.labelMoneyTransfer.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelMoneyTransfer.ForeColor = System.Drawing.Color.Black;
            this.labelMoneyTransfer.Location = new System.Drawing.Point(51, 11);
            this.labelMoneyTransfer.Name = "labelMoneyTransfer";
            this.labelMoneyTransfer.Size = new System.Drawing.Size(191, 29);
            this.labelMoneyTransfer.TabIndex = 3;
            this.labelMoneyTransfer.Text = "Money Transfer";
            // 
            // labelTransferMoneyTo
            // 
            this.labelTransferMoneyTo.AutoSize = true;
            this.labelTransferMoneyTo.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTransferMoneyTo.ForeColor = System.Drawing.Color.Black;
            this.labelTransferMoneyTo.Location = new System.Drawing.Point(18, 72);
            this.labelTransferMoneyTo.Name = "labelTransferMoneyTo";
            this.labelTransferMoneyTo.Size = new System.Drawing.Size(187, 22);
            this.labelTransferMoneyTo.TabIndex = 4;
            this.labelTransferMoneyTo.Text = "Transfer money to:";
            // 
            // labelTransferAmount
            // 
            this.labelTransferAmount.AutoSize = true;
            this.labelTransferAmount.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTransferAmount.ForeColor = System.Drawing.Color.Black;
            this.labelTransferAmount.Location = new System.Drawing.Point(18, 156);
            this.labelTransferAmount.Name = "labelTransferAmount";
            this.labelTransferAmount.Size = new System.Drawing.Size(171, 22);
            this.labelTransferAmount.TabIndex = 5;
            this.labelTransferAmount.Text = "Transfer amount:";
            // 
            // labelTargetMissing
            // 
            this.labelTargetMissing.AutoSize = true;
            this.labelTargetMissing.BackColor = System.Drawing.SystemColors.Control;
            this.labelTargetMissing.Font = new System.Drawing.Font("Arial", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTargetMissing.ForeColor = System.Drawing.Color.Red;
            this.labelTargetMissing.Location = new System.Drawing.Point(19, 121);
            this.labelTargetMissing.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelTargetMissing.Name = "labelTargetMissing";
            this.labelTargetMissing.Size = new System.Drawing.Size(158, 14);
            this.labelTargetMissing.TabIndex = 6;
            this.labelTargetMissing.Text = "Please select transfer reciever!";
            // 
            // labelAmountMissing
            // 
            this.labelAmountMissing.AutoSize = true;
            this.labelAmountMissing.BackColor = System.Drawing.SystemColors.Control;
            this.labelAmountMissing.Font = new System.Drawing.Font("Arial", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelAmountMissing.ForeColor = System.Drawing.Color.Red;
            this.labelAmountMissing.Location = new System.Drawing.Point(19, 204);
            this.labelAmountMissing.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelAmountMissing.Name = "labelAmountMissing";
            this.labelAmountMissing.Size = new System.Drawing.Size(132, 14);
            this.labelAmountMissing.TabIndex = 7;
            this.labelAmountMissing.Text = "Please enter valid amount!";
            // 
            // Bank
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.RoyalBlue;
            this.ClientSize = new System.Drawing.Size(747, 475);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "Bank";
            this.Text = "Fake Bank";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Bank_FormClosed);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label labelBalance;
        private System.Windows.Forms.Label labelAccountName;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ListBox listBoxTransactions;
        private System.Windows.Forms.Button buttonSend;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.TextBox textBoxSendAmount;
        private System.Windows.Forms.Label labelTransactions;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label labelTransferAmount;
        private System.Windows.Forms.Label labelTransferMoneyTo;
        private System.Windows.Forms.Label labelMoneyTransfer;
        private System.Windows.Forms.Label labelAmountMissing;
        private System.Windows.Forms.Label labelTargetMissing;
    }
}