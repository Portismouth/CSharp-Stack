using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using TheWall.Models;

namespace TheWall.Controllers
{
    public class MessageController : Controller
    {
        private readonly DbConnector _dbConnector;
        public MessageController(DbConnector connect)
        {
            _dbConnector = connect;
        }
    
        // GET: /Home/
        [HttpGet]
        [Route("wall")]
        public IActionResult Index()
        {
            TempData["UserId"] = HttpContext.Session.GetInt32("UserId");
            TempData["FirstName"] = HttpContext.Session.GetString("name");
            if(TempData["UserId"] == null)
            {
                return RedirectToAction("Index", "User");
            }
            List<Dictionary<string, object>> AllMessages = _dbConnector.Query("SELECT messages.id, messages.message, users.first_name, users.last_name, messages.created_at FROM messages INNER JOIN users ON messages.user_id = users.id ORDER BY created_at desc");
            List<Dictionary<string, object>> AllComments = _dbConnector.Query("SELECT comments.comment, users.first_name, users.last_name, comments.id, comments.message_id, comments.created_at FROM comments INNER JOIN users ON comments.user_id = users.id");
            ViewBag.Messages = AllMessages;
            ViewBag.Comments = AllComments;
            return View();
        }

        [HttpPost]
        [Route("message")]
        public IActionResult Message(MessagingViewModel Message)
        {
            if (!ModelState.IsValid)
            {
                TempData["UserId"] = HttpContext.Session.GetInt32("UserId");
                TempData["FirstName"] = HttpContext.Session.GetString("name");
                List<Dictionary<string, object>> AllMessages = _dbConnector.Query("SELECT messages.id, messages.message, users.first_name, users.last_name, messages.created_at FROM messages INNER JOIN users ON messages.user_id = users.id ORDER BY created_at desc");
                List<Dictionary<string, object>> AllComments = _dbConnector.Query("SELECT comments.comment, users.first_name, users.last_name, comments.id, comments.message_id, comments.created_at FROM comments INNER JOIN users ON comments.user_id = users.id");
                ViewBag.Messages = AllMessages;
                ViewBag.Comments = AllComments;
                return View("Index");
            }
            else
            {
                // int? id = (int)HttpContext.Session.GetInt32("id");
                TempData["UserId"] = HttpContext.Session.GetInt32("UserId");
                TempData["FirstName"] = HttpContext.Session.GetString("name");
                string createMessage = $"INSERT INTO messages (message, user_id) VALUES ('{Message.UserMessage.Content}', {TempData["UserId"]})";
                System.Console.WriteLine(createMessage);
                _dbConnector.Execute(createMessage);
                return RedirectToAction("Index");
            }
        }
        [HttpPost]
        [Route("comment")]
        public IActionResult Comment(MessagingViewModel Comment)
        {
            if (!ModelState.IsValid)
            {
                TempData["UserId"] = HttpContext.Session.GetInt32("UserId");
                TempData["FirstName"] = HttpContext.Session.GetString("name");
                List<Dictionary<string, object>> AllMessages = _dbConnector.Query("SELECT messages.id, messages.message, users.first_name, users.last_name, messages.created_at FROM messages INNER JOIN users ON messages.user_id = users.id ORDER BY created_at desc");
                List<Dictionary<string, object>> AllComments = _dbConnector.Query("SELECT comments.comment, users.first_name, users.last_name, comments.id, comments.message_id, comments.created_at FROM comments INNER JOIN users ON comments.user_id = users.id");
                ViewBag.Messages = AllMessages;
                ViewBag.Comments = AllComments;
                return View("Index");
            }
            else
            {
                TempData["UserId"] = HttpContext.Session.GetInt32("UserId");
                TempData["FirstName"] = HttpContext.Session.GetString("name");
                // int? id = (int)HttpContext.Session.GetInt32("id");
                int MessageId = Comment.UserComment.MessageId;
                string createComment = $"INSERT INTO comments (comment, user_id, message_id) VALUES ('{Comment.UserComment.Content}', {TempData["UserId"]}, {MessageId})";
                _dbConnector.Execute(createComment);
                return RedirectToAction("Index");
            }
        }
    }
}