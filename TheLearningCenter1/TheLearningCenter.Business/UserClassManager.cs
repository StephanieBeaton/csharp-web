using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TheLearningCenter.Repository;

namespace TheLearningCenter.Business
{
    public interface IUserClassManager
    {
        UserClassModel Add(int userId, int classId);
        bool Remove(int userId, int classId);
        UserClassModel[] GetAll(int userId);
    }

    public class UserClassModel
    {
        public int UserId { get; set; }
        public int ClassId { get; set; }
        public string ClassName { get; set; }
        public string ClassDescription { get; set; }
        public double ClassPrice { get; set; }
    }

    class UserClassManager : IUserClassManager
    {
        private readonly IUserClassRepository userClassRepository;

        public UserClassManager(IUserClassRepository userClassRepository)
        {
            this.userClassRepository = userClassRepository;
        }

        public UserClassModel Add(int userId, int classId)
        {
            var userClass = userClassRepository.Add(userId, classId);

            return new UserClassModel { UserId = userClass.UserId, ClassId = userClass.ClassId };
        }
    

        public UserClassModel[] GetAll(int userId)
        {
            // throw new NotImplementedException();

            // from cstructor.com
            //    http://cstructor.com/Home/SNotes?classId=39&sequence=540

            var userClasses = userClassRepository.GetAll(userId)
                            .Select(t =>
                             {
                                 return new UserClassModel
                                 {
                                     UserId = userId,
                                     ClassId = t.ClassId,
                                     ClassName = t.Name,
                                     ClassDescription = t.Description,
                                     ClassPrice = t.Price
                                 };
                             })
                            .ToArray();

            return userClasses;
        }

        public bool Remove(int userId, int classId)
        {
            return userClassRepository.Remove(userId, classId);
        }
    }
}
