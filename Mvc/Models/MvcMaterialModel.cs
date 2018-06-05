using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Mvc.Models
{
    public class MvcMaterialModel
    {


        public int MaterialID { get; set; }
        [Required(ErrorMessage ="Este campo é obrigatorio!")]
        public string Nome { get; set; }
        public string Tipo { get; set; }








    }
}