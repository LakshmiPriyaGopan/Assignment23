using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace _23WebAPIAssignment1.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult SupplierList()
        {
            var client = new HttpClient();
            var response = client.GetAsync("http://localhost:50788/api/Suppliers").Result;
            var products = response.Content.ReadAsAsync<IEnumerable<Supplier>>().Result;
            return View(products);
        }

        public ActionResult EditSupplier(string id)
        {
            var client = new HttpClient();
            var response = client.GetAsync("http://localhost:50788/api/Suppliers/" + id).Result;
            var supplier = response.Content.ReadAsAsync<Supplier>().Result;
            return View(supplier);
        }
        public ActionResult DeleteSupplier(string id)
        {
            var client = new HttpClient();
            var response = client.GetAsync("http://localhost:50788/api/Suppliers/"+id).Result;
            var supplier = response.Content.ReadAsAsync<Supplier>().Result;
            return View(supplier);
        } 
        public ActionResult AddSupplier()
        {
            ViewBag.Message = "Add new Suppliers.";
            return View();
        }


        public ActionResult ItemList()
        {
            var client = new HttpClient();
            var response = client.GetAsync("http://localhost:50788/api/Items").Result;
            var items = response.Content.ReadAsAsync<IEnumerable<Item>>().Result;
            return View(items);
        }

        public ActionResult EditItem(string id)
        {
            var client = new HttpClient();
            var response = client.GetAsync("http://localhost:50788/api/Items/" + id).Result;
            var item = response.Content.ReadAsAsync<Item>().Result;
            return View(item);
        }
        public ActionResult DeleteItem(string id)
        {
            var client = new HttpClient();
            var response = client.GetAsync("http://localhost:50788/api/Items/" + id).Result;
            var item = response.Content.ReadAsAsync<Item>().Result;
            return View(item);
        }
        public ActionResult AddItem()
        {
            ViewBag.Message = "Add new Items.";

            return View();
        }


        public ActionResult PurchaseList()
        {
            var client = new HttpClient();
            var response = client.GetAsync("http://localhost:50788/api/PoMasters").Result;
            var poMasters = response.Content.ReadAsAsync<IEnumerable<PoMaster>>().Result;
            return View(poMasters);
        }

        public ActionResult EditPurchase(string id)
        {
            var client = new HttpClient();
            var response = client.GetAsync("http://localhost:50788/api/PoMasters/" + id).Result;
            var poMasters = response.Content.ReadAsAsync<PoMaster>().Result;

            response = client.GetAsync("http://localhost:50788/api/Suppliers").Result;
            var suppliers = response.Content.ReadAsAsync<IEnumerable<Supplier>>().Result;
            List<SelectListItem> supplierList = new List<SelectListItem>();
            foreach (Supplier sup in suppliers.ToList())
            {
                supplierList.Add(new SelectListItem
                {
                    Text = sup.SuplName,
                    Value = sup.SuplNo
                });
            }
            poMasters.Suppliers = supplierList;

            return View(poMasters);
        }
        public ActionResult DeletePurchase(string id)
        {
            var client = new HttpClient();
            var response = client.GetAsync("http://localhost:50788/api/PoMasters/" + id).Result;
            var poMasters = response.Content.ReadAsAsync<PoMaster>().Result;
            return View(poMasters);
        }
        public ActionResult AddPurchase()
        {
            ViewBag.Message = "Make new purchase.";
            var client = new HttpClient();
            var response = client.GetAsync("http://localhost:50788/api/Suppliers").Result;
            var suppliers = response.Content.ReadAsAsync<IEnumerable<Supplier>>().Result;
            PoMaster master = new PoMaster();
            List<SelectListItem> supplierList = new List<SelectListItem>();
            foreach (Supplier sup in suppliers.ToList())
            {
                supplierList.Add(new SelectListItem
                {
                    Text = sup.SuplName,
                    Value = sup.SuplNo
                });
            }
            master.Suppliers = supplierList;
            return View(master);
        }
        public ActionResult DetailsPurchase(string id)
        {
            var client = new HttpClient();
            var response = client.GetAsync("http://localhost:50788/api/PoMasters/" + id).Result;
            var poMasters = response.Content.ReadAsAsync<PoMaster>().Result;

            response = client.GetAsync("http://localhost:50788/api/Suppliers").Result;
            var suppliers = response.Content.ReadAsAsync<IEnumerable<Supplier>>().Result;
            List<SelectListItem> supplierList = new List<SelectListItem>();
            foreach (Supplier sup in suppliers.ToList())
            {
                supplierList.Add(new SelectListItem
                {
                    Text = sup.SuplName,
                    Value = sup.SuplNo
                });
            }
            poMasters.Suppliers = supplierList;

            return View(poMasters);
        }
        public ActionResult EditPurhcaseDetail(string id, string itcode)
        {
            var client = new HttpClient();
            var response = client.GetAsync("http://localhost:50788/api/PoDetails?id=" + id+ "&itcode=" + itcode).Result;
            var poDetail = response.Content.ReadAsAsync<PoDetail>().Result;
            response = client.GetAsync("http://localhost:50788/api/Items").Result;
            var items = response.Content.ReadAsAsync<IEnumerable<Item>>().Result;
            List<SelectListItem> itemsList = new List<SelectListItem>();
            foreach (Item itm in items.ToList())
            {
                itemsList.Add(new SelectListItem
                {
                    Text = itm.ItDesc,
                    Value = itm.ItCode
                });
            }
            poDetail.Items = itemsList;
            return View(poDetail);
        }
        public ActionResult DeletePurhcaseDetail(string id, string itcode)
        {
            var client = new HttpClient();
            var response = client.GetAsync("http://localhost:50788/api/PoDetails?id=" + id + "&itcode=" + itcode).Result;
            var poDetail = response.Content.ReadAsAsync<PoDetail>().Result;
            response = client.GetAsync("http://localhost:50788/api/Items/" + itcode).Result;
            Item item = response.Content.ReadAsAsync<Item>().Result; 
            poDetail.Item = item;
            response = client.GetAsync("http://localhost:50788/api/PoMasters/" + id).Result;
            PoMaster poMasters = response.Content.ReadAsAsync<PoMaster>().Result;
            poDetail.PoMaster = poMasters;
            return View(poDetail);
        }
        public ActionResult AddPurhcaseDetail(string id)
        {
            PoDetail poDetail =  new PoDetail();
                poDetail.PoNo = id;
                ViewBag.Message = "Make new purchase.";
            var client = new HttpClient();
            var response = client.GetAsync("http://localhost:50788/api/Items").Result;
            var items = response.Content.ReadAsAsync<IEnumerable<Item>>().Result;
            List<SelectListItem> itemsList = new List<SelectListItem>();
            foreach (Item itm in items.ToList())
            {
                itemsList.Add(new SelectListItem
                {
                    Text = itm.ItDesc,
                    Value = itm.ItCode
                });
            }
            poDetail.Items = itemsList;
            response = client.GetAsync("http://localhost:50788/api/PoMasters").Result;
            var PoNos = response.Content.ReadAsAsync<IEnumerable<PoMaster>>().Result;
            List<SelectListItem> PoNoList = new List<SelectListItem>();
            foreach (PoMaster poMaster in PoNos.ToList())
            {
                PoNoList.Add(new SelectListItem
                {
                    Text = poMaster.PoNo,
                    Value = poMaster.PoNo
                });
            }
            poDetail.PoNos = PoNoList;
            return View(poDetail);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}