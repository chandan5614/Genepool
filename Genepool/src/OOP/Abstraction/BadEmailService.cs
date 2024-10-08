using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Genepool.src.OOP.Abstraction
{
    public class BadEmailService
    {
        public void SendEmail()
        {
            System.Console.WriteLine("Sending email...");
        }

        public void Connect()
        {
            System.Console.WriteLine("Connecting to email server...");
        }

        public void Authenticate()
        {
            System.Console.WriteLine("Authenticating...");
        }

        public void Disconnect()
        {
            System.Console.WriteLine("Disconnecting from email server...");
        }
    }
}