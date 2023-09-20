using ProjectTestBackendDev.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace ProjectTestBackendDev.Controllers
{
    public class UsersController : ApiController
    {
        //Dummy Data
        public List<Users> userList = new List<Users>
        {
            new Users() { UserId = 1, Username = "user001", Password ="user001", Email = "user001@gmail.com", Role="Admin"},
            new Users() { UserId = 2, Username = "user002", Password ="user002", Email = "user002@gmail.com", Role=""},
            new Users() { UserId = 3, Username = "user003", Password ="user003", Email = "user003@gmail.com", Role=""},
        };
        bool isLogin = false;
        // GET: api/Users
        [HttpGet]
        //[Authorize]
        public List<Users> Get()
        {
            List<Users> user = new List<Users>();
            user.AddRange(userList);

            return user;
        }

        // POST: api/Friend
        [HttpPost]
        [Route("api/users/Add")]
        //[Authorize]
        public List<Users> Post([FromBody] Users user)
        {
            userList.Add(user);

            return userList;
        }

        // PUT: api/Friend/5
        [HttpPut]
        [Route("api/users/Update")]
        //[Authorize]
        public List<Users> Put(int id, [FromBody] Users user)
        {
            Users userUpdate = userList.Find(f => f.UserId == id);
            int index = userList.IndexOf(userUpdate);

            userList[index].Username = user.Username;
            userList[index].Password = user.Password;
            userList[index].Email = user.Email;

            return userList;
        }

        //DELETE: api/Users/1
        [HttpDelete]
        [Route("api/users/Delete")]
        //[Authorize]
        public List<Users> Delete(int id)
        {
            Users user = userList.Find(f => f.UserId == id);
            userList.Remove(user);

            return userList;
        }

        // GET: api/Users/GetEmail
        [HttpGet]
        [Route("api/users/GetEmail")]
        //[Authorize]
        public List<Users> GetEmail(string email)
        {
            Users user = userList.Find(f => f.Email == email);
            List<Users> userEmail = new List<Users>();
            userEmail.Add(user);

            return userEmail;
        }

        [HttpPost]
        [Route("api/users/Login")]
        public string Login(string uname, string pass)
        {
            var userLogin = userList.Where(f => f.Username == uname && f.Password == pass).ToList();
            string textLogin = string.Empty;
            if(userLogin.Count > 0)
            {
                textLogin = "Logins Success";
            }
            else
            {
                textLogin = "Logins Failed";
            }
            return textLogin;
        }
    }
}