﻿using AutoMapper;
using Lms.Core.Dto;
using Lms.Core.Entities;
using Lms.Core.Lms.Core.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lms.Data.Data
{
    public class LmsMappings : Profile
    {
        public LmsMappings()
        {
            CreateMap<Module, ModuleDto>().ReverseMap();
            CreateMap<Course, CourseDto>().ReverseMap();

        }
    }
}
