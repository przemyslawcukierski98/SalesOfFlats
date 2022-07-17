using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Flat : AuditableEntity
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public double Area { get; set; }
        public int NumberOfRooms { get; set; }
        public int Price { get; set; }
        public string FormOfOwnership { get; set; }
        public int Floor { get; set; }
        public string StateOfCompletion { get; set; }
        public string KindOfBalcony { get; set; }
        public string ParkingSpace { get; set; }
        public string Heating { get; set; }

        public Flat()
        {

        }

        public Flat(int id, string title, string description, double area,
            int numberOfRooms, int price, string formOfOwnership,
            int floor, string stateOfCompletion, string kindOfBalcony,
            string parkingSpace, string heating)
        {
            (Id, Title, Description, Area, NumberOfRooms, Price, FormOfOwnership,
                Floor, StateOfCompletion, KindOfBalcony, ParkingSpace, Heating) =
            (id, title, description, area, numberOfRooms, price, formOfOwnership,
            floor, stateOfCompletion, kindOfBalcony, parkingSpace, heating);
        }
    }
}
