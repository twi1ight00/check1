using System;
using System.Collections.Generic;
using System.Text;
using ns45;

namespace ns71;

internal class Class3526
{
	private readonly Class3520 class3520_0;

	private readonly Class3482 class3482_0;

	private string string_0;

	public string SourceCode
	{
		get
		{
			return string_0;
		}
		set
		{
			string_0 = value;
		}
	}

	public Class3482 Module => class3482_0;

	public Class3520 DirStream => class3520_0;

	public Class3526(Class3482 module, Class3520 dirStream)
	{
		if (module == null)
		{
			throw new ArgumentNullException();
		}
		if (dirStream == null)
		{
			throw new ArgumentNullException();
		}
		class3482_0 = module;
		class3520_0 = dirStream;
	}

	public Class3526(Class1106 stream, Class3482 module, Class3520 dirStream)
	{
		if (stream == null)
		{
			throw new ArgumentNullException();
		}
		if (module == null)
		{
			throw new ArgumentNullException();
		}
		if (dirStream == null)
		{
			throw new ArgumentNullException();
		}
		class3482_0 = module;
		class3520_0 = dirStream;
		byte[] data = stream.method_8();
		method_1(data);
	}

	public void method_0(Class1106 stream)
	{
		Encoding encoding = Encoding.GetEncoding(class3520_0.ProjectInformation.ProjectCodePage.CodePage);
		List<byte> list = new List<byte>(encoding.GetBytes(string_0));
		list.Add(0);
		byte[] d = Class3517.smethod_1(list.ToArray());
		stream.method_1(d);
	}

	private void method_1(byte[] data)
	{
		byte[] array = new byte[data.Length - class3482_0.Offset.Offset];
		Buffer.BlockCopy(data, (int)class3482_0.Offset.Offset, array, 0, array.Length);
		byte[] byteArray = Class3517.smethod_0(array);
		string_0 = Class3524.smethod_1(byteArray, class3520_0.ProjectInformation.ProjectCodePage.CodePage);
	}
}
