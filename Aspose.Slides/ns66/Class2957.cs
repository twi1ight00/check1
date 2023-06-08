using System;
using System.IO;
using ns234;
using ns45;

namespace ns66;

internal class Class2957
{
	private const string string_0 = "\u0001Ole";

	private Class2962 class2962_0;

	public Class2962 OleStream
	{
		get
		{
			return class2962_0;
		}
		set
		{
			class2962_0 = value;
		}
	}

	public Class2957()
	{
		OleStream = new Class2962();
	}

	public Class2957(byte[] data)
	{
		if (data == null)
		{
			throw new ArgumentNullException("data");
		}
		using MemoryStream stream = new MemoryStream(data);
		Read(stream);
	}

	public Class2957(byte[] data, int uncompressedLength)
	{
		if (data == null)
		{
			throw new ArgumentNullException();
		}
		byte[] buffer = Class6171.smethod_0(data, uncompressedLength, Enum794.const_1);
		using MemoryStream stream = new MemoryStream(buffer);
		Read(stream);
	}

	public void Read(Stream stream)
	{
		Class1110 @class = new Class1110(stream);
		Class1106 class2 = (Class1106)@class.RootFolder.method_2("\u0001Ole");
		if (class2 == null)
		{
			return;
		}
		using MemoryStream input = new MemoryStream(class2.method_7());
		using BinaryReader reader = new BinaryReader(input);
		class2962_0 = new Class2962(reader);
	}

	public void Write(Stream stream)
	{
		Class1110 @class = new Class1110();
		if (OleStream != null)
		{
			using MemoryStream memoryStream = new MemoryStream();
			using (BinaryWriter writer = new BinaryWriter(memoryStream))
			{
				OleStream.Write(writer);
			}
			memoryStream.Flush();
			Class1106 class2 = new Class1106("\u0001Ole");
			class2.method_1(memoryStream.ToArray());
			@class.RootFolder.Add(class2);
		}
		@class.Write(stream);
	}
}
