using AutoMapper;
using MyRentalPos.Areas.Admin.Models.Store;
using MyRentalPos.Core.Domain.Stores;

namespace MyRentalPos.Mappers
{
    public static class MappingExtensions
    {
        public static StoreModel ToModel(this Store entity)
        {
            return Mapper.Map<Store, StoreModel>(entity);
        }

        public static Store ToEntity(this StoreModel model)
        {
            return Mapper.Map<StoreModel, Store>(model);
        }

        public static Store ToEntity(this StoreModel model, Store destination)
        {
            return Mapper.Map(model, destination);
        }

        public static StoreAddressModel ToModel(this StoreAddress entity)
        {
            return Mapper.Map<StoreAddress, StoreAddressModel>(entity);
        }

        public static StoreAddress ToEntity(this StoreAddressModel model)
        {
            return Mapper.Map<StoreAddressModel, StoreAddress>(model);
        }

        public static StoreAddress ToEntity(this StoreAddressModel model, StoreAddress destination)
        {
            return Mapper.Map(model, destination);
        }

    }
}