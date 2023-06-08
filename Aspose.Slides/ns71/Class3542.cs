using System;
using System.Collections.Generic;
using System.IO;
using ns4;
using ns45;

namespace ns71;

internal sealed class Class3542
{
	internal const string string_0 = "VBA";

	internal const string string_1 = "PROJECT";

	internal const string string_2 = "PROJECTlk";

	internal const string string_3 = "PROJECTwm";

	private Class3544 class3544_0;

	private Dictionary<string, Class3519> dictionary_0 = new Dictionary<string, Class3519>();

	private Class1106 class1106_0;

	private Class3540 class3540_0;

	private Class3539 class3539_0;

	public Class3544 VbaStorage
	{
		get
		{
			return class3544_0;
		}
		set
		{
			class3544_0 = value;
		}
	}

	public Class3539 ProjectStream
	{
		get
		{
			return class3539_0;
		}
		set
		{
			class3539_0 = value;
		}
	}

	public Dictionary<string, Class3519> DesignerStorages
	{
		get
		{
			return dictionary_0;
		}
		set
		{
			dictionary_0 = value;
		}
	}

	public Class3542(ushort codePage, string projectName)
	{
		class3544_0 = new Class3544(codePage, projectName);
		class3540_0 = new Class3540(codePage);
		class3539_0 = new Class3539(codePage, projectName);
	}

	public Class3542(byte[] data)
	{
		using MemoryStream inputStream = new MemoryStream(data);
		Class1110 fileSystem = smethod_0(inputStream);
		method_3(fileSystem);
	}

	public Class3542(Class1110 fileSystem)
	{
		method_3(fileSystem);
	}

	public void method_0(Stream stream)
	{
		Class1110 @class = new Class1110();
		method_5(@class);
		method_7(@class);
		method_9(@class);
		method_11(@class);
		method_13(@class);
		@class.Write(stream);
	}

	public byte[] ToBinary()
	{
		using MemoryStream memoryStream = new MemoryStream();
		method_0(memoryStream);
		return memoryStream.ToArray();
	}

	public Class3526 AddEmptyModule(string name)
	{
		Class3526 result = class3544_0.AddEmptyModule(name);
		class3539_0.ProjectInformation.method_3(name);
		class3540_0.method_1(name);
		return result;
	}

	public void method_1(string name, string libid)
	{
		class3544_0.method_2(name, libid);
	}

	public void method_2(string name)
	{
		class3544_0.method_1(name);
		class3539_0.ProjectInformation.method_4(name);
		class3540_0.method_2(name);
	}

	private void method_3(Class1110 fileSystem)
	{
		method_4(fileSystem);
		method_6(fileSystem);
		method_8(fileSystem);
		method_10(fileSystem);
		method_12(fileSystem);
	}

	private static Class1110 smethod_0(Stream inputStream)
	{
		try
		{
			return new Class1110(inputStream);
		}
		catch (Exception1 exception)
		{
			throw new Exception10("Can't read VBA project", exception);
		}
		catch (Exception exception2)
		{
			throw new Exception10("Can't read VBA project.", exception2);
		}
	}

	private void method_4(Class1110 fileSystem)
	{
		if (!(fileSystem.RootFolder.method_2("VBA") is Class1107 vbaStorage))
		{
			throw new Exception10("Can't read VBA project");
		}
		class3544_0 = new Class3544(vbaStorage);
	}

	private void method_5(Class1110 fileSystem)
	{
		Class1107 @class = new Class1107("VBA");
		class3544_0.method_0(@class);
		fileSystem.RootFolder.Add(@class);
	}

	private void method_6(Class1110 fileSystem)
	{
		foreach (Class3482 module in class3544_0.DirStream.ProjectModules.Modules)
		{
			if (module.Type.Id == 34 && fileSystem.RootFolder.method_2(module.StreamName.StreamName) is Class1107 storage)
			{
				Class3519 value = new Class3519(storage, class3544_0.DirStream.ProjectInformation.ProjectCodePage.CodePage);
				dictionary_0.Add(module.StreamName.StreamName, value);
			}
		}
	}

	private void method_7(Class1110 fileSystem)
	{
		foreach (KeyValuePair<string, Class3519> item in dictionary_0)
		{
			item.Value.method_0(fileSystem.RootFolder);
		}
	}

	private void method_8(Class1110 fileSystem)
	{
		if (fileSystem.RootFolder.method_2("PROJECT") == null)
		{
			throw new Exception10("Can't read VBA project");
		}
		Class1106 stream = fileSystem.RootFolder.method_2("PROJECT") as Class1106;
		class3539_0 = new Class3539(stream, class3544_0.DirStream.ProjectInformation.ProjectCodePage.CodePage);
	}

	private void method_9(Class1110 fileSystem)
	{
		Class1106 @class = new Class1106("PROJECT");
		class3539_0.method_0(@class);
		fileSystem.RootFolder.Add(@class);
	}

	private void method_10(Class1110 fileSystem)
	{
		class1106_0 = fileSystem.RootFolder.method_2("PROJECTlk") as Class1106;
	}

	private void method_11(Class1110 fileSystem)
	{
		if (class1106_0 != null)
		{
			fileSystem.RootFolder.Add(class1106_0);
		}
	}

	private void method_12(Class1110 fileSystem)
	{
		if (fileSystem.RootFolder.method_2("PROJECTwm") is Class1106 stream)
		{
			class3540_0 = new Class3540(stream, class3544_0.DirStream.ProjectInformation.ProjectCodePage.CodePage);
		}
	}

	private void method_13(Class1110 fileSystem)
	{
		if (class3540_0 != null)
		{
			Class1106 @class = new Class1106("PROJECTwm");
			class3540_0.method_0(@class);
			fileSystem.RootFolder.Add(@class);
		}
	}
}
