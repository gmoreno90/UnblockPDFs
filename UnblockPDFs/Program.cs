using UglyToad.PdfPig;
using UglyToad.PdfPig.Writer;

Console.WriteLine("Path to PDF File:");
string filePath = Console.ReadLine();
Console.WriteLine("Password of PDF File:");
string filePassword = Console.ReadLine();

try
{
    using (PdfDocument document = PdfDocument.Open(filePath, new ParsingOptions { Password = filePassword }))
    {
        PdfDocumentBuilder builder = new PdfDocumentBuilder();
        var pages = document.GetPages();
        var pagecounts = pages.Count();
        for (int i = 1; i <= pagecounts; i++)
        {
            builder.AddPage(document, i);
        }
        File.WriteAllBytes(filePath.Replace(".pdf", "_unblock.pdf"), builder.Build());
        Console.WriteLine("PDF Saved: " + filePath.Replace(".pdf", "_unblock.pdf"));
        Console.ReadLine();
    }
}
catch (Exception ex)
{
    Console.WriteLine("ERROR: " + ex.Message + " " + ex.StackTrace);
    Console.ReadLine();
}


