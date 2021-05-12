using ChatApi.Infrastructure.Models;
using ChatApi.Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ChatApi.Controllers
{
    public class GroupController
    {

        private readonly IGroupService _groupService;


        public GroupController(IGroupService groupService)
        {
            _groupService = groupService;
        }


        [HttpGet]
        [Route("/GetAll")]
        public async Task<ActionResult<Group>> GetGroups()
        {
            var groups = await _groupService.GetGroups();
            return Ok(groups);
        }

        [HttpPost]
        [Route("/register")]
        public ActionResult AddGroup(Group group)
        {
            _groupService.AddGroup(group);
            return Ok();
        }

        [HttpPut]
        [Route("/remove")]
        public ActionResult RemoveGroup(int id)
        {
            _groupService.RemoveGroup(id);
            return Ok();
        }
    }
}
