namespace SonoffProgrammer
{
    partial class Form1
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.cmbPortName = new System.Windows.Forms.ComboBox();
            this.rtxtDataArea = new System.Windows.Forms.RichTextBox();
            this.txtSendData = new System.Windows.Forms.TextBox();
            this.btnSend = new System.Windows.Forms.Button();
            this.btnConnect = new System.Windows.Forms.Button();
            this.ComPort = new System.IO.Ports.SerialPort(this.components);
            this.cmbFiles = new System.Windows.Forms.ComboBox();
            this.btnSendFile = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cmbPortName
            // 
            this.cmbPortName.FormattingEnabled = true;
            this.cmbPortName.Location = new System.Drawing.Point(12, 12);
            this.cmbPortName.Name = "cmbPortName";
            this.cmbPortName.Size = new System.Drawing.Size(166, 21);
            this.cmbPortName.TabIndex = 2;
            this.cmbPortName.Text = "Port auswählen";
            // 
            // rtxtDataArea
            // 
            this.rtxtDataArea.Location = new System.Drawing.Point(12, 44);
            this.rtxtDataArea.Name = "rtxtDataArea";
            this.rtxtDataArea.Size = new System.Drawing.Size(820, 399);
            this.rtxtDataArea.TabIndex = 7;
            this.rtxtDataArea.Text = "";
            // 
            // txtSendData
            // 
            this.txtSendData.Location = new System.Drawing.Point(12, 454);
            this.txtSendData.Name = "txtSendData";
            this.txtSendData.Size = new System.Drawing.Size(773, 20);
            this.txtSendData.TabIndex = 8;
            this.txtSendData.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tb_KeyDown);
            // 
            // btnSend
            // 
            this.btnSend.Enabled = false;
            this.btnSend.Location = new System.Drawing.Point(791, 454);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(41, 20);
            this.btnSend.TabIndex = 9;
            this.btnSend.Text = "->";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(184, 10);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(75, 23);
            this.btnConnect.TabIndex = 10;
            this.btnConnect.Text = "Verbinden";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // ComPort
            // 
            this.ComPort.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.dataReceived);
            // 
            // cmbFiles
            // 
            this.cmbFiles.FormattingEnabled = true;
            this.cmbFiles.Location = new System.Drawing.Point(612, 12);
            this.cmbFiles.Name = "cmbFiles";
            this.cmbFiles.Size = new System.Drawing.Size(173, 21);
            this.cmbFiles.TabIndex = 11;
            this.cmbFiles.Text = "Config File";
            // 
            // btnSendFile
            // 
            this.btnSendFile.Enabled = false;
            this.btnSendFile.Location = new System.Drawing.Point(791, 12);
            this.btnSendFile.Name = "btnSendFile";
            this.btnSendFile.Size = new System.Drawing.Size(41, 21);
            this.btnSendFile.TabIndex = 12;
            this.btnSendFile.Text = "->";
            this.btnSendFile.UseVisualStyleBackColor = true;
            this.btnSendFile.Click += new System.EventHandler(this.btnSendFile_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(844, 486);
            this.Controls.Add(this.btnSendFile);
            this.Controls.Add(this.cmbFiles);
            this.Controls.Add(this.btnConnect);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.txtSendData);
            this.Controls.Add(this.rtxtDataArea);
            this.Controls.Add(this.cmbPortName);
            this.Name = "Form1";
            this.Text = "Sonoff Programmer";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbPortName;
        private System.Windows.Forms.RichTextBox rtxtDataArea;
        private System.Windows.Forms.TextBox txtSendData;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.Button btnConnect;
        private System.IO.Ports.SerialPort ComPort;
        private System.Windows.Forms.ComboBox cmbFiles;
        private System.Windows.Forms.Button btnSendFile;
    }
}

