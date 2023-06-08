using System.Collections.Generic;
using Aspose.Slides;
using ns60;
using ns62;
using ns63;

namespace ns15;

internal sealed class Class854
{
	private readonly Class857 class857_0;

	private readonly IBaseSlide ibaseSlide_0;

	private readonly Class2888 class2888_0;

	private readonly Class2714 class2714_0;

	private readonly Class2671 class2671_0;

	private readonly Class2893 class2893_0;

	private Dictionary<Class2669, Class852> dictionary_0 = new Dictionary<Class2669, Class852>();

	private Dictionary<int, TextStyle> dictionary_1;

	private List<Class2951> list_0;

	private readonly uint uint_0;

	private readonly Class2727 class2727_0;

	private readonly IDictionary<uint, IShape> idictionary_0 = new Dictionary<uint, IShape>();

	public Class857 DeserializationContext => class857_0;

	public IBaseSlide DomSlide => ibaseSlide_0;

	public Class2888 SlideAtom => class2888_0;

	public Class2714 DrawingContainer => class2714_0;

	public Class2893 SlideShowSlideInfo => class2893_0;

	public Class2671 GroupShapeContainer => class2671_0;

	public Dictionary<Class2669, Class852> FrameToPlaceholder => dictionary_0;

	public Dictionary<int, TextStyle> TxMasterStyles
	{
		get
		{
			return dictionary_1;
		}
		set
		{
			dictionary_1 = value;
		}
	}

	public uint ReferrenceId => uint_0;

	public Class2727 ProgTags => class2727_0;

	public List<Class2951> SubFrames => list_0;

	public IDictionary<uint, IShape> Shapes => idictionary_0;

	public Class854(BaseSlide domSlide, Class2717 pptMasterOrSlideContainer, Class857 deserializationContext)
	{
		class857_0 = deserializationContext;
		ibaseSlide_0 = domSlide;
		class2888_0 = pptMasterOrSlideContainer.SlideAtom;
		class2714_0 = pptMasterOrSlideContainer.Drawing;
		Class2688 documentContainer = deserializationContext.DocumentContainer;
		if (class2888_0 == null || class2714_0 == null)
		{
			throw new PptException("Can't open presentation. MasterOrSlideContainer is broken.");
		}
		list_0 = documentContainer.method_14(pptMasterOrSlideContainer.PersistId);
		domSlide.BaseSlidePPTUnsupportedProps.SlideId = pptMasterOrSlideContainer.SlideId;
		domSlide.BaseSlidePPTUnsupportedProps.SlidePersistAtom_FShouldCollapse = list_0[0].SlidePersist.FShouldCollapse;
		class2727_0 = pptMasterOrSlideContainer.SlideProgTagsContainer;
		class2671_0 = smethod_0(class2714_0.OfficeArtDg, out var _);
		class2893_0 = pptMasterOrSlideContainer.SlideShowSlideInfoAtom;
		deserializationContext.method_1(pptMasterOrSlideContainer.SlideId, this);
	}

	public static Class2671 smethod_0(Class2643 officeArtDg, out List<Class2670> nonGroupSpContainers)
	{
		nonGroupSpContainers = null;
		List<Class2623> records = officeArtDg.Records;
		Class2671 @class = null;
		for (int i = 0; i < records.Count; i++)
		{
			if (@class == null)
			{
				@class = records[i] as Class2671;
			}
			if (records[i] is Class2670 item)
			{
				if (nonGroupSpContainers == null)
				{
					nonGroupSpContainers = new List<Class2670>();
				}
				nonGroupSpContainers.Add(item);
			}
		}
		return @class;
	}

	private static void smethod_1(List<Class2623> shapeContainersList, Class2671 groupContainer)
	{
		if (groupContainer == null)
		{
			return;
		}
		for (int i = 0; i < groupContainer.Records.Count; i++)
		{
			if (groupContainer.Records[i] is Class2670)
			{
				shapeContainersList.Add(groupContainer.Records[i]);
			}
			else if (groupContainer.Records[i] is Class2671)
			{
				smethod_1(shapeContainersList, groupContainer.Records[i] as Class2671);
			}
		}
	}

	public static List<Class2623> smethod_2(Class2643 officeArtDg, out List<Class2670> nonGroupSpContainers)
	{
		List<Class2623> list = new List<Class2623>();
		Class2671 @class = smethod_0(officeArtDg, out nonGroupSpContainers);
		if (@class != null)
		{
			smethod_1(list, @class);
		}
		return list;
	}
}
