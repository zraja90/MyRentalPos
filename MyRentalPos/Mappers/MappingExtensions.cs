using AutoMapper;
using MyRentalPos.Areas.Admin.Models.Store;
using MyRentalPos.Core.Domain.Stores;

namespace MyRentalPos.Mappers
{
    public static class MappingExtensions
    {
        public static CreateStoreModel ToModel(this Store entity)
        {
            return Mapper.Map<Store, CreateStoreModel>(entity);
        }

        public static Store ToEntity(this CreateStoreModel model)
        {
            return Mapper.Map<CreateStoreModel, Store>(model);
        }

        public static Store ToEntity(this CreateStoreModel model, Store destination)
        {
            return Mapper.Map(model, destination);
        }
    }
}