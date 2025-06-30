using EntitySql_4.Data;
using EntitySql_4.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EntitySql_4.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly AppDbContext _appDbContext;
        
    
        public ProductController(AppDbContext appDbContext)   
        {      
            _appDbContext = appDbContext;
        }

        [HttpGet]

        public IActionResult GetAll()
        {
         var Readed= _appDbContext.Details.Include(s=>s.Student).ToList();
              return Ok(Readed);
        }
    }
}
