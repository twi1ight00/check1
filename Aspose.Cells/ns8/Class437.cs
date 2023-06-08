using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using ns1;

namespace ns8;

internal class Class437
{
	private Hashtable hashtable_0;

	public Class437()
	{
		hashtable_0 = new Hashtable();
	}

	public Hashtable method_0(Stream stream_0, Encoding encoding_0)
	{
		StreamReader streamReader_ = new StreamReader(stream_0, encoding_0);
		return method_2(streamReader_, encoding_0);
	}

	public Hashtable method_1(string string_0, Encoding encoding_0)
	{
		StreamReader streamReader = new StreamReader(string_0, encoding_0);
		try
		{
			return method_2(streamReader, encoding_0);
		}
		finally
		{
			streamReader?.Close();
		}
	}

	private Hashtable method_2(StreamReader streamReader_0, Encoding encoding_0)
	{
		string value = "Content-Location";
		string value2 = "Content-Transfer-Encoding";
		string value3 = "Content-Type";
		string value4 = "Content-ID";
		string text = "boundary=";
		string text2 = "X-Document-Type";
		int num = 0;
		string text3 = null;
		bool flag = false;
		Stream stream = null;
		StreamWriter streamWriter = null;
		bool flag2 = false;
		string text4 = null;
		string text5 = null;
		string string_ = null;
		string string_2 = null;
		string text6;
		while ((text6 = streamReader_0.ReadLine()) != null)
		{
			if (text6.Length == 0)
			{
				continue;
			}
			int num2 = text6.IndexOf(text2);
			if (num2 != -1)
			{
				string text7 = text6.Substring(text2.Length + 1);
				if (text7.Trim().ToUpper().Equals("WORKSHEET"))
				{
					flag2 = true;
					flag = true;
				}
			}
			int num3 = text6.IndexOf(text);
			if (num3 > -1)
			{
				text3 = text6.Substring(text6.IndexOf(text) + text.Length);
				if (text3.StartsWith("\"") && text3.StartsWith("\""))
				{
					text3 = text3.Substring(1, text3.Length - 2);
				}
				continue;
			}
			if (Class436.smethod_0(text6, text3))
			{
				flag = true;
			}
			if (flag)
			{
				int num4 = 0;
				string text8 = text6;
				stream = new MemoryStream();
				streamWriter = new StreamWriter(stream);
				text4 = null;
				text5 = null;
				string_2 = null;
				while (text8 != null)
				{
					if (text8.StartsWith(value))
					{
						text4 = Class436.smethod_1(text8);
					}
					if (text8.StartsWith(value4))
					{
						text5 = Class436.smethod_1(text8);
					}
					if (text8.StartsWith(value3))
					{
						string_ = Class436.smethod_1(text8);
					}
					if (text8.StartsWith(value2))
					{
						string_2 = Class436.smethod_1(text8);
					}
					if (num4 > 3)
					{
						if (Class436.smethod_0(text8, text3))
						{
							if (text4 == null && text5 == null)
							{
								text4 = "";
							}
							else if (text4 == null && text5 != null)
							{
								text4 = text5;
							}
							streamWriter.Flush();
							stream.Position = 0L;
							method_3(stream, text4, string_2, encoding_0, string_);
							streamWriter.Close();
							break;
						}
						streamWriter.WriteLine(text8);
					}
					num4++;
					text8 = streamReader_0.ReadLine();
				}
			}
			num++;
			if (flag2)
			{
				streamWriter.Flush();
				stream.Position = 0L;
				method_3(stream, text4, string_2, encoding_0, string_);
				streamWriter.Close();
			}
		}
		return hashtable_0;
	}

	private void method_3(Stream stream_0, string string_0, string string_1, Encoding encoding_0, string string_2)
	{
		string key;
		if ((key = string_1) == null)
		{
			return;
		}
		if (Class1742.dictionary_3 == null)
		{
			Class1742.dictionary_3 = new Dictionary<string, int>(6)
			{
				{ "7bit", 0 },
				{ "8bit", 1 },
				{ "binary", 2 },
				{ "quoted-printable", 3 },
				{ "base64", 4 },
				{ "x-encodingname", 5 }
			};
		}
		if (Class1742.dictionary_3.TryGetValue(key, out var value))
		{
			switch (value)
			{
			case 3:
			{
				Stream value2 = Class430.smethod_1(stream_0, encoding_0);
				hashtable_0.Add(string_0, value2);
				break;
			}
			case 4:
			{
				StreamReader streamReader = new StreamReader(stream_0, encoding_0);
				byte[] buffer = Convert.FromBase64String(streamReader.ReadToEnd());
				Class438 @class = new Class438();
				@class.stream_0 = new MemoryStream(buffer);
				@class.string_0 = string_2;
				hashtable_0.Add(string_0, @class);
				break;
			}
			case 0:
			case 1:
			case 2:
			case 5:
				break;
			}
		}
	}
}
