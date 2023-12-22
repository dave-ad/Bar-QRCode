using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using QRcode.Models;

namespace QRCode_API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class QRCodeAPIController : ControllerBase
{
    private readonly QRCodeService.QRCodeService _qrCodeService;

    public QRCodeAPIController(QRCodeService.QRCodeService qrCodeService)
    {
        _qrCodeService = qrCodeService;
    }

    [HttpPost("GenerateQRCode")]
    public IActionResult GenerateQRCode([FromBody] GenerateQRCodeModel generateQRCode)
    {
        try
        {
            string imageUrl = _qrCodeService.GenerateQRCode(generateQRCode.QRInput, this.Request.Host.Value);
            return Ok(new { QrCodeUrl = imageUrl });
        }
        catch (Exception ex)
        {
            return BadRequest(new { ErrorMessage = ex.Message });
        }
    }

    //[HttpPost("QRCode")]
    //public IActionResult GenQRCode([FromBody] GenerateQRCodeModel generateQRCode)
    //{
    //    try
    //    {
    //        using IronBarCode;

    //        // Simplest example of creating a QR Code with no settings:
    //        GeneratedBarcode myQRCode = QRCodeWriter.CreateQrCode("https://ironsoftware.com/");

    //        // Advanced Example to set all parameters:

    //        // The value of the QR code as a string. Also suitable for URLS.
    //        string value = "https://ironsoftware.com/";

    //        // The error correction level of the QR code.
    //        var correction = QRCodeWriter.QrErrorCorrectionLevel.Highest;

    //        // The width and height of the QR code in pixels.
    //        int size = 500;

    //        // QR Version. Please read https://www.qrcode.com/en/about/version.html
    //        int qrVersion = 0;

    //        GeneratedBarcode myQRCodeComplex = QRCodeWriter.CreateQrCode(value, size, correction, qrVersion);
    //    }
    //    catch (Exception ex)
    //    {
    //        return BadRequest(new { ErrorMessage = ex.Message });
    //    }
    //}
}
