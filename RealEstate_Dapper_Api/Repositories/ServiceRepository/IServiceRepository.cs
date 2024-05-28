using RealEstate_Dapper_Api.DTOs.CategoryDTOs;
using RealEstate_Dapper_Api.DTOs.ServiceDTOs;

namespace RealEstate_Dapper_Api.Repositories.ServiceRepository
{
    public interface IServiceRepository
    {
        Task<List<ResultServiceDTO>> GetAllServiceAsync(); // Category Read imzası 
        void CreateService(CreateServiceDTO createServiceDTO);
        void UpdateService(UpdateServiceDTO updateServiceDTO);
        void DeleteService(int id);
        Task<GetServiceByIdDTO> GetServiceAsync(int id);

    }
}
