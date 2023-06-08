using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml;
using ns292;
using ns299;

namespace ns298;

internal class Class6869 : IDisposable
{
	private const char char_0 = '\t';

	private XmlTextWriter xmlTextWriter_0;

	private Class6875 class6875_0;

	private readonly Stack stack_0 = new Stack();

	protected static readonly Encoding encoding_0 = new UTF8Encoding(encoderShouldEmitUTF8Identifier: false);

	private Class6866 class6866_0;

	private readonly Class6868 class6868_0;

	private readonly Stream stream_0;

	private readonly Class6794 class6794_0;

	private readonly string string_0;

	protected Class6875 CurrentTag
	{
		get
		{
			return class6875_0;
		}
		set
		{
			class6875_0 = value;
		}
	}

	public XmlTextWriter InnerWriter => xmlTextWriter_0;

	public Encoding Encoding => encoding_0;

	public Class6869(Stream stream, Class6868 cssWriter, Class6794 bundle, string cssLocation)
	{
		stream_0 = stream;
		xmlTextWriter_0 = new XmlTextWriter(stream_0, encoding_0);
		xmlTextWriter_0.IndentChar = '\t';
		xmlTextWriter_0.Formatting = Formatting.Indented;
		xmlTextWriter_0.Indentation = 1;
		string_0 = cssLocation;
		class6868_0 = cssWriter;
		class6794_0 = bundle;
	}

	public void Write(string value, bool replaceReturn, bool addWhiteSpaceToLineEnd)
	{
		StringBuilder stringBuilder = new StringBuilder();
		for (int i = 0; i < value.Length; i++)
		{
			char c = value[i];
			if (replaceReturn && c == '\r')
			{
				xmlTextWriter_0.WriteString(stringBuilder.ToString());
				stringBuilder.Remove(0, stringBuilder.Length);
				if (addWhiteSpaceToLineEnd)
				{
					xmlTextWriter_0.WriteRaw(" &nbsp;");
				}
				continue;
			}
			if (!char.IsWhiteSpace(c))
			{
				stringBuilder.Append(c);
				continue;
			}
			int num = smethod_0(value, i);
			if (num == 1)
			{
				stringBuilder.Append(c);
				continue;
			}
			xmlTextWriter_0.WriteString(stringBuilder.ToString());
			stringBuilder.Remove(0, stringBuilder.Length);
			i += num - 1;
			while (num != 0)
			{
				xmlTextWriter_0.WriteRaw("&nbsp;");
				num--;
			}
		}
		if (stringBuilder.Length != 0)
		{
			xmlTextWriter_0.WriteString(stringBuilder.ToString());
		}
	}

	public void Write(string format, object arg0)
	{
		xmlTextWriter_0.WriteString(string.Format(format, arg0));
	}

	public void Write(string format, object arg0, object arg1)
	{
		xmlTextWriter_0.WriteString(string.Format(format, arg0, arg1));
	}

	public void Write(string format, object arg0, object arg1, object arg2)
	{
		xmlTextWriter_0.WriteString(string.Format(format, arg0, arg1, arg2));
	}

	public void Write(string format, params object[] arg)
	{
		xmlTextWriter_0.WriteString(string.Format(format, arg));
	}

	public void method_0()
	{
		xmlTextWriter_0.WriteString(Environment.NewLine);
	}

	public void method_1(string format, object arg0)
	{
		xmlTextWriter_0.WriteString(string.Format(format, arg0));
		method_0();
	}

	public void method_2(string format, object arg0, object arg1)
	{
		xmlTextWriter_0.WriteString(string.Format(format, arg0, arg1));
		method_0();
	}

	public void method_3(string format, object arg0, object arg1, object arg2)
	{
		xmlTextWriter_0.WriteString(string.Format(format, arg0, arg1, arg2));
		method_0();
	}

	public void method_4(string format, params object[] arg)
	{
		xmlTextWriter_0.WriteString(string.Format(format, arg));
		method_0();
	}

	public void method_5(string value)
	{
		xmlTextWriter_0.WriteString(value);
		method_0();
	}

	public void method_6(Enum931 tag)
	{
		method_8(tag, null);
	}

	internal void method_7()
	{
		xmlTextWriter_0.WriteRaw("<!--[if IE]>  <html class=\"ie\"> <![endif]-->");
	}

	public void method_8(Enum931 tag, string ns)
	{
		Class6875 @class = new Class6875(tag);
		vmethod_2(tag);
		if (ns == null)
		{
			xmlTextWriter_0.WriteStartElement(vmethod_0(@class));
		}
		else
		{
			xmlTextWriter_0.WriteStartElement(vmethod_0(@class), ns);
		}
		CurrentTag = @class;
		method_21(CurrentTag);
	}

