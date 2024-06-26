﻿using ASAP_Application.Services.APIService;
using ASAP_Application.Services.CientService;
using ASAP_Application.Services.EmailService;
using ASAP_Application.Services.Hangifure;
using ASAP_DTO;
using ASAP_DTO.ClientDTO;
using ASAP_Models;
using Hangfire;
using Microsoft.AspNetCore.Mvc;

namespace ASAP_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly IClientService clientService;
        private readonly IJobService jobService;
        private readonly IBackgroundJobClient backgroundJobClient;
        private readonly IRecurringJobManager _recurringJobManager;
        private readonly IApiService apiService;
        
        private readonly IEmail emailService;
        public ClientController(
                                IClientService _clientService,
                                IEmail _emailService,
                                IApiService _apiService
                               )
        {
            clientService = _clientService;
        
            emailService = _emailService;
            apiService= _apiService; ;

        }
        [HttpGet("/FireAndForgetJob")]
        public async Task<ActionResult> CreateFireAndForgetJob()
        {
            //RecurringJob.AddOrUpdate("FirstJob", () => jobService.ReccuringJob(), Cron.Minutely);
            // RecurringJob.AddOrUpdate("csc", () => apiService.GetDataAsync(), Cron.Minutely);
            // Schedule the second job to run every minute, dependent on the first job
            // RecurringJob.AddOrUpdate("SecondJob", () => jobService.ContinuationJob(), Cron.Minutely);
            var response =await  apiService.GetDataAsync();
            return Ok();
        }



        [HttpPost("create")]
        public async Task<IActionResult> create([FromBody]CreateClientDto client)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            var result = await clientService.CreateClient(client);

            return Ok(result);
          
        }


        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetByID(int id)
        {
            try
            {
                var QueryProduct = await clientService.GetById(id);
                if (QueryProduct == null)
                {
                    return NotFound();
                }
                return Ok(QueryProduct);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await clientService.DeleteClient(id);
            if (result.status == true)
            {
                return Ok(result);
            }
            else
            {
                return NotFound(result);
            }
        }


        [HttpPost("update")]
        public async Task<IActionResult> update([FromBody] CreateClientDto client)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await clientService.UpdateClient(client);

            return Ok(result);
        }



        [HttpGet("{skip},{take}")]
        public async Task<IActionResult> GetAllClients(int skip, int take)
        {
            try
            {
                var QueryAllClients = await clientService.GetAllPagination(skip, take);
                if (QueryAllClients == null || QueryAllClients.total == 0)
                {
                    return NotFound("No Client Found !!");
                }
                return Ok(QueryAllClients);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public async Task<IActionResult> SearchByName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                return BadRequest("Name parameter is required.");
            }

            // Invoke the repository method to search by name
            var searchResults = await clientService.GetByName(name);

            // Return the search results to the client
            return Ok(searchResults);
        }



    }
}
