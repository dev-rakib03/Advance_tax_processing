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
    public class PaymentController : ApiController
    {
        [Route("api/payment")]
        [HttpGet]
        public HttpResponseMessage Payment()
        {
            try
            {
                var data = PaymentService.GetPayment();
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch(Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }
        [Route("api/payment/{id}")]
        [HttpGet]
        public HttpResponseMessage Payment(int id)
        {
            try
            {
                var data = PaymentService.GetPayment(id);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch(Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }
        [Route("api/payment/create")]
        [HttpPost]
        public HttpResponseMessage Add(PaymentDTO payment)
        {
            try
            {
                var data = PaymentService.AddPayment(payment);
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
        [Route("api/payment/update")]
        [HttpPost]
        public HttpResponseMessage Update(PaymentDTO payment)
        {
            try
            {
                var data = PaymentService.UpdatePayment(payment);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch(Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }
        [Route("api/payment/delete/{id}")]
        [HttpGet]
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                var data = PaymentService.DeletePayment(id);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch(Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }
        
    }
}
