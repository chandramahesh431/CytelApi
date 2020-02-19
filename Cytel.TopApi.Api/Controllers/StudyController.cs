﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Cytel.Top.Model;
using Cytel.Top.Repository;


namespace Cytel.Top.Api.Controllers
{
    //[Route("api/[controller]")]
    [ApiController]
    public class StudyController : ControllerBase
    {
        private readonly StudyRepository customerRepository;
        public StudyController(IConfiguration configuration)
        {
            customerRepository = new StudyRepository(configuration);
        }

       
        [HttpGet]
        [Route("Cytel/GetAll")]
        public IEnumerable<Study> GetAll()
        {
            IEnumerable<Study> listAll = customerRepository.FindAll();
            return listAll;
        }
        [HttpGet]
        [Route("Cytel/GetById")]
        public Study GetById(int id)
        {
            Study _input = customerRepository.FindByID(id);
            return _input;
        }

        [HttpPost]
        [Route("Cytel/PostInput")]
        public void PostInput(Study _input)
        {
            customerRepository.Add(_input);
        }
    }
}