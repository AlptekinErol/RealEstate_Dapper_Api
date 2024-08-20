using Dapper;
using RealEstate_Dapper_Api.Models.DapperContext;

namespace RealEstate_Dapper_Api.Repositories.StatisticRepositories
{
    public class StatisticsRepository : IStatisticsRepository
    {
        // Summary bu class'ın interface kısmında açıklandığı gibi istatistiksel sql sorguları pratiği amaçlı oluşturulan repo class'ıdır
        // ve CRUD işlemlerinden ziyade veri okuma yapılmaya amaçlanmıştır
        private readonly Context _context;

        public StatisticsRepository(Context context)
        {
            _context = context;
        }

        public int ActiveCategoryCount()
        {
            string query = "Select Count (*) From Category where Status = 1";
            using (var connection = _context.CreateConnection())
            {
                var values = connection.QueryFirstOrDefault<int>(query); // Burada async yapı kullanmadık ayrıca first or default bizim işimizi görüyor
                                                                         // çünkü bir list değil de bir adet veri döndürmeye odaklnadık.
                return values;
            }
        }

        public int ActiveEmployeeCount()
        {
            string query = "Select Count (*) From Employee where Status = 1";
            using (var connection = _context.CreateConnection())
            {
                var values = connection.QueryFirstOrDefault<int>(query);  // aynı basit mantık kullanıldı 17-26 arası kod bloklarında ki gibi
                return values;
            }
        }

        public int ApartmentCount()
        {
            string query = "select Count(*) from Product where Title like '%daire%'";
            using (var connection = _context.CreateConnection())
            {
                var values = connection.QueryFirstOrDefault<int>(query);
                return values;
            }
        }

        public decimal AverageProductPriceByRent()
        {
            string query = "select AVG(Price) from Product where Type = 'Kiralık'";
            using (var connection = _context.CreateConnection())
            {
                var values = connection.QueryFirstOrDefault<decimal>(query);
                return values;
            }
        }

        public decimal AverageProductPriceBySale()
        {
            string query = "select AVG(Price) from Product where Type = 'Satılık'";
            using (var connection = _context.CreateConnection())
            {
                var values = connection.QueryFirstOrDefault<decimal>(query);
                return values;
            }
        }

        public int AvereageRoomCount()   // çok sağlıklı bir method değil çünkü kiralık veya satılık türüne göre ortalam oda sayısı hesaplanmamış ??? ama AVG fonk pratiği
        {
            string query = "select AVG(RoomCount) from ProductDetails";
            using (var connection = _context.CreateConnection())
            {
                var values = connection.QueryFirstOrDefault<int>(query);
                return values;
            }
        }

        public int CategoryCount()
        {
            string query = "Select Count(*) From Category";
            using (var connection = _context.CreateConnection())
            {
                var values = connection.QueryFirstOrDefault<int>(query);
                return values;
            }
        }

        public string CategoryNameByMaxProductCount()  // bu sorgu sonuç olarak string döndüğü için burada sql sorgusu biraz karışık durabilir...
        {
            string query = "Select  Top(1) Name , Count(*) as Toplam from Product inner join Category on Product.ProductCategory = Category.CategoryId Group by Name Order by Count(*) desc";
            using ( var connection = _context.CreateConnection())
            {
                var values = connection.QueryFirstOrDefault<string>(query);
                return values;
            }
           
        }

        public string CityNameByMaxProductCount() // Önceki query gibi en çok ilan bulunan şehir adını döndüreceğiz
        {
            string query = "Select Top(1) City ,  Count(*) as ToplamŞehir from Product Group By City Order by ToplamŞehir desc";
            using( var connection = _context.CreateConnection())
            {
                var values = connection.QueryFirstOrDefault<string>(query);
                return values;
            }
        }

        public int DeactiveCategoryCount()
        {
            string query = "select Count(*) from Category where Status=0";
            using(var connection = _context.CreateConnection())
            {
                var values = connection.QueryFirstOrDefault<int>(query);
                return values;
            }
        }

        public int DifferentCityCount()
        {
            string query = "Select Count(Distinct(City)) from Product";
            using(var connection = _context.CreateConnection())
            {
                var values = connection.QueryFirstOrDefault<int>(query);
                return values;
            }
        }

        public string EmployeeNameByMaxProduct()
        {
            string query = "Select Top(1) Employee.Name,Count(*) as ToplamSatis From Product inner join Employee on Product.EmployeeId = Employee.EmployeeId Group By Name Order by ToplamSatis desc";

            using ( var connection= _context.CreateConnection())
            {
                var values = connection.QueryFirstOrDefault<string>(query);
                return values;
            }
        }

        public decimal LastProductPrice()
        {
            string query = "Select Top(1) Price from Product Order by ProductId desc";  // Basit mantıkla PRoductId'ye göre listeyi terse ççevirip Top(1) ile en üstteki veriyi aldık
            using( var connection = _context.CreateConnection())
            {
                var values = connection.QueryFirstOrDefault<decimal>(query);
                return values;
            }
        }

        public string NewestBuildingYear()
        {
            string query = "select Max(BuildYear) as EnYeniBina from ProductDetails"; // Max()
            using(var conncetion = _context.CreateConnection())
            {
                var values = conncetion.QueryFirstOrDefault<string>(query);
                return values;
            }
        }

        public string OldestBuildingYear()
        {
            string query = "select Min(BuildYear) as EnYeniBina from ProductDetails"; // Min()
            using (var conncetion = _context.CreateConnection())
            {
                var values = conncetion.QueryFirstOrDefault<string>(query);
                return values;
            }
        }

        public int ProductCount()
        {
            string query = "Select Count(*) from product"; 
            using (var conncetion = _context.CreateConnection())
            {
                var values = conncetion.QueryFirstOrDefault<int>(query);
                return values;
            }
        }
    }
}
