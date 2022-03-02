using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Serilog;
using ShoppingBL;
using ShoppingModel;

namespace ShoppingApi.Controllers
{
    [Route("apiv2/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerBL _customerBL;
        private readonly IOrderBL _orderBL;


        public CustomerController(ICustomerBL b_customerBL, IOrderBL b_orderBL)
        {
            _customerBL = b_customerBL;
            _orderBL = b_orderBL;
        }

    

       [HttpPost("Register")]
       public IActionResult AddCustomer([FromBody] NewCustomer b_customer)
        {
             try
            {
                Log.Information("Customer successfully registered");
                return Created("Customer successfully registered", _customerBL.AddCustomer(b_customer));
                
            }
            catch(System.Exception ex)
            {
                return Conflict(ex.Message);
            }
          
        }
        

         [HttpPost("Login")]
       public IActionResult Login([FromBody] CustomerLogin b_customer)
        {
             try
            {
                return Created("Successfully login", _customerBL.Login(b_customer));
            }
            catch(System.Exception ex)
            {
                return Conflict(ex.Message);
            }
          
        }
        



    // POST: api/Customer/Orders
    [HttpPost("PlaceOrder{CustomerID}")]
    public async Task<IActionResult> PlaceOrder2(Guid CustomerID, [FromBody] Order b_order)
    {
      try
      {
        b_order.CustomerID = CustomerID;
        return Created("Succesfully created new order!", await _orderBL.PlaceOrder(b_order));
      }
      catch (Exception e)
      {
        Log.Warning("Error while placing order");
        Log.Warning(e.Message);
        return StatusCode(500, e);
      }
    }




        [HttpGet("CustomerOrderHistory")]
        public async Task<IActionResult> GetAllOrdersByCustomerID([FromQuery] Guid b_customerID)
        {
        try
        {
          return Ok(await _orderBL.GetAllOrdersByCustomerID(b_customerID));
        }
          catch (Exception e)
        {
        
        Log.Warning(e.Message);
        return NotFound(e.Message);
        }
        }




        // PUT: api/Shopping/5
       [HttpPut("Update Customer Info")]
        public IActionResult Put(string Email, [FromBody] ReturningCustomer b_customer)
        {
            b_customer.CustomerEmail = Email;

              try
            {
                return Ok(_customerBL.UpdateCustomer(b_customer));
            }
            catch(System.Exception ex)
            {
                return Conflict(ex.Message);
            }
        }
    }
}
