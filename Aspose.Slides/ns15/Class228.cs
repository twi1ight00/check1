using System;
using System.Xml;
using Aspose.Slides.Warnings;
using ns16;
using ns56;
using ns57;
using ns60;
using ns63;

namespace ns15;

internal class Class228
{
	public static void smethod_0(Class2306 targetElementData, Class2765 target, Class854 deserializationContext)
	{
		if (target != null)
		{
			switch (target.Header.Type)
			{
			case 11009:
				smethod_1(targetElementData, target);
				break;
			default:
				throw new NotImplementedException();
			case 11003:
				smethod_2(targetElementData, target, deserializationContext);
				break;
			}
		}
	}

	private static void smethod_1(Class2306 targetElementData, Class2765 target)
	{
		if (!(target is Class2766))
		{
			throw new InvalidOperationException();
		}
		targetElementData.delegate2773_0("sldTgt");
	}

	private static void smethod_2(Class2306 targetElementData, Class2765 target, Class854 deserializationContext)
	{
		if (!(target is Class2767 atom))
		{
			throw new InvalidOperationException();
		}
		smethod_3(targetElementData, atom, deserializationContext);
		smethod_4(targetElementData, atom, deserializationContext);
		smethod_5(targetElementData, atom, deserializationContext);
	}

	private static bool smethod_3(Class2306 targetElementData, Class2767 atom, Class854 deserializationContext)
	{
		if (!(atom is Class2770 @class))
		{
			return false;
		}
		Class1838 class2 = (Class1838)targetElementData.delegate2773_0("sndTgt").Object;
		Class857 deserializationContext2 = deserializationContext.DeserializationContext;
		Class2734 soundCollection = deserializationContext2.DocumentContainer.SoundCollection;
		Class2733 class3 = soundCollection.method_5((int)@class.SoundIdRef);
		if (class3 != null)
		{
			deserializationContext2.method_0(class3);
			class2.Name = class3.SoundName.String;
			class2.R_Embed = class3.SoundId.String;
		}
		return true;
	}

	private static bool smethod_4(Class2306 targetElementData, Class2767 atom, Class854 deserializationContext)
	{
		if (!(atom is Class2768 @class))
		{
			return false;
		}
		Class2294 class2 = (Class2294)targetElementData.delegate2773_0("spTgt").Object;
		if (deserializationContext.Shapes.ContainsKey(@class.ShapeIdRef))
		{
			class2.Spid = deserializationContext.Shapes[@class.ShapeIdRef].UniqueId.ToString();
		}
		Class2291 class3 = (Class2291)class2.delegate2773_0("oleChartEl").Object;
		class3.Type = smethod_6(@class.Build);
		if (@class.ChartElementToAnimate >= 0)
		{
			class3.Lvl = (uint)@class.ChartElementToAnimate;
		}
		return true;
	}

	private static bool smethod_5(Class2306 targetElementData, Class2767 atom, Class854 deserializationContext)
	{
		if (!(atom is Class2769 @class))
		{
			return false;
		}
		Class2294 class2 = (Class2294)targetElementData.delegate2773_0("spTgt").Object;
		if (deserializationContext.Shapes.ContainsKey(@class.ShapeIdRef))
		{
			class2.Spid = @class.ShapeIdRef.ToString();
		}
		if (@class.VisualType != 0)
		{
			if (@class.VisualType == Enum401.const_6)
			{
				class2.delegate2773_0("bg");
			}
			else if (@class.VisualType == Enum401.const_2)
			{
				Class2298 class3 = (Class2298)class2.delegate2773_0("txEl").Object;
				Class2239 class4 = (Class2239)class3.delegate2773_0("charRg").Object;
				class4.St = (uint)@class.TextRangeIndexBegin;
				class4.End = (uint)@class.TextRangeIndexEnd;
			}
		}
		return true;
	}

	private static Enum295 smethod_6(Enum403 type)
	{
		return type switch
		{
			Enum403.const_0 => Enum295.const_0, 
			Enum403.const_1 => Enum295.const_1, 
			Enum403.const_2 => Enum295.const_2, 
			Enum403.const_3 => Enum295.const_3, 
			Enum403.const_4 => Enum295.const_4, 
			_ => throw new NotImplementedException(), 
		};
	}

	public static void smethod_7(Class2306 timeTargetElementData, Class2657 timeConditionContainer, Class234 timelineSerializationContext)
	{
		if (timeTargetElementData != null)
		{
			Class2649 @class = new Class2649();
			timeConditionContainer.Records.Add(@class);
			smethod_10(timeTargetElementData, @class, timelineSerializationContext);
		}
	}

	public static void smethod_8(Class2306 timeTargetElementData, Class2654 timeBehaviorContainer, Class234 timelineSerializationContext)
	{
		if (timeTargetElementData != null)
		{
			Class2649 @class = new Class2649();
			timeBehaviorContainer.Records.Add(@class);
			smethod_10(timeTargetElementData, @class, timelineSerializationContext);
		}
	}

