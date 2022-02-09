using mb.Common;
using mb.Common.Models;
using mb.Common.Models.ApiModels;

namespace mb.Logic
{
    public class AccountService
    {
        private readonly IAccountData _accountData;

        public AccountService(IAccountData accountData)
        {
            _accountData = accountData;
        }

        public string Register(ApiAccount apiAccount)
        {
            Account account = new Account(apiAccount.Email, apiAccount.Username, apiAccount.Password);
            return _accountData.Register(account);
        }
    }
}