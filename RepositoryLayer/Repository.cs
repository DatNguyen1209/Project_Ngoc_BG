using DomainLayer.DTO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer
{
    public class Repository<T> : IRepository<T> where T : class
    {
        internal StudentDbContext _studentDbContext;
        private DbSet<T> _entity;
        public Repository(StudentDbContext studentDbContext, DbSet<T> entity)
        {
            _studentDbContext = studentDbContext;
            _entity = entity;
        }
    }
}
