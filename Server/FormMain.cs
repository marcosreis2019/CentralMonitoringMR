using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using System.Threading;
using System.Net.Sockets;
using System.IO;
using System.Net;
using LibClass.Views;
using LibClass.Commom;
using LibClass.Commom.Enum;
using LibClass.Business;

namespace Server
{
    public partial class FormMain : Form
    {
        // Constants
        private const string ERROR_MESSAGE = "ERROR";
        private const string CONFIRMATION_MESSAGE = "OK";
        private const byte HEADER = 0xFF;

        // Screen refresh control.
        bool hasChange = false;
        bool hasChangeEvent = false;

        List<GenericItem> lstConnectedCentral = null;
        List<EventsReceivedView> lstEventsReceivedView = null;
        EventsReceivedView objEventsReceivedView;
        GenericItem objConnectedCentral;
        CommunicationManager objCommunicationManager;

        #region Variables for communication

        Socket objSocket;
        TcpListener objTcpListener;

        #endregion

        public FormMain()
        {
            InitializeComponent();
            lstConnectedCentral = new List<GenericItem>();
            lstEventsReceivedView = new List<EventsReceivedView>();
            objCommunicationManager = new CommunicationManager();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            // Start the Server to receive connections.
            Thread objThread = new Thread(new ThreadStart(StartServer));
            objThread.Start();
        }

        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Stop the Server to receive connections.
            StopServer();

            // Close the program.
            Environment.Exit(Environment.ExitCode);
        }

        private void Combo_SelectedValueChanged(object sender, EventArgs e)
        {
            // Load Grid Events Received
            LoadGridEventsReceived();
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            if (hasChange)
            {
                // Activate the panel and load the controls.
                ActivePanelEvents();

                // Load Grid Connected Central -Add.
                LoadGridConnectedCentral();

                // Load Connected Central.
                LoadConnectedCentral();

                // To update the screen.
                hasChange = false;
            }

            if (hasChangeEvent)
            {
                // Load Grid Events Received
                LoadGridEventsReceived();

                // To update the screen.
                hasChangeEvent = false;
            }
        }

