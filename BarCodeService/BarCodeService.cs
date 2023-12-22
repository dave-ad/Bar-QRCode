using IronBarCode;


namespace BarCodeService;

public class BarCodeService
{
    public string GenerateBarCode(string input, string webRootPath)
    {
        try
        {
            GeneratedBarcode barcode = BarcodeWriter.CreateBarcode(input, BarcodeEncoding.Code128);

            //barcode.AddBarcodeValueTextBelowBarcode();
            string fileName = $"{Guid.NewGuid()}.png";
            string folderPath = Path.Combine(webRootPath, "GeneratedBarcodes");

            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }

            string filePath = Path.Combine(folderPath, fileName);
            barcode.SaveAsPng(filePath);

            return Path.Combine("GeneratedBarcodes", fileName);
        }
        catch (Exception ex)
        {
            throw new Exception("Failed to generate barcode.", ex);
        }
    }
}
