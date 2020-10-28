using SEDC.Lamazon.Domain.Enum;
using SEDC.Lamazon.Domain.Models;
using SEDC.Lamazon.WebModels.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace SEDC.Lamazon.Services.Interfaces
{
    public interface IOrderService
    {
        //TODO: Change all the User domain models with appropriate ViewModel!!!
        IEnumerable<OrderViewModel> GetAllOrders();
        OrderViewModel GetOrderById(int id);
        int CreateOrder(OrderViewModel order, int userId);
        int AddProduct(int orderId, int productId, int userId);
        OrderViewModel GetCurrentOrder(int userId);
        int ChangeStatus(int orderId, int userId, StatusType status);
    }
}
