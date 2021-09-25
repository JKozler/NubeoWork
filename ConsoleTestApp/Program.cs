using System;
using TwilloSendLibrary;

namespace ConsoleTestApp
{
    class Program
    {
        static void Main(string[] args)
        {
            TwilloLibrary library = new TwilloLibrary("+420776877148", MessagingManager.TwilioClient);
            library.SendMessage("Hi, I am Jakub.", "+420776877148", Platforms.SMS);
        }
    }
}
