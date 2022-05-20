using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace AppGym.Models.DataNotation
{
    [MetadataType(typeof(JornadasDNotation))]
    public partial class Jornadas
    {
    }
    public class JornadasDNotation
    {

        public int IdJornada { get; set; }


        [Required(ErrorMessage ="* Campo necesario")]
        [RegularExpression(@"[A-Za-z|\s]*", ErrorMessage = "Nombre unicamente se acepta letras y espacios")]
        public string NombreJornada { get; set; }
        
        
        [Required(ErrorMessage = "* Campo necesario")]
        public int DiasJornada { get; set; }
        
        [RegularExpression(@"([L]{1}|[M]{1}|[J]{1}|[V]{1}|[S]{1}|\s){1,11}", ErrorMessage = "* Escribir cualquier abreviatura del dia L M M J V S")]
        [Required(ErrorMessage = "* Campo necesario")]
        public string NombreDias { get; set; }
    }
}
