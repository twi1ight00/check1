using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aspose.Slides;
using ns16;
using ns24;
using ns33;
using ns4;
using ns62;
using ns7;

namespace ns15;

internal sealed class Class200
{
	private long[] long_0;

	internal int int_0;

	internal int int_1;

	internal Class2934 class2934_0;

	internal Class2934 class2934_1;

	internal Class2934 class2934_2;

	internal Class2934 class2934_3;

	internal Class2934 class2934_4;

	internal long long_1;

	internal long long_2;

	[CompilerGenerated]
	private Class540 class540_0;

	[CompilerGenerated]
	private List<Class541> list_0;

	[CompilerGenerated]
	private Class342.Enum164[] enum164_0;

	internal Class540 DomGeometry
	{
		[CompilerGenerated]
		get
		{
			return class540_0;
		}
		[CompilerGenerated]
		set
		{
			class540_0 = value;
		}
	}

	internal List<Class541> DomGeometryGuides
	{
		[CompilerGenerated]
		get
		{
			return list_0;
		}
		[CompilerGenerated]
		set
		{
			list_0 = value;
		}
	}

	internal Class342.Enum164[] guideValueFlags
	{
		[CompilerGenerated]
		get
		{
			return enum164_0;
		}
		[CompilerGenerated]
		set
		{
			enum164_0 = value;
		}
	}

	internal Class200(Class540 domGeometry, Class2834 shapePrimaryOptions)
	{
		DomGeometry = domGeometry;
		int_0 = 21600;
		int_1 = 21600;
		if (shapePrimaryOptions.Properties[Enum426.const_59] is Class2911 @class)
		{
			int_0 = (int)@class.Value;
		}
		if (shapePrimaryOptions.Properties[Enum426.const_60] is Class2911 class2)
		{
			int_1 = (int)class2.Value;
		}
		long_1 = method_7(int_0);
		long_2 = method_7(int_1);
		class2934_0 = shapePrimaryOptions.Properties[Enum426.const_62] as Class2934;
		class2934_1 = shapePrimaryOptions.Properties[Enum426.const_63] as Class2934;
		class2934_2 = shapePrimaryOptions.Properties[Enum426.const_77] as Class2934;
		class2934_3 = shapePrimaryOptions.Properties[Enum426.const_78] as Class2934;
		class2934_4 = shapePrimaryOptions.Properties[Enum426.const_72] as Class2934;
		method_0();
	}

	internal Class200(Class540 domGeometry, Class204 domShapeImp)
	{
		DomGeometry = domGeometry;
		long_1 = domShapeImp.Width;
		long_2 = domShapeImp.Height;
		class2934_0 = domShapeImp.method_1();
		class2934_1 = domShapeImp.method_0();
		class2934_2 = domShapeImp.method_3();
		class2934_3 = domShapeImp.method_4();
		class2934_4 = domShapeImp.method_2();
		method_0();
	}

	private void method_0()
	{
		DomGeometry.RawPreset = ShapeType.Custom;
		method_1();
		method_2();
		method_3();
		method_4();
		DomGeometry.GeomGuides = DomGeometryGuides.ToArray();
		method_5();
		method_6();
		method_9();
	}

	private void method_1()
	{
		if (class2934_0.CbElem != 4 && class2934_0.CbElem != 8 && class2934_0.CbElem != 65520)
		{
			long_0 = null;
			return;
		}
		long_0 = new long[class2934_0.NElems * 2];
		if (class2934_0.CbElem != 4 && class2934_0.CbElem != 65520)
		{
			for (int i = 0; i < class2934_0.NElems; i++)
			{
				ulong num = class2934_0[i];
				long_0[2 * i] = method_7((int)(num & 0xFFFFFFFFL));
				long_0[2 * i + 1] = method_7((int)(num >> 32));
			}
		}
		else
		{
			for (int j = 0; j < class2934_0.NElems; j++)
			{
				uint num2 = (uint)class2934_0[j];
				long_0[2 * j] = method_7((short)(num2 & 0xFFFF));
				long_0[2 * j + 1] = method_7((short)(num2 >> 16));
			}
		}
	}

