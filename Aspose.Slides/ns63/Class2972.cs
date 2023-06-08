using System;
using System.IO;
using System.Text;
using Aspose.Slides;
using ns60;

namespace ns63;

internal class Class2972 : Interface40
{
	private Enum450 enum450_0;

	private Enum446 enum446_0;

	protected short short_0;

	protected ushort ushort_0 = ushort.MaxValue;

	protected short short_1;

	protected Class2966 class2966_0;

	protected Enum455 enum455_0;

	protected short short_2;

	protected short short_3;

	protected short short_4;

	protected short short_5;

	protected short short_6;

	protected short short_7;

	protected Class2942 class2942_0;

	protected Enum380 enum380_0;

	protected Enum440 enum440_0;

	protected Enum445 enum445_0;

	protected short short_8 = -1;

	protected bool bool_0;

	protected Class2979 class2979_0 = new Class2979();

	protected Enum446[] enum446_1 = new Enum446[4]
	{
		Enum446.flag_0,
		Enum446.flag_1,
		Enum446.flag_2,
		Enum446.flag_3
	};

	public bool IsEmpty
	{
		get
		{
			return enum450_0 == (Enum450)0;
		}
		set
		{
			if (value)
			{
				enum450_0 = (Enum450)0;
				class2966_0 = null;
				class2942_0 = null;
				class2979_0 = null;
			}
		}
	}

	public bool HaveTabAndMargin
	{
		get
		{
			return method_5(Enum450.flag_28);
		}
		set
		{
			if (!value)
			{
				method_6(Enum450.flag_28, condition: false);
			}
		}
	}

	public void method_0(BinaryReader reader)
	{
		enum450_0 = (Enum450)reader.ReadUInt32();
		if (method_5(Enum450.flag_29))
		{
			if (method_5(Enum450.flag_26))
			{
				enum446_0 = (Enum446)reader.ReadUInt16();
			}
			if (method_5(Enum450.flag_7))
			{
				short_0 = reader.ReadInt16();
			}
			if (method_5(Enum450.flag_4))
			{
				ushort_0 = reader.ReadUInt16();
			}
			if (method_5(Enum450.flag_6))
			{
				short_1 = reader.ReadInt16();
			}
			if (method_5(Enum450.flag_5))
			{
				class2966_0 = new Class2966(reader.ReadUInt32());
			}
			if (method_5(Enum450.flag_11))
			{
				int num = reader.ReadUInt16();
				if (!Enum.IsDefined(typeof(Enum455), num))
				{
					throw new PptReadException("[ms-ppt] 2.9.20 TextPFException contains wrong value in textAlignment field which is not present in 2.13.27 TextAlignmentEnum enumeration.");
				}
				enum455_0 = (Enum455)num;
			}
			if (method_5(Enum450.flag_12))
			{
				short_2 = reader.ReadInt16();
			}
			if (method_5(Enum450.flag_13))
			{
				short_3 = reader.ReadInt16();
			}
			if (method_5(Enum450.flag_14))
			{
				short_4 = reader.ReadInt16();
			}
			if (method_5(Enum450.flag_8))
			{
				short_5 = reader.ReadInt16();
			}
			if (method_5(Enum450.flag_10))
			{
				short_6 = reader.ReadInt16();
			}
			if (method_5(Enum450.flag_15))
			{
				short_7 = reader.ReadInt16();
			}
			if (method_5(Enum450.flag_20))
			{
				class2942_0 = new Class2942(reader);
			}
			if (method_5(Enum450.flag_16))
			{
				int num2 = reader.ReadUInt16();
				if (!Enum.IsDefined(typeof(Enum380), num2))
				{
					throw new PptReadException("[ms-ppt] 2.9.20 TextPFException contains wrong value in fontAlign field which is not present in 2.13.31 TextFontAlignmentEnum enumeration.");
				}
				enum380_0 = (Enum380)num2;
			}
			if (method_5(Enum450.flag_27))
			{
				enum440_0 = (Enum440)reader.ReadUInt16();
			}
			if (method_5(Enum450.flag_21))
			{
				int num3 = reader.ReadUInt16();
				if (!Enum.IsDefined(typeof(Enum445), num3))
				{
					throw new PptReadException("[ms-ppt] 2.9.20 TextPFException contains wrong value in textDirection field which is not present in 2.13.30 TextDirectionEnum enumeration.");
				}
				enum445_0 = (Enum445)num3;
			}
		}
		if (method_5(Enum450.flag_30))
		{
			if (method_5(Enum450.flag_23))
			{
				short_8 = reader.ReadInt16();
			}
			if (method_5(Enum450.flag_25))
			{
				bool_0 = reader.ReadInt16() != 0;
			}
			if (method_5(Enum450.flag_24))
			{
				class2979_0.method_0(reader);
			}
		}
	}

