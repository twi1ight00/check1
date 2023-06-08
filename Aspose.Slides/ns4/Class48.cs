using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aspose.Slides;

namespace ns4;

internal class Class48
{
	[CompilerGenerated]
	private sealed class Class49
	{
		public Enum2 enum2_0;

		public IFontData ifontData_0;

		public bool method_0(Class52 fd)
		{
			return smethod_0(enum2_0, fd, ifontData_0);
		}
	}

	[CompilerGenerated]
	private sealed class Class50
	{
		public Enum2 enum2_0;

		public IFontData ifontData_0;

		public bool method_0(Class52 fd)
		{
			return smethod_0(enum2_0, fd, ifontData_0);
		}
	}

	[CompilerGenerated]
	private sealed class Class51
	{
		public int int_0;

		public bool method_0(Class52 entry)
		{
			if (entry.PptFontTableIndex.HasValue)
			{
				return entry.PptFontTableIndex.Value == int_0;
			}
			return false;
		}
	}

	public const ushort ushort_0 = ushort.MaxValue;

	public const string string_0 = "Arial";

	public const Enum2 enum2_0 = Enum2.const_0;

	private List<Class52> list_0 = new List<Class52>();

	private bool bool_0;

	[CompilerGenerated]
	private static Comparison<Class52> comparison_0;

	public int Count => list_0.Count;

	public IList<Class52> Entries => list_0.AsReadOnly();

	public bool LocalPresentationContext
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

	public void CopyFrom(Class48 fontsList)
	{
		foreach (Class52 item in fontsList.list_0)
		{
			Add(item.FontClass, item.FontData, noExistsCheck: false, item.PptFontTableIndex);
		}
	}

	public IFontData method_0(Enum2 fontClass, IFontData fontData)
	{
		return method_5(Add(fontClass, fontData)).FontData;
	}

	public ushort Add(Enum2 fontClass, IFontData fontData)
	{
		return Add(fontClass, fontData, noExistsCheck: false, null);
	}

	public IList<Class52> method_1()
	{
		Class52[] array = new Class52[list_0.Count];
		list_0.CopyTo(array);
		List<Class52> list = new List<Class52>(array);
		list.Sort(delegate(Class52 left, Class52 right)
		{
			if (!left.PptFontTableIndex.HasValue && !right.PptFontTableIndex.HasValue)
			{
				return 1;
			}
			if (!left.PptFontTableIndex.HasValue)
			{
				return 1;
			}
			return (!right.PptFontTableIndex.HasValue) ? (-1) : left.PptFontTableIndex.Value.CompareTo(right.PptFontTableIndex.Value);
		});
		return list;
	}

	public ushort Add(Enum2 fontClass, IFontData fontData, bool noExistsCheck, int? pptFontTableIndex)
	{
		checked
		{
			if (fontData != null && !string.IsNullOrEmpty(fontData.FontName))
			{
				if (fontData.FontName == null)
				{
					int num = IndexOf(Enum2.const_0, new FontData("Arial"));
					list_0[num].LocalPresentationFont = LocalPresentationContext;
					return (ushort)num;
				}
				Enum2 fontClass2 = ((!(fontData.FontName == "Arial")) ? fontClass : Enum2.const_0);
				if (!noExistsCheck && Contains(fontClass2, fontData))
				{
					int num2 = IndexOf(fontClass2, fontData);
					list_0[num2].LocalPresentationFont = LocalPresentationContext;
					return (ushort)num2;
				}
				if (list_0.Count >= 65535)
				{
					throw new InvalidOperationException();
				}
				list_0.Add(new Class52(fontClass2, fontData, pptFontTableIndex, LocalPresentationContext));
				return (ushort)(list_0.Count - 1);
			}
			return ushort.MaxValue;
		}
	}

	private bool Contains(Enum2 fontClass, IFontData fontData)
	{
		return list_0.Exists((Class52 fd) => smethod_0(fontClass, fd, fontData));
	}

	public int IndexOf(Enum2 fontClass, IFontData fontData)
	{
		return list_0.FindIndex((Class52 fd) => smethod_0(fontClass, fd, fontData));
	}

