using AutoMapper; 
using MMVDashboard.Application.AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace MMVDashboard.Application.AutoMapper
{
    public class AutoMapperConfig
    {
        public static MapperConfiguration RegisterMappings()
        {
            return new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new DomainToViewModelMappingProfile());
                cfg.AddProfile(new ViewModelToDomainMappingProfile());
            });
        }
    }
}
