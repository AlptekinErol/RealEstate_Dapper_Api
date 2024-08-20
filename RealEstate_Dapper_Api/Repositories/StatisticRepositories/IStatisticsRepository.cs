namespace RealEstate_Dapper_Api.Repositories.StatisticRepositories
{
    public interface IStatisticsRepository
    {
        // Summary : Site için gerekli istatistik verilerini tutması için oluşturulan interface
        // burada ki amaç genel olarak sql sorgularını çeşitlendirebilmek adına pratik amaçlı methodlardır fonksiyonel açıdan amaç güdülmemiştir.
        int CategoryCount(); // kategori sayısı 
        int ActiveCategoryCount(); // aktif kategori sayfası
        int DeactiveCategoryCount(); // deaktif kategori sayısı
        int ProductCount(); // product sayısı
        int ApartmentCount(); // daire sayısı 
        string EmployeeNameByMaxProduct(); // en fazla ürünü bulunan çalışan adı
        string CategoryNameByMaxProductCount(); // en fazla kategorisi olan 
        decimal AverageProductPriceByRent(); // ortalana kiralık fiyatı
        decimal AverageProductPriceBySale(); // ortalama satılık fiyatı
        string CityNameByMaxProductCount();  // en fazla ilan bulundurulan şehir
        int DifferentCityCount(); // kaç farklı şehir ilan sayısı
        decimal LastProductPrice(); // Son eklenen ilanın fiyatı
        string NewestBuildingYear(); // En yeni binanın ilanı
        string OldestBuildingYear(); // En eski binanın ilanı
        int ActiveEmployeeCount(); // Aktif çalışan sayısı
        int AvereageRoomCount(); // Ortalama oda sayısı
    }
}
