using System;
using System.Collections.Generic;
using System.Linq;
using LibClass.Commom;
using System.Windows.Forms;

namespace LibClass.Business
{
    public class CommunicationManager
    {
        // Constants.
        private const byte HEADER = 0xFF;
        private const byte FOOTER = 0xFF;

        /// <summary>
        /// Load the control with the list of objects.
        /// </summary>
        /// <param name="objGenericItens"></param>
        /// <param name="combo"></param>
        /// <param name="firstLineText"></param>
        public void LoadComboBox(List<GenericItem> objGenericItens, ComboBox combo, string firstLineText)
        {
            // Clear the control.
            combo.DataSource = null;
            combo.DisplayMember = "Description";
            combo.ValueMember = "Code";

            if (objGenericItens != null && objGenericItens.Count > 0)
            {
                // Add the first item.
                objGenericItens.Add(new GenericItem
                {
                    Description = firstLineText,
                    Code = 0
                });

                // Ordering.
                objGenericItens = objGenericItens
                    .OrderBy(obj => obj.Code)
                    .ToList();

                // Load the control with the list of objects.
                combo.DataSource = objGenericItens;
            }
        }

        /// <summary>
        /// Prepare the Identification command.
        /// </summary>
        /// <param name="identifier"></param>
        /// <returns></returns>
        public byte[] GetIdentificationCommand(short identifier)
        {
            byte[] identifierArray = BitConverter.GetBytes(identifier);

            if (identifierArray != null && identifierArray.Length > 1)
            {
                // Prepare the list with the information.
                List<byte> lstIdentificationCommand = new List<byte> { HEADER };
                lstIdentificationCommand.Add(identifierArray[1]);
                lstIdentificationCommand.Add(identifierArray[0]);
                lstIdentificationCommand.Add(FOOTER);

                // Return array.
                return lstIdentificationCommand.ToArray();
            }

            return null;
        }

        /// <summary>
        /// Prepare the Event command.
        /// </summary>
        /// <param name="codeMonitoredAccount"></param>
        /// <param name="codeEvent"></param>
        /// <param name="codePartition"></param>
        /// <param name="codeZone"></param>
        /// <param name="codeUser"></param>
        /// <returns></returns>
        public byte[] GetEventCommand(short codeMonitoredAccount, short codeEvent, byte codePartition, byte codeZone, byte codeUser)
        {
            byte[] codeMonitoredAccountArray = BitConverter.GetBytes(codeMonitoredAccount);
            byte[] codeEventArray = BitConverter.GetBytes(codeEvent);

            if (codeEventArray != null && codeEventArray.Length > 1 &&
                codeMonitoredAccountArray != null && codeMonitoredAccountArray.Length > 1)
            {
                // Prepare the list with the information.
                List<byte> lstEventCommand = new List<byte> { HEADER };
                lstEventCommand.Add(codeMonitoredAccountArray[1]);
                lstEventCommand.Add(codeMonitoredAccountArray[0]);
                lstEventCommand.Add(codeEventArray[1]);
                lstEventCommand.Add(codeEventArray[0]);
                lstEventCommand.Add(codePartition);
                lstEventCommand.Add(codeZone);
                lstEventCommand.Add(codeUser);

                #region Get checksum

                int count = 0;
                byte checksum;

                for (int i = 1; i < lstEventCommand.Count; i++)
                {
                    count += lstEventCommand[i];

                    if (count > HEADER)
                    {
                        count -= HEADER;
                    }
                }

                count -= 2;
                checksum = (byte)count;
                lstEventCommand.Add(checksum);

                #endregion

                // Return array.
                return lstEventCommand.ToArray();
            }

            return null;
        }

        /// <summary>
        /// Validate Identifier Code Received.
        /// </summary>
        /// <param name="listReceived"></param>
        /// <param name="lstConnectedCentral"></param>
        /// <returns></returns>
        public bool ValidateIdentifierCodeReceived(byte[] listReceived, List<GenericItem> lstConnectedCentral)
        {
            bool hasError = false;

            try
            {
                if (listReceived == null)
                {
                    hasError = true;
                }

                if (!listReceived[0].Equals(HEADER))
                {
                    hasError = true;
                }

                if (!listReceived[3].Equals(HEADER))
                {
                    hasError = true;
                }

                short code = BitConverter.ToInt16(new[]
                {
                    listReceived[2],
                    listReceived[1]
                }, 0);

                if (code < 0)
                {
                    hasError = true;
                }

                if (lstConnectedCentral.Count > 0)
                {
                    if (lstConnectedCentral.Any(obj => obj.Code == code))
                    {
                        hasError = true;
                    }
                }
            }
            catch
            {
                hasError = true;
            }

            return hasError;
        }

        /// <summary>
        /// Validate Event Received.
        /// </summary>
        /// <param name="listReceived"></param>
        /// <returns></returns>
        public bool ValidateEventReceived(byte[] listReceived)
        {
            bool hasError = false;

            try
            {
                if (listReceived == null)
                {
                    hasError = true;
                }

                #region Get checksum

                int count = 0;
                byte checksum;

                for (int i = 1; i < listReceived.Length - 1; i++)
                {
                    count += listReceived[i];

                    if (count > HEADER)
                    {
                        count -= HEADER;
                    }
                }

                count -= 2;
                checksum = (byte)count;

                #endregion

                if (!listReceived[0].Equals(HEADER))
                {
                    hasError = true;
                }

                if (!listReceived[listReceived.Length - 1].Equals(checksum))
                {
                    hasError = true;
                }

                int codeMonitoredAccount = BitConverter.ToInt32(new[]
                {
                    listReceived[2],
                    listReceived[1],
                    (byte)0,
                    (byte)0
                }, 0);

                if (codeMonitoredAccount <= 0)
                {
                    hasError = true;
                }

                short codeEvent = BitConverter.ToInt16(new[]
                {
                    listReceived[4],
                    listReceived[3]
                }, 0);

                if (codeEvent <= 0)
                {
                    hasError = true;
                }
            }
            catch
            {
                hasError = true;
            }

            return hasError;
        }
    }
}