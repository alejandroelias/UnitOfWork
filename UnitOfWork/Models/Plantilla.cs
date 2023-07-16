using System;
using System.Collections.Generic;

namespace UnitOfWork.Models
{
    public partial class Plantilla
    {
        public int PlantillaId { get; set; }
        public string Descripcion { get; set; }
        public int PlantillaTipoId { get; set; }

        public virtual PlantillaTipo PlantillaTipo { get; set; }
    }
}
