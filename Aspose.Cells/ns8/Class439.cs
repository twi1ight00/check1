using System.Collections;
using System.IO;
using System.Text;
using System.Xml;
using Aspose.Cells;
using ns16;
using ns22;

namespace ns8;

internal class Class439
{
	private IStreamProvider istreamProvider_0;

	private Hashtable hashtable_0;

	public Class439(IStreamProvider istreamProvider_1)
	{
		istreamProvider_0 = istreamProvider_1;
	}

	public void method_0(string string_0, Workbook workbook_0, LoadOptions loadOptions_0)
	{
		Class437 @class = new Class437();
		((Class433)istreamProvider_0).method_0(@class.method_1(string_0, Encoding.UTF8));
		method_2(workbook_0, loadOptions_0);
	}

	public void method_1(Stream stream_0, Workbook workbook_0, LoadOptions loadOptions_0)
	{
		Class437 @class = new Class437();
		((Class433)istreamProvider_0).method_0(@class.method_0(stream_0, Encoding.UTF8));
		method_2(workbook_0, loadOptions_0);
	}

	private void method_2(Workbook workbook_0, LoadOptions loadOptions_0)
	{
		Hashtable hashtable = ((Class433)istreamProvider_0).method_1();
		string string_ = "filelist.xml";
		Stream stream = method_4(hashtable, string_);
		if (hashtable.Count > 1 && stream != null)
		{
			XmlDocument xmlDocument = Class1188.smethod_2(stream);
			XmlNodeList elementsByTagName = xmlDocument.GetElementsByTagName("o:MainFile");
			XmlElement xmlNode_ = (XmlElement)elementsByTagName[0];
			string text = Class1618.smethod_172(xmlNode_, "HRef");
			string string_2 = text.Substring(text.LastIndexOf("/") + 1);
			Stream stream_ = method_4(hashtable, string_2);
			method_3(stream_, workbook_0, loadOptions_0);
			return;
		}
		IDictionaryEnumerator enumerator = hashtable.GetEnumerator();
		if (hashtable.Count == 1)
		{
			while (enumerator.MoveNext())
			{
				method_3(((Class438)enumerator.Value).stream_0, workbook_0, loadOptions_0);
			}
			return;
		}
		hashtable_0 = new Hashtable();
		while (enumerator.MoveNext())
		{
			Class438 @class = (Class438)enumerator.Value;
			if (@class.string_0.IndexOf("css") == -1)
			{
				continue;
			}
			Class730 class2 = new Class730(@class.stream_0, workbook_0, new HTMLLoadOptions(), Encoding.UTF8);
			class2.method_12(istreamProvider_0);
			class2.method_19().method_8(@class.stream_0);
			foreach (DictionaryEntry item in class2.method_19().method_34().method_73())
			{
				hashtable_0.Add(item.Key, item.Value);
			}
		}
		enumerator = hashtable.GetEnumerator();
		while (enumerator.MoveNext())
		{
			if (((Class438)enumerator.Value).string_0.IndexOf("css") == -1)
			{
				method_3(((Class438)enumerator.Value).stream_0, workbook_0, loadOptions_0);
			}
		}
	}

	private void method_3(Stream stream_0, Workbook workbook_0, LoadOptions loadOptions_0)
	{
		try
		{
			Class730 @class = new Class730(stream_0, workbook_0, new HTMLLoadOptions(), Encoding.UTF8);
			@class.method_12(istreamProvider_0);
			if (hashtable_0 != null)
			{
				@class.method_19().method_34().method_74(hashtable_0);
			}
			@class.method_15();
			@class.method_19().method_34().Clear();
			if (method_5(@class))
			{
				@class.method_13(@class.method_19(), workbook_0, Encoding.UTF8);
			}
		}
		finally
		{
			stream_0?.Close();
		}
	}

	private Stream method_4(Hashtable hashtable_1, string string_0)
	{
		IDictionaryEnumerator enumerator = hashtable_1.GetEnumerator();
		string[] array;
		do
		{
			if (enumerator.MoveNext())
			{
				string text = (string)enumerator.Key;
				array = text.Split('/');
				continue;
			}
			return null;
		}
		while (!array[array.Length - 1].Equals(string_0));
		return (Stream)enumerator.Value;
	}

	private bool method_5(Class730 class730_0)
	{
		foreach (Stream value in class730_0.method_19().method_33().Values)
		{
			if (value != null)
			{
				return true;
			}
		}
		return false;
	}
}