	private void method_2()
	{
		DomGeometryGuides = new List<Class541>();
		if (class2934_2 == null || class2934_2.NElems == 0)
		{
			return;
		}
		int lastUsedAdjustment = -1;
		if (class2934_2.CbElem != 8)
		{
			throw new PptReadException("Wrong SG structure size in IMsoArray.");
		}
		for (int i = 0; i < class2934_2.NElems; i++)
		{
			DomGeometryGuides.Add(null);
		}
		for (int j = 0; j < class2934_2.NElems; j++)
		{
			Class2952 @class = new Class2952(class2934_2.method_1(j));
			long num = (@class.CalculatedParam1 ? method_8(@class.Param1, ref lastUsedAdjustment) : @class.Param1);
			long num2 = (@class.CalculatedParam2 ? method_8(@class.Param2, ref lastUsedAdjustment) : @class.Param2);
			long num3 = (@class.CalculatedParam3 ? method_8(@class.Param3, ref lastUsedAdjustment) : @class.Param3);
			string name = "G" + j;
			switch (@class.Sgf)
			{
			case Enum429.const_0:
				DomGeometryGuides[j] = new Class541(name, Enum113.const_1, num, num2, num3);
				break;
			case Enum429.const_1:
				if (num3 == 0L)
				{
					num3 = 1L;
				}
				DomGeometryGuides[j] = new Class541(name, Enum113.const_0, num, num2, num3);
				break;
			case Enum429.const_2:
				DomGeometryGuides[j] = new Class541(name, Enum113.const_2, num, num2, 2L);
				break;
			case Enum429.const_3:
				DomGeometryGuides[j] = new Class541(name, Enum113.const_4, num, 0L, 0L);
				break;
			case Enum429.const_4:
				DomGeometryGuides[j] = new Class541(name, Enum113.const_9, num, num2, 0L);
				break;
			case Enum429.const_5:
				DomGeometryGuides[j] = new Class541(name, Enum113.const_8, num, num2, 0L);
				break;
			case Enum429.const_6:
				DomGeometryGuides[j] = new Class541(name, Enum113.const_3, num, num2, num3);
				break;
			case Enum429.const_7:
				DomGeometryGuides[j] = new Class541(name, Enum113.const_10, num, num2, num3);
				break;
			case Enum429.const_8:
				DomGeometryGuides[j] = new Class541(name, Enum113.const_0, method_13(DomGeometryGuides, Enum113.const_5, num, num2, 0L), 65536L, 60000L);
				break;
			case Enum429.const_9:
				DomGeometryGuides[j] = new Class541(name, Enum113.const_13, num, method_13(DomGeometryGuides, Enum113.const_0, num2, 60000L, 65536L), 0L);
				break;
			case Enum429.const_10:
				DomGeometryGuides[j] = new Class541(name, Enum113.const_7, num, method_13(DomGeometryGuides, Enum113.const_0, num2, 60000L, 65536L), 0L);
				break;
			case Enum429.const_11:
				DomGeometryGuides[j] = new Class541(name, Enum113.const_6, num, num2, num3);
				break;
			case Enum429.const_12:
				DomGeometryGuides[j] = new Class541(name, Enum113.const_12, num, num2, num3);
				break;
			case Enum429.const_13:
				DomGeometryGuides[j] = new Class541(name, Enum113.const_14, num, 0L, 0L);
				break;
			case Enum429.const_14:
				DomGeometryGuides[j] = new Class541(name, Enum113.const_1, num, method_13(DomGeometryGuides, Enum113.const_0, 65536L, method_13(DomGeometryGuides, Enum113.const_1, num2, 0L, num3), 1L), 0L);
				break;
			case Enum429.const_15:
			{
				long num4 = method_13(DomGeometryGuides, Enum113.const_0, num, 0L, num2);
				DomGeometryGuides[j] = new Class541(name, Enum113.const_0, num3, method_13(DomGeometryGuides, Enum113.const_14, method_13(DomGeometryGuides, Enum113.const_1, 1L, 0L, method_13(DomGeometryGuides, Enum113.const_0, num4, num4, 0L)), 0L, 0L), 0L);
				break;
			}
			case Enum429.const_16:
				DomGeometryGuides[j] = new Class541(name, Enum113.const_15, num, method_13(DomGeometryGuides, Enum113.const_0, num2, 60000L, 65536L), 0L);
				break;
			}
		}
		if (lastUsedAdjustment >= 0)
		{
			DomGeometry.Adjustments = new Class341[lastUsedAdjustment + 1];
		}
	}