	public void method_1(BinaryWriter writer)
	{
		writer.Write((uint)enum450_0);
		if (method_5(Enum450.flag_29))
		{
			if (method_5(Enum450.flag_26))
			{
				writer.Write((ushort)enum446_0);
			}
			if (method_5(Enum450.flag_7))
			{
				writer.Write(short_0);
			}
			if (method_5(Enum450.flag_4))
			{
				writer.Write(ushort_0);
			}
			if (method_5(Enum450.flag_6))
			{
				writer.Write(short_1);
			}
			if (method_5(Enum450.flag_5))
			{
				writer.Write(class2966_0.Struct);
			}
			if (method_5(Enum450.flag_11))
			{
				writer.Write((ushort)enum455_0);
			}
			if (method_5(Enum450.flag_12))
			{
				writer.Write(short_2);
			}
			if (method_5(Enum450.flag_13))
			{
				writer.Write(short_3);
			}
			if (method_5(Enum450.flag_14))
			{
				writer.Write(short_4);
			}
			if (method_5(Enum450.flag_8))
			{
				writer.Write(short_5);
			}
			if (method_5(Enum450.flag_10))
			{
				writer.Write(short_6);
			}
			if (method_5(Enum450.flag_15))
			{
				writer.Write(short_7);
			}
			if (method_5(Enum450.flag_20))
			{
				class2942_0.method_3(writer);
			}
			if (method_5(Enum450.flag_16))
			{
				writer.Write((ushort)enum380_0);
			}
			if (method_5(Enum450.flag_27))
			{
				writer.Write((ushort)enum440_0);
			}
			if (method_5(Enum450.flag_21))
			{
				writer.Write((ushort)enum445_0);
			}
		}
		if (method_5(Enum450.flag_30))
		{
			if (method_5(Enum450.flag_23))
			{
				writer.Write(short_8);
			}
			if (method_5(Enum450.flag_25))
			{
				writer.Write((ushort)(bool_0 ? 1u : 0u));
			}
			if (method_5(Enum450.flag_24))
			{
				class2979_0.method_1(writer);
			}
		}
	}

	public int method_2()
	{
		int num = 4;
		if (method_5(Enum450.flag_29))
		{
			if (method_5(Enum450.flag_26))
			{
				num += 2;
			}
			if (method_5(Enum450.flag_7))
			{
				num += 2;
			}
			if (method_5(Enum450.flag_4))
			{
				num += 2;
			}
			if (method_5(Enum450.flag_6))
			{
				num += 2;
			}
			if (method_5(Enum450.flag_5))
			{
				num += 4;
			}
			if (method_5(Enum450.flag_11))
			{
				num += 2;
			}
			if (method_5(Enum450.flag_12))
			{
				num += 2;
			}
			if (method_5(Enum450.flag_13))
			{
				num += 2;
			}
			if (method_5(Enum450.flag_14))
			{
				num += 2;
			}
			if (method_5(Enum450.flag_8))
			{
				num += 2;
			}
			if (method_5(Enum450.flag_10))
			{
				num += 2;
			}
			if (method_5(Enum450.flag_15))
			{
				num += 2;
			}
			if (method_5(Enum450.flag_20))
			{
				num += class2942_0.method_4();
			}
			if (method_5(Enum450.flag_16))
			{
				num += 2;
			}
			if (method_5(Enum450.flag_27))
			{
				num += 2;
			}
			if (method_5(Enum450.flag_21))
			{
				num += 2;
			}
		}
		if (method_5(Enum450.flag_30))
		{
			if (method_5(Enum450.flag_23))
			{
				num += 2;
			}
			if (method_5(Enum450.flag_25))
			{
				num += 2;
			}
			if (method_5(Enum450.flag_24))
			{
				num += class2979_0.method_2();
			}
		}
		return num;
	}

