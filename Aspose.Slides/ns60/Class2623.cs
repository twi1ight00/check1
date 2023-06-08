using System;
using System.IO;
using ns33;

namespace ns60;

internal abstract class Class2623
{
	private bool bool_0;

	private Class2623 class2623_0;

	protected Class2943 class2943_0;

	public Class2943 Header => class2943_0;

	public ushort Type => class2943_0.Type;

	public byte Version => class2943_0.Version;

	public short Instance
	{
		get
		{
			return class2943_0.Instance;
		}
		set
		{
			class2943_0.Instance = value;
		}
	}

	public int Length
	{
		get
		{
			return class2943_0.Length;
		}
		set
		{
			class2943_0.Length = value;
		}
	}

	internal bool IsGrabbed => bool_0;

	public Class2623 ParentRecord
	{
		get
		{
			return class2623_0;
		}
		set
		{
			class2623_0 = value;
		}
	}

	internal Class2623()
	{
		class2943_0 = new Class2943();
	}

	internal Class2623(ushort type, byte version)
		: this()
	{
		class2943_0.Type = type;
		class2943_0.Version = version;
	}

	public void Read(BinaryReader reader)
	{
		Read(reader, new Class2943(reader));
	}

	public void Read(BinaryReader reader, Class2943 hdr)
	{
		class2943_0 = hdr;
		int num = (int)reader.BaseStream.Position;
		vmethod_0(reader);
		int num2 = (int)reader.BaseStream.Position - num;
		if (num2 != class2943_0.Length)
		{
			string text = "Read wrong number of bytes [ 0x" + num2.ToString("X2") + " != 0x" + class2943_0.Length.ToString("X2") + " ] from record! ";
			text = text + "\nRecord: " + ToString();
			text = text + "\nOffset: 0x" + num.ToString("X4");
			throw new Exception(text);
		}
	}

	protected abstract void vmethod_0(BinaryReader reader);

	public int Write(BinaryWriter writer)
	{
		int num = (int)writer.BaseStream.Position;
		int num2 = num + 8;
		writer.BaseStream.Seek(num2, SeekOrigin.Begin);
		vmethod_1(writer);
		int num3 = Convert.ToInt32(writer.BaseStream.Position);
		Header.Length = num3 - num2;
		writer.BaseStream.Seek(num, SeekOrigin.Begin);
		Header.Write(writer);
		writer.BaseStream.Seek(num3, SeekOrigin.Begin);
		int num4 = num3 - num;
		int num5 = vmethod_2() + 8;
		if (num4 != num5)
		{
			string message = "Writed number of bytes [0x" + num4.ToString("X4") + "] not equal to record size [0x" + num5.ToString("X4") + "] " + ToString();
			throw new Exception(message);
		}
		return num4;
	}

	public abstract void vmethod_1(BinaryWriter writer);

	public abstract int vmethod_2();

	public virtual void vmethod_3(Interface38 statistics)
	{
	}

	public Class2623 method_0()
	{
		bool_0 = true;
		return this;
	}

	public override string ToString()
	{
		return $"{GetType().Name}, Header:{class2943_0.ToString()}";
	}

	public virtual void vmethod_4()
	{
	}
}
