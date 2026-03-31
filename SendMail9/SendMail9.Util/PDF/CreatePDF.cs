using SendMail9.Domain;
using SendMail9.Util.PDF.Interfaces;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using QRCoder;

namespace SendMail9.Util.PDF;

public class CreatePDF : ICreatePDF
{
    public byte[] CreatePDFDocument(List<Product> products)
    {
        // Set license for QuestPDF (Community license is free for open source)
        QuestPDF.Settings.License = LicenseType.Community;
        
        // Generate QR code
        QRCodeGenerator qrGenerator = new QRCodeGenerator();
        QRCodeData qrCodeData = qrGenerator.CreateQrCode("https://vives.be", QRCodeGenerator.ECCLevel.Q);
        PngByteQRCode qrCode = new PngByteQRCode(qrCodeData);
        byte[] qrCodeImage = qrCode.GetGraphic(20);
        
        var document = Document.Create(container =>
        {
            container.Page(page =>
            {
                page.Size(PageSizes.A4);
                page.Margin(2, Unit.Centimetre);
                page.PageColor(Colors.White);
                page.DefaultTextStyle(x => x.FontSize(11));

                page.Header()
                    .Text("Beerstore - Orderbevestiging")
                    .SemiBold().FontSize(20).FontColor(Colors.Blue.Medium);

                page.Content()
                    .PaddingVertical(1, Unit.Centimetre)
                    .Column(x =>
                    {
                        x.Spacing(20);

                        x.Item().Text($"Order Datum: {DateTime.Now:dd/MM/yyyy HH:mm}");
                        
                        x.Item().Text("Bestelde Producten:").SemiBold().FontSize(14);

                        // Products table
                        x.Item().Table(table =>
                        {
                            // Define columns
                            table.ColumnsDefinition(columns =>
                            {
                                columns.RelativeColumn(3); // Product name
                                columns.RelativeColumn(1); // Quantity
                                columns.RelativeColumn(2); // Price
                                columns.RelativeColumn(2); // Total
                            });

                            // Header
                            table.Header(header =>
                            {
                                header.Cell().Element(CellStyle).Text("Product").SemiBold();
                                header.Cell().Element(CellStyle).Text("Aantal").SemiBold();
                                header.Cell().Element(CellStyle).Text("Prijs").SemiBold();
                                header.Cell().Element(CellStyle).Text("Totaal").SemiBold();
                            });

                            // Products rows
                            decimal grandTotal = 0;
                            foreach (var product in products)
                            {
                                var total = product.Quantity * product.Price;
                                grandTotal += total;

                                table.Cell().Element(CellStyle).Text(product.Name);
                                table.Cell().Element(CellStyle).AlignRight().Text(product.Quantity.ToString());
                                table.Cell().Element(CellStyle).AlignRight().Text($"€{product.Price:F2}");
                                table.Cell().Element(CellStyle).AlignRight().Text($"€{total:F2}");
                            }

                            // Total row
                            table.Cell().ColumnSpan(3).Element(CellStyle).AlignRight().Text("Totaalbedrag:").SemiBold();
                            table.Cell().Element(CellStyle).AlignRight().Text($"€{grandTotal:F2}").SemiBold();
                        });
                        
                        x.Item().PaddingTop(20).Text("Bedankt voor uw bestelling!");
                        x.Item().Text("Met vriendelijke groeten,").Italic();
                        x.Item().Text("Het Beerstore Team").Italic();
                    });

                page.Footer()
                    .Row(row =>
                    {
                        row.RelativeItem()
                            .AlignLeft()
                            .Column(column =>
                            {
                                column.Item()
                                    .Width(80)
                                    .Height(80)
                                    .Image(qrCodeImage);
                                
                                column.Item()
                                    .PaddingTop(5)
                                    .Text("Scan voor meer info")
                                    .FontSize(8)
                                    .Italic();
                            });
                        
                        row.RelativeItem()
                            .AlignCenter()
                            .AlignMiddle()
                            .Text(x =>
                            {
                                x.Span("Pagina ");
                                x.CurrentPageNumber();
                                x.Span(" van ");
                                x.TotalPages();
                            });
                        
                        row.RelativeItem(); // Empty space for symmetry
                    });
            });
        });

        return document.GeneratePdf();
    }

    private static IContainer CellStyle(IContainer container)
    {
        return container.BorderBottom(1).BorderColor(Colors.Grey.Lighten2).PaddingVertical(5);
    }
}