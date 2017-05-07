using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;

namespace TheLearningCenter.Repository
{
    // from http://cstructor.com/Home/SNotes?classId=39&sequence=530

    public interface IUserLoginRepository
    {
        UserModel LogIn(string email, string password);
        UserModel Register(string email, string password);
    }

    public class UserModel
    {
        public int Id { get; set; }
        public string Name { get; set; }     // can also be User's email
    }

    class UserLoginRepository : IUserLoginRepository
    {
        //  for testing

        //public IEnumerable<User> Users
        //{
        //    get
        //    {
        //        var users = new[]
        //        {
        //            new User{ Id=100, Name="admin", Password="admin"},
        //            new User{ Id=101, Name="mike", Password="mike"},
        //            new User{ Id=102, Name="dave", Password="dave"},
        //            new User{ Id=103, Name="lisa", Password="lisa"},
        //        };
        //        return users;
        //    }
        //}


        public UserModel LogIn(string email, string password)
        {
            var user = DatabaseAccessor.Instance.Users
                .FirstOrDefault(t => t.UserName.ToLower() == email.ToLower()
                                      && t.UserPassword == password);

            if (user == null)
            {
                return null;
            }

            return new UserModel { Id = user.UserId, Name = user.UserName };
        }

        public UserModel Register(string email, string password)
        {
            var user = DatabaseAccessor.Instance.Users
                    .Add(new TheLearningCenter.SchoolDatabase.User { UserName = email, UserPassword = password });

            DatabaseAccessor.Instance.SaveChanges();

            return new UserModel { Id = user.UserId, Name = user.UserName };
        }

    }
}