	private void method_3()
	{
		if (long_0 == null)
		{
			return;
		}
		List<Class516> list = new List<Class516>();
		List<long> list2 = new List<long>(long_0.Length + 16);
		Enum271 fillMode = Enum271.const_1;
		bool stroke = true;
		bool extrusionOk = true;
		int num = 0;
		int num2 = 0;
		int num3 = 0;
		bool flag = true;
		int num4 = 0;
		List<Enum115> list3 = new List<Enum115>();
		if (class2934_1 != null && class2934_1.NElems != 0)
		{
			while (num3 < class2934_1.NElems)
			{
				try
				{
					Class2953 @class = Class2953.smethod_0((ushort)class2934_1[num3++]);
					switch (@class.Type)
					{
					case Enum431.const_0:
					{
						if (flag)
						{
							list3.Add(Enum115.const_1);
							method_14(list2, long_0, num2, 2);
							num2 += 2;
							flag = false;
						}
						method_14(list2, long_0, num2, @class.Segments * 2);
						num2 += @class.Segments * 2;
						for (int j = 0; j < @class.Segments; j++)
						{
							list3.Add(Enum115.const_2);
						}
						break;
					}
					case Enum431.const_1:
					{
						if (flag)
						{
							list3.Add(Enum115.const_1);
							method_14(list2, long_0, num2, 2);
							num2 += 2;
							flag = false;
						}
						method_14(list2, long_0, num2, @class.Segments * 6);
						num2 += @class.Segments * 6;
						for (int i = 0; i < @class.Segments; i++)
						{
							list3.Add(Enum115.const_5);
						}
						break;
					}
					case Enum431.const_2:
						list3.Add(Enum115.const_1);
						method_14(list2, long_0, num2, 2);
						num2 += 2;
						flag = false;
						break;
					case Enum431.const_3:
						list3.Add(Enum115.const_0);
						break;
					case Enum431.const_4:
						list.Add(new Class516(list3.ToArray(), list2, 0, list2.Count, long_1, long_2, fillMode, stroke, extrusionOk));
						fillMode = Enum271.const_1;
						stroke = true;
						extrusionOk = true;
						list3.Clear();
						list2.Clear();
						num = list2.Count;
						flag = true;
						break;
					case Enum431.const_5:
					case Enum431.const_6:
					{
						Class2954 class2 = (Class2954)@class;
						switch (class2.Escape)
						{
						case Enum430.const_3:
						case Enum430.const_4:
						case Enum430.const_5:
							if (class2.Segments == 2)
							{
								long param7 = long_0[num2++];
								long param8 = long_0[num2++];
								long num10 = long_0[num2++];
								long param9 = long_0[num2++];
								list3.Add(Enum115.const_1);
								list2.Add(num10);
								list2.Add(method_13(DomGeometryGuides, Enum113.const_2, param8, param9, 2L));
								list3.Add(Enum115.const_3);
								long param10 = method_13(DomGeometryGuides, Enum113.const_1, num10, 0L, param7);
								long param11 = method_13(DomGeometryGuides, Enum113.const_1, num10, 0L, param7);
								list2.Add(method_13(DomGeometryGuides, Enum113.const_0, param10, 1L, 2L));
								list2.Add(method_13(DomGeometryGuides, Enum113.const_0, param11, 1L, 2L));
								list2.Add(0L);
								list2.Add(21600000L);
								break;
							}
							if ((int)class2.Segments % 4 != 0)
							{
								throw new Exception("Invalid data autoshape segment" + class2);
							}
							for (num4 = class2.Segments; num4 > 0; num4 -= 4)
							{
								long num11 = long_0[num2++];
								long num12 = long_0[num2++];
								long num13 = long_0[num2++];
								long num14 = long_0[num2++];
								long num15 = long_0[num2++];
								long num16 = long_0[num2++];
								long param12 = long_0[num2++];
								long param13 = long_0[num2++];
								if (flag)
								{
									list3.Add(Enum115.const_1);
									flag = false;
								}
								else
								{
									list3.Add(Enum115.const_2);
								}
								list2.Add(num15);
								list2.Add(num16);
								list3.Add(Enum115.const_3);
								long param14 = method_13(DomGeometryGuides, Enum113.const_1, num13, 0L, num11);
								long param15 = method_13(DomGeometryGuides, Enum113.const_1, num14, 0L, num12);
								list2.Add(method_13(DomGeometryGuides, Enum113.const_0, param14, 1L, 2L));
								list2.Add(method_13(DomGeometryGuides, Enum113.const_0, param15, 1L, 2L));
								long param16 = method_13(DomGeometryGuides, Enum113.const_2, num11, num13, 2L);
								long param17 = method_13(DomGeometryGuides, Enum113.const_2, num12, num14, 2L);
								long param18 = method_13(DomGeometryGuides, Enum113.const_1, num15, 0L, param16);
								long param19 = method_13(DomGeometryGuides, Enum113.const_1, num16, 0L, param17);
								long param20 = method_13(DomGeometryGuides, Enum113.const_1, param12, 0L, param16);
								long param21 = method_13(DomGeometryGuides, Enum113.const_1, param13, 0L, param17);
								long num17 = method_13(DomGeometryGuides, Enum113.const_5, param18, param19, 0L);
								long param22 = method_13(DomGeometryGuides, Enum113.const_5, param20, param21, 0L);
								list2.Add(num17);
								long num18 = method_13(DomGeometryGuides, Enum113.const_1, param22, 0L, num17);
								if (class2.Escape != Enum430.const_5)
								{
									long item = method_13(DomGeometryGuides, Enum113.const_3, num18, method_13(DomGeometryGuides, Enum113.const_1, num18, 0L, 21600000L), num18);
									list2.Add(item);
								}
								else
								{
									long item = method_13(DomGeometryGuides, Enum113.const_3, num18, num18, method_13(DomGeometryGuides, Enum113.const_1, num18, 21600000L, 0L));
									list2.Add(item);
								}
							}
							break;
						default:
							if (class2.Segments != 0)
							{
								if (flag)
								{
									list3.Add(Enum115.const_1);
									method_14(list2, long_0, num2, 2);
									num2 += 2;
									flag = false;
								}
								long num5 = long_0[num2 - 2];
								long num6 = long_0[num2 - 1];
								long param = long_0[num2];
								long param2 = long_0[num2 + 1];
								long param3 = method_13(DomGeometryGuides, Enum113.const_1, param, 0L, num5);
								long param4 = method_13(DomGeometryGuides, Enum113.const_1, param2, 0L, num6);
								long num7 = ((class2.Escape != Enum430.const_7) ? 1 : (-1));
								long param5 = method_13(DomGeometryGuides, Enum113.const_3, method_13(DomGeometryGuides, Enum113.const_0, param3, param4, 1L), num7, -num7);
								num4 = class2.Segments;
								while (num4-- > 0)
								{
									param = long_0[num2++];
									param2 = long_0[num2++];
									param3 = method_13(DomGeometryGuides, Enum113.const_1, param, 0L, num5);
									param4 = method_13(DomGeometryGuides, Enum113.const_1, param2, 0L, num6);
									long param6 = method_13(DomGeometryGuides, Enum113.const_0, param3, param4, param5);
									long num8 = method_13(DomGeometryGuides, Enum113.const_0, param3, 1L, 2L);
									long num9 = method_13(DomGeometryGuides, Enum113.const_0, param4, 1L, 2L);
									list3.Add(Enum115.const_5);
									list2.Add(method_13(DomGeometryGuides, Enum113.const_3, param6, num5, method_13(DomGeometryGuides, Enum113.const_1, num5, num8, 0L)));
									list2.Add(method_13(DomGeometryGuides, Enum113.const_3, param6, method_13(DomGeometryGuides, Enum113.const_1, num6, num9, 0L), num6));
									list2.Add(method_13(DomGeometryGuides, Enum113.const_3, param6, method_13(DomGeometryGuides, Enum113.const_1, param, 0L, num8), param));
									list2.Add(method_13(DomGeometryGuides, Enum113.const_3, param6, param2, method_13(DomGeometryGuides, Enum113.const_1, param2, 0L, num9)));
									list2.Add(param);
									list2.Add(param2);
								}
							}
							break;
						case Enum430.const_10:
							fillMode = Enum271.const_0;
							break;
						case Enum430.const_11:
							stroke = false;
							break;
						}
						break;
					}
					}
				}
				catch (Exception ex)
				{
					Class1165.smethod_28(ex);
				}
			}
		}
		else
		{
			if (long_0.Length < 4)
			{
				return;
			}
			list3.Capacity = long_0.Length / 2;
			list3.Add(Enum115.const_1);
		}
		if (num < list2.Count)
		{
			list.Add(new Class516(list3.ToArray(), list2, 0, list2.Count, long_1, long_2, fillMode, stroke, extrusionOk));
		}
		DomGeometry.Paths = list.ToArray();
	}

