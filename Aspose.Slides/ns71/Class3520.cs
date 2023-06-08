using System;
using System.IO;
using ns45;

namespace ns71;

internal class Class3520
{
	private Class3511 class3511_0;

	private Class3512 class3512_0;

	private Class3503 class3503_0;

	public Class3511 ProjectInformation => class3511_0;

	public Class3512 ProjectReferences => class3512_0;

	public Class3503 ProjectModules => class3503_0;

	internal Class3520(ushort codePage, string projectName)
	{
		class3511_0 = new Class3511(codePage, projectName);
		class3512_0 = new Class3512(codePage);
		class3503_0 = new Class3503(codePage);
	}

	internal Class3520(Class1106 stream)
	{
		if (stream == null)
		{
			throw new ArgumentNullException();
		}
		class3511_0 = new Class3511();
		using MemoryStream input = new MemoryStream(Class3517.smethod_0(stream.method_8()));
		using BinaryReader reader = new BinaryReader(input);
		method_3(reader);
	}

	internal void method_0(Class1106 stream)
	{
		using MemoryStream memoryStream = new MemoryStream();
		using BinaryWriter writer = new BinaryWriter(memoryStream);
		method_4(writer);
		stream.method_1(Class3517.smethod_1(memoryStream.ToArray()));
	}

	internal Class3482 AddEmptyModule(string name)
	{
		Class3482 @class = new Class3482(class3511_0.ProjectCodePage.CodePage, name);
		class3503_0.Modules.Add(@class);
		return @class;
	}

	internal void method_1(Class3513 reference)
	{
		class3512_0.References.Add(reference);
	}

	internal void method_2(string name)
	{
		class3503_0.method_0(name);
	}

	private void method_3(BinaryReader reader)
	{
		class3511_0.vmethod_0(reader);
		class3512_0 = new Class3512(class3511_0.ProjectCodePage.CodePage);
		class3512_0.vmethod_0(reader);
		class3503_0 = new Class3503(class3511_0.ProjectCodePage.CodePage);
		class3503_0.vmethod_0(reader);
		ushort num = reader.ReadUInt16();
		if (num != 16)
		{
			throw new Exception10();
		}
		if (reader.ReadUInt32() != 0)
		{
			throw new Exception10();
		}
	}

	private void method_4(BinaryWriter writer)
	{
		class3511_0.vmethod_1(writer);
		class3512_0.vmethod_1(writer);
		class3503_0.vmethod_1(writer);
		writer.Write((ushort)16);
		writer.Write(0u);
	}
}
