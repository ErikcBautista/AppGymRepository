using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace AppGym.Models
{
    public partial class Jornadas
    {
        public Jornadas()
        {
            Empleados = new HashSet<Empleados>();
        }

        public int IdJornada { get; set; }
        public string NombreJornada { get; set; }
        public int DiasJornada { get; set; }
        public string NombreDias { get; set; }

        public virtual ICollection<Empleados> Empleados { get; set; }
    }
}
