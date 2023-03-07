using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Data;
using System.Data.SqlClient;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [Produces("application/json")]
    [Route("api/Products")]
    [ApiController]
    public class ArtProductController : ControllerBase
    {

        private readonly AppDbContext _context;

        public ArtProductController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("~/api/GetProducts")]
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


        [HttpPost]
        [Route("~/api/PostProducts")]
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
    }
}
