using Microsoft.EntityFrameworkCore;
using ShoppingDAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingDAL.Repository
{
    public class ShoppingRepository:IShoppingRepository
    {
        private ShoppingContext context;
        public ShoppingRepository()
        {
            context = new ShoppingContext();
        }

        public bool Register(User entUser)
        {
            bool result = false;
            try
            {
                context.Users.Add(entUser);
                context.SaveChanges();
                result = true;
            }
            catch (Exception e)
            {
                throw e;
            }
            return result;
        }

        public User Login(string username, string password)
        {
            User user = null;
            try
            {
                user = context.Users.Where(u => u.UserId == username && u.Password == password).FirstOrDefault();
            }
            catch (Exception e)
            {
                throw e;
            }
            return user;
        }

 
        public User GetUserByID(string userId)
        {
            User user = null;
            try
            {
                user = context.Users.Find(userId);
            }
            catch (Exception e)
            {
                throw e;
            }
            return user;
        }

        public bool UpdateProfile(User entUser)
        {
            bool result = false;
            try
            {
                var user = context.Users.Find(entUser.UserId);
                if (user != null)
                {
                    user.UserName = entUser.UserName;
                    user.Email = entUser.Email;
                    user.Address = entUser.Address;
                    context.SaveChanges();
                    result = true;
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            return result;
        }


        public int ResetPassword(string userid, string oldPass, string newPass)
        {
            try
            {
                User user = context.Users.Find(userid);
                if (user != null && user.Password == oldPass)
                {
                    user.Password = newPass;
                    context.SaveChanges();
                    return 1;
                }
                else
                {
                    return 0;
                }
            }
            catch (Exception e)
            {
                throw e;
                return -1;
            }
        }

        public List<Product> SearchProducts(string searchTerm)
        {
            List<Product> products = null;
            try
            {
                products = context.Products
                    .Where(p => p.ProductName.Contains(searchTerm))
                    .Include(c => c.Category)
                    .ToList();
            }
            catch (Exception e)
            {
                throw e;
            }
            return products;
        }

        
        public List<Product> GetProducts()
        {
            List<Product> products = null;
            try
            {
                products = context.Products
                    .Include(c => c.Category)
                    .ToList();
            }
            catch (Exception e)
            {
                throw e;
            }
            return products;
        }


        public List<Product> GetProductByCategory(string category)
        {
            List<Product> products = null;
            try
            {
                products = context.Products
                    .Where(p => p.Category.CategoryName == category)
                    .Include(c => c.Category)
                    .ToList();
            }
            catch (Exception e)
            {
                throw e;
            }
            return products;
        }

        
        public Product GetProductById(int id)
        {
           
            try
            {
                return context.Products.Find(id);
            }
            catch (Exception e)
            {
                throw e;
            }
           
        }

        
        public bool AddProduct(Product product)
        {
            bool flag = false;
            try
            {
                context.Products.Add(product);
                context.SaveChanges();
                flag = true;
            }
            catch (Exception e)
            {
                throw e;
            }
            return flag;
        }

        
        public bool RemoveProduct(int id)
        {
            bool flag = false;
            try
            {
                var prod = context.Products.Find(id);
                if (prod != null)
                {
                    context.Products.Remove(prod);
                    context.SaveChanges();
                    flag = true;
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            return flag;
        }

  
        public bool UpdateProductDetails(Product entProd)
        {
            bool flag = false;
            try
            {
                var prod = context.Products.Find(entProd.ProductId);
                if (prod != null)
                {
                    prod.ProductName = entProd.ProductName;
                    prod.ProductDescription = entProd.ProductDescription;
                    prod.UnitPrice = entProd.UnitPrice;
                    prod.CategoryId = entProd.CategoryId;
                    context.SaveChanges();
                    flag = true;
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            return flag;
        }

        
       
        public List<Category> GetCategories()
        {
            try
            {
                return context.Categories.ToList();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public Category GetCategoryById(int id)
        {
            try
            {
                return context.Categories.Find(id);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

       
        public bool AddCategory(Category category)
        {
            try
            {
                context.Categories.Add(category);
                context.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        
        public bool RemoveCategory(int id)
        {
            try
            {
                var cat = context.Categories.Find(id);
                if (cat != null)
                {
                    context.Categories.Remove(cat);
                    context.SaveChanges();
                    return true;
                }
                return false;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        
        public bool UpdateCategoryName(int id, string newName)
        {
            try
            {
                var cat = context.Categories.Find(id);
                if (cat != null)
                {
                    cat.CategoryName = newName;
                    context.SaveChanges();
                    return true;
                }
                return false;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public int PlaceOrder(Order order)
        {
            try
            {
                context.Orders.Add(order);
                context.SaveChanges();
                return order.OrderId;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        
    }
}
