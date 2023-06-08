using System.IO;
using System.Text;
using x6c95d9cf46ff5f25;
using xb92b7270f78a4e8d;

namespace x5af3f327d745698a;

internal class x432b11171adc04ec : x8761581bef471ee5
{
	private readonly string x9cec11473cd27cef;

	string x8761581bef471ee5.x32513d67c4b572d4 => "\u0003OCXNAME";

	internal string x7418697d519d9ddc => x9cec11473cd27cef;

	internal x432b11171adc04ec(string ocxName)
	{
		x9cec11473cd27cef = ocxName;
	}

	internal x432b11171adc04ec(xe7be411416cfcd54 storage)
	{
		MemoryStream memoryStream = storage.x3e19bf48aeaa5779("\u0003OCXNAME");
		if (memoryStream == null)
		{
			return;
		}
		BinaryReader binaryReader = new BinaryReader(memoryStream, Encoding.Unicode);
		StringBuilder stringBuilder = new StringBuilder();
		while (x0d299f323d241756.xd7d2f6dd32a72a3b(binaryReader, 2))
		{
			char c = binaryReader.ReadChar();
			if (c == '\0')
			{
				break;
			}
			stringBuilder.Append(c);
		}
		x9cec11473cd27cef = stringBuilder.ToString();
	}

	private void x66a781f9bc1549ba(BinaryWriter xbdfb620b7167944b)
	{
		if (x0d299f323d241756.x5959bccb67bbf051(x9cec11473cd27cef))
		{
			for (int i = 0; i < x9cec11473cd27cef.Length; i++)
			{
				char c = x9cec11473cd27cef[i];
				xbdfb620b7167944b.Write((byte)c);
				xbdfb620b7167944b.Write((byte)0);
			}
		}
		xbdfb620b7167944b.Write(0);
	}

	void x8761581bef471ee5.x6210059f049f0d48(BinaryWriter xbdfb620b7167944b)
	{
		//ILSpy generated this explicit interface implementation from .override directive in x66a781f9bc1549ba
		this.x66a781f9bc1549ba(xbdfb620b7167944b);
	}
}
