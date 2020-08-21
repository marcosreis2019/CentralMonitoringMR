using System;
using LibClass.Business;
using LibClass.Commom.Enum;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.Windows.Forms;
using System.Collections.Generic;
using LibClass.Commom;

namespace CentralMonitoringUnitTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void LoadMonitoredAccounts()
        {
            ComboBox combo = new ComboBox();
            CommunicationManager objCommunicationManager = new CommunicationManager();

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
            objCommunicationManager.LoadComboBox(lstMonitoredAccounts, combo, "Escolha...");
        }

        [TestMethod]
        public void LoadEvents()
        {
            ComboBox combo = new ComboBox();
            CommunicationManager objCommunicationManager = new CommunicationManager();

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
            objCommunicationManager.LoadComboBox(lstEvents, combo, "Escolha...");
        }

        [TestMethod]
        public void LoadPartitions()
        {
            ComboBox combo = new ComboBox();
            CommunicationManager objCommunicationManager = new CommunicationManager();

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
            objCommunicationManager.LoadComboBox(lstPartitions, combo, "Escolha...");
        }

        [TestMethod]
        public void LoadZones()
        {
            ComboBox combo = new ComboBox();
            CommunicationManager objCommunicationManager = new CommunicationManager();

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
            objCommunicationManager.LoadComboBox(lstZones, combo, "Escolha...");
        }

        [TestMethod]
        public void LoadUsers()
        {
            ComboBox combo = new ComboBox();
            CommunicationManager objCommunicationManager = new CommunicationManager();

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
            objCommunicationManager.LoadComboBox(lstUsers, combo, "Escolha...");
        }

        [TestMethod]
        public void LoadIdentificationCommand()
        {
            CommunicationManager objCommunicationManager = new CommunicationManager();

            short identifier = 10;
            byte[] identificationCommand = objCommunicationManager.GetIdentificationCommand(identifier);
        }

        [TestMethod]
        public void LoadEventCommand()
        {
            CommunicationManager objCommunicationManager = new CommunicationManager();

            short codeMonitoredAccount = 1000;
            short codeEvent = 1321;
            byte codePartition = 1;
            byte codeZone = 2;
            byte codeUser = 3;

            byte[] identificationCommand = objCommunicationManager.GetEventCommand(codeMonitoredAccount, codeEvent, codePartition, codeZone, codeUser);
        }

        [TestMethod]
        public void ValidateIdentifierCodeReceived()
        {
            CommunicationManager objCommunicationManager = new CommunicationManager();

            byte[] listCommand = new byte[4];
            listCommand[0] = 0xFF;
            listCommand[1] = 4;
            listCommand[2] = 87;
            listCommand[3] = 0xFF;

            List<GenericItem> lstConnectedCentral = new List<GenericItem>
            {
                new GenericItem
                {
                    Date = DateTime.Now,
                    Code = 10,
                    Description = "10"
                }
            };

            bool validate = objCommunicationManager.ValidateIdentifierCodeReceived(listCommand, lstConnectedCentral);
        }

        [TestMethod]
        public void ValidateEventReceived()
        {
            CommunicationManager objCommunicationManager = new CommunicationManager();

            short codeMonitoredAccount = 1000;
            short codeEvent = 1321;
            byte codePartition = 1;
            byte codeZone = 2;
            byte codeUser = 3;

            byte[] identificationCommand = objCommunicationManager.GetEventCommand(codeMonitoredAccount, codeEvent, codePartition, codeZone, codeUser);

            bool validate = objCommunicationManager.ValidateEventReceived(identificationCommand);
        }
    }
}