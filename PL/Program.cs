using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PL
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Examen.Palindromo("Anita lava la tina");

            //ML.Materia materia = new ML.Materia(); //guardando los datos que me dio el usuario

            //Console.WriteLine("Dame el nombre de la Materia:");
            //materia.Nombre = Console.ReadLine();

            //Console.WriteLine("Dame los creditos");
            //materia.Creditos = byte.Parse(Console.ReadLine());

            //Console.WriteLine("Dame el Promedio");
            //materia.Promedio = double.Parse(Console.ReadLine());

            ////continuan con los demas datos
            //BL.Materia.Add(materia);

            ////Console.WriteLine("Dame el id que quieres borrar");
            ////int id = int.Parse(Console.ReadLine());
            ////bool respuesta = BL.Materia.Delete(id);
            ////if(respuesta) //respuesta == true
            ////{
            ////    Console.WriteLine("Se Elimino Correctamente");
            ////}
            ////else
            ////{
            ////    Console.WriteLine("No se pudo eliminar");
            ////}
            ////List<object> registros = BL.Materia.GetAll();
            ////2


            ////Imprimir(1);











            //var registros = BL.Materia.GetAll();

            //foreach (ML.Materia materia in registros) //unboxing
            //{
            //    Console.WriteLine(materia.Nombre);
            //    Console.WriteLine(materia.Creditos);
            //    Console.WriteLine(materia.Carrera.Nombre);
            //}







            //Console.WriteLine("Dame el id que quieres ver");
            //int id = int.Parse(Console.ReadLine());

            //object resultado = BL.Materia.GetById(id);

            //if (resultado != null)
            //{
            //    //encontro una materia
            //    ML.Materia materia = (ML.Materia)resultado; // unboxing

            //    //imprimir
            //    Console.WriteLine(materia.Id);
            //    Console.WriteLine(materia.Nombre);

            //    //pedir los datos a actualizar
            //    ML.Materia materiaUpdate = new ML.Materia();
            //    Console.WriteLine("Dame el nuevo nombre");
            //    materiaUpdate.Nombre = Console.ReadLine();
            //    Console.WriteLine("Dame los nuevos creditos");
            //    materiaUpdate.Creditos = byte.Parse(Console.ReadLine());
            //    Console.WriteLine("Dame el nuevo promedio");
            //    materiaUpdate.Promedio = double.Parse(Console.ReadLine());
            //    materiaUpdate.Id = id;

            //    bool respuesta = BL.Materia.Update(materiaUpdate);

            //    if (respuesta)
            //    {
            //        Console.WriteLine("Se actualizo correctamente");
            //    }
            //    else
            //    {
            //        Console.WriteLine("No se actualizo");
            //    }

            //}
            //else
            //{
            //    //no encontro una materia
            //    Console.WriteLine("El Id no existe");
            //}






        }

        public static void Imprimir(int numero)
        {
            if (numero <= 5)
            {
                Console.WriteLine(numero);
                numero++;
                Imprimir(numero);
            }
            else
            {
                return;

            }
        }
    }
}
