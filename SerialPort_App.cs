using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.IO.Ports;
using System.Windows.Forms;
using Telerik.WinControls.Enumerations;
using Telerik.WinControls.UI;

namespace SerialPort_App_NET
{
    public class SerialPort_App : Form
    {
        private Telerik.WinControls.UI.RadLabel SelectPortLabel;
        private Telerik.WinControls.UI.RadLabel SelectBaudrateLabel;
        private Telerik.WinControls.UI.RadButton AdvancedSerialPortSettingsButton;
        private Telerik.WinControls.UI.RadDropDownList PortsDropDownList;
        private Telerik.WinControls.UI.RadDropDownList BaudratesDropDownList;
        private SerialPort serialPort;
        private IContainer components;
        private Label OpenPortErrorLabel;
        private RadToggleButton OpenPortToggleButton;
        private AdvancedSerialPortSettingsForm AdvancedSettingsForm;
        private MacroNameInputForm MacroNameInputForm;
        private RichTextBox ReceivedDataRichTextBox;
        private RadButton SendButton;
        public TextBox TransmitDataTextBox;
        private RadButton SaveButton;
        public RadDropDownList MacroCommandsDropDownList;
        private RadButton DeleteButton;
        private RadButton SavedCommandSendButton;
        private RadLabel TransmitDataLabel;
        private RadLabel TransmitDataLabel2;
        private RadLabel ReceivedDataLabel;
        private RichTextBox SentDataRichTextBox;
        private RadLabel SentDataLabel;
        private RadTextBox ParserDataTextBox;
        private Label ParseDataLabel;
        private RadCheckBox ParseDataCheckBox;
        public RadCheckBox EnableHEXCheckBoxSend;
        private RadButton ClearSentDataButton;
        private RadButton ClearReceivedDataButton;
        public string mainFormName;
        public string Macro;
        public string ReceivedDataString;
        public int ReceivedDataHEX;
        public string hexString;
        public ToolStripMenuItem menuItemCut = new ToolStripMenuItem("Cut");
        public ToolStripMenuItem menuItemCopy = new ToolStripMenuItem("Copy");
        public ToolStripMenuItem menuItemPaste = new ToolStripMenuItem("Paste");
        public ToolStripMenuItem menuItemHex = new ToolStripMenuItem("Enable HEX");
        public string fileName = @"MacroCommands.txt";
        private RadDropDownList NewLineDropDownList;
        private RadLabel NewLineLabel;
        string SelectedPort = null;
        public Int32[] baudrates = { 110, 300, 600, 1200, 2400, 4800, 9600, 14400, 19200, 38400, 57600, 115200, 128000, 256000 };
        public SerialPort_App()
        {
            InitializeComponent();
            mainFormName = this.Name;
            PortsDropDownList_Init();
            BaudratesDropDownList_Init();
            AdvancedSettingsForm = new AdvancedSerialPortSettingsForm();
            AdvancedSettingsForm.ParityDropDownList_Init();
            AdvancedSettingsForm.DataBitsDropDownList_Init();
            AdvancedSettingsForm.StopBitsDropDownList_Init();
            AdvancedSettingsForm.DtrDropDownList_Init();
            AdvancedSettingsForm.RtsDropDownList_Init();
            AdvancedSettingsForm.HandshakeDropDownList_Init();
            AdvancedSettingsForm.RXTimeoutTextBox_Init();
            AdvancedSettingsForm.TXTimeoutTextBox_Init();
            //NewLineDropDownList için başlangıç indexi "0": Parse input aktif iken yeni line oluşturmaz. 
            NewLineDropDownList.SelectedIndex = 0;
            //Başlangıçta TextFile'dan kaydedilmiş komutları çek
            LoadDataFromFile(fileName);

            //ReceivedDataBox için Hex ve String ContextMenuleri oluşturma
            ContextMenuStrip contextMenuStrip = new ContextMenuStrip();
            
            menuItemCut.Click += (sender, e) => ReceivedDataRichTextBox.Cut();
            contextMenuStrip.Items.Add(menuItemCut);
            
            menuItemCopy.Click += (sender, e) => ReceivedDataRichTextBox.Copy();
            contextMenuStrip.Items.Add(menuItemCopy);

            menuItemPaste.Click += (sender, e) => ReceivedDataRichTextBox.Paste();
            contextMenuStrip.Items.Add(menuItemPaste);

            menuItemHex.Click += (sender, e) =>
            {
                menuItemHex.Checked = !menuItemHex.Checked;
            };
            contextMenuStrip.Items.Add(menuItemHex);
            ReceivedDataRichTextBox.ContextMenuStrip = contextMenuStrip;
            Controls.Add(ReceivedDataRichTextBox);
            //////////////////////////////////////////////////////////////
        }

