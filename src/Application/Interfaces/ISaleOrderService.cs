using Domain.Entities;
using Application.Models.DTOs;

namespace Application.Interfaces
{
    public interface ISaleOrderService
    {
        List<SaleOrder> GetAllByClient(int clientId);
        SaleOrder? GetById(int id);
        int AddSaleOrder(SaleOrderDto dto);
        void DeleteSaleOrder(int id);
        void UpdateSaleOrder(int id, SaleOrderDto dto);
    }
}