	private void method_4()
	{
		guideValueFlags = new Class342.Enum164[DomGeometryGuides.Count + 11];
		int num = 0;
		int num2 = -1;
		for (int i = 0; i < 11; i++)
		{
			guideValueFlags[i] = Class342.Enum164.flag_5;
		}
		guideValueFlags[7] |= Class342.Enum164.flag_1;
		guideValueFlags[8] |= Class342.Enum164.flag_3;
		guideValueFlags[9] |= Class342.Enum164.flag_2;
		guideValueFlags[10] |= Class342.Enum164.flag_4;
		int num3 = 10;
		while (num3 > 0 && num < guideValueFlags.Length)
		{
			num2 = num;
			num = guideValueFlags.Length;
			num3 = 0;
			for (int j = Math.Max(num2, 11); j < guideValueFlags.Length; j++)
			{
				if ((guideValueFlags[j] & Class342.Enum164.flag_5) != Class342.Enum164.flag_5)
				{
					Class541 @class = DomGeometryGuides[j - 11];
					Class342.Enum164 @enum = method_11(guideValueFlags, @class.Data1);
					Class342.Enum164 enum2 = method_11(guideValueFlags, @class.Data2);
					Class342.Enum164 enum3 = method_11(guideValueFlags, @class.Data3);
					if ((@enum & Class342.Enum164.flag_5) == Class342.Enum164.flag_5 && (enum2 & Class342.Enum164.flag_5) == Class342.Enum164.flag_5 && (enum3 & Class342.Enum164.flag_5) == Class342.Enum164.flag_5)
					{
						guideValueFlags[j] = @enum | enum2 | enum3;
						num3++;
						@class.Data1 = method_10(DomGeometryGuides, @class.Data1, long_1, long_2);
						@class.Data2 = method_10(DomGeometryGuides, @class.Data2, long_1, long_2);
						@class.Data3 = method_10(DomGeometryGuides, @class.Data3, long_1, long_2);
					}
					else if (j < num)
					{
						num = j;
					}
				}
			}
		}
		Class342.Enum164 enum4 = Class342.Enum164.flag_1 | Class342.Enum164.flag_2 | Class342.Enum164.flag_3 | Class342.Enum164.flag_4;
		Class516[] paths = DomGeometry.Paths;
		if (paths == null)
		{
			return;
		}
		for (int k = 0; k < paths.Length; k++)
		{
			long[] data = paths[k].Data;
			bool flag;
			if (!(flag = paths[k].Width < -27273042329600L || paths[k].Height < -27273042329600L))
			{
				for (int l = 0; l < data.Length; l++)
				{
					if (data[l] < -27273042329600L)
					{
						int num4 = (int)(-27273042329600L - data[l] - 1L);
						if ((guideValueFlags[num4] & enum4) != 0)
						{
							flag = true;
							break;
						}
					}
				}
			}
			if (flag)
			{
				paths[k].method_3(DomGeometryGuides, guideValueFlags);
			}
		}
	}

