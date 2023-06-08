using System;
using System.Drawing;
using Aspose.Slides.Warnings;
using ns16;
using ns18;
using ns56;
using ns57;
using ns60;
using ns62;
using ns63;

namespace ns15;

internal class Class215
{
	public static void smethod_0(Class2265 animBehaviorElementData, Class2650 timeNodeContainer, Class854 deserializationContext)
	{
		if (timeNodeContainer != null && timeNodeContainer.TimeAnimateBehavior != null)
		{
			Class2652 timeAnimateBehavior = timeNodeContainer.TimeAnimateBehavior;
			Class222.smethod_1(animBehaviorElementData.CBhvr, timeNodeContainer, timeAnimateBehavior.Behavior, deserializationContext);
			smethod_1(animBehaviorElementData.delegate2647_0, timeAnimateBehavior);
			animBehaviorElementData.By = ((timeAnimateBehavior.VarBy == null) ? null : timeAnimateBehavior.VarBy.Value);
			animBehaviorElementData.From = ((timeAnimateBehavior.VarFrom == null) ? null : timeAnimateBehavior.VarFrom.Value);
			animBehaviorElementData.To = ((timeAnimateBehavior.VarTo == null) ? null : timeAnimateBehavior.VarTo.Value);
			animBehaviorElementData.Calcmode = smethod_3(timeAnimateBehavior.AnimateBehaviorAtom.CalcMode);
			animBehaviorElementData.ValueType = smethod_5(timeAnimateBehavior.AnimateBehaviorAtom.ValueType);
			return;
		}
		throw new InvalidOperationException();
	}

	private static void smethod_1(Class2300.Delegate2647 addTavListDelegate, Class2652 timeAnimateBehavior)
	{
		if (timeAnimateBehavior.AnimateValueList == null || timeAnimateBehavior.AnimateValueList.RgTimeAnimValueList.Count == 0)
		{
			return;
		}
		Class2300 @class = addTavListDelegate();
		foreach (Class2938 rgTimeAnimValue in timeAnimateBehavior.AnimateValueList.RgTimeAnimValueList)
		{
			Class2299 class2 = @class.delegate2644_0();
			class2.Tm = (rgTimeAnimValue.TimeAnimationValueAtom.Time * 100).ToString();
			Class2272 valElementData = class2.delegate2563_0();
			smethod_2(rgTimeAnimValue, class2, valElementData);
		}
	}

	private static void smethod_2(Class2938 entry, Class2299 tavElementData, Class2272 valElementData)
	{
		Class2760 varValue = entry.VarValue;
		switch (varValue.TimeVariantType)
		{
		case Enum400.const_0:
		{
			Class2761 class7 = varValue as Class2761;
			Class2271 class8 = (Class2271)valElementData.delegate2773_0("boolVal").Object;
			class8.Val = class7.Value;
			break;
		}
		case Enum400.const_1:
		{
			Class2763 class5 = varValue as Class2763;
			Class2274 class6 = (Class2274)valElementData.delegate2773_0("intVal").Object;
			class6.Val = class5.Value;
			break;
		}
		case Enum400.const_2:
		{
			Class2762 class3 = varValue as Class2762;
			Class2273 class4 = (Class2273)valElementData.delegate2773_0("fltVal").Object;
			class4.Val = class3.Value;
			break;
		}
		case Enum400.const_3:
		{
			Class2764 @class = varValue as Class2764;
			Class2275 class2 = (Class2275)valElementData.delegate2773_0("strVal").Object;
			class2.Val = @class.Value;
			break;
		}
		}
		if (entry.VarFormula != null)
		{
			string value = entry.VarFormula.Value;
			if (!string.IsNullOrEmpty(value))
			{
				tavElementData.Fmla = value;
			}
		}
	}

	private static Enum278 smethod_3(uint calcMode)
	{
		return calcMode switch
		{
			0u => Enum278.const_1, 
			1u => Enum278.const_2, 
			2u => Enum278.const_3, 
			_ => Enum278.const_0, 
		};
	}

	private static uint smethod_4(Enum278 calcMode)
	{
		return calcMode switch
		{
			Enum278.const_1 => 0u, 
			Enum278.const_2 => 1u, 
			Enum278.const_3 => 2u, 
			_ => throw new NotImplementedException(), 
		};
	}

	private static Enum379 smethod_5(Enum397 valueType)
	{
		return valueType switch
		{
			Enum397.const_0 => Enum379.const_1, 
			Enum397.const_1 => Enum379.const_2, 
			Enum397.const_2 => Enum379.const_3, 
			_ => Enum379.const_0, 
		};
	}

