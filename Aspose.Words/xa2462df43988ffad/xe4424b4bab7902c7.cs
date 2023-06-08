using Aspose.Words.Drawing;
using x55b2bd426d41d30c;
using x6c95d9cf46ff5f25;
using xbe73d5820f7f4ae3;

namespace xa2462df43988ffad;

internal class xe4424b4bab7902c7
{
	private readonly xdb0bf9f81de4b38c x9b287b671d592594;

	internal xe4424b4bab7902c7(xdb0bf9f81de4b38c writer)
	{
		x9b287b671d592594 = writer;
	}

	internal void x56c6b9360de4fb23(string x121383aa64985888, Shape x5770cdefd8931aa9)
	{
		if (x9b287b671d592594.x05ee8ce4d7312eb5 != x14bf6f47128e4438.x62896619d90ad964)
		{
			x2f696e6403c110df(x121383aa64985888, x5770cdefd8931aa9.ImageData);
		}
	}

	private void x2f696e6403c110df(string x121383aa64985888, ImageData xf1c258adc3c53c0e)
	{
		if (xf1c258adc3c53c0e.x169baa05e57bf312)
		{
			byte[] imageBytes = xf1c258adc3c53c0e.ImageBytes;
			string arg = xb9015fe823e7e228.xac88cb4f794761a9(xf1c258adc3c53c0e.xfe2ff3c162b47c70);
			x9b287b671d592594.xaa7785f730d8dd15++;
			string text = $"Pictures/image{x9b287b671d592594.xaa7785f730d8dd15}.{arg}";
			x0ca5e8b532953a51 x0ca5e8b532953a = new x0ca5e8b532953a51(text);
			x9b287b671d592594.x39c7aeeec1af9dd0.xd6abb2ab950b4d22.xd6b6ed77479ef68c(x0ca5e8b532953a);
			if (xf1c258adc3c53c0e.x169baa05e57bf312)
			{
				x0ca5e8b532953a.xb8a774e0111d0fbe.Write(imageBytes, 0, imageBytes.Length);
			}
			x9b287b671d592594.x862b4148836ee29c.Add(new x03305f81beb3a033(xb9015fe823e7e228.x0ad80fdc3fba643e(xf1c258adc3c53c0e.xfe2ff3c162b47c70), text, ""));
			xdf222feef3841fbc(x121383aa64985888, text);
		}
		else if (xf1c258adc3c53c0e.IsLink)
		{
			xdf222feef3841fbc("draw:image", xbb857c9fc36f5054.xdd08ed399f8774b0(xf1c258adc3c53c0e.SourceFullName, x9b287b671d592594.x2c8c6741422a1298.xb93d084d48e486dd, xf4959543150451ad: true));
		}
	}

	private void xdf222feef3841fbc(string x121383aa64985888, string x0404c2245e8d0997)
	{
		x9c77c7e782b62883 xe1410f585439c7d = x9b287b671d592594.xe1410f585439c7d4;
		if (x121383aa64985888 == "text:list-level-style-image")
		{
			xe1410f585439c7d.x943f6be3acf634db("xlink:href", x0404c2245e8d0997);
			xe1410f585439c7d.x943f6be3acf634db("xlink:type", "simple");
			xe1410f585439c7d.x943f6be3acf634db("xlink:show", "embed");
			xe1410f585439c7d.x943f6be3acf634db("xlink:actuate", "onLoad");
			return;
		}
		xe1410f585439c7d.x5a3f5d78674f78e4(x121383aa64985888);
		xe1410f585439c7d.x19b0790c272bbe88("xlink:href", x0404c2245e8d0997);
		xe1410f585439c7d.x19b0790c272bbe88("xlink:type", "simple");
		xe1410f585439c7d.x19b0790c272bbe88("xlink:show", "embed");
		xe1410f585439c7d.x19b0790c272bbe88("xlink:actuate", "onLoad");
		if (x121383aa64985888 == "style:background-image")
		{
			xe1410f585439c7d.x19b0790c272bbe88("style:repeat", "stretch");
		}
		xe1410f585439c7d.xd52401bdf5aacef6("/>");
	}
}
