using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DL_EF;

namespace BL
{
    public class Materia
    {
        public static ML.Result AddAdoNET(ML.Materia Materia)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (SqlConnection context = new SqlConnection())
                {
                    context.ConnectionString = DL.Connection.GetConnection();

                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = context;
                    cmd.CommandText = "INSERT INTO Materia2 (Nombre, Creditos, Promedio) VALUES (@Nombre, @Creditos, @Promedio)";

                    cmd.Parameters.AddWithValue("Nombre", Materia.Nombre);
                    cmd.Parameters.AddWithValue("Creditos", Materia.Creditos);
                    cmd.Parameters.AddWithValue("Promedio", Materia.Promedio);

                    context.Open();

                    int filasAfectadas = cmd.ExecuteNonQuery();

                    if (filasAfectadas > 0)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "Error al insertar";
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

        public static ML.Result Delete(int Id)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (SqlConnection context = new SqlConnection(DL.Connection.GetConnection()))
                {

                    string query = "DELETE FROM Materia WHERE Id = @IdMateria";

                    SqlCommand cmd = new SqlCommand(query, context);

                    cmd.Parameters.AddWithValue("IdMateria", Id);

                    context.Open();

                    int filasAfectadas = cmd.ExecuteNonQuery();

                    if (filasAfectadas > 0)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se pudo eliminar";
                    }

                }

            }
            catch (Exception ex)
            {
                //ERROR
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }

