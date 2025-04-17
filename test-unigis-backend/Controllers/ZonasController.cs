using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using test_unigis_backend.Models;

namespace test_unigis_backend.Controllers
{
    public class ZonasController : ApiController
    {
        test_unigis_dbaEntities contexto = new test_unigis_dbaEntities();
        // GET: api/Zonas
        public List<ctl_zonas> Get()
        {
            try
            {
                var zonas = contexto.ctl_zonas.ToList();
                return zonas;
            }
            catch(Exception ex)
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
        [Route("api/Zonas/total")]
        public List<sp_obtiene_total_ventas_Result> GetTotal()
        {
            try
            {
                var totalVentas = contexto.sp_obtiene_total_ventas().ToList();

                return totalVentas;
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

        //// GET: api/Zonas/5
        //public string Get(int id)
        //{
        //    try
        //    {
        //        var zonas = contexto.ctl_zonas.ToList();
        //        return zonas;
        //    }
        //    catch (Exception ex)
        //    {
        //        if (ex.InnerException != null)
        //        {
        //            throw new Exception(ex.InnerException.Message);
        //        }
        //        else
        //        {
        //            throw new Exception(ex.Message);
        //        }

        //    }
        //}

        //// POST: api/Zonas
        //public void Post([FromBody]string value)
        //{
        //    try
        //    {
        //        var zonas = contexto.ctl_zonas.ToList();
        //        return zonas;
        //    }
        //    catch (Exception ex)
        //    {
        //        if (ex.InnerException != null)
        //        {
        //            throw new Exception(ex.InnerException.Message);
        //        }
        //        else
        //        {
        //            throw new Exception(ex.Message);
        //        }

        //    }
        //}

        //// PUT: api/Zonas/5
        //public void Put(int id, [FromBody]string value)
        //{
        //    try
        //    {
        //        var zonas = contexto.ctl_zonas.ToList();
        //        return zonas;
        //    }
        //    catch (Exception ex)
        //    {
        //        if (ex.InnerException != null)
        //        {
        //            throw new Exception(ex.InnerException.Message);
        //        }
        //        else
        //        {
        //            throw new Exception(ex.Message);
        //        }

        //    }
        //}

        //// DELETE: api/Zonas/5
        //public void Delete(int id)
        //{
        //    try
        //    {
        //        var zonas = contexto.ctl_zonas.ToList();
        //        return zonas;
        //    }
        //    catch (Exception ex)
        //    {
        //        if (ex.InnerException != null)
        //        {
        //            throw new Exception(ex.InnerException.Message);
        //        }
        //        else
        //        {
        //            throw new Exception(ex.Message);
        //        }

        //    }
        //}
    }
}
