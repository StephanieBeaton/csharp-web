using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TheLearningCenter.SchoolDatabase;

namespace TheLearningCenter.Repository
{
    public interface IUserClassRepository
    {
        UserClassModel Add(int userId, int classId);
        bool Remove(int userId, int classId);
        UserClassModel[] GetAll(int userId);

    }

    public class UserClassModel
    {
        public int UserId { get; set; }
        public int ClassId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public int Sessions { get; set; }

    }

    class UserClassRepository : IUserClassRepository
    {
        public UserClassModel Add(int userId, int classId)
        {
            // Get the user object from the database
            var user = DatabaseAccessor.Instance.Users.First(t => t.UserId == userId);

            // Get the class object from the database
            var newClass = DatabaseAccessor.Instance.ClassMasters.First(t => t.ClassId == classId);

            // Add the class to the user object
            user.ClassMasters.Add(newClass);

            // Save the changes to the database
            DatabaseAccessor.Instance.SaveChanges();

            return new UserClassModel { UserId = userId, ClassId = classId };
        }

    public UserClassModel[] GetAll(int userId)
        {
            // this code calls a Stored Procedure in the database
            //
            //var userClasses = DatabaseAccessor.Instance.RetrieveClassesForStudent(userId)
            //                            .Select(t => new UserClassModel { UserId = t.UserId, ClassId = t.ClassId })
            //                            .ToArray();

            var userClasses = DatabaseAccessor.Instance.Users.First(t => t.UserId == userId)
                      .ClassMasters.Select(t =>
                            new UserClassModel
                            {
                                UserId = userId,
                                ClassId = t.ClassId,
                                Name = t.ClassName,
                                Description = t.ClassDescription,
                                Price = t.ClassPrice,
                                Sessions = t.ClassSessions
                            })
                      .ToArray();

            return userClasses;
        }

        public bool Remove(int userId, int classId)
        {
            //var items = DatabaseAccessor.Instance.ShoppingCartItems
            //        .Where(t => t.UserId == userId && t.ProductId == productId);

            //if (items.Count() == 0)
            //{
            //    return false;
            //}

            //DatabaseAccessor.Instance.ShoppingCartItems.Remove(items.First());

            //DatabaseAccessor.Instance.SaveChanges();

            return true;
        }
    }
}
