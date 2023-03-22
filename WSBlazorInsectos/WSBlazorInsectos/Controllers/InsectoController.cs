using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WSBlazorInsectos.Models.Response;
using WSBlazorInsectos.Models;
using WSBlazorInsectos.Models.Request;

namespace WSBlazorInsectos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InsectoController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            Respuesta oRespuesta = new Respuesta();
            try
            {
                using (InsectosContext db = new InsectosContext())
                {
                    var lst = db.Insectos.ToList();
                    oRespuesta.Exito = 1;
                    oRespuesta.Data = lst;
                }
            }
            catch (Exception ex)
            {
                oRespuesta.Mensaje = ex.Message;
            }
            return Ok(oRespuesta);
        }

        [HttpPost]
        public IActionResult Add(InsectoRequest model)
        {
            Respuesta oRespuesta = new Respuesta();
            try
            {
                using (InsectosContext db = new InsectosContext())
                {
                    Insecto oInsecto = new Insecto();
                    oInsecto.Nombre = model.Nombre;
                    oInsecto.Descripcion = model.Descripcion;
                    oInsecto.Ubicacion = model.Ubicacion;
                    db.Insectos.Add(oInsecto);
                    db.SaveChanges();
                    oRespuesta.Exito = 1;
                }
            }
            catch (Exception ex)
            {
                oRespuesta.Mensaje = ex.Message;
            }
            return Ok(oRespuesta);
        }

        [HttpPut]
        public IActionResult Edit(InsectoRequest model)
        {
            Respuesta oRespuesta = new Respuesta();
            try
            {
                using (InsectosContext db = new InsectosContext())
                {
                    Insecto oInsecto = db.Insectos.Find(model.Id);
                    oInsecto.Nombre = model.Nombre;
                    oInsecto.Descripcion = model.Descripcion;
                    oInsecto.Ubicacion = model.Ubicacion;
                    db.Entry(oInsecto).State = Microsoft.EntityFrameworkCore.EntityState.Modified; ;
                    db.SaveChanges();
                    oRespuesta.Exito = 1;
                }
            }
            catch (Exception ex)
            {
                oRespuesta.Mensaje = ex.Message;
            }
            return Ok(oRespuesta);
        }

        [HttpDelete("{  }")]
        public IActionResult Delete(int Id)
        {
            Respuesta oRespuesta = new Respuesta();
            try
            {
                using (InsectosContext db = new InsectosContext())
                {
                    Insecto oInsecto = db.Insectos.Find(Id);
                    db.Remove(oInsecto);
                    db.SaveChanges();
                    oRespuesta.Exito = 1;
                }
            }
            catch (Exception ex)
            {
                oRespuesta.Mensaje = ex.Message;
            }
            return Ok(oRespuesta);
        }
    }
}
