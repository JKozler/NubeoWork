using System;
using TwilloSendLibrary;

namespace ConsoleTestApp
{
    class Program
    {
        static void Main(string[] args)
        {
            TwilloLibrary library = new TwilloLibrary("SKd7b1e9d764a09727874ffb174f669cbe", "7e8d3ce38955995a743618e7fa6ed6e7", "+420776877148", MessagingManager.TwilioClient);
            library.SendMessage("Hi, I am Jakub.", "+420776877148", Platforms.SMS);
        }
    }
}
