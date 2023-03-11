using AutoMapper;
using ContactManager.BLL.DTO;
using ContactManager.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ContactManager.BLL.Mapping;

public class ContactDataProfile : Profile
{
    public ContactDataProfile()
    {
        CreateMap<ContactData, ContactDataDTO>()
            .ForMember(dest => dest.Married, opt => opt.MapFrom(src => src.Married ? "Yes" : "No"))
            .ForMember(dest => dest.DateOfBirth, opt => opt.MapFrom(src => src.DateOfBirth.ToString("yyyy-MM-dd")));

        CreateMap<ContactDataDTO, ContactData>()
            .ForMember(dest => dest.Married, opt => opt.MapFrom(src => src.Married == "Yes"))
            .ForMember(dest => dest.DateOfBirth, opt => opt.MapFrom(src => DateTime.ParseExact(src.DateOfBirth, "yyyy-MM-dd", CultureInfo.InvariantCulture)));
    }
}
