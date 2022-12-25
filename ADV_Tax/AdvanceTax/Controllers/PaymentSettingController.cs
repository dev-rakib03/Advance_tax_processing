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
    public class PaymentSettingController : ApiController
    {
        [Route("api/paymentSetting")]
        [HttpGet]
        public HttpResponseMessage PaymentSetting()
        {
            try
            {
                var data = PaymentSettingService.GetPaymentSetting();
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch(Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }
        [Route("api/paymentSetting/{id}")]
        [HttpGet]
        public HttpResponseMessage PaymentSetting(int id)
        {
            try
            {
                var data = PaymentSettingService.GetPaymentSetting(id);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch(Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }
        [Route("api/paymentSetting/create")]
        [HttpPost]
        public HttpResponseMessage Add(PaymentSettingDTO payment)
        {
            try
            {
                var data = PaymentSettingService.AddPaymentSetting(payment);
                if (data != null)
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
        [Route("api/paymentSetting/update")]
        [HttpPost]
        public HttpResponseMessage Update(PaymentSettingDTO payment)
        {
            try
            {
                var data = PaymentSettingService.UpdatePaymentSetting(payment);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch(Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }
        [Route("api/paymentSetting/delete/{id}")]
        [HttpGet]
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                var data = PaymentSettingService.DeletePaymentSetting(id);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch(Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }
    }
}
