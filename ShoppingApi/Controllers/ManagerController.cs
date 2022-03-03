using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShoppingBL;
using ShoppingModel;
using Serilog;

namespace ShoppingApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ManagerController : ControllerBase
    {

        private readonly ICustomerBL _customerBL;
        private readonly IAdminBL _adminBL;
        private readonly IStoreBL _storeBL;
        private readonly IProductBL _productBL;
        private readonly IOrderBL _orderBL;


        public ManagerController(ICustomerBL b_customerBL, IAdminBL adminBL, IStoreBL storeBL, IProductBL productBL, IOrderBL orderBL)
        {
            _customerBL = b_customerBL;
            _adminBL = adminBL;
            _storeBL = storeBL;
            _productBL = productBL;
            _orderBL = orderBL;
        }


        [HttpPost("Register")]     
        public IActionResult AddAdmin([FromBody] Admin b_admin)
        {
             try
            {
                return Created("Admin successfully registered", _adminBL.AddAdmin(b_admin));
                
            }
            catch(System.Exception ex)
            {
                return Conflict(ex.Message);
            }
          
        }

         [HttpPost("Login")]
        public IActionResult Login([FromBody] AdminLogin b_admin)
        {
             try
            {
                return Created("Successfully login", _adminBL.Login(b_admin));
            }
            catch(System.Exception ex)
            {
                return Conflict(ex.Message);
            }
          
        }

        // GET: api/Manager
        
        [HttpGet("GetAllAdmin")]
        public IActionResult GetAllAdmin()
        {
            try
            {
                return Ok(_adminBL.GetAllAdmin());
            }
            catch(SqlException)
            {
                return NotFound();
            }  
        }


        [HttpGet("SearchCustomer")]
        public IActionResult SearchCustomer(string p_name)
        {
            try
            {
                return Ok(_customerBL.SearchCustomer(p_name));
            }
            catch(System.Exception)
            {
                return NotFound();
            }
        }


          [HttpGet("GetAllCustomer")]
        public IActionResult GetAllCustomer()
        {
            try
            {
                return Ok(_customerBL.GetAllCustomerOld());
            }
            catch(SqlException)
            {
                return NotFound();
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


        [HttpGet("GetAllOrderByPrice")]
        public IActionResult GetOrderbyPrice()
        {
            try
            {
                return Ok(_orderBL.GetOrderbyPrice());
            }
            catch(SqlException)
            {
                return NotFound();
            }  
        }



        // GET: api/Manager/5
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
        return NotFound(e);
        }
        }



        [HttpGet("StoreOrderHistory")]
        public async Task<IActionResult> GetAllOrdersByStoreID([FromQuery] Guid b_storeID)
        {
        try
        {
          return Ok(await _orderBL.GetAllOrdersByStoreID(b_storeID));
        }
          catch (Exception e)
        {
        
        Log.Warning(e.Message);
        return NotFound(e);
        }
        }


         // DELETE: api/Shopping/5
        [HttpDelete("DeleteCustomer{id}")]
        public IActionResult Delete(Guid id, [FromBody] ReturningCustomer b_customer)
        {
            b_customer.CustomerID = id;
              try
            {
                return Created("Successfully delete", _customerBL.DeleteCustomer(b_customer));
            }
            catch(System.Exception ex)
            {
                return Conflict(ex.Message);
            }
        }
        
    }
}
