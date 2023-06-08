using System.Text;
using System.Xml;

namespace ns286;

internal class Class6891
{
	private Encoding encoding_0;

	private bool bool_0;

	private string string_0;

	private bool bool_1;

	public Encoding Encoding
	{
		get
		{
			return encoding_0;
		}
		set
		{
			encoding_0 = value;
		}
	}

	public bool Indent
	{
		get
		{
			return bool_0;
		}
		set
		{
			bool_0 = value;
		}
	}

	public string IndentChars
	{
		get
		{
			return string_0;
		}
		set
		{
			string_0 = value;
		}
	}

	public bool OmitXmlDeclaration
	{
		get
		{
			return bool_1;
		}
		set
		{
			bool_1 = value;
		}
	}

	public static Class6891 Default
	{
		get
		{
			Class6891 @class = new Class6891();
			@class.Indent = true;
			@class.IndentChars = "\t";
			@class.OmitXmlDeclaration = true;
			@class.Encoding = new UTF8Encoding(encoderShouldEmitUTF8Identifier: false);
			return @class;
		}
	}

	public Class6891()
	{
		encoding_0 = Encoding.UTF8;
		string_0 = "\t";
	}

	internal XmlWriterSettings method_0()
	{
		XmlWriterSettings xmlWriterSettings = new XmlWriterSettings();
		xmlWriterSettings.Indent = Indent;
		xmlWriterSettings.IndentChars = IndentChars;
		xmlWriterSettings.OmitXmlDeclaration = OmitXmlDeclaration;
		xmlWriterSettings.Encoding = Encoding;
		return xmlWriterSettings;
	}
}
