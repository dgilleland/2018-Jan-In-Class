using NorthwindEntities; // Product, Category, Supplier classes
using NorthwindSystem.DAL; // NorthwindContext
using System.Collections.Generic; // List<T>
using System.Linq; // for extension methods such as .ToList()

namespace NorthwindSystem.BLL
{
    // This class is the public access into our system/application
    // that will be used by the website to provide CRUD maintenance
    // for inventory related data.
    public class InventoryPurchasingController
    {
        #region Product CRUD
        public List<Product> ListAllProducts()
        {
            using (var context = new NorthwindContext())
            {
                return context.Products.ToList();
            }
        }
        #endregion

        #region Category CRUD
        #endregion

        #region Supplier CRUD
        #endregion
    }
}
