using Microsoft.AspNetCore.Mvc;
using QRcode.Models;

namespace QRcode.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IWebHostEnvironment _iwebhostenvironment;
    private readonly QRCodeService.QRCodeService _qrCodeService;

    public HomeController(ILogger<HomeController> _logger, IWebHostEnvironment _webHostEnvironment, QRCodeService.QRCodeService qrCodeService)
    {
        _logger = _logger ?? throw new ArgumentNullException(nameof(_logger));
        _iwebhostenvironment = _webHostEnvironment ?? throw new ArgumentNullException(nameof(_webHostEnvironment));
        _qrCodeService = qrCodeService ?? throw new ArgumentNullException(nameof(qrCodeService));
    }

    public IActionResult CreateQRCode(GenerateQRCodeModel generateQRCode)
    {
        try
        {
            string imageUrl = _qrCodeService.GenerateQRCode(generateQRCode.QRInput, _iwebhostenvironment.WebRootPath);
            ViewBag.QrCodeUrl = imageUrl;
        }
        catch (Exception ex)
        {
            ViewBag.ErrorMessage = "Failed to generate and display QR code.";
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
        //return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        return View();
    }
}