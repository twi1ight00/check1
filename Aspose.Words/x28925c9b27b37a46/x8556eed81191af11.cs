using System.Collections;
using System.IO;
using Aspose.Words;
using Aspose.Words.Drawing;
using Aspose.Words.Saving;
using x011d489fb9df7027;
using x38d3ef1c1d247e82;
using x6c95d9cf46ff5f25;
using xb92b7270f78a4e8d;

namespace x28925c9b27b37a46;

internal class x8556eed81191af11
{
	internal Document x2c8c6741422a1298;

	internal Stream xb8a774e0111d0fbe;

	internal string xa39af5a82860a9a3;

	internal SaveOptions xf57de0fd37d5e97d;

	internal xe7be411416cfcd54 x7c3f3666365efbc6 = new xe7be411416cfcd54();

	internal xe7be411416cfcd54 xf341204f1f55ff47 = new xe7be411416cfcd54();

	internal bool xd72e197c9500653f;

	internal bool x427aee4dfcc89c31;

	internal bool xdff795aea0409829;

	internal xd345c73dd1b16b74 x688a25acd97815ab = new xd345c73dd1b16b74();

	internal xd345c73dd1b16b74 xf6915d468ae54ed1 = new xd345c73dd1b16b74();

	internal xd345c73dd1b16b74 x916244faa1c7ed9f = new xd345c73dd1b16b74();

	internal x1e9b3e0e8864e135 x158c955c749c5e5b;

	internal Hashtable xe42bd130f1e95570 = new Hashtable();

	internal x94c83b1ca7961561 xa2c21fc178d67af8 = new x94c83b1ca7961561();

	private readonly ArrayList x5b2dbaa8757e69c5 = new ArrayList();

	private readonly ArrayList xf85e10392e75539c = new ArrayList();

	internal SaveFormat x707d72c3570dbf2d => xf57de0fd37d5e97d.SaveFormat;

	internal bool x3a8dc2dec3d16d89 => xf341204f1f55ff47.Count > 0;

	internal bool x35d47c685b5fd0e6
	{
		get
		{
			if (x707d72c3570dbf2d != SaveFormat.Pdf && x707d72c3570dbf2d != SaveFormat.Xps && x707d72c3570dbf2d != SaveFormat.Png && x707d72c3570dbf2d != SaveFormat.Swf && x707d72c3570dbf2d != SaveFormat.Svg && x707d72c3570dbf2d != SaveFormat.Tiff && x707d72c3570dbf2d != SaveFormat.Bmp && x707d72c3570dbf2d != SaveFormat.Emf && x707d72c3570dbf2d != SaveFormat.Jpeg)
			{
				return x707d72c3570dbf2d == SaveFormat.XamlFixed;
			}
			return true;
		}
	}

	internal bool xfa6c1a3e13a2b61b
	{
		get
		{
			if (x707d72c3570dbf2d != SaveFormat.Docx && x707d72c3570dbf2d != SaveFormat.Docm && x707d72c3570dbf2d != SaveFormat.Dotx && x707d72c3570dbf2d != SaveFormat.Dotm && x707d72c3570dbf2d != SaveFormat.FlatOpc && x707d72c3570dbf2d != SaveFormat.FlatOpcMacroEnabled && x707d72c3570dbf2d != SaveFormat.FlatOpcTemplate)
			{
				return x707d72c3570dbf2d == SaveFormat.FlatOpcTemplateMacroEnabled;
			}
			return true;
		}
	}

	internal x8556eed81191af11(Document doc, Stream stream, string fileName, SaveOptions saveOptions)
	{
		x2c8c6741422a1298 = doc;
		xb8a774e0111d0fbe = stream;
		xa39af5a82860a9a3 = fileName;
		xf57de0fd37d5e97d = saveOptions;
	}

	internal void xdc421ae00841d163(ShapeBase x5770cdefd8931aa9, bool xe7d7afd9c3c7235a)
	{
		if (x5770cdefd8931aa9.IsTopLevel)
		{
			x67b8a7f950420880(xe7d7afd9c3c7235a).Add(x5770cdefd8931aa9);
		}
	}

	private ArrayList x67b8a7f950420880(bool xe7d7afd9c3c7235a)
	{
		if (!xe7d7afd9c3c7235a)
		{
			return x5b2dbaa8757e69c5;
		}
		return xf85e10392e75539c;
	}

	internal void xd65754175bfac027()
	{
		xd65754175bfac027(x5b2dbaa8757e69c5);
		xd65754175bfac027(xf85e10392e75539c);
	}

	private static void xd65754175bfac027(ArrayList xb8d4ee4d8de67728)
	{
		if (xb8d4ee4d8de67728.Count == 0)
		{
			return;
		}
		xb8d4ee4d8de67728.Sort(new x41d5513fb432c671());
		int num = 1;
		int num2 = 0;
		foreach (ShapeBase item in xb8d4ee4d8de67728)
		{
			if (!item.IsInline)
			{
				if (!item.BehindText)
				{
					item.x2dacf7fcd96fee63 = num++;
				}
				else
				{
					num2++;
				}
			}
		}
		num = -num2;
		foreach (ShapeBase item2 in xb8d4ee4d8de67728)
		{
			if (!item2.IsInline && item2.BehindText)
			{
				item2.x2dacf7fcd96fee63 = num++;
			}
		}
	}

	internal void x466c910d5f8cc342()
	{
		x466c910d5f8cc342(x5b2dbaa8757e69c5);
		x466c910d5f8cc342(xf85e10392e75539c);
	}

	private static void x466c910d5f8cc342(ArrayList xb8d4ee4d8de67728)
	{
		if (xb8d4ee4d8de67728.Count == 0)
		{
			return;
		}
		xb8d4ee4d8de67728.Sort(new x41d5513fb432c671());
		int num = 0;
		foreach (ShapeBase item in xb8d4ee4d8de67728)
		{
			if (!item.IsInline && !item.BehindText)
			{
				item.x2dacf7fcd96fee63 = 251658240 + num;
				num += 1024;
			}
		}
		num = 0;
		foreach (ShapeBase item2 in xb8d4ee4d8de67728)
		{
			if (!item2.IsInline && item2.BehindText)
			{
				item2.x2dacf7fcd96fee63 = -251658240 + num;
				num += 1024;
			}
		}
	}

	internal void x95f46c00b56409c0()
	{
		x95f46c00b56409c0(x5b2dbaa8757e69c5);
		x95f46c00b56409c0(xf85e10392e75539c);
	}

	private static void x95f46c00b56409c0(ArrayList xb8d4ee4d8de67728)
	{
		if (xb8d4ee4d8de67728.Count == 0)
		{
			return;
		}
		xb8d4ee4d8de67728.Sort(new x41d5513fb432c671());
		int num = 0;
		foreach (ShapeBase item in xb8d4ee4d8de67728)
		{
			if (!item.IsInline || item.xac9731dd322f2036)
			{
				item.x2dacf7fcd96fee63 = num++;
			}
		}
	}
}
