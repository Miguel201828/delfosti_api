namespace delfosti.tracking.api.Generic
{
    public interface IGeneric<T> where T : class
    {
        Task<List<T>> GetAll();
        Task<T> GetById(Int32 id);
        Task<Boolean> Insert(T entidad);
        Task Update(Int32 id, T entidad);
        Task Delete(Int32 id);
    }
}
