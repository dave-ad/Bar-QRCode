using IronBarCode;
using Microsoft.AspNetCore.Mvc;
using QRcode.Models;
using System.Diagnostics;

namespace QRcode.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IWebHostEnvironment _iwebhostenvironment;

        public HomeController(IWebHostEnvironment _webHostEnvironment)
        {
            _iwebhostenvironment = _webHostEnvironment;
        }

        public  IActionResult CreateQRCode()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateQRCode(GenerateQRCodeModel GenerateQRCode)
        {
            try
            {
                GeneratedBarcode barcode = QRCodeWriter.CreateQrCode(GenerateQRCode.QRInput, 200);
                barcode.AddBarcodeValueTextBelowBarcode();
                barcode.SetMargins(10);
                barcode.ChangeBarCodeColor(Color.Black);
                string path = Path.Combine(_iwebhostenvironment.WebRootPath, "GeneratedQRCode");
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                string filePath = Path.Combine(_iwebhostenvironment.WebRootPath, "GeneratedQRCode/qrcode.png");
                barcode.SaveAsPng(filePath);
                string filename = Path.GetFileName(filePath);
                string imageUrl = $"{this.Request.Scheme}:{this.Request.Host}{this.Request.PathBase}" + "/GeneratedQRCode/ " + filename;
                ViewBag.QrCodeUrl = imageUrl;
            }
            catch (Exception)
            {
                throw;
            }
            return View();
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            //return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
            return View();
        }
    }
}