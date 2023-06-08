using System.IO;
using System.Text;
using Aspose.Cells;

namespace ns8;

internal class Class776
{
	private IStreamProvider istreamProvider_0;

	public Class776(IStreamProvider istreamProvider_1)
	{
		istreamProvider_0 = istreamProvider_1;
	}

	public void method_0(string string_0, Workbook workbook_0, LoadOptions loadOptions_0)
	{
		Class730 @class = null;
		if (loadOptions_0 != null && loadOptions_0 is HTMLLoadOptions)
		{
			workbook_0.Settings.Encoding = ((HTMLLoadOptions)loadOptions_0).Encoding;
			@class = new Class730(string_0, workbook_0, (HTMLLoadOptions)loadOptions_0, Encoding.UTF8);
		}
		else
		{
			string text = method_3(string_0);
			@class = ((text != null) ? new Class730(string_0, workbook_0, Encoding.GetEncoding(text)) : new Class730(string_0, workbook_0, workbook_0.Settings.Encoding));
		}
		@class.method_12(istreamProvider_0);
		@class.method_15();
		@class.method_8().Close();
		@class.method_19().method_34().Clear();
		if (method_2(@class))
		{
			@class.method_13(@class.method_19(), workbook_0, workbook_0.Settings.Encoding);
		}
	}

	public void method_1(Stream stream_0, Workbook workbook_0, LoadOptions loadOptions_0)
	{
		try
		{
			Class730 @class = null;
			if (loadOptions_0 != null && loadOptions_0 is HTMLLoadOptions)
			{
				workbook_0.Settings.Encoding = ((HTMLLoadOptions)loadOptions_0).Encoding;
				@class = new Class730(stream_0, workbook_0, (HTMLLoadOptions)loadOptions_0, Encoding.UTF8);
			}
			else
			{
				string text = method_4(stream_0);
				@class = ((text != null) ? new Class730(stream_0, workbook_0, new HTMLLoadOptions(), Encoding.GetEncoding(text)) : new Class730(stream_0, workbook_0, new HTMLLoadOptions(), Encoding.UTF8));
			}
			@class.method_12(istreamProvider_0);
			@class.method_15();
			@class.method_19().method_34().Clear();
			if (method_2(@class))
			{
				@class.method_13(@class.method_19(), workbook_0, workbook_0.Settings.Encoding);
			}
		}
		finally
		{
			stream_0?.Close();
		}
	}

	private bool method_2(Class730 class730_0)
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

	private string method_3(string string_0)
	{
		FileStream stream_ = File.Open(string_0, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
		return method_4(stream_);
	}

	private string method_4(Stream stream_0)
	{
		StreamReader streamReader = new StreamReader(stream_0);
		string result = null;
		int num = 0;
		string text = null;
		while ((text = streamReader.ReadLine()) != null && num <= 5)
		{
			int num2 = text.IndexOf("charset");
			if (!text.Trim().StartsWith("<meta") || num2 <= -1)
			{
				num++;
				continue;
			}
			string text2 = text.Substring(num2, text.Length - num2 - 1);
			result = text2.Trim().Substring(text2.IndexOf("=") + 1);
			result = result.Replace("\"", "");
			break;
		}
		stream_0.Position = 0L;
		return result;
	}
}
