using System;
using System.IO;
using x13f1efc79617a47b;

namespace x1a62aaf14e3c5909;

internal class xfbb3f4be330f4086 : xddf6304144fd3863
{
	internal const int x269fd800b5fc7482 = 36;

	internal int xff0ea9d348c6d812;

	internal int x3df0b33d2192d410;

	internal byte[] x8601da8f676be405;

	internal int xffe521cc76054baf;

	internal int x0ceec69a97f73617;

	internal int xbbb4d81f327c96e5;

	internal uint x62ccf2f5b04cb08c;

	internal int x48bc09179b84e8f0;

	internal int x7e7568b9977b4f16;

	internal int xc83ed05f75257524;

	internal int xd83a450912bc2206;

	private xd959c7c7ca733332 x1e85e97d2d60083b;

	private bool x441235a6d7939cf2;

	internal bool xcb09944671f5a4fd
	{
		get
		{
			return x441235a6d7939cf2;
		}
		set
		{
			x441235a6d7939cf2 = value;
		}
	}

	internal xd959c7c7ca733332 x90c6e45466e5b849
	{
		get
		{
			return x1e85e97d2d60083b;
		}
		set
		{
			x1e85e97d2d60083b = value;
		}
	}

	internal xfbb3f4be330f4086()
		: base(x773fe540042dad03.x1a32cef9417f917a, 2)
	{
	}

	internal void x707eda0bf8f1735b(BinaryReader x44008b73fc5f9672)
	{
		if (x62ccf2f5b04cb08c != uint.MaxValue && xbbb4d81f327c96e5 != 0 && xff0ea9d348c6d812 != 0)
		{
			x44008b73fc5f9672.BaseStream.Position = x62ccf2f5b04cb08c;
			x1e85e97d2d60083b = xeb990b4cb5dd2e44.x2785b0923dba0723(x44008b73fc5f9672, base.xf69ca7a9bb4a4a51) as xd959c7c7ca733332;
		}
	}

	internal void xbf2311da8da339cb(BinaryWriter xc83188e30d5f47a5)
	{
		x62ccf2f5b04cb08c = (uint)xc83188e30d5f47a5.BaseStream.Position;
		x0ceec69a97f73617 = x1e85e97d2d60083b.x6210059f049f0d48(xc83188e30d5f47a5);
	}

	protected override void DoRead(BinaryReader reader)
	{
		int num = (int)(reader.BaseStream.Position + base.x1ea60bde2b5d0d28.x1be93eed8950d961);
		xdc351cc35a0b2cdb(reader);
		while (reader.BaseStream.Position < num)
		{
			x441235a6d7939cf2 = true;
			x1e85e97d2d60083b = (xd959c7c7ca733332)xeb990b4cb5dd2e44.x2785b0923dba0723(reader, base.xf69ca7a9bb4a4a51);
		}
	}

	protected override void DoWrite(BinaryWriter writer)
	{
		int num = (int)writer.BaseStream.Position;
		x054a4d37a44641dc(writer);
		if (x441235a6d7939cf2)
		{
			x0ceec69a97f73617 = x1e85e97d2d60083b.x6210059f049f0d48(writer);
			int num2 = (int)writer.BaseStream.Position;
			writer.BaseStream.Position = num;
			x054a4d37a44641dc(writer);
			writer.BaseStream.Position = num2;
		}
	}

	private void xdc351cc35a0b2cdb(BinaryReader xe134235b3526fa75)
	{
		xff0ea9d348c6d812 = xe134235b3526fa75.ReadByte();
		x3df0b33d2192d410 = xe134235b3526fa75.ReadByte();
		x8601da8f676be405 = xe134235b3526fa75.ReadBytes(16);
		xffe521cc76054baf = xe134235b3526fa75.ReadInt16();
		x0ceec69a97f73617 = xe134235b3526fa75.ReadInt32();
		xbbb4d81f327c96e5 = xe134235b3526fa75.ReadInt32();
		x62ccf2f5b04cb08c = xe134235b3526fa75.ReadUInt32();
		x48bc09179b84e8f0 = xe134235b3526fa75.ReadByte();
		x7e7568b9977b4f16 = xe134235b3526fa75.ReadByte();
		xc83ed05f75257524 = xe134235b3526fa75.ReadByte();
		xd83a450912bc2206 = xe134235b3526fa75.ReadByte();
		if (x7e7568b9977b4f16 > 0)
		{
			throw new InvalidOperationException(string.Intern(x1110bdd110cdcea4._xaacba899487bce8c("gihjmkojpkfkfkmkijdlbfklpibmleimkgpmbhgnlgnnpgeomdloajcpphjphiaaihhancoalgfbhcmbchdccgkclgbdagidibpdgfgeagnedfefmalfnfcgoejgmeahdfhhnpnhdefikemiepcjpdkjndbkpdikiookodglhcnlddemmnkmmccnlcjndcaoachomboombfplbmpjadafakammab", 430610240)));
		}
	}

	private void x054a4d37a44641dc(BinaryWriter xbdfb620b7167944b)
	{
		xbdfb620b7167944b.Write((byte)xff0ea9d348c6d812);
		xbdfb620b7167944b.Write((byte)x3df0b33d2192d410);
		xbdfb620b7167944b.Write(x8601da8f676be405);
		xbdfb620b7167944b.Write((short)xffe521cc76054baf);
		xbdfb620b7167944b.Write(x0ceec69a97f73617);
		xbdfb620b7167944b.Write(xbbb4d81f327c96e5);
		xbdfb620b7167944b.Write(x62ccf2f5b04cb08c);
		xbdfb620b7167944b.Write((byte)x48bc09179b84e8f0);
		xbdfb620b7167944b.Write((byte)x7e7568b9977b4f16);
		xbdfb620b7167944b.Write((byte)xc83ed05f75257524);
		xbdfb620b7167944b.Write((byte)xd83a450912bc2206);
	}
}
