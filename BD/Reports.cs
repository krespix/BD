using System;
using System.Collections.Generic;

using ClosedXML.Excel;

using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;

namespace BD
{
    public class Reports
    {
        public static void WriteExcel(string file, List<List<string>> data,string sheetName = "Query report")
        {
            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add(sheetName);
                for (int i = 0; i < data.Count; i++)
                {
                    for (int j = 0; j < data[i].Count; j++)
                    {
                        worksheet.Row(i + 1).Cell(j + 1).Value = data[i][j];
                    }
                }
                workbook.SaveAs(file);
            }
        }

        public static void WriteWord(string file, List<List<string>> data)
        {
            try
            {
                Reports.CreateWordprocessingDocument(file);
            }
            catch
            {
                Console.WriteLine("ALREADY EXISTS");
            }
            Reports.CreateTable(file, data);
        }

        private static void CreateTable(string fileName, List<List<string>> data)
        {
            using (WordprocessingDocument doc
                = WordprocessingDocument.Open(fileName, true))
            {
                DocumentFormat.OpenXml.Wordprocessing.Table table = new DocumentFormat.OpenXml.Wordprocessing.Table();

                TableProperties tblProp = new TableProperties(
                    new TableBorders(
                        new TopBorder()
                        {
                            Val =
                            new EnumValue<BorderValues>(BorderValues.Single),
                            Size = 3
                        },
                        new BottomBorder()
                        {
                            Val =
                            new EnumValue<BorderValues>(BorderValues.Single),
                            Size = 3
                        },
                        new LeftBorder()
                        {
                            Val =
                            new EnumValue<BorderValues>(BorderValues.Single),
                            Size = 3
                        },
                        new RightBorder()
                        {
                            Val =
                            new EnumValue<BorderValues>(BorderValues.Single),
                            Size = 3
                        },
                        new InsideHorizontalBorder()
                        {
                            Val =
                            new EnumValue<BorderValues>(BorderValues.Single),
                            Size = 3
                        },
                        new InsideVerticalBorder()
                        {
                            Val =
                            new EnumValue<BorderValues>(BorderValues.Single),
                            Size = 3
                        }
                    )
                );

                table.AppendChild<TableProperties>(tblProp);

                for (int i = 0; i < data.Count; i++)
                {
                    TableRow tr = new TableRow();

                    for (int j = 0; j < data[i].Count; j++)
                    {
                        TableCell tc1 = new TableCell();
                        tc1.Append(new TableCellProperties(
                            new TableCellWidth() { Type = TableWidthUnitValues.Dxa, Width = "1400" }));
                        tc1.Append(new Paragraph(new Run(new Text(data[i][j]))));
                        tr.Append(tc1);
                    }
                    table.Append(tr);
                }

                doc.MainDocumentPart.Document.Body.Append(table);
            }
        }

        private static void CreateWordprocessingDocument(string filepath)
        {
            using (WordprocessingDocument wordDocument =
                WordprocessingDocument.Create(filepath, WordprocessingDocumentType.Document))
            {
                MainDocumentPart mainPart = wordDocument.AddMainDocumentPart();

                mainPart.Document = new Document();
                Body body = mainPart.Document.AppendChild(new Body());
            }
        }
    }
}