using System;
using System.IO;
using System.Runtime.CompilerServices;
using ns59;

namespace ns63;

internal class Class2687 : Class2639, Interface44
{
	internal const int int_0 = 12052;

	private Class2617 class2617_0;

	[CompilerGenerated]
	private uint uint_0;

	public Class2617 EncryptionHeader => class2617_0;

	public uint PersistId
	{
		[CompilerGenerated]
		get
		{
			return uint_0;
		}
		[CompilerGenerated]
		set
		{
			uint_0 = value;
		}
	}

	internal Class2687()
	{
		base.Header.Type = 12052;
	}

	public Class2687(string password)
	{
		base.Header.Type = 12052;
		base.Header.Instance = 0;
		base.Header.Version = 15;
		class2617_0 = new Class2617(password);
	}

	public static Class2687 smethod_2(Stream stream)
	{
		return (Class2687)Class2950.smethod_1(new BinaryReader(stream), null);
	}

	protected override void vmethod_0(BinaryReader reader)
	{
		class2617_0 = Class2617.smethod_0(reader.BaseStream);
	}

	public override void vmethod_1(BinaryWriter writer)
	{
		class2617_0.method_1(writer);
	}

	public override int vmethod_2()
	{
		throw new NotImplementedException();
	}
}
