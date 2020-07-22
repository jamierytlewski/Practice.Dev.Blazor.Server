using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValidateController : ControllerBase
    {
        [HttpPost]
        public ValidationPasswordResult Post(PasswordValues password)
        {
            var regex = Regex.Match(password.Password, @"^[^\s](?=.{4,}$)(?=.*[!@#$]).*[^\s]$");
            return new ValidationPasswordResult
            {
                IsValid = regex.Success
            };
        }

        public class PasswordValues
        {
            public string Password { get; set; }
        }
    }


}
