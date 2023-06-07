using POSBill.Domain.Models;
using QuestPDF.Fluent;
using QuestPDF.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantRetailPOSBill.WPF.Models
{
    public class InvoiceDocument : IDocument
    {
        public Cart Model { get; }

        public InvoiceDocument(Cart model)
        {
            Model = model;
        }
        public DocumentMetadata GetMetadata() => DocumentMetadata.Default;
        public DocumentSettings GetSettings() => DocumentSettings.Default;

        public void Compose(IDocumentContainer container)
        {
            container
             .Page(page =>
             {
                 page.Margin(50);

                 page.Header().Element(ComposeHeader);
                 page.Content().Element(ComposeContent);


                 page.Footer().AlignCenter().Text(x =>
                 {
                     x.CurrentPageNumber();
                     x.Span(" / ");
                     x.TotalPages();
                 });
             });
        }

        void ComposeHeader(IContainer container)
        {
            var titleStyle = TextStyle.Default.FontSize(20).SemiBold();

            container.Row(row =>
            {
                row.RelativeItem().Column(column =>
                {
                    column.Item().Text($"Invoice #{Model.InvoiceNumber}").Style(titleStyle);

                    column.Item().Text(text =>
                    {
                        text.Span("Issue date: ").SemiBold();
                        text.Span($"{Model.strDate:d}");
                    });

                    column.Item().Text(text =>
                    {
                        text.Span("Due date: ").SemiBold();
                        text.Span($"{Model.strDate:d}");
                    });
                });

                row.ConstantItem(100).Height(50).Placeholder();
            });
        }

        void ComposeContent(IContainer container)
        {
          //  container
                //.PaddingVertical(40)
                //.Height(250)
                ////.Background(Colors.Grey.Lighten3)
                //.AlignCenter()
                //.AlignMiddle()
                //.Text("Content").FontSize(16);
                container.PaddingVertical(40).Column(column =>
                {
                    column.Spacing(5);

                    column.Item().Element(ComposeTable);

                    if (!string.IsNullOrWhiteSpace(Model.strCartPaymentMethod))
                        column.Item().PaddingTop(25).Element(ComposeComments);
                });
        }
        void ComposeTable(IContainer container)
        {
           
            container.Table(table =>
                {
                    // step 1
                    table.ColumnsDefinition(columns =>
                    {
                        columns.ConstantColumn(25);
                        columns.RelativeColumn(3);
                        columns.RelativeColumn();
                        columns.RelativeColumn();
                        columns.RelativeColumn();
                    });

                    // step 2
                    table.Header(header =>
                    {
                       // header.Cell().Element(CellStyle).Text("#");
                        header.Cell().Element(CellStyle).Text("Product");
                        header.Cell().Element(CellStyle).AlignRight().Text("Unit price");
                        header.Cell().Element(CellStyle).AlignRight().Text("Quantity");
                        header.Cell().Element(CellStyle).AlignRight().Text("Total");

                        static IContainer CellStyle(IContainer container)
                        {
                            return container.DefaultTextStyle(x => x.SemiBold()).PaddingVertical(5).BorderBottom(1);
                        }
                    });

                    // step 3
                    foreach (PosBillDetails details in Model.posBillArray)
                    {
                       // table.Cell().Element(CellStyle).Text(Model.Items.IndexOf(item) + 1);
                        table.Cell().Element(CellStyle).Text(details.strPosItemName);
                        table.Cell().Element(CellStyle).AlignRight().Text($"{details.strPrice}$");
                        table.Cell().Element(CellStyle).AlignRight().Text(details.strPosQty);
                        table.Cell().Element(CellStyle).AlignRight().Text($"{details.strTotal}$");

                        static IContainer CellStyle(IContainer container)
                        {
                            return container.BorderBottom(1);
                        }
                    }
                });
        }
        void ComposeComments(IContainer container)
        {
            container.Background("").Padding(10).Column(column =>
            {
                column.Spacing(5);
                column.Item().Text("Comments").FontSize(14);
              //  column.Item().Text(Model.Comments);
            });
        }
    }
}

