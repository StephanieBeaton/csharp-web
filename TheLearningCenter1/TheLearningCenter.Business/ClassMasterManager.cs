using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheLearningCenter.Repository;

namespace TheLearningCenter.Business
{
    public interface IClassMasterManager
    {
        ClassMasterModel[] ClassMasters { get; }
        ClassMasterModel ClassMaster(int classId);
    }

    // from TheLearningCenter.Repository
    //      ... ClassMasterRepository.cs
    //
    //public int Id { get; set; }
    //public string Name { get; set; }
    //public string Description { get; set; }
    //public double Price { get; set; }
    //public int Sessions { get; set; }


    public class ClassMasterModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public int Sessions { get; set; }

        public ClassMasterModel(int id, 
                                string name, 
                                string description,
                                double price,
                                int sessions)
        {
            Id = id;
            Name = name;
            Description = description;
            Price = price;
            Sessions = sessions;
        }

    }

    class ClassMasterManager : IClassMasterManager
    {
        private readonly IClassMasterRepository classMasterRepository;

        public ClassMasterManager( IClassMasterRepository classMasterRepository)
        {
            this.classMasterRepository = classMasterRepository;
        }

        public ClassMasterModel[] ClassMasters
        {
            get
            {
                return classMasterRepository.ClassMasters
                            .Select(t => new ClassMasterModel(t.Id, t.Name, t.Description, t.Price, t.Sessions))
                            .ToArray();
            }
        }

        public ClassMasterModel ClassMaster(int classId)
        {
            var classMasterModel = classMasterRepository.ClassMaster(classId);
            return new ClassMasterModel(classMasterModel.Id,
                                        classMasterModel.Name,
                                        classMasterModel.Description,
                                        classMasterModel.Price,
                                        classMasterModel.Sessions);
        }
    }
}
