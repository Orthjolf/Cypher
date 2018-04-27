using System;

namespace Cypher
{
	internal class Program
	{
		public static void Main(string[] args)
		{
			const string contractNumber = "Д-НС-09.11-15317/Т-НС-22.03-17316";
			const string id = "12345";

			var encrypted = Encoder.BuildCode(id, contractNumber);
			var decrypted = Decoder.Reconstitute(encrypted);

			if (decrypted.Key == id && decrypted.Value == contractNumber)
			{
				Console.WriteLine("It Works");
			}

			var base64BarCode = BarCodeGenerator.GetBarcode(id, contractNumber);
		}
	}
}