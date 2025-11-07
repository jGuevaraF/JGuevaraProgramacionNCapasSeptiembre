using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PL_MVC.Controllers
{
    public class MateriaController : Controller
    {
        // GET: Materia
        //Action Method
        //ActionResult => Vista
        //FileResult => descargar archivo
        //JsonResult => JSON

        [HttpGet] //Mostrar TODOS
        public ActionResult GetAll()
        {
            ML.Materia materia = new ML.Materia();
            materia.Nombre = "";

            var registros = BL.Materia.GetAll(materia);

            if (registros.Correct)
            {
                materia.Materias = registros.Objects;
                return View(materia);
            }
            else
            {
                materia.Materias = new List<object>(); //***********
                return View(materia);

            }
        }

        [HttpPost]
        public ActionResult GetAll(ML.Materia materia)
        {
            return View();
        }

        [HttpGet] //=> mostrar la vista
        public ActionResult Form(int? idMateria)
        {
            ML.Materia materia = new ML.Materia();

            if (idMateria == null)
            {
                //agregar
            }
            else
            {
                //idMateria > 0

                //editar
                //GetById

                ML.Result respuesta = BL.Materia.GetById(idMateria.Value);

                if (respuesta.Correct)
                {
                    materia = (ML.Materia)respuesta.Object;
                }

                //materia = (ML.Materia)respuesta;

            }
            return View(materia);
        }

        [HttpPost] // => Enviar, guardar informacion a la BD
        public ActionResult Form(ML.Materia materia)
        {
            if (materia.Id > 0)
            {
                //Editar Actualizar 
                BL.Materia.Update(materia);
                //Bien
                //Mal
            }
            else
            {
                ML.Result respuesta = BL.Materia.AddAdoNET(materia);

                if (respuesta.Correct)
                {
                    ViewBag.Message = "La materia se agrego correctamente";

                }
                else
                {
                    ViewBag.Message = "No se agrego " + respuesta.ErrorMessage;
                }

            }
            return PartialView("_Modal");
        }

        [HttpGet] //JS
        public ActionResult Delete(int idMateria)
        {
            ML.Result respuesta = BL.Materia.Delete(idMateria);
            if (respuesta.Correct)
            {
                //mostrar mensaje de que se hizo bien
            }
            else
            {
                //mostrar mensaje de que hubo un error
            }
            return RedirectToAction("GetAll");
        }

        [HttpPost]
        public JsonResult ChangeStatus(int idMateria, bool estatus)
        {
            ML.Result result = BL.Materia.ChangeStatus(idMateria, estatus);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

    }
}