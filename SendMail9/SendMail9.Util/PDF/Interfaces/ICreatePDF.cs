using SendMail9.Domain;

namespace SendMail9.Util.PDF.Interfaces;

public interface ICreatePDF
{
    byte[] CreatePDFDocument(List<Product> products);
}