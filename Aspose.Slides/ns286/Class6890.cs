using System;
using System.IO;
using System.Xml;

namespace ns286;

internal class Class6890 : IDisposable
{
	private const char char_0 = '\u001a';

	private const string string_0 = "\u001a";

	private XmlWriter xmlWriter_0;

	public Class6890(Stream stream)
		: this(stream, Class6891.Default)
	{
	}

	public Class6890(Stream stream, Class6891 settings)
	{
		xmlWriter_0 = XmlWriter.Create(stream, settings.method_0());
	}

	public Class6890(TextWriter textWriter)
		: this(textWriter, Class6891.Default)
	{
	}

	public Class6890(TextWriter textWriter, Class6891 settings)
	{
		xmlWriter_0 = XmlWriter.Create(textWriter, settings.method_0());
	}

	public void Flush()
	{
		xmlWriter_0.Flush();
	}

	public void method_0(string name, string pubid, string sysid, string subset)
	{
		xmlWriter_0.WriteDocType(name, pubid, sysid, subset);
	}

	public void method_1(string localName)
	{
		xmlWriter_0.WriteStartElement(localName);
	}

	public void method_2(string localName, string ns)
	{
		xmlWriter_0.WriteStartElement(localName, ns);
	}

	public void method_3(string prefix, string localName, string ns)
	{
		xmlWriter_0.WriteStartElement(prefix, localName, ns);
	}

	public void method_4()
	{
		xmlWriter_0.WriteEndElement();
	}

	public void method_5()
	{
		xmlWriter_0.WriteFullEndElement();
	}

	public void method_6(string localName, string value)
	{
		xmlWriter_0.WriteAttributeString(localName, value);
	}

	public void method_7(string text)
	{
		xmlWriter_0.WriteString(text);
	}

	public void method_8(string raw)
	{
		if (raw.Length != 0)
		{
			if (raw.IndexOf('\u001a') != -1)
			{
				raw = raw.Replace("\u001a", string.Empty);
			}
			xmlWriter_0.WriteRaw(raw.ToCharArray(), 0, raw.Length);
		}
	}

	protected virtual void Dispose(bool disposing)
	{
		if (disposing && xmlWriter_0 != null)
		{
			((IDisposable)xmlWriter_0).Dispose();
			xmlWriter_0 = null;
		}
	}

	void IDisposable.Dispose()
	{
		Dispose(disposing: true);
		GC.SuppressFinalize(this);
	}
}
