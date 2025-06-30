using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SQLADO_3.Model;
using SQLADO_3.Services;

namespace SQLADO_3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployController : ControllerBase
    {
        private readonly IEmployee _employee;


         public EmployController( IEmployee employee )
        {
            _employee = employee;
        }

        [HttpGet]
        public IActionResult GETALL()
        {
            var read=_employee.Get();

            return Ok(read);
        }
        [HttpPost]         
         public IActionResult Create(EMPLOYMODEL mPLOYMODEL)
        {
            var Write = _employee.CREATING(mPLOYMODEL);
            if (Write == null) return BadRequest();
            return Ok(Write);
        }
        

    }
}
