using Models.Entities;

namespace Contracts
{
    public interface IUnitOfWork
    {
        IRepo<Brand> CarBrands { get; }

        IRepo<Model> CarModels { get; }

        //IRepo<ModelTypes> ModelTypes { get; }

        IRepo<Car> Cars { get; }

        IRepo<Currency> Currencies { get; }

        IRepo<Price> CarPrices { get; }

        void SaveChanges();
    }
}