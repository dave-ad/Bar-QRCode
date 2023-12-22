using IronBarCode;
using Color = System.Drawing.Color;


namespace QRCodeService;

public class QRCodeService
{
    public string GenerateQRCode(string input, string webRootPath)
    {
        try
        {
            GeneratedBarcode barcode = QRCodeWriter.CreateQrCode(input, 200);
            barcode.AddBarcodeValueTextBelowBarcode();
            barcode.SetMargins(10);
            barcode.ChangeBarCodeColor(Color.Black);
            string path = Path.Combine(webRootPath, "GeneratedQRCode");

            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            string filePath = Path.Combine(path, "qrcode.png");
            barcode.SaveAsPng(filePath);

            string fileName = Path.GetFileName(filePath);
            string imageUrl = $"GeneratedQRCode/{fileName}";

            return imageUrl;
        }
        catch (Exception ex)
        {
            throw new Exception("Failed to generate QR code.", ex);
        }
    }
}
