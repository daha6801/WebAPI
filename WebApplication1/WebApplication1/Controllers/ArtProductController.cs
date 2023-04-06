using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Data;
using System.Data.SqlClient;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class ArtProductController : ControllerBase
    {

        private readonly AppDbContext _context;

        public ArtProductController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public List<ArtProduct> Get()
        {
            List<ArtProduct> artList = new List<ArtProduct>();

            try {
                artList = _context.ArtProducts.ToList();
            }
            catch{
                return null; // An error occured
            }

            return artList;
        }

        [HttpGet("{id:Guid}")]
        public ArtProduct Get(Guid id)
        {
            ArtProduct artProduct = new ArtProduct();

            try
            {
                artProduct = _context.ArtProducts.First(a => a.ArtId == id);
            }
            catch
            {
                return null; // An error occured
            }

            return artProduct;
        }

        [HttpPost]
        public string Post([FromForm] ArtProduct prod)
        {

            using (MemoryStream memoryStream = new MemoryStream())
            {
                prod.imgFile.CopyTo(memoryStream);
                prod.imgBytes = memoryStream.ToArray();
            }

            try
            {
                _context.ArtProducts.Add(prod);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                return null; // An error occured
            }

            return "Added Successfully";
        }

        [HttpPut]
        public string Put([FromForm] ArtProduct prod)
        {

            using (MemoryStream memoryStream = new MemoryStream())
            {
                prod.imgFile.CopyTo(memoryStream);
                prod.imgBytes = memoryStream.ToArray();
            }

            try
            {
                ArtProduct product = _context.ArtProducts.Find(prod.ArtId);
                if (product != null)
                {

                    // Make changes on entity
                    product.ArtName = prod.ArtName;
                    product.ArtDesc = prod.ArtDesc;
                    product.ArtPrice = prod.ArtPrice;
                    product.ArtScore = prod.ArtScore;
                    product.isAvailable = prod.isAvailable;
                    product.ArtDimensions = prod.ArtDimensions;
                    product.imgBytes = prod.imgBytes;
                }
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                return null; // An error occured
            }

            return "Updated Successfully";
        }

        [HttpDelete("{id:Guid}")]
        public string Delete(Guid id)
        {
            ArtProduct artProduct = new ArtProduct();

            try
            {
                artProduct = _context.ArtProducts.First(a => a.ArtId == id);
                _context.Remove(artProduct);
                _context.SaveChanges();
            }
            catch
            {
                return null; // An error occured
            }

            return "Deleted successfully";
        }
    }
}
