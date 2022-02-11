using mb.Common.Models;

namespace mb.Common
{
    public interface IAccountData
    {
        public string Register(Account account);
        public Account GetAccount(string username);
    }
}