	private static Enum397 smethod_6(Enum379 valueType)
	{
		return valueType switch
		{
			Enum379.const_1 => Enum397.const_0, 
			Enum379.const_2 => Enum397.const_1, 
			Enum379.const_3 => Enum397.const_2, 
			_ => throw new NotImplementedException(), 
		};
	}

	public static void smethod_7(Class2265 animateBehaviorElementData, Class2650 timeNodeContainer, Class234 timelineSerializationContext)
	{
		if (animateBehaviorElementData != null)
		{
			Class2652 @class = new Class2652();
			timeNodeContainer.Records.Add(@class);
			smethod_8(animateBehaviorElementData, @class);
			smethod_9(animateBehaviorElementData, @class, timelineSerializationContext);
			if (!string.IsNullOrEmpty(animateBehaviorElementData.By))
			{
				Class2764 item = new Class2764(animateBehaviorElementData.By);
				@class.Records.Add(item);
			}
			if (!string.IsNullOrEmpty(animateBehaviorElementData.From))
			{
				Class2764 item2 = new Class2764(animateBehaviorElementData.From);
				@class.Records.Add(item2);
			}
			if (!string.IsNullOrEmpty(animateBehaviorElementData.To))
			{
				Class2764 item3 = new Class2764(animateBehaviorElementData.To);
				@class.Records.Add(item3);
			}
			smethod_11(animateBehaviorElementData.CBhvr, @class, timelineSerializationContext);
		}
	}

	private static void smethod_8(Class2265 animateBehaviorElementData, Class2652 timeAnimateBehaviorContainer)
	{
		if (animateBehaviorElementData == null)
		{
			throw new ArgumentNullException();
		}
		if (timeAnimateBehaviorContainer == null)
		{
			throw new ArgumentNullException();
		}
		Class2745 @class = new Class2745();
		timeAnimateBehaviorContainer.Records.Add(@class);
		if (animateBehaviorElementData.Calcmode != Enum278.const_0)
		{
			@class.FCalcModePropertyUsed = true;
			@class.CalcMode = smethod_4(animateBehaviorElementData.Calcmode);
		}
		else
		{
			@class.FCalcModePropertyUsed = false;
			@class.CalcMode = 0u;
		}
		if (!string.IsNullOrEmpty(animateBehaviorElementData.By))
		{
			@class.FByPropertyUsed = true;
		}
		else
		{
			@class.FByPropertyUsed = false;
		}
		if (!string.IsNullOrEmpty(animateBehaviorElementData.From))
		{
			@class.FFromPropertyUsed = true;
		}
		else
		{
			@class.FFromPropertyUsed = false;
		}
		if (!string.IsNullOrEmpty(animateBehaviorElementData.To))
		{
			@class.FToPropertyUsed = true;
		}
		else
		{
			@class.FToPropertyUsed = false;
		}
		if (animateBehaviorElementData.TavLst != null && animateBehaviorElementData.TavLst.TavList.Length > 0)
		{
			@class.FAnimationValuesPropertyUsed = true;
		}
		else
		{
			@class.FAnimationValuesPropertyUsed = false;
		}
		if (animateBehaviorElementData.ValueType != Enum379.const_0)
		{
			@class.FValueTypePropertyUsed = true;
			@class.ValueType = smethod_6(animateBehaviorElementData.ValueType);
		}
		else
		{
			@class.FValueTypePropertyUsed = false;
			@class.ValueType = Enum397.const_1;
		}
	}

	private static void smethod_9(Class2265 animateBehaviorElementData, Class2652 timeAnimateBehaviorContainer, Class234 timelineSerializationContext)
	{
		if (animateBehaviorElementData == null)
		{
			throw new ArgumentNullException();
		}
		if (timeAnimateBehaviorContainer == null)
		{
			throw new ArgumentNullException();
		}
		if (animateBehaviorElementData.TavLst != null && animateBehaviorElementData.TavLst.TavList.Length != 0)
		{
			Class2653 @class = new Class2653();
			timeAnimateBehaviorContainer.Records.Add(@class);
			Class2299[] tavList = animateBehaviorElementData.TavLst.TavList;
			foreach (Class2299 timeAnimateValueListElementData in tavList)
			{
				smethod_10(timeAnimateValueListElementData, @class, timelineSerializationContext);
			}
		}
	}

