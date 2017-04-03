namespace Contracts
{
    using System.Collections.Generic;
    using Models.ViewModels;

    public interface ICatalogService
    {
        IEnumerable<CarViewModel> GetCars();
    }
}