﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using TaxManager.Core.Models;
using TaxManager.Core.Models.TaxManager.Core.Models;
using TaxManagerServer.Core.DTOs;

namespace TaxManagerServer.Core
{
    public class Mapping : Profile
    {
        public Mapping() { 

            CreateMap<User, UserDTO>().ReverseMap(); ;

            CreateMap<Document, DocumentDTO>().ReverseMap(); ;

            CreateMap<Folder, FolderDTO>().ReverseMap();

        }
    }
}
