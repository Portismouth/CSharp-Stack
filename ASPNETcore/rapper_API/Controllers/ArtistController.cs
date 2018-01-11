using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using JsonData;

namespace MusicApi.Controllers {

    
    public class ArtistController : Controller {

        public List<Artist> allArtists;

        public ArtistController() {
            allArtists = JsonToFile<Artist>.ReadJson();
        }

        //This method is shown to the user navigating to the default API domain name
        //It just display some basic information on how this API functions
        [Route("")]
        [HttpGet]
        public string Index() {
            //String describing the API functionality
            string instructions = "Welcome to the Music API~~\n========================\n";
            instructions += "    Use the route /artists/ to get artist info.\n";
            instructions += "    End-points:\n";
            instructions += "       *Name/{string}\n";
            instructions += "       *RealName/{string}\n";
            instructions += "       *Hometown/{string}\n";
            instructions += "       *GroupId/{int}\n\n";
            instructions += "    Use the route /groups/ to get group info.\n";
            instructions += "    End-points:\n";
            instructions += "       *Name/{string}\n";
            instructions += "       *GroupId/{int}\n";
            instructions += "       *ListArtists=?(true/false)\n";
            return instructions;
        }
        [Route("artists")]
        [HttpGet]
        public JsonResult Artists()
        {
            return Json(allArtists);
        }
        [Route("artists/name/{name}")]
        [HttpGet]
        public JsonResult artistName(string name)
        {
            var Artist = allArtists.Where(artist => artist.ArtistName == $"{name}");
            return Json(Artist);
        }
        [Route("artists/realname/{realName}")]
        [HttpGet]
        public JsonResult artistRealName(string realName)
        {
            var artistRName = allArtists.Where(artist => artist.RealName == $"{realName}");
            return Json(artistRName);
        }
        [Route("artists/hometown/{town}")]
        [HttpGet]
        public JsonResult artistHomeTown(string town)
        {
            var hometown = allArtists.Where(artist => artist.Hometown == $"{town}");
            return Json(hometown);
        }
        [HttpGet]
        [Route("artists/group/{id}")]
        public JsonResult artistGroup(int id)
        {
            var groupMem = allArtists.Where(artist => artist.GroupId == id);
            return Json(groupMem);
        }
    }
}