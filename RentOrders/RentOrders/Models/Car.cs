using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using SQLiteNetExtensions.Attributes;

namespace RentOrders.Models
{
    public class Car
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Model { get; set; }
        public string Color { get; set; }
        [OneToMany]
        public List<ListCar> ListCars { get; set; }
    }
}
