using Aspose.Slides;
using ns63;

namespace ns22;

internal abstract class Class262 : Class258
{
	private BaseSlide baseSlide_0;

	private bool bool_0;

	private Class2816[] class2816_0;

	private Class2800 class2800_0;

	private Class2801[] class2801_0;

	private Class2809 class2809_0;

	private Class2889 class2889_0;

	private Class2880 class2880_0;

	private Class2684 class2684_0;

	private Class2788 class2788_0;

	public uint SlideId
	{
		get
		{
			return baseSlide_0.BaseSlidePPTXUnsupportedProps.SlideId;
		}
		set
		{
			baseSlide_0.BaseSlidePPTXUnsupportedProps.SlideId = value;
		}
	}

	public bool SlidePersistAtom_FShouldCollapse
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

	public Class2816[] SlideProgTagsContainer_PP10SlideBinaryTagExtension_RgTextMasterStyleAtom
	{
		get
		{
			return class2816_0;
		}
		set
		{
			class2816_0 = value;
		}
	}

	public Class2800 SlideProgTagsContainer_PP10SlideBinaryTagExtension_LinkedSlideAtom
	{
		get
		{
			return class2800_0;
		}
		set
		{
			class2800_0 = value;
		}
	}

	public Class2801[] SlideProgTagsContainer_PP10SlideBinaryTagExtension_RgLinkedShape10Atom
	{
		get
		{
			return class2801_0;
		}
		set
		{
			class2801_0 = value;
		}
	}

	public Class2809 SlideProgTagsContainer_PP10SlideBinaryTagExtension_SlideFlagsAtom
	{
		get
		{
			return class2809_0;
		}
		set
		{
			class2809_0 = value;
		}
	}

	public Class2889 SlideProgTagsContainer_PP10SlideBinaryTagExtension_SlideTimeAtom
	{
		get
		{
			return class2889_0;
		}
		set
		{
			class2889_0 = value;
		}
	}

	public Class2880 SlideProgTagsContainer_PP10SlideBinaryTagExtension_HashCodeAtom
	{
		get
		{
			return class2880_0;
		}
		set
		{
			class2880_0 = value;
		}
	}

	public Class2684 SlideProgTagsContainer_PP10SlideBinaryTagExtension_BuildListContainer
	{
		get
		{
			return class2684_0;
		}
		set
		{
			class2684_0 = value;
		}
	}

	public Class2788 SlideProgTagsContainer_PP12SlideBinaryTagExtension_RoundTripHeaderFooterDefaultsAtom
	{
		get
		{
			return class2788_0;
		}
		set
		{
			class2788_0 = value;
		}
	}

	public void method_0(BaseSlide parent)
	{
		baseSlide_0 = parent;
	}
}
