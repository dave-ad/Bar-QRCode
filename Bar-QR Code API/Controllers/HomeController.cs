using Bar_QR_Code_API.Models;
using BarCodeService;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace Bar_QR_Code_API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class HomeController : ControllerBase
{
    //private readonly ILogger<HomeController> _logger;
    private readonly IWebHostEnvironment _iwebhostenvironment;
    private readonly QRCodeService.QRCodeService _qrCodeService;
    private readonly BarCodeService.BarCodeService _barCodeService;

    public HomeController(/*ILogger<HomeController> _logger,*/ IWebHostEnvironment _webHostEnvironment, QRCodeService.QRCodeService qrCodeService, BarCodeService.BarCodeService barCodeService)
    {
        //_logger = _logger ?? throw new ArgumentNullException(nameof(_logger));
        _iwebhostenvironment = _webHostEnvironment ?? throw new ArgumentNullException(nameof(_webHostEnvironment));
        _qrCodeService = qrCodeService ?? throw new ArgumentNullException(nameof(qrCodeService));
        _barCodeService = barCodeService ?? throw new ArgumentNullException(nameof(barCodeService));
    }

    // POST: api/CreateUser/signup
    [HttpPost]
    [Route("CreateQRCode")]
    [ProducesDefaultResponseType]
    public async Task<IActionResult> CreateQRCode([FromBody] CodeModel generateQRCode)
    {
        try
        {
            string imageUrl = _qrCodeService.GenerateQRCode(generateQRCode.Input, _iwebhostenvironment.WebRootPath);
            return Ok(new { QrCodeUrl = imageUrl });
        }
        catch (Exception ex)
        {
            //_logger.LogError(ex, "Error generating QR code");
            return BadRequest(new { ErrorMessage = ex.Message });
        }
    }

    [HttpPost("Barcode")]
    [ProducesDefaultResponseType]

    public async Task<IActionResult> CreateBarcode([FromBody] CodeModel generateBarCode)
    {
        try
        {
            string imageUrl = _barCodeService.GenerateBarCode(generateBarCode.Input, _iwebhostenvironment.WebRootPath);
            return Ok(new { BarcodeUrl = imageUrl });
        }
        catch (Exception ex)
        {
            return BadRequest("Failed to generate barcode.");
        }
    }
}