using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebApi.Models;
using WebApi.Repositories;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomersRepository _customersRepository;

        public CustomersController(ICustomersRepository customersRepository)
        {
            _customersRepository = customersRepository;
        }

        [HttpGet("GetCustomer/{id}", Name = "GetCustomer")]
        public ActionResult<Customer> GetCustomer(int id)
        {
            var customer = _customersRepository.GetCustomer(id);
            return Ok(customer);
        }

        [HttpPost("CheckLogin")]
        public ActionResult<bool> CheckLogin([FromBody] Login login)
        {
            var isValidUser = _customersRepository.CheckLogin(login.Username,login.Password);
            return Ok(isValidUser);
        }

        [HttpPost("ChangePassword")]
        public ActionResult<bool> ChangePassword([FromBody] Login login)
        {
            return Ok(_customersRepository.ChangePassword(login.Username, login.Password));
        }

        [HttpGet("ForgotPassword/{email}", Name = "ForgotPassword")]
        public ActionResult<bool> ForgotPassword(string email)
        {
            return Ok(_customersRepository.ForgotPassword(email));
        }

        [HttpPost("CreateCustomer")]
        public ActionResult<bool> CreateCustomer([FromBody]Customer customer)
        {
            return Ok(_customersRepository.CreateCustomer(customer));
        }

        [HttpPost("UpdateCustomer")]
        public ActionResult<bool> UpdateCustomer([FromBody]Customer customer)
        {
            return Ok(_customersRepository.UpdateCustomer(customer));
        }


    }
}
