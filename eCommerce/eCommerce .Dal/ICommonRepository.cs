namespace eCommerce.Dal
{
    public interface ICommonRepository<T>
    {
        Task<List<T>> GetAllAsync();
        Task<T> GetDetailAsync(int id);
        Task<int> InsertAsync(T item);
        Task<int> UpdateAsync(T item);
        Task<int> DeleteAsync(int id);
    }
}
