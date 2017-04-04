using System;
using System.Web.Mvc;
using Contracts;
using Repo;

namespace BrainCarShop.Controllers
{
    public class CatalogController : Controller
    {
        private readonly ICatalogService _catalogService;
        private readonly IUnitOfWork _unitOfWork;

        public CatalogController()
        {
            _catalogService = new CatalogService();
            _unitOfWork = new UnitOfWork();
            _unitOfWork.CarBrands.Get(Guid.NewGuid());

        }
        // GET: Catalog
        public ActionResult Index()
        {
            return this.View(_catalogService.GetCars());
        }
        public ActionResult Details()
        {
            return this.View();
        }
        public ActionResult Create()
        {
            return this.View();
        }
        public ActionResult Delete()
        {
            return this.View();
        }
        public ActionResult Edit()
        {
            return this.View();
        }
    }
}