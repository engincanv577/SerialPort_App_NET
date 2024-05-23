using System;
using System.IO.Ports;
using System.Windows.Forms;

namespace SerialPort_App_NET
{
    public partial class AdvancedSerialPortSettingsForm : Form
    {
        public SByte DefaultParity = (SByte)Parity.None;
        public SByte DefaultDataBits = 8;
        public StopBits DefaultStopBits = StopBits.One;
        public UInt16 DefaultReadTimeout = 1000;
        public UInt16 DefaultWriteTimeout = 1000;
        public bool DefaultDtrSetting = false;
        public bool DefaultRtsSetting = false;
        public SByte DefaultHandshake = (SByte)Handshake.None;

        public AdvancedSerialPortSettingsForm()
        {
            InitializeComponent();
        }
       
        public void ParityDropDownList_Init()
        {
            foreach (Parity Parity in Enum.GetValues(typeof(Parity)))
            {
                ParityDropDownList.Items.Add(Parity.ToString());
            }
            ParityDropDownList.SelectedIndex = 0;
        }
        
        public void ParityDropDownList_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            if(ParityDropDownList.SelectedItem != null)
            {
                string SelectedParityName = ParityDropDownList.SelectedItem.ToString();
                DefaultParity = Convert.ToSByte((Parity)Enum.Parse(typeof(Parity), SelectedParityName));
            }
            else
            {
                ParityDropDownList.SelectedIndex = 0;
            }
        }

        public void DataBitsDropDownList_Init()
        {
            DataBitsDropDownList.Items.Add("7");
            DataBitsDropDownList.Items.Add("8");
            DataBitsDropDownList.SelectedIndex = 1;
        }

        public void DataBitsDropDownList_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            if(DataBitsDropDownList.SelectedItem != null)
            {
                DefaultDataBits = Convert.ToSByte(DataBitsDropDownList.SelectedItem.ToString());
            }
            else
            {
                DataBitsDropDownList.SelectedIndex = 1;
            }
        }

        public void StopBitsDropDownList_Init()
        {
            foreach (StopBits stopBit in Enum.GetValues(typeof(StopBits)))
            {
                StopBitsDropDownList.Items.Add(stopBit.ToString());
            }
            StopBitsDropDownList.SelectedIndex = 1;
        }
        public void StopBitsDropDownList_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            if(StopBitsDropDownList.SelectedItem != null)
            {
                string SelectedStopBitsName = StopBitsDropDownList.SelectedItem.ToString();
                DefaultStopBits = (StopBits)Enum.Parse(typeof(StopBits), SelectedStopBitsName);
            }
            else
            {
                StopBitsDropDownList.SelectedIndex = 1;
            }
        }

        public void DtrDropDownList_Init()
        {
            DtrDropDownList.Items.Add("Disable");
            DtrDropDownList.Items.Add("Enable");
            DtrDropDownList.SelectedIndex = 0;
        }

        public void DtrDropDownList_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            if(DtrDropDownList.SelectedItem != null)
            {
                if (DtrDropDownList.SelectedItem.ToString() == "Disable")
                {
                    DefaultDtrSetting = false;
                }
                else if (DtrDropDownList.SelectedItem.ToString() == "Enable")
                {
                    DefaultDtrSetting = true;
                }
                else
                {
                }
            }
            else
            {
                DtrDropDownList.SelectedIndex = 0;
            }
        }

        public void RtsDropDownList_Init()
        {
            RtsDropDownList.Items.Add("Disable");
            RtsDropDownList.Items.Add("Enable");
            RtsDropDownList.SelectedIndex = 0;        
        }
        public void RtsDropDownList_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            if(RtsDropDownList.SelectedItem != null)
            {
                if (RtsDropDownList.SelectedItem.ToString() == "Disable")
                {
                    DefaultRtsSetting = false;
                }
                else if (RtsDropDownList.SelectedItem.ToString() == "Enable")
                {
                    DefaultRtsSetting = true;
                }
                else
                {
                }
            }
            else
            {
                RtsDropDownList.SelectedIndex = 0;
            }
        }
        public void HandshakeDropDownList_Init()
        {
            foreach (Handshake handShake in Enum.GetValues(typeof(Handshake)))
            {
                HandshakeDropDownList.Items.Add(handShake.ToString());
            }
            HandshakeDropDownList.SelectedIndex = 0;
        }

        private void HandshakeDropDownList_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            if (HandshakeDropDownList.SelectedItem != null)
            {
                string SelectedHandshakeName = HandshakeDropDownList.SelectedItem.ToString();
                DefaultHandshake = Convert.ToSByte((Handshake)Enum.Parse(typeof(Handshake), SelectedHandshakeName));
            }
            else
            {
                HandshakeDropDownList.SelectedIndex = 0;
            }
        }

        public void RXTimeoutTextBox_Init()
        {
            DefaultReadTimeout = 1000;
            RXTimeoutTextBox.Text = "1000";
        }

        private void RXTimeoutTextBox_Leave(object sender, EventArgs e)
        {
            uint timeoutValue;
            if (uint.TryParse(RXTimeoutTextBox.Text, out timeoutValue) == true)
            {
                if (timeoutValue < 50 || timeoutValue > 5000)
                {
                    RXTimeoutTextBox_Init();
                }
                else
                {
                    DefaultReadTimeout = Convert.ToUInt16(timeoutValue);
                }
            }
            else
            {
                RXTimeoutTextBox_Init();
            }
        }
        public void TXTimeoutTextBox_Init()
        {
            DefaultWriteTimeout = 1000;
            TXTimeoutTextBox.Text = "1000";
        }

        private void TXTimeoutTextBox_Leave(object sender, EventArgs e)
        {
            uint timeoutValue;
            if (uint.TryParse(TXTimeoutTextBox.Text, out timeoutValue) == true)
            {
                if (timeoutValue < 50 || timeoutValue > 5000)
                {
                    TXTimeoutTextBox_Init();
                }
                else
                {
                    DefaultWriteTimeout = Convert.ToUInt16(timeoutValue);
                }
            }
            else
            {
                TXTimeoutTextBox_Init();
            }
        }
    }
}
