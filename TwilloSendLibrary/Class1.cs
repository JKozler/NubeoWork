using System;
using Twilio;
using Twilio.Rest.Api.V2010.Account;

namespace TwilloSendLibrary
{
    public class TwilloLibrary
    {
        //These two props references to Twilio 
        private string AccountSid { get; set; }
        private string AuthToken { get; set; }
        public string NumberPrefix { get; set; }

        public TwilloLibrary(string numberPrefix)
        {
            //Do not chage these
            AccountSid = Environment.GetEnvironmentVariable("SKd7b1e9d764a09727874ffb174f669cbe");
            AuthToken = Environment.GetEnvironmentVariable("7e8d3ce38955995a743618e7fa6ed6e7");
            NumberPrefix = numberPrefix;
            TwilioClient.Init(AccountSid, AuthToken);
        }

        
        public void SendMessage(string body, string from, string to, string platform)
        {
            MessageResource.Create(
                body: body,
                from: new Twilio.Types.PhoneNumber(platform + ":" + NumberPrefix + from),
                to: new Twilio.Types.PhoneNumber(platform + ":" + NumberPrefix + to)
            );
        }
    }
}
