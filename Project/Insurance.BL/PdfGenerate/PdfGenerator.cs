using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PdfSharp.Drawing;
using PdfSharp.Pdf;
using PdfSharp.Pdf.IO;
using System.Diagnostics;
using PdfSharp.Drawing.Layout;
using MigraDoc;
using MigraDoc.DocumentObjectModel;
using MigraDoc.Rendering;
using MigraDoc.DocumentObjectModel.Tables;
using Insurance.BL.Models;

namespace Insurance.BL
{
    /// <summary>
    /// Класс представляет методы генерации полиса в pdf формате.
    /// </summary>
    public class PdfGenerator
    {
        /// <summary>
        /// Метод генерирует полис.
        /// </summary>
        /// <param name="policy">Экземпляр Insurance.BL.Models.Policy</param>
        /// <param name="user">Экземпляр Insurance.BL.Models.User</param>
        /// <returns>Имя сгенерированного полиса.</returns>
        public string GeneratePolicy(Policy policy, User user)
        {
            var p = new PdfGenerator();
            Document document = new Document();
            Section section = document.AddSection();
            p.Styles(document);

            //ЗАГОЛОВОК
            Paragraph paragraph = section.AddParagraph();
            paragraph.Format.LeftIndent = 120;
            paragraph.AddFormattedText("СТРАХОВОЙ ПОЛИС", "Title");
            paragraph.AddFormattedText("\nКОМПЛЕКСНОГО АВТОМОБИЛЬНОГО" +
                "\nСТРАХОВАНИЯ, КРОМЕ ОТВЕТСТВЕННОСТИ", "Normal");

            //ТАБЛИЦА С ДАТОЙ СРОКА ДЕЙСТВИЯ ПОЛИСА
            section.AddParagraph();
            section.AddParagraph();
            section.AddParagraph();
            Table tablePolicyDate = section.AddTable();
            tablePolicyDate.AddColumn(296);
            tablePolicyDate.Borders.Width = 1.5;
            tablePolicyDate.TopPadding = 4;
            tablePolicyDate.BottomPadding = 4;
            Row row = tablePolicyDate.AddRow();
            tablePolicyDate.Rows.LeftIndent = 180;
            var text = p.GetFormattedPolicyDateText(policy.PolicyDate);
            row.Style = "Text";
            row.Cells[0].AddParagraph(text);

            //ТАБЛИЦА С ИМЕНЕМ КЛИЕНТА
            section.AddParagraph();
            section.AddParagraph();
            section.AddParagraph();
            Table dateInsuranceCase = section.AddTable();
            dateInsuranceCase.AddColumn(480);
            dateInsuranceCase.Borders.Width = 1.5;
            dateInsuranceCase.TopPadding = 4;
            dateInsuranceCase.BottomPadding = 4;
            row = dateInsuranceCase.AddRow();
            row.Style = "Text";
            row.VerticalAlignment = VerticalAlignment.Center;
            row.Cells[0].AddParagraph("Страхователь (фамилия имя отчество)");
            row = dateInsuranceCase.AddRow();
            row.Style = "Text";
            row.Cells[0].AddParagraph(user.Name);

            //ТАБЛИЦА С ПАРАМЕТРАМИ АВТОМОБИЛЯ.
            section.AddParagraph();
            section.AddParagraph();
            section.AddParagraph();
            section.AddParagraph("Характеристики транспортного средства:");
            Table carData = section.AddTable();

            //Строка с наименованием.
            carData.AddColumn(120);
            carData.AddColumn(120);
            carData.AddColumn(120);
            carData.AddColumn(120);
            row = carData.AddRow();
            carData.Borders.Width = 1.5;
            carData.TopPadding = 4;
            carData.BottomPadding = 4;
            row.Style = "Text";
            row.Cells[0].AddParagraph(
                "Номер" +
                "\nавтомобиля");
            row.Cells[1].AddParagraph(
                "Модель" +
                "\nавтомобиля");
            row.Cells[2].AddParagraph(
                "Год производства" +
                "\nавтомобиля");
            row.Cells[3].AddParagraph(
                "Мощность двигателя" +
                "\nавтомобиля");

            //Строка со значениями.
            row = carData.AddRow();
            row.VerticalAlignment = VerticalAlignment.Center;
            row.Cells[0].AddParagraph(policy.Car.CarNumber);
            row.Cells[1].AddParagraph(policy.Car.Model);
            row.Cells[2].AddParagraph(policy.Car.ManufacturedYear.ToString());
            row.Cells[3].AddParagraph(string.Format("{0} л.с.", policy.Car.EnginePower));

            //СТРАХОВАЯ ПРЕМИЯ
            section.AddParagraph();
            section.AddParagraph();
            section.AddParagraph();
            section.AddParagraph(
                "Автомобиль застрахован по программе все включено (угон\\хищение, полная потеря, повреждение)." +
                "\nСумма страховой премии:");
            Table cost = section.AddTable();
            cost.AddColumn(200);
            row = cost.AddRow();
            cost.Borders.Width = 1.5;
            cost.TopPadding = 4;
            cost.BottomPadding = 4;
            row.Style = "Title";
            row.VerticalAlignment = VerticalAlignment.Center;
            row.Cells[0].AddParagraph(string.Format("{0:C}", policy.Cost));

            //НОМЕР ПОЛИСА
            section.AddParagraph();
            section.AddParagraph();
            section.AddParagraph();
            section.AddParagraph();
            section.AddParagraph();
            section.AddParagraph();
            section.AddParagraph();
            section.AddParagraph();
            section.AddParagraph();
            section.AddParagraph();
            paragraph = section.AddParagraph();
            paragraph.Format.Alignment = ParagraphAlignment.Center;
            paragraph.AddFormattedText(string.Format("Полис № {0}", policy.PolicyId));

            //Сохранение и рендер полиса
            PdfDocumentRenderer pdfRenderer = new PdfDocumentRenderer(true, PdfFontEmbedding.Always);
            pdfRenderer.Document = document;
            pdfRenderer.RenderDocument();
            var fileName = policy.PolicyId.ToString() + ".pdf";
            pdfRenderer.PdfDocument.Save(fileName);
            //Process.Start(fileName);

            return fileName;
        }

