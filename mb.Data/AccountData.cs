using System.Linq;
using mb.Common;
using mb.Common.Models;

namespace mb.Data
{
    public class AccountData : IAccountData
    {
        private readonly IMbContext _mbContext;

        public AccountData(IMbContext mbContext)
        {
            _mbContext = mbContext;
        }

        public string Register(Account account)
        {
            if (CheckEmailTaken(account.Email))
            {
                return "Email already taken";
            }
            
            if (account.Email == null && account.Password == null && account.Username == null)
            {
                return "Error";
            }
            
            _mbContext.Accounts.Add(account);
            _mbContext.SaveChanges();
            return "Successful";
        }
        
        private bool CheckEmailTaken(string email)
        {
            return _mbContext.Accounts.FirstOrDefault(u => u.Email == email) != null;
        }
    }
}