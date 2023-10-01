using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Test.NetEF.SqlLite.Data;

namespace Test.NetEF.SqlLite.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly AppDbContext _appDbContext;

        public EmployeeController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
    }
}
