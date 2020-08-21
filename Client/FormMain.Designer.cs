namespace Client
{
    partial class FormMain
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtIdentifierCode = new System.Windows.Forms.TextBox();
            this.btnConnect = new System.Windows.Forms.Button();
            this.groupEventsPanel = new System.Windows.Forms.GroupBox();
            this.label10 = new System.Windows.Forms.Label();
            this.btnSend = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.comboEventUser = new System.Windows.Forms.ComboBox();
            this.comboSensorZone = new System.Windows.Forms.ComboBox();
            this.comboEventPartition = new System.Windows.Forms.ComboBox();
            this.comboEvent = new System.Windows.Forms.ComboBox();
            this.comboMonitoredAccount = new System.Windows.Forms.ComboBox();
            this.txtServerAddress = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtPort = new System.Windows.Forms.NumericUpDown();
            this.label11 = new System.Windows.Forms.Label();
            this.groupEventsSent = new System.Windows.Forms.GroupBox();
            this.gridEventsSent = new System.Windows.Forms.DataGridView();
            this.groupEventsPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtPort)).BeginInit();
            this.groupEventsSent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridEventsSent)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(350, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(279, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "Central de Alarme do Cliente";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(324, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(331, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Este aplicativo permite conexão e envio de eventos";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(34, 106);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(119, 15);
            this.label3.TabIndex = 2;
            this.label3.Text = "Código Identificador:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(367, 61);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(245, 17);
            this.label4.TabIndex = 3;
            this.label4.Text = "para a Central de Monitoramento MR.";
            // 
            // txtIdentifierCode
            // 
            this.txtIdentifierCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIdentifierCode.Location = new System.Drawing.Point(159, 103);
            this.txtIdentifierCode.MaxLength = 4;
            this.txtIdentifierCode.Name = "txtIdentifierCode";
            this.txtIdentifierCode.Size = new System.Drawing.Size(171, 21);
            this.txtIdentifierCode.TabIndex = 0;
            this.txtIdentifierCode.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtIdentifierCode_KeyPress);
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(484, 135);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(117, 23);
            this.btnConnect.TabIndex = 3;
            this.btnConnect.Text = "Conectar";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.BtnConnect_Click);
            // 
            // groupEventsPanel
            // 
            this.groupEventsPanel.BackColor = System.Drawing.SystemColors.Info;
            this.groupEventsPanel.Controls.Add(this.label10);
            this.groupEventsPanel.Controls.Add(this.btnSend);
            this.groupEventsPanel.Controls.Add(this.label9);
            this.groupEventsPanel.Controls.Add(this.label8);
            this.groupEventsPanel.Controls.Add(this.label7);
            this.groupEventsPanel.Controls.Add(this.label6);
            this.groupEventsPanel.Controls.Add(this.comboEventUser);
            this.groupEventsPanel.Controls.Add(this.comboSensorZone);
            this.groupEventsPanel.Controls.Add(this.comboEventPartition);
            this.groupEventsPanel.Controls.Add(this.comboEvent);
            this.groupEventsPanel.Controls.Add(this.comboMonitoredAccount);
            this.groupEventsPanel.Enabled = false;
            this.groupEventsPanel.Location = new System.Drawing.Point(12, 173);
            this.groupEventsPanel.Name = "groupEventsPanel";
            this.groupEventsPanel.Size = new System.Drawing.Size(381, 242);
            this.groupEventsPanel.TabIndex = 7;
            this.groupEventsPanel.TabStop = false;
            this.groupEventsPanel.Text = "Enviar Eventos Para a Central";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(18, 167);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(110, 15);
            this.label10.TabIndex = 2;
            this.label10.Text = "Usuário do Evento:";
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(249, 202);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(117, 23);
            this.btnSend.TabIndex = 9;
            this.btnSend.Text = "Enviar";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.BtnSend_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(31, 133);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(97, 15);
            this.label9.TabIndex = 2;
            this.label9.Text = "Zona do Sensor:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(16, 99);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(112, 15);
            this.label8.TabIndex = 2;
            this.label8.Text = "Partição do Evento:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(81, 65);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(47, 15);
            this.label7.TabIndex = 2;
            this.label7.Text = "Evento:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(20, 31);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(108, 15);
            this.label6.TabIndex = 2;
            this.label6.Text = "Conta Monitorada:";
            // 
            // comboEventUser
            // 
            this.comboEventUser.DisplayMember = "Description";
            this.comboEventUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboEventUser.FormattingEnabled = true;
            this.comboEventUser.Location = new System.Drawing.Point(134, 164);
            this.comboEventUser.Name = "comboEventUser";
            this.comboEventUser.Size = new System.Drawing.Size(232, 23);
            this.comboEventUser.TabIndex = 8;
            this.comboEventUser.ValueMember = "Code";
            // 
            // comboSensorZone
            // 
            this.comboSensorZone.DisplayMember = "Description";
            this.comboSensorZone.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboSensorZone.FormattingEnabled = true;
            this.comboSensorZone.Location = new System.Drawing.Point(134, 130);
            this.comboSensorZone.Name = "comboSensorZone";
            this.comboSensorZone.Size = new System.Drawing.Size(232, 23);
            this.comboSensorZone.TabIndex = 7;
            this.comboSensorZone.ValueMember = "Code";
            // 
            // comboEventPartition
            // 
            this.comboEventPartition.DisplayMember = "Description";
            this.comboEventPartition.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboEventPartition.FormattingEnabled = true;
            this.comboEventPartition.Location = new System.Drawing.Point(134, 96);
            this.comboEventPartition.Name = "comboEventPartition";
            this.comboEventPartition.Size = new System.Drawing.Size(232, 23);
            this.comboEventPartition.TabIndex = 6;
            this.comboEventPartition.ValueMember = "Code";
            // 
            // comboEvent
            // 
            this.comboEvent.DisplayMember = "Description";
            this.comboEvent.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboEvent.FormattingEnabled = true;
            this.comboEvent.Location = new System.Drawing.Point(134, 62);
            this.comboEvent.Name = "comboEvent";
            this.comboEvent.Size = new System.Drawing.Size(232, 23);
            this.comboEvent.TabIndex = 5;
            this.comboEvent.ValueMember = "Code";
            // 
            // comboMonitoredAccount
            // 
            this.comboMonitoredAccount.DisplayMember = "Description";
            this.comboMonitoredAccount.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboMonitoredAccount.FormattingEnabled = true;
            this.comboMonitoredAccount.Location = new System.Drawing.Point(134, 28);
            this.comboMonitoredAccount.Name = "comboMonitoredAccount";
            this.comboMonitoredAccount.Size = new System.Drawing.Size(232, 23);
            this.comboMonitoredAccount.TabIndex = 4;
            this.comboMonitoredAccount.ValueMember = "Code";
            // 
            // txtServerAddress
            // 
            this.txtServerAddress.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtServerAddress.Location = new System.Drawing.Point(159, 135);
            this.txtServerAddress.Name = "txtServerAddress";
            this.txtServerAddress.Size = new System.Drawing.Size(319, 21);
            this.txtServerAddress.TabIndex = 2;
            this.txtServerAddress.Text = "localhost";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(25, 138);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(128, 15);
            this.label5.TabIndex = 2;
            this.label5.Text = "Endereço do Servidor:";
            // 
            // txtPort
            // 
            this.txtPort.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPort.Location = new System.Drawing.Point(419, 104);
            this.txtPort.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.txtPort.Name = "txtPort";
            this.txtPort.Size = new System.Drawing.Size(59, 21);
            this.txtPort.TabIndex = 1;
            this.txtPort.Value = new decimal(new int[] {
            9000,
            0,
            0,
            0});
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(374, 106);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(39, 15);
            this.label11.TabIndex = 2;
            this.label11.Text = "Porta:";
            // 
            // groupEventsSent
            // 
            this.groupEventsSent.BackColor = System.Drawing.SystemColors.Info;
            this.groupEventsSent.Controls.Add(this.gridEventsSent);
            this.groupEventsSent.Enabled = false;
            this.groupEventsSent.Location = new System.Drawing.Point(399, 173);
            this.groupEventsSent.Name = "groupEventsSent";
            this.groupEventsSent.Size = new System.Drawing.Size(567, 242);
            this.groupEventsSent.TabIndex = 10;
            this.groupEventsSent.TabStop = false;
            this.groupEventsSent.Text = "Eventos Enviados";
            // 
            // gridEventsSent
            // 
            this.gridEventsSent.AllowUserToAddRows = false;
            this.gridEventsSent.AllowUserToDeleteRows = false;
            this.gridEventsSent.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.gridEventsSent.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridEventsSent.Location = new System.Drawing.Point(6, 15);
            this.gridEventsSent.Name = "gridEventsSent";
            this.gridEventsSent.ReadOnly = true;
            this.gridEventsSent.RowHeadersVisible = false;
            this.gridEventsSent.Size = new System.Drawing.Size(555, 221);
            this.gridEventsSent.TabIndex = 10;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(978, 428);
            this.Controls.Add(this.groupEventsSent);
            this.Controls.Add(this.txtPort);
            this.Controls.Add(this.txtServerAddress);
            this.Controls.Add(this.groupEventsPanel);
            this.Controls.Add(this.btnConnect);
            this.Controls.Add(this.txtIdentifierCode);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Monitoramento de Central MR - Central de Alarme do Cliente";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormMain_FormClosing);
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.groupEventsPanel.ResumeLayout(false);
            this.groupEventsPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtPort)).EndInit();
            this.groupEventsSent.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridEventsSent)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtIdentifierCode;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.GroupBox groupEventsPanel;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox comboEventUser;
        private System.Windows.Forms.ComboBox comboSensorZone;
        private System.Windows.Forms.ComboBox comboEventPartition;
        private System.Windows.Forms.ComboBox comboEvent;
        private System.Windows.Forms.ComboBox comboMonitoredAccount;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.TextBox txtServerAddress;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown txtPort;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.GroupBox groupEventsSent;
        private System.Windows.Forms.DataGridView gridEventsSent;
    }
}

