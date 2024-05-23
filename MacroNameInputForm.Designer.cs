namespace SerialPort_App_NET
{
    partial class MacroNameInputForm
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
            this.MacroNameInputText = new Telerik.WinControls.UI.RadTextBox();
            this.MacroNameInputButton_OK = new Telerik.WinControls.UI.RadButton();
            this.MacroNameInputButton_Cancel = new Telerik.WinControls.UI.RadButton();
            ((System.ComponentModel.ISupportInitialize)(this.MacroNameInputText)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MacroNameInputButton_OK)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MacroNameInputButton_Cancel)).BeginInit();
            this.SuspendLayout();
            // 
            // MacroNameInputText
            // 
            this.MacroNameInputText.Location = new System.Drawing.Point(12, 12);
            this.MacroNameInputText.Name = "MacroNameInputText";
            this.MacroNameInputText.Size = new System.Drawing.Size(243, 20);
            this.MacroNameInputText.TabIndex = 0;
            this.MacroNameInputText.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.MacroNameInputText_KeyPress);
            // 
            // MacroNameInputButton_OK
            // 
            this.MacroNameInputButton_OK.Location = new System.Drawing.Point(12, 48);
            this.MacroNameInputButton_OK.Name = "MacroNameInputButton_OK";
            this.MacroNameInputButton_OK.Size = new System.Drawing.Size(102, 22);
            this.MacroNameInputButton_OK.TabIndex = 1;
            this.MacroNameInputButton_OK.Text = "OK";
            this.MacroNameInputButton_OK.Click += new System.EventHandler(this.MacroNameInputButton_OK_Click);
            // 
            // MacroNameInputButton_Cancel
            // 
            this.MacroNameInputButton_Cancel.Location = new System.Drawing.Point(153, 48);
            this.MacroNameInputButton_Cancel.Name = "MacroNameInputButton_Cancel";
            this.MacroNameInputButton_Cancel.Size = new System.Drawing.Size(102, 22);
            this.MacroNameInputButton_Cancel.TabIndex = 2;
            this.MacroNameInputButton_Cancel.Text = "Cancel";
            this.MacroNameInputButton_Cancel.Click += new System.EventHandler(this.MacroNameInputButton_Cancel_Click);
            // 
            // MacroNameInputForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(267, 80);
            this.ControlBox = false;
            this.Controls.Add(this.MacroNameInputButton_Cancel);
            this.Controls.Add(this.MacroNameInputButton_OK);
            this.Controls.Add(this.MacroNameInputText);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MacroNameInputForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "                                Give a name";
            ((System.ComponentModel.ISupportInitialize)(this.MacroNameInputText)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MacroNameInputButton_OK)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MacroNameInputButton_Cancel)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public Telerik.WinControls.UI.RadTextBox MacroNameInputText;
        public Telerik.WinControls.UI.RadButton MacroNameInputButton_OK;
        public Telerik.WinControls.UI.RadButton MacroNameInputButton_Cancel;
    }
}