            return result;

        }

        public static List<object> GetAllSinResult() //TODOS LOS REGISTROS
        {
            using (SqlConnection context = new SqlConnection(DL.Connection.GetConnection()))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = context;
                cmd.CommandText = "MateriaGetALl"; //Nombre del Procedimiento almacenado
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter adapter = new SqlDataAdapter(cmd); //ejecuta el query, SELECT

                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                if (dataTable.Rows.Count > 0)
                {
                    List<object> list = new List<object>();
                    //si hay informacion
                    foreach (DataRow row in dataTable.Rows) //iterar TODO
                    {
                        ML.Materia materia = new ML.Materia();
                        materia.Carrera = new ML.Carrera();

                        materia.Id = Convert.ToInt32(row[0]);
                        materia.Nombre = row[1].ToString();

                        materia.Creditos = Convert.ToByte(row[2]);
                        materia.Creditos = byte.Parse(row[2].ToString());

                        //materia.Promedio = Convert.ToDouble(row[3]);

                        materia.Carrera.Nombre = row[7].ToString();



                        list.Add(materia); //boxing
                    }

                    return list;


                }
                else
                {
                    //no hay informacion
                    //ROWS

                    return new List<object> { };
                }
            }
        }

        public static ML.Result GetByIdADONET(int Id)
        {
            ML.Result result = new ML.Result(); //nivel de contexto

            try
            {
                using (SqlConnection context = new SqlConnection(DL.Connection.GetConnection()))
                {
                    string query = "SELECT Id, Nombre, Creditos, Promedio, Dinero, Fecha, FechaYHora FROM Materia WHERE Id = @Id";

                    SqlCommand cmd = new SqlCommand(query, context);
                    cmd.Parameters.AddWithValue("Id", Id);

                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    if (dataTable.Rows.Count > 0)
                    {

                        DataRow row = dataTable.Rows[0];

                        ML.Materia materia = new ML.Materia();
                        materia.Id = Convert.ToInt32(row[0]);
                        materia.Nombre = row[1].ToString();

                        materia.Creditos = Convert.ToByte(row[2]);
                        materia.Creditos = byte.Parse(row[2].ToString());

                        //materia.Promedio = Convert.ToDouble(row[3]);

                        result.Object = materia;

                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se encontro el registro";
                    }
                }

            }
            catch (Exception ex)
            {
                //ERROR
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }

            return result;


        }

        public static bool Update(ML.Materia Materia)
        {
            using (SqlConnection context = new SqlConnection((DL.Connection.GetConnection())))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = context;
                cmd.CommandText = "MateriaUpdate";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("Nombre", Materia.Nombre);
                cmd.Parameters.AddWithValue("Creditos", Materia.Creditos);
                cmd.Parameters.AddWithValue("Promedio", Materia.Promedio);
                cmd.Parameters.AddWithValue("id", Materia.Id);

                context.Open();

                int filasAfectadas = cmd.ExecuteNonQuery();
                if (filasAfectadas > 0)
                {
                    //Actualizo Correctamente
                    return true;
                }
                else
                {
                    //ERROR
                    return false;
                }

            }
        }


        public static ML.Result GetAllAdoNET()
        {
            ML.Result result = new ML.Result();

            try
            {
                //intenta hacer esto
                using (SqlConnection context = new SqlConnection(DL.Connection.GetConnection()))
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = context;
                    cmd.CommandText = "MateriaGetAll";
                    cmd.CommandType = CommandType.StoredProcedure;

                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    if (dataTable.Rows.Count > 0)
                    {
                        //hay informacion
                        result.Objects = new List<object>();

                        foreach (DataRow row in dataTable.Rows) //iterar TODO
                        {
                            ML.Materia materia = new ML.Materia();
                            materia.Carrera = new ML.Carrera();

                            materia.Id = Convert.ToInt32(row[0]);
                            materia.Nombre = row[1].ToString();

                            materia.Creditos = Convert.ToByte(row[2]);
                            materia.Creditos = byte.Parse(row[2].ToString());

                            //materia.Promedio = Convert.ToDouble(row[3]);

                            materia.Carrera.Nombre = row[7].ToString();


                            result.Objects.Add(materia); //boxing
                        }

                        result.Correct = true;

                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No hay registros";
                    }
                }

            }
            catch (Exception ex)
            {
                //ERROR 
                result.Correct = false;
                result.ErrorMessage = ex.Message; //USUARIO
                result.Ex = ex; //PROGRAMADOR
            }

            return result;
        }


        public static ML.Result GetAll(ML.Materia materiaBusqueda)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.JGuevaraProgramacionNCapasSeptiembre2025Entities context = new DL_EF.JGuevaraProgramacionNCapasSeptiembre2025Entities())
                {
                    var registros = context.MateriaGetAll(materiaBusqueda.Nombre, materiaBusqueda.Carrera.IdCarrera).ToList();

                    if (registros.Count > 0)
                    {
                        result.Objects = new List<object>();

                        foreach (var registro in registros)
                        {
                            ML.Materia materia = new ML.Materia();
                            materia.Id = registro.Id;
                            if (registro.Promedio != null)
                            {
                                materia.Promedio = registro.Promedio.Value;

                            }

                            materia.Nombre = registro.MateriaNombre;
                            materia.Carrera = new ML.Carrera();
                            materia.Carrera.Nombre = registro.CarreraNombre;

                            materia.Estatus = registro.Estatus ?? false;

                            result.Objects.Add(materia);
                        }

                        result.Correct = true;

                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No hay registros";
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

        public static ML.Result GetAllView()
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.JGuevaraProgramacionNCapasSeptiembre2025Entities context = new DL_EF.JGuevaraProgramacionNCapasSeptiembre2025Entities())
                {
                    var registros = context.MateriaGetAllViews.ToList();

                    if (registros.Count > 0)
                    {
                        result.Objects = new List<object>();

                        foreach (var registro in registros)
                        {
                            ML.Materia materia = new ML.Materia();
                            materia.Id = registro.Id;
                            if (registro.Promedio != null)
                            {
                                materia.Promedio = registro.Promedio.Value;

                            }

                            materia.Nombre = registro.MateriaNombre;
                            materia.Carrera = new ML.Carrera();
                            materia.Carrera.Nombre = registro.CarreraNombre;

                            materia.Estatus = registro.Estatus ?? false;

                            result.Objects.Add(materia);
                        }

                        result.Correct = true;

                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No hay registros";
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

        public static ML.Result GetById(int idMateria)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL_EF.JGuevaraProgramacionNCapasSeptiembre2025Entities context = new DL_EF.JGuevaraProgramacionNCapasSeptiembre2025Entities())
                {
                    //var query = context.MateriaGetById(idMateria).FirstOrDefault();

                    var query = (from materia in context.Materias
                                 where materia.Id == 1982980
                                 select materia).SingleOrDefault();

                    //if (query != null)
                    //{
                    //    //encontro informacion
                    //    ML.Materia materia = new ML.Materia();
                    //    materia.Id = query.Id;
                    //    materia.Nombre = query.Nombre;

                    //    materia.Promedio = query.Promedio ?? 0;

                    //    //if (query.Promedio != null)
                    //    //{
                    //    //    materia.Promedio = query.Promedio.Value;

                    //    //}

                    //    materia.Creditos = query.Creditos ?? 0;

                    //    result.Object = materia;

                    //    result.Correct = true;
                    //}
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

        public static ML.Result ChangeStatus(int idMateria, bool estatus)
        {
            ML.Result result = new ML.Result();
            try
            {
                using(DL_EF.JGuevaraProgramacionNCapasSeptiembre2025Entities context = new DL_EF.JGuevaraProgramacionNCapasSeptiembre2025Entities())
                {
                    var query = context.MateriaChangeStatus(idMateria, estatus);

                    if(query > 0)
                    {
                        result.Correct = true;
                    } else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se pudo actualizar";
                    }
                }

            } catch(Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }

            return result;
        }

    }
}
