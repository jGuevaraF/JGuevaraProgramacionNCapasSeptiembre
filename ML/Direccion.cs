using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML
{

    public class Estado
    {
        public int IdEstado { get; set; }
        public string Nombre { get; set; }
    }

    public class Municipio
    {
        public int IdMunicipio { get; set; }
        public string Nombre { get; set; }
        public Estado Estado { get; set; }
    }

    public class Colonia
    {
        public int IdColonia { get; set; }
        public string Nombre { get; set; }
        public int CodigoPostal { get; set; }
        public Municipio Municipio { get; set; }
    }

    public class Direccion
    {
        public int IdDireccion { get; set; }
        public string Calle { get; set; }
        public Colonia Colonia { get; set; }
    }
}
