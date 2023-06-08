using System.Drawing;
using System.IO;
using x6c95d9cf46ff5f25;

namespace xa7850104c8d8c135;

internal class xfad9e03fe21035af
{
	private Rectangle xbcce5a326302a01d = Rectangle.Empty;

	private Rectangle xa613532e6749367d = Rectangle.Empty;

	private int xdd6fa729345eb62c;

	private int x39efd8eeea44ab3e;

	private int xd018ee1cd412724b;

	private int x0104137d7f90bb0d;

	internal Rectangle xee6354c7044d841a => xbcce5a326302a01d;

	internal Rectangle xd948e2bd0383550a => xa613532e6749367d;

	internal RectangleF x535d3b35c3a3e8ea => new RectangleF(x61017482ec6171f0(xa613532e6749367d.X, xbdbc901ec38a52fd), x61017482ec6171f0(xa613532e6749367d.Y, xf3e60acd6c76c08e), x61017482ec6171f0(xa613532e6749367d.Width, xbdbc901ec38a52fd), x61017482ec6171f0(xa613532e6749367d.Height, xf3e60acd6c76c08e));

	private double xbdbc901ec38a52fd => (double)xdd6fa729345eb62c / (double)xd018ee1cd412724b;

	private double xf3e60acd6c76c08e => (double)x39efd8eeea44ab3e / (double)x0104137d7f90bb0d;

	internal float xf2b3620f7bfc9ed5 => (float)(xbdbc901ec38a52fd * 25.4);

	internal float x5c6fc5693c6898cd => (float)(xf3e60acd6c76c08e * 25.4);

	internal SizeF xd72aaca54f51ce54 => new SizeF(xdd6fa729345eb62c, x39efd8eeea44ab3e);

	internal xfad9e03fe21035af()
	{
	}

	internal void x06b0e25aa6ad68a9(BinaryReader xe134235b3526fa75)
	{
		xe134235b3526fa75.ReadUInt32();
		uint num = xe134235b3526fa75.ReadUInt32();
		int left = xe134235b3526fa75.ReadInt32();
		int top = xe134235b3526fa75.ReadInt32();
		int right = xe134235b3526fa75.ReadInt32();
		int bottom = xe134235b3526fa75.ReadInt32();
		xbcce5a326302a01d = Rectangle.FromLTRB(left, top, right, bottom);
		left = xe134235b3526fa75.ReadInt32();
		top = xe134235b3526fa75.ReadInt32();
		right = xe134235b3526fa75.ReadInt32();
		bottom = xe134235b3526fa75.ReadInt32();
		xa613532e6749367d = Rectangle.FromLTRB(left, top, right, bottom);
		xe134235b3526fa75.ReadUInt32();
		xe134235b3526fa75.ReadUInt32();
		xe134235b3526fa75.ReadUInt32();
		xe134235b3526fa75.ReadUInt32();
		xe134235b3526fa75.ReadUInt16();
		xe134235b3526fa75.ReadUInt16();
		xe134235b3526fa75.ReadUInt32();
		xe134235b3526fa75.ReadUInt32();
		xe134235b3526fa75.ReadUInt32();
		xdd6fa729345eb62c = xe134235b3526fa75.ReadInt32();
		x39efd8eeea44ab3e = xe134235b3526fa75.ReadInt32();
		xd018ee1cd412724b = xe134235b3526fa75.ReadInt32();
		x0104137d7f90bb0d = xe134235b3526fa75.ReadInt32();
		xe134235b3526fa75.BaseStream.Position = num;
	}

	private int x61017482ec6171f0(double x940ad9b31a9c7cce, double x04052cdbc06df72f)
	{
		return x15e971129fd80714.x43fcc3f62534530b(x940ad9b31a9c7cce / 100.0 * x04052cdbc06df72f);
	}
}
