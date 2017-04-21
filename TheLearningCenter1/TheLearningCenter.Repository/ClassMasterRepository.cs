using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheLearningCenter.Repository
{
    public interface IClassMasterRepository
    {
        ClassMasterModel[] ClassMasters { get; }
        ClassMasterModel ClassMaster(int ClassMasterId);
    }

    // from TheLearningCenter.SchoolDatabase
    //      ... SchoolDatabase.edmx
    //      ...   SchoolDatabase.tt
    //      ...     ClassMaster.cs
    //
    //public int ClassId { get; set; }
    //public string ClassName { get; set; }
    //public string ClassDescription { get; set; }
    //public double ClassPrice { get; set; }
    //public int ClassSessions { get; set; }


    public class ClassMasterModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public int Sessions { get; set; }
    }

    public class ClassMasterRepository : IClassMasterRepository
    {
        public ClassMasterModel[] ClassMasters
        {
            get
            {
                return DatabaseAccessor.Instance.ClassMasters
                                               .Select(t => new ClassMasterModel {
                                                   Id = t.ClassId,
                                                   Name = t.ClassName,
                                                   Description = t.ClassDescription,
                                                   Price = t.ClassPrice,
                                                   Sessions = t.ClassSessions
                                               })
                                               .ToArray();
            }
        }

        public ClassMasterModel ClassMaster(int classMasterId)
        {
            var classMaster = DatabaseAccessor.Instance.ClassMasters
                                                   .Where(t => t.ClassId == classMasterId)
                                                   .Select(t => new ClassMasterModel {
                                                       Id = t.ClassId,
                                                       Name = t.ClassName,
                                                       Description = t.ClassDescription,
                                                       Price = t.ClassPrice,
                                                       Sessions = t.ClassSessions
                                                   })
                                                   .First();
            return classMaster;
        }
    }
}