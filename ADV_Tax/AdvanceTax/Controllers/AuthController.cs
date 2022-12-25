using BLL.DTOs;
using BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace AdvanceTax.Controllers
{
    [EnableCors("*", "*", "*")]
    public class AuthController : ApiController
    {
        [Route("api/login")]
        [HttpPost]
        public HttpResponseMessage Login(LoginDTO login)
        {
            if(login == null)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Email or Password not supplied");
            }
            if(ModelState.IsValid)
            {
                var token = AuthService.Authenticate(login.Email, login.Password);
                if (token != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, token);
                }
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Email or Password Invalid");
            }
            return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
        }
    }
}
