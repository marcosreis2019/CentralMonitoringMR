namespace Server
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
            this.components = new System.ComponentModel.Container();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panelSearchFilters = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.comboEvent = new System.Windows.Forms.ComboBox();
            this.comboConnectedCentral = new System.Windows.Forms.ComboBox();
            this.comboMonitoredAccount = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.gridConnectedClients = new System.Windows.Forms.DataGridView();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.gridEventsReceived = new System.Windows.Forms.DataGridView();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.panelSearchFilters.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridConnectedClients)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridEventsReceived)).BeginInit();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(280, 61);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(240, 17);
            this.label4.TabIndex = 6;
            this.label4.Text = "das Centrais de Alarme dos Clientes.";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(209, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(382, 17);
            this.label2.TabIndex = 5;
            this.label2.Text = "Este aplicativo permite conexões e recebimento de eventos";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(269, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(263, 24);
            this.label1.TabIndex = 4;
            this.label1.Text = "Servidor de Monitoramento";
            // 
            // panelSearchFilters
            // 
            this.panelSearchFilters.BackColor = System.Drawing.SystemColors.Info;
            this.panelSearchFilters.Controls.Add(this.label7);
            this.panelSearchFilters.Controls.Add(this.label3);
            this.panelSearchFilters.Controls.Add(this.label6);
            this.panelSearchFilters.Controls.Add(this.comboEvent);
            this.panelSearchFilters.Controls.Add(this.comboConnectedCentral);
            this.panelSearchFilters.Controls.Add(this.comboMonitoredAccount);
            this.panelSearchFilters.Enabled = false;
            this.panelSearchFilters.Location = new System.Drawing.Point(12, 95);
            this.panelSearchFilters.Name = "panelSearchFilters";
            this.panelSearchFilters.Size = new System.Drawing.Size(388, 125);
            this.panelSearchFilters.TabIndex = 7;
            this.panelSearchFilters.TabStop = false;
            this.panelSearchFilters.Text = "Filtros de Pesquisa";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(86, 91);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(47, 15);
            this.label7.TabIndex = 6;
            this.label7.Text = "Evento:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(22, 23);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(111, 15);
            this.label3.TabIndex = 7;
            this.label3.Text = "Central Conectada:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(25, 57);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(108, 15);
            this.label6.TabIndex = 7;
            this.label6.Text = "Conta Monitorada:";
            // 
            // comboEvent
            // 
            this.comboEvent.DisplayMember = "Description";
            this.comboEvent.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboEvent.FormattingEnabled = true;
            this.comboEvent.Location = new System.Drawing.Point(139, 88);
            this.comboEvent.Name = "comboEvent";
            this.comboEvent.Size = new System.Drawing.Size(232, 23);
            this.comboEvent.TabIndex = 9;
            this.comboEvent.ValueMember = "Code";
            this.comboEvent.SelectedValueChanged += new System.EventHandler(this.Combo_SelectedValueChanged);
            // 
            // comboConnectedCentral
            // 
            this.comboConnectedCentral.DisplayMember = "Description";
            this.comboConnectedCentral.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboConnectedCentral.FormattingEnabled = true;
            this.comboConnectedCentral.Location = new System.Drawing.Point(139, 20);
            this.comboConnectedCentral.Name = "comboConnectedCentral";
            this.comboConnectedCentral.Size = new System.Drawing.Size(232, 23);
            this.comboConnectedCentral.TabIndex = 8;
            this.comboConnectedCentral.ValueMember = "Code";
            this.comboConnectedCentral.SelectedValueChanged += new System.EventHandler(this.Combo_SelectedValueChanged);
            // 
            // comboMonitoredAccount
            // 
            this.comboMonitoredAccount.DisplayMember = "Description";
            this.comboMonitoredAccount.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboMonitoredAccount.FormattingEnabled = true;
            this.comboMonitoredAccount.Location = new System.Drawing.Point(139, 54);
            this.comboMonitoredAccount.Name = "comboMonitoredAccount";
            this.comboMonitoredAccount.Size = new System.Drawing.Size(232, 23);
            this.comboMonitoredAccount.TabIndex = 8;
            this.comboMonitoredAccount.ValueMember = "Code";
            this.comboMonitoredAccount.SelectedValueChanged += new System.EventHandler(this.Combo_SelectedValueChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.SystemColors.Info;
            this.groupBox2.Controls.Add(this.gridConnectedClients);
            this.groupBox2.Location = new System.Drawing.Point(406, 95);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(382, 125);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Centrais de Alarme Conectadas";
            // 
            // gridConnectedClients
            // 
            this.gridConnectedClients.AllowUserToAddRows = false;
            this.gridConnectedClients.AllowUserToDeleteRows = false;
            this.gridConnectedClients.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.gridConnectedClients.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridConnectedClients.Location = new System.Drawing.Point(6, 15);
            this.gridConnectedClients.Name = "gridConnectedClients";
            this.gridConnectedClients.ReadOnly = true;
            this.gridConnectedClients.RowHeadersVisible = false;
            this.gridConnectedClients.Size = new System.Drawing.Size(370, 104);
            this.gridConnectedClients.TabIndex = 11;
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.SystemColors.Info;
            this.groupBox3.Controls.Add(this.gridEventsReceived);
            this.groupBox3.Location = new System.Drawing.Point(12, 226);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(776, 282);
            this.groupBox3.TabIndex = 7;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Eventos Recebidos";
            // 
            // gridEventsReceived
            // 
            this.gridEventsReceived.AllowUserToAddRows = false;
            this.gridEventsReceived.AllowUserToDeleteRows = false;
            this.gridEventsReceived.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.gridEventsReceived.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridEventsReceived.Location = new System.Drawing.Point(6, 15);
            this.gridEventsReceived.Name = "gridEventsReceived";
            this.gridEventsReceived.ReadOnly = true;
            this.gridEventsReceived.RowHeadersVisible = false;
            this.gridEventsReceived.Size = new System.Drawing.Size(764, 261);
            this.gridEventsReceived.TabIndex = 11;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.Timer1_Tick);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 520);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.panelSearchFilters);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FormMain";
            this.Text = "Monitoramento de Central MR - Servidor de Monitoramento";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormMain_FormClosing);
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.panelSearchFilters.ResumeLayout(false);
            this.panelSearchFilters.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridConnectedClients)).EndInit();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridEventsReceived)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox panelSearchFilters;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox comboEvent;
        private System.Windows.Forms.ComboBox comboConnectedCentral;
        private System.Windows.Forms.ComboBox comboMonitoredAccount;
        private System.Windows.Forms.DataGridView gridConnectedClients;
        private System.Windows.Forms.DataGridView gridEventsReceived;
        private System.Windows.Forms.Timer timer1;
    }
}

