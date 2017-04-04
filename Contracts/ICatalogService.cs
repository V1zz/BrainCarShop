namespace Contracts
{
    using System.Collections.Generic;
    using BrainCarShop.ViewModels;

    public interface ICatalogService
    {
        IEnumerable<CarViewModel> GetCars();
    }
}