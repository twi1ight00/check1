using System.IO;
using ns101;
using ns146;
using ns149;
using ns99;

namespace ns147;

internal class Class4655
{
	private bool bool_0;

	private Class4681 class4681_0;

	private Class4651 class4651_0;

	private uint uint_0;

	private uint uint_1;

	private uint uint_2;

	private object object_0 = new object();

	private bool bool_1;

	public Class4681 TTFTables => class4681_0;

	internal Class4651 Context => class4651_0;

	internal bool IsNewFont
	{
		get
		{
			return bool_0;
		}
		set
		{
			bool_0 = value;
		}
	}

	private uint CheckSum => uint_0;

	public uint Offset => uint_1;

	protected uint Length => uint_2;

	internal Class4655(Class4681 ttfTables, Class4411 font)
	{
		bool_0 = true;
		class4681_0 = ttfTables;
		class4651_0 = new Class4651(null, font, ttfTables);
	}

	internal Class4655(Class4651 context, uint checkSum, uint offset, uint length)
	{
		bool_0 = false;
		class4651_0 = context;
		class4681_0 = context.TTFTables;
		uint_0 = checkSum;
		uint_1 = offset;
		uint_2 = length;
	}

	internal void method_0()
	{
		if (bool_1)
		{
			return;
		}
		lock (object_0)
		{
			if (bool_1)
			{
				return;
			}
			try
			{
				if (!IsNewFont)
				{
					using (Class4689 ttfReader = new Class4689(Context.vmethod_0()))
					{
						vmethod_0(ttfReader);
						return;
					}
				}
				vmethod_0(null);
			}
			catch (EndOfStreamException)
			{
				if (Class4510.Current.Strictness != Class4510.Enum644.const_1)
				{
					throw;
				}
			}
			finally
			{
				bool_1 = true;
			}
		}
	}

	internal virtual void vmethod_0(Class4689 ttfReader)
	{
	}

	internal virtual bool vmethod_1()
	{
		return true;
	}

	internal virtual void vmethod_2(Class4689 ttfReader)
	{
	}

	internal virtual void Save(out byte[] tableBytes, out uint length, out uint checksum)
	{
		try
		{
			using Class4689 @class = new Class4689(Context.vmethod_0());
			@class.Seek(Offset);
			using MemoryStream stream = new MemoryStream();
			using Class4685 class2 = new Class4685(stream);
			class2.method_1(@class.method_1((int)Length));
			method_1(class2, stream, out tableBytes, out length, out checksum);
		}
		catch (EndOfStreamException)
		{
			if (Class4510.Current.Strictness != Class4510.Enum644.const_1)
			{
				throw;
			}
			tableBytes = new byte[0];
			length = 0u;
			checksum = smethod_0(tableBytes);
		}
	}

	internal virtual void vmethod_3(out byte[] tableBytes, out uint length, out uint checksum)
	{
		try
		{
			using Class4689 @class = new Class4689(Context.vmethod_0());
			@class.Seek(Offset);
			tableBytes = @class.method_1((int)Length);
			length = Length;
			checksum = uint_0;
		}
		catch (EndOfStreamException)
		{
			if (Class4510.Current.Strictness != Class4510.Enum644.const_1)
			{
				throw;
			}
			tableBytes = new byte[0];
			length = 0u;
			checksum = smethod_0(tableBytes);
		}
	}

	internal void method_1(Class4685 writer, MemoryStream stream, out byte[] tableBytes, out uint length, out uint checksum)
	{
		length = (uint)writer.Position;
		while (writer.Position % 4L != 0L)
		{
			writer.WriteByte(0);
		}
		stream.Close();
		tableBytes = stream.ToArray();
		checksum = smethod_0(tableBytes);
	}

	internal static uint smethod_0(byte[] data)
	{
		int num = data.Length / 4;
		int num2 = 0;
		int num3 = 0;
		int num4 = 0;
		int num5 = 0;
		int num6 = 0;
		for (int i = 0; i < num; i++)
		{
			num5 += data[num6++] & 0xFF;
			num4 += data[num6++] & 0xFF;
			num3 += data[num6++] & 0xFF;
			num2 += data[num6++] & 0xFF;
		}
		return (uint)(num2 + (num3 << 8) + (num4 << 16) + (num5 << 24));
	}
}
