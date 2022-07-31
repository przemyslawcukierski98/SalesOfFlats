using Domain.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    [Table("Flats")]
    public class Flat : AuditableEntity
    {
        [Key]
        [Comment("Klucz główny tabeli z informacjami o mieszkaniach")]
        public int Id { get; set; }
        [Required]
        [MaxLength(200)]
        [Comment("Tytuł ogłoszenia")]
        public string Title { get; set; }
        [Required]
        [MaxLength(1000)]
        [Comment("Opis ogłoszenia")]
        public string Description { get; set; }
        [Required]
        [Comment("Powierzchnia mieszkania (w metrach kwadratowych)")]
        public double Area { get; set; }
        [Required]
        [Comment("Liczba pokoi")]
        public int NumberOfRooms { get; set; }
        [Required]
        [Comment("Cena (za metr kwadratowy)")]
        public int Price { get; set; }
        [Comment("Forma własności")]
        public string FormOfOwnership { get; set; }
        [Comment("Piętro")]
        public int Floor { get; set; }
        [Comment("Status wykończenia mieszkania")]
        public string StateOfCompletion { get; set; }
        [Comment("Typ balkonu (jeśli brak - wartość pusta)")]
        public string KindOfBalcony { get; set; }
        [Comment("Parking (jeśli brak - wartość pusta)")]
        public string ParkingSpace { get; set; }
        [Comment("Rodzaj ogrzewania")]
        public string Heating { get; set; }
        public ICollection<Picture> Pictures { get; set; }

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
