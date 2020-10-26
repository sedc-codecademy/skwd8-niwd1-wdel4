﻿using SEDC.Lamazon.DataAccess.Interfaces;
using SEDC.Lamazon.Domain.Enum;
using SEDC.Lamazon.Domain.Models;
using SEDC.Lamazon.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SEDC.Lamazon.Services.Services
{
    public class OrderService : IOrderService
    {
        protected readonly IRepository<Product> _productRepository;
        protected readonly IRepository<Order> _orderRepository;
        protected readonly IUserRepository _userRepository;

        public OrderService(IRepository<Product> productRepository,
                            IRepository<Order> orderRepository,
                            IUserRepository userRepository)
        {
            _productRepository = productRepository;
            _orderRepository = orderRepository;
            _userRepository = userRepository;
        }

        //TODO: Refactor the code when ViewModels will be implemented
        public IEnumerable<Order> GetAllOrders()
        {
            IEnumerable<Order> orders = _orderRepository.GetAll();
            return orders;
        }

        public Order GetCurrentOrder(int userId)
        {
            try
            {
                Order order = _orderRepository.GetAll()
                                              .Where(x => x.UserId == userId)
                                              .LastOrDefault();
                return order;
            }
            catch (Exception ex)
            {
                string message = ex.Message;
                throw new Exception(message);
            }
        }

        public Order GetOrderById(int id)
        {
            try
            {
                return _orderRepository.GetById(id);
            }
            catch (Exception ex)
            {
                string message = ex.Message;
                throw new Exception(message);
            }
        }

        public int AddProduct(int orderId, int productId, int userId)
        {
            try
            {
                Product product = _productRepository.GetById(productId);
                Order order = _orderRepository.GetById(orderId);

                User user = _userRepository.GetById(userId);

                order.ProductOrders.Add(
                        new ProductOrder
                        {
                            Product = product,
                            Order = order
                        }
                    );
                order.User = user;
                return _orderRepository.Update(order);
            }
            catch (Exception ex)
            {
                string message = ex.Message;
                throw new Exception(message);
            }
        }

        public int CreateOrder(Order order, int userId)
        {
            try
            {
                User user = _userRepository.GetById(userId);

                order.User = user;
                return _orderRepository.Insert(order);
            }
            catch (Exception ex)
            {
                string message = ex.Message;
                throw new Exception(message);
            }

        }

        public int ChangeStatus(int orderId, int userId, StatusType status)
        {
            try
            {
                Order order = _orderRepository.GetById(orderId);
                User user = _userRepository.GetById(userId);

                order.Status = status;

                if(status == StatusType.Pending)
                {
                    _orderRepository.Insert(
                            new Order
                            {
                                User = user,
                                DateOfOrder = DateTime.Now,
                                Status = StatusType.Init,
                            }
                        );
                }
                return _orderRepository.Update(order);
            }
            catch (Exception ex)
            {
                string message = ex.Message;
                throw new Exception(message);
            }
        }
    }
}