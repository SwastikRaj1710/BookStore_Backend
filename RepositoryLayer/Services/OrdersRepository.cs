using CommonLayer.Models;
using RepositoryLayer.BookStoreDBContext;
using RepositoryLayer.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoryLayer.Services
{
    public class OrdersRepository
    {
        private BookStoreContext context;
        public OrdersRepository(BookStoreContext context)
        {
            this.context = context;
        }

        /*public OrdersEntity AddOrder(AddOrderModel model)
        {
            try
            {
                OrdersEntity entity = new OrdersEntity();
                entity.OrderDate = DateTime.Now;
                foreach (var book in entity.Books)
                {
                    
                }
                entity.Books = model.Books;
            }
            catch (Exception)
            {

                throw;
            }
        }*/
    }
}
