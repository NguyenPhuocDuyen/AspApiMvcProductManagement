using BusinessObject;
using DataAccess.Repository.IRepository;
using DataAccess.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace eStoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategorysController : ControllerBase
    {
        private ICategoryRepository repository = new CategoryRepository();
        // GET: api/<CategorysController>
        [HttpGet]
        public ActionResult<IEnumerable<Category>> GetCategorys() => repository.GetCategories();

    }
}
