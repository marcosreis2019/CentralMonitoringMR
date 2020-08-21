using System;
using System.IO;
using System.Data;
using System.Linq;
using System.Text;
using System.Net.Sockets;
using System.Windows.Forms;
using System.Collections.Generic;
using LibClass.Views;
using LibClass.Commom;
using LibClass.Commom.Enum;
using System.Threading;
using LibClass.Business;

namespace Client
{
    public partial class FormMain : Form
    {
        private const string CONFIRMATION_MESSAGE = "OK";

        string result = string.Empty;
        CommunicationManager objCommunicationManager;
        EventsSentView objEventsSentView;
        List<EventsSentView> lstEventsSentView = null;
        
        short codeMonitoredAccount;
        short codeEvent;
        byte codePartition;
        byte codeZone;
        byte codeUser;

        #region Variables for communication

        TcpClient objTcpClient;
        BinaryWriter objBinaryWriter;
        BinaryReader objBinaryReader;
        NetworkStream objNetworkStream;

        #endregion

        public FormMain()
        {
            InitializeComponent();
            lstEventsSentView = new List<EventsSentView>();
            objCommunicationManager = new CommunicationManager();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            
        }

        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Close Connections.
            CloseConnections();

            // Close Program.
            Environment.Exit(Environment.ExitCode);
        }

