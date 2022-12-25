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
    //[Logged]
    public class IncomeController : ApiController
    {
        [Route("api/income")]
        [HttpGet]
        public HttpResponseMessage Income()
        {
            try
            {
                var data = IncomeService.GetIncome();
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch(Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex);
            }
        }
        [Route("api/income/{id}")]
        [HttpGet]
        public HttpResponseMessage Income(int id)
        {
            try
            {
                var data = IncomeService.GetIncome(id);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch(Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }
        [Route("api/income/create")]
        [HttpPost]
        public HttpResponseMessage Add(IncomeDTO income)
        {
            try
            {
                var data = IncomeService.AddIncome(income);
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
        [Route("api/income/update")]
        [HttpPost]
        public HttpResponseMessage Update(IncomeDTO income)
        {
            try
            {
                var data = IncomeService.UpdateIncome(income);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch(Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }
        [Route("api/income/delete/{id}")]
        [HttpGet]
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                var data = IncomeService.DeleteIncome(id);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch(Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }
    }
}