	internal static bool smethod_0(Enum2 fontClass, Class52 fontListEntry, IFontData fontData)
	{
		bool flag = fontListEntry.FontClass == fontClass && fontListEntry.FontData.FontName == fontData.FontName;
		FontData fontData2 = fontData as FontData;
		FontData fontData3 = fontListEntry.FontData as FontData;
		if (fontData2 != null)
		{
			flag = flag && fontData2.PitchFamily == fontData3.PitchFamily;
		}
		return flag;
	}

	public void Clear()
	{
		list_0.Clear();
	}

	public bool method_2(IFontData sourceFont, IFontData destFont)
	{
		bool result = false;
		Enum2[] array = (Enum2[])Enum.GetValues(typeof(Enum2));
		int num = 0;
		while (true)
		{
			if (num < array.Length)
			{
				Enum2 fontClass = array[num];
				int num2 = IndexOf(fontClass, sourceFont);
				if (num2 != -1)
				{
					Class52 @class = method_5(num2);
					if (!(@class.FontData is FontData))
					{
						break;
					}
					@class.ReplaceWithFontData = destFont;
					result = true;
				}
				num++;
				continue;
			}
			return result;
		}
		return false;
	}

	public bool method_3(IFontData fontSource, IFontData fontDest, FontSubstCondition fontSubstRule)
	{
		bool result = false;
		Enum2[] array = (Enum2[])Enum.GetValues(typeof(Enum2));
		int num = 0;
		while (true)
		{
			if (num < array.Length)
			{
				Enum2 fontClass = array[num];
				int num2 = IndexOf(fontClass, fontSource);
				if (num2 != -1)
				{
					Class52 @class = method_5(num2);
					if (@class.SubstitutedForRendering)
					{
						throw new InvalidOperationException("Font is already subsituted");
					}
					if (!(@class.FontData is FontData))
					{
						break;
					}
					@class.ReplaceForRenderingWithFontData = fontDest;
					@class.ReplaceForRenderingFontSubstRule = fontSubstRule;
					result = true;
				}
				num++;
				continue;
			}
			return result;
		}
		return false;
	}

	public void method_4()
	{
		foreach (Class52 entry in Entries)
		{
			entry.ReplaceForRenderingWithFontData = null;
		}
	}

	public Class52 method_5(int index)
	{
		if (index != 65535 && index < list_0.Count)
		{
			return list_0[index];
		}
		int num = IndexOf(Enum2.const_0, new FontData("Arial"));
		if (num != -1)
		{
			return list_0[num];
		}
		if (list_0.Count == 0)
		{
			Add(Enum2.const_0, new FontData("Arial"));
		}
		return list_0[0];
	}

	public Class52 method_6(int index)
	{
		int num = list_0.FindIndex((Class52 entry) => entry.PptFontTableIndex.HasValue && entry.PptFontTableIndex.Value == index);
		if (num == -1)
		{
			return method_5(IndexOf(Enum2.const_0, new FontData("Arial")));
		}
		return method_5(num);
	}

	public int method_7()
	{
		int num = 0;
		foreach (Class52 item in list_0)
		{
			if (item.PptFontTableIndex.HasValue)
			{
				num++;
			}
		}
		return num;
	}

	public void method_8()
	{
		foreach (Class52 item in list_0)
		{
			item.method_0();
		}
	}

	public void method_9(bool isLocal)
	{
		foreach (Class52 item in list_0)
		{
			item.LocalPresentationFont = isLocal;
		}
	}

	public static Enum2 smethod_1(string typeface)
	{
		if (FontData.smethod_0(typeface))
		{
			return Enum2.const_0;
		}
		if (FontData.smethod_1(typeface))
		{
			return Enum2.const_1;
		}
		if (FontData.smethod_2(typeface))
		{
			return Enum2.const_2;
		}
		return Enum2.const_0;
	}

	[CompilerGenerated]
	private static int smethod_2(Class52 left, Class52 right)
	{
		if (!left.PptFontTableIndex.HasValue && !right.PptFontTableIndex.HasValue)
		{
			return 1;
		}
		if (!left.PptFontTableIndex.HasValue)
		{
			return 1;
		}
		if (!right.PptFontTableIndex.HasValue)
		{
			return -1;
		}
		return left.PptFontTableIndex.Value.CompareTo(right.PptFontTableIndex.Value);
	}
}
