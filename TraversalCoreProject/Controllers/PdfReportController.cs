using iTextSharp.text;
using iTextSharp.text.pdf;
using Microsoft.AspNetCore.Mvc;

namespace TraversalCoreProject.Controllers
{
    public class PdfReportController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult StaticPdfReport()
        {
            string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/pdfreport/" + "dosya1.pdf");
            var stream = new FileStream(path, FileMode.Create);

            Document document = new Document(PageSize.A4); //döküman oluşturma
            PdfWriter.GetInstance(document, stream);

            document.Open();
            Paragraph paragraph = new Paragraph("Travelsal Rezervasyon Pdf Raporu"); //döküman içeriği

            document.Add(paragraph);
            document.Close();
            return File("/pdfreport/dosya1.pdf", "application/pdf", "dosya1.pdf");
        }
        public IActionResult StaticCustomerReport()
        {
            string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/pdfreport/" + "dosya4.pdf");
            var stream = new FileStream(path, FileMode.Create);

            Document document = new Document(PageSize.A4); //döküman oluşturma
            PdfWriter.GetInstance(document, stream);

            document.Open();

            PdfPTable pdfPTable = new PdfPTable(3);

            pdfPTable.AddCell("Misafir Adı");
            pdfPTable.AddCell("Misafir Soyadı");
            pdfPTable.AddCell("Misafir TC");

            pdfPTable.AddCell("Eylül");
            pdfPTable.AddCell("Çınar");
            pdfPTable.AddCell("11111111111");

            pdfPTable.AddCell("Deniz");
            pdfPTable.AddCell("Çınar");
            pdfPTable.AddCell("22222222222");

            document.Add(pdfPTable);
            document.Close();
            return File("/pdfreport/dosya4.pdf", "application/pdf", "dosya4.pdf");
        }
    }
}
