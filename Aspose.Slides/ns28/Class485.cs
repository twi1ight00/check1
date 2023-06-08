using System.IO;
using Aspose.Slides.Export;
using Aspose.Slides.Odp;
using ns276;

namespace ns28;

internal class Class485
{
	private const string string_0 = ".odp";

	private Class476 class476_0;

	private Class465 class465_0;

	private string string_1 = ".odp";

	internal string FileExtension
	{
		get
		{
			return string_1;
		}
		set
		{
			string text = ".";
			if (value.StartsWith(text))
			{
				string_1 = value;
			}
			else
			{
				string_1 = text + value;
			}
		}
	}

	public Class485(Stream stream)
	{
		class476_0 = new Class476(stream);
	}

	public Class485(string file)
	{
		Stream stream = null;
		try
		{
			stream = new FileStream(file, FileMode.Open, FileAccess.Read, FileShare.Read);
			ReadPresentation(new Class476(stream));
		}
		finally
		{
			stream?.Close();
		}
	}

	internal void ReadPresentation(Class476 package)
	{
		class476_0 = package;
		class465_0 = package.class465_0;
	}

	public void Save(Stream stream, SaveFormat format)
	{
		Save(stream, format, null);
	}

	public void Save(string fname, SaveFormat format)
	{
		using FileStream stream = new FileStream(fname, FileMode.Create, FileAccess.Write);
		Save(stream, format, null);
	}

	public void Save(string fname, SaveFormat format, SaveOptions options)
	{
		using FileStream stream = new FileStream(fname, FileMode.Create, FileAccess.Write);
		Save(stream, format, options);
	}

	public void Save(Stream stream, SaveFormat format, SaveOptions options)
	{
		if (format != SaveFormat.Pptx)
		{
			throw new OdpException("This export format is not implemented for ODP yet.");
		}
		Write(stream);
	}

	public void Write(Stream stream)
	{
		method_1(stream);
		using Class6752 @class = new Class6752();
		method_0(new Class481(@class));
		@class.Save(stream);
	}

	internal void method_0(Class481 context)
	{
		context.bool_0 = true;
	}

	private void method_1(Stream stream)
	{
		if (stream is FileStream)
		{
			FileStream fileStream = (FileStream)stream;
			FileExtension = Path.GetExtension(fileStream.Name).ToLower();
		}
	}
}
