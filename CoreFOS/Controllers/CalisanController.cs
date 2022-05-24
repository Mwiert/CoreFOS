using Microsoft.AspNetCore.Mvc;
using CFOS.EntityLayer.Concretes;
using CFOS.ServiceLayer.Concretes.dotnetCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication;

namespace CoreFOS.Controllers
{
    [Authorize(Roles ="Yetkili")]
    public class CalisanController : Controller
    {
        public static readonly string UserId;
        
        Materials materials = new Materials();
        CoatingInfo coatingInfo = new CoatingInfo();
        List<Customer> customerList = new List<Customer>();
        Order order = new Order();
        List<CoatingInfo > coatingInfos = new List<CoatingInfo>();
        Machine machine = new Machine();
        Product product = new Product();
        RawMaterial rawMaterial = new RawMaterial();
        List<Materials> MaterialsList = new List<Materials>();
        List<Machine> Machines = new List<Machine>();
        List<Product> products = new List<Product>();
        List<Order> Orders = new List<Order>();
        List<RawMaterial> rawMaterials = new List<RawMaterial>();
        AdminService AdminService = new AdminService();
        OtherService OtherService = new OtherService();
        CalisanService CalisanService = new CalisanService();
        public static string Email;
        public IActionResult Index(string email)
        {
            Email = email;
            return View("~/Views/Calisan/CalisanPanel.cshtml");
        }
        public IActionResult AddMaterial(int MaterialLenght, int MaterialCount, string MaterialExp)
        {
            if (MaterialLenght != 0)
            {
                materials.MalzemeUzunluk = MaterialLenght;
                materials.MalzemeAdedi = MaterialCount;
                materials.MalzemeAciklama = MaterialExp;
                OtherService.MaterialAdd(materials);
                MaterialsList = OtherService.MaterialList();
                ViewBag.MaterialList = MaterialsList;
                return View("~/Views/Calisan/ListMaterial.cshtml");
            }
            return View("~/Views/Calisan/AddMaterial.cshtml");
        }
        public IActionResult DeleteMaterial(int id)
        {
            if (id != 0)
            {
                OtherService.DeleteMaterial(id);
                MaterialsList = OtherService.MaterialList();
                ViewBag.MaterialList = MaterialsList;
            }
            return View("~/Views/Calisan/ListMaterial.cshtml");
        }
        public IActionResult ListMaterial()
        {
            //malzeme adı neden yok?
            MaterialsList = OtherService.MaterialList();
            ViewBag.MaterialList = MaterialsList;
            return View("~/Views/Calisan/ListMaterial.cshtml");
        }
        public IActionResult AddOrder(int HammadeId, int KaplamaId, bool KesmeOK, bool TaslamaOK, bool BilemeOK, bool KumlamaOK, int MachineId, int MusteriId) // düzeltilecek
        {
            if (HammadeId != 0)
            {

                coatingInfo.KaplamaAdi = OtherService.GetCoationgInfoNameById(HammadeId);
                rawMaterial.HammaddeAdi = OtherService.GetRawMaterialNameById(KaplamaId);
                order.Hammadde.HammaddeId = HammadeId;
                order.Kaplama.KaplamaNo = KaplamaId;
                order.TamamlanmaSuresi = 3000;
                order.SiparisTarihi = DateTime.Now;
                order.SevkDurumu = false;
                order.Calisan.CalisanId = 1; //Claimsten Mevcut kullanıcı id çek ve yazdir
                order.TahminiSure = 3000; // makine öğrenmesi algoritmasi tahmin ettirelecekti
                order.SevkTarihi = DateTime.MaxValue;
                order.Musteri.UserId = MusteriId;
                order.Makine.MakineId = MachineId;
                if (KesmeOK != true)
                {
                    order.Kesme = false;
                }
                else
                {
                    order.Kesme = true;
                }
                if (TaslamaOK != true)
                {
                    order.Kesme = false;
                }
                else
                {
                    order.Kesme = true;
                }
                if (BilemeOK != true)
                {
                    order.Bileme = false;
                }
                else
                {
                    order.Bileme = true;
                }
                if (KumlamaOK != true)
                {
                    order.Kumlama = false;
                }
                else
                {
                    order.Kumlama = true;
                }
            }
            else
            {
                Machines = OtherService.MachineList();
                ViewBag.MachineList = Machines;
                customerList = CalisanService.listCustomer();
                ViewBag.CustomerList = customerList;
                coatingInfos = OtherService.CoatingInfoList();
                ViewBag.CoatingInfoList = coatingInfos;
                rawMaterials = OtherService.rawMaterialList();
                ViewBag.RawMaterialList = rawMaterials;
            }
            return View("~/Views/Calisan/AddOrder.cshtml");
        }
        public IActionResult DeleteOrder(int OrderId)
        {
            AdminService.getCustomerById(OrderId);
            Orders = CalisanService.listOrder();
            ViewBag.OrderList = Orders;
            if (OrderId != 0)
            {
                CalisanService.deleteOrder(OrderId);
                Orders = CalisanService.listOrder();
                ViewBag.Orders = Orders;
            }
            return View("~/Views/Calisan/DeleteOrder.cshtml");
        }
        public IActionResult ListOrder()
        {
            Orders = CalisanService.listOrder();
            ViewBag.OrderList = Orders;
            return View("~/Views/Calisan/ListOrder.cshtml");
        }
        public async Task<IActionResult> Logout()
        {
            try
            {
                await HttpContext.SignOutAsync();
                return View("~/Views/Login/LoginView.cshtml");
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        public IActionResult AddMachine(string MakineAdi)
        {
            if (!string.IsNullOrEmpty(MakineAdi))
            {
                machine.MakineAdi = MakineAdi;

                OtherService.MachinelAdd(machine);
                Machines = OtherService.MachineList();
                ViewBag.MachineList = Machines;
                return View("~/Views/Calisan/ListMachine.cshtml");
            }
            return View("~/Views/Calisan/AddMachine.cshtml");
        }
        public IActionResult DeleteMachine(int id)
        {
            if (id != 0)
            {
                OtherService.MachinelDelete(id);
                Machines = OtherService.MachineList();
                ViewBag.MachineList = Machines;
            }
            return View("~/Views/Calisan/ListMachine.cshtml");
        }
        public IActionResult ListMachine()
        {
            Machines = OtherService.MachineList();
            ViewBag.MachineList = Machines;
            return View("~/Views/Calisan/ListMachine.cshtml");
        }
        public IActionResult AddRawMaterial(string RawMaterialName, string RawMaterialSerialNo, double RawMaterialCap, int RawMaterialBoy)
        {
            if (!string.IsNullOrEmpty(RawMaterialName))
            {
                rawMaterial.HammaddeAdi = RawMaterialName;
                rawMaterial.HammaddeSeriNo = RawMaterialSerialNo;
                rawMaterial.HammaddeBoy = RawMaterialBoy;
                rawMaterial.HammaddeCap = RawMaterialCap;

                OtherService.rawMaterialAdd(rawMaterial);
                rawMaterials = OtherService.rawMaterialList();
                ViewBag.RawMaterialList = rawMaterials;
                return View("~/Views/Calisan/ListRawMaterial.cshtml");
            }
            return View("~/Views/Calisan/AddRawMaterial.cshtml");
        }
        public IActionResult ListRawMaterial()
        {
            rawMaterials = OtherService.rawMaterialList();
            ViewBag.RawMaterialList = rawMaterials;
            return View("~/Views/Calisan/ListRawMaterial.cshtml");
        }
        public IActionResult DeleteRawMaterial(int id)
        {
            rawMaterials = OtherService.rawMaterialList();
            ViewBag.RawMaterialList = rawMaterials;
            if (id != 0)
            {
                OtherService.rawMaterialDelete(id);
                rawMaterials = OtherService.rawMaterialList();
                ViewBag.RawMaterialList = rawMaterials;
            }
            return View("~/Views/Calisan/ListRawMaterial.cshtml");
        }
        public IActionResult AddCoatingInfo(string CoatName, DateTime CoatSevkTime, DateTime CoatTeslimTarihi)
        {
            if (!string.IsNullOrEmpty(CoatName))
            {
                coatingInfo.KaplamaAdi = CoatName;
                coatingInfo.SevkTarihi = CoatSevkTime;
                coatingInfo.TeslimTarihi = CoatTeslimTarihi;

                OtherService.CoatingInfoAdd(coatingInfo);
                coatingInfos = OtherService.CoatingInfoList();
                ViewBag.CoatingInfoList = coatingInfos;

                return View("~/Views/Calisan/ListCoatingInfo.cshtml");
            }

            return View("~/Views/Calisan/AddCoatingInfo.cshtml");
        }
        public IActionResult ListCoatingInfo()
        {
            coatingInfos = OtherService.CoatingInfoList();
            ViewBag.CoatingInfoList = coatingInfos;

            return View("~/Views/Calisan/ListCoatingInfo.cshtml");
        }
        public IActionResult DeleteCoatingInfo(int id)
        {
            if (id != 0)
            {
                OtherService.CoatingInfoDelete(id);
                coatingInfos = OtherService.CoatingInfoList();
                ViewBag.CoatingInfoList = coatingInfos;
            }
            return View("~/Views/Calisan/ListCoatingInfo.cshtml");
        }
        public IActionResult ListProduct()
        {
            products = CalisanService.listProduct();
            ViewBag.ProductList = products;
            return View("~/Views/Calisan/ListProduct.cshtml");
        }
        public IActionResult DeleteProduct(int id)
        {
            CalisanService.deleteProduct(id);
            products = CalisanService.listProduct();
            ViewBag.ProductList = products;
            return View("~/Views/Calisan/ListProduct.cshtml");
        }
        public IActionResult AddProduct(string UrunAdi, string UrunKodu, double OnCap, double ArkaCap, double HelisBoyu, double HamBoy, int AgizSayisi, int HelisAcisi)
        {
            if (!string.IsNullOrEmpty(UrunAdi))
            {
                product.UrunAdi = UrunAdi;
                product.UrunKodu = UrunKodu;
                product.ArkaCap = ArkaCap;
                product.HelisBoyu = HelisBoyu;
                product.HamBoy = HamBoy;
                product.AgizSayisi = AgizSayisi;
                product.HelisAcisi = HelisAcisi;
                product.OnCap = OnCap;
                CalisanService.insertProdut(product);
                products = CalisanService.listProduct();
                ViewBag.ProductList = products;
                return View("~/Views/Calisan/ListProduct.cshtml");
            }

            return View("~/Views/Calisan/AddProduct.cshtml");
        }
    }
}