        /// <summary>
        /// Метод возвращает форматированный текст с началом и окончанием действия полиса.
        /// </summary>
        /// <param name="policyDate">Дата начала действия полиса.</param>
        /// <returns>Форматированный текст.</returns>
        private string GetFormattedPolicyDateText(DateTime policyDate)
        {
            var day = new TimeSpan(1, 0, 0, 0);
            //Дата окончания действия полиса
            var policyEndDate = (policyDate - day).AddYears(1);

            var formattedStartDate = string.Format("{0:dd.MM.yyyy}г.", policyDate);
            var formattedEndDate = string.Format("{0:dd.MM.yyyy}г.", policyEndDate);

            var text = string.Format(
                "Срок страхования с 00ч. 00мин. " + formattedStartDate +
                "\n\t\t\tпо 24ч. 00мин. " + formattedEndDate);

            return text;
        }

        private static void DefineTableOfContents(Document document)
        {
            Section section = document.LastSection;
            section.AddPageBreak();
            Paragraph paragraph = section.AddParagraph("Table of Contents");
            paragraph.Format.Font.Size = 14;
            paragraph.Format.Font.Bold = true;
            paragraph.Format.SpaceAfter = 24;
            paragraph.Format.OutlineLevel = OutlineLevel.Level1;

            paragraph = section.AddParagraph();
            paragraph.Style = "TOC";
            Hyperlink hyperlink = paragraph.AddHyperlink("Paragraphs");
            hyperlink.AddText("Paragraphs\t");
            hyperlink.AddPageRefField("Paragraphs");

            paragraph = section.AddParagraph();
            paragraph.Style = "TOC";
            hyperlink = paragraph.AddHyperlink("Tables");
            hyperlink.AddText("Tables\t");
            hyperlink.AddPageRefField("Tables");

            paragraph = section.AddParagraph();
            paragraph.Style = "TOC";
            hyperlink = paragraph.AddHyperlink("Charts");
            hyperlink.AddText("Charts\t");
            hyperlink.AddPageRefField("Charts");

        }

        /// <summary>
        /// Метод определяет стили текста.
        /// </summary>
        /// <param name="document">Экземпляр класса Document к которому применяются стили.</param>
        private void Styles(Document document)
        {
            //Шрифт заголовка
            Style style = document.Styles["Normal"];
            style.Font.Name = "Times New Roman";
            style.Font.Size = 14;
            style.Font.Bold = false;

            //Шрифт подзаголовка
            style = document.AddStyle("Title", "Normal");
            style.Font.Name = "Times New Roman";
            style.Font.Size = 20;
            style.Font.Bold = true;

            //Шрифт текста
            style = document.AddStyle("Text", "Normal");
            style.Font.Name = "Times New Roman";
            style.Font.Size = 14;
            style.Font.Bold = false;
        }







        private void DefineStyles(Document document)
        {
            // Get the predefined style Normal.
            Style style = document.Styles["Normal"];
            // Because all styles are derived from Normal, the next line changes the 
            // font of the whole document. Or, more exactly, it changes the font of
            // all styles and paragraphs that do not redefine the font.
            style.Font.Name = "Times New Roman";

            // Heading1 to Heading9 are predefined styles with an outline level. An outline level
            // other than OutlineLevel.BodyText automatically creates the outline (or bookmarks) 
            // in PDF.

            style = document.Styles["Heading1"];
            style.Font.Name = "Tahoma";
            style.Font.Size = 14;
            style.Font.Bold = true;
            style.Font.Color = Colors.DarkBlue;
            style.ParagraphFormat.PageBreakBefore = true;
            style.ParagraphFormat.SpaceAfter = 6;

            style = document.Styles["Heading2"];
            style.Font.Size = 12;
            style.Font.Bold = true;
            style.ParagraphFormat.PageBreakBefore = false;
            style.ParagraphFormat.SpaceBefore = 6;
            style.ParagraphFormat.SpaceAfter = 6;

            style = document.Styles["Heading3"];
            style.Font.Size = 10;
            style.Font.Bold = true;
            style.Font.Italic = true;
            style.ParagraphFormat.SpaceBefore = 6;
            style.ParagraphFormat.SpaceAfter = 3;

            style = document.Styles[StyleNames.Header];
            style.ParagraphFormat.AddTabStop("16cm", TabAlignment.Right);

            style = document.Styles[StyleNames.Footer];
            style.ParagraphFormat.AddTabStop("8cm", TabAlignment.Center);

            // Create a new style called TextBox based on style Normal
            style = document.Styles.AddStyle("TextBox", "Normal");
            style.ParagraphFormat.Alignment = ParagraphAlignment.Justify;
            style.ParagraphFormat.Borders.Width = 2.5;
            style.ParagraphFormat.Borders.Distance = "3pt";
            style.ParagraphFormat.Shading.Color = Colors.SkyBlue;

            // Create a new style called TOC based on style Normal
            style = document.Styles.AddStyle("TOC", "Normal");
            style.ParagraphFormat.AddTabStop("16cm", TabAlignment.Right, TabLeader.Dots);
            style.ParagraphFormat.Font.Color = Colors.Blue;
        }
    }
}