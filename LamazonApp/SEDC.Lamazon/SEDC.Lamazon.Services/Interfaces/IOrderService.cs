using SEDC.Lamazon.Domain.Enum;
using SEDC.Lamazon.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SEDC.Lamazon.Services.Interfaces
{
    public interface IOrderService
    {
        //TODO: Change all the User domain models with appropriate ViewModel!!!
        IEnumerable<Order> GetAllOrders();
        Order GetOrderById(int id);
        int CreateOrder(Order order, int userId);
        int AddProduct(int orderId, int productId, int userId);
        Order GetCurrentOrder(int userId);
        int ChangeStatus(int orderId, int userId, StatusType status);
    }
}
