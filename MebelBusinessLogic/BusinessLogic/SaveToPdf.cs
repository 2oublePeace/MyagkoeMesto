﻿using MebelBusinessLogic.HelperModels;
using MigraDoc.DocumentObjectModel;
using MigraDoc.DocumentObjectModel.Tables;
using MigraDoc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;

namespace MebelBusinessLogic.BusinessLogic
{
	class SaveToPdf
	{
		public static void CreateDoc(PdfProviderInfo info)
		{
			Document document = new Document();
			DefineStyles(document);
			Section section = document.AddSection();
			Paragraph paragraph = section.AddParagraph(info.Title);
			paragraph.Format.SpaceAfter = "1cm";
			paragraph.Format.Alignment = ParagraphAlignment.Center;
			paragraph.Style = "NormalTitle";
			paragraph = section.AddParagraph($"с {info.DateFrom.ToShortDateString()} по { info.DateTo.ToShortDateString()}");
			paragraph.Format.SpaceAfter = "1cm";
			paragraph.Format.Alignment = ParagraphAlignment.Center;
			paragraph.Style = "Normal";
			var table = document.LastSection.AddTable();
			List<string> columns = new List<string> { "3cm", "6cm", "3cm", "3cm" };
			foreach (var elem in columns)
			{
				table.AddColumn(elem);
			}
			CreateRow(new PdfRowParameters
			{
				Table = table,
				Texts = new List<string> { "Поставка", "Цена поставки", "Гарнитур", "Дата" },
				Style = "NormalTitle",
				ParagraphAlignment = ParagraphAlignment.Center
			});
			foreach (var supply in info.Supplys)
			{
				CreateRow(new PdfRowParameters
				{
					Table = table,
					Texts = new List<string> { supply.SupplyName.ToString(), supply.SupplyPrice.ToString(), supply.GarnitureName, supply.Date.ToShortDateString()},
					Style = "Normal",
					ParagraphAlignment = ParagraphAlignment.Left
				});
			}
			PdfDocumentRenderer renderer = new PdfDocumentRenderer(true, PdfSharp.Pdf.PdfFontEmbedding.Always)
			{
				Document = document
			};
			renderer.RenderDocument();
			renderer.PdfDocument.Save(info.FileName);
		}

		public static void CreateDoc(PdfCustomerInfo info)
		{
			Document document = new Document();
			DefineStyles(document);
			Section section = document.AddSection();
			Paragraph paragraph = section.AddParagraph(info.Title);
			paragraph.Format.SpaceAfter = "1cm";
			paragraph.Format.Alignment = ParagraphAlignment.Center;
			paragraph.Style = "NormalTitle";
			paragraph = section.AddParagraph($"с {info.DateFrom.ToShortDateString()} по { info.DateTo.ToShortDateString()}");
			paragraph.Format.SpaceAfter = "1cm";
			paragraph.Format.Alignment = ParagraphAlignment.Center;
			paragraph.Style = "Normal";
			var table = document.LastSection.AddTable();
			List<string> columns = new List<string> { "3cm", "6cm", "3cm", "3cm" };
			foreach (var elem in columns)
			{
				table.AddColumn(elem);
			}
			CreateRow(new PdfRowParameters
			{
				Table = table,
				Texts = new List<string> { "Поставка", "Отгрузка", "Дата поставки", "Дата отгрузки" },
				Style = "NormalTitle",
				ParagraphAlignment = ParagraphAlignment.Center
			});
			foreach (var shipment in info.Shipments)
			{
				CreateRow(new PdfRowParameters
				{
					Table = table,
					Texts = new List<string> { shipment.SupplyName, shipment.ShipmentName, shipment.SupplyDate.ToString(), shipment.ShipmentDate.ToString() },
					Style = "Normal",
					ParagraphAlignment = ParagraphAlignment.Left
				});
			}
			PdfDocumentRenderer renderer = new PdfDocumentRenderer(true, PdfSharp.Pdf.PdfFontEmbedding.Always)
			{
				Document = document
			};
			renderer.RenderDocument();
			renderer.PdfDocument.Save(info.FileName);
		}

		/// <summary>
		/// Создание стилей для документа
		/// </summary>
		/// <param name="document"></param>
		private static void DefineStyles(Document document)
		{
			Style style = document.Styles["Normal"];
			style.Font.Name = "Times New Roman";
			style.Font.Size = 14;
			style = document.Styles.AddStyle("NormalTitle", "Normal");
			style.Font.Bold = true;
		}
		/// <summary>
		/// Создание и заполнение строки
		/// </summary>
		/// <param name="rowParameters"></param>
		private static void CreateRow(PdfRowParameters rowParameters)
		{
			Row row = rowParameters.Table.AddRow();
			for (int i = 0; i < rowParameters.Texts.Count; ++i)
			{
				FillCell(new PdfCellParameters
				{
					Cell = row.Cells[i],
					Text = rowParameters.Texts[i],
					Style = rowParameters.Style,
					BorderWidth = 0.5,
					ParagraphAlignment = rowParameters.ParagraphAlignment
				});
			}
		}
		/// <summary>
		/// Заполнение ячейки
		/// </summary>
		/// <param name="cellParameters"></param>
		private static void FillCell(PdfCellParameters cellParameters)
		{
			cellParameters.Cell.AddParagraph(cellParameters.Text);
			if (!string.IsNullOrEmpty(cellParameters.Style))
			{
				cellParameters.Cell.Style = cellParameters.Style;
			}
			cellParameters.Cell.Borders.Left.Width = cellParameters.BorderWidth;
			cellParameters.Cell.Borders.Right.Width = cellParameters.BorderWidth;
			cellParameters.Cell.Borders.Top.Width = cellParameters.BorderWidth;
			cellParameters.Cell.Borders.Bottom.Width = cellParameters.BorderWidth;
			cellParameters.Cell.Format.Alignment = cellParameters.ParagraphAlignment;
			cellParameters.Cell.VerticalAlignment = VerticalAlignment.Center;
		}
	}
}
