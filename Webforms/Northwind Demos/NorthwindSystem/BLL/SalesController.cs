using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NorthwindEntities;
using NorthwindSystem.DAL;
using System.Data.SqlClient;

namespace NorthwindSystem.BLL
{
    public class SalesController
    {
        public List<Customer> ListAllCustomers()
        {
            using (var context = new NorthwindContext())
            {
                return context.Customers.ToList();
            }
        }

        public List<Employee> ListAllEmployees()
        {
            using (var context = new NorthwindContext())
            {
                return context.Employees.ToList();
            }
        }

        public List<Shipper> ListAllShippers()
        {
            using (var context = new NorthwindContext())
            {
                return context.Shippers.ToList();
            }
        }

        public List<Order> GetCustomerOrders(string customerId)
        {
            using (var context = new NorthwindContext())
            {
                var param = new SqlParameter("CustomerID", customerId);
                var result = context.Database.SqlQuery<Order>("EXEC Orders_GetByCustomers @CustomerID", param);
                return result.ToList();
            }
        }
    }
}
