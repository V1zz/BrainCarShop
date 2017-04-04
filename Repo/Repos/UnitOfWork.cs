using System;
using Contracts;
using System.Data.Entity;
using CarShopLayer;
using BrainCarShop.Entities;
using Repo.Repos;

namespace Repo
{
    

    public class UnitOfWork :  IUnitOfWork, IDisposable
    {
        private readonly DbContext _dbContext;

        private IRepo<Brand> _carBrandsRepo;
        private IRepo<Model> _carModelsRepo;
        private IRepo<Car> _carsRepo;
        private IRepo<Currency> _currenciesRepo;
        private IRepo<Price> _carPricesRepo;
        private IRepo<ModelType> _modelTypesRepo;

        public UnitOfWork()
        {
            _dbContext = new CarShopContext();
        }

        public IRepo<Brand> CarBrands => _carBrandsRepo ?? (_carBrandsRepo = new GenericRepo<Brand>(_dbContext));
        public IRepo<Model> CarModels => _carModelsRepo ?? (_carModelsRepo = new GenericRepo<Model>(_dbContext));
        public IRepo<Car> Cars => _carsRepo ?? (_carsRepo = new GenericRepo<Car>(_dbContext));
        public IRepo<Currency> Currencies => _currenciesRepo ?? (_currenciesRepo = new GenericRepo<Currency>(_dbContext));
        public IRepo<Price> CarPrices => _carPricesRepo ?? (_carPricesRepo = new GenericRepo<Price>(_dbContext));
        public IRepo<ModelType> ModelTypes => _modelTypesRepo ?? (_modelTypesRepo = new GenericRepo<ModelType>(_dbContext));

        public void SaveChanges()
        {
            _dbContext.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (this.disposed) return;
            if (disposing)
            {
                _dbContext.Dispose();
            }
            this.disposed = true;
        }
        
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}