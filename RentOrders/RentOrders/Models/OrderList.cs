using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace RentOrders.Models
{
   public class OrderList
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Title { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhNumber { get; set; }
        public DateTime Date { get; set; }
    }
}
