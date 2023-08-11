using SchoolSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SchoolSystem.Repository
{
    public class RepositoryClass : Iclass
    {
        private EntityContext entityContext;

        public RepositoryClass(EntityContext entityContext)
        {
            this.entityContext = entityContext;
        }

        public void DeleteClsRecord(int clsId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Class> GetClass(EntityContext entityContext)
        {
            return entityContext.Classes.ToList();
        }

        public IEnumerable<Class> GetClass()
        {
            throw new NotImplementedException();
        }

        public Class GetClsById(int clsId)
        {
            throw new NotImplementedException();
        }

        public void InsertClsRecord(Class cls)
        {
            throw new NotImplementedException();
        }

        public void UpdateClsRecord(Class cls)
        {
            throw new NotImplementedException();
        }
    }
}