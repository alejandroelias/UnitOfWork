using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using UnitOfWork.Models;
using UnitOfWork.Services;

namespace UnitOfWork.Controllers
{
    public class PlantillaController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public PlantillaController(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;

        public ActionResult Index()
        {
            IEnumerable<Plantilla> plantillas = from p in _unitOfWork.Plantilla.Get()
                                                select new Plantilla
                                                {
                                                    PlantillaId = p.PlantillaId,
                                                    Descripcion = p.Descripcion
                                                };

            IEnumerable<PlantillaTipo> tiposPlantillas = _unitOfWork.PlantillaTipo.Get();


            return View();
        }
    }
}