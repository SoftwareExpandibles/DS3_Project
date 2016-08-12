using Data;
using Data.Models;
using Models;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace BusinessLogic
{
   public class CatalogHead
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        private IRangamoRepository _rangamoRepository;
        public CatalogHead()
        {
            this._rangamoRepository = new RangamoRepository(new ApplicationDbContext());
        }
        public List<Product> AllowedProducts()
        {
            List<Product> ap = new List<Product>();
            foreach (Product item in _rangamoRepository.GetAllProducts())
            {
                var result = _rangamoRepository.ReadInventory(item.ProductId);
               // var result = db.InventoryItems.ToList().Find(p => p.ProductId == item.ProductId);
                if (result != null)
                {
                    if (result.StockOnHand > 25)
                    {
                        ap.Add(item);
                    }
                }
            }
            return ap;
        }
        public List<MonthlyReOrderCounters> AcceptedReStocks()
        {
            return _rangamoRepository.GetAllMonthlyReOrderCounters().ToList();
        }
        public List<DailyOrderCounters> ProcessedOrders()
        {
            return _rangamoRepository.GetAllDailyOrderCounters().ToList();
        }
        public List<DailyReOrderCounters> RequestedRestock()
        {
            return _rangamoRepository.GetAllDailyReOrderCounters().ToList();
        }
        public List<MonthlyOrderCounters> RequestedOrders()
        {
            return _rangamoRepository.GetAllMonthlyOrderCounters().ToList();
        }

    }
}