	private static void smethod_10(Class2299 timeAnimateValueListElementData, Class2653 timeAnimationValueListContainer, Class234 timelineSerializationContext)
	{
		if (timeAnimateValueListElementData == null)
		{
			throw new ArgumentNullException();
		}
		if (timeAnimationValueListContainer == null)
		{
			throw new ArgumentNullException();
		}
		if (timeAnimateValueListElementData.Val != null)
		{
			if (timeAnimateValueListElementData.Val.Value == null)
			{
				throw new InvalidOperationException();
			}
			Class2746 @class = null;
			if (!string.IsNullOrEmpty(timeAnimateValueListElementData.Tm))
			{
				@class = new Class2746();
				@class.Time = Class225.smethod_17(Class1008.smethod_7(timeAnimateValueListElementData.Tm));
			}
			if (@class == null)
			{
				throw new InvalidOperationException();
			}
			timeAnimationValueListContainer.Records.Add(@class);
			Class2760 class2 = null;
			Class2605 value = timeAnimateValueListElementData.Val.Value;
			Class2764 class7;
			switch (value.Name)
			{
			case "clrVal":
				timelineSerializationContext.method_3("Writing of the animation value list failed.", WarningType.DataLoss);
				goto IL_0150;
			case "strVal":
			{
				Class2275 class6 = (Class2275)value.Object;
				class2 = new Class2764(class6.Val);
				goto IL_0150;
			}
			case "fltVal":
			{
				Class2273 class5 = (Class2273)value.Object;
				class2 = new Class2762(class5.Val);
				goto IL_0150;
			}
			case "intVal":
			{
				Class2274 class4 = (Class2274)value.Object;
				class2 = new Class2763(class4.Val);
				goto IL_0150;
			}
			case "boolVal":
			{
				Class2271 class3 = (Class2271)value.Object;
				class2 = new Class2761(class3.Val);
				goto IL_0150;
			}
			default:
				{
					throw new NotImplementedException();
				}
				IL_0150:
				if (class2 != null)
				{
					class2.Header.Instance = 0;
					timeAnimationValueListContainer.Records.Add(class2);
				}
				class7 = null;
				if (!string.IsNullOrEmpty(timeAnimateValueListElementData.Fmla))
				{
					class7 = new Class2764(timeAnimateValueListElementData.Fmla);
					class7.Header.Instance = 1;
					timeAnimationValueListContainer.Records.Add(class7);
				}
				break;
			}
		}
	}

	private static void smethod_11(Class2281 commonBehaviorElementData, Class2652 timeAnimateBehaviorContainer, Class234 timelineSerializationContext)
	{
		if (commonBehaviorElementData == null)
		{
			throw new ArgumentNullException();
		}
		if (timeAnimateBehaviorContainer == null)
		{
			throw new ArgumentNullException();
		}
		Class2654 @class = new Class2654();
		timeAnimateBehaviorContainer.Records.Add(@class);
		Class222.smethod_5(commonBehaviorElementData, @class);
		Class222.smethod_6(commonBehaviorElementData, @class);
		Class228.smethod_8(commonBehaviorElementData.TgtEl, @class, timelineSerializationContext);
	}

	internal static void smethod_12(Class2304 shapeEntranceEffectElementData, Class2641 officeArtClientData)
	{
		if (shapeEntranceEffectElementData == null)
		{
			throw new ArgumentNullException();
		}
		if (officeArtClientData == null)
		{
			throw new ArgumentNullException();
		}
		Class2672 @class = new Class2672();
		officeArtClientData.Records.Add(@class);
		Class2838 class2 = new Class2838();
		@class.Records.Add(class2);
		class2.DimColor = new Class2966(Class2966.Enum441.const_6, Color.Black);
		class2.AnimAfterEffect = 0;
		if (shapeEntranceEffectElementData.CTn.SubTnLst != null)
		{
			Class2605[] nodeList = shapeEntranceEffectElementData.CTn.SubTnLst.NodeList;
			foreach (Class2605 class3 in nodeList)
			{
				if (class3.Name == "animClr")
				{
					Class2266 class4 = (Class2266)class3.Object;
					if (class4.To != null && class4.To.Color != null && class4.To.Color.Name == "srgbClr")
					{
						Class1926 class5 = (Class1926)class4.To.Color.Object;
						class2.DimColor = new Class2966(class5.Val);
						class2.AnimAfterEffect = 1;
					}
				}
			}
		}
		class2.Flags = 17408;
		class2.TextBuildSubEffect = 0;
		class2.OLEVerb = 0;
		class2.SlideCount = 1;
		class2.AnimBuildType = 1;
		class2.SoundIdRef = 0u;
		class2.OrderID = (short)shapeEntranceEffectElementData.CTn.GrpId;
		smethod_13(shapeEntranceEffectElementData, class2);
	}