	private void method_5()
	{
		if (class2934_3 == null || class2934_3.NElems == 0)
		{
			return;
		}
		if (class2934_3.CbElem != 8 && class2934_3.CbElem != 16)
		{
			throw new PptReadException("Wront element size in IMsoArray p_Inscape_complex property.");
		}
		DomGeometry.RectTopLeft = new Class887[class2934_3.NElems];
		DomGeometry.RectBottomRight = new Class887[class2934_3.NElems];
		Class519 @class = new Class519(long_1, long_2);
		List<Class541> list = new List<Class541>(DomGeometry.GeomGuides);
		for (int i = 0; i < class2934_3.NElems; i++)
		{
			byte[] data = class2934_3.method_1(i);
			int arg;
			int arg2;
			int arg3;
			int arg4;
			if (class2934_3.CbElem == 8)
			{
				arg = Class1162.smethod_0(data, 0);
				arg2 = Class1162.smethod_0(data, 2);
				arg3 = Class1162.smethod_0(data, 4);
				arg4 = Class1162.smethod_0(data, 6);
			}
			else
			{
				arg = Class1162.smethod_6(data, 0);
				arg2 = Class1162.smethod_6(data, 4);
				arg3 = Class1162.smethod_6(data, 8);
				arg4 = Class1162.smethod_6(data, 12);
			}
			long x = @class.method_0(list, method_7(arg), guideValueFlags);
			long y = @class.method_1(list, method_7(arg2), guideValueFlags);
			if (DomGeometry.RectTopLeft != null)
			{
				DomGeometry.RectTopLeft[i] = new Class887(x, y);
			}
			x = @class.method_0(list, method_7(arg3), guideValueFlags);
			y = @class.method_1(list, method_7(arg4), guideValueFlags);
			if (DomGeometry.RectBottomRight != null)
			{
				DomGeometry.RectBottomRight[i] = new Class887(x, y);
			}
			DomGeometry.GeomGuides = list.ToArray();
		}
	}

