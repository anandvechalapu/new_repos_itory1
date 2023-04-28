namespace newcom
{
    public class GratuityCalculationRepository : IGratuityCalculationRepository
    {
        private readonly string _connectionString;

        public GratuityCalculationRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<GratuityCalculationModel> GetAsync(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var query = "SELECT * FROM GratuityCalculation WHERE Id = @id";
                var result = await connection.QuerySingleOrDefaultAsync<GratuityCalculationModel>(query, new { id });
                return result;
            }
        }

        public async Task<IEnumerable<GratuityCalculationModel>> GetAllAsync()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var query = "SELECT * FROM GratuityCalculation";
                var result = await connection.QueryAsync<GratuityCalculationModel>(query);
                return result;
            }
        }

        public async Task<int> CreateAsync(GratuityCalculationModel model)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var query = "INSERT INTO GratuityCalculation (BasicSalary, Increments, GratuityAmount) VALUES (@BasicSalary, @Increments, @GratuityAmount); SELECT CAST(SCOPE_IDENTITY() as int)";
                var result = await connection.QuerySingleAsync<int>(query, new {model.BasicSalary, model.Increments, model.GratuityAmount });
                return result;
            }
        }

        public async Task<int> UpdateAsync(GratuityCalculationModel model)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var query = "UPDATE GratuityCalculation SET BasicSalary = @BasicSalary, Increments = @Increments, GratuityAmount = @GratuityAmount WHERE Id = @Id";
                var result = await connection.ExecuteAsync(query, new { model.Id, model.BasicSalary, model.Increments, model.GratuityAmount });
                return result;
            }
        }

        public async Task<int> DeleteAsync(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var query = "DELETE FROM GratuityCalculation WHERE Id = @Id";
                var result = await connection.ExecuteAsync(query, new { id });
                return result;
            }
        }
    }
}