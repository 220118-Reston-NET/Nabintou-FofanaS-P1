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
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {

        //private static Product _product = new Product();
        private readonly ICustomerBL _customerBL;
        private readonly IOrderBL _orderBL;
        private readonly IProductBL _productBL;
        private readonly ILineItemBL _lineitemBL;
        public CustomerController(ICustomerBL b_customerBL, IOrderBL b_orderBL, IProductBL b_productBL, ILineItemBL b_lineitemBL)
        {
            _customerBL = b_customerBL;
            _orderBL = b_orderBL;
            _productBL = b_productBL;
            _lineitemBL = b_lineitemBL;
        }



        [HttpPost("Register/{Name}/{Address}/{Email}/{Username}/{Password}")]
       public IActionResult AddCustomer(string Name, string Address, string Email, string Username, string Password,[FromBody] NewCustomer b_customer)
        {
          b_customer.CustomerID = new Guid();
          b_customer.CustomerName = Name;
          b_customer.CustomerAddress = Address;
          b_customer.CustomerUsername = Username;
          b_customer.CustomerEmail = Email;
          b_customer.CustomerPassword = Password;
             try
            {
                return Created("Customer successfully registered", _customerBL.AddCustomer(b_customer));
                //Log.Information("Customer successfully registered");
            }
            catch(System.Exception ex)
            {
                return Conflict(ex.Message);
            }
          
        }
        

         [HttpPost("Login/{Username}/{Password}")]
       public IActionResult Login(string Username, string Password, [FromBody] CustomerLogin b_customer)
        {
            b_customer.CustomerUsername = Username;
            b_customer.CustomerPassword = Password;
             try
            {
                return Created("Successfully login", _customerBL.Login(b_customer));
                //Log.Information("Customer successfully registered");
            }
            catch(System.Exception ex)
            {
                return Conflict(ex.Message);
            }
          
        }



        [HttpGet("GetAllProduct")]
        public IActionResult GetAllProduct()
        {
            try
            {
                return Ok(_productBL.GetAllProduct());
            }
            catch(SqlException)
            {
                return NotFound();
            }  
        }


        // POST: api/Customer/Orders
        [HttpPost("PlaceOrder")]
      public async Task<IActionResult> PlaceOrder2([FromBody] Order b_order)
      {
      try
      {
        return Created("Succesfully created new order!", await _orderBL.PlaceOrder(b_order));
      }
      catch (Exception e)
      {
        Log.Warning("Error while placing order");
        Log.Warning(e.Message);
        return Conflict(e.Message);
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
        Log.Warning("Error while getting order history");
        Log.Warning(e.Message);
        return Conflict(e.Message);
        }
        }




        // PUT: api/Shopping/5
       [HttpPut("UpdateCustomerInfoUsingCustomerID")]
            public IActionResult Put([FromQuery] ReturningCustomer b_customer)
            {
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
