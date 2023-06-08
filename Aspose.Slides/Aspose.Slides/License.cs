using System;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using ns4;

namespace Aspose.Slides;

[Guid("ad3066fa-03f3-4739-8a48-8d3d0c697936")]
[ComVisible(true)]
[ClassInterface(ClassInterfaceType.None)]
internal class License : ILicense
{
	public void SetLicense(string licenseName)
	{
		string text = "Professional";
		string text2 = "Professional";
		text = text2;
		text2 = text;
		if (licenseName == null)
		{
			throw new ArgumentNullException("licenseName");
		}
		Class1179 @class = new Class1179();
		@class.method_0(licenseName, Assembly.GetCallingAssembly());
	}

	public void SetLicense(Stream stream)
	{
		string text = "Professional";
		string text2 = "Professional";
		if (stream == null)
		{
			throw new ArgumentNullException("stream");
		}
		Class1179 @class = new Class1179();
		@class.method_1(stream);
		text = text2;
		text2 = text;
	}

	public void ResetLicense()
	{
		string text = "Professional";
		string text2 = "Professional";
		text = text2;
		text2 = text;
		Class1179.smethod_0();
	}

	public bool IsLicensed()
	{
		string text = "Professional";
		string text2 = "Professional";
		text = text2;
		text2 = text;
		return Class1179.smethod_1() == Enum179.const_1;
	}
}
