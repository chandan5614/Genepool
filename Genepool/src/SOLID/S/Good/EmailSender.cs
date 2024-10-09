using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Genepool.src.SOLID.S.Good
{
    public class EmailSender
    {
        public void SendEmail(string message, string recipient)
        {
            Console.WriteLine($"Sending email to {recipient}: {message}");
        }
    }
}