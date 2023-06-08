using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using ns292;
using ns298;

namespace ns299;

internal class Class6868 : IDisposable
{
	private const int int_0 = 4095;

	private TextWriter textWriter_0;

	private int int_1 = 1;

	private readonly Hashtable hashtable_0 = new Hashtable();

	private readonly List<KeyValuePair<string, string>> list_0 = new List<KeyValuePair<string, string>>();

	private Stream stream_0;

	private List<int> list_1 = new List<int>();

	private Class6790 class6790_0;

	private int int_2;

	public List<int> StyleRestrictionPositions => list_1;

	public Class6868(TextWriter writer, Class6790 options)
	{
		textWriter_0 = writer;
		class6790_0 = options;
	}

	public Class6868(Stream stream, Class6790 options)
		: this(new StreamWriter(stream), options)
	{
		stream_0 = stream;
		class6790_0 = options;
	}

	public Class6868(string filename, Class6790 options)
	{
		Class6872.smethod_4(filename);
		textWriter_0 = new StreamWriter(new FileStream(filename, FileMode.Create, FileAccess.Write, FileShare.Read));
		class6790_0 = options;
	}

	public bool method_0(string fontFamily, string url)
	{
		string value = fontFamily.ToLower();
		foreach (KeyValuePair<string, string> item in list_0)
		{
			if (item.Key.Equals(value, StringComparison.OrdinalIgnoreCase))
			{
				string fileName = Path.GetFileName(url);
				string fileName2 = Path.GetFileName(item.Value);
				if (fileName != null && fileName.Equals(fileName2, StringComparison.OrdinalIgnoreCase))
				{
					return true;
				}
			}
		}
		return false;
	}

	public bool method_1(string fontFamily, string url)
	{
		if (method_0(fontFamily, url))
		{
			return false;
		}
		list_0.Add(new KeyValuePair<string, string>(fontFamily.ToLower(), Path.GetFileName(url)));
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.AppendLine("@font-face {");
		stringBuilder.AppendLine($"\tfont-family:\"{fontFamily}\";");
		stringBuilder.AppendLine($"\tsrc:url(\"{url}\");");
		stringBuilder.AppendLine("}");
		textWriter_0.Write(stringBuilder.ToString());
		return true;
	}

	public void method_2(string fontFamily, string url)
	{
		list_0.Add(new KeyValuePair<string, string>(fontFamily.ToLower(), Path.GetFileName(url)));
	}

	public bool method_3(string fontFamily, string eotUrl, string woffUrl, string ttfUrl)
	{
		if (string.IsNullOrEmpty(eotUrl) && string.IsNullOrEmpty(woffUrl) && string.IsNullOrEmpty(ttfUrl))
		{
			return false;
		}
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.AppendLine("@font-face {");
		stringBuilder.AppendLine($"\tfont-family:\"{fontFamily}\";");
		StringBuilder stringBuilder2 = new StringBuilder();
		if (!string.IsNullOrEmpty(eotUrl))
		{
			stringBuilder2.AppendLine($"\tsrc:url(\"{eotUrl}\");");
			stringBuilder2.AppendFormat("\tsrc:url(\"{0}?#iefix\") format(\"embedded-opentype\")", eotUrl);
			stringBuilder2.Append((!string.IsNullOrEmpty(woffUrl) || !string.IsNullOrEmpty(ttfUrl)) ? ",\n" : ";\n");
		}
		if (!string.IsNullOrEmpty(woffUrl))
		{
			stringBuilder2.Append((stringBuilder2.Length == 0) ? "\tsrc:" : "\t");
			stringBuilder2.AppendFormat("url(\"{0}\") format(\"woff\")", woffUrl);
			stringBuilder2.Append((!string.IsNullOrEmpty(ttfUrl)) ? ",\n" : ";\n");
		}
		if (!string.IsNullOrEmpty(ttfUrl))
		{
			stringBuilder2.Append((stringBuilder2.Length == 0) ? "\tsrc:" : "\t");
			stringBuilder2.AppendFormat("url(\"{0}\") format(\"truetype\");\n", ttfUrl);
		}
		stringBuilder.Append(stringBuilder2.ToString());
		stringBuilder.AppendLine("}");
		textWriter_0.Write(stringBuilder.ToString());
		return true;
	}

	public void method_4(string css, int rawStylesNumber)
	{
		int_2 += rawStylesNumber;
		if (method_6())
		{
			method_7();
			int_2 = 0;
		}
		textWriter_0.Write(css);
	}

	public string method_5(Class6866 builder)
	{
		string text = method_13();
		hashtable_0.Add(text, builder);
		method_7();
		textWriter_0.Write(builder.method_3("." + text));
		return text;
	}

	private bool method_6()
	{
		if (stream_0 != null && hashtable_0.Count + int_2 > 0)
		{
			return (hashtable_0.Count + int_2) % 4095 == 0;
		}
		return false;
	}

	public void method_7()
	{
		if (method_6())
		{
			Flush();
			StyleRestrictionPositions.Add((int)stream_0.Position);
		}
	}

	public string method_8(Class6866 builder, string key)
	{
		if (!hashtable_0.Contains(key))
		{
			hashtable_0.Add(key, builder);
			method_7();
			textWriter_0.Write(builder.method_3("." + key));
		}
		return key;
	}

	public string method_9(string key, Class6866 builder)
	{
		hashtable_0.Add(key, builder);
		method_7();
		textWriter_0.Write(builder.method_3(key));
		return key;
	}

	public bool method_10(Class6866 builder)
	{
		return hashtable_0.ContainsValue(builder);
	}

	public bool method_11(string key)
	{
		return hashtable_0.ContainsKey(key);
	}

	public string method_12(Class6866 builder)
	{
		string result = null;
		foreach (DictionaryEntry item in hashtable_0)
		{
			if (item.Value.Equals(builder))
			{
				result = (string)item.Key;
				break;
			}
		}
		return result;
	}

	public string method_13()
	{
		string text = class6790_0.ClassNamePrefix.TrimStart(' ', '.');
		string result = text + int_1.ToString("00", Class6872.HtmlCulture.NumberFormat);
		int_1++;
		return result;
	}

	public void Flush()
	{
		textWriter_0.Flush();
	}

	public void Close()
	{
		textWriter_0.Close();
	}

	protected virtual void Dispose(bool disposing)
	{
		if (disposing && textWriter_0 != null)
		{
			textWriter_0.Dispose();
			textWriter_0 = null;
		}
	}

	void IDisposable.Dispose()
	{
		Dispose(disposing: true);
		GC.SuppressFinalize(this);
	}
}
