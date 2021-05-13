using ChatApi.Infrastructure.Models;
using ChatApi.Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ChatApi.Controllers
{
    
    [Route("[controller]")]
    [ApiController]
    public class GroupController : Controller
    {

        private readonly IGroupService _groupService;


        public GroupController(IGroupService groupService)
        {
            _groupService = groupService;
        }


        [HttpGet]
        [Route("/GetAllGroups")]
        public async Task<ActionResult<Group>> GetGroups()
        {
            var groups = await _groupService.GetGroups();
            return Ok(groups);
        }

        [HttpPost]
        [Route("/AddGroup")]
        public ActionResult AddGroup(Group group)
        {
            _groupService.AddGroup(group);
            return Ok();
        }

        [HttpPut]
        [Route("/RemoveGroup")]
        public ActionResult RemoveGroup(int id)
        {
            _groupService.RemoveGroup(id);
            return Ok();
        }
    }
}
