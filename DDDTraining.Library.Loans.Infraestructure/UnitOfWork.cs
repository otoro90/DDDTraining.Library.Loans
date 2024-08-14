using DDDTraining.Library.Loans.Domain.Repositories.Base;
using DDDTraining.Library.Loans.Infraestructure.DBContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace DDDTraining.Library.Loans.Infraestructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly LibraryDbContext _dbContext;
        private IDbContextTransaction _transaction;
        private List<object> _entitiesToDetach;

        public UnitOfWork(LibraryDbContext dbContext)
        {
            _dbContext = dbContext;
            _entitiesToDetach = new List<object>();
        }

        public void BeginTransaction()
        {
            _transaction = _dbContext.Database.BeginTransaction();
        }

        public async Task CommitAsync(CancellationToken cancellationToken)
        {
            try
            {
                await _dbContext.SaveChangesAsync(cancellationToken);
                _transaction?.Commit();
            }
            catch (Exception)
            {
                Rollback();
                throw;
            }
            finally
            {
                DetachEntities();
            }
        }

        public void Rollback()
        {
            if (_transaction != null)
            {
                _transaction.Rollback();
                return;
            }

            // Deshacer los cambios en el DbContext
            foreach (var entry in _dbContext.ChangeTracker.Entries())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.State = EntityState.Detached;
                        break;
                    case EntityState.Modified:
                    case EntityState.Deleted:
                        entry.Reload();
                        break;
                }
            }
        }

        public void RegisterEntityToDetach(object entity)
        {
            _entitiesToDetach.Add(entity);
        }

        private void DetachEntities()
        {
            foreach (var entity in _entitiesToDetach)
            {
                _dbContext.Entry(entity).State = EntityState.Detached;
            }
        }
    }
}
