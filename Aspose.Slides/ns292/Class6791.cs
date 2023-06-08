using System.IO;
using ns298;
using ns301;

namespace ns292;

internal class Class6791 : Interface326
{
	private readonly string string_0;

	private readonly Class6794 class6794_0;

	public Class6791(string outputFileName)
	{
		Class6892.smethod_0(outputFileName, "outputFileName");
		string_0 = outputFileName;
		class6794_0 = new Class6794(string_0);
	}

	public Class6794 imethod_0()
	{
		return (Class6794)class6794_0.Clone();
	}

	public string imethod_1(byte[] data, Enum922 imageType, string suggestedFileName)
	{
		string path = class6794_0.method_2(suggestedFileName);
		Class6872.smethod_4(path);
		using (FileStream fileStream = new FileStream(path, FileMode.Create, FileAccess.Write))
		{
			fileStream.Write(data, 0, data.Length);
		}
		return class6794_0.method_5(suggestedFileName);
	}

	public string imethod_2(byte[] data, Enum922 imageType, string suggestedFileName)
	{
		return Path.GetFileName(imethod_1(data, imageType, suggestedFileName));
	}

	public bool imethod_3(string uniqueFontId, ref string uri)
	{
		return false;
	}

	public void imethod_4(string uniqueFontId, string uri)
	{
	}

	public string imethod_5(Stream fontData, string suggestedFileName)
	{
		smethod_0(fontData, class6794_0.method_2(suggestedFileName));
		return suggestedFileName;
	}

	public void imethod_6(Stream data, string fileName)
	{
		smethod_0(data, class6794_0.method_2(fileName));
	}

	public string imethod_7(int pageNumber, int partNumber)
	{
		return $"style{pageNumber}p{partNumber}.css";
	}

	public string imethod_8(Stream data, string suggestedFileName)
	{
		smethod_0(data, Path.Combine(class6794_0.BundleRoot, suggestedFileName));
		return suggestedFileName;
	}

	public string imethod_9()
	{
		return null;
	}

	private static void smethod_0(Stream data, string fileName)
	{
		Class6872.smethod_4(fileName);
		using FileStream fileStream = new FileStream(fileName, FileMode.Create, FileAccess.Write);
		byte[] array = new byte[1024];
		int count;
		while ((count = data.Read(array, 0, array.Length)) > 0)
		{
			fileStream.Write(array, 0, count);
		}
	}
}
