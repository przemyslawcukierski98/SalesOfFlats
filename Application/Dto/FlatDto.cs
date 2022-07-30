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
    public class FlatDto : IMap
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public double Area { get; set; }
        public int NumberOfRooms { get; set; }
        public int Price { get; set; }
        public int Floor { get; set; }
        public DateTime CreationDate { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<Flat, FlatDto>()
                .ForMember(dest => dest.CreationDate,
                opt => opt.MapFrom(src => src.Created));
        }
    }
}