	public void method_9()
	{
		method_11();
		xmlTextWriter_0.WriteEndElement();
	}

	public void method_10()
	{
		method_11();
		xmlTextWriter_0.WriteFullEndElement();
	}

	private void method_11()
	{
		Class6876 @class = method_22();
		if (CurrentTag.Tag == Enum931.const_4)
		{
			method_12();
		}
		CurrentTag = @class.ParentTag;
	}

	private void method_12()
	{
		string value = string_0;
		new Class6871(this).method_1(Enum931.const_9).method_5(Enum929.const_26, "stylesheet").method_5(Enum929.const_34, "text/css")
			.method_5(Enum929.const_15, value)
			.method_3();
	}

	public void method_13(Enum929 attribute, string value)
	{
		xmlTextWriter_0.WriteAttributeString(vmethod_1(new Class6865(attribute)), value);
	}

	public void method_14()
	{
		class6866_0 = new Class6866();
	}

	public void method_15(Enum930 style, string value)
	{
		if (class6866_0 == null)
		{
			throw new InvalidOperationException("Call \"BeginRenderStyle\" method before adding styles.");
		}
		class6866_0[style] = value;
	}

	public void method_16()
	{
		if (class6866_0 == null)
		{
			throw new InvalidOperationException("Call \"BeginRenderStyle\" method before render styles.");
		}
		string value = (class6868_0.method_10(class6866_0) ? class6868_0.method_12(class6866_0) : class6868_0.method_5(class6866_0));
		method_13(Enum929.const_9, smethod_1(value));
		class6866_0 = null;
	}

	internal string method_17(out bool alreadyExist)
	{
		return method_18(null, out alreadyExist);
	}

	internal string method_18(string key, out bool alreadyExist)
	{
		if (class6866_0 == null)
		{
			throw new InvalidOperationException("Call \"BeginRenderStyle\" method before render styles.");
		}
		alreadyExist = class6868_0.method_10(class6866_0);
		string result = (alreadyExist ? class6868_0.method_12(class6866_0) : (string.IsNullOrEmpty(key) ? class6868_0.method_5(class6866_0) : class6868_0.method_8(class6866_0, key)));
		class6866_0 = null;
		return result;
	}

	internal void method_19(string stylesId)
	{
		method_13(Enum929.const_9, smethod_1(stylesId));
	}

	public void method_20(string key, Class6866 cssBuilder)
	{
		if (!class6868_0.method_11(key))
		{
			class6868_0.method_9(key, cssBuilder);
		}
	}

	protected virtual string vmethod_0(Class6875 tagInfo)
	{
		return tagInfo.Name;
	}

	protected virtual string vmethod_1(Class6865 attribute)
	{
		return attribute.Name;
	}

	protected virtual void vmethod_2(Enum931 tag)
	{
	}

	private void method_21(Class6875 tag)
	{
		Class6875 parentTag = null;
		if (stack_0.Count != 0)
		{
			Class6876 @class = (Class6876)stack_0.Peek();
			parentTag = @class.TagInfo;
		}
		Class6876 obj = new Class6876(tag, parentTag);
		stack_0.Push(obj);
	}

	private Class6876 method_22()
	{
		return (Class6876)stack_0.Pop();
	}

	public void Flush()
	{
		xmlTextWriter_0.Flush();
	}

	public void Close()
	{
		xmlTextWriter_0.Close();
	}

	internal void method_23()
	{
		class6868_0.Flush();
		class6868_0.Close();
	}

	protected virtual void Dispose(bool disposing)
	{
		if (disposing && xmlTextWriter_0 != null)
		{
			((IDisposable)xmlTextWriter_0).Dispose();
			xmlTextWriter_0 = null;
		}
	}

	void IDisposable.Dispose()
	{
		Dispose(disposing: true);
		GC.SuppressFinalize(this);
	}

	private static int smethod_0(string value, int index)
	{
		int num = 0;
		for (int i = index; i < value.Length && char.IsWhiteSpace(value[i]); i++)
		{
			num++;
		}
		return num;
	}

	private static string smethod_1(string value)
	{
		List<string> list = new List<string>();
		string[] array = value.Split(new string[2] { " ", "." }, StringSplitOptions.RemoveEmptyEntries);
		foreach (string item in array)
		{
			if (!list.Contains(item))
			{
				list.Add(item);
			}
		}
		return string.Join(" ", list.ToArray());
	}
}
