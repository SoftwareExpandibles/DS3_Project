using Data;
using Data.Models;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Services
{
   public class RangamoRepository:IRangamoRepository
    {
       private readonly ApplicationDbContext _context;
       public RangamoRepository(ApplicationDbContext rangamocontext)
       {
           this._context = rangamocontext;
       }
       //Products
       public IEnumerable<Product> GetAllProducts()
       {
           var products = _context.Products.Include(p => p.Genre).Include(p => p.Size).Include(p => p.Supplier);
           return (IEnumerable<Product>) products;
       }
       public Product ReadProduct(int id)
       {
           return (Product)_context.Products.Find(id);
       }
       public void CreateProduct(Product product)
       {
          _context.Products.Add(product);
       }
       public void DeleteProduct(int id)
       {
          var product = _context.Products.ToList().Find(p=>p.ProductId==id);
           _context.Products.Remove(product);
       }
       public void UpdateProduct(Product product)
       {
           _context.Entry(product).State = EntityState.Modified;
       }

       //Genre
       public IEnumerable<Genre> GetAllGenres()
       {
           return (IEnumerable<Genre>)_context.Genres.ToList();
       }
       public Genre ReadGenre(int id)
       {
           return (Genre)_context.Genres.Find(id);
       }
       public void CreateGenre(Genre genre)
       {
           _context.Genres.Add(genre);
       }
       public void DeleteGenre(int id)
       {
           var genre = _context.Genres.ToList().Find(p => p.genreID == id);
           _context.Genres.Remove(genre);
       }
       public void UpdateGenre(Genre genre)
       {
           _context.Entry(genre).State = EntityState.Modified;
       }

       //Sizes
       public IEnumerable<Size> GetAllSizes()
       {
           return (IEnumerable<Size>)_context.Sizes.ToList();
       }
       public Size ReadSize(int id)
       {
           return (Size)_context.Sizes.Find(id);
       }
       public void CreateSize(Size size)
       {
           _context.Sizes.Add(size);
       }
       public void DeleteSize(int id)
       {
           var size = _context.Sizes.ToList().Find(p => p.sizeId == id);
           _context.Sizes.Remove(size);
       }
       public void UpdateSize(Size size)
       {
           _context.Entry(size).State = EntityState.Modified;
       }

       //Employees
       public IEnumerable<Employee> GetAllEmployees()
       {
           return (IEnumerable<Employee>) _context.Employees.ToList();
       }
       public Employee ReadEmployee(int id)
       {
           return (Employee)_context.Employees.Find(id);
       }
       public void CreateEmployee(Employee employee)
       {
           _context.Employees.Add(employee);
       }
       public void DeleteEmployee(int id)
       {
           var employee = _context.Employees.ToList().Find(p => p.employeeID == id);
           _context.Employees.Remove(employee);
       }
       public void UpdateEmployee(Employee employee)
       {
           _context.Entry(employee).State = EntityState.Modified;
       }
       public void Save()
       {
           _context.SaveChanges();
       }
       
       //Customer
       public IEnumerable<Customer> GetAllCustomers()
       {
           return (IEnumerable<Customer>)_context.Customers.ToList();
       }

       public Customer ReadCustomer(int id)
       {
           return (Customer)_context.Customers.Find(id);
       }

       public void CreateCustomer(Customer customer)
       {
           _context.Customers.Add(customer);

       }

       public void DeleteCustomer(int id)
       {
           var customer = _context.Customers.ToList().Find(c => c.customerID == id);
           _context.Customers.Remove(customer);
       }

       public void UpdateCustomer(Customer customer)
       {
           _context.Entry(customer).State = EntityState.Modified;
       }
       //Inventory

       public IEnumerable<Inventory> GetInventory()
       {
           var inventories = _context.Inventories;
           return (IEnumerable<Inventory>)_context.Inventories.ToList();
          
       }

       public Inventory ReadInventory(int id)
       {
           return (Inventory) _context.Inventories.ToList().Find(p =>p.ProductId == id);
       }

       public void CreateInventory(Inventory inventory)
       {
           _context.Inventories.Add(inventory);
       }

       public void DeleteInventory(int id)
       {
           var inventory = _context.Inventories.ToList().Find(i =>i.InventoryID == id);
           _context.Inventories.Remove(inventory);
       }

       public void UpdateInventory(Inventory inventory)
       {
           _context.Entry(inventory).State = EntityState.Modified;
       }
       //Supplier
       public IEnumerable<Supplier> GetSuppliers()
       {
           var supplier = _context.Suppliers;
           return (IEnumerable<Supplier>)_context.Suppliers.ToList();
       }

       public Supplier ReadSupplier(int id)
       {
           return (Supplier)_context.Suppliers.Find(id);
       }

       public void CreateSupplier(Supplier supplier)
       {
           _context.Suppliers.Add(supplier);
       }

       public void DeleteSupplier(int id)
       {
           var supplier = _context.Suppliers.ToList().Find(s =>s.SupplierID == id);
           _context.Suppliers.Remove(supplier);
       }

       public void UpdateSupplier(Supplier supplier)
       {
           _context.Entry(supplier).State = EntityState.Modified;
       }

       //Warehouse
       public IEnumerable<Warehouse> GetWarehouse()
       {
           return (IEnumerable<Warehouse>)_context.Warehouses.ToList();
       }

       public Warehouse ReadWarehouse(int id)
       {
           return (Warehouse)_context.Warehouses.Find(id);
       }

       public void CreateWarehouse(Warehouse warehouse)
       {
           _context.Warehouses.Add(warehouse);
       }

       public void DeleteWarehouse(int id)
       {
           var warehouse = _context.Warehouses.ToList().Find(c => c.warehouseID == id);
           _context.Warehouses.Remove(warehouse);
       }

       public void UpdateWarehouse(Warehouse warehouse)
       {
           _context.Entry(warehouse).State = EntityState.Modified;
       }

        //ReOrderRequest
        public IEnumerable<ReOrderRequest> GetAllReOrders()
        {
            return (IEnumerable<ReOrderRequest>)_context.ReOrderRequests.ToList();
        }

        public ReOrderRequest ReadReOrder(int id)
        {
            return (ReOrderRequest)_context.ReOrderRequests.Find(id);
        }

        public void CreateReOrder(ReOrderRequest reOrder)
        {
            _context.ReOrderRequests.Add(reOrder);
        }

        public void DeleteReOrder(int id)
        {
            var reOrder = _context.ReOrderRequests.ToList().Find(c => c.ReOrderId == id);
            _context.ReOrderRequests.Remove(reOrder);
        }

        public void UpdateReOrder(ReOrderRequest reOrder)
        {
            _context.Entry(reOrder).State = EntityState.Modified;
        }
        //Order
        public IEnumerable<Order> GetAllOrders()
        {
            return (IEnumerable<Order>)_context.Orders.ToList();
        }

        public Order ReadOrder(int id)
        {
            return (Order)_context.Orders.Find(id);
        }

        public void CreateOrder(Order order)
        {
            _context.Orders.Add(order);
        }

        public void DeleteOrder(int id)
        {
            var order = _context.Orders.ToList().Find(c => c.OrderID == id);
            _context.Orders.Remove(order);
        }

        public void UpdateOrder(Order order)
        {
            _context.Entry(order).State = EntityState.Modified;
        }
        //DailyReOrderCounters
        public IEnumerable<DailyReOrderCounters> GetAllDailyReOrderCounters()
        {
            return (IEnumerable<DailyReOrderCounters>)_context.DailyReOrderCounter.ToList();
        }


        public void CreateDailyReOrderCounters(DailyReOrderCounters drc)
        {
            _context.DailyReOrderCounter.Add(drc);
        }


        public void UpdateDailyReOrderCounters(DailyReOrderCounters drc)
        {
            _context.Entry(drc).State = EntityState.Modified;
        }

        //DailyOrderCounters
        public IEnumerable<DailyOrderCounters> GetAllDailyOrderCounters()
        {
            return (IEnumerable<DailyOrderCounters>)_context.DailyOrderCounter.ToList();
        }


        public void CreateDailyOrderCounters(DailyOrderCounters drc)
        {
            _context.DailyOrderCounter.Add(drc);
        }


        public void UpdateDailyOrderCounters(DailyOrderCounters drc)
        {
            _context.Entry(drc).State = EntityState.Modified;
        }

        //MonthlyReOrderCounters
        public IEnumerable<MonthlyReOrderCounters> GetAllMonthlyReOrderCounters()
        {
            return (IEnumerable<MonthlyReOrderCounters>)_context.MonthlyReOrderCounter.ToList();
        }


        public void CreateMonthlyReOrderCounters(MonthlyReOrderCounters drc)
        {
            _context.MonthlyReOrderCounter.Add(drc);
        }


        public void UpdateMonthlyReOrderCounters(MonthlyReOrderCounters drc)
        {
            _context.Entry(drc).State = EntityState.Modified;
        }

        //MonthlyOrderCounters
        public IEnumerable<MonthlyOrderCounters> GetAllMonthlyOrderCounters()
        {
            return (IEnumerable<MonthlyOrderCounters>)_context.MonthlyOrderCounter.ToList();
        }


        public void CreateMonthlyOrderCounters(MonthlyOrderCounters drc)
        {
            _context.MonthlyOrderCounter.Add(drc);
        }


        public void UpdateMonthlyOrderCounters(MonthlyOrderCounters drc)
        {
            _context.Entry(drc).State = EntityState.Modified;
        }
        public void Dispose()
       {
            _context.Dispose();
       }



       
    }
}