	private void method_6()
	{
		if (class2934_4 == null)
		{
			return;
		}
		if (class2934_4.CbElem != 4 && class2934_4.CbElem != 8 && class2934_4.CbElem != 65520)
		{
			DomGeometry.ConnSites = new Class888[0];
			return;
		}
		Class887[] array = new Class887[class2934_4.NElems];
		if (class2934_4.CbElem != 4 && class2934_4.CbElem != 65520)
		{
			for (int i = 0; i < class2934_4.NElems; i++)
			{
				ulong num = class2934_4[i];
				array[i] = new Class887(method_7((int)(num & 0xFFFFFFFFL)), method_7((int)(num >> 32)));
			}
		}
		else
		{
			for (int j = 0; j < class2934_4.NElems; j++)
			{
				uint num2 = (uint)class2934_4[j];
				array[j] = new Class887(method_7((short)(num2 & 0xFFFF)), method_7((short)(num2 >> 16)));
			}
		}
		DomGeometry.ConnSites = new Class888[array.Length];
		for (int k = 0; k < array.Length; k++)
		{
			DomGeometry.ConnSites[k] = new Class888(array[k].X, array[k].Y, 0L);
		}
	}

	private long method_7(int arg)
	{
		if (arg < -2147479552)
		{
			int num = arg & 0x7FFFFFFF;
			return -27273042329600L - num - 11L - 1L;
		}
		return arg;
	}

