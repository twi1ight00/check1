using System;
using System.Collections;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Text;
using Aspose.Cells;
using Aspose.Cells.Drawing;
using ns22;
using ns27;

namespace ns52;

internal class Class1711
{
	private Hashtable hashtable_0;

	private object object_0;

	internal Class1136 this[ushort ushort_0] => (Class1136)hashtable_0[ushort_0];

	internal int Count => hashtable_0.Count;

	internal int Length
	{
		get
		{
			Hyperlink hyperlink = null;
			int num = hashtable_0.Count * 6;
			foreach (Class1136 value in hashtable_0.Values)
			{
				if (value.method_0())
				{
					switch (value.method_2())
					{
					case Enum183.const_2:
					{
						string text = (string)value.method_4();
						num += text.Length * 2 + 2;
						break;
					}
					case Enum183.const_3:
					{
						hyperlink = (Hyperlink)value.method_4();
						Class646 class2 = new Class646(hyperlink.Area, "", hyperlink.Address, hyperlink);
						int num2 = class2.Length - 8;
						byte[] array = new byte[num2];
						Array.Copy(class2.Data, 8, array, 0, num2);
						value.method_5(array);
						value.method_3(Enum183.const_4);
						num += num2;
						break;
					}
					case Enum183.const_4:
						num += ((byte[])value.method_4()).Length;
						break;
					case Enum183.const_5:
						num += ((byte[])value.method_4()).Length;
						break;
					}
				}
			}
			if (object_0 is Class1714 && hyperlink != null && hyperlink.ScreenTip != null && hyperlink.ScreenTip != "")
			{
				((Class1714)object_0).method_5().method_1(50061, Enum183.const_2, hyperlink.ScreenTip);
			}
			return num;
		}
	}

	internal Class1711(object object_1)
	{
		object_0 = object_1;
		hashtable_0 = new Hashtable();
	}

	internal void Clear()
	{
		hashtable_0.Clear();
	}

	internal bool Contains(ushort ushort_0)
	{
		return hashtable_0.ContainsKey(ushort_0);
	}

	internal void Remove(ushort ushort_0, ushort ushort_1)
	{
		for (ushort num = ushort_0; num <= ushort_1; num = (ushort)(num + 1))
		{
			hashtable_0.Remove(num);
		}
	}

	internal void Remove(ushort ushort_0)
	{
		hashtable_0.Remove(ushort_0);
	}

	internal void Copy(Class1711 class1711_0)
	{
		hashtable_0 = (Hashtable)class1711_0.hashtable_0.Clone();
		hashtable_0.Clear();
		IEnumerator enumerator = class1711_0.hashtable_0.Values.GetEnumerator();
		while (enumerator.MoveNext())
		{
			Class1136 @class = (Class1136)enumerator.Current;
			object obj = @class.method_4();
			switch (@class.method_2())
			{
			case Enum183.const_3:
			{
				Hyperlink hyperlink = new Hyperlink();
				hyperlink.Copy((Hyperlink)obj);
				obj = hyperlink;
				break;
			}
			case Enum183.const_4:
				obj = (byte[])((byte[])obj).Clone();
				break;
			}
			Class1136 class2 = new Class1136(@class.method_1(), @class.method_2(), obj);
			hashtable_0.Add(class2.method_1(), class2);
		}
	}

	[SpecialName]
	internal ArrayList method_0()
	{
		ArrayList arrayList = new ArrayList();
		foreach (Class1136 value in hashtable_0.Values)
		{
			arrayList.Add(value);
		}
		arrayList.Sort(new Class1135());
		return arrayList;
	}

	internal static bool smethod_0(ushort ushort_0, int int_0)
	{
		if (int_0 == 0)
		{
			return false;
		}
		switch (ushort_0 & 0x3FFF)
		{
		default:
			return false;
		case 325:
		case 326:
		case 337:
		case 341:
		case 342:
		case 343:
			return true;
		}
	}

	internal void method_1(ushort ushort_0, Enum183 enum183_0, object object_1)
	{
		if (object_1 == null)
		{
			Remove(ushort_0);
			return;
		}
		if (enum183_0 == Enum183.const_0 && object_1 is uint)
		{
			object_1 = (int)(uint)object_1;
		}
		Class1136 @class = this[ushort_0];
		if (@class != null)
		{
			@class.method_3(enum183_0);
			@class.method_5(object_1);
		}
		else
		{
			hashtable_0.Add(ushort_0, new Class1136(ushort_0, enum183_0, object_1));
		}
	}

