namespace E_Commerce.Domain.UnitOfWorkPattern
{
    public interface IUnitOfWork
    {
        Task Commit();
    }
}
