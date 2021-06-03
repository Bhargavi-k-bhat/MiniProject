
using LimeLemon.DataAccessLayer;
using LimeLemon.Models;
using LimeLemon.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LimeLemon.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        public ProductServices services = null;
        public ProductController()
        {
            services = new ProductServices();
        }
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(services.GetProducts());

            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
        
        [HttpGet("GetByName/{itemName}")]
        public IActionResult GetProductByName(string itemName)
        {
            

                return Ok(services.getProductByName(itemName));

            
           
        }
        [HttpPost("AddProduct")]
        public IActionResult Post(Product product)
        {
            
                services.addProduct(product);
                return Ok("Records added");

            
            /*catch (Exception ex)
            {
                return NotFound(ex.Message);
            }*/
        }
        [HttpDelete("DeleteByName/{name}")]
        public IActionResult Delete(string name)
        {
            try
            {
                services.deleteByName(name);
                return Ok("Records deleted");

            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
        [HttpPut("UpdateByName")]
        public IActionResult Update(Product product)
        {
            try
            {
                services.updateProductByName(product);
                return Ok("records updated");

            }
            catch(Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
