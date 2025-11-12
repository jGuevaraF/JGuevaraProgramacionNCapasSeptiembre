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
            materia.Carrera = new ML.Carrera();

            var registros = BL.Materia.GetAll(materia);

            if (registros.Correct)
            {
                materia.Materias = registros.Objects;

                ML.Result resultCarreras = BL.Carrera.GetAll();

                if (resultCarreras.Correct)
                {
                    materia.Carrera.Carreras = resultCarreras.Objects;
                }
                else
                {
                    ViewBag.Error = resultCarreras.ErrorMessage;
                    materia.Carrera.Carreras = new List<object> { };
                }

                return View(materia);
            }
            else
            {
                ViewBag.Error = registros.ErrorMessage;
                materia.Materias = new List<object>(); //***********
                return View(materia);

            }
        }

        [HttpPost]
        public ActionResult GetAll(ML.Materia materia)
        {

            materia.Nombre = materia.Nombre == null ? "" : materia.Nombre;
            
            ML.Result result = BL.Materia.GetAll(materia);

            if (result.Correct)
            {
                materia.Materias = result.Objects;

                ML.Result resultCarreras = BL.Carrera.GetAll();

                if (resultCarreras.Correct)
                {
                    materia.Carrera.Carreras = resultCarreras.Objects;
                }
                else
                {
                    ViewBag.Error = resultCarreras.ErrorMessage;
                    materia.Carrera.Carreras = new List<object> { };
                }
            }
            else
            {
                materia.Materias = new List<object>();
                ViewBag.Error = "No se encontraron registros";
                ML.Result resultCarreras = BL.Carrera.GetAll();

                if (resultCarreras.Correct)
                {
                    materia.Carrera.Carreras = resultCarreras.Objects;
                }
                else
                {
                    ViewBag.Error = resultCarreras.ErrorMessage;
                    materia.Carrera.Carreras = new List<object> { };
                }
            }

            return View(materia);
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

        [HttpGet]
        public ActionResult GetAllView()
        {
            ML.Result result = BL.Materia.GetAllView();
            ML.Materia materia = new ML.Materia();

            if (result.Correct)
            {
                materia.Materias = result.Objects;
            }
            else
            {

            }

            return View(materia);
        }
    }
}