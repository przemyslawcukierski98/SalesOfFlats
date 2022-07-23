using Application.Mappings;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dto
{
    public class CreateFlatDto : IMap
    {
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



        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateFlatDto, Flat>();
        }
    }
}