        //Kaydedilmiş komutlar TextFile'dan çekilir.
        private void LoadDataFromFile(string filePath)
        {
            try
            {
                if (!File.Exists(fileName))
                {
                    using (FileStream fs = File.Create(fileName))
                    {
                    }
                }
                string[] lines = File.ReadAllLines(filePath);

                foreach (string line in lines)
                {
                    string[] parts = line.Split(':');

                    if (parts.Length == 2)
                    {
                        string key = parts[0].Trim();
                        string value = parts[1].Trim();

                        MacroCommandsDropDownList.Items.Add(key + ": " + value);
                    }
                    else
                    {
                        MessageBox.Show("Invalid format in line: " + line);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error reading file: " + ex.Message);
            }
        }
        /////////////////////////////////////////////
        public void OpenSerialPort(SerialPort serialPort)
         {
            serialPort.PortName = SelectedPort;
            serialPort.BaudRate = Convert.ToInt32(SelectedBaudrate);
            serialPort.Parity = (Parity)Convert.ToSByte(AdvancedSettingsForm.DefaultParity);
            serialPort.DataBits = AdvancedSettingsForm.DefaultDataBits;
            serialPort.StopBits = AdvancedSettingsForm.DefaultStopBits;
            serialPort.ReadTimeout = AdvancedSettingsForm.DefaultReadTimeout;
            serialPort.WriteTimeout = AdvancedSettingsForm.DefaultWriteTimeout;
            serialPort.DtrEnable = AdvancedSettingsForm.DefaultDtrSetting;
            serialPort.RtsEnable = AdvancedSettingsForm.DefaultRtsSetting;
            serialPort.Handshake = (Handshake)AdvancedSettingsForm.DefaultHandshake;
            serialPort.Open();
        }
        private void PortsDropDownList_Init()
        {
            string[] ports = SerialPort.GetPortNames();
            Array.Sort(ports);
            foreach (string port in ports)
            {
                PortsDropDownList.Items.Add(port);
            }
        }
        public void BaudratesDropDownList_Init()
        {
            foreach (int baudrate in baudrates) 
            {
                BaudratesDropDownList.Items.Add(baudrate.ToString());
            }
        }
        public void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Telerik.WinControls.UI.RadListDataItem radListDataItem4 = new Telerik.WinControls.UI.RadListDataItem();
            Telerik.WinControls.UI.RadListDataItem radListDataItem5 = new Telerik.WinControls.UI.RadListDataItem();
            Telerik.WinControls.UI.RadListDataItem radListDataItem6 = new Telerik.WinControls.UI.RadListDataItem();
            this.SelectPortLabel = new Telerik.WinControls.UI.RadLabel();
            this.SelectBaudrateLabel = new Telerik.WinControls.UI.RadLabel();
            this.AdvancedSerialPortSettingsButton = new Telerik.WinControls.UI.RadButton();
            this.PortsDropDownList = new Telerik.WinControls.UI.RadDropDownList();
            this.BaudratesDropDownList = new Telerik.WinControls.UI.RadDropDownList();
            this.serialPort = new System.IO.Ports.SerialPort(this.components);
            this.OpenPortErrorLabel = new System.Windows.Forms.Label();
            this.OpenPortToggleButton = new Telerik.WinControls.UI.RadToggleButton();
            this.ReceivedDataRichTextBox = new System.Windows.Forms.RichTextBox();
            this.SendButton = new Telerik.WinControls.UI.RadButton();
            this.TransmitDataTextBox = new System.Windows.Forms.TextBox();
            this.SaveButton = new Telerik.WinControls.UI.RadButton();
            this.MacroCommandsDropDownList = new Telerik.WinControls.UI.RadDropDownList();
            this.DeleteButton = new Telerik.WinControls.UI.RadButton();
            this.SavedCommandSendButton = new Telerik.WinControls.UI.RadButton();
            this.TransmitDataLabel = new Telerik.WinControls.UI.RadLabel();
            this.TransmitDataLabel2 = new Telerik.WinControls.UI.RadLabel();
            this.ReceivedDataLabel = new Telerik.WinControls.UI.RadLabel();
            this.SentDataRichTextBox = new System.Windows.Forms.RichTextBox();
            this.SentDataLabel = new Telerik.WinControls.UI.RadLabel();
            this.ParserDataTextBox = new Telerik.WinControls.UI.RadTextBox();
            this.ParseDataLabel = new System.Windows.Forms.Label();
            this.ParseDataCheckBox = new Telerik.WinControls.UI.RadCheckBox();
            this.EnableHEXCheckBoxSend = new Telerik.WinControls.UI.RadCheckBox();
            this.ClearSentDataButton = new Telerik.WinControls.UI.RadButton();
            this.ClearReceivedDataButton = new Telerik.WinControls.UI.RadButton();
            this.NewLineDropDownList = new Telerik.WinControls.UI.RadDropDownList();
            this.NewLineLabel = new Telerik.WinControls.UI.RadLabel();
            ((System.ComponentModel.ISupportInitialize)(this.SelectPortLabel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SelectBaudrateLabel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AdvancedSerialPortSettingsButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PortsDropDownList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BaudratesDropDownList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.OpenPortToggleButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SendButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SaveButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MacroCommandsDropDownList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DeleteButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SavedCommandSendButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TransmitDataLabel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TransmitDataLabel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ReceivedDataLabel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SentDataLabel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ParserDataTextBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ParseDataCheckBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EnableHEXCheckBoxSend)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ClearSentDataButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ClearReceivedDataButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NewLineDropDownList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NewLineLabel)).BeginInit();
            this.SuspendLayout();
            // 
            // SelectPortLabel
            // 
            this.SelectPortLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.SelectPortLabel.Location = new System.Drawing.Point(20, 14);
            this.SelectPortLabel.Name = "SelectPortLabel";
            this.SelectPortLabel.Size = new System.Drawing.Size(68, 19);
            this.SelectPortLabel.TabIndex = 3;
            this.SelectPortLabel.Text = "Select Port:";
            // 
            // SelectBaudrateLabel
            // 
            this.SelectBaudrateLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.SelectBaudrateLabel.Location = new System.Drawing.Point(20, 54);
            this.SelectBaudrateLabel.Name = "SelectBaudrateLabel";
            this.SelectBaudrateLabel.Size = new System.Drawing.Size(94, 19);
            this.SelectBaudrateLabel.TabIndex = 4;
            this.SelectBaudrateLabel.Text = "Select Baudrate:";
            // 
            // AdvancedSerialPortSettingsButton
            // 
            this.AdvancedSerialPortSettingsButton.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.AdvancedSerialPortSettingsButton.Location = new System.Drawing.Point(20, 89);
            this.AdvancedSerialPortSettingsButton.Name = "AdvancedSerialPortSettingsButton";
            this.AdvancedSerialPortSettingsButton.Size = new System.Drawing.Size(104, 21);
            this.AdvancedSerialPortSettingsButton.TabIndex = 6;
            this.AdvancedSerialPortSettingsButton.Text = "Advanced Settings";
            this.AdvancedSerialPortSettingsButton.Click += new System.EventHandler(this.AdvancedSerialPortSettingsButton_Click);
            // 
            // PortsDropDownList
            // 
            this.PortsDropDownList.DropDownAnimationEnabled = true;
            this.PortsDropDownList.Location = new System.Drawing.Point(116, 12);
            this.PortsDropDownList.Name = "PortsDropDownList";
            this.PortsDropDownList.Size = new System.Drawing.Size(93, 20);
            this.PortsDropDownList.TabIndex = 7;
            this.PortsDropDownList.SelectedIndexChanged += new Telerik.WinControls.UI.Data.PositionChangedEventHandler(this.PortsDropDownList_SelectedIndexChanged);
            // 
            // BaudratesDropDownList
            // 
            this.BaudratesDropDownList.DropDownAnimationEnabled = true;
            this.BaudratesDropDownList.Location = new System.Drawing.Point(116, 53);
            this.BaudratesDropDownList.Name = "BaudratesDropDownList";
            this.BaudratesDropDownList.Size = new System.Drawing.Size(93, 20);
            this.BaudratesDropDownList.TabIndex = 8;
            this.BaudratesDropDownList.SelectedIndexChanged += new Telerik.WinControls.UI.Data.PositionChangedEventHandler(this.BaudratesDropDownList_SelectedIndexChanged);
            // 
            // serialPort
            // 
            this.serialPort.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.serialPort_DataReceived);
            // 
            // OpenPortErrorLabel
            // 
            this.OpenPortErrorLabel.AutoSize = true;
            this.OpenPortErrorLabel.ForeColor = System.Drawing.Color.Red;
            this.OpenPortErrorLabel.Location = new System.Drawing.Point(17, 120);
            this.OpenPortErrorLabel.Name = "OpenPortErrorLabel";
            this.OpenPortErrorLabel.Size = new System.Drawing.Size(0, 13);
            this.OpenPortErrorLabel.TabIndex = 9;
            // 
            // OpenPortToggleButton
            // 
            this.OpenPortToggleButton.Location = new System.Drawing.Point(225, 12);
            this.OpenPortToggleButton.Name = "OpenPortToggleButton";
            this.OpenPortToggleButton.Size = new System.Drawing.Size(85, 61);
            this.OpenPortToggleButton.TabIndex = 11;
            this.OpenPortToggleButton.Text = "Open Port";
            this.OpenPortToggleButton.Click += new System.EventHandler(this.OpenPortToggleButton_Click);
            // 
            // ReceivedDataRichTextBox
            // 
            this.ReceivedDataRichTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ReceivedDataRichTextBox.Location = new System.Drawing.Point(603, 157);
            this.ReceivedDataRichTextBox.Name = "ReceivedDataRichTextBox";
            this.ReceivedDataRichTextBox.ReadOnly = true;
            this.ReceivedDataRichTextBox.Size = new System.Drawing.Size(554, 360);
            this.ReceivedDataRichTextBox.TabIndex = 12;
            this.ReceivedDataRichTextBox.Text = "";
            // 
            // SendButton
            // 
            this.SendButton.Location = new System.Drawing.Point(1019, 27);
            this.SendButton.Name = "SendButton";
            this.SendButton.Size = new System.Drawing.Size(65, 25);
            this.SendButton.TabIndex = 13;
            this.SendButton.Text = "Send";
            this.SendButton.Click += new System.EventHandler(this.SendButton_Click);
            // 
            // TransmitDataTextBox
            // 
            this.TransmitDataTextBox.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.TransmitDataTextBox.Location = new System.Drawing.Point(478, 27);
            this.TransmitDataTextBox.Name = "TransmitDataTextBox";
            this.TransmitDataTextBox.Size = new System.Drawing.Size(480, 25);
            this.TransmitDataTextBox.TabIndex = 14;
            // 
            // SaveButton
            // 
            this.SaveButton.Location = new System.Drawing.Point(1092, 27);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(65, 25);
            this.SaveButton.TabIndex = 16;
            this.SaveButton.Text = "Save";
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // MacroCommandsDropDownList
            // 
            this.MacroCommandsDropDownList.DropDownAnimationEnabled = true;
            this.MacroCommandsDropDownList.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.MacroCommandsDropDownList.Location = new System.Drawing.Point(478, 80);
            this.MacroCommandsDropDownList.Name = "MacroCommandsDropDownList";
            this.MacroCommandsDropDownList.Size = new System.Drawing.Size(535, 23);
            this.MacroCommandsDropDownList.TabIndex = 17;
            // 
            // DeleteButton
            // 
            this.DeleteButton.Location = new System.Drawing.Point(1092, 79);
            this.DeleteButton.Name = "DeleteButton";
            this.DeleteButton.Size = new System.Drawing.Size(65, 25);
            this.DeleteButton.TabIndex = 18;
            this.DeleteButton.Text = "Delete";
            // 
            // SavedCommandSendButton
            // 
            this.SavedCommandSendButton.Location = new System.Drawing.Point(1019, 79);
            this.SavedCommandSendButton.Name = "SavedCommandSendButton";
            this.SavedCommandSendButton.Size = new System.Drawing.Size(65, 25);
            this.SavedCommandSendButton.TabIndex = 19;
            this.SavedCommandSendButton.Text = "Send";
            this.SavedCommandSendButton.Click += new System.EventHandler(this.SavedCommandSendButton_Click);
            // 
            // TransmitDataLabel
            // 
            this.TransmitDataLabel.Font = new System.Drawing.Font("Segoe UI", 10.25F);
            this.TransmitDataLabel.Location = new System.Drawing.Point(431, 28);
            this.TransmitDataLabel.Name = "TransmitDataLabel";
            this.TransmitDataLabel.Size = new System.Drawing.Size(41, 22);
            this.TransmitDataLabel.TabIndex = 20;
            this.TransmitDataLabel.Text = "Send:";
            // 
            // TransmitDataLabel2
            // 
            this.TransmitDataLabel2.Font = new System.Drawing.Font("Segoe UI", 10.25F);
            this.TransmitDataLabel2.Location = new System.Drawing.Point(431, 81);
            this.TransmitDataLabel2.Name = "TransmitDataLabel2";
            this.TransmitDataLabel2.Size = new System.Drawing.Size(41, 22);
            this.TransmitDataLabel2.TabIndex = 21;
            this.TransmitDataLabel2.Text = "Send:";
            // 
            // ReceivedDataLabel
            // 
            this.ReceivedDataLabel.Font = new System.Drawing.Font("Segoe UI", 10.25F);
            this.ReceivedDataLabel.Location = new System.Drawing.Point(830, 133);
            this.ReceivedDataLabel.Name = "ReceivedDataLabel";
            this.ReceivedDataLabel.Size = new System.Drawing.Size(95, 22);
            this.ReceivedDataLabel.TabIndex = 22;
            this.ReceivedDataLabel.Text = "Received Data";
            // 
            // SentDataRichTextBox
            // 
            this.SentDataRichTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.SentDataRichTextBox.DetectUrls = false;
            this.SentDataRichTextBox.Enabled = false;
            this.SentDataRichTextBox.ForeColor = System.Drawing.Color.Black;
            this.SentDataRichTextBox.Location = new System.Drawing.Point(20, 157);
            this.SentDataRichTextBox.Name = "SentDataRichTextBox";
            this.SentDataRichTextBox.Size = new System.Drawing.Size(554, 385);
            this.SentDataRichTextBox.TabIndex = 23;
            this.SentDataRichTextBox.Text = "";
            // 
            // SentDataLabel
            // 
            this.SentDataLabel.Font = new System.Drawing.Font("Segoe UI", 10.25F);
            this.SentDataLabel.Location = new System.Drawing.Point(263, 133);
            this.SentDataLabel.Name = "SentDataLabel";
            this.SentDataLabel.Size = new System.Drawing.Size(67, 22);
            this.SentDataLabel.TabIndex = 24;
            this.SentDataLabel.Text = "Sent Data";
            // 
            // ParserDataTextBox
            // 
            this.ParserDataTextBox.Location = new System.Drawing.Point(735, 524);
            this.ParserDataTextBox.Name = "ParserDataTextBox";
            this.ParserDataTextBox.Size = new System.Drawing.Size(322, 20);
            this.ParserDataTextBox.TabIndex = 25;
            // 
            // ParseDataLabel
            // 
            this.ParseDataLabel.AutoSize = true;
            this.ParseDataLabel.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.ParseDataLabel.Location = new System.Drawing.Point(614, 528);
            this.ParseDataLabel.Name = "ParseDataLabel";
            this.ParseDataLabel.Size = new System.Drawing.Size(114, 13);
            this.ParseDataLabel.TabIndex = 26;
            this.ParseDataLabel.Text = "Keyword for parsing:";
            // 
            // ParseDataCheckBox
            // 
            this.ParseDataCheckBox.Location = new System.Drawing.Point(1063, 525);
            this.ParseDataCheckBox.Name = "ParseDataCheckBox";
            this.ParseDataCheckBox.Size = new System.Drawing.Size(94, 18);
            this.ParseDataCheckBox.TabIndex = 27;
            this.ParseDataCheckBox.Text = "Enable/Disable";
            // 
            // EnableHEXCheckBoxSend
            // 
            this.EnableHEXCheckBoxSend.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.EnableHEXCheckBoxSend.Location = new System.Drawing.Point(970, 30);
            this.EnableHEXCheckBoxSend.Name = "EnableHEXCheckBoxSend";
            this.EnableHEXCheckBoxSend.Size = new System.Drawing.Size(43, 19);
            this.EnableHEXCheckBoxSend.TabIndex = 28;
            this.EnableHEXCheckBoxSend.Text = "HEX";
            // 
            // ClearSentDataButton
            // 
            this.ClearSentDataButton.Location = new System.Drawing.Point(240, 551);
            this.ClearSentDataButton.Name = "ClearSentDataButton";
            this.ClearSentDataButton.Size = new System.Drawing.Size(114, 28);
            this.ClearSentDataButton.TabIndex = 30;
            this.ClearSentDataButton.Text = "Clear Sent Data";
            this.ClearSentDataButton.Click += new System.EventHandler(this.ClearSentDataButton_Click);
            // 
            // ClearReceivedDataButton
            // 
            this.ClearReceivedDataButton.Location = new System.Drawing.Point(825, 551);
            this.ClearReceivedDataButton.Name = "ClearReceivedDataButton";
            this.ClearReceivedDataButton.Size = new System.Drawing.Size(108, 28);
            this.ClearReceivedDataButton.TabIndex = 31;
            this.ClearReceivedDataButton.Text = "Clear Received Data";
            this.ClearReceivedDataButton.Click += new System.EventHandler(this.ClearReceivedDataButton_Click);
            // 
            // NewLineDropDownList
            // 
            this.NewLineDropDownList.DropDownAnimationEnabled = true;
            this.NewLineDropDownList.Font = new System.Drawing.Font("Segoe UI", 7.25F);
            radListDataItem4.Font = new System.Drawing.Font("Segoe UI", 7.25F);
            radListDataItem4.Text = "Don\'t create new line";
            radListDataItem5.Font = new System.Drawing.Font("Segoe UI", 7.25F);
            radListDataItem5.Text = "New line after keyword";
            radListDataItem6.Font = new System.Drawing.Font("Segoe UI", 7.25F);
            radListDataItem6.Text = "New line before keyword";
            this.NewLineDropDownList.Items.Add(radListDataItem4);
            this.NewLineDropDownList.Items.Add(radListDataItem5);
            this.NewLineDropDownList.Items.Add(radListDataItem6);
            this.NewLineDropDownList.Location = new System.Drawing.Point(1036, 554);
            this.NewLineDropDownList.Name = "NewLineDropDownList";
            this.NewLineDropDownList.Size = new System.Drawing.Size(121, 18);
            this.NewLineDropDownList.TabIndex = 32;
            // 
            // NewLineLabel
            // 
            this.NewLineLabel.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.NewLineLabel.Location = new System.Drawing.Point(952, 555);
            this.NewLineLabel.Name = "NewLineLabel";
            this.NewLineLabel.Size = new System.Drawing.Size(85, 18);
            this.NewLineLabel.TabIndex = 33;
            this.NewLineLabel.Text = "Keyword found:";
            // 
            // SerialPort_App
            // 
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.ClientSize = new System.Drawing.Size(1169, 583);
            this.Controls.Add(this.NewLineLabel);
            this.Controls.Add(this.NewLineDropDownList);
            this.Controls.Add(this.ClearReceivedDataButton);
            this.Controls.Add(this.ClearSentDataButton);
            this.Controls.Add(this.EnableHEXCheckBoxSend);
            this.Controls.Add(this.ParseDataCheckBox);
            this.Controls.Add(this.ParseDataLabel);
            this.Controls.Add(this.ParserDataTextBox);
            this.Controls.Add(this.SentDataLabel);
            this.Controls.Add(this.SentDataRichTextBox);
            this.Controls.Add(this.ReceivedDataLabel);
            this.Controls.Add(this.TransmitDataLabel2);
            this.Controls.Add(this.TransmitDataLabel);
            this.Controls.Add(this.SavedCommandSendButton);
            this.Controls.Add(this.DeleteButton);
            this.Controls.Add(this.MacroCommandsDropDownList);
            this.Controls.Add(this.SaveButton);
            this.Controls.Add(this.TransmitDataTextBox);
            this.Controls.Add(this.SendButton);
            this.Controls.Add(this.ReceivedDataRichTextBox);
            this.Controls.Add(this.OpenPortToggleButton);
            this.Controls.Add(this.OpenPortErrorLabel);
            this.Controls.Add(this.BaudratesDropDownList);
            this.Controls.Add(this.PortsDropDownList);
            this.Controls.Add(this.AdvancedSerialPortSettingsButton);
            this.Controls.Add(this.SelectBaudrateLabel);
            this.Controls.Add(this.SelectPortLabel);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "SerialPort_App";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Serial Terminal";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SerialPort_App_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.SelectPortLabel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SelectBaudrateLabel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AdvancedSerialPortSettingsButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PortsDropDownList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BaudratesDropDownList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.OpenPortToggleButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SendButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SaveButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MacroCommandsDropDownList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DeleteButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SavedCommandSendButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TransmitDataLabel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TransmitDataLabel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ReceivedDataLabel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SentDataLabel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ParserDataTextBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ParseDataCheckBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EnableHEXCheckBoxSend)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ClearSentDataButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ClearReceivedDataButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NewLineDropDownList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NewLineLabel)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        
        private void PortsDropDownList_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            if(PortsDropDownList.SelectedItem != null)
            {
                SelectedPort = PortsDropDownList.SelectedItem.ToString();
            }
        }
        string SelectedBaudrate = null;
        private void BaudratesDropDownList_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            if (BaudratesDropDownList.SelectedItem != null)
            {
                SelectedBaudrate = BaudratesDropDownList.SelectedItem.ToString();
            }
        }

        private void AdvancedSerialPortSettingsButton_Click(object sender, EventArgs e)
        {
            AdvancedSettingsForm.ShowDialog();
        }
        private void OpenPortToggleButton_Click(object sender, EventArgs e)
        {
            if (SelectedPort != null && SelectedBaudrate != null)
            {
                if (serialPort.IsOpen)
                {
                    serialPort.Close();
                    AdvancedSerialPortSettingsButton.Enabled = true;
                    PortsDropDownList.Enabled = true;
                    BaudratesDropDownList.Enabled = true;
                    OpenPortToggleButton.ToggleState = ToggleState.On;
                    OpenPortErrorLabel.Text = "";
                    OpenPortToggleButton.Text = "Open Port";
                }
                else
                {
                    try
                    {
                        OpenSerialPort(serialPort);
                        AdvancedSerialPortSettingsButton.Enabled = false;
                        PortsDropDownList.Enabled = false;
                        BaudratesDropDownList.Enabled = false;
                        OpenPortToggleButton.ToggleState = ToggleState.Off;
                        OpenPortErrorLabel.Text = "";
                        OpenPortToggleButton.Text = "Close Port";

                    }
                    catch
                    {
                        OpenPortErrorLabel.Text = "Access denied for selected port.";
                        OpenPortToggleButton.ToggleState = ToggleState.On;
                        OpenPortToggleButton.Text = "Open Port";
                    }
                }
            }
            else if (SelectedPort == null)
            {
                OpenPortErrorLabel.Text = "Please Select a Port";
                OpenPortToggleButton.ToggleState = ToggleState.On;
            }
            else if (SelectedBaudrate == null)
            {
                OpenPortErrorLabel.Text = "Please Select a Baudrate";
                OpenPortToggleButton.ToggleState = ToggleState.On;
            }
            else if ((SelectedPort == null) && (SelectedBaudrate == null))
            {
                OpenPortErrorLabel.Text = "Please Select Port and Baudrate";
                OpenPortToggleButton.ToggleState = ToggleState.On;
            }
        }
        private void SerialPort_App_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (serialPort != null && serialPort.IsOpen)
            {
                serialPort.Close();
            }
        }

        private void SendButton_Click(object sender, EventArgs e)
        {
            if (serialPort.IsOpen)
            {
                if(TransmitDataTextBox.Text != null && TransmitDataTextBox.Text != "")
                {
                    SerialWrite_WriteLogs(SendButton);
                }
            }
            else
            {
                MessageBox.Show("Please open the port before sending a command.");
            }
        }

        private void SavedCommandSendButton_Click(object sender, EventArgs e)
        {
            if (serialPort.IsOpen)
            {
                if (MacroCommandsDropDownList.SelectedItem != null)
                {
                    SerialWrite_WriteLogs(SavedCommandSendButton);
                }
                else
                {
                    MessageBox.Show("Select a command.");
                }
            }
            else
            {
                MessageBox.Show("Please open the port before sending a command.");
            }
        }
        private void WriteDataLogRichTextBox(RichTextBox richTextBox,string data)
        {
            if(richTextBox == ReceivedDataRichTextBox)
            {
                richTextBox.AppendText(data);
                richTextBox.ScrollToCaret();
            }
            else
            {
                DateTime CurrentDateTime = DateTime.Now;
                richTextBox.SelectionColor = System.Drawing.Color.Red;
                richTextBox.AppendText("[" + DateTime.Now + "]: ");
                richTextBox.SelectionColor = System.Drawing.Color.Black;
                richTextBox.AppendText(data + "\n");
                richTextBox.ScrollToCaret();
            }
        }
        private void SerialWrite_WriteLogs(RadButton radButton)
        {
            if(radButton == SendButton)
            {
                if(EnableHEXCheckBoxSend.Checked)
                {
                    string result = TransmitDataTextBox.Text.Replace(" ", "").Replace("-", "");

                    if (result.Length % 2 != 0 || !System.Text.RegularExpressions.Regex.IsMatch(result, @"\A\b[0-9a-fA-F]+\b\Z"))
                    {
                        MessageBox.Show("Invalid hexadecimal input.\nYou can write bytes plain or you can leave a space or hyphen (-) for each byte.");
                    }
                    else
                    {
                        byte[] byteArray = new byte[result.Length / 2];
                        for (int i = 0; i < byteArray.Length; i++)
                        {
                            byteArray[i] = Convert.ToByte(result.Substring(i * 2, 2), 16);
                        }
                        serialPort.Write(byteArray, 0, byteArray.Length);
                        WriteDataLogRichTextBox(SentDataRichTextBox, TransmitDataTextBox.Text);
                    }
                }
                else
                {
                    serialPort.Write(TransmitDataTextBox.Text);
                    WriteDataLogRichTextBox(SentDataRichTextBox, TransmitDataTextBox.Text);
                }
            }
            else if(radButton == SavedCommandSendButton)
            {
                string DataString = MacroCommandsDropDownList.Text;
                int colonIndex = DataString.IndexOf(':');
                if (colonIndex != -1) // Check if the colon was found
                {
                    string commandType = DataString.Substring(colonIndex - 5, 5).Trim(); // Get the command type (e.g., "(HEX)")
                    string command = DataString.Substring(colonIndex + 1).Trim(); // Get the command

                    if (commandType.Equals("(HEX)", StringComparison.OrdinalIgnoreCase))
                    {
                        // Remove any spaces from the command
                        command = command.Replace(" ", "").Replace("-", "");

                        if (command.Length % 2 != 0 || !System.Text.RegularExpressions.Regex.IsMatch(command, @"\A\b[0-9a-fA-F]+\b\Z"))
                        {
                            MessageBox.Show("Invalid hexadecimal input.\nYou can write bytes plain or you can leave a space or hyphen (-) for each byte.");
                        }
                        else
                        {
                            byte[] byteArray = new byte[command.Length / 2];
                            for (int i = 0; i < byteArray.Length; i++)
                            {
                                byteArray[i] = Convert.ToByte(command.Substring(i * 2, 2), 16);
                            }
                            serialPort.Write(byteArray, 0, byteArray.Length);
                            WriteDataLogRichTextBox(SentDataRichTextBox, MacroCommandsDropDownList.Text);
                        }
                    }
                    else if (commandType.Equals("(STR)", StringComparison.OrdinalIgnoreCase))
                    {
                        // Send the string command over serial
                        serialPort.Write(command);
                        WriteDataLogRichTextBox(SentDataRichTextBox, MacroCommandsDropDownList.Text);
                    }
                    else
                    {
                        MessageBox.Show("Unsupported command type.");
                    }
                }
            }
        }

        // Verinin HEX Formatta olup olmadığı kontrol edilir.
        void CheckFormatHEX()
        {
            string data = TransmitDataTextBox.Text.Replace(" ", "").Replace("-", "");

            if (data.Length % 2 != 0 || !System.Text.RegularExpressions.Regex.IsMatch(data, @"\A\b[0-9a-fA-F]+\b\Z"))
            {
                MessageBox.Show("Invalid hexadecimal input.\nYou can write bytes plain or you can leave a space or hyphen (-) for each byte.");
            }
            else
            {
                byte[] byteArray = new byte[data.Length / 2];
                for (int i = 0; i < byteArray.Length; i++)
                {
                    byteArray[i] = Convert.ToByte(data.Substring(i * 2, 2), 16);
                }
                SaveCommandQuery();
            }
        }
        ////////////////////////////////////////////////////
        // Komut kaydetme için yanıt beklenir.
        void SaveCommandQuery()
        {
            DialogResult dialogResult = MessageBox.Show("Give a name for this command.", "", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                Macro = TransmitDataTextBox.Text;
                MacroNameInputForm = new MacroNameInputForm(this);
                if (MacroNameInputForm.ShowDialog(this) == DialogResult.OK)
                {
                    if (MacroNameInputForm.MacroNameInputText.Text != "")
                    {

                    }
                }
                else
                {
                }
                MacroNameInputForm.Dispose();
            }
            else if (dialogResult == DialogResult.No)
            {
            }
        }
        ////////////////////////////////////////////////////
        private void SaveButton_Click(object sender, EventArgs e)
        {
            if (TransmitDataTextBox.Text != null && TransmitDataTextBox.Text != "")
            {
                if (EnableHEXCheckBoxSend.Checked)
                {
                    CheckFormatHEX();
                }
                else
                {
                    SaveCommandQuery();
                }
            }
        }

        private void ClearSentDataButton_Click(object sender, EventArgs e)
        {
            SentDataRichTextBox.Clear();
        }

        private void ClearReceivedDataButton_Click(object sender, EventArgs e)
        {
            ReceivedDataRichTextBox.Clear();
        }
        private void ChangeKeywordColorInTextbox(string rawData, string keyword)
        {
            ReceivedDataRichTextBox.Invoke((MethodInvoker)delegate {
                int index = rawData.IndexOf(keyword);
                if (index != -1)
                {
                    ReceivedDataRichTextBox.SelectionColor = System.Drawing.Color.Black;
                    WriteDataLogRichTextBox(ReceivedDataRichTextBox, rawData.Substring(0, index));

                    ReceivedDataRichTextBox.SelectionColor = System.Drawing.Color.Red;
                    if (NewLineDropDownList.SelectedIndex == 1)
                    {
                        WriteDataLogRichTextBox(ReceivedDataRichTextBox, (keyword + "\n"));
                    }
                    else if(NewLineDropDownList.SelectedIndex == 2)
                    {
                        WriteDataLogRichTextBox(ReceivedDataRichTextBox, ("\n" + keyword));
                    }
                    else
                    {
                        WriteDataLogRichTextBox(ReceivedDataRichTextBox, keyword);
                    }
                    ReceivedDataRichTextBox.SelectionColor = System.Drawing.Color.Black;
                    WriteDataLogRichTextBox(ReceivedDataRichTextBox, rawData.Substring(index + keyword.Length));
                }
                else
                {
                    ReceivedDataRichTextBox.SelectionColor = System.Drawing.Color.Black;
                    WriteDataLogRichTextBox(ReceivedDataRichTextBox, rawData);
                }
            });
        }
        private void serialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            if (menuItemHex.Checked)
            {
                List<byte> bufferList = new List<byte>();

                while (serialPort.BytesToRead > 0)
                {
                    int data = serialPort.ReadByte();
                    bufferList.Add((byte)data);
                }

                byte[] buffer = bufferList.ToArray();
                hexString = BitConverter.ToString(buffer)+ "-";

                if (ParseDataCheckBox.Checked)
                {
                    if (ParserDataTextBox.Text != null && ParserDataTextBox.Text != "")
                    {
                        if (hexString.Contains(ParserDataTextBox.Text))
                        {
                            ChangeKeywordColorInTextbox(hexString,ParserDataTextBox.Text);
                        }
                        else
                        {
                            ReceivedDataRichTextBox.Invoke((MethodInvoker)(() => WriteDataLogRichTextBox(ReceivedDataRichTextBox, hexString)));
                        }
                    }
                    else
                    {
                        ReceivedDataRichTextBox.Invoke((MethodInvoker)(() => WriteDataLogRichTextBox(ReceivedDataRichTextBox, hexString)));
                    }
                }
                else
                {
                    ReceivedDataRichTextBox.Invoke((MethodInvoker)(() => WriteDataLogRichTextBox(ReceivedDataRichTextBox, hexString)));
                }
            }
            else
            {
                ReceivedDataString = serialPort.ReadExisting();
                if (ParseDataCheckBox.Checked)
                {
                    if (ParserDataTextBox.Text != null && ParserDataTextBox.Text != "")
                    {
                        if (ReceivedDataString.Contains(ParserDataTextBox.Text))
                        {
                            ChangeKeywordColorInTextbox(ReceivedDataString, ParserDataTextBox.Text);
                        }
                        else
                        {
                            ReceivedDataRichTextBox.Invoke((MethodInvoker)(() => WriteDataLogRichTextBox(ReceivedDataRichTextBox, ReceivedDataString)));
                        }
                    }
                    else
                    {
                        ReceivedDataRichTextBox.Invoke((MethodInvoker)(() => WriteDataLogRichTextBox(ReceivedDataRichTextBox, ReceivedDataString)));
                    }
                }
                else
                {
                    ReceivedDataRichTextBox.Invoke((MethodInvoker)(() => WriteDataLogRichTextBox(ReceivedDataRichTextBox, ReceivedDataString)));
                }
            }
        }
    }
}
