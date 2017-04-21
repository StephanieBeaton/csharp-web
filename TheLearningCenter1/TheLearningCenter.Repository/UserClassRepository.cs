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
    }

    class UserClassRepository : IUserClassRepository
    {
        public UserClassModel Add(int userId, int classId)
        {
            // fix this code !!
            // 
            // missing "UserClass" in SchoolDatabase.edmx

            // var userClass = DatabaseAccessor.Instance.UserClass.Add(
            //                   new TheLearningCenter.SchoolDatabase.UserClassModel { UserId = t.UserId, ClassId = t.classId });

            // DatabaseAccessor.Instance.SaveChanges();

            // return new UserClassModel { UserId = userClass.UserId, ClassId = userClass.ClassId };

            // ===========================================================
            //   Instructions from UW Canvas course Discussion board
            //             https://canvas.uw.edu/courses/1105401/discussion_topics/3676338
            //  
            // Get the user object from the database
            // var user = database.Users.First(t => t.UserId == sessionUser.UserId);
            //
            // Get the class object from the database
            // var newClass = database.Classes.First(t => t.ClassId == model.ClassId);
            //
            // Class newClass = null;
            // foreach (var t in database.Classes)
            // {
            //    if (t.ClassId == model.ClassId)
            //    {
            //        newClass = t;
            //        break;
            //    }
            // }
            //
            // Add the class to the user object
            // user.Classes.Add(newClass);
            //
            // Save the changes to the database
            // database.SaveChanges();

            // ===========================================================

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
            var userClasses = DatabaseAccessor.Instance.RetrieveClassesForStudent(userId)
                                        .Select(t => new UserClassModel { UserId = t.UserId, ClassId = t.ClassId })
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
