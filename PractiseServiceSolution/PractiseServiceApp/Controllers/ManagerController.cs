using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PractiseServiceApp.Interfaces;

namespace PractiseServiceApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ManagerController : ControllerBase
    {
        IManager _mng1;
        IManager _mng2;

        public ManagerController(IManager mng1, IManager mng2)
        {
            _mng1 = mng1;
            _mng2 = mng2;
        }
        [HttpGet]
        public ActionResult Index()
        {
            string gid1 = _mng1.Generateguid().ToString();
            string gid2 = _mng2.Generateguid().ToString();


            List<string> emplist = _mng1.GetManagerlist();
            return Ok(emplist);
        }

    }
}