	public virtual void vmethod_0(Class2972 textPFExceptionBase)
	{
		if (textPFExceptionBase == null)
		{
			return;
		}
		Enum450 @enum = textPFExceptionBase.enum450_0 ^ (textPFExceptionBase.enum450_0 & enum450_0);
		if ((@enum & Enum450.flag_29) != 0)
		{
			if ((@enum & Enum450.flag_26) != 0)
			{
				for (int i = 0; i < enum446_1.Length; i++)
				{
					Enum450 mask = method_9(enum446_1[i]);
					if (!method_5(mask) && textPFExceptionBase.method_5(mask))
					{
						method_6(mask, condition: true);
						method_8(enum446_1[i], textPFExceptionBase.method_7(enum446_1[i]));
					}
				}
			}
			if ((@enum & Enum450.flag_7) != 0)
			{
				short_0 = textPFExceptionBase.short_0;
			}
			if ((@enum & Enum450.flag_4) != 0)
			{
				ushort_0 = textPFExceptionBase.ushort_0;
			}
			if ((@enum & Enum450.flag_6) != 0)
			{
				short_1 = textPFExceptionBase.short_1;
			}
			if ((@enum & Enum450.flag_5) != 0)
			{
				class2966_0 = textPFExceptionBase.class2966_0;
			}
			if ((@enum & Enum450.flag_11) != 0)
			{
				enum455_0 = textPFExceptionBase.enum455_0;
			}
			if ((@enum & Enum450.flag_12) != 0)
			{
				short_2 = textPFExceptionBase.short_2;
			}
			if ((@enum & Enum450.flag_13) != 0)
			{
				short_3 = textPFExceptionBase.short_3;
			}
			if ((@enum & Enum450.flag_14) != 0)
			{
				short_4 = textPFExceptionBase.short_4;
			}
			if ((@enum & Enum450.flag_8) != 0)
			{
				short_5 = textPFExceptionBase.short_5;
			}
			if ((@enum & Enum450.flag_10) != 0)
			{
				short_6 = textPFExceptionBase.short_6;
			}
			if ((@enum & Enum450.flag_15) != 0)
			{
				short_7 = textPFExceptionBase.short_7;
			}
			if ((@enum & Enum450.flag_20) != 0)
			{
				class2942_0 = textPFExceptionBase.class2942_0;
			}
			if ((@enum & Enum450.flag_16) != 0)
			{
				enum380_0 = textPFExceptionBase.enum380_0;
			}
			if ((@enum & Enum450.flag_27) != 0)
			{
				enum440_0 = textPFExceptionBase.enum440_0;
			}
			if ((@enum & Enum450.flag_21) != 0)
			{
				enum445_0 = textPFExceptionBase.enum445_0;
			}
		}
		if ((@enum & Enum450.flag_30) != 0)
		{
			if ((@enum & Enum450.flag_23) != 0)
			{
				short_8 = textPFExceptionBase.short_8;
			}
			if ((@enum & Enum450.flag_25) != 0)
			{
				bool_0 = textPFExceptionBase.bool_0;
			}
			if ((@enum & Enum450.flag_24) != 0)
			{
				class2979_0 = textPFExceptionBase.class2979_0;
			}
		}
		enum450_0 |= textPFExceptionBase.enum450_0;
	}

