using Dapper;
using RealEstate_Dapper_Api.DTOs.CategoryDTOs;
using RealEstate_Dapper_Api.DTOs.WhoWeAreDetailDTOs;
using RealEstate_Dapper_Api.Models.DapperContext;

namespace RealEstate_Dapper_Api.Repositories.WhoWeAreDetailRepository
{
    public class WhoWeAreDetailRepository : IWhoWeAreDetailRepository
    {
        private readonly Context _context;

        public WhoWeAreDetailRepository(Context context)
        {
            _context = context;
        }

        public async void  CreateWhoWeAreDetail(CreateWhoWeAreDetailDTO createWhoWeAreDetailDTO)
        {
            string query = "insert into WhoWeAreDetail (Title , Subtitle ,Description1 , Description2) values (@title,@subtitle,@description1,@description2)";  // SQL Query
            var parameters = new DynamicParameters(); // Dapper methodu için gerekli parametreleri oluşturuyoruz
            parameters.Add("@title", createWhoWeAreDetailDTO.Title); // 1. parametre query de ki value   =>  2. parametre eklenmesini istediğimiz nesne (prop)
            parameters.Add("@subtitle", createWhoWeAreDetailDTO.Subtitle); 
            parameters.Add("@description1", createWhoWeAreDetailDTO.Description1); 
            parameters.Add("@description2", createWhoWeAreDetailDTO.Description2); 

            using (var connection = _context.CreateConnection()) // klasik ezberlenmesi gereken connection kod bloğu
            {
                await connection.ExecuteAsync(query, parameters); // Create işlemi için Dapper ExecuteAsync methodu kullanıyoruz parametre ve query yolluyoruz.
            }
        }

        public async void DeleteWhoWeAreDetail(int id)
        {
            string query = "Delete from WhoWeAreDetail where WhoWeAreDetailID=@whoWeAreDetailID"; // buradaki querylerde kendimiz elle giriyoruz gibi yazıyoruz values veya where için
            var parameters = new DynamicParameters();
            parameters.Add("@whoWeAreDetailID", id);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters); // ExecuteAsync burada yazılan methodu ve parametreleri execute ediyor
            }
        }

        public async Task<List<ResultWhoWeAreDetailDTO>> GetAllWhoWeAreDetailAsync()
        {
            string query = "Select * From WhoWeAreDetail"; // => SQL Query
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultWhoWeAreDetailDTO>(query); // connection bizim bağlantımızı tutuyor ve QueryAsync bir dapper methodu
                                                                                    // ilgili DTO Parametre olarak verilip ilgili tabloya gerekli query'yi ulaştırıyor
                return values.ToList();
            }
        }

        public async Task<GetByIDWhoWeAreDetailDTO> GetWhoWeAreDetail(int id)
        {
            string query = "Select * from WhoWeAreDetail Where WhoWeAreDetailID=@whoWeAreDetailID ";
            var parameters = new DynamicParameters();
            parameters.Add("whoWeAreDetailID", id);
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryFirstOrDefaultAsync<GetByIDWhoWeAreDetailDTO>(query, parameters); // FirstOrDefault dapper methodu bu sefer verdiğimiz id değerine eş gelen
                return values;                                                                                               // tek değeri döndürmeye yarayan metot
            }
        }

        public async void UpdateWhoWeAreDetail(UpdateWhoWeAreDetailDTO updateWhoWeAreDetailDTO)
        {
            string query = "Update WhoWeAreDetail Set Title=@title,Subtitle=@subtitle ,Description1=@description1,Description2=@description2 Where WhoWeAreDetailID=@whoWeAreDetailID";
            var parameters = new DynamicParameters();
            parameters.Add("title", updateWhoWeAreDetailDTO.Title);        // @title ile DTO.title ile matchleniyor
            parameters.Add("subtitle", updateWhoWeAreDetailDTO.Subtitle);        
            parameters.Add("description1", updateWhoWeAreDetailDTO.Description1);        
            parameters.Add("description2", updateWhoWeAreDetailDTO.Description2);        
            parameters.Add("whoWeAreDetailID", updateWhoWeAreDetailDTO.WhoWeAreDetailID);        
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.ExecuteAsync(query, parameters);
            }
        }
    }
}
