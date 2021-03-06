 using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using ShoppingBL;
using ShoppingModel;

namespace ShoppingApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StoreController : ControllerBase
    {
        private readonly IStoreBL _storeBL;
        private readonly IOrderBL _orderBL;
        private readonly IInventoryBL _invenBL;
        private readonly IProductBL _productBL;

        public StoreController(IStoreBL b_storeBL, IOrderBL b_orderBL, IInventoryBL b_invenBL, IProductBL b_productBL)
        {
            _storeBL = b_storeBL;
            _orderBL = b_orderBL;
            _invenBL = b_invenBL;
            _productBL = b_productBL;
        }



        [HttpPost("Add Store")]
        public async Task<IActionResult> AddNewStore(StoreFront b_store)
        {
             try
            {
                return Created("Store successfully added", await _storeBL.AddNewStoreFront(b_store));
            }
            catch(Exception e)
            {
                Log.Warning("Could not add store");
               Log.Warning(e.Message);
               return NotFound(e);
            }
          
        }

        [HttpGet("Get All Store")]
        public async Task<IActionResult> GetAllStore()
        {
       try
       {
        Log.Information("List of all store");
        return Ok(await _storeBL.GetAllStore());
       }
       catch (Exception e)
       {
        Log.Warning("Could not show store");
        Log.Warning(e.Message);
        return NotFound(e);
       }
      }

    [HttpGet("Search Store")]
    public async Task<IActionResult> GetStoreByStoreID([FromQuery] Guid b_storeID)
    {
      try
      {
        Log.Information("Searching store");
        return Ok(await _storeBL.GetStoreByID(b_storeID));
      }
      catch (Exception e)
      {
        Log.Warning(e.Message);
        return NotFound(e);
      }
    }

    [HttpPut("Update Store")]
    public async Task<IActionResult> UpdateStore( StoreFront b_store)
    {
      try
      {
        Log.Information("Updating store");
        return Accepted(await _storeBL.UpdateStore(b_store));
      }
      catch (Exception e)
      {
        Log.Warning(e.Message);
        return StatusCode(406, e);
      }
    }


      [HttpGet("GetProductByStoreID")]
        public IActionResult GetProductByStoreID( Guid b_store)
        {
            try
            {
                return Ok(_productBL.GetProductByStoreID(b_store));
            }
             catch (Exception e)
      {
        Log.Warning(e.Message);
        return NotFound(e);
      }
        }




     [HttpPost("Add Inventory")]
           public async Task<IActionResult> AddInventory([FromBody] Inventory b_inven)
          {
          Task taskImportProduct = _invenBL.AddInventory(b_inven);
          try
          {
           await taskImportProduct;
           return Ok(new { Results = "Imported new product successfully!" });
          }
          catch (Exception e)
         {
         Log.Warning(e.Message);
         return BadRequest(new { Results = "This Product is already in the store's inventory" });
         }
    }


        [HttpGet("Get All Inventory")]
        public async Task<IActionResult> GetAllInventory([FromQuery] Guid b_storeID)
        {
            try
            {
                return Ok(await _invenBL.GetAllInventory());
            }
            catch(Exception e)
            {
                Log.Warning(e.Message);
                return NotFound(e);
            }  
        }

        [HttpPut("ReplenishInventory Inventory")]
         public async Task<IActionResult> ReplenishInventoryByID([FromBody] Inventory b_inven)
         {
             try
             {
                 await _invenBL.ReplenishInventoryByID(b_inven);
                 return Ok();
             }
             catch (Exception e)
            {
            Log.Warning(e.Message);
            return StatusCode(406, e);
            }
         }
    }
}