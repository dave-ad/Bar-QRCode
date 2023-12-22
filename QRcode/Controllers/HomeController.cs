using Microsoft.AspNetCore.Mvc;
using CodeGen.Models;

namespace CodeGen.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IWebHostEnvironment _iwebhostenvironment;
    private readonly QRCodeService.QRCodeService _qrCodeService;
    private readonly BarCodeService.BarCodeService _barCodeService;

    public HomeController(ILogger<HomeController> _logger, IWebHostEnvironment _webHostEnvironment, QRCodeService.QRCodeService qrCodeService, BarCodeService.BarCodeService barCodeService)
    {
        _logger = _logger ?? throw new ArgumentNullException(nameof(_logger));
        _iwebhostenvironment = _webHostEnvironment ?? throw new ArgumentNullException(nameof(_webHostEnvironment));
        _qrCodeService = qrCodeService ?? throw new ArgumentNullException(nameof(qrCodeService));
        _barCodeService = barCodeService ?? throw new ArgumentNullException(nameof(barCodeService));
    }

    public IActionResult CreateQRCode(GenerateCodeModel generateQRCode)
    {
        try
        {
            string imageUrl = _qrCodeService.GenerateQRCode(generateQRCode.Input, _iwebhostenvironment.WebRootPath);
            ViewBag.QrCodeUrl = imageUrl;
        }
        catch (Exception)
        {
            ViewBag.ErrorMessage = "Failed to generate and display QR code.";
        }

        return View();
    }

    public IActionResult CreateBarCode(GenerateCodeModel generateBarCode)
    {
        try
        {
            string imageUrl = _barCodeService.GenerateBarCode(generateBarCode.Input, _iwebhostenvironment.WebRootPath);
            ViewBag.BarCodeUrl = imageUrl;
        }
        catch (Exception)
        {
            ViewBag.ErrorMessage = "Failed to generate and display Bar code.";
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

    public IActionResult Error()
    {
        return View();
    }
}