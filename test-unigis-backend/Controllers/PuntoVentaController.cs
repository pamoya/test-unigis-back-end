using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using test_unigis_backend.Models;

namespace test_unigis_backend.Controllers
{
    [EnableCors(origins: "http://localhost:3000", headers:"*", methods:"*")]
    public class PuntoVentaController : ApiController
    {
        test_unigis_dbaEntities contexto = new test_unigis_dbaEntities();

        // GET: api/PuntoVenta
        public List<punto_venta> Get()
        {
            try
            {
                var puntosVenta = contexto.punto_venta.ToList();

                foreach(var puntoVenta in puntosVenta)
                {
                    puntoVenta.DetalleZonas = contexto.ctl_zonas.FirstOrDefault(x => x.id == puntoVenta.Zona);
                }

                return puntosVenta;
            }
            catch (Exception ex)
            {
                if (ex.InnerException != null)
                {
                    throw new Exception(ex.InnerException.Message);
                }
                else
                {
                    throw new Exception(ex.Message);
                }

            }
        }

        // GET: api/PuntoVenta/5
        public punto_venta Get(int id)
        {
            try
            {
                var puntoVenta = contexto.punto_venta.FirstOrDefault(x=>x.Id == id);
                puntoVenta.DetalleZonas = contexto.ctl_zonas.FirstOrDefault(x => x.id == puntoVenta.Zona);
                return puntoVenta;
            }
            catch (Exception ex)
            {
                if (ex.InnerException != null)
                {
                    throw new Exception(ex.InnerException.Message);
                }
                else
                {
                    throw new Exception(ex.Message);
                }

            }
        }

        // POST: api/PuntoVenta
        public string Post([FromBody]punto_venta puntoVenta)
        {
            try
            {
                contexto.punto_venta.Add(puntoVenta);
                var response = contexto.SaveChanges();
                
                if(response > 0)
                {
                    return "Registro guardado con exito";
                }
                else
                {
                    return "El registro no se guardo";
                }
            }
            catch (Exception ex)
            {
                if (ex.InnerException != null)
                {
                    throw new Exception(ex.InnerException.Message);
                }
                else
                {
                    throw new Exception(ex.Message);
                }

            }
        }

        // PUT: api/PuntoVenta/5
        public string Put([FromBody]punto_venta puntoVenta)
        {
            try
            {
                var salePoint = contexto.punto_venta.FirstOrDefault(x=>x.Id == puntoVenta.Id);

                if(salePoint != null )
                {
                    contexto.Entry(salePoint).CurrentValues.SetValues(puntoVenta);
                    var response = contexto.SaveChanges();

                    if (response > 0)
                    {
                        return "Registro actualizado con exito";
                    }
                    else
                    {
                        return "El registro no se actualizo";
                    }
                }
                else
                {
                    return "El registro no existe";
                }
            }
            catch (Exception ex)
            {
                if (ex.InnerException != null)
                {
                    throw new Exception(ex.InnerException.Message);
                }
                else
                {
                    throw new Exception(ex.Message);
                }

            }
        }

        // DELETE: api/PuntoVenta/5
        public string Delete(int id)
        {
            try
            {
                var salePoint = contexto.punto_venta.FirstOrDefault(x => x.Id == id);

                if (salePoint != null)
                {
                    contexto.punto_venta.Remove(salePoint);
                    var response = contexto.SaveChanges();

                    if (response > 0)
                    {
                        return "Registro borrado con exito";
                    }
                    else
                    {
                        return "El registro no se pudo borrar";
                    }
                }
                else
                {
                    return "El registro no existe";
                }
            }
            catch (Exception ex)
            {
                if (ex.InnerException != null)
                {
                    throw new Exception(ex.InnerException.Message);
                }
                else
                {
                    throw new Exception(ex.Message);
                }

            }
        }
    }
}
