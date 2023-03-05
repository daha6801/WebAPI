using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Data;
using System.Data.SqlClient;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [Produces("application/json")]
    [Route("api/Products")]
    [ApiController]
    public class ArtProductController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        JsonSerializer serializer = new JsonSerializer();

        public ArtProductController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        [Route("~/api/GetProducts")]
        public List<ArtProduct> Get()
        {
            List<ArtProduct> artList = new List<ArtProduct>();

            string query = @"select artId, ArtName, ArtDesc, ArtPrice, ArtDimensions, ArtScore, isAvailable, ImgBytes from [ArtProductDB].[dbo].[ArtProduct]";
            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("ArtProductAppCon");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    string JsonResponse = string.Empty;
                    JsonResponse = JsonConvert.SerializeObject(table);
                    artList = JsonConvert.DeserializeObject<List<ArtProduct>>(JsonResponse);

                    myReader.Close();
                    myCon.Close();
                }
            }

            return artList;
        }

        [HttpPost]
        [Route("~/api/PostProducts")]
        public JsonResult Post([FromForm] ArtProduct prod)
        {

            string query = @" insert into dbo.ArtProduct values ('" + prod.ArtName + "','" + prod.ArtDesc + "','" + prod.ArtPrice + "','" + prod.ArtDimensions + "','" + prod.ArtScore + "','"+ prod.isAvailable + "', CAST('" + prod.imgFile + @"' AS VARBINARY(MAX)))";
            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("ArtProductAppCon");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader); ;

                    myReader.Close();
                    myCon.Close();
                }
            }

            return new JsonResult("Added Successfully");
        }
    }
}
