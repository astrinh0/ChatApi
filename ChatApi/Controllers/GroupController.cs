using ChatApi.Infrastructure.Models;
using ChatApi.Infrastructure.Models.Enums;
using ChatApi.Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;
using System;
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
            try
            {
                var groups = await _groupService.GetGroups();
                return Ok(groups);
            }
            catch (Exception ex)
            {

                return Json(ex);
            }
            
        }

        [HttpPost]
        [Route("/AddGroup")]
        public ActionResult AddGroup(EnumTypeGroup type)
        {
            try
            {
                _groupService.AddGroup(type, User.Identity.Name);
                return Ok();
            }
            catch (Exception ex)
            {

                return Json(ex);
            }
          
        }

        [HttpPut]
        [Route("/RemoveGroup")]
        public ActionResult RemoveGroup(int id)
        {
            try
            {
                _groupService.RemoveGroup(id);
                return Ok();
            }
            catch (Exception ex)
            {

                return Json(ex);
            }

        }
    }
}