	[SpecialName]
	internal Hyperlink method_2()
	{
		Class1136 @class = this[50050];
		if (@class == null)
		{
			return null;
		}
		if (@class.method_2() == Enum183.const_4)
		{
			byte[] array = (byte[])@class.method_4();
			HyperlinkCollection hyperlinkCollection = new HyperlinkCollection(null);
			byte[] array2 = new byte[array.Length + 8];
			Array.Copy(array, 0, array2, 8, array.Length);
			hyperlinkCollection.method_7(array2);
			@class.method_3(Enum183.const_3);
			@class.method_5(hyperlinkCollection[0]);
			if (object_0 != null && object_0 is Class1714)
			{
				Class1714 class2 = (Class1714)object_0;
				if (class2.method_3() != null)
				{
					string stringValue = class2.method_5().GetStringValue(50061);
					if (stringValue != null && stringValue != "")
					{
						hyperlinkCollection[0].ScreenTip = stringValue;
						class2.method_5().Remove(50061);
					}
				}
			}
			return hyperlinkCollection[0];
		}
		if (@class.method_2() == Enum183.const_3)
		{
			return (Hyperlink)@class.method_4();
		}
		return null;
	}

	internal byte[] method_3(ushort ushort_0)
	{
		Class1136 @class = this[ushort_0];
		if (@class == null)
		{
			return null;
		}
		if (@class.method_2() == Enum183.const_4)
		{
			return (byte[])@class.method_4();
		}
		return null;
	}

	internal string GetStringValue(ushort ushort_0)
	{
		Class1136 @class = this[ushort_0];
		if (@class == null)
		{
			return "";
		}
		switch (@class.method_2())
		{
		case Enum183.const_2:
			return (string)@class.method_4();
		default:
			return null;
		case Enum183.const_4:
		{
			byte[] array = (byte[])@class.method_4();
			return Encoding.Unicode.GetString(array, 0, array.Length - 2);
		}
		}
	}

	internal int method_4(ushort ushort_0, int int_0)
	{
		Class1136 @class = this[ushort_0];
		if (@class == null)
		{
			return int_0;
		}
		if (@class.method_4() is Color color)
		{
			return color.ToArgb() & 0xFFFFFF;
		}
		return (int)@class.method_4();
	}

	internal bool method_5(ushort ushort_0, int int_0, bool bool_0)
	{
		Class1136 @class = this[ushort_0];
		if (@class == null)
		{
			return bool_0;
		}
		uint num = (uint)(int)@class.method_4();
		int num2 = 1 << int_0;
		if (((num >> 16) & num2) == 0)
		{
			return bool_0;
		}
		return (num & num2) != 0;
	}

	internal void method_6(ushort ushort_0, int int_0, bool bool_0)
	{
		uint num = (uint)(1 << int_0);
		Class1136 @class = this[ushort_0];
		if (@class == null)
		{
			@class = new Class1136(ushort_0, Enum183.const_0, 0);
			hashtable_0.Add(ushort_0, @class);
		}
		uint num2 = (uint)(int)@class.method_4();
		uint num3 = num << 16;
		num2 &= ~(num3 + num);
		num2 |= (bool_0 ? (num3 + num) : (num << 16));
		@class.method_5((int)num2);
	}

	internal float method_7(ushort ushort_0, float float_0)
	{
		Class1136 @class = this[ushort_0];
		if (@class == null)
		{
			return float_0;
		}
		int num = (int)@class.method_4();
		return (float)(num >> 16) + (float)(num & 0xFFFF) / 65536f;
	}

	internal void method_8(ushort ushort_0, float float_0)
	{
		int num = (int)float_0;
		int num2 = (num << 16) + (int)((float_0 - (float)num) * 65536f);
		method_1(ushort_0, Enum183.const_0, num2);
	}

	internal static int smethod_1(float float_0)
	{
		int num = (int)float_0;
		return (num << 16) + (int)((float_0 - (float)num) * 65536f);
	}

	internal static float smethod_2(int int_0)
	{
		return (float)(int_0 >> 16) + (float)(int_0 & 0xFFFF) / 65536f;
	}

	[SpecialName]
	internal WorksheetCollection method_9()
	{
		if (object_0 is Class1714)
		{
			return ((Class1714)object_0).method_6().method_1();
		}
		if (object_0 is FillFormat)
		{
			return ((FillFormat)object_0).method_0().Chart.method_14();
		}
		return null;
	}

