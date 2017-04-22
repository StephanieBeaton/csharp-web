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
        //ClassMasterModel GetClass(int classId);
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
        private readonly IClassMasterRepository classMasterRepository;

        public UserClassManager(IUserClassRepository userClassRepository,
                                IClassMasterRepository classMasterRepository)
        {
            this.userClassRepository = userClassRepository;
            this.classMasterRepository = classMasterRepository;

            this.classMasterRepository.ClassMaster(1);
        }

        private ClassMasterModel GetClass(int classId)
        {
            TheLearningCenter.Repository.ClassMasterModel myClass = this.classMasterRepository.ClassMaster(classId);

            return new ClassMasterModel(classId, myClass.Name, myClass.Description, myClass.Price, myClass.Sessions);
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
                                 var myClass = GetClass(t.ClassId);

                                 return new UserClassModel
                                 {
                                     UserId = userId,
                                     ClassId = t.ClassId,
                                     ClassName = myClass.Name,
                                     ClassDescription = myClass.Description,
                                     ClassPrice = myClass.Price
                                 };
                             })
                            .ToArray();


            //var userClasses = userClassRepository.GetAll(userId)
            //                    .Select(t => new UserClassModel {
            //                        UserId = t.UserId,
            //                        ClassId = t.ClassId})
            //                    .ToArray();

            return userClasses;
        }

        public bool Remove(int userId, int classId)
        {
            return userClassRepository.Remove(userId, classId);
        }
    }
}
