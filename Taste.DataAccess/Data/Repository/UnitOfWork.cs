using System;
using System.Collections.Generic;
using System.Text;
using Taste.DataAccess.Data.Repository.IRepository;

namespace Taste.DataAccess.Data.Repository
{
    class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _db;

        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
            Catergory = new CategoryRepository(_db);
        }

        public ICategoryRepository Catergory { get; private set; }
        public ICategoryRepository Category { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public void Dispose()
        {
            _db.Dispose();
        }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