	internal Color GetColor(ushort ushort_0, Color color_0)
	{
		Class1136 @class = this[ushort_0];
		if (@class == null)
		{
			return color_0;
		}
		if (@class.method_2() == Enum183.const_1)
		{
			return (Color)@class.method_4();
		}
		int num = (int)@class.method_4();
		Color color = color_0;
		switch ((num >> 24) & 0xFF)
		{
		case 16:
			return color_0;
		case 0:
		case 2:
		case 4:
			color = Color.FromArgb(num & 0xFF, (num >> 8) & 0xFF, (num >> 16) & 0xFF);
			@class.method_5(color);
			@class.method_3(Enum183.const_1);
			goto IL_00d9;
		default:
			return color_0;
		case 1:
		case 8:
			{
				color = method_9().method_24().method_7(num & 0xFFFFFF);
				if (!color.IsEmpty)
				{
					@class.method_5(color);
					@class.method_3(Enum183.const_1);
					goto IL_00d9;
				}
				return color_0;
			}
			IL_00d9:
			return color;
		}
	}

	internal bool method_10(ushort ushort_0)
	{
		Class1136 @class = this[ushort_0];
		if (@class == null)
		{
			return true;
		}
		if (@class.method_2() == Enum183.const_1)
		{
			return Class1178.smethod_0((Color)@class.method_4());
		}
		int num = (int)@class.method_4();
		switch ((num >> 24) & 0xFF)
		{
		default:
			return false;
		case 16:
			return true;
		case 1:
		case 8:
			return (num & 0xFFFFFF) >= 64;
		}
	}

	internal int method_11(Shape shape_0, byte[] byte_0, int int_0, bool bool_0)
	{
		ushort num = 3;
		num = (ushort)(3u | (ushort)(Count << 4));
		Array.Copy(BitConverter.GetBytes(num), 0, byte_0, int_0, 2);
		if (bool_0)
		{
			byte_0[int_0 + 2] = 34;
			byte_0[int_0 + 3] = 241;
		}
		else
		{
			byte_0[int_0 + 2] = 11;
			byte_0[int_0 + 3] = 240;
		}
		int length = Length;
		Array.Copy(BitConverter.GetBytes(length), 0, byte_0, int_0 + 4, 4);
		int_0 += 8;
		ArrayList arrayList = method_0();
		int num2 = int_0 + arrayList.Count * 6;
		foreach (Class1136 item in arrayList)
		{
			Array.Copy(BitConverter.GetBytes(item.method_1()), 0, byte_0, int_0, 2);
			switch (item.method_2())
			{
			case Enum183.const_0:
				if (item.method_1() == 4)
				{
					double num4 = smethod_2((int)item.method_4());
					if (shape_0 != null && (shape_0.IsFlippedHorizontally ^ shape_0.IsFlippedVertically))
					{
						num4 = 0.0 - num4;
					}
					if (num4 < 0.0)
					{
						num4 += 360.0;
					}
					int value = smethod_1((float)num4);
					Array.Copy(BitConverter.GetBytes(value), 0, byte_0, int_0 + 2, 4);
				}
				else
				{
					Array.Copy(BitConverter.GetBytes((int)item.method_4()), 0, byte_0, int_0 + 2, 4);
				}
				break;
			case Enum183.const_1:
			{
				Color color_ = (Color)item.method_4();
				if (Class1178.smethod_0(color_))
				{
					ushort num3 = item.method_1();
					if (num3 == 448)
					{
						byte_0[int_0 + 2] = 64;
					}
					byte_0[int_0 + 5] = 8;
				}
				else
				{
					byte_0[int_0 + 2] = color_.R;
					byte_0[int_0 + 3] = color_.G;
					byte_0[int_0 + 4] = color_.B;
				}
				break;
			}
			case Enum183.const_2:
			{
				byte[] bytes = Encoding.Unicode.GetBytes((string)item.method_4());
				Array.Copy(BitConverter.GetBytes(bytes.Length + 2), 0, byte_0, int_0 + 2, 4);
				Array.Copy(bytes, 0, byte_0, num2, bytes.Length);
				num2 += bytes.Length + 2;
				break;
			}
			case Enum183.const_4:
			{
				byte[] array2 = (byte[])item.method_4();
				Array.Copy(BitConverter.GetBytes(array2.Length), 0, byte_0, int_0 + 2, 4);
				Array.Copy(array2, 0, byte_0, num2, array2.Length);
				num2 += array2.Length;
				break;
			}
			case Enum183.const_5:
			{
				byte[] array = (byte[])item.method_4();
				Array.Copy(BitConverter.GetBytes(array.Length - 6), 0, byte_0, int_0 + 2, 4);
				Array.Copy(array, 0, byte_0, num2, array.Length);
				num2 += array.Length;
				break;
			}
			}
			int_0 += 6;
		}
		return length + 8;
	}
}