        private void TxtIdentifierCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '.' || (!char.IsNumber(e.KeyChar) && !(e.KeyChar == (char)Keys.Back) && !(e.KeyChar == (char)Keys.Delete)))
            {
                e.Handled = true;
            }
        }

        private void BtnConnect_Click(object sender, EventArgs e)
        {
            // Validations.
            result = ValidationsToConnect();
            if (!string.IsNullOrEmpty(result))
            {
                MessageBox.Show(result, "Monitoramento de Central MR", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtIdentifierCode.Focus();
                return;
            }

            // Start Connecting to the Server.
            Thread objThread = new Thread(new ThreadStart(StartConnectingServer));
            objThread.Start();
        }

        private void BtnSend_Click(object sender, EventArgs e)
        {
            #region Validations

            result = ValidationsToSend();
            if (!string.IsNullOrEmpty(result))
            {
                MessageBox.Show(result, "Monitoramento de Central MR", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            #endregion

            #region Send information about events

            try
            {
                // Send the Event command.
                objBinaryWriter.Write(objCommunicationManager.GetEventCommand(codeMonitoredAccount, codeEvent, codePartition, codeZone, codeUser));

                // Confirmation message.
                if (objBinaryReader.ReadString() != CONFIRMATION_MESSAGE)
                {
                    throw new Exception("Erro de comunicação!");
                }
            }
            catch (SocketException error)
            {
                var errorDescription = string.Format("Erro de comunicação!\nTente novamente.\nDescrição Erro: {0}\n{1}", error.Message, error.InnerException?.Message);
                MessageBox.Show(errorDescription, "Monitoramento de Central MR", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            catch (Exception error)
            {
                var errorDescription = string.Format("Não foi possível enviar a identificação da Central de Alarme.\nDescrição Erro: {0}\n{1}", error.Message, error.InnerException?.Message);
                MessageBox.Show(errorDescription, "Monitoramento de Central MR", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            #endregion

            // Load the object.
            objEventsSentView = new EventsSentView
            {
                Date = DateTime.Now,
                Account = EnumManager.LoadDescriptionMonitoredAccount(codeMonitoredAccount),
                Event = EnumManager.LoadDescriptionEvent(codeEvent),
                Partition = EnumManager.LoadDescriptionPartition(codePartition),
                Zone = EnumManager.LoadDescriptionZone(codeZone),
                User = EnumManager.LoadDescriptionUser(codeUser)
            };

            // Load Grid Events Sent.
            LoadGridEventsSent(objEventsSentView);
        }

        /// <summary>
        /// Start Connecting to the Server.
        /// </summary>
        public void StartConnectingServer()
        {
            try
            {
                objTcpClient = new TcpClient();

                // Connect to the server.
                objTcpClient.Connect(txtServerAddress.Text, (int)txtPort.Value);

                // Get stream.
                objNetworkStream = objTcpClient.GetStream();

                // Start reading and writing objects with the stream.
                objBinaryWriter = new BinaryWriter(objNetworkStream);
                objBinaryReader = new BinaryReader(objNetworkStream);

                #region Send the identification command

                short.TryParse(txtIdentifierCode.Text, out short identifier);

                if (identifier > 0)
                {
                    objBinaryWriter.Write(objCommunicationManager.GetIdentificationCommand(identifier));
                }

                #endregion

                if (objBinaryReader != null && objBinaryReader.ReadString() == CONFIRMATION_MESSAGE)
                {
                    // Activate the panel and load the controls.
                    ActivePanelEvents();

                    // Confirmation message.
                    MessageBox.Show("Conexão com a Central de Monitoramento realizada com sucesso!", "Monitoramento de Central MR", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    throw new Exception("Erro de conexão ou esse identificador já está sendo usado.");
                }
            }
            catch (Exception error)
            {
                // Error message.
                MessageBox.Show(error.Message, "Monitoramento de Central MR", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                // Close Connections.
                CloseConnections();
            }
        }

        /// <summary>
        /// Close Connections.
        /// </summary>
        private void CloseConnections()
        {
            if (objBinaryWriter != null)
            {
                objBinaryWriter.Close();
            }

            if (objBinaryReader != null)
            {
                objBinaryReader.Close();
            }

            if (objNetworkStream != null)
            {
                objNetworkStream.Close();
            }

            if (objTcpClient != null)
            {
                objTcpClient.Close();
            }
        }

        /// <summary>
        /// Validations To Connect.
        /// </summary>
        /// <returns></returns>
        private string ValidationsToConnect()
        {
            StringBuilder errors = new StringBuilder();

            if (string.IsNullOrWhiteSpace(txtIdentifierCode.Text))
            {
                errors.AppendLine("Necessário Informar o Código Identificador.");
            }

            if (string.IsNullOrWhiteSpace(txtServerAddress.Text))
            {
                errors.AppendLine("Necessário Informar o Endereço do Servidor.");
            }

            return errors.ToString();
        }

        /// <summary>
        /// Validations To Send.
        /// </summary>
        /// <returns></returns>
        private string ValidationsToSend()
        {
            StringBuilder errors = new StringBuilder();

            // Clears values.
            codeMonitoredAccount = 0;
            codeEvent = 0;
            codePartition = 0;
            codeZone = 0;
            codeUser = 0;

            if (comboMonitoredAccount.SelectedValue != null)
            {
                short.TryParse(comboMonitoredAccount.SelectedValue.ToString(), out codeMonitoredAccount);
            }

            if (comboEvent.SelectedValue != null)
            {
                short.TryParse(comboEvent.SelectedValue.ToString(), out codeEvent);
            }

            if (comboEventPartition.SelectedValue != null)
            {
                byte.TryParse(comboEventPartition.SelectedValue.ToString(), out codePartition);
            }

            if (comboSensorZone.SelectedValue != null)
            {
                byte.TryParse(comboSensorZone.SelectedValue.ToString(), out codeZone);
            }

            if (comboEventUser.SelectedValue != null)
            {
                byte.TryParse(comboEventUser.SelectedValue.ToString(), out codeUser);
            }

            if (codeMonitoredAccount.Equals(0))
            {
                errors.AppendLine("Escolha a Conta Monitorada.");
            }

            if (codeEvent.Equals(0))
            {
                errors.AppendLine("Escolha o Evento.");
            }

            if (codePartition.Equals(0))
            {
                errors.AppendLine("Escolha a Partição do Evento.");
            }

            if (codeZone.Equals(0))
            {
                errors.AppendLine("Escolha a Zona do Sensor.");
            }

            if (codeUser.Equals(0))
            {
                errors.AppendLine("Escolha o Usuário do Evento.");
            }

            return errors.ToString();
        }

        /// <summary>
        /// Activate the panel and load the controls.
        /// </summary>
        private void ActivePanelEvents()
        {
            // Enable Dashboards.
            groupEventsPanel.Enabled = true;
            groupEventsSent.Enabled = true;

            // Does not allow editing after connecting.
            txtIdentifierCode.ReadOnly = true;
            txtServerAddress.ReadOnly = true;
            txtPort.ReadOnly = true;
            btnConnect.Enabled = false;

            // Load Monitored Accounts.
            LoadMonitoredAccounts();

            //Load Events.
            LoadEvents();

            // Load Partitions.
            LoadPartitions();

            // Load Zones.
            LoadZones();

            // Load Users.
            LoadUsers();
        }

        /// <summary>
        /// Load Monitored Accounts.
        /// </summary>
        private void LoadMonitoredAccounts()
        {
            // Load the list of objects from the enum.
            var lstMonitoredAccounts =
                Enum.GetValues(typeof(MonitoredAccount))
                .Cast<MonitoredAccount>()
                .Select((obj) => new GenericItem
                {
                    Description = obj.Description(),
                    Code = (short)obj
                })
                .ToList();

            // Load the control with the list of objects.
            objCommunicationManager.LoadComboBox(lstMonitoredAccounts, comboMonitoredAccount, "Escolha...");
        }

        /// <summary>
        /// Load Events.
        /// </summary>
        private void LoadEvents()
        {
            // Load the list of objects from the enum.
            var lstEvents =
                Enum.GetValues(typeof(Event))
                .Cast<Event>()
                .Select((obj) => new GenericItem
                {
                    Description = obj.Description(),
                    Code = (short)obj
                })
                .ToList();

            // Load the control with the list of objects.
            objCommunicationManager.LoadComboBox(lstEvents, comboEvent, "Escolha...");
        }

        /// <summary>
        /// Load Partitions.
        /// </summary>
        private void LoadPartitions()
        {
            // Load the list of objects from the enum.
            var lstPartitions =
                Enum.GetValues(typeof(Partition))
                .Cast<Partition>()
                .Select((obj) => new GenericItem
                {
                    Description = obj.Description(),
                    Code = (short)obj
                })
                .ToList();

            // Load the control with the list of objects.
            objCommunicationManager.LoadComboBox(lstPartitions, comboEventPartition, "Escolha...");
        }

        /// <summary>
        /// Load Zones.
        /// </summary>
        private void LoadZones()
        {
            // Load the list of objects from the enum.
            var lstZones =
                Enum.GetValues(typeof(Zone))
                .Cast<Zone>()
                .Select((obj) => new GenericItem
                {
                    Description = obj.Description(),
                    Code = (short)obj
                })
                .ToList();

            // Load the control with the list of objects.
            objCommunicationManager.LoadComboBox(lstZones, comboSensorZone, "Escolha...");
        }

        /// <summary>
        /// Load Users.
        /// </summary>
        private void LoadUsers()
        {
            // Load the list of objects from the enum.
            var lstUsers = 
                Enum.GetValues(typeof(User))
                .Cast<User>()
                .Select((obj) => new GenericItem
                {
                    Description = obj.Description(),
                    Code = (short)obj
                })
                .ToList();

            // Load the control with the list of objects.
            objCommunicationManager.LoadComboBox(lstUsers, comboEventUser, "Escolha...");
        }

        /// <summary>
        /// Load Grid Events Sent.
        /// </summary>
        private void LoadGridEventsSent(EventsSentView objEventsSentView)
        {
            // Clear the control.
            gridEventsSent.DataSource = null;

            // Add new item.
            if (objEventsSentView != null)
            {
                lstEventsSentView.Add(objEventsSentView);
            }

            // If the list has records, load the grid.
            if (lstEventsSentView.Count > 0)
            {
                // Ordering.
                lstEventsSentView = lstEventsSentView
                    .OrderByDescending(obj => obj.Date)
                    .ToList();

                // Load the control with the list of objects.
                gridEventsSent.DataSource = lstEventsSentView;

                // Adjust columns.
                gridEventsSent.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

                // Column names.
                gridEventsSent.Columns[0].HeaderText = "Data";
                gridEventsSent.Columns[1].HeaderText = "Conta";
                gridEventsSent.Columns[2].HeaderText = "Evento";
                gridEventsSent.Columns[3].HeaderText = "Partição";
                gridEventsSent.Columns[4].HeaderText = "Zona";
                gridEventsSent.Columns[5].HeaderText = "Usuário";
            }
        }
    }
}