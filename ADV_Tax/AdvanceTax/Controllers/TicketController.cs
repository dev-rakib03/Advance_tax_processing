using BLL.DTOs;
using BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Management;

namespace AdvanceTax.Controllers
{
    [EnableCors("*", "*", "*")]
    //[Logged]
    public class TicketController : ApiController
    {
        [Route("api/ticket")]
        [HttpGet]
        public  HttpResponseMessage Ticket()
        {
            try
            {
                var data = TicketService.GetTicket();
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch(Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex);   
            }
        }
        [Route("api/ticket/{id}")]
        [HttpGet]
        public HttpResponseMessage Ticket(int id)
        {
            try
            {
                var data = TicketService.GetTicket(id);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch(Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }
        [Route("api/ticket/create")]
        [HttpPost]
        public HttpResponseMessage Add(TicketDTO ticket)
        {
            try
            {
                var data = TicketService.AddTicket(ticket);
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
        [Route("api/ticket/update")]
        [HttpPost]
        public HttpResponseMessage Update(TicketDTO ticket)
        {
            try
            {
                var data = TicketService.UpdateTicket(ticket);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch(Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }
        [Route("api/ticket/delete/{id}")]
        [HttpGet]
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                var data = TicketService.DeleteTicket(id);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch(Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }
    }
}
