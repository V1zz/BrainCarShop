using Models.ViewModels;

namespace Contracts
{
    using System.Collections.Generic;

    public interface ICatalogService
    {
        IEnumerable<CarViewModel> GetCars();
    }
}