using Microsoft.AspNet.Authorization;
using Microsoft.AspNet.Mvc;
using SolutionsAI.BusinessLogic.Services.Interface;
using SolutionsAI.Domain;
using SolutionsAI.Interfaces;
using SolutionsAI.Requests;
using SolutionsAI.Response;
using SolutionsAI.Response.DTOs;
using SolutionsAI.Utility;

namespace SolutionsAI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    public class GroupsController: Controller, IGroupsController
    {
        private IGroupService GroupService { get; }

        public GroupsController(IGroupService groupService)
        {
            GroupService = groupService;
        }

        [HttpPost]
        public GenericResponse<GroupDTO> CreateGroup([FromBody]NameRequest nameRequest)
        {
            return this.GetGenericResponse<Group, GroupDTO>(
                userId => GroupService.CreateGroup(nameRequest.ToCreateRequest(userId)),
                false);
        }
    }
}