	private static void smethod_13(Class2304 shapeEntranceEffectElementData, Class2838 animationInfoAtom)
	{
		if (shapeEntranceEffectElementData.CTn.PresetClass != 0)
		{
			throw new InvalidOperationException();
		}
		Class2283 cTn = shapeEntranceEffectElementData.CTn;
		animationInfoAtom.AnimEffect = 0;
		animationInfoAtom.AnimEffectDirection = 0;
		if (cTn.PresetID == 1L)
		{
			animationInfoAtom.AnimEffect = 0;
			animationInfoAtom.AnimEffectDirection = 0;
		}
		else if (cTn.PresetID == 3L)
		{
			animationInfoAtom.AnimEffect = 2;
			if (cTn.PresetSubtype == 5L)
			{
				animationInfoAtom.AnimEffectDirection = 0;
			}
			else if (cTn.PresetSubtype == 10L)
			{
				animationInfoAtom.AnimEffectDirection = 1;
			}
		}
		else if (cTn.PresetID == 5L)
		{
			animationInfoAtom.AnimEffect = 3;
			if (cTn.PresetSubtype == 5L)
			{
				animationInfoAtom.AnimEffectDirection = 1;
			}
			else if (cTn.PresetSubtype == 10L)
			{
				animationInfoAtom.AnimEffectDirection = 0;
			}
		}
		else if (cTn.PresetID == 12L)
		{
			animationInfoAtom.AnimEffect = 4;
			animationInfoAtom.AnimEffectDirection = 0;
		}
		else if (cTn.PresetID == 9L)
		{
			animationInfoAtom.AnimEffect = 5;
			animationInfoAtom.AnimEffectDirection = 0;
		}
		else if (cTn.PresetID == 10L)
		{
			animationInfoAtom.AnimEffect = 6;
			animationInfoAtom.AnimEffectDirection = 0;
		}
		else if (cTn.PresetID == 14L)
		{
			animationInfoAtom.AnimEffect = 8;
			if (cTn.PresetSubtype == 5L)
			{
				animationInfoAtom.AnimEffectDirection = 1;
			}
			else if (cTn.PresetSubtype == 10L)
			{
				animationInfoAtom.AnimEffectDirection = 0;
			}
		}
		else if (cTn.PresetID == 18L)
		{
			animationInfoAtom.AnimEffect = 9;
			if (cTn.PresetSubtype == 3L)
			{
				animationInfoAtom.AnimEffectDirection = 1;
			}
			else if (cTn.PresetSubtype == 6L)
			{
				animationInfoAtom.AnimEffectDirection = 2;
			}
			else if (cTn.PresetSubtype == 9L)
			{
				animationInfoAtom.AnimEffectDirection = 0;
			}
			else if (cTn.PresetSubtype == 12L)
			{
				animationInfoAtom.AnimEffectDirection = 3;
			}
		}
		else if (cTn.PresetID == 22L)
		{
			animationInfoAtom.AnimEffect = 10;
			animationInfoAtom.AnimEffectDirection = 0;
		}
		else if (cTn.PresetID == 53L)
		{
			animationInfoAtom.AnimEffect = 11;
			animationInfoAtom.AnimEffectDirection = 0;
		}
		else if (cTn.PresetID == 2L)
		{
			animationInfoAtom.AnimEffect = 12;
			animationInfoAtom.AnimEffectDirection = 0;
		}
		else if (cTn.PresetID == 16L)
		{
			animationInfoAtom.AnimEffect = 13;
			if (cTn.PresetSubtype == 26L)
			{
				animationInfoAtom.AnimEffectDirection = 0;
			}
			else if (cTn.PresetSubtype == 42L)
			{
				animationInfoAtom.AnimEffectDirection = 1;
			}
			else if (cTn.PresetSubtype == 21L)
			{
				animationInfoAtom.AnimEffectDirection = 3;
			}
			else if (cTn.PresetSubtype == 37L)
			{
				animationInfoAtom.AnimEffectDirection = 3;
			}
		}
		else if (cTn.PresetID == 12L)
		{
			animationInfoAtom.AnimEffect = 14;
			animationInfoAtom.AnimEffectDirection = 0;
		}
		else if (cTn.PresetID == 8L)
		{
			animationInfoAtom.AnimEffect = 17;
			animationInfoAtom.AnimEffectDirection = 0;
		}
		else if (cTn.PresetID == 13L)
		{
			animationInfoAtom.AnimEffect = 18;
			animationInfoAtom.AnimEffectDirection = 0;
		}
		else if (cTn.PresetID == 20L)
		{
			animationInfoAtom.AnimEffect = 19;
			animationInfoAtom.AnimEffectDirection = 0;
		}
		else if (cTn.PresetID == 21L)
		{
			animationInfoAtom.AnimEffect = 26;
			animationInfoAtom.AnimEffectDirection = 1;
		}
		else if (cTn.PresetID == 21L)
		{
			animationInfoAtom.AnimEffect = 27;
			animationInfoAtom.AnimEffectDirection = 1;
		}
	}
}
