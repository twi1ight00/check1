using System;
using System.IO;
using System.Text;
using Aspose.Cells.Properties;
using ns22;
using ns30;
using ns57;

namespace ns59;

internal class Class1726
{
	private BuiltInDocumentPropertyCollection builtInDocumentPropertyCollection_0;

	private CustomDocumentPropertyCollection customDocumentPropertyCollection_0;

	private Class1325 class1325_0;

	private Class1325 class1325_1;

	private Class1325 class1325_2;

	private static readonly DateTime dateTime_0 = new DateTime(1601, 1, 1);

	internal void Read(Class1319 class1319_0, BuiltInDocumentPropertyCollection builtInDocumentPropertyCollection_1, CustomDocumentPropertyCollection customDocumentPropertyCollection_1)
	{
		try
		{
			builtInDocumentPropertyCollection_0 = builtInDocumentPropertyCollection_1;
			customDocumentPropertyCollection_0 = customDocumentPropertyCollection_1;
			Stream stream = class1319_0.GetStream("\u0005SummaryInformation");
			if (stream != null)
			{
				method_0(stream);
			}
			Stream stream2 = class1319_0.GetStream("\u0005DocumentSummaryInformation");
			if (stream2 != null)
			{
				method_1(stream2);
			}
		}
		catch
		{
		}
	}

	private void method_0(Stream stream_0)
	{
		Class1324 @class = new Class1324(stream_0);
		if (@class.method_0().Count > 0)
		{
			Class1323 properties = @class.method_0()[0].Properties;
			smethod_0(properties, builtInDocumentPropertyCollection_0, Enum218.const_0);
		}
	}

	private void method_1(Stream stream_0)
	{
		Class1324 @class = new Class1324(stream_0);
		if (@class.method_0().Count > 0)
		{
			Class1323 properties = @class.method_0()[0].Properties;
			smethod_0(properties, builtInDocumentPropertyCollection_0, Enum218.const_1);
		}
		if (@class.method_0().Count > 1)
		{
			Class1323 properties2 = @class.method_0()[1].Properties;
			smethod_0(properties2, customDocumentPropertyCollection_0, Enum218.const_2);
		}
	}

	[Attribute0(true)]
	private static void smethod_0(Class1323 class1323_0, DocumentPropertyCollection documentPropertyCollection_0, Enum218 enum218_0)
	{
		for (int i = 0; i < class1323_0.Count; i++)
		{
			Class1322 @class = class1323_0[i];
			string text;
			bool bool_;
			switch (enum218_0)
			{
			case Enum218.const_0:
				text = BuiltInDocumentPropertyCollection.smethod_0(@class.int_0, enum218_0);
				switch ((Enum192)@class.int_0)
				{
				case Enum192.const_7:
					try
					{
						@class.object_0 = int.Parse((string)@class.object_0);
					}
					catch (Exception)
					{
						@class.object_0 = 0;
					}
					break;
				case Enum192.const_8:
					@class.object_0 = ((DateTime)@class.object_0 - dateTime_0).TotalMinutes;
					break;
				}
				goto IL_012f;
			case Enum218.const_1:
				text = BuiltInDocumentPropertyCollection.smethod_0(@class.int_0, enum218_0);
				goto IL_012f;
			case Enum218.const_2:
				text = @class.string_0;
				goto IL_012f;
			default:
				{
					throw new Exception("Unknown property group type.");
				}
				IL_012f:
				bool_ = false;
				if (text == null)
				{
					text = "퀀_generated_" + (int)enum218_0 + "." + @class.int_0;
					bool_ = true;
				}
				break;
			}
			documentPropertyCollection_0.Add(enum218_0, @class.int_0, text, @class.object_0, bool_);
		}
	}

	internal static byte[] smethod_1(string string_0)
	{
		byte[] bytes = Encoding.Unicode.GetBytes(string_0);
		byte[] array = new byte[bytes.Length + 2];
		Array.Copy(bytes, array, bytes.Length);
		return array;
	}

	[Attribute0(true)]
	internal void Write(BuiltInDocumentPropertyCollection builtInDocumentPropertyCollection_1, CustomDocumentPropertyCollection customDocumentPropertyCollection_1, Class1319 class1319_0)
	{
		string text = null;
		builtInDocumentPropertyCollection_0 = builtInDocumentPropertyCollection_1;
		if (builtInDocumentPropertyCollection_1.Contains("HyperlinkBase"))
		{
			text = builtInDocumentPropertyCollection_1.HyperlinkBase;
			builtInDocumentPropertyCollection_1.Remove("HyperlinkBase");
			if (text != null && text != "")
			{
				customDocumentPropertyCollection_1.Remove("_PID_LINKBASE");
				customDocumentPropertyCollection_1.Add("_PID_LINKBASE", smethod_1(text));
			}
		}
		customDocumentPropertyCollection_0 = customDocumentPropertyCollection_1;
		Class1324 @class = new Class1324();
		class1325_0 = new Class1325(Class1325.guid_1);
		@class.method_0().Add(class1325_0);
		Class1324 class2 = new Class1324();
		class1325_1 = new Class1325(Class1325.guid_2);
		class2.method_0().Add(class1325_1);
		class1325_2 = new Class1325(Class1325.guid_3);
		class2.method_0().Add(class1325_2);
		method_2(builtInDocumentPropertyCollection_0);
		method_2(customDocumentPropertyCollection_0);
		if (class1325_2.Properties.Count == 0)
		{
			class2.method_0().Remove(class1325_2);
		}
		MemoryStream memoryStream = new MemoryStream();
		@class.Save(memoryStream);
		class1319_0["\u0005SummaryInformation"] = memoryStream;
		MemoryStream memoryStream2 = new MemoryStream();
		class2.Save(memoryStream2);
		class1319_0["\u0005DocumentSummaryInformation"] = memoryStream2;
		if (text != null && text != "")
		{
			builtInDocumentPropertyCollection_1.HyperlinkBase = text;
			customDocumentPropertyCollection_1.Remove("_PID_LINKBASE");
		}
	}

	[Attribute0(true)]
	private void method_2(DocumentPropertyCollection documentPropertyCollection_0)
	{
		foreach (DocumentProperty item in documentPropertyCollection_0)
		{
			switch (item.Group)
			{
			case Enum218.const_0:
			{
				object obj = item.Value;
				switch ((Enum192)item.method_0())
				{
				case Enum192.const_7:
					obj = obj.ToString();
					break;
				case Enum192.const_8:
				{
					TimeSpan timeSpan = TimeSpan.FromMinutes((double)obj);
					obj = dateTime_0 + timeSpan;
					break;
				}
				}
				class1325_0.Properties.Add(new Class1322(item.method_0(), null, obj));
				break;
			}
			case Enum218.const_1:
				class1325_1.Properties.Add(new Class1322(item.method_0(), null, item.Value));
				break;
			case Enum218.const_2:
			{
				string string_ = (item.IsGeneratedName ? null : item.Name);
				class1325_2.Properties.Add(new Class1322(item.method_0(), string_, item.Value));
				break;
			}
			default:
				throw new Exception("Unknown property group.");
			}
		}
	}
}
