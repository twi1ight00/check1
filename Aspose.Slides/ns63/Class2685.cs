using System;
using System.IO;
using ns60;

namespace ns63;

internal class Class2685 : Class2639
{
	public const int int_0 = 12000;

	private Class2843 class2843_0;

	private Class2843 class2843_1;

	private Class2843 class2843_2;

	private Class2841 class2841_0;

	private static readonly int[] int_1 = new int[8] { 4026, 0, 4026, 1, 4026, 2, 12001, 2147483647 };

	public string Author
	{
		get
		{
			if (class2843_0 != null)
			{
				return class2843_0.String;
			}
			return "";
		}
		set
		{
			if (string.IsNullOrEmpty(value))
			{
				class2843_0 = null;
				return;
			}
			if (class2843_0 == null)
			{
				class2843_0 = new Class2843("", 0);
			}
			class2843_0.String = value;
		}
	}

	public string Text
	{
		get
		{
			if (class2843_1 != null)
			{
				return class2843_1.String;
			}
			return "";
		}
		set
		{
			if (string.IsNullOrEmpty(value))
			{
				class2843_1 = null;
				return;
			}
			if (class2843_1 == null)
			{
				class2843_1 = new Class2843("", 1);
			}
			class2843_1.String = value;
		}
	}

	public string Initials
	{
		get
		{
			if (class2843_2 != null)
			{
				return class2843_2.String;
			}
			return "";
		}
		set
		{
			if (string.IsNullOrEmpty(value))
			{
				class2843_2 = null;
				return;
			}
			if (class2843_2 == null)
			{
				class2843_2 = new Class2843("", 2);
			}
			class2843_2.String = value;
		}
	}

	public Class2841 CommentAtom => class2841_0;

	public Class2685()
	{
		base.Header.Type = 12000;
		class2841_0 = new Class2841();
	}

	public string method_5(short instance)
	{
		int num = 0;
		while (true)
		{
			if (num < base.Records.Count)
			{
				if (base.Records[num] is Class2843 && ((Class2843)base.Records[num]).Header.Instance == instance)
				{
					break;
				}
				num++;
				continue;
			}
			return "";
		}
		return ((Class2843)base.Records[num]).String;
	}

	protected override void vmethod_0(BinaryReader reader)
	{
		long num = reader.BaseStream.Position + base.Header.Length;
		while (true)
		{
			if (reader.BaseStream.Position >= num)
			{
				return;
			}
			Class2623 @class = Class2950.smethod_1(reader, this);
			if (@class is Class2843)
			{
				switch (@class.Header.Instance)
				{
				case 0:
					class2843_0 = (Class2843)@class;
					break;
				case 1:
					class2843_1 = (Class2843)@class;
					break;
				case 2:
					class2843_2 = (Class2843)@class;
					break;
				default:
					throw new Exception("Read Error! Unknown CString record in Comment10Container.");
				}
			}
			else
			{
				if (!(@class is Class2841))
				{
					break;
				}
				class2841_0 = (Class2841)@class;
			}
		}
		throw new Exception("Read Error! Unknown record in Comment10Container.");
	}

	public override void vmethod_1(BinaryWriter writer)
	{
		if (class2843_0 != null)
		{
			class2843_0.Write(writer);
		}
		if (class2843_1 != null)
		{
			class2843_1.Write(writer);
		}
		if (class2843_2 != null)
		{
			class2843_2.Write(writer);
		}
		if (class2841_0 == null)
		{
			throw new Exception("Write Error! Comment10Container haven't Comment10Atom.");
		}
		class2841_0.Write(writer);
	}

	public override int vmethod_2()
	{
		int num = 0;
		if (class2843_0 != null)
		{
			num += class2843_0.vmethod_2() + 8;
		}
		if (class2843_1 != null)
		{
			num += class2843_1.vmethod_2() + 8;
		}
		if (class2843_2 != null)
		{
			num += class2843_2.vmethod_2() + 8;
		}
		if (class2841_0 != null)
		{
			num += class2841_0.vmethod_2() + 8;
		}
		return num;
	}

	protected override int[] vmethod_6()
	{
		return int_1;
	}
}
