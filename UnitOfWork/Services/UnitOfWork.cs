using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UnitOfWork.Models;

namespace UnitOfWork.Services
{
    public interface IUnitOfWork
    {
        IRepository<Plantilla> Plantilla { get; }
        IRepository<PlantillaTipo> PlantillaTipo { get; }
        void Save();
    }

    public class UnitOfWork : IUnitOfWork
    {
        private PresupuestoContext _presupuestoContext;
        private IRepository<Plantilla> _plantilla;
        private IRepository<PlantillaTipo> _plantillaTipo;

        public UnitOfWork(PresupuestoContext presupuestoContext) => this._presupuestoContext = presupuestoContext;

        public IRepository<Plantilla> Plantilla
        {
            get
            {
                return _plantilla == null ?
                _plantilla = new Repository<Plantilla>(_presupuestoContext) :
                _plantilla;
            }
        }


        public IRepository<PlantillaTipo> PlantillaTipo
        {
            get
            {
                return _plantillaTipo == null ?
                _plantillaTipo = new Repository<PlantillaTipo>(_presupuestoContext) :
                _plantillaTipo;
            }
        }

        public void Save() => _presupuestoContext.SaveChanges();
    }
}