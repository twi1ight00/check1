using System;
using System.IO;

namespace ns61;

internal sealed class Class2960
{
	private Class2958 class2958_0;

	public Guid MonikerClsid => class2958_0.MonikerClsid;

	public Class2958 Data
	{
		get
		{
			return class2958_0;
		}
		set
		{
			class2958_0 = value;
		}
	}

	public Class2960(Class2958 moniker)
	{
		if (moniker == null)
		{
			throw new ArgumentNullException("moniker");
		}
		class2958_0 = moniker;
	}

	public Class2960(BinaryReader reader)
	{
		Read(reader);
	}

	public uint method_0()
	{
		return 16 + class2958_0.vmethod_0();
	}

	public void Read(BinaryReader reader)
	{
		Guid monikerClsid = new Guid(reader.ReadBytes(16));
		class2958_0 = Class2963.smethod_1(monikerClsid, reader);
	}

	public void Write(BinaryWriter writer)
	{
		byte[] buffer = MonikerClsid.ToByteArray();
		writer.Write(buffer);
		class2958_0.Write(writer);
	}
}
