using System.Collections.Generic;
using Aspose.Slides;
using ns24;
using ns60;
using ns62;
using ns63;

namespace ns15;

internal class Class1054
{
	private static readonly Dictionary<Enum382, IHyperlink> dictionary_0 = new Dictionary<Enum382, IHyperlink>
	{
		{
			Enum382.const_0,
			Hyperlink.NoAction
		},
		{
			Enum382.const_1,
			Hyperlink.NextSlide
		},
		{
			Enum382.const_2,
			Hyperlink.PreviousSlide
		},
		{
			Enum382.const_3,
			Hyperlink.FirstSlide
		},
		{
			Enum382.const_4,
			Hyperlink.LastSlide
		},
		{
			Enum382.const_5,
			Hyperlink.LastVievedSlide
		},
		{
			Enum382.const_6,
			Hyperlink.EndShow
		}
	};

	private static readonly Dictionary<IHyperlink, Enum382> dictionary_1 = new Dictionary<IHyperlink, Enum382>
	{
		{
			Hyperlink.NoAction,
			Enum382.const_0
		},
		{
			Hyperlink.NextSlide,
			Enum382.const_1
		},
		{
			Hyperlink.PreviousSlide,
			Enum382.const_2
		},
		{
			Hyperlink.FirstSlide,
			Enum382.const_3
		},
		{
			Hyperlink.LastSlide,
			Enum382.const_4
		},
		{
			Hyperlink.LastVievedSlide,
			Enum382.const_5
		},
		{
			Hyperlink.EndShow,
			Enum382.const_6
		}
	};

	internal static Hyperlink smethod_0(Class2882 interactiveInfoAtom, Class857 deserializationContext)
	{
		Class2688 documentContainer = deserializationContext.DocumentContainer;
		switch (interactiveInfoAtom.Action)
		{
		case Enum381.const_3:
			if (interactiveInfoAtom.Jump >= Enum382.const_0 && (int)interactiveInfoAtom.Jump < dictionary_0.Count)
			{
				return (Hyperlink)dictionary_0[interactiveInfoAtom.Jump];
			}
			return Hyperlink.NoAction;
		case Enum381.const_4:
		{
			Class2699 exObjList = documentContainer.ExObjList;
			if (exObjList != null)
			{
				Class2694 @class = exObjList.method_10(interactiveInfoAtom.ExHyperlinkIdRef);
				if (@class != null)
				{
					if (interactiveInfoAtom.HyperlinkType != Enum383.const_6 && interactiveInfoAtom.HyperlinkType != Enum383.const_7 && interactiveInfoAtom.HyperlinkType != Enum383.const_8)
					{
						if (interactiveInfoAtom.HyperlinkType == Enum383.const_5)
						{
							Class2843 location = @class.Location;
							if (location != null)
							{
								Hyperlink hyperlink = new Hyperlink(external: false, location.String, "ppaction://hlinksldjump");
								deserializationContext.InternalHyperlinks.Add(hyperlink);
								return hyperlink;
							}
						}
					}
					else
					{
						string text = "";
						Class2843 target = @class.Target;
						if (target != null)
						{
							text = target.String;
							Class2843 location2 = @class.Location;
							if (location2 != null)
							{
								text = text + "#" + location2.String;
							}
							return new Hyperlink(text);
						}
					}
				}
			}
			return Hyperlink.NoAction;
		}
		default:
			return Hyperlink.NoAction;
		case Enum381.const_6:
			return Hyperlink.Media;
		}
	}

