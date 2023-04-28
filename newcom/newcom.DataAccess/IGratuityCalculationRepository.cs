namespace newcom.Service
{
    using newcom.DTO;
    
    public interface IGratuityCalculationRepository
    {
        Task<GratuityCalculationModel> GetAsync(int id);
        Task<IEnumerable<GratuityCalculationModel>> GetAllAsync();
        Task<int> CreateAsync(GratuityCalculationModel model);
        Task<int> UpdateAsync(GratuityCalculationModel model);
        Task<int> DeleteAsync(int id);
    }
}