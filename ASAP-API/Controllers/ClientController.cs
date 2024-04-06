﻿using ASAP_Application.Services.CientService;
using ASAP_DTO;
using ASAP_DTO.ClientDTO;
using ASAP_Models;
using Microsoft.AspNetCore.Mvc;

namespace ASAP_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly IClientService clientService;
        public ClientController(IClientService _clientService)
        {
            clientService = _clientService;
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



        [HttpGet("{items},{page}")]
        public async Task<IActionResult> GetAllProduct(int items, int page)
        {
            try
            {
                var QueryAllProducts = await clientService.GetAllPagination(items, page);
                if (QueryAllProducts == null || QueryAllProducts.Count == 0)
                {
                    return NotFound("No Products Found !!");
                }
                return Ok(QueryAllProducts);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
