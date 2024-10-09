using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Genepool.src.SOLID.S.Good
{
    public class UserService
    {
        public void Register(User user)
        {
            EmailSender emailSender= new EmailSender();
            emailSender.SendEmail("Welcome! ", user.Email);
        }
    }
}