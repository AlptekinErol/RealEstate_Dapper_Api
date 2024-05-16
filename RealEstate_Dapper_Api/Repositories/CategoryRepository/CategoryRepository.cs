using Dapper;
using RealEstate_Dapper_Api.DTOs.CategoryDTOs;
using RealEstate_Dapper_Api.Models.DapperContext;

namespace RealEstate_Dapper_Api.Repositories.CategoryRepository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly Context _context;

        public CategoryRepository(Context context)
        {
            _context = context;
        }

        public async void CreateCategory(CreateCategoryDTO categoryDTO)
        {
            string query = "insert into Category (Name , Status) values (@categoryName,@categoryStatus)";  // SQL Query
            var parameters = new DynamicParameters(); // Dapper methodu için gerekli parametreleri oluşturuyoruz
            parameters.Add("@categoryName", categoryDTO.Name); // 1. parametre query de ki value   =>  2. parametre eklenmesini istediğimiz nesne (prop)
            parameters.Add("@categoryStatus", true); // arka planda statik true tutuyoruz
            using (var connection = _context.CreateConnection()) // klasik ezberlenmesi gereken connection kod bloğu
            {
                await connection.ExecuteAsync(query, parameters); // Create işlemi için Dapper ExecuteAsync methodu kullanıyoruz parametre ve query yolluyoruz.
            }
        }

        public async void DeleteCategory(int id)
        {
            string query = "Delete from Category where CategoryId=@categoryId"; // buradaki querylerde kendimiz elle giriyoruz gibi yazıyoruz values veya where için
            var parameters = new DynamicParameters();
            parameters.Add("@categoryId", id);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters); // ExecuteAsync burada yazılan methodu ve parametreleri execute ediyor
            }
        }

        public async Task<List<ResultCategoryDTO>> GetAllCategoryAsync()
        {
            string query = "Select * From Category"; // => SQL Query
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultCategoryDTO>(query); // connection bizim bağlantımızı tutuyor ve QueryAsync bir dapper methodu
                                                                                    // ilgili DTO Parametre olarak verilip ilgili tabloya gerekli query'yi ulaştırıyor
                return values.ToList();
            }
        }

        public async Task<GetByIDCategoryDTO> GetCategoryAsync(int id)
        {
            string query = "Select * from Category Where CategoryId=@categoryId ";
            var parameters = new DynamicParameters();
            parameters.Add("categoryId", id);
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryFirstOrDefaultAsync<GetByIDCategoryDTO>(query, parameters); // FirstOrDefault dapper methodu bu sefer verdiğimiz id değerine eş gelen
                return values;                                                                                               // tek değeri döndürmeye yarayan metot
            }
        }

        public async void UpdateCategory(UpdateCategoryDTO updateCategoryDTO)
        {
            string query = "Update Category Set Name=@name,Status=@status Where CategoryId=@categoryId";
            var parameters = new DynamicParameters();
            parameters.Add("name", updateCategoryDTO.Name);        // @name ile DTO.Name matchleniyor
            parameters.Add("status", updateCategoryDTO.Status);   // @status ile DTO.status matchleniyor
            parameters.Add("categoryId", updateCategoryDTO.CategoryId);   // @categoryId ile DTO.categoryId matchleniyor
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.ExecuteAsync(query, parameters);
            }
        }
    }
}
