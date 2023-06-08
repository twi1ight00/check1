using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using ns1;

namespace ns8;

internal class Class434
{
	private Class1487 class1487_0;

	private ArrayList arrayList_0 = new ArrayList();

	public Class434(Stream stream_0, Encoding encoding_0)
	{
		class1487_0 = new Class1487(stream_0, encoding_0);
	}

	public Class1487 method_0(string string_0)
	{
		class1487_0.Write("MIME-Version: 1.0");
		class1487_0.method_8("X-Document-Type: Workbook");
		class1487_0.method_8("Content-Type: multipart/related; boundary=\"" + string_0 + "\"");
		class1487_0.method_9();
		class1487_0.method_8("This document is a Single File Web Page, also known as a Web Archive file.  If you are seeing this message, your browser or editor doesn't support Web Archive files.  Please download a browser that supports Web Archive, such as Windows Internet Explorer.");
		class1487_0.method_9();
		class1487_0.Flush();
		return class1487_0;
	}

	public Class1487 method_1(string string_0, bool bool_0)
	{
		try
		{
			class1487_0.method_9();
			class1487_0.method_8(string_0 + "--");
			class1487_0.Flush();
		}
		finally
		{
			if (class1487_0 != null && bool_0)
			{
				class1487_0.Close();
			}
		}
		return class1487_0;
	}

	public void method_2(Stream stream_0, Stream stream_1, Encoding encoding_0, string string_0)
	{
		StreamWriter streamWriter = null;
		string text = "Content-Location";
		string text2 = "Content-Transfer-Encoding";
		string text3 = "Content-Type";
		try
		{
			ArrayList arrayList = method_4(stream_1, encoding_0);
			streamWriter = new StreamWriter(stream_0, encoding_0);
			streamWriter.WriteLine("MIME-Version: 1.0");
			streamWriter.WriteLine("X-Document-Type: Workbook");
			streamWriter.WriteLine("Content-Type: multipart/related; boundary=\"" + string_0.Substring(2) + "\"");
			streamWriter.WriteLine();
			streamWriter.WriteLine("This document is a Single File Web Page, also known as a Web Archive file.  If you are seeing this message, your browser or editor doesn't support Web Archive files.  Please download a browser that supports Web Archive, such as Windows Internet Explorer.");
			streamWriter.WriteLine();
			streamWriter.Flush();
			MemoryStream memoryStream = null;
			int num;
			for (num = 0; num < arrayList.Count; num++)
			{
				Hashtable hashtable = (Hashtable)arrayList[num];
				streamWriter.WriteLine(string_0);
				streamWriter.WriteLine(text + ":" + hashtable[text]);
				streamWriter.WriteLine(text2 + ":" + hashtable[text2]);
				streamWriter.WriteLine(text3 + ":" + hashtable[text3]);
				streamWriter.WriteLine();
				streamWriter.Flush();
				num++;
				memoryStream = (MemoryStream)arrayList[num];
				streamWriter.BaseStream.Write(memoryStream.GetBuffer(), 0, (int)memoryStream.Length);
				streamWriter.Flush();
				memoryStream.Close();
			}
			streamWriter.WriteLine(string_0 + "--");
			streamWriter.Flush();
			stream_0.Position = 0L;
		}
		catch
		{
		}
	}

	public void method_3(string string_0, Stream stream_0, Encoding encoding_0, string string_1)
	{
		StreamWriter streamWriter = null;
		string text = "Content-Location";
		string text2 = "Content-Transfer-Encoding";
		string text3 = "Content-Type";
		try
		{
			ArrayList arrayList = method_4(stream_0, encoding_0);
			Directory.CreateDirectory(Path.GetDirectoryName(string_0));
			FileStream stream = new FileStream(string_0, FileMode.Create);
			streamWriter = new StreamWriter(stream, encoding_0);
			streamWriter.WriteLine("MIME-Version: 1.0");
			streamWriter.WriteLine("X-Document-Type: Workbook");
			streamWriter.WriteLine("Content-Type: multipart/related; boundary=\"" + string_1.Substring(2) + "\"");
			streamWriter.WriteLine();
			streamWriter.WriteLine("This document is a Single File Web Page, also known as a Web Archive file.  If you are seeing this message, your browser or editor doesn't support Web Archive files.  Please download a browser that supports Web Archive, such as Windows Internet Explorer.");
			streamWriter.WriteLine();
			streamWriter.Flush();
			MemoryStream memoryStream = null;
			int num;
			for (num = 0; num < arrayList.Count; num++)
			{
				Hashtable hashtable = (Hashtable)arrayList[num];
				streamWriter.WriteLine(string_1);
				streamWriter.WriteLine(text + ":" + hashtable[text]);
				streamWriter.WriteLine(text2 + ":" + hashtable[text2]);
				streamWriter.WriteLine(text3 + ":" + hashtable[text3]);
				streamWriter.WriteLine();
				streamWriter.Flush();
				num++;
				memoryStream = (MemoryStream)arrayList[num];
				streamWriter.BaseStream.Write(memoryStream.GetBuffer(), 0, (int)memoryStream.Length);
				streamWriter.Flush();
				memoryStream.Close();
			}
			streamWriter.WriteLine(string_1 + "--");
			streamWriter.Flush();
		}
		finally
		{
			streamWriter?.Close();
		}
	}

