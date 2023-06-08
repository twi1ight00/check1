using System.IO;
using System.Text;
using System.Xml;
using ns53;

namespace ns18;

internal abstract class Class1023
{
	private bool bool_0;

	private XmlTextWriter xmlTextWriter_0;

	private MemoryStream memoryStream_0;

	protected XmlWriter XmlPartWriter => xmlTextWriter_0;

	public MemoryStream WriteStream => memoryStream_0;

	protected void method_0()
	{
		if (bool_0)
		{
			throw new Exception5("Parsing must be started once time per instance of XmlFragmentParser. One instance of XmlFragmentParser corresponds to one part.");
		}
		bool_0 = true;
		memoryStream_0 = new MemoryStream();
		xmlTextWriter_0 = new XmlTextWriter(WriteStream, Encoding.UTF8);
		xmlTextWriter_0.Indentation = 4;
		xmlTextWriter_0.Formatting = Formatting.Indented;
	}

	protected void method_1()
	{
		xmlTextWriter_0.Flush();
		xmlTextWriter_0.Close();
	}
}
