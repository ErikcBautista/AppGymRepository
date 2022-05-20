using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace AppGym.Models
{
    public partial class Bitacoras
    {
        public int IdBitacora { get; set; }
        public DateTime Asistencia { get; set; }
        public int IdEmpleadoBitacora { get; set; }

        public virtual Empleados IdEmpleadoBitacoraNavigation { get; set; }
    }
}
