using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
    public class Result
    {
        //Dar el resultado de una tarea
        public bool Correct { get; set; } //true , false
        public string ErrorMessage { get; set; } // Mensaje de error => Correct = false
        public Exception Ex { get; set; } //Error no esperado ConnectionString


        //SELECT
        public object Object { get; set; } //BOXING => GetById o solo traiga 1 solo registro

        public List<object> Objects { get; set; } //=> SELECT encuentre dos o mas registros

    }
}
