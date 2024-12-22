﻿using CinemaHub_BLL.DTO.Cinema;
using CinemaHub_BLL.Services.CinemaService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CinemaHub.Controllers
{

    [Route("api/[Controller]")]
    [ApiController]
    public class CinemaController : GenericController<CinemaDTO>
    {
       private readonly iCinemaService _iCinemaService;

        public CinemaController(iCinemaService iCinemaService) : base(iCinemaService) 
        {
            _iCinemaService = iCinemaService;
        }
        [HttpPost("addCinema")]
        public async Task<IActionResult> AddCinema([FromBody] CinemaDTO cinemaDto)
        {
            try
            {
                await _iCinemaService.AddCinemaWithAdminAsync(cinemaDto);
                return Ok(new { message = "Cinema added successfully" });
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "An unexpected error occurred.", details = ex.Message });
            }
        }



        [HttpGet("{cinemaId}/admin")]
        public async Task<IActionResult> GetCinemaAdmin(int cinemaId)
        {
            var adminDto = await _iCinemaService.GetCinemaAdminDtoAsync(cinemaId);
            if (adminDto == null)
            {
                return NotFound(new { message = "Admin not found for the specified cinema." });
            }
            return Ok(adminDto);
        }
    }
}