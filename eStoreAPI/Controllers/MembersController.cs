using BusinessObject;
using DataAccess.Repository.IRepository;
using DataAccess.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace eStoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MembersController : ControllerBase
    {
        private IMemberRepository repository = new MemberRepository();
        // GET: api/<MembersController>
        [HttpGet]
        public ActionResult<IEnumerable<Member>> GetMembers() => repository.GetMembers();

        // GET api/<MembersController>/5
        [HttpGet("{id}")]
        public ActionResult<Member> Get(int id)
        {
            var p = repository.GetMemberById(id);
            if (p == null)
            {
                return NotFound();
            }
            return Ok(p);
        }

        [HttpPost]
        public IActionResult PostMember(Member member)
        {
            var list = repository.GetMembers();
            var m = list.Where(m => m.Email.Equals(member.Email)).FirstOrDefault();
            if (m != null)
            {
                return BadRequest();
            }
            repository.SaveMember(member);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteMember(int id)
        {
            var p = repository.GetMemberById(id);
            if (p == null)
            {
                return NotFound();
            }
            repository.DeleteMember(p);
            return NoContent();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateMember(int id, Member member)
        {
            var temp = repository.GetMemberById(id);
            if (temp == null)
            {
                return NotFound();
            }
            repository.UpdateMember(member);
            return NoContent();
        }
    }
}
