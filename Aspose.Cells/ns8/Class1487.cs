using System.Collections;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;
using Aspose.Cells;

namespace ns8;

internal class Class1487
{
	private StreamWriter streamWriter_0;

	private Encoding encoding_0 = Encoding.UTF8;

	private SaveFormat saveFormat_0 = SaveFormat.Html;

	private Hashtable hashtable_0 = new Hashtable();

	[SpecialName]
	public void method_0(Encoding encoding_1)
	{
		encoding_0 = encoding_1;
	}

	[SpecialName]
	public SaveFormat method_1()
	{
		return saveFormat_0;
	}

	[SpecialName]
	public void method_2(SaveFormat saveFormat_1)
	{
		saveFormat_0 = saveFormat_1;
	}

	[SpecialName]
	public Hashtable method_3()
	{
		return hashtable_0;
	}

	internal Class1487(Stream stream_0, Encoding encoding_1)
	{
		encoding_0 = encoding_1;
		streamWriter_0 = method_11(stream_0, encoding_0);
	}

	internal Class1487(string string_0, Encoding encoding_1)
	{
		Directory.CreateDirectory(Path.GetDirectoryName(string_0));
		FileStream stream_ = new FileStream(string_0, FileMode.Create);
		encoding_0 = encoding_1;
		streamWriter_0 = method_11(stream_, encoding_0);
	}

	internal void Write(string string_0)
	{
		streamWriter_0.Write(string_0);
	}

	internal void method_4(bool bool_0, bool bool_1)
	{
		if (bool_0)
		{
			Write("<html xmlns:v=\"urn:schemas-microsoft-com:vml\"");
			method_8("xmlns:o=\"urn:schemas-microsoft-com:office:office\"");
			method_8("xmlns:x=\"urn:schemas-microsoft-com:office:excel\"");
			method_8("xmlns=\"http://www.w3.org/TR/REC-html40\"");
			if (bool_1)
			{
				streamWriter_0.Write("dir=RTL");
			}
			streamWriter_0.Write(">");
		}
		else
		{
			method_8("<html");
			if (bool_1)
			{
				streamWriter_0.Write("dir=RTL");
			}
			streamWriter_0.Write(">");
		}
	}

	internal void method_5()
	{
		method_8("</html>");
	}

	internal void method_6()
	{
		method_8("<head>");
	}

	internal void method_7()
	{
		method_8("</head>");
	}

	internal void Close()
	{
		streamWriter_0.Close();
	}

	internal void method_8(string string_0)
	{
		streamWriter_0.Write("\n" + string_0);
	}

	internal void method_9()
	{
		streamWriter_0.Write("\n");
	}

	internal void Flush()
	{
		streamWriter_0.Flush();
	}

	internal void method_10(bool bool_0)
	{
		string text = "";
		if (bool_0)
		{
			method_8("<meta name=\"Excel Workbook Frameset\">");
		}
		method_8("<meta http-equiv=Content-Type content=\"text/html; charset=" + encoding_0.WebName + "\">");
		method_8("<meta name=ProgId content=Excel.Sheet>");
		method_8("<meta name=Generator content=\"Aspose.Cell " + text + "\">");
	}

	private StreamWriter method_11(Stream stream_0, Encoding encoding_1)
	{
		return new StreamWriter(stream_0, encoding_1);
	}
}
