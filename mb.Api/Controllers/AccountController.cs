using mb.Common;
using mb.Common.Models.ApiModels;
using mb.Data;
using mb.Logic;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace moodboardwebapi.Controllers
{
    [EnableCors("AllowCors")]
    [ApiController]
    [Route("[controller]")]
    public class AccountController : Controller
    {
        private readonly AccountService _accountService;

        public AccountController(MbContext mbContext)
        {
            _accountService = new AccountService(new AccountData(mbContext));
        }
        
        [HttpPost("/account/register")]
        public string Register(ApiAccount account)
        {
            string register = _accountService.Register(account);
            return register;
        }

        [HttpPost("/account/login")]
        public string Login(ApiAccount account)
        {
            string login = _accountService.Login(account);
            return login;
        }
    }
}