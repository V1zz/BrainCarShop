namespace Repo
{
    using System.Linq;
    using System.Collections.Generic;
    using Contracts;
    using BrainCarShop.ViewModels;

    public class CatalogService : ICatalogService
    {
        private readonly IUnitOfWork _unitOfWork;

        public CatalogService()
        {
            _unitOfWork = new UnitOfWork();
        }

        public IEnumerable<CarViewModel> GetCars()
        {
            return _unitOfWork.Cars.Find(car => true, car => car.Model.ModelType, car => car.Model.Brand,
                                 car => car.Prices)
                             .Select(car => new CarViewModel
                             {
                                 Id = car.Id,
                                 Brand = car.Model.Brand.Name,
                                 ChasisNumber = car.ChasisNumber,
                                 Type = car.Model.ModelType.Type,
                                 Color = car.Color,
                                 Model = car.Model.Name,
                                 Year = car.Model.Year.ToString()
                             });
        }
    }
}