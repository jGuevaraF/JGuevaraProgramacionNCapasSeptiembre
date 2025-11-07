using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Carrera
    {

        public static ML.Result GetAll()
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL_EF.JGuevaraProgramacionNCapasSeptiembre2025Entities context = new DL_EF.JGuevaraProgramacionNCapasSeptiembre2025Entities())
                {
                    var carreras = context.CarreraGetAll().ToList();

                    if (carreras.Count > 0)
                    {
                        result.Objects = new List<object>();
                        foreach (var c in carreras)
                        {
                            ML.Carrera carrera = new ML.Carrera();
                            carrera.IdCarrera = c.IdCarrera;
                            carrera.Nombre = c.Nombre;
                            result.Objects.Add(carrera);

                        }
                        result.Correct = true;
                    }
                    else
                    {
                        result.ErrorMessage = "No se encontraron carreras";
                        result.Correct = false;
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }

            return result;
        }

    }
}