	private long method_8(int arg, ref int lastUsedAdjustment)
	{
		if (arg >= 1024 && arg <= 1151)
		{
			int num = arg - 1024;
			return -27273042329600L - num - 11L - 1L;
		}
		if (arg >= 327 && arg <= 334)
		{
			int num2 = arg - 327;
			if (num2 > lastUsedAdjustment)
			{
				lastUsedAdjustment = num2;
			}
			return num2 + 27273042316900L + 1L;
		}
		if (arg >= 320 && arg <= 323)
		{
			int num3 = arg - 320 + 7;
			return -27273042329600L - num3 - 1L;
		}
		return arg;
	}

	private void method_9()
	{
		Class342.Enum164[] array = new Class342.Enum164[DomGeometry.GeomGuides.Length + 11];
		int[] array2 = new int[DomGeometry.GeomGuides.Length + 11];
		Class541[] array3 = new Class541[DomGeometry.GeomGuides.Length];
		int num = 0;
		int num2 = 0;
		int num3 = -1;
		for (int i = 0; i < 11; i++)
		{
			array[i] = Class342.Enum164.flag_5;
			array2[i] = i;
		}
		int num4 = 10;
		int num5 = 0;
		while (num4 > 0 && num2 < array.Length)
		{
			num5++;
			num3 = num2;
			num2 = array.Length;
			num4 = 0;
			for (int j = Math.Max(num3, 11); j < array.Length; j++)
			{
				if ((array[j] & Class342.Enum164.flag_5) != Class342.Enum164.flag_5)
				{
					Class541 @class = DomGeometry.GeomGuides[j - 11];
					Class342.Enum164 @enum = method_11(array, @class.Data1);
					Class342.Enum164 enum2 = method_11(array, @class.Data2);
					Class342.Enum164 enum3 = method_11(array, @class.Data3);
					if ((@enum & Class342.Enum164.flag_5) == Class342.Enum164.flag_5 && (enum2 & Class342.Enum164.flag_5) == Class342.Enum164.flag_5 && (enum3 & Class342.Enum164.flag_5) == Class342.Enum164.flag_5)
					{
						array[j] = @enum | enum2 | enum3;
						array2[j] = num + 11;
						array3[num++] = @class;
						num4++;
					}
					else if (j < num2)
					{
						num2 = j;
					}
				}
			}
		}
		if (num < array3.Length)
		{
			for (int k = 11; k < array.Length; k++)
			{
				if ((array[k] & Class342.Enum164.flag_5) != Class342.Enum164.flag_5)
				{
					Class541 class2 = DomGeometry.GeomGuides[k - 11];
					array2[k] = num + 11;
					array3[num++] = class2;
				}
			}
		}
		if (num5 == 1)
		{
			return;
		}
		DomGeometry.GeomGuides = array3;
		for (int l = 0; l < DomGeometry.GeomGuides.Length; l++)
		{
			Class541 class3 = DomGeometry.GeomGuides[l];
			class3.Data1 = method_12(array2, class3.Data1);
			class3.Data2 = method_12(array2, class3.Data2);
			class3.Data3 = method_12(array2, class3.Data3);
		}
		for (int m = 0; m < DomGeometry.Paths.Length; m++)
		{
			long[] data = DomGeometry.Paths[m].Data;
			for (int n = 0; n < data.Length; n++)
			{
				data[n] = method_12(array2, data[n]);
			}
		}
		if (DomGeometry.RectTopLeft != null)
		{
			for (int num6 = 0; num6 < DomGeometry.RectTopLeft.Length; num6++)
			{
				DomGeometry.RectTopLeft[num6].X = method_12(array2, DomGeometry.RectTopLeft[num6].X);
				DomGeometry.RectTopLeft[num6].Y = method_12(array2, DomGeometry.RectTopLeft[num6].Y);
			}
		}
		if (DomGeometry.RectBottomRight != null)
		{
			for (int num7 = 0; num7 < DomGeometry.RectBottomRight.Length; num7++)
			{
				DomGeometry.RectBottomRight[num7].X = method_12(array2, DomGeometry.RectBottomRight[num7].X);
				DomGeometry.RectBottomRight[num7].Y = method_12(array2, DomGeometry.RectBottomRight[num7].Y);
			}
		}
		if (DomGeometry.ConnSites != null)
		{
			for (int num8 = 0; num8 < DomGeometry.ConnSites.Length; num8++)
			{
				DomGeometry.ConnSites[num8].Pos.X = method_12(array2, DomGeometry.ConnSites[num8].Pos.X);
				DomGeometry.ConnSites[num8].Pos.Y = method_12(array2, DomGeometry.ConnSites[num8].Pos.Y);
				DomGeometry.ConnSites[num8].Direction = method_12(array2, DomGeometry.ConnSites[num8].Direction);
			}
		}
		if (DomGeometry.AdjustHandles != null)
		{
			for (int num9 = 0; num9 < DomGeometry.AdjustHandles.Length; num9++)
			{
				DomGeometry.AdjustHandles[num9].class887_0.X = method_12(array2, DomGeometry.AdjustHandles[num9].class887_0.X);
				DomGeometry.AdjustHandles[num9].class887_0.Y = method_12(array2, DomGeometry.AdjustHandles[num9].class887_0.Y);
				DomGeometry.AdjustHandles[num9].long_0 = method_12(array2, DomGeometry.AdjustHandles[num9].long_0);
				DomGeometry.AdjustHandles[num9].long_3 = method_12(array2, DomGeometry.AdjustHandles[num9].long_3);
				DomGeometry.AdjustHandles[num9].long_1 = method_12(array2, DomGeometry.AdjustHandles[num9].long_1);
				DomGeometry.AdjustHandles[num9].long_4 = method_12(array2, DomGeometry.AdjustHandles[num9].long_4);
				DomGeometry.AdjustHandles[num9].long_2 = method_12(array2, DomGeometry.AdjustHandles[num9].long_2);
				DomGeometry.AdjustHandles[num9].long_5 = method_12(array2, DomGeometry.AdjustHandles[num9].long_5);
			}
		}
	}

	private long method_10(List<Class541> geomGuides, long coordinate, long width, long height)
	{
		if (coordinate >= -27273042329611L && coordinate <= -27273042329608L)
		{
			long num = coordinate;
			if (num <= -27273042329608L && num >= -27273042329611L)
			{
				switch (num - -27273042329611L)
				{
				case 0L:
					coordinate = height;
					break;
				case 1L:
					coordinate = width;
					break;
				case 2L:
				case 3L:
					coordinate = 0L;
					break;
				}
			}
		}
		if (coordinate > 27273042316900L)
		{
			coordinate = method_13(geomGuides, Enum113.const_0, coordinate, 21600L, 100000L);
		}
		return coordinate;
	}

	private Class342.Enum164 method_11(Class342.Enum164[] guideFlags, long coordinate)
	{
		if (coordinate > 27273042316900L)
		{
			return Class342.Enum164.flag_5;
		}
		if (coordinate < -27273042329600L)
		{
			int num = (int)(-27273042329600L - coordinate - 1L);
			return guideFlags[num];
		}
		return Class342.Enum164.flag_5;
	}

	private long method_12(int[] indexMap, long coordinate)
	{
		if (coordinate < -27273042329600L)
		{
			int num = (int)(-27273042329601L - coordinate);
			num = indexMap[num];
			return -27273042329601L - num;
		}
		return coordinate;
	}

	private long method_13(List<Class541> geomGuides, Enum113 operation, long param1, long param2, long param3)
	{
		return Class342.smethod_2(geomGuides, operation, param1, param2, param3);
	}

	private void method_14(List<long> outputPoints, long[] inputPoints, int startPosition, int count)
	{
		int num = startPosition + count;
		while (startPosition < num)
		{
			outputPoints.Add(inputPoints[startPosition++]);
		}
	}
}
