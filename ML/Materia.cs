using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
    public class Materia
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public byte Creditos { get; set; }
        public decimal Promedio { get; set; }
        public bool Estatus { get; set; }
        public ML.Carrera Carrera { get; set; } //Propiedad de navegacion
        //FK

        public List<object> Materias { get; set; }
    }

    //cuando manden mas de 2 campos, mejor manden un modelo
}
