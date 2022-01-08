using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using SQLiteNetExtensions.Attributes;

namespace RentOrders.Models
{
   public class ListCar
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        [ForeignKey(typeof(OrderList))]
        public int OrderListID { get; set; }
        public int CarID { get; set; }
    }
}
