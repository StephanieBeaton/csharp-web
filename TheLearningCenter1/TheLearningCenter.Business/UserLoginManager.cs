using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheLearningCenter.Repository;

namespace TheLearningCenter.Business
{
    public interface IUserLoginManager
    {
        UserLoginModel LogIn(string email, string password);
        UserLoginModel RegisterUser(string email, string password);
    }

    public class UserLoginModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    class UserLoginManager : IUserLoginManager
    {

        private readonly IUserLoginRepository userLoginRepository;

        public UserLoginManager(IUserLoginRepository userLoginRepository)
        {
            this.userLoginRepository = userLoginRepository;
        }

        public UserLoginModel LogIn(string email, string password)
        {
            // throw new NotImplementedException();
            var user = userLoginRepository.LogIn(email, password);

            if (user == null)
            {
                return null;
            }

            return new UserLoginModel { Id = user.Id, Name = user.Name };

        }

        public UserLoginModel RegisterUser(string email, string password)
        {
            var user = userLoginRepository.Register(email, password);

            if (user == null)
            {
                return null;
            }

            return new UserLoginModel { Id = user.Id, Name = user.Name };
        }
    }
}