	internal static Class2711 smethod_1(IHyperlink hyperlink, Class856 context)
	{
		if (hyperlink == null)
		{
			return null;
		}
		Class2688 documentContainer = context.PptBinaryFile.PowerPointDocumentStream.DocumentContainer;
		Class2699 @class = documentContainer.method_12();
		uint num = @class.ExObjListAtom.ExObjIdSeed++;
		Class2694 class2 = new Class2694();
		@class.Records.Add(class2);
		Class2869 class3 = new Class2869();
		class2.Records.Add(class3);
		class3.ExHyperlinkId = num;
		Class2711 class4 = new Class2711(null);
		Class2882 class5 = new Class2882();
		class5.ExHyperlinkIdRef = num;
		class4.Records.Add(class5);
		Class343 pPTXUnsupportedProps = ((Hyperlink)hyperlink).PPTXUnsupportedProps;
		if (!(pPTXUnsupportedProps.InternalUrl == "*") && !((Hyperlink)hyperlink == Hyperlink.NoAction))
		{
			if (hyperlink.ExternalUrl != null)
			{
				string externalUrl = hyperlink.ExternalUrl;
				class2.Records.Add(new Class2843(externalUrl, 0));
				if (externalUrl.Contains("#"))
				{
					class2.Records.Add(new Class2843(externalUrl.Substring(0, externalUrl.LastIndexOf('#')), 1));
					class2.Records.Add(new Class2843(externalUrl.Remove(0, externalUrl.LastIndexOf('#') + 1), 3));
				}
				else
				{
					class2.Records.Add(new Class2843(externalUrl, 1));
				}
				class5.Action = Enum381.const_4;
				class5.HyperlinkType = Enum383.const_6;
				smethod_4(documentContainer, class5, "");
			}
			else if (hyperlink.TargetSlide != null)
			{
				if (hyperlink.TargetSlide.Presentation != context.DomPresentation)
				{
					class5.Action = Enum381.const_0;
				}
				else
				{
					context.InternalHyperlinks.Add(class2, hyperlink.TargetSlide);
					class5.Action = Enum381.const_4;
					class5.HyperlinkType = Enum383.const_5;
					smethod_4(documentContainer, class5, "");
				}
			}
			else if (!((Hyperlink)hyperlink == Hyperlink.NextSlide) && !((Hyperlink)hyperlink == Hyperlink.PreviousSlide) && !((Hyperlink)hyperlink == Hyperlink.FirstSlide) && !((Hyperlink)hyperlink == Hyperlink.LastSlide) && !((Hyperlink)hyperlink == Hyperlink.LastVievedSlide) && !((Hyperlink)hyperlink == Hyperlink.EndShow))
			{
				if ((Hyperlink)hyperlink == Hyperlink.Media)
				{
					class5.Action = Enum381.const_6;
				}
			}
			else
			{
				class5.Action = Enum381.const_3;
				class5.Jump = dictionary_1[hyperlink];
				class5.HyperlinkType = Enum383.const_1;
				switch (dictionary_1[hyperlink])
				{
				case Enum382.const_1:
					class2.Records.Add(new Class2843("NEXT", 0));
					class2.Records.Add(new Class2843("-1,-1,NEXT", 3));
					class5.HyperlinkType = Enum383.const_0;
					break;
				case Enum382.const_2:
					class2.Records.Add(new Class2843("PREV", 0));
					class2.Records.Add(new Class2843("-1,-1,PREV", 3));
					class5.HyperlinkType = Enum383.const_1;
					break;
				case Enum382.const_3:
					class2.Records.Add(new Class2843("FIRST", 0));
					class2.Records.Add(new Class2843("-1,-1,FIRST", 3));
					class5.HyperlinkType = Enum383.const_2;
					break;
				case Enum382.const_4:
					class2.Records.Add(new Class2843("LAST", 0));
					class2.Records.Add(new Class2843("-1,-1,LAST", 3));
					class5.HyperlinkType = Enum383.const_3;
					break;
				case Enum382.const_5:
					class2.Records.Add(new Class2843("VIEWED", 0));
					class2.Records.Add(new Class2843("-1,-1,VIEWED", 3));
					break;
				case Enum382.const_6:
					class2.Records.Add(new Class2843("ENDSHOW", 0));
					class2.Records.Add(new Class2843("-1,-1,ENDSHOW", 3));
					break;
				}
				smethod_4(documentContainer, class5, "");
			}
			return class4;
		}
		class5.Action = Enum381.const_0;
		return class4;
	}

	internal static void smethod_2(IHyperlink hyperlink, Class2982 subRecordsList, Class856 context)
	{
		if (subRecordsList != null)
		{
			Class2711 @class = smethod_1(hyperlink, context);
			if (@class != null)
			{
				subRecordsList.method_2(@class);
			}
		}
	}

	internal static void smethod_3(IHyperlink hyperlink, Class2670 shapeContainer, Class856 context)
	{
		if (shapeContainer != null)
		{
			Class2711 @class = smethod_1(hyperlink, context);
			if (@class != null)
			{
				shapeContainer.ClientData.Records.Add(@class);
			}
		}
	}

	private static Class2695 smethod_4(Class2688 documentContainer, Class2882 interactiveInfoAtom, string screenTip)
	{
		if (interactiveInfoAtom.ExHyperlinkIdRef == 0)
		{
			return null;
		}
		Class2683 @class = documentContainer.DocInfoList.ProgTags.method_8();
		Class2695[] rgExternalHyperlink = @class.RgExternalHyperlink9;
		int num = 0;
		Class2695 class2;
		while (true)
		{
			if (num < rgExternalHyperlink.Length)
			{
				class2 = rgExternalHyperlink[num];
				if (class2.ExHyperlinkRefAtom.ExHyperlinkId == interactiveInfoAtom.ExHyperlinkIdRef)
				{
					break;
				}
				num++;
				continue;
			}
			Class2695 class3 = new Class2695();
			@class.Records.Add(class3);
			Class2869 class4 = new Class2869();
			class3.Records.Add(class4);
			class4.ExHyperlinkId = interactiveInfoAtom.ExHyperlinkIdRef;
			class3.method_2(new Class2843(screenTip, 0));
			Class2870 class5 = new Class2870();
			class3.Records.Add(class5);
			class5.Flags = 1u;
			return class3;
		}
		return class2;
	}
}