	public virtual void vmethod_1(Class2972 textPFExceptionBase)
	{
		if (textPFExceptionBase == null)
		{
			return;
		}
		Enum450 @enum = textPFExceptionBase.enum450_0 & enum450_0;
		if ((@enum & Enum450.flag_29) == 0)
		{
			return;
		}
		if ((@enum & Enum450.flag_26) != 0)
		{
			if (enum446_0 == textPFExceptionBase.enum446_0)
			{
				method_6(Enum450.flag_26, condition: false);
			}
			else
			{
				for (int i = 0; i < enum446_1.Length; i++)
				{
					NullableBool nullableBool = method_7(enum446_1[i]);
					NullableBool nullableBool2 = textPFExceptionBase.method_7(enum446_1[i]);
					if (nullableBool != NullableBool.NotDefined && nullableBool == nullableBool2)
					{
						method_8(enum446_1[i], NullableBool.NotDefined);
					}
				}
			}
		}
		if ((@enum & Enum450.flag_7) != 0 && short_0 == textPFExceptionBase.short_0)
		{
			method_6(Enum450.flag_7, condition: false);
		}
		if ((@enum & Enum450.flag_4) != 0 && ushort_0 == textPFExceptionBase.ushort_0)
		{
			method_6(Enum450.flag_4, condition: false);
		}
		if ((@enum & Enum450.flag_6) != 0 && short_1 == textPFExceptionBase.short_1)
		{
			method_6(Enum450.flag_6, condition: false);
		}
		if ((@enum & Enum450.flag_5) != 0 && class2966_0 == textPFExceptionBase.class2966_0)
		{
			method_6(Enum450.flag_5, condition: false);
		}
		if ((@enum & Enum450.flag_11) != 0 && enum455_0 == textPFExceptionBase.enum455_0)
		{
			method_6(Enum450.flag_11, condition: false);
		}
		if ((@enum & Enum450.flag_12) != 0 && short_2 == textPFExceptionBase.short_2)
		{
			method_6(Enum450.flag_12, condition: false);
		}
		if ((@enum & Enum450.flag_13) != 0 && short_3 == textPFExceptionBase.short_3)
		{
			method_6(Enum450.flag_13, condition: false);
		}
		if ((@enum & Enum450.flag_14) != 0 && short_4 == textPFExceptionBase.short_4)
		{
			method_6(Enum450.flag_14, condition: false);
		}
		if ((@enum & Enum450.flag_8) != 0 && short_5 == textPFExceptionBase.short_5)
		{
			method_6(Enum450.flag_8, condition: false);
		}
		if ((@enum & Enum450.flag_10) != 0 && short_6 == textPFExceptionBase.short_6)
		{
			method_6(Enum450.flag_10, condition: false);
		}
		if ((@enum & Enum450.flag_15) != 0 && short_7 == textPFExceptionBase.short_7)
		{
			method_6(Enum450.flag_15, condition: false);
		}
		if ((@enum & Enum450.flag_20) != 0 && class2942_0 == textPFExceptionBase.class2942_0)
		{
			method_6(Enum450.flag_20, condition: false);
		}
		if ((@enum & Enum450.flag_16) != 0 && enum380_0 == textPFExceptionBase.enum380_0)
		{
			method_6(Enum450.flag_16, condition: false);
		}
		if ((@enum & Enum450.flag_27) != 0 && enum440_0 == textPFExceptionBase.enum440_0)
		{
			method_6(Enum450.flag_27, condition: false);
		}
		if ((@enum & Enum450.flag_21) != 0 && enum445_0 == textPFExceptionBase.enum445_0)
		{
			method_6(Enum450.flag_21, condition: false);
		}
	}

