﻿using AutoMapper;
using MyRentalPos.Areas.Admin.Models.Store;
using MyRentalPos.Core.Domain.Stores;

namespace MyRentalPos.Mappers
{
    public class MappingProfile : Profile
    {
        public override string ProfileName
        {
            get { return "MappingProfile"; }
        }
        protected override void Configure()
        {
            Mapper.CreateMap<Store, StoreModel>();
            Mapper.CreateMap<StoreModel, Store>();

            Mapper.CreateMap<StoreAddress, StoreAddressModel>();
            Mapper.CreateMap<StoreAddressModel, StoreAddress>();
        }
    }
}