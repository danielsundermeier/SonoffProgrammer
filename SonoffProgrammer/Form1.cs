using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SonoffProgrammer
{
    public partial class Form1 : Form
    {
        private String receivedData = "";

        public Form1()
        {
            InitializeComponent();

            rtxtDataArea.VisibleChanged += (sender, e) =>
            {
                if (rtxtDataArea.Visible)
                {
                    rtxtDataArea.SelectionStart = rtxtDataArea.TextLength;
                    rtxtDataArea.ScrollToCaret();
                }
            };

            updatePorts();
            UpdateFiles();
        }

        private void Form1_FormClosing(object sender, EventArgs e)
        {
            try
            {
                disconnect();
            }
            catch(Exception exc)
            {

            }
        }

        private void UpdateFiles()
        {
            DirectoryInfo dinfo = new DirectoryInfo("./");
            FileInfo[] Files = dinfo.GetFiles("*.txt");
            foreach (FileInfo file in Files)
            {
                cmbFiles.Items.Add(file.Name);
            }
        }

        private void updatePorts()
        {
            String[] ports = SerialPort.GetPortNames();
            foreach (string port in ports)
            {
                cmbPortName.Items.Add(port);
            }
        }

        private void Connect()
        {
            if (cmbPortName.SelectedIndex != -1)
            {
                ComPort.PortName = cmbPortName.Text;
                ComPort.BaudRate = 115200;
                ComPort.ReadTimeout = 5000;
 
                try
                {
                    ComPort.Open();
                    txtSendData.Focus();
                }
                catch (Exception exc)
                {
                    MessageBox.Show(this, "Verbindung zum Comport konnte nicht hergestellt werden!" + exc.Message, "Comport nicht verfügbar", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
            }
            else
            {
                MessageBox.Show("Bitte alle COM Port Einstellungen setzen", "Serial Port Interface", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }

            if (ComPort.IsOpen)
            {
                btnConnect.Text = "Trennen";
                btnSend.Enabled = true;
                btnSendFile.Enabled = true; ;
                cmbPortName.Enabled = false;
            }
        }

        private void disconnect()
        {
            ComPort.Close();
            btnConnect.Text = "Verbinden";
            btnSend.Enabled = false;
            btnSendFile.Enabled = false;
            cmbPortName.Enabled = true;
        }

        private void sendData(string text)
        {

            // string recievedData = "";
            ComPort.Write(text.Trim() + System.Environment.NewLine);
            rtxtDataArea.AppendText("S: " + text + System.Environment.NewLine);
            /*
            rtxtDataArea.AppendText("Warte auf Antwort");
            int BytesToRead = ComPort.BytesToRead;
            int runden = 0;
            int rundenBisAbbruch = 10;
            while (BytesToRead == 0 & runden < rundenBisAbbruch)
            {
                System.Threading.Thread.Sleep(500);
                rtxtDataArea.AppendText(".");
                runden++;
                BytesToRead = ComPort.BytesToRead;
            }
            rtxtDataArea.AppendText(System.Environment.NewLine);
            rtxtDataArea.AppendText("Bytes to Read: " + BytesToRead + System.Environment.NewLine);
            recievedData = ComPort.ReadExisting();
            rtxtDataArea.AppendText("R: " + recievedData + System.Environment.NewLine);
            */
        }

        private void UpdateTextBox()
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Action(UpdateTextBox));
                return;
            }
            string data = this.receivedData;
            this.rtxtDataArea.ForeColor = Color.Green;
            this.rtxtDataArea.AppendText(data);
        }

        public void dataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            Debug.WriteLine("Daten empfangen");
            try
            {
                SerialPort sp = (SerialPort)sender;
                this.receivedData = sp.ReadExisting();
                this.UpdateTextBox();
            }
            catch (Exception exc)
            {
                MessageBox.Show(this, "Text konnte nicht empfangen werden! " + exc.Message, "Empfangen fehlgeschlagen", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            if (ComPort.IsOpen)
            {
                disconnect();
            }
            else
            {
                Connect();
            }
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            try
            {
                sendData(txtSendData.Text);
            }
            catch (Exception exc)
            {
                MessageBox.Show(this, "Text konnte nicht gesendet werden! " + exc.Message, "Senden fehlgeschlagen", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        void tb_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter)
            {
                return;
            }

            try
            {
                sendData(txtSendData.Text);
            }
            catch (Exception exc)
            {
                MessageBox.Show(this, "Text konnte nicht gesendet werden! " + exc.Message, "Senden fehlgeschlagen", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void btnSendFile_Click(object sender, EventArgs e)
        {
            int counter = 0;
            string line;
            string cmd = "Backlog ";

            System.IO.StreamReader file = new System.IO.StreamReader("./" + cmbFiles.Text);
            while ((line = file.ReadLine()) != null)
            {
                if (line.Length == 0 || line.Substring(0, 1) == ";")
                {
                    continue;
                }

                Debug.WriteLine(line);
                cmd += line + ";";
                counter++;
            }

            if (counter > 0)
            {
                sendData(cmd);
            }
                
            file.Close();
        }
    }
}