	public override string ToString()
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.AppendLine($"  PFMask: 0x{(uint)enum450_0:X}, {enum450_0}");
		if (method_5(Enum450.flag_29))
		{
			if (method_5(Enum450.flag_26))
			{
				stringBuilder.AppendLine($"  Bulletflags   : 0x{(ushort)enum446_0:X}, {enum446_0}");
				if (method_5(Enum450.flag_0))
				{
					stringBuilder.AppendLine($"  HasBullet     : {method_7(Enum446.flag_0) == NullableBool.True}");
				}
				if (method_5(Enum450.flag_1))
				{
					stringBuilder.AppendLine($"  BulletHasFont : {method_7(Enum446.flag_1) == NullableBool.True}");
				}
				if (method_5(Enum450.flag_2))
				{
					stringBuilder.AppendLine($"  BulletHasColor: {method_7(Enum446.flag_2) == NullableBool.True}");
				}
				if (method_5(Enum450.flag_3))
				{
					stringBuilder.AppendLine($"  BulletHasSize : {method_7(Enum446.flag_3) == NullableBool.True}");
				}
			}
			if (method_5(Enum450.flag_7))
			{
				stringBuilder.AppendLine($"  BulletChar: {short_0}");
			}
			if (method_5(Enum450.flag_4))
			{
				stringBuilder.AppendLine($"  BulletFontRef: {ushort_0}");
			}
			if (method_5(Enum450.flag_6))
			{
				stringBuilder.AppendLine($"  BulletSize: {short_1}");
			}
			if (method_5(Enum450.flag_5))
			{
				stringBuilder.AppendLine($"  BulletColor: {class2966_0}");
			}
			if (method_5(Enum450.flag_11))
			{
				stringBuilder.AppendLine($"  TextAlignment: {enum455_0}");
			}
			if (method_5(Enum450.flag_12))
			{
				stringBuilder.AppendLine($"  LineSpacing: {short_2}");
			}
			if (method_5(Enum450.flag_13))
			{
				stringBuilder.AppendLine($"  SpaceBefore: {short_3}");
			}
			if (method_5(Enum450.flag_14))
			{
				stringBuilder.AppendLine($"  SpaceAfter: {short_4}");
			}
			if (method_5(Enum450.flag_8))
			{
				stringBuilder.AppendLine($"  LeftMargin: {short_5}");
			}
			if (method_5(Enum450.flag_10))
			{
				stringBuilder.AppendLine($"  Indent: {short_6}");
			}
			if (method_5(Enum450.flag_15))
			{
				stringBuilder.AppendLine($"  DefaultTabSize: {short_7}");
			}
			if (method_5(Enum450.flag_20))
			{
				stringBuilder.AppendLine($"  TabStops: {class2942_0}");
			}
			if (method_5(Enum450.flag_16))
			{
				stringBuilder.AppendLine($"  FontAlign: {enum380_0}");
			}
			if (method_5(Enum450.flag_27))
			{
				stringBuilder.AppendLine($"  Wrapflags   : 0x{(ushort)enum440_0:X}, {enum440_0}");
				if (method_5(Enum450.flag_17))
				{
					stringBuilder.AppendLine($"  CharWrap: {method_10(Enum440.flag_0) == NullableBool.True}");
				}
				if (method_5(Enum450.flag_18))
				{
					stringBuilder.AppendLine($"  WordWrap: {method_10(Enum440.flag_1) == NullableBool.True}");
				}
				if (method_5(Enum450.flag_19))
				{
					stringBuilder.AppendLine($"  Overfow: {method_10(Enum440.flag_2) == NullableBool.True}");
				}
			}
			if (method_5(Enum450.flag_21))
			{
				stringBuilder.Append($"  TextDirection: {enum445_0}");
			}
		}
		if (method_5(Enum450.flag_30))
		{
			if (method_5(Enum450.flag_23))
			{
				stringBuilder.AppendLine($"  BulletBlip: {short_8}");
			}
			if (method_5(Enum450.flag_25))
			{
				stringBuilder.AppendLine($"  BulletHasScheme: {bool_0}");
			}
			if (method_5(Enum450.flag_24))
			{
				stringBuilder.AppendLine($"  BulletScheme: {class2979_0.ToString()}");
			}
		}
		return stringBuilder.ToString();
	}

	internal void method_3(uint testMask)
	{
	}

	internal bool method_4(Class2972 textPFException)
	{
		if (enum450_0 != textPFException.enum450_0)
		{
			return false;
		}
		if (enum450_0 == (Enum450)0)
		{
			return true;
		}
		if (method_5(Enum450.flag_26) && enum446_0 != textPFException.enum446_0)
		{
			return false;
		}
		if (method_5(Enum450.flag_7) && short_0 != textPFException.short_0)
		{
			return false;
		}
		if (method_5(Enum450.flag_4) && ushort_0 != textPFException.ushort_0)
		{
			return false;
		}
		if (method_5(Enum450.flag_6) && short_1 != textPFException.short_1)
		{
			return false;
		}
		if (method_5(Enum450.flag_5) && class2966_0.Struct != textPFException.class2966_0.Struct)
		{
			return false;
		}
		if (method_5(Enum450.flag_11) && enum455_0 != textPFException.enum455_0)
		{
			return false;
		}
		if (method_5(Enum450.flag_12) && short_2 != textPFException.short_2)
		{
			return false;
		}
		if (method_5(Enum450.flag_13) && short_3 != textPFException.short_3)
		{
			return false;
		}
		if (method_5(Enum450.flag_14) && short_4 != textPFException.short_4)
		{
			return false;
		}
		if (method_5(Enum450.flag_8) && short_5 != textPFException.short_5)
		{
			return false;
		}
		if (method_5(Enum450.flag_10) && short_6 != textPFException.short_6)
		{
			return false;
		}
		if (method_5(Enum450.flag_15) && short_7 != textPFException.short_7)
		{
			return false;
		}
		if (method_5(Enum450.flag_20) && !class2942_0.method_5(textPFException.class2942_0))
		{
			return false;
		}
		if (method_5(Enum450.flag_16) && enum380_0 != textPFException.enum380_0)
		{
			return false;
		}
		if (method_5(Enum450.flag_27) && enum440_0 != textPFException.enum440_0)
		{
			return false;
		}
		if (method_5(Enum450.flag_21) && enum445_0 != textPFException.enum445_0)
		{
			return false;
		}
		if (method_5(Enum450.flag_23) && short_8 != textPFException.short_8)
		{
			return false;
		}
		if (method_5(Enum450.flag_25) && bool_0 != textPFException.bool_0)
		{
			return false;
		}
		if (method_5(Enum450.flag_24) && !class2979_0.method_3(textPFException.class2979_0))
		{
			return false;
		}
		return true;
	}

	protected bool method_5(Enum450 mask)
	{
		return (enum450_0 & mask) != 0;
	}

	protected void method_6(Enum450 mask, bool condition)
	{
		enum450_0 |= mask;
		if (!condition)
		{
			enum450_0 ^= mask;
		}
	}

	protected NullableBool method_7(Enum446 flag)
	{
		if (!method_5(method_9(flag)))
		{
			return NullableBool.NotDefined;
		}
		if ((enum446_0 & flag) == 0)
		{
			return NullableBool.False;
		}
		return NullableBool.True;
	}

	protected void method_8(Enum446 flag, NullableBool value)
	{
		Enum450 @enum = method_9(flag);
		if (value == NullableBool.NotDefined)
		{
			enum450_0 = (enum450_0 | @enum) ^ @enum;
			return;
		}
		enum450_0 |= @enum;
		enum446_0 |= flag;
		if (value == NullableBool.False)
		{
			enum446_0 ^= flag;
		}
	}

	private Enum450 method_9(Enum446 flag)
	{
		Enum450 @enum = (Enum450)(flag & (Enum446.flag_0 | Enum446.flag_1 | Enum446.flag_2 | Enum446.flag_3));
		if (@enum == (Enum450)0)
		{
			throw new InvalidOperationException();
		}
		return @enum;
	}

	protected NullableBool method_10(Enum440 flag)
	{
		if (!method_5(method_12(flag)))
		{
			return NullableBool.NotDefined;
		}
		if ((enum440_0 & flag) == 0)
		{
			return NullableBool.False;
		}
		return NullableBool.True;
	}

	protected void method_11(Enum440 flag, NullableBool value)
	{
		Enum450 @enum = method_12(flag);
		if (value == NullableBool.NotDefined)
		{
			enum450_0 = (enum450_0 | @enum) ^ @enum;
			return;
		}
		enum450_0 |= @enum;
		enum440_0 |= flag;
		if (value == NullableBool.False)
		{
			enum440_0 ^= flag;
		}
	}

	private Enum450 method_12(Enum440 flag)
	{
		Enum450 @enum = (Enum450)(((int)flag << 17) & 0xE0000);
		if (@enum == (Enum450)0)
		{
			throw new InvalidOperationException();
		}
		return @enum;
	}
}
