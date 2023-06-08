using System.Drawing;
using System.IO;
using ns60;

namespace ns63;

internal class Class2904 : Class2623
{
	internal const int int_0 = 1021;

	private Class2964 class2964_0 = new Class2964();

	private Point point_0 = new Point(0, 0);

	private bool bool_1;

	private bool bool_2;

	public Class2964 CurScale => class2964_0;

	public Point Origin => point_0;

	public bool FUseVarScale
	{
		get
		{
			return bool_1;
		}
		set
		{
			bool_1 = value;
		}
	}

	public bool FDraftMode
	{
		get
		{
			return bool_2;
		}
		set
		{
			bool_2 = value;
		}
	}

	internal Class2904()
	{
		base.Header.Type = 1021;
	}

	internal void method_1(int index)
	{
		switch (index)
		{
		case 0:
			class2964_0.X = new Class2965(68, 100);
			class2964_0.Y = new Class2965(68, 100);
			point_0 = new Point(-102, -26);
			bool_1 = true;
			bool_2 = false;
			break;
		case 1:
			class2964_0.X = new Class2965(100, 100);
			class2964_0.Y = new Class2965(100, 100);
			point_0 = new Point(0, 0);
			bool_1 = false;
			bool_2 = true;
			break;
		}
	}

	protected override void vmethod_0(BinaryReader reader)
	{
		class2964_0.method_0(reader);
		reader.ReadBytes(24);
		point_0 = new Point(reader.ReadInt32(), reader.ReadInt32());
		bool_1 = reader.ReadByte() != 0;
		bool_2 = reader.ReadByte() != 0;
		reader.ReadInt16();
	}

	public override void vmethod_1(BinaryWriter writer)
	{
		class2964_0.method_1(writer);
		for (int i = 0; i < 6; i++)
		{
			writer.Write(0u);
		}
		writer.Write(point_0.X);
		writer.Write(point_0.Y);
		writer.Write((byte)(bool_1 ? 1u : 0u));
		writer.Write((byte)(bool_2 ? 1u : 0u));
		writer.Write((ushort)0);
	}

	public override int vmethod_2()
	{
		return 52;
	}
}