	public static void smethod_9(Class2306 timeTargetElementData, Class2650 timeNodeContainer, Class234 timelineSerializationContext)
	{
		if (timeTargetElementData != null)
		{
			Class2649 @class = new Class2649();
			timeNodeContainer.Records.Add(@class);
			smethod_10(timeTargetElementData, @class, timelineSerializationContext);
		}
	}

	private static void smethod_10(Class2306 timeTargetElementData, Class2649 clientVisualElementContainer, Class234 timelineSerializationContext)
	{
		if (timeTargetElementData != null && timeTargetElementData.Target != null)
		{
			if (clientVisualElementContainer == null)
			{
				throw new InvalidOperationException();
			}
			Class2605 target = timeTargetElementData.Target;
			switch (target.Name)
			{
			case "spTgt":
			{
				Class2294 shapeTargetElementData = (Class2294)target.Object;
				smethod_11(shapeTargetElementData, clientVisualElementContainer, timelineSerializationContext);
				break;
			}
			case "sndTgt":
			{
				Class2770 @class = new Class2770();
				clientVisualElementContainer.Records.Add(@class);
				Class1838 class2 = (Class1838)target.Object;
				@class.VisualType = Enum401.const_3;
				if (uint.TryParse(class2.R_Embed, out var result))
				{
					@class.SoundIdRef = result;
					break;
				}
				throw new InvalidOperationException();
			}
			case "sldTgt":
			{
				Class2766 item = new Class2766();
				clientVisualElementContainer.Records.Add(item);
				break;
			}
			default:
				timelineSerializationContext.method_3("Writing of the animation target failed.", WarningType.DataLoss);
				break;
			}
			return;
		}
		throw new InvalidOperationException();
	}

	private static void smethod_11(Class2294 shapeTargetElementData, Class2649 clientVisualElementContainer, Class234 timelineSerializationContext)
	{
		if (shapeTargetElementData == null)
		{
			throw new InvalidOperationException();
		}
		if (clientVisualElementContainer == null)
		{
			throw new InvalidOperationException();
		}
		if (shapeTargetElementData.TargetShape == null)
		{
			if (smethod_12(shapeTargetElementData.Spid, timelineSerializationContext))
			{
				Class2769 @class = new Class2769();
				clientVisualElementContainer.Records.Add(@class);
				@class.VisualType = Enum401.const_0;
				@class.ShapeIdRef = smethod_13(shapeTargetElementData.Spid, timelineSerializationContext);
				@class.TextRangeIndexBegin = -1;
				@class.TextRangeIndexEnd = -1;
			}
			return;
		}
		switch (shapeTargetElementData.TargetShape.Name)
		{
		case "txEl":
		{
			Class2298 class3 = (Class2298)shapeTargetElementData.TargetShape.Object;
			if (class3.Range != null)
			{
				switch (class3.Range.Name)
				{
				case "charRg":
				{
					Class2239 class4 = (Class2239)class3.Range.Object;
					Class2769 class5 = new Class2769();
					clientVisualElementContainer.Records.Add(class5);
					class5.VisualType = Enum401.const_2;
					class5.TextRangeIndexBegin = (int)class4.St;
					class5.TextRangeIndexEnd = (int)class4.End;
					class5.ShapeIdRef = smethod_13(shapeTargetElementData.Spid, timelineSerializationContext);
					break;
				}
				default:
					timelineSerializationContext.method_3("Writing of the animation target failed.", WarningType.DataLoss);
					break;
				}
			}
			break;
		}
		case "bg":
		{
			Class2769 class2 = new Class2769();
			clientVisualElementContainer.Records.Add(class2);
			class2.VisualType = Enum401.const_6;
			class2.ShapeIdRef = smethod_13(shapeTargetElementData.Spid, timelineSerializationContext);
			break;
		}
		default:
			timelineSerializationContext.method_3("Writing of the animation target failed.", WarningType.DataLoss);
			break;
		}
	}

	private static bool smethod_12(string xmlSpid, Class234 timelineSerializationContext)
	{
		if (xmlSpid == null)
		{
			return false;
		}
		uint key = XmlConvert.ToUInt32(xmlSpid);
		return timelineSerializationContext.ShapeIdToOfficeArtFSPSpidMap.ContainsKey(key);
	}

	private static uint smethod_13(string xmlSpid, Class234 timelineSerializationContext)
	{
		uint key = XmlConvert.ToUInt32(xmlSpid);
		if (!timelineSerializationContext.ShapeIdToOfficeArtFSPSpidMap.ContainsKey(key))
		{
			throw new InvalidOperationException();
		}
		return timelineSerializationContext.ShapeIdToOfficeArtFSPSpidMap[key];
	}
}
