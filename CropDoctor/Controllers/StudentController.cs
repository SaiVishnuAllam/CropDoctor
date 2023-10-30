﻿using CropDoctor.Services.Core.StudentDetails.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CropDoctor.Service.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IDetailsService _detailsService;

        public StudentController(IDetailsService detailsService)
        {
            _detailsService = detailsService;
        }

        // GET api/<StudentController>/5
        /// <summary>
        /// Api to get Student Details using Student Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> StudentDetails(ObjectId studentId)
        {
            await _detailsService.GetDetails(studentId);
            return Ok();
        }          
    }
}