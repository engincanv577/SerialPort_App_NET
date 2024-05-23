namespace SerialPort_App_NET
{
    public partial class AdvancedSerialPortSettingsForm
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
        public void InitializeComponent()
        {
            this.ParityLabel = new Telerik.WinControls.UI.RadLabel();
            this.DataBitsLabel = new Telerik.WinControls.UI.RadLabel();
            this.StopBitsLabel = new Telerik.WinControls.UI.RadLabel();
            this.DtrLabel = new Telerik.WinControls.UI.RadLabel();
            this.RtsLabel = new Telerik.WinControls.UI.RadLabel();
            this.HandshakeLabel = new Telerik.WinControls.UI.RadLabel();
            this.RXTimeoutLabel = new Telerik.WinControls.UI.RadLabel();
            this.TXTimeoutLabel = new Telerik.WinControls.UI.RadLabel();
            this.ParityDropDownList = new Telerik.WinControls.UI.RadDropDownList();
            this.DataBitsDropDownList = new Telerik.WinControls.UI.RadDropDownList();
            this.StopBitsDropDownList = new Telerik.WinControls.UI.RadDropDownList();
            this.DtrDropDownList = new Telerik.WinControls.UI.RadDropDownList();
            this.RtsDropDownList = new Telerik.WinControls.UI.RadDropDownList();
            this.HandshakeDropDownList = new Telerik.WinControls.UI.RadDropDownList();
            this.RXTimeoutTextBox = new Telerik.WinControls.UI.RadTextBox();
            this.TXTimeoutTextBox = new Telerik.WinControls.UI.RadTextBox();
            this.RXTimeoutWarningLabel = new Telerik.WinControls.UI.RadLabel();
            this.TXTimeoutWarningLabel = new Telerik.WinControls.UI.RadLabel();
            ((System.ComponentModel.ISupportInitialize)(this.ParityLabel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataBitsLabel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.StopBitsLabel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DtrLabel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RtsLabel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.HandshakeLabel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RXTimeoutLabel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TXTimeoutLabel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ParityDropDownList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataBitsDropDownList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.StopBitsDropDownList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DtrDropDownList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RtsDropDownList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.HandshakeDropDownList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RXTimeoutTextBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TXTimeoutTextBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RXTimeoutWarningLabel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TXTimeoutWarningLabel)).BeginInit();
            this.SuspendLayout();
            // 
            // ParityLabel
            // 
            this.ParityLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.ParityLabel.Location = new System.Drawing.Point(12, 23);
            this.ParityLabel.Name = "ParityLabel";
            this.ParityLabel.Size = new System.Drawing.Size(40, 19);
            this.ParityLabel.TabIndex = 0;
            this.ParityLabel.Text = "Parity:";
            // 
            // DataBitsLabel
            // 
            this.DataBitsLabel.Location = new System.Drawing.Point(12, 53);
            this.DataBitsLabel.Name = "DataBitsLabel";
            this.DataBitsLabel.Size = new System.Drawing.Size(50, 18);
            this.DataBitsLabel.TabIndex = 1;
            this.DataBitsLabel.Text = "DataBits:";
            // 
            // StopBitsLabel
            // 
            this.StopBitsLabel.Location = new System.Drawing.Point(12, 83);
            this.StopBitsLabel.Name = "StopBitsLabel";
            this.StopBitsLabel.Size = new System.Drawing.Size(50, 18);
            this.StopBitsLabel.TabIndex = 2;
            this.StopBitsLabel.Text = "StopBits:";
            // 
            // DtrLabel
            // 
            this.DtrLabel.Location = new System.Drawing.Point(12, 113);
            this.DtrLabel.Name = "DtrLabel";
            this.DtrLabel.Size = new System.Drawing.Size(29, 18);
            this.DtrLabel.TabIndex = 3;
            this.DtrLabel.Text = "DTR:";
            // 
            // RtsLabel
            // 
            this.RtsLabel.Location = new System.Drawing.Point(12, 143);
            this.RtsLabel.Name = "RtsLabel";
            this.RtsLabel.Size = new System.Drawing.Size(27, 18);
            this.RtsLabel.TabIndex = 4;
            this.RtsLabel.Text = "RTS:";
            // 
            // HandshakeLabel
            // 
            this.HandshakeLabel.Location = new System.Drawing.Point(12, 173);
            this.HandshakeLabel.Name = "HandshakeLabel";
            this.HandshakeLabel.Size = new System.Drawing.Size(64, 18);
            this.HandshakeLabel.TabIndex = 5;
            this.HandshakeLabel.Text = "Handshake:";
            // 
            // RXTimeoutLabel
            // 
            this.RXTimeoutLabel.Location = new System.Drawing.Point(185, 24);
            this.RXTimeoutLabel.Name = "RXTimeoutLabel";
            this.RXTimeoutLabel.Size = new System.Drawing.Size(66, 18);
            this.RXTimeoutLabel.TabIndex = 6;
            this.RXTimeoutLabel.Text = "RX Timeout:";
            // 
            // TXTimeoutLabel
            // 
            this.TXTimeoutLabel.Location = new System.Drawing.Point(185, 83);
            this.TXTimeoutLabel.Name = "TXTimeoutLabel";
            this.TXTimeoutLabel.Size = new System.Drawing.Size(66, 18);
            this.TXTimeoutLabel.TabIndex = 7;
            this.TXTimeoutLabel.Text = "TX Timeout:";
            // 
            // ParityDropDownList
            // 
            this.ParityDropDownList.DropDownAnimationEnabled = true;
            this.ParityDropDownList.Location = new System.Drawing.Point(94, 24);
            this.ParityDropDownList.Name = "ParityDropDownList";
            this.ParityDropDownList.Size = new System.Drawing.Size(74, 20);
            this.ParityDropDownList.TabIndex = 8;
            this.ParityDropDownList.SelectedIndexChanged += new Telerik.WinControls.UI.Data.PositionChangedEventHandler(this.ParityDropDownList_SelectedIndexChanged);
            // 
            // DataBitsDropDownList
            // 
            this.DataBitsDropDownList.DropDownAnimationEnabled = true;
            this.DataBitsDropDownList.Location = new System.Drawing.Point(94, 53);
            this.DataBitsDropDownList.Name = "DataBitsDropDownList";
            this.DataBitsDropDownList.Size = new System.Drawing.Size(74, 20);
            this.DataBitsDropDownList.TabIndex = 9;
            this.DataBitsDropDownList.SelectedIndexChanged += new Telerik.WinControls.UI.Data.PositionChangedEventHandler(this.DataBitsDropDownList_SelectedIndexChanged);
            // 
            // StopBitsDropDownList
            // 
            this.StopBitsDropDownList.DropDownAnimationEnabled = true;
            this.StopBitsDropDownList.Location = new System.Drawing.Point(94, 83);
            this.StopBitsDropDownList.Name = "StopBitsDropDownList";
            this.StopBitsDropDownList.Size = new System.Drawing.Size(74, 20);
            this.StopBitsDropDownList.TabIndex = 10;
            this.StopBitsDropDownList.SelectedIndexChanged += new Telerik.WinControls.UI.Data.PositionChangedEventHandler(this.StopBitsDropDownList_SelectedIndexChanged);
            // 
            // DtrDropDownList
            // 
            this.DtrDropDownList.DropDownAnimationEnabled = true;
            this.DtrDropDownList.Location = new System.Drawing.Point(94, 113);
            this.DtrDropDownList.Name = "DtrDropDownList";
            this.DtrDropDownList.Size = new System.Drawing.Size(74, 20);
            this.DtrDropDownList.TabIndex = 11;
            this.DtrDropDownList.SelectedIndexChanged += new Telerik.WinControls.UI.Data.PositionChangedEventHandler(this.DtrDropDownList_SelectedIndexChanged);
            // 
            // RtsDropDownList
            // 
            this.RtsDropDownList.DropDownAnimationEnabled = true;
            this.RtsDropDownList.Location = new System.Drawing.Point(94, 143);
            this.RtsDropDownList.Name = "RtsDropDownList";
            this.RtsDropDownList.Size = new System.Drawing.Size(74, 20);
            this.RtsDropDownList.TabIndex = 12;
            this.RtsDropDownList.SelectedIndexChanged += new Telerik.WinControls.UI.Data.PositionChangedEventHandler(this.RtsDropDownList_SelectedIndexChanged);
            // 
            // HandshakeDropDownList
            // 
            this.HandshakeDropDownList.DropDownAnimationEnabled = true;
            this.HandshakeDropDownList.Location = new System.Drawing.Point(94, 173);
            this.HandshakeDropDownList.Name = "HandshakeDropDownList";
            this.HandshakeDropDownList.Size = new System.Drawing.Size(74, 20);
            this.HandshakeDropDownList.TabIndex = 13;
            this.HandshakeDropDownList.SelectedIndexChanged += new Telerik.WinControls.UI.Data.PositionChangedEventHandler(this.HandshakeDropDownList_SelectedIndexChanged);
            // 
            // RXTimeoutTextBox
            // 
            this.RXTimeoutTextBox.Location = new System.Drawing.Point(257, 24);
            this.RXTimeoutTextBox.Name = "RXTimeoutTextBox";
            this.RXTimeoutTextBox.Size = new System.Drawing.Size(74, 20);
            this.RXTimeoutTextBox.TabIndex = 15;
            this.RXTimeoutTextBox.Leave += new System.EventHandler(this.RXTimeoutTextBox_Leave);
            // 
            // TXTimeoutTextBox
            // 
            this.TXTimeoutTextBox.Location = new System.Drawing.Point(257, 81);
            this.TXTimeoutTextBox.Name = "TXTimeoutTextBox";
            this.TXTimeoutTextBox.Size = new System.Drawing.Size(74, 20);
            this.TXTimeoutTextBox.TabIndex = 16;
            this.TXTimeoutTextBox.Leave += new System.EventHandler(this.TXTimeoutTextBox_Leave);
            // 
            // RXTimeoutWarningLabel
            // 
            this.RXTimeoutWarningLabel.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.RXTimeoutWarningLabel.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.RXTimeoutWarningLabel.Location = new System.Drawing.Point(259, 50);
            this.RXTimeoutWarningLabel.Name = "RXTimeoutWarningLabel";
            this.RXTimeoutWarningLabel.Size = new System.Drawing.Size(70, 18);
            this.RXTimeoutWarningLabel.TabIndex = 17;
            this.RXTimeoutWarningLabel.Text = "(50-5000) ms";
            // 
            // TXTimeoutWarningLabel
            // 
            this.TXTimeoutWarningLabel.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.TXTimeoutWarningLabel.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.TXTimeoutWarningLabel.Location = new System.Drawing.Point(259, 107);
            this.TXTimeoutWarningLabel.Name = "TXTimeoutWarningLabel";
            this.TXTimeoutWarningLabel.Size = new System.Drawing.Size(72, 18);
            this.TXTimeoutWarningLabel.TabIndex = 18;
            this.TXTimeoutWarningLabel.Text = "(50-5000) ms";
            // 
            // AdvancedSerialPortSettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(345, 208);
            this.Controls.Add(this.TXTimeoutWarningLabel);
            this.Controls.Add(this.RXTimeoutWarningLabel);
            this.Controls.Add(this.TXTimeoutTextBox);
            this.Controls.Add(this.RXTimeoutTextBox);
            this.Controls.Add(this.HandshakeDropDownList);
            this.Controls.Add(this.RtsDropDownList);
            this.Controls.Add(this.DtrDropDownList);
            this.Controls.Add(this.StopBitsDropDownList);
            this.Controls.Add(this.DataBitsDropDownList);
            this.Controls.Add(this.ParityDropDownList);
            this.Controls.Add(this.TXTimeoutLabel);
            this.Controls.Add(this.RXTimeoutLabel);
            this.Controls.Add(this.HandshakeLabel);
            this.Controls.Add(this.RtsLabel);
            this.Controls.Add(this.DtrLabel);
            this.Controls.Add(this.StopBitsLabel);
            this.Controls.Add(this.DataBitsLabel);
            this.Controls.Add(this.ParityLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "AdvancedSerialPortSettingsForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Advanced Settings";
            ((System.ComponentModel.ISupportInitialize)(this.ParityLabel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataBitsLabel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.StopBitsLabel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DtrLabel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RtsLabel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.HandshakeLabel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RXTimeoutLabel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TXTimeoutLabel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ParityDropDownList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataBitsDropDownList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.StopBitsDropDownList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DtrDropDownList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RtsDropDownList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.HandshakeDropDownList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RXTimeoutTextBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TXTimeoutTextBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RXTimeoutWarningLabel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TXTimeoutWarningLabel)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.UI.RadLabel ParityLabel;
        private Telerik.WinControls.UI.RadLabel DataBitsLabel;
        private Telerik.WinControls.UI.RadLabel StopBitsLabel;
        private Telerik.WinControls.UI.RadLabel DtrLabel;
        private Telerik.WinControls.UI.RadLabel RtsLabel;
        private Telerik.WinControls.UI.RadLabel HandshakeLabel;
        private Telerik.WinControls.UI.RadLabel RXTimeoutLabel;
        private Telerik.WinControls.UI.RadLabel TXTimeoutLabel;
        public Telerik.WinControls.UI.RadDropDownList ParityDropDownList;
        private Telerik.WinControls.UI.RadDropDownList DataBitsDropDownList;
        private Telerik.WinControls.UI.RadDropDownList StopBitsDropDownList;
        private Telerik.WinControls.UI.RadDropDownList DtrDropDownList;
        private Telerik.WinControls.UI.RadDropDownList RtsDropDownList;
        private Telerik.WinControls.UI.RadDropDownList HandshakeDropDownList;
        private Telerik.WinControls.UI.RadTextBox RXTimeoutTextBox;
        private Telerik.WinControls.UI.RadTextBox TXTimeoutTextBox;
        private Telerik.WinControls.UI.RadLabel RXTimeoutWarningLabel;
        private Telerik.WinControls.UI.RadLabel TXTimeoutWarningLabel;
    }
}