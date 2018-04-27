using System;
using System.IO;
using Zen.Barcode;

namespace Cypher
{
	public static class BarCodeGenerator
	{
		/// <summary>
		/// Генерирует BarCode в формате Code128
		/// </summary>
		/// <param name="id">ID договора</param>
		/// <param name="contractNumber">Номер договора</param>
		/// <returns>BarCode в формате Base64</returns>
		public static string GetBarcode(string id, string contractNumber)
		{
			const BarcodeSymbology type = BarcodeSymbology.Code128;
			var drawObject = BarcodeDrawFactory.GetSymbology(type);
			var metrics = drawObject.GetDefaultMetrics(60);
			metrics.Scale = 2;

			var endodedIdAndContractNumber = Encoder.BuildCode(id, contractNumber);
			var barcodeImage = drawObject.Draw(endodedIdAndContractNumber, metrics);

			using (var memoryStream = new MemoryStream())
			{
				barcodeImage.Save(memoryStream, System.Drawing.Imaging.ImageFormat.Png);
				var imageBytes = memoryStream.ToArray();

				return Convert.ToBase64String(imageBytes);
			}
		}
	}
}