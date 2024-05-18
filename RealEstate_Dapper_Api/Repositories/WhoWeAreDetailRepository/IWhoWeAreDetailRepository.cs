using RealEstate_Dapper_Api.DTOs.WhoWeAreDetailDTOs;

namespace RealEstate_Dapper_Api.Repositories.WhoWeAreDetailRepository
{
    public interface IWhoWeAreDetailRepository
    {
        Task<List<ResultWhoWeAreDetailDTO>> GetAllWhoWeAreDetailAsync();
        void CreateWhoWeAreDetail(CreateWhoWeAreDetailDTO createWhoWeAreDetailDTO);
        void DeleteWhoWeAreDetail(int id);
        void UpdateWhoWeAreDetail(UpdateWhoWeAreDetailDTO updateWhoWeAreDetailDTO);

        Task<GetByIDWhoWeAreDetailDTO> GetWhoWeAreDetail(int id);
    }
}
