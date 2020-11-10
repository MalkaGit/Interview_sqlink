using log4net;
using sqlink.BL;
using sqlink.Common;
using sqlink.Common.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
namespace sqlink.App.Controllers
{
    public class VehicleController : ApiController
    {
        #region private prperties

        private static ILog Logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        #endregion


        //Post  api/Vehicle
        [HttpPost]
        public HttpResponseMessage Post([FromBody] Vehicle model)
        {
            try
            {
                VehicleService.Instance.Create(model);
                return Request.CreateResponse(HttpStatusCode.Created, model);
            }
            catch (BaseException e)
            {
                Logger.ErrorFormat("{0}", e.ToString());
                return Request.CreateResponse(HttpStatusCode.BadRequest, e.Message);
            }
            catch (Exception e)
            {
                Logger.ErrorFormat("{0}", e.ToString());
                return Request.CreateResponse(HttpStatusCode.InternalServerError, "Please contact admin");
            }
        }



        // GET: api/Vehicle?LiceseNumber=&Owner= ...
        [HttpGet]
        public HttpResponseMessage Get(long? LicenseNumber=null, string Owner = null)
        {
            try
            {
                var data = VehicleService.Instance.GetAll(LicenseNumber, Owner);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (BaseException e)
            {
                Logger.ErrorFormat("{0}", e.ToString());
                return Request.CreateResponse(HttpStatusCode.BadRequest, e.Message);
            }
            catch (Exception e)
            {
                Logger.ErrorFormat("{0}", e.ToString());
                return Request.CreateResponse(HttpStatusCode.InternalServerError, "Please contact admin");
            }
        }




        //Put api/Vehicle/1
        [HttpPut]
        public HttpResponseMessage Put(long id, [FromBody] Vehicle model)
        {
            try
            {
                model.LicenseNumber = id;

                var result = VehicleService.Instance.Update(model);
                if (result == true)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, model); 
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, false);
                }
            }
            catch (BaseException e)
            {
                Logger.ErrorFormat("{0}", e.ToString());
                return Request.CreateResponse(HttpStatusCode.BadRequest, e.Message);
            }
            catch (Exception e)
            {
                Logger.ErrorFormat("{0}", e.ToString());
                return Request.CreateResponse(HttpStatusCode.InternalServerError, "Please contact admin");
            }
        }





        ///PUT api/bulk/Vehicle
        [HttpPut]
        [Route("api/bulk/Vehicle")]
        public HttpResponseMessage BulkUpdate([FromBody] IEnumerable<Vehicle> models)
        {
            try
            {
                VehicleService.Instance.BulkUpdate(models);
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (BaseException e)
            {
                Logger.ErrorFormat("{0}", e.ToString());
                return Request.CreateResponse(HttpStatusCode.BadRequest, e.Message);
            }
            catch (Exception e)
            {
                Logger.ErrorFormat("{0}", e.ToString());
                return Request.CreateResponse(HttpStatusCode.InternalServerError, "Please contact admin");
            }
        }




        // DELETE: api/Vehicle/5
        public HttpResponseMessage Delete(long id)
        {
            try
            {
                var result = VehicleService.Instance.Delete(id);
                return Request.CreateResponse(HttpStatusCode.OK, result);
            }
            catch (BaseException e)
            {
                Logger.ErrorFormat("{0}", e.ToString());
                return Request.CreateResponse(HttpStatusCode.BadRequest, e.Message);
            }
            catch (Exception e)
            {
                Logger.ErrorFormat("{0}", e.ToString());
                return Request.CreateResponse(HttpStatusCode.InternalServerError, "Please contact admin");
            }
        }




        ///DELETE api/bulk/Vehicle?lisenceNumbers=1&lisenceNumbers=2
        [HttpDelete]
        [Route("api/bulk/Vehicle")]

        public HttpResponseMessage BulkDelete([FromUri]long[] lisenceNumbers)
        {
            try
            {
                VehicleService.Instance.BulkDelete(lisenceNumbers);
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (BaseException e)
            {
                Logger.ErrorFormat("{0}", e.ToString());
                return Request.CreateResponse(HttpStatusCode.BadRequest, e.Message);
            }
            catch (Exception e)
            {
                Logger.ErrorFormat("{0}", e.ToString());
                return Request.CreateResponse(HttpStatusCode.InternalServerError, "Please contact admin");
            }
        }









    }
}
