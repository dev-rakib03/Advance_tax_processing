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
    public class RoleController : ApiController
    {
        [Route("api/roles")]
        [HttpGet]
        public HttpResponseMessage Roles()
        {
            try
            {
                var data = RoleService.GetRole();
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }
        [Route("api/roles/{id}")]
        [HttpGet]
        public HttpResponseMessage Roles(int id)
        {
            try
            {
                var data = RoleService.GetRole(id);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }
        [Route("api/roles/create")]
        [HttpPost]
        public HttpResponseMessage Add(RoleDTO role)
        {
            try
            {
                var data = RoleService.AddRole(role);
                if (data != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, data);
                }
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
            return Request.CreateResponse(HttpStatusCode.BadRequest, new { });
        }
        [Route("api/roles/update")]
        [HttpPost]
        public HttpResponseMessage Update(RoleDTO role)
        {
            try
            {
                var data = RoleService.UpdateRole(role);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }
        [Route("api/roles/delete/{id}")]
        [HttpGet]
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                var data = RoleService.DeleteRole(id);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }
    }
}
