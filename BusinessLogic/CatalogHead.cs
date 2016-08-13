////using Data;
////using Data.Models;
////using Models;
////using Services;
////using System;
////using System.Collections.Generic;
////using System.Linq;
////using System.Text;
////using System.Threading.Tasks;

//using Data;
//using Data.Models;
//using Models;
//using Services;
//using System.Collections.Generic;
//namespace BusinessLogic
//{
//    class CatalogHead
//    {
//        private ApplicationDbContext db = new ApplicationDbContext();
//        private IRangamoRepository _rangamoRepository;
//        public CatalogHead()
//        {
//            this._rangamoRepository = new RangamoRepository(new ApplicationDbContext());
//        }
//        public List<Product> AllowedProducts()
//        {
//            List<Product> ap = new List<Product>();
//            foreach (Product item in _rangamoRepository.GetAllProducts())
//            {
//                var result = _rangamoRepository.ReadInventory(item.ProductId);
//               // var result = db.InventoryItems.ToList().Find(p => p.ProductId == item.ProductId);
//                if (result != null)
//                {
//                    if (result.StockOnHand > 25)
//                    {
//                        ap.Add(item);
//                    }
//                }
//            }
//            return ap;
//        }
//        public List<ReOrderRequest> AcceptedReStocks()
//        {
//            List<ReOrderRequest> ror = new List<ReOrderRequest>();
//            foreach (ReOrderRequest item in _rangamoRepository.GetAllReOrders())
//            {
//                if (item.Approval==true)
//                {
//                    ror.Add(item);
//                }
//            }
//            return ror;
//        }
//        public List<Order> ProcessedOrders()
//        {
//            return _rangamoRepository.GetAllOrders().ToList();
//        }
//        public List<ReOrderRequest> RequestedRestock()
//        {
//            return _rangamoRepository.GetAllReOrders();
//        }
//        public List<Order> RequestedOrders()
//        {
//            return _rangamoRepository.GetAllOrders();
//        }

//   }
//}
