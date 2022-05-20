using Encrypt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
namespace AppGym.Models.DataNotation
{
    [MetadataType(typeof(EmpleadosDNotation))]
    public partial class Empleados
    {
    }
    public class EmpleadosDNotation
    {
        public int IdEmpleado { get; set; }

        [Required(ErrorMessage = "* Campo obligatorio")]
        [RegularExpression(@"[A-Za-z|\s]*", ErrorMessage = "* Unicamente se acepta letras y espacios")]
        public string NombresEmpleado { get; set; }

        [Required(ErrorMessage = "* Campo obligatorio")]
        [RegularExpression(@"[A-Za-z|\s]*", ErrorMessage = "* Unicamente se acepta letras y espacios")]
        public string ApellidosEmpleado { get; set; }

        [Required(ErrorMessage = "* Campo obligatorio")]
        [RegularExpression(@"[0-9]{10}",ErrorMessage ="* 10 Digitos")]
        public string TelefonoEmpleado { get; set; }

        [Required(ErrorMessage = "* Campo obligatorio")]
        public string NombreSesionEmpleado { get; set; }
        //public string PasswordEmpleado { get; set; }
        
        
        public string _PasswordEmpleado;
        [Required(ErrorMessage = "* Campo obligatorio")]
        [MinLength(8,ErrorMessage ="Introducir al menos 8 caracteres")]
        [RegularExpression(@"([A-Z]{1,}[a-z]{1,}[0-9]{1,})",ErrorMessage ="* Al menos una mayuscula una minuscula y un numero")]
        public string PasswordEmpleado
        {
            get
            {
                Encript encript = new Encript();
                encript.strData = _PasswordEmpleado;
                return encript.DecryptData();
                //return _PasswordEmpleado;
            }
            set
            {
                Encript encript = new Encript();
                encript.strData = value;
                _PasswordEmpleado = encript.EncryptData();
            }
        }

        [Required(ErrorMessage = "* Campo obligatorio")]
        public int IdJornadaEmpleado { get; set; }

        public virtual Jornadas IdJornadaEmpleadoNavigation { get; set; }
    }
}
