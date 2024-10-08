using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Genepool.src.OOP.Coupling.Bad
{
    public class Order
    {
        public void PlaceOrder()
        {
            EmailSender emailSender= new EmailSender();
            emailSender.SendEmail("Order placed successfully");
        }
    }
}