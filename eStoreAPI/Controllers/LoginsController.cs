using BusinessObject;
using DataAccess.Repository.IRepository;
using DataAccess.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace eStoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginsController : ControllerBase
    {
        private IMemberRepository repository = new MemberRepository();

        [HttpPost]
        public IActionResult Login(Member member)
        {
            //check login
            var temp = repository.CheckLogin(member.Email, member.Password);
            if (temp != null)
            {
                return Ok(temp);
            }
            return NotFound();
        }

        [HttpPost("checkrole")]
        public IActionResult CheckRole(Member member)
        {
            var role = repository.CheckRole(member.Email, member.Password);
            if (role != null)
            {
                return Ok(role);
            }
            return NotFound();
        }
    }
}
