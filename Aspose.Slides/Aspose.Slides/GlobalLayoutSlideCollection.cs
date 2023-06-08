using System;
using System.Collections;
using System.Collections.Generic;
using ns16;
using ns4;

namespace Aspose.Slides;

public sealed class GlobalLayoutSlideCollection : LayoutSlideCollection, IEnumerable<ILayoutSlide>, ICollection, IEnumerable, ILayoutSlideCollection, IGlobalLayoutSlideCollection
{
	ILayoutSlideCollection IGlobalLayoutSlideCollection.AsILayoutSlideCollection => this;

	internal GlobalLayoutSlideCollection(Presentation parent)
		: base(parent)
	{
	}

	public ILayoutSlide AddClone(ILayoutSlide sourceLayout)
	{
		LayoutSlide layoutSlide = (LayoutSlide)sourceLayout;
		lock (base.PresentationInternal)
		{
			if (layoutSlide.Presentation == base.PresentationInternal)
			{
				return Class1026.smethod_3(layoutSlide.MasterSlide, layoutSlide);
			}
			IMasterSlide destMaster = ((MasterSlideCollection)base.PresentationInternal.Masters).method_2(layoutSlide.MasterSlide, cloneLinkedLayouts: false);
			return AddClone(layoutSlide, destMaster);
		}
	}

	public ILayoutSlide AddClone(ILayoutSlide sourceLayout, IMasterSlide destMaster)
	{
		LayoutSlide layoutSlide = (LayoutSlide)sourceLayout;
		if (destMaster.Presentation != base.PresentationInternal)
		{
			throw new PptxEditException("Master must belong to the target presentation.");
		}
		LayoutSlide layoutSlide2;
		if (layoutSlide.Presentation == base.PresentationInternal)
		{
			layoutSlide2 = (LayoutSlide)Class1026.smethod_3(destMaster, layoutSlide);
		}
		else
		{
			layoutSlide2 = (LayoutSlide)Class1026.smethod_3(destMaster, layoutSlide);
			layoutSlide2.method_8(layoutSlide);
			layoutSlide2.method_7(layoutSlide.Presentation.DefaultTextStyle);
		}
		return layoutSlide2;
	}

	public ILayoutSlide Add(IMasterSlide master, SlideLayoutType layoutType, string layoutName)
	{
		if (master == null)
		{
			throw new ArgumentNullException("master");
		}
		if (master.Presentation != base.PresentationInternal)
		{
			throw new ArgumentException("Master slide must be from the same presentation.");
		}
		LayoutSlide layoutSlide = Class1081.smethod_0(master, layoutType);
		if (layoutName != null)
		{
			if (smethod_1(layoutSlide).Contains(layoutName))
			{
				throw new ArgumentException("The layout name \"" + layoutName + "\" is already in use. Please modify the name.");
			}
			layoutSlide.Name = layoutName;
		}
		else
		{
			smethod_0(layoutSlide);
		}
		return layoutSlide;
	}

	internal static void smethod_0(ILayoutSlide layoutDest)
	{
		List<string> list = smethod_1(layoutDest);
		string name = layoutDest.Name;
		int num = 1;
		while (list.Contains(layoutDest.Name))
		{
			layoutDest.Name = num + "_" + name;
			num++;
		}
	}

	private static List<string> smethod_1(ILayoutSlide givenLayout)
	{
		IMasterSlide masterSlide = givenLayout.MasterSlide;
		List<string> list = new List<string>();
		foreach (ILayoutSlide layoutSlide in masterSlide.LayoutSlides)
		{
			if (layoutSlide != givenLayout)
			{
				list.Add(layoutSlide.Name);
			}
		}
		return list;
	}
}
