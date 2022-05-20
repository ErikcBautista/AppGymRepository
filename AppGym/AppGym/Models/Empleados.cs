using Encrypt;
using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace AppGym.Models
{
    public partial class Empleados
    {
        public Empleados()
        {
            Bitacoras = new HashSet<Bitacoras>();
        }

        public int IdEmpleado { get; set; }
        public string NombresEmpleado { get; set; }
        public string ApellidosEmpleado { get; set; }
        public string TelefonoEmpleado { get; set; }
        public string NombreSesionEmpleado { get; set; }
        //public string PasswordEmpleado { get; set; }
        public string _PasswordEmpleado;
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
        public int IdJornadaEmpleado { get; set; }

        public virtual Jornadas IdJornadaEmpleadoNavigation { get; set; }
        public virtual ICollection<Bitacoras> Bitacoras { get; set; }
    }
}
