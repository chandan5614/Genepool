using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Genepool.src.SOLID.S.Bad
{
    public class User
    {
        public string UserName { get; set; }
        public string Email { get; set; }

        public void Register()
        {
            EmailSender emailSender= new EmailSender();
            emailSender.SendEmail("Welcome! ", Email);
        }
    }
}