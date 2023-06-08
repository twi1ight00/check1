using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using ns45;

namespace ns71;

internal class Class3540
{
	[CompilerGenerated]
	private sealed class Class3541
	{
		public string string_0;

		public bool method_0(Class3515 n)
		{
			return n.ModuleName == string_0;
		}
	}

	private readonly int int_0;

	private readonly List<Class3515> list_0 = new List<Class3515>();

	internal Class3540(int codePage)
	{
		int_0 = codePage;
	}

	internal Class3540(Class1106 stream, int codePage)
	{
		if (stream == null)
		{
			throw new ArgumentNullException();
		}
		int_0 = codePage;
		byte[] array = stream.method_8();
		using MemoryStream memoryStream = new MemoryStream(array);
		using BinaryReader binaryReader = new BinaryReader(memoryStream);
		while (memoryStream.Position < array.Length - 2)
		{
			Class3515 @class = new Class3515(int_0);
			@class.vmethod_0(binaryReader);
			list_0.Add(@class);
		}
		if (binaryReader.ReadUInt16() != 0)
		{
			throw new Exception10();
		}
	}

	internal void method_0(Class1106 stream)
	{
		using MemoryStream memoryStream = new MemoryStream();
		using BinaryWriter binaryWriter = new BinaryWriter(memoryStream);
		foreach (Class3515 item in list_0)
		{
			item.vmethod_1(binaryWriter);
		}
		binaryWriter.Write((ushort)0);
		stream.method_1(memoryStream.ToArray());
	}

	internal void method_1(string name)
	{
		Class3515 item = new Class3515(int_0, name);
		list_0.Add(item);
	}

	internal void method_2(string name)
	{
		Class3515 @class = list_0.Find((Class3515 n) => n.ModuleName == name);
		if (@class == null)
		{
			throw new ArgumentException($"NAMEMAP entry for module with name {name} is not exists");
		}
		list_0.Remove(@class);
	}
}
