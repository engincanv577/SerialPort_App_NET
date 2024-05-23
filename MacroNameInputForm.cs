using System;
using System.IO;
using System.Windows.Forms;

namespace SerialPort_App_NET
{
    public partial class MacroNameInputForm : Form
    {
        private SerialPort_App mainForm;
        public string MacroName = null;
        public MacroNameInputForm(SerialPort_App mainForm)
        {
            InitializeComponent();
            this.mainForm = mainForm;
        }
        void WriteTextFile(string data)
        {
            try
            {
                File.AppendAllText(mainForm.fileName, data);
            }
            catch
            {

            }
        }

        // Komut kaydetme fonksiyonu
        void SaveCommand(string macroName)
        {
            macroName = MacroNameInputText.Text;
            if (mainForm.EnableHEXCheckBoxSend.Checked)
            {
                WriteTextFile("[" + macroName + "](HEX): ");
                mainForm.MacroCommandsDropDownList.Items.Add("[" + macroName + "](HEX): " + mainForm.Macro);
            }
            else
            {
                WriteTextFile("[" + macroName + "](STR): ");
                mainForm.MacroCommandsDropDownList.Items.Add("[" + macroName + "](STR): " + mainForm.Macro);
            }
            WriteTextFile(mainForm.Macro + "\n");
            MessageBox.Show("Success");
            Close();
        }
        //////////////////////////////
        void AreYouSureSaveCommand()
        {
            if (MacroNameInputText.Text != "")
            {
                DialogResult dialogResult = MessageBox.Show("Are you sure?", "", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {

                    try
                    {
                        SaveCommand(MacroName);
                    }
                    catch
                    {

                    }

                }
            }
            else
            {
                MessageBox.Show("Macro name can not be empty.");
            }
        }
        private void MacroNameInputButton_OK_Click(object sender, EventArgs e)
        {
            AreYouSureSaveCommand();
        }

        private void MacroNameInputButton_Cancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void MacroNameInputText_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                AreYouSureSaveCommand();
            }
        }
    }
}
