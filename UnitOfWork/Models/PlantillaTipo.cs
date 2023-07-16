using System;
using System.Collections.Generic;

namespace UnitOfWork.Models
{
    public partial class PlantillaTipo
    {
        public PlantillaTipo()
        {
            Plantilla = new HashSet<Plantilla>();
        }

        public int PlatillaTipoId { get; set; }
        public string Descripcion { get; set; }

        public virtual ICollection<Plantilla> Plantilla { get; set; }
    }
}
