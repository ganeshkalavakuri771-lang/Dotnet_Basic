using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShoppingDAL.Models;
namespace ShoppingDAL.Repository
{
    public interface IShoppingRepository
    {
        public interface IShoppingRepository
        {
           
            bool Register(User entUser);
            User Login(string username, string password);
            User GetUserByID(string userId);
            bool UpdateProfile(User entUser);
            int ResetPassword(string userid, string oldPass, string newPass);
           
            List<Product> SearchProducts(string searchTerm);
            List<Product> GetProducts();
            List<Product> GetProductByCategory(string category);
            Product GetProductById(int id);
            bool AddProduct(Product product);
            bool RemoveProduct(int id);
            bool UpdateProductDetails(Product entProd);
         

         
            List<Category> GetCategories();
            Category GetCategoryById(int id);
            bool AddCategory(Category category);
            bool RemoveCategory(int id);
            bool UpdateCategoryName(int id, string newName);
          
            int PlaceOrder(Order order);
      
        }

    }
}