	private ArrayList method_4(Stream stream_0, Encoding encoding_0)
	{
		StreamReader streamReader = new StreamReader(stream_0, encoding_0);
		string text = "Content-Location";
		string text2 = "Content-Transfer-Encoding";
		string text3 = "Content-Type";
		string text4 = "boundary=";
		int num = 0;
		string text5 = null;
		bool flag = false;
		Stream stream = null;
		StreamWriter streamWriter = null;
		bool flag2 = false;
		string text6 = null;
		string text7 = null;
		string text8 = null;
		Hashtable hashtable = null;
		try
		{
			string text9;
			while ((text9 = streamReader.ReadLine()) != null)
			{
				if (num == 2)
				{
					if (text9.IndexOf(text4) > -1)
					{
						text5 = text9.Substring(text9.IndexOf(text4) + text4.Length);
						if (text5.StartsWith("\"") && text5.StartsWith("\""))
						{
							text5 = text5.Substring(1, text5.Length - 2);
						}
					}
					else
					{
						flag2 = (flag = true);
					}
				}
				if (Class436.smethod_0(text9, text5))
				{
					flag = true;
				}
				if (flag)
				{
					int num2 = 0;
					string text10 = text9;
					stream = new MemoryStream();
					streamWriter = new StreamWriter(stream);
					text6 = null;
					text7 = null;
					text8 = null;
					hashtable = new Hashtable();
					while (text10 != null)
					{
						if (text10.StartsWith(text))
						{
							text6 = Class436.smethod_1(text10);
							hashtable.Add(text, text6);
						}
						if (text10.StartsWith(text2))
						{
							text7 = Class436.smethod_1(text10);
							hashtable.Add(text2, text7);
						}
						if (text10.StartsWith(text3))
						{
							text8 = Class436.smethod_1(text10);
							hashtable.Add(text3, text8);
						}
						if (num2 > 3)
						{
							if (Class436.smethod_0(text10, text5))
							{
								streamWriter.Flush();
								stream.Position = 0L;
								method_5(stream, hashtable, text7, encoding_0);
								if (text7 == "quoted-printable")
								{
									streamWriter.Close();
								}
								break;
							}
							streamWriter.WriteLine(text10);
						}
						num2++;
						text10 = streamReader.ReadLine();
					}
				}
				num++;
				if (flag2)
				{
					streamWriter.Flush();
					stream.Position = 0L;
					method_5(stream, hashtable, text7, encoding_0);
					streamWriter.Close();
				}
			}
		}
		catch
		{
		}
		finally
		{
			streamReader?.Close();
		}
		return arrayList_0;
	}

	private void method_5(Stream stream_0, Hashtable hashtable_0, string string_0, Encoding encoding_0)
	{
		string key;
		if ((key = string_0) == null)
		{
			return;
		}
		if (Class1742.dictionary_2 == null)
		{
			Class1742.dictionary_2 = new Dictionary<string, int>(6)
			{
				{ "7bit", 0 },
				{ "8bit", 1 },
				{ "binary", 2 },
				{ "quoted-printable", 3 },
				{ "base64", 4 },
				{ "x-encodingname", 5 }
			};
		}
		if (Class1742.dictionary_2.TryGetValue(key, out var value))
		{
			switch (value)
			{
			case 3:
			{
				Stream value2 = Class430.smethod_0(stream_0, encoding_0);
				arrayList_0.Add(hashtable_0);
				arrayList_0.Add(value2);
				break;
			}
			case 4:
				arrayList_0.Add(hashtable_0);
				arrayList_0.Add(stream_0);
				break;
			case 0:
			case 1:
			case 2:
			case 5:
				break;
			}
		}
	}
}
