using Dapper;
using RealEstate_Dapper_Api.DTOs.ProductDTOs;
using RealEstate_Dapper_Api.Models.DapperContext;
using RealEstate_Dapper_UI.DTOs.ProductDTOs;

namespace RealEstate_Dapper_Api.Repositories.ProductRepository
{
    public class ProductRepository : IProductRepository
    {
        private readonly Context _context;

        public ProductRepository(Context context)
        {
            _context = context;
        }

        public async void DealoftheDayActive(int id)
        {
            string query = "Update Product Set DealoftheDay=1 where ProductId=@productId";
            var parameters = new DynamicParameters();
            parameters.Add("@productID", id);
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.ExecuteAsync(query, parameters);

            }
        }
        public async void DealoftheDayPassive(int id)
        {
            string query = "Update Product Set DealoftheDay=0 where ProductId=@productId";
            var parameters = new DynamicParameters();
            parameters.Add("@productID", id);
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.ExecuteAsync(query, parameters);

            }
        }

        public async Task<List<ResultProductDTO>> GetAllProductAsync()
        {
            var query = "Select * from Product";
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultProductDTO>(query);
                return values.ToList();
            }
        }

        public async Task<List<ResultProductWithCategoryDTO>> GetAllProductWithCategory()
        {
            var query = "Select ProductId,Title,Price,City,District,Name,CoverImage,Type,Address,DealoftheDay from Product inner join Category on Product.ProductCategory=Category.CategoryId"; // inner join query
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultProductWithCategoryDTO>(query);
                return values.ToList();
            }
        }

        public async Task<List<ResultLast5ProductWithCategoryDTO>> GetLast5Product()
        {
            string query = "Select Top(5) ProductId,Title,Price,City,District,ProductCategory,Name,AdvertisementDate From Product Inner Join Category on Product.ProductCategory = Category.CategoryId Where Type = 'Kiralık' Order By ProductId Desc";
            using(var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultLast5ProductWithCategoryDTO>(query);
                return values.ToList();
            }
        }
    }
}
