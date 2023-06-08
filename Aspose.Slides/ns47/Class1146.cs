using System;
using System.IO;
using Aspose.Slides;
using ns33;

namespace ns47;

internal class Class1146
{
	private readonly ushort ushort_0 = 65534;

	private readonly ushort ushort_1;

	private readonly uint uint_0;

	private Guid guid_0;

	private uint uint_1;

	private Guid guid_1;

	private Guid guid_2;

	private Class1145 class1145_0;

	private Class1145 class1145_1;

	public static readonly Guid guid_3 = new Guid("F29F85E0-4FF9-1068-AB91-08002B27B3D9");

	public static readonly Guid guid_4 = new Guid("D5CDD502-2E9C-101B-9397-08002B2CF9AE");

	public uint PropertiesNumber
	{
		get
		{
			return uint_1;
		}
		set
		{
			uint_1 = value;
		}
	}

	public Class1145 PropertySet0
	{
		get
		{
			return class1145_0;
		}
		set
		{
			class1145_0 = value;
		}
	}

	public Class1145 PropertySet1
	{
		get
		{
			return class1145_1;
		}
		set
		{
			class1145_1 = value;
		}
	}

	public Class1146(Stream stream)
	{
		BinaryReader binaryReader = new BinaryReader(stream);
		ushort_0 = binaryReader.ReadUInt16();
		ushort_1 = binaryReader.ReadUInt16();
		uint_0 = binaryReader.ReadUInt32();
		guid_0 = new Guid(binaryReader.ReadBytes(16));
		uint_1 = binaryReader.ReadUInt32();
		guid_1 = new Guid(binaryReader.ReadBytes(16));
		uint offset = binaryReader.ReadUInt32();
		uint offset2 = 0u;
		if (uint_1 == 2)
		{
			guid_2 = new Guid(binaryReader.ReadBytes(16));
			offset2 = binaryReader.ReadUInt32();
		}
		class1145_0 = new Class1145(stream, offset, 0);
		if (uint_1 == 2)
		{
			try
			{
				class1145_1 = new Class1145(stream, offset2, 1);
			}
			catch (PptReadException ex)
			{
				Class1165.smethod_28(ex);
				class1145_1 = null;
				uint_1 = 1u;
			}
		}
	}

	public byte[] Write()
	{
		MemoryStream memoryStream = new MemoryStream();
		BinaryWriter binaryWriter = new BinaryWriter(memoryStream);
		binaryWriter.Write(ushort_0);
		binaryWriter.Write(ushort_1);
		binaryWriter.Write(uint_0);
		binaryWriter.Write(guid_0.ToByteArray());
		binaryWriter.Write(uint_1);
		binaryWriter.Write(guid_1.ToByteArray());
		uint num = (uint)((int)memoryStream.Position + 4);
		if (uint_1 == 2)
		{
			num += 20;
		}
		binaryWriter.Write(num);
		byte[] array = class1145_0.Write();
		if (uint_1 == 2)
		{
			binaryWriter.Write(guid_2.ToByteArray());
			num += (uint)array.Length;
			binaryWriter.Write(num);
		}
		binaryWriter.Write(array);
		if (uint_1 == 2)
		{
			binaryWriter.Write(class1145_1.Write());
		}
		binaryWriter.Close();
		return memoryStream.ToArray();
	}

	public static byte[] smethod_0(Guid streamGuid)
	{
		MemoryStream memoryStream = new MemoryStream();
		BinaryWriter binaryWriter = new BinaryWriter(memoryStream);
		binaryWriter.Write((ushort)65534);
		binaryWriter.Write((ushort)0);
		binaryWriter.Write(131334u);
		binaryWriter.Write(Guid.Empty.ToByteArray());
		binaryWriter.Write(1u);
		binaryWriter.Write(streamGuid.ToByteArray());
		binaryWriter.Write((uint)(memoryStream.Position + 4L));
		Class1145 @class = new Class1145();
		@class.Properties.RemoveAt(2);
		@class.Properties.RemoveAt(0);
		byte[] buffer = @class.Write();
		binaryWriter.Write(buffer);
		binaryWriter.Close();
		return memoryStream.ToArray();
	}

	public Class1145 method_0()
	{
		if (class1145_1 != null)
		{
			return class1145_1;
		}
		uint_1 = 2u;
		guid_2 = new Guid("{d5cdd505-2e9c-101b-9397-08002b2cf9ae}");
		class1145_1 = new Class1145();
		return class1145_1;
	}
}
