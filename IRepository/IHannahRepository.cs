using Funix.HannahAssistant.Api.Entities;

namespace Funix.HannahAssistant.Api.IRepository
{
    public interface IHannahRepository
    {
        Task<Hannah?> Get(string Name);
        Task<Hannah?> Get(Guid HannahId);
        Task Add(Hannah entity);
        void Update(Hannah entity);
        void Update(List<Hannah> entities);
        Task<List<Hannah>> Get();
        Task<List<Hannah>> Get(List<Guid> Ids);
        Task<List<Guid>> GetUserId();
    }
}
