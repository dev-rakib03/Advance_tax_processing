using BLL.DTOs;
using BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AdvanceTax.Controllers
{
    public class SettingController : ApiController
    {
        [Route("api/setting")]
        [HttpGet]
        public HttpResponseMessage Setting()
        {
            try
            {
                var data = SettingService.GetSetting();
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch(Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex);
            }
        }
        [Route("api/setting/{id}")]
        [HttpGet]
        public HttpResponseMessage Setting(int id)
        {
            try
            {
                var data = SettingService.GetSetting(id);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch(Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }
        [Route("api/setting/create")]
        [HttpPost]
        public HttpResponseMessage Add(SettingDTO setting)
        {
            try
            {
                var data = SettingService.AddSetting(setting);
                if(data != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, data);
                }
            }
            catch(Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
            return Request.CreateResponse(HttpStatusCode.BadRequest, new { });
        }
        [Route("api/setting/update")]
        [HttpPost]
        public HttpResponseMessage Update(SettingDTO setting)
        {
            try
            {
                var data = SettingService.UpdateSetting(setting);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }
        [Route("api/setting/delete/{id}")]
        [HttpGet]
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                var data = SettingService.DeleteSetting(id);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch(Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }
        
    }
}
