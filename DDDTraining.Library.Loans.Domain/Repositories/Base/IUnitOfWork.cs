namespace DDDTraining.Library.Loans.Domain.Repositories.Base
{
    public interface IUnitOfWork
    {
        public Task CommitAsync(CancellationToken cancellationToken);
        public void Rollback();
        public void BeginTransaction();
        public void RegisterEntityToDetach(object entity);
    }
}
