using System.Drawing;
using System.IO;
using ns60;

namespace ns63;

internal class Class2864 : Class2623
{
	public const int int_0 = 1001;

	private int int_1;

	private int int_2;

	private int int_3;

	private int int_4;

	private int int_5;

	private int int_6;

	private uint uint_0;

	private uint uint_1;

	private ushort ushort_0;

	private short short_0;

	private bool bool_1;

	private bool bool_2;

	private bool bool_3;

	private bool bool_4;

	public Size SlideSize
	{
		get
		{
			return new Size(int_1, int_2);
		}
		set
		{
			int_1 = value.Width;
			int_2 = value.Height;
		}
	}

	public Size NotesSize
	{
		get
		{
			return new Size(int_3, int_4);
		}
		set
		{
			int_3 = value.Width;
			int_4 = value.Height;
		}
	}

	public Size ServerZoom
	{
		get
		{
			return new Size(int_5, int_6);
		}
		set
		{
			int_5 = value.Width;
			int_6 = value.Height;
		}
	}

	public uint NotesMasterPersistIdRef
	{
		get
		{
			return uint_0;
		}
		set
		{
			uint_0 = value;
		}
	}

	public uint HandoutMasterPersistIdRef
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

	public ushort FirstSlideNumber
	{
		get
		{
			return ushort_0;
		}
		set
		{
			ushort_0 = value;
		}
	}

	public Enum453 SlideSizeType
	{
		get
		{
			return (Enum453)short_0;
		}
		set
		{
			short_0 = (short)value;
		}
	}

	public bool FSaveWithFonts
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

	public bool FOmitTitlePlace
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

	public bool FRightToLeft
	{
		get
		{
			return bool_3;
		}
		set
		{
			bool_3 = value;
		}
	}

	public bool FShowComments
	{
		get
		{
			return bool_4;
		}
		set
		{
			bool_4 = value;
		}
	}

	public Class2864()
	{
		base.Header.Version = 1;
		base.Header.Instance = 0;
		base.Header.Type = 1001;
	}

	internal void method_1()
	{
		int_1 = 5760;
		int_2 = 4320;
		int_3 = 4320;
		int_4 = 5760;
		int_5 = 5;
		int_6 = 10;
		uint_0 = 0u;
		uint_1 = 0u;
		ushort_0 = 1;
		short_0 = 0;
		bool_1 = false;
		bool_2 = false;
		bool_3 = false;
		bool_4 = true;
	}

	protected override void vmethod_0(BinaryReader reader)
	{
		int_1 = reader.ReadInt32();
		int_2 = reader.ReadInt32();
		int_3 = reader.ReadInt32();
		int_4 = reader.ReadInt32();
		int_5 = reader.ReadInt32();
		int_6 = reader.ReadInt32();
		uint_0 = reader.ReadUInt32();
		uint_1 = reader.ReadUInt32();
		ushort_0 = reader.ReadUInt16();
		short_0 = reader.ReadInt16();
		bool_1 = reader.ReadByte() == 1;
		bool_2 = reader.ReadByte() == 1;
		bool_3 = reader.ReadByte() == 1;
		bool_4 = reader.ReadByte() == 1;
	}

	public override void vmethod_1(BinaryWriter writer)
	{
		writer.Write(int_1);
		writer.Write(int_2);
		writer.Write(int_3);
		writer.Write(int_4);
		writer.Write(int_5);
		writer.Write(int_6);
		writer.Write(uint_0);
		writer.Write(uint_1);
		writer.Write(ushort_0);
		writer.Write(short_0);
		writer.Write((byte)(bool_1 ? 1 : 0));
		writer.Write((byte)(bool_2 ? 1 : 0));
		writer.Write((byte)(bool_3 ? 1 : 0));
		writer.Write((byte)(bool_4 ? 1 : 0));
	}

	public override int vmethod_2()
	{
		return 40;
	}
}
