using AutoMapper;
using ContactManager.BLL.DTO;
using ContactManager.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ContactManager.BLL.Mapping;

public class ContactDataProfile : Profile
{
    public ContactDataProfile()
    {
        CreateMap<ContactData, ContactDataDTO>().ReverseMap();
    }
}
