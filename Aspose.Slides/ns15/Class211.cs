using System;
using System.Xml;
using Aspose.Slides.Warnings;
using ns16;
using ns56;
using ns63;

namespace ns15;

internal class Class211
{
	public static void smethod_0(Class2278 buildParaElementData, Class2684 buildListContainer, Class234 timelineSerializationContext)
	{
		if (buildParaElementData != null)
		{
			if (buildListContainer == null)
			{
				throw new InvalidOperationException();
			}
			Class2646 @class = new Class2646();
			buildListContainer.Records.Add(@class);
			Class2839 class2 = new Class2839();
			@class.Records.Add(class2);
			class2.BuildType = 1u;
			if (buildParaElementData.Spid != null)
			{
				class2.ShapeIdRef = XmlConvert.ToUInt32(buildParaElementData.Spid);
			}
			class2.FExpanded = 1;
			class2.FUIExpanded = (byte)(buildParaElementData.UiExpand ? 1u : 0u);
			Class2886 class3 = new Class2886();
			@class.Records.Add(class3);
			class3.Header.Version = 1;
			if (buildParaElementData.Build != 0)
			{
				class3.ParaBuild = smethod_3(buildParaElementData.Build);
			}
			else
			{
				class3.ParaBuild = 0u;
			}
			class3.BuildLevel = buildParaElementData.BldLvl;
			class3.FAnimBackground = (byte)((!buildParaElementData.AnimBg) ? 1u : 0u);
			class3.FReverse = (byte)(buildParaElementData.Rev ? 1u : 0u);
			class3.FUserSetAnimBackground = (byte)((!buildParaElementData.AutoUpdateAnimBg) ? 1u : 0u);
			class3.FAutomatic = 0;
		}
	}

	public static void smethod_1(Class2277 buildParaElementData, Class2684 buildListContainer, Class234 timelineSerializationContext)
	{
		if (buildParaElementData != null)
		{
			if (buildListContainer == null)
			{
				throw new InvalidOperationException();
			}
			timelineSerializationContext.method_3("Writing of the animation diagramm para failed.", WarningType.DataLoss);
		}
	}

	public static void smethod_2(Class2290 buildParaElementData, Class2684 buildListContainer, Class234 timelineSerializationContext)
	{
		if (buildParaElementData != null)
		{
			if (buildListContainer == null)
			{
				throw new InvalidOperationException();
			}
			timelineSerializationContext.method_3("Writing of the animation chart para failed.", WarningType.DataLoss);
		}
	}

	private static uint smethod_3(Enum359 buildType)
	{
		return buildType switch
		{
			Enum359.const_1 => 0u, 
			Enum359.const_2 => 1u, 
			Enum359.const_3 => 2u, 
			Enum359.const_4 => 3u, 
			_ => 0u, 
		};
	}
}
