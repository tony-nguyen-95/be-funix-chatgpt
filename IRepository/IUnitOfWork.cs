namespace Funix.HannahAssistant.Api.IRepository
{
    public interface IUnitOfWork
    {
        Task CommitAsync();
    }
}
