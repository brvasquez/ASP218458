using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASP218458.Models
{

    public class ReporteP
    {
        public String nombreCliente{ get; set; }
        public String documentoCliente { get; set; }        
        public System.DateTime? fechaCompras { get; set; }
        public int? totalCompras { get; set; }
    }

}