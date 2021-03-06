using System;
using Twilio;
using Twilio.Rest.Api.V2010.Account;

namespace TwilloSendLibrary
{
    //In future it can be post to different platforms, just add it
    public enum Platforms { SMS, whatsapp }

    //Also, in future can be add some more managers to send or post something
    public enum MessagingManager { TwilioClient }

    public class TwilloLibrary
    {
        /// <summary>
        /// SID for your Client platform
        /// </summary>
        public string AccountSid { get; set; }

        /// <summary>
        /// Token for your Client platform
        /// </summary>
        public string AuthToken { get; set; }

        /// <summary>
        /// Refers to user phone number (message FROM)
        /// </summary>
        public string UserNumber { get; set; }
        
        /// <summary>
        /// Client type
        /// </summary>
        public MessagingManager ManagerClientType { get; set; }

        /// <summary>
        /// Default Constructor of Twilio Library
        /// </summary>
        /// <param name="userNumber">User phone number with prefix</param>
        public TwilloLibrary(string accountSid, string authToken, string userNumber, MessagingManager managerClientType)
        {
            //Account information
            AccountSid = Environment.GetEnvironmentVariable(accountSid);
            AuthToken = Environment.GetEnvironmentVariable(authToken);
            //Assign user phone number
            UserNumber = userNumber;
            //Assign Client
            switch (managerClientType)
            {
                case MessagingManager.TwilioClient:
                    TwilioClient.Init(AccountSid, AuthToken);
                    break;
            }
        }

        /// <summary>
        /// Send message method via Twilio
        /// </summary>
        /// <param name="body">Text of message</param>
        /// <param name="to">Do not forget about prefix in phone number</param>
        /// <param name="platform">For example for whatsapp is "whatsapp", for normal SMS fill nothing - ""</param>
        public void SendMessage(string body, string to, Platforms platform)
        {
            try
            {
                //Platforming
                string platformText = "";
                if (platform != Platforms.SMS)
                    platformText = Enum.GetName(typeof(Platforms), platform);

                //Create a message
                MessageResource.Create(
                    body: body,
                    from: new Twilio.Types.PhoneNumber(platformText + ":" + UserNumber),
                    to: new Twilio.Types.PhoneNumber(platformText + ":" + to)
                );
            }
            catch (Exception ex)
            {
                throw new ArgumentException("There is some problem with "+ ex.Message.ToString());
            }
        }
    }
}