        /// <summary>
        /// Start the Server to receive connections.
        /// </summary>
        private void StartServer()
        {
            int port = 9000;

            try
            {
                objTcpListener = new TcpListener(IPAddress.Any, port);

                // Statr the server.
                objTcpListener.Start(int.MaxValue);

                while (true)
                {
                    // Accepts a pending connection request.
                    objSocket = objTcpListener.AcceptSocket();

                    // Queuing processes to receive parallel connections.
                    ThreadPool.QueueUserWorkItem(ThreadQueueItem, objSocket);
                }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message, "Monitoramento de Central MR", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        /// <summary>
        /// Stop the Server to receive connections.
        /// </summary>
        private void StopServer()
        {
            if (objTcpListener != null)
            {
                objTcpListener.Stop();
            }

            if (objSocket != null)
            {
                objSocket.Close();
            }
        }

        /// <summary>
        /// Queuing processes to receive parallel connections.
        /// </summary>
        /// <param name="socket"></param>
        public void ThreadQueueItem(object socket)
        {
            Socket objSocket = (Socket)socket;
            NetworkStream objNetworkStream = new NetworkStream(objSocket);
            BinaryWriter objBinaryWriter = new BinaryWriter(objNetworkStream);
            BinaryReader objBinaryReader = new BinaryReader(objNetworkStream);

            // Command reading.
            byte[] listCommand = objBinaryReader.ReadBytes(4);

            // Validate Identifier Code.
            if (objCommunicationManager.ValidateIdentifierCodeReceived(listCommand, lstConnectedCentral))
            {
                // Error message.
                objBinaryWriter.Write(ERROR_MESSAGE);

                #region Close Connections

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

                if (objSocket != null)
                {
                    objSocket.Close();
                }

                #endregion
                
                return;
            }

            // Get panel code
            short panel = BitConverter.ToInt16(new[]
            {
                listCommand[2],
                listCommand[1]
            }, 0);

            #region Add a new switch to the list

            objConnectedCentral = new GenericItem
            {
                Date = DateTime.Now,
                Code = panel,
                Description = panel.ToString(),
            };

            lstConnectedCentral.Add(objConnectedCentral);

            #endregion

            // To update the screen.
            hasChange = true;

            // Confirmation message.
            objBinaryWriter.Write(CONFIRMATION_MESSAGE);

            do
            {
                try
                {
                    // Command reading.
                    byte[] listReceived = objBinaryReader.ReadBytes(9);

                    // Validate Event Received.
                    if (objCommunicationManager.ValidateEventReceived(listReceived))
                    {
                        // Error message.
                        objBinaryWriter.Write(ERROR_MESSAGE);
                        continue;
                    }

                    // Get event code
                    short codeEvent = BitConverter.ToInt16(new[]
                    {
                        listReceived[4],
                        listReceived[3]
                    }, 0);

                    // Get account code
                    int account = BitConverter.ToInt32(new[]
                    {
                        listReceived[2],
                        listReceived[1],
                        (byte)0,
                        (byte)0
                    }, 0);

                    #region Add a new event to the list

                    objEventsReceivedView = new EventsReceivedView
                    {
                        Date = DateTime.Now,
                        Panel = panel,
                        Account = account,
                        Event = codeEvent,
                        Description = EnumManager.LoadDescriptionEvent(codeEvent),
                        Partition = listReceived[5],
                        Zone = listReceived[6],
                        User = listReceived[7]
                    };

                    lstEventsReceivedView.Add(objEventsReceivedView);

                    #endregion

                    // Confirmation message.
                    objBinaryWriter.Write(CONFIRMATION_MESSAGE);

                    // To update the screen.
                    hasChangeEvent = true;
                }
                catch (Exception)
                {
                    break;
                }

            } while (objSocket.Connected);

            #region Close Connections

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

            if (objSocket != null)
            {
                objSocket.Close();
            }

            #endregion

            // Remove the disconnected panel.
            lstConnectedCentral.RemoveAll(obj => obj.Code.Equals(panel));

            // Remove events from the disconnected panel.
            lstEventsReceivedView.RemoveAll(obj => obj.Panel.Equals(panel));

            // To update the screen.
            hasChange = true;
            hasChangeEvent = true;
        }

        /// <summary>
        /// Load Connected Central.
        /// </summary>
        private void LoadConnectedCentral()
        {
            // Create a new list so as not to alter the original.
            var lstGenericItemToDisplayTemp = new GenericItem[lstConnectedCentral.Count];
            lstConnectedCentral.CopyTo(lstGenericItemToDisplayTemp);
            List<GenericItem> lstGenericItemToDisplay = lstGenericItemToDisplayTemp.ToList();

            // Load the control with the list of objects.
            objCommunicationManager.LoadComboBox(lstGenericItemToDisplay, comboConnectedCentral, "Todas...");
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
            objCommunicationManager.LoadComboBox(lstMonitoredAccounts, comboMonitoredAccount, "Todas...");
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
            objCommunicationManager.LoadComboBox(lstEvents, comboEvent, "Todos...");
        }

        /// <summary>
        /// Load Grid Events Received
        /// </summary>
        private void LoadGridEventsReceived()
        {
            // Clear the grid.
            gridEventsReceived.DataSource = null;

            if (lstEventsReceivedView.Count > 0)
            {
                // Create a new list so as not to alter the original.
                var lstEventsReceivedViewToDisplayTemp = new EventsReceivedView[lstEventsReceivedView.Count];
                lstEventsReceivedView.CopyTo(lstEventsReceivedViewToDisplayTemp);
                IEnumerable<EventsReceivedView> lstEventsReceivedViewToDisplay = lstEventsReceivedViewToDisplayTemp.ToList();

                // If the list has records, load the grid.
                if (lstEventsReceivedViewToDisplay.Count() > 0)
                {
                    #region Filter by Connected Central

                    short codeConnectedCentral = 0;

                    if (comboConnectedCentral.SelectedValue != null)
                    {
                        short.TryParse(comboConnectedCentral.SelectedValue.ToString(), out codeConnectedCentral);
                    }

                    if (codeConnectedCentral > 0)
                    {
                        lstEventsReceivedViewToDisplay = lstEventsReceivedViewToDisplay
                            .Where(obj => obj.Panel.Equals(codeConnectedCentral));
                    }

                    #endregion

                    #region Filter by Monitored Account

                    short codeMonitoredAccount = 0;

                    if (comboMonitoredAccount.SelectedValue != null)
                    {
                        short.TryParse(comboMonitoredAccount.SelectedValue.ToString(), out codeMonitoredAccount);
                    }

                    if (codeMonitoredAccount > 0)
                    {
                        lstEventsReceivedViewToDisplay = lstEventsReceivedViewToDisplay
                            .Where(obj => obj.Account.Equals(codeMonitoredAccount));
                    }

                    #endregion

                    #region Filter by Event

                    short codeEvent = 0;

                    if (comboEvent.SelectedValue != null)
                    {
                        short.TryParse(comboEvent.SelectedValue.ToString(), out codeEvent);
                    }

                    if (codeEvent > 0)
                    {
                        lstEventsReceivedViewToDisplay = lstEventsReceivedViewToDisplay
                            .Where(obj => obj.Event.Equals(codeEvent));
                    }

                    #endregion

                    if (lstEventsReceivedViewToDisplay.Count() > 0)
                    {
                        // Ordering.
                        lstEventsReceivedViewToDisplay = lstEventsReceivedViewToDisplay
                            .OrderByDescending(obj => obj.Date);

                        // Load the grid with the list.
                        gridEventsReceived.DataSource = lstEventsReceivedViewToDisplay.ToList();

                        // Adjust columns.
                        gridEventsReceived.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

                        // Column names.
                        gridEventsReceived.Columns[0].HeaderText = "Data";
                        gridEventsReceived.Columns[1].HeaderText = "Painel";
                        gridEventsReceived.Columns[2].HeaderText = "Conta";
                        gridEventsReceived.Columns[3].HeaderText = "Evento";
                        gridEventsReceived.Columns[4].HeaderText = "Descrição";
                        gridEventsReceived.Columns[5].HeaderText = "Partição";
                        gridEventsReceived.Columns[6].HeaderText = "Zona";
                        gridEventsReceived.Columns[7].HeaderText = "Usuário";
                    }
                }
            }
        }

        /// <summary>
        /// Load Grid Connected Central - Add.
        /// </summary>
        private void LoadGridConnectedCentral()
        {
            // Clear the grid.
            gridConnectedClients.DataSource = null;

            // If the list has records, load the grid.
            if (lstConnectedCentral.Count > 0)
            {
                // Ordering.
                lstConnectedCentral = lstConnectedCentral
                    .OrderByDescending(obj => obj.Date)
                    .ToList();

                // Load the grid with the list.
                gridConnectedClients.DataSource = lstConnectedCentral;

                // Adjust columns.
                gridConnectedClients.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                gridConnectedClients.Columns[2].Visible = false;

                // Column names.
                gridConnectedClients.Columns[0].HeaderText = "Data";
                gridConnectedClients.Columns[1].HeaderText = "Painel";
            }
        }

        /// <summary>
        /// Activate the panel and load the controls.
        /// </summary>
        private void ActivePanelEvents()
        {
            if (!panelSearchFilters.Enabled)
            {
                // Activate the panel.
                panelSearchFilters.Enabled = true;

                // Load Monitored Accounts.
                LoadMonitoredAccounts();

                //Load Events.
                LoadEvents();
            }
        }
    }
}