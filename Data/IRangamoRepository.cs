using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
   public interface IRangamoRepository:IDisposable
    {
        IEnumerable<Genre> GetAllGenres();
        Genre ReadGenre(int id);
        void CreateGenre(Genre genre);
        void DeleteGenre(int id);
        void UpdateGenre(Genre genre);

        IEnumerable<Size> GetAllSizes();
        Size ReadSize(int id);
        void CreateSize(Size size);
        void DeleteSize(int id);
        void UpdateSize(Size size);

        IEnumerable<Product> GetAllProducts();
        Product ReadProduct(int id);
        void CreateProduct(Product product);
        void DeleteProduct(int id);
        void UpdateProduct(Product product);

        IEnumerable<Inventory> GetInventory();
        Inventory ReadInventory(int id);
        void CreateInventory(Inventory inventory);
        void DeleteInventory(int id);
        void UpdateInventory(Inventory inventory);

        IEnumerable<Supplier> GetSuppliers();
        Supplier ReadSupplier(int id);
        void CreateSupplier(Supplier supplier);
        void DeleteSupplier(int id);
        void UpdateSupplier(Supplier supplier);
      
        void CreateCustomer(Customer customer);
        void DeleteCustomer(int id);
        void UpdateCustomer(Customer customer);

        IEnumerable<Employee> GetAllEmployees();
        Employee ReadEmployee(int id);
        void CreateEmployee(Employee employee);
        void DeleteEmployee(int id);
        void UpdateEmployee(Employee employee);

        IEnumerable<Warehouse> GetWarehouse();
        Warehouse ReadWarehouse(int id);
        void CreateWarehouse(Warehouse warehouse);
        void DeleteWarehouse(int id);
        void UpdateWarehouse(Warehouse warehouse);

        IEnumerable<ReOrderRequest> GetAllReOrders();
        ReOrderRequest ReadReOrder(int id);
        void CreateReOrder(ReOrderRequest reOrder);
        void DeleteReOrder(int id);
        void UpdateReOrder(ReOrderRequest reOrder);

        IEnumerable<Order> GetAllOrders();
        Order ReadOrder(int id);
        void CreateOrder(Order order);
        void DeleteOrder(int id);
        void UpdateOrder(Order order);

        IEnumerable<DailyReOrderCounters> GetAllDailyReOrderCounters();
        void CreateDailyReOrderCounters(DailyReOrderCounters drc);
        void UpdateDailyReOrderCounters(DailyReOrderCounters drc);

        IEnumerable<DailyOrderCounters> GetAllDailyOrderCounters();
        void CreateDailyOrderCounters(DailyOrderCounters drc);
        void UpdateDailyOrderCounters(DailyOrderCounters drc);

        IEnumerable<MonthlyReOrderCounters> GetAllMonthlyReOrderCounters();
        void CreateMonthlyReOrderCounters(MonthlyReOrderCounters drc);
        void UpdateMonthlyReOrderCounters(MonthlyReOrderCounters drc);

        IEnumerable<MonthlyOrderCounters> GetAllMonthlyOrderCounters();
        void CreateMonthlyOrderCounters(MonthlyOrderCounters drc);
        void UpdateMonthlyOrderCounters(MonthlyOrderCounters drc);
        IEnumerable<Item> GetAllItems();
        Item ReadItem(int id);
        void CreateItem(Item item);
        void DeleteItem(int id);
        void UpdateItem(Item item);
        void Save();
    }
}
