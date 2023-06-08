using System.Collections;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;
using Aspose.Cells;

namespace ns8;

internal class Class730 : Class729
{
	private StringBuilder stringBuilder_1 = new StringBuilder();

	private StringBuilder stringBuilder_2 = new StringBuilder();

	private Class735 class735_0;

	private IStreamProvider istreamProvider_0;

	[SpecialName]
	public void method_12(IStreamProvider istreamProvider_1)
	{
		istreamProvider_0 = istreamProvider_1;
		class735_0.method_0(istreamProvider_0);
	}

	public Class730(string string_2, Workbook workbook_0, Encoding encoding_0)
	{
		class735_0 = new Class735(string_2, workbook_0);
		method_25(workbook_0);
		FileStream stream = File.OpenRead(string_2);
		method_9(new StreamReader(stream, encoding_0));
	}

	public Class730(string string_2, Workbook workbook_0, HTMLLoadOptions htmlloadOptions_0, Encoding encoding_0)
	{
		class735_0 = new Class735(string_2, workbook_0, htmlloadOptions_0);
		method_25(workbook_0);
		FileStream stream = File.OpenRead(string_2);
		method_9(new StreamReader(stream, encoding_0));
	}

	public Class730(Stream stream_0, Workbook workbook_0, Class735 class735_1, string string_2, Encoding encoding_0)
	{
		class735_0 = class735_1;
		class735_0.method_36();
		method_25(workbook_0);
		method_9(new StreamReader(stream_0, encoding_0));
		class735_0.method_35(string_2);
	}

	public Class730(Stream stream_0, Workbook workbook_0, HTMLLoadOptions htmlloadOptions_0, Encoding encoding_0)
	{
		method_25(workbook_0);
		class735_0 = new Class735(stream_0, workbook_0, htmlloadOptions_0);
		method_9(new StreamReader(stream_0, encoding_0));
	}

	public void method_13(Class735 class735_1, Workbook workbook_0, Encoding encoding_0)
	{
		class735_1.method_37();
		Hashtable hashtable = class735_1.method_33();
		IDictionaryEnumerator enumerator = hashtable.GetEnumerator();
		while (enumerator.MoveNext())
		{
			string sheetName = null;
			string sheetPath = null;
			method_14((string)enumerator.Key, out sheetName, out sheetPath);
			class735_1.method_34().method_71(class735_1.method_34().Worksheets[sheetName]);
			class735_1.method_34().method_72(class735_1.method_34().method_70().Cells);
			Stream stream = (Stream)enumerator.Value;
			Class730 @class = new Class730(stream, workbook_0, class735_1, (string)enumerator.Key, encoding_0);
			@class.method_15();
			@class.method_19().method_34().Clear();
			stream.Close();
		}
	}

	private void method_14(string src, out string sheetName, out string sheetPath)
	{
		sheetName = (sheetPath = null);
		string[] array = src.Split('\b');
		sheetName = array[0];
		sheetPath = array[1];
	}

	public void method_15()
	{
		method_20();
		char c = ' ';
		method_11(method_3());
		while (!method_2())
		{
			if (method_10() == '<')
			{
				char c2 = method_3();
				if (c2 == '!' && (c = method_3()) == '-' && method_3() == '-')
				{
					method_23();
					method_16();
				}
				else if (c2 == '!' && c == '[')
				{
					method_24();
				}
				else
				{
					method_22(c2);
					method_18();
				}
			}
			else
			{
				method_21();
				method_17();
			}
		}
	}

	public void method_16()
	{
		class735_0.method_7(stringBuilder_1.ToString());
	}

	public void method_17()
	{
		if (stringBuilder_2.Length > 0)
		{
			class735_0.method_6(stringBuilder_2.ToString());
		}
	}

	public void method_18()
	{
		if (method_7().ToString().StartsWith("/"))
		{
			class735_0.method_3(method_7().ToString().ToLower(), method_0());
		}
		else
		{
			class735_0.method_1(method_7().ToString().ToLower(), method_0());
		}
	}

	[SpecialName]
	public Class735 method_19()
	{
		return class735_0;
	}

	private void method_20()
	{
		class735_0.method_32();
	}

	private void method_21()
	{
		char c = method_3();
		if (c != '\r' && c != '\n' && c != '<')
		{
			stringBuilder_2.Remove(0, stringBuilder_2.Length);
			stringBuilder_2.Append(c);
			while (true)
			{
				if (!method_2())
				{
					c = method_3();
					if (c == '<')
					{
						break;
					}
					stringBuilder_2.Append(c);
					continue;
				}
				return;
			}
			method_11(c);
		}
		else
		{
			method_11(c);
			stringBuilder_2.Remove(0, stringBuilder_2.Length);
		}
	}

	private void method_22(char char_1)
	{
		method_7().Remove(0, method_7().Length);
		Clear();
		method_7().Append(char_1);
		while (!method_2())
		{
			char c = method_3();
			if (c != '>')
			{
				if (Class729.smethod_0(c))
				{
					break;
				}
				method_7().Append(c);
				continue;
			}
			method_11(c);
			return;
		}
		method_11(method_1());
		string string_;
		while (true)
		{
			if (method_10() != '>')
			{
				string_ = method_4();
				if (method_10() == '>')
				{
					break;
				}
				string string_2 = method_5();
				method_6(string_, string_2);
				continue;
			}
			return;
		}
		method_6(string_, "");
	}

	private void method_23()
	{
		stringBuilder_1.Remove(0, stringBuilder_1.Length);
		while (!method_2())
		{
			char c = method_3();
			if (c == '-')
			{
				stringBuilder_1.Append(c);
				c = method_3();
				if (c == '-')
				{
					c = method_3();
					if (c == '>')
					{
						stringBuilder_1.Remove(stringBuilder_1.Length - 1, 1);
						break;
					}
				}
			}
			stringBuilder_1.Append(c);
		}
		method_11(method_3());
	}

	private void method_24()
	{
		stringBuilder_1.Remove(0, stringBuilder_1.Length);
		while (!method_2())
		{
			char c = method_3();
			if (c == ']' && method_3() == '>')
			{
				break;
			}
			stringBuilder_1.Append(c);
		}
		method_11(method_3());
	}

	private void method_25(Workbook workbook_0)
	{
		for (int i = 0; i < workbook_0.Worksheets.Count; i++)
		{
			workbook_0.Worksheets[i].IsGridlinesVisible = false;
		}
	}
}
