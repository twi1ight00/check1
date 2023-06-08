using System;
using System.Collections.Generic;
using ns45;

namespace ns71;

internal class Class3544
{
	internal const string string_0 = "_VBA_PROJECT";

	internal const string string_1 = "dir";

	private Class3543 class3543_0;

	private Class3520 class3520_0;

	private Dictionary<string, Class3526> dictionary_0 = new Dictionary<string, Class3526>();

	public Class3520 DirStream => class3520_0;

	public Dictionary<string, Class3526> Modules => dictionary_0;

	internal Class3544(ushort codePage, string projectName)
	{
		class3543_0 = new Class3543();
		class3520_0 = new Class3520(codePage, projectName);
	}

	internal Class3544(Class1107 vbaStorage)
	{
		if (vbaStorage == null)
		{
			throw new ArgumentNullException();
		}
		if (vbaStorage.EntryName != "VBA")
		{
			throw new InvalidOperationException();
		}
		method_4(vbaStorage);
		method_6(vbaStorage);
		method_8(vbaStorage);
	}

	internal void method_0(Class1107 vbaStorage)
	{
		method_5(vbaStorage);
		method_7(vbaStorage);
		method_9(vbaStorage);
	}

	internal Class3526 AddEmptyModule(string name)
	{
		if (dictionary_0.ContainsKey(name))
		{
			throw new ArgumentException($"Module with name {name} already exists");
		}
		Class3482 module = class3520_0.AddEmptyModule(name);
		return method_3(module);
	}

	internal void method_1(string name)
	{
		if (!dictionary_0.ContainsKey(name))
		{
			throw new ArgumentException($"Module with name {name} is not exists");
		}
		class3520_0.method_2(name);
		dictionary_0.Remove(name);
	}

	internal void method_2(string name, string libid)
	{
		int codePage = class3520_0.ProjectInformation.ProjectCodePage.CodePage;
		Class3513 @class = new Class3513(codePage);
		@class.ReferenceName = new Class3507(codePage, name);
		@class.ReferenceRecord = new Class3510(codePage, libid);
		class3520_0.method_1(@class);
	}

	private Class3526 method_3(Class3482 module)
	{
		Class3526 @class = new Class3526(module, class3520_0);
		dictionary_0.Add(module.StreamName.StreamName, @class);
		return @class;
	}

	private void method_4(Class1107 vbaStorage)
	{
		if (!(vbaStorage.method_2("_VBA_PROJECT") is Class1106 stream))
		{
			throw new Exception10("Can't read VBA project");
		}
		class3543_0 = new Class3543(stream);
	}

	private void method_5(Class1107 vbaStorage)
	{
		Class1106 @class = new Class1106("_VBA_PROJECT");
		class3543_0.method_1(@class);
		vbaStorage.Add(@class);
	}

	private void method_6(Class1107 vbaStorage)
	{
		if (!(vbaStorage.method_2("dir") is Class1106 stream))
		{
			throw new Exception10("Can't read VBA project");
		}
		class3520_0 = new Class3520(stream);
	}

	private void method_7(Class1107 vbaStorage)
	{
		Class1106 @class = new Class1106("dir");
		class3520_0.method_0(@class);
		vbaStorage.Add(@class);
	}

	private void method_8(Class1107 vbaStorage)
	{
		foreach (Class3482 module in class3520_0.ProjectModules.Modules)
		{
			if (vbaStorage.method_2(module.StreamName.StreamName) is Class1106 stream)
			{
				Class3526 value = new Class3526(stream, module, class3520_0);
				dictionary_0.Add(module.StreamName.StreamName, value);
				continue;
			}
			throw new InvalidOperationException();
		}
	}

	private void method_9(Class1107 vbaStorage)
	{
		foreach (KeyValuePair<string, Class3526> item in dictionary_0)
		{
			Class1106 @class = new Class1106(item.Key);
			item.Value.method_0(@class);
			vbaStorage.Add(@class);
		}
	}
}
