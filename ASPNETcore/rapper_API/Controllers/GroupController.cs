using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using JsonData;

namespace MusicApi.Controllers {
    public class GroupController : Controller {
        List<Group> allGroups {get; set;}
        List<Artist> allArtists;

        public GroupController() 
        {
            allGroups = JsonToFile<Group>.ReadJson();
            allArtists = JsonToFile<Artist>.ReadJson();
        }
        [Route("groups")]
        [HttpGet]
        public JsonResult Groups(bool listArtists = false)
        {
            return Json(allGroups);
        }
        [Route("groups/name/{name}/{display}")]
        [HttpGet]
        public JsonResult groupName(string name, bool display = false)
        {
            if(display ==true)
            {
                // var groupName = allGroups.Where(group => group.GroupName == $"{name}").Join(allArtists, group => group.Id, artist => artist.GroupId, (group, artist) => 
                // {
                //     a;
                // };
                var groupName = from Group in allGroups
                                join Artist in allArtists
                                on Group.Id equals Artist.GroupId
                                into Members
                                where Group.GroupName == name
                                select new
                                {
                                    Group = Group.GroupName,
                                    Members = Members.Select(e => e.ArtistName)
                                };
                return Json(groupName);
            }
            else
            {
                var groupName = allGroups.Where(group => group.GroupName == $"{name}");
                return Json(groupName);
            }
        }
        [Route("groups/id/{id}")]
        [HttpGet]
        public JsonResult groupID(int id, bool display = false)
        {
            if (display == true)
            {
                var groupID = 
                    from Group in allGroups
                    join Artist in allArtists
                    on Group.Id equals Artist.GroupId
                    into Members
                    where Group.Id == id
                    select new
                    {
                        Group = Group.GroupName,
                        Members = Members.Select(e => e.ArtistName)
                    };
                return Json(groupID);
            }
            else
            {
                var groupID = allGroups.Where(g => g.Id == id);
                return Json(groupID);
            }
        }
    }
}