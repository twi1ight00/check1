using System;
using System.Collections.Generic;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Warnings;
using ns33;
using ns49;
using ns60;
using ns62;
using ns63;

namespace ns15;

internal sealed class Class856
{
	private const uint uint_0 = 1024u;

	private const uint uint_1 = 2048u;

	private const uint uint_2 = 3072u;

	private const uint uint_3 = 4096u;

	public const bool bool_0 = false;

	private Presentation presentation_0;

	private Class2985 class2985_0;

	private ISaveOptions isaveOptions_0;

	private List<Class878> list_0 = new List<Class878>();

	private Dictionary<IPPImage, List<Class2911>> dictionary_0 = new Dictionary<IPPImage, List<Class2911>>();

	private uint uint_4;

	private uint uint_5;

	private uint uint_6;

	private uint uint_7;

	private uint uint_8;

	private int int_0;

	private Class2717 class2717_0;

	private Class2720 class2720_0;

	private Class2743 class2743_0;

	private readonly Dictionary<IMasterSlide, Class2718> dictionary_1 = new Dictionary<IMasterSlide, Class2718>();

	private readonly Dictionary<ILayoutSlide, uint> dictionary_2 = new Dictionary<ILayoutSlide, uint>();

	private readonly Dictionary<ISlide, uint> dictionary_3 = new Dictionary<ISlide, uint>();

	private Dictionary<Class2694, ISlide> dictionary_4 = new Dictionary<Class2694, ISlide>();

	private uint[] uint_9;

	private Dictionary<IMasterSlide, Class2894[]> dictionary_5 = new Dictionary<IMasterSlide, Class2894[]>();

	private Class2894[] class2894_0;

	private Class2894[] class2894_1;

	private Class201 class201_0;

	private bool bool_1;

	private int int_1;

	private readonly Dictionary<uint, uint> dictionary_6 = new Dictionary<uint, uint>();

	private static byte[] byte_0 = new byte[183]
	{
		0, 2, 15, 16, 0, 2, 13, 14, 1, 21,
		1, 2, 7, 9, 8, 1, 2, 13, 14, 1,
		2, 13, 21, 1, 2, 13, 23, 1, 2, 13,
		20, 1, 2, 13, 19, 1, 2, 13, 18, 2,
		21, 3, 4, 7, 9, 8, 2, 18, 3, 4,
		7, 1, 13, 8, 3, 13, 14, 14, 8, 3,
		13, 14, 20, 8, 3, 13, 20, 14, 8, 3,
		13, 14, 22, 8, 3, 13, 22, 14, 8, 3,
		13, 14, 19, 8, 3, 13, 19, 14, 8, 3,
		13, 14, 24, 8, 3, 13, 24, 14, 8, 3,
		13, 22, 18, 8, 3, 13, 19, 19, 9, 3,
		13, 14, 19, 9, 3, 13, 19, 14, 10, 4,
		13, 14, 19, 19, 10, 4, 13, 19, 19, 19,
		11, 4, 13, 19, 19, 19, 11, 4, 13, 19,
		19, 14, 13, 4, 13, 19, 19, 14, 14, 5,
		13, 19, 19, 19, 19, 15, 1, 19, 16, 2,
		13, 14, 16, 5, 13, 14, 19, 14, 19, 16,
		3, 13, 19, 14, 17, 2, 17, 18, 18, 3,
		17, 18, 20
	};

	public Presentation DomPresentation => presentation_0;

	public Class2985 PptBinaryFile => class2985_0;

	public Dictionary<IMasterSlide, Class2718> MasterSlideToMainMasterContainer => dictionary_1;

	public Dictionary<ILayoutSlide, uint> TitleLayoutMasterSlideToSlideId => dictionary_2;

	public Dictionary<ISlide, uint> SlideToSlideId => dictionary_3;

	public ISaveOptions SaveOptions
	{
		get
		{
			return isaveOptions_0;
		}
		set
		{
			isaveOptions_0 = value;
		}
	}

	public List<Class878> PatternBlips => list_0;

	public Dictionary<IPPImage, List<Class2911>> BlipPibs => dictionary_0;

	public Class2894[] PptCurrentTextMasterStyleList
	{
		get
		{
			return class2894_0;
		}
		set
		{
			class2894_0 = value;
		}
	}

	public Class2894[] PptDefaultTextMasterStyleList
	{
		get
		{
			return class2894_1;
		}
		set
		{
			class2894_1 = value;
		}
	}

	public Class2717 PptCurrentMasterOrSlideContainer
	{
		get
		{
			return class2717_0;
		}
		set
		{
			class2717_0 = value;
		}
	}

	public Class2743 PptCurrentOfficeArtFdg
	{
		get
		{
			return class2743_0;
		}
		set
		{
			class2743_0 = value;
		}
	}

	public Class2720 PptCurrentNotesContainer
	{
		get
		{
			return class2720_0;
		}
		set
		{
			class2720_0 = value;
		}
	}

	public Class2644 PptOfficeArtDggContainer => class2985_0.PowerPointDocumentStream.DocumentContainer.DrawingGroup.OfficeArtDgg;

	public Dictionary<Class2694, ISlide> InternalHyperlinks => dictionary_4;

	public Dictionary<IMasterSlide, Class2894[]> DelayedMasterStyles => dictionary_5;

	public bool NotLicensed
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

	public int TextlTxId
	{
		get
		{
			return ++int_1;
		}
		set
		{
			int_1 = value;
		}
	}

	public Class201 CurrentShapeContext
	{
		get
		{
			return class201_0;
		}
		set
		{
			class201_0 = value;
		}
	}

	public Dictionary<uint, uint> ShapeIdToOfficeArtFSPSpidMap => dictionary_6;

	public Class856(Presentation domPresentation, Class2985 pptBinaryFile)
	{
		if (domPresentation == null)
		{
			throw new ArgumentNullException();
		}
		presentation_0 = domPresentation;
		class2985_0 = pptBinaryFile;
		uint_9 = smethod_0();
	}

	private static uint[] smethod_0()
	{
		List<uint> list = new List<uint>();
		int num = byte_0.Length;
		int i = 0;
		int num2 = 0;
		int num4;
		for (; i < num; i += 2 + num4)
		{
			uint num3 = (uint)((byte_0[i + 1] & 0x10) << 27);
			num4 = byte_0[i + 1] & 0xF;
			for (int j = 0; j < num4; j++)
			{
				num3 |= smethod_1((Enum384)byte_0[i + 2 + j]);
			}
			list.Add(num3);
			list.Add((uint)(byte_0[i] + (num2 << 16)));
			num2++;
		}
		return list.ToArray();
	}

	private static uint smethod_1(Enum384 placeholderType)
	{
		if (placeholderType == Enum384.const_0)
		{
			return 0u;
		}
		int num = (byte)placeholderType - 1;
		if (num > 0)
		{
			return (uint)(1 << num);
		}
		return 1u;
	}

	private uint method_0(Class2888 slideAtom)
	{
		uint num = 0u;
		for (int i = 0; i < 8; i++)
		{
			num |= smethod_1(slideAtom.RgPlaceholderTypes[i]);
		}
		return num;
	}

	private void method_1(Class2888 slideAtom, int mapOffcet)
	{
		int num = byte_0[mapOffcet + 1] & 0xF;
		for (int i = 0; i < num; i++)
		{
			slideAtom.RgPlaceholderTypes[i] = (Enum384)byte_0[mapOffcet + 2 + i];
		}
	}

	internal bool method_2(Class2888 slideAtom)
	{
		int num = 0;
		while (true)
		{
			if (num < 8)
			{
				if (slideAtom.RgPlaceholderTypes[num] != 0)
				{
					break;
				}
				num++;
				continue;
			}
			return false;
		}
		return true;
	}

	internal void method_3(Class2888 slideAtom, bool isMaster)
	{
		bool flag;
		if (!(flag = method_2(slideAtom)) && slideAtom.Geom == Enum451.const_11)
		{
			return;
		}
		int num;
		if (!flag)
		{
			num = byte_0.Length;
			int i;
			for (i = 0; i < num; i += (2 + byte_0[i + 1]) & 0xF)
			{
				if ((Enum451)byte_0[i] == slideAtom.Geom && isMaster == ((byte_0[i + 1] & 0x10) != 0))
				{
					method_1(slideAtom, i);
					break;
				}
			}
			if (i >= num)
			{
				throw new NotImplementedException("Have no matched Geom type for SlideAtom!");
			}
			return;
		}
		uint num2 = method_0(slideAtom) | (isMaster ? 2147483648u : 0u);
		num = uint_9.Length >> 1;
		List<uint> list = new List<uint>();
		uint num3 = 32u;
		for (int j = 0; j < num; j++)
		{
			uint num4 = uint_9[j * 2];
			if (((num4 ^ 0xFFFFFFFFu) & num2) == 0)
			{
				uint num5 = Class1165.smethod_19(num2 ^ num4);
				if (num3 > num5)
				{
					list = new List<uint>();
					num3 = num5;
				}
				if (num5 <= num3)
				{
					list.Add(uint_9[j * 2 + 1]);
				}
			}
		}
		uint num6 = 65535u;
		if (list.Count == 1)
		{
			num6 = (list[0] >> 16) & 0xFFFFu;
			slideAtom.Geom = (Enum451)((int)list[0] & 0xFFFF);
		}
		if (list.Count > 1)
		{
			for (int k = 0; k < list.Count; k++)
			{
				if ((list[k] & 0xFFFF) == (uint)slideAtom.Geom)
				{
					num6 = (list[k] >> 16) & 0xFFFFu;
					break;
				}
			}
			if (num6 == 65535)
			{
				num6 = 0u;
				throw new NotImplementedException();
			}
		}
		if (num6 < 65535)
		{
			int num7 = 0;
			while (num6 != 0)
			{
				num7 += (2 + byte_0[num7 + 1]) & 0xF;
				num6--;
			}
			method_1(slideAtom, num7);
		}
	}

	public int method_4()
	{
		return ++int_0;
	}

	public void method_5(Class2911 odrawBlipPib, IPPImage ppImage)
	{
		if (!dictionary_0.TryGetValue(ppImage, out var value))
		{
			dictionary_0.Add(ppImage, value = new List<Class2911>());
		}
		value.Add(odrawBlipPib);
	}

	public Class2947 method_6(uint dgid)
	{
		Class2947 @class = null;
		foreach (Class2947 item in PptOfficeArtDggContainer.DrawingGroup.Rgidcl)
		{
			if (item.Dgid == dgid)
			{
				@class = item;
				break;
			}
		}
		if (@class == null)
		{
			throw new ArgumentException("There is no OfficeArtIDCL record for specified drawing ID.");
		}
		return @class;
	}

	public Class878 method_7(PatternStyle patternStyle)
	{
		Class878 @class = null;
		foreach (Class878 item in list_0)
		{
			if (item.PatternStyle == patternStyle)
			{
				@class = item;
				break;
			}
		}
		if (@class == null)
		{
			list_0.Add(@class = new Class878(patternStyle, this));
		}
		return @class;
	}

	public uint method_8(bool incFdgCsp)
	{
		uint num = method_11();
		if (incFdgCsp)
		{
			PptCurrentOfficeArtFdg.ShapeCount++;
			PptOfficeArtDggContainer.DrawingGroup.CspSaved++;
		}
		PptCurrentOfficeArtFdg.SpidLast = num;
		PptOfficeArtDggContainer.DrawingGroup.SpidMax = num + 1;
		method_6(PptCurrentOfficeArtFdg.DrawingId).CspidCur = num - method_14() + 1;
		return num;
	}

	public uint method_9()
	{
		uint num = (uint)(PptOfficeArtDggContainer.DrawingGroup.Rgidcl.Count + 1);
		PptOfficeArtDggContainer.DrawingGroup.CdgSaved++;
		Class2947 item = new Class2947(num, 0u);
		PptOfficeArtDggContainer.DrawingGroup.Rgidcl.Add(item);
		return num;
	}

	public uint method_10()
	{
		return ++uint_4;
	}

	private uint method_11()
	{
		if (PptCurrentNotesContainer != null)
		{
			return method_14() + uint_8++;
		}
		if (PptCurrentMasterOrSlideContainer != null)
		{
			if (PptCurrentMasterOrSlideContainer is Class2718)
			{
				return method_14() + uint_5++;
			}
			if (PptCurrentMasterOrSlideContainer is Class2719)
			{
				return method_14() + uint_6++;
			}
		}
		throw new NotImplementedException();
	}

	public Class2855 method_12(uint persistIdRef)
	{
		Class2688 documentContainer = class2985_0.PowerPointDocumentStream.DocumentContainer;
		Class2855 @class = null;
		@class = method_13(persistIdRef, documentContainer.MasterList);
		if (@class != null)
		{
			return @class;
		}
		@class = method_13(persistIdRef, documentContainer.SlideList);
		if (@class != null)
		{
			return @class;
		}
		@class = method_13(persistIdRef, documentContainer.NotesList);
		if (@class != null)
		{
			return @class;
		}
		return null;
	}

	public Class2855 method_13(uint persistIdRef, Class2731 slideList)
	{
		return slideList?.ContentRecords.method_9(persistIdRef);
	}

	private uint method_14()
	{
		if (PptCurrentNotesContainer != null)
		{
			if (PptCurrentMasterOrSlideContainer != null)
			{
				return 4096u;
			}
			return 3072u;
		}
		if (PptCurrentMasterOrSlideContainer != null)
		{
			if (PptCurrentMasterOrSlideContainer is Class2718)
			{
				return 1024u;
			}
			if (PptCurrentMasterOrSlideContainer is Class2719)
			{
				return 2048u;
			}
		}
		throw new NotImplementedException();
	}

	internal void method_15(string description, WarningType warningType)
	{
		if (SaveOptions != null && SaveOptions.WarningCallback != null)
		{
			Class1176 @class = new Class1176(description, warningType);
			@class.SendWarning(SaveOptions.WarningCallback);
		}
	}
}
