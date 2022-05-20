using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace AppGym.Models.DataNotation
{
    [MetadataType(typeof(JornadasDNotation))]
    public partial class Bitacoras
    {
    }
    public class BitacorasDNotation
    {

        public int IdBitacora { get; set; }


        [Required(ErrorMessage = "* Campo necesario")]
        [DataType(DataType.DateTime, ErrorMessage = "* Formato fecha")]
        public DateTime Asistencia { get; set; }


        [Required(ErrorMessage = "* Campo necesario")]
        public int IdEmpleadoBitacora { get; set; }
        public virtual Empleados IdEmpleadoBitacoraNavigation { get; set; }
    }
}
