using System;
using System.Globalization;
using Aspose.Slides;
using ns16;
using ns24;
using ns56;

namespace ns18;

internal class Class983
{
	private const string string_0 = "AS_UNIQUEID";

	public static void smethod_0(IShape shape, Class1921 spPrElementData, Class1341 deserializationContext)
	{
		if (spPrElementData != null)
		{
			Class949.smethod_0(shape.FillFormat, spPrElementData.FillProperties, deserializationContext);
			Class968.smethod_0(shape.LineFormat, spPrElementData.Ln);
			Class939.smethod_0(shape.EffectFormat, spPrElementData.EffectProperties, deserializationContext);
			Class1007.smethod_0(shape.ThreeDFormat, spPrElementData.Scene3d, spPrElementData.Sp3d, null);
			Class280 pPTXUnsupportedProps = ((Shape)shape).PPTXUnsupportedProps;
			Class1021.smethod_1(((Shape)shape).RawFrameImpl, spPrElementData.Xfrm);
			pPTXUnsupportedProps.ExtensionListOfShapeProperties = spPrElementData.ExtLst;
		}
	}

	public static void smethod_1(IShape shape, Class2221 nvPr, Class1030 slideDeserializationContext)
	{
		if (nvPr != null)
		{
			Class978.smethod_0(shape, nvPr.Ph, slideDeserializationContext);
			Class280 pPTXUnsupportedProps = ((Shape)shape).PPTXUnsupportedProps;
			Class937.smethod_0(shape.CustomData, nvPr.CustDataLst, slideDeserializationContext.DeserializationContext);
			if (shape.CustomData.Tags.Contains("AS_UNIQUEID"))
			{
				((Shape)shape).method_9(shape.CustomData.Tags["AS_UNIQUEID"]);
				shape.CustomData.Tags.Remove("AS_UNIQUEID");
			}
			pPTXUnsupportedProps.NvIsPhoto = nvPr.IsPhoto;
			pPTXUnsupportedProps.NvUserDrawn = nvPr.UserDrawn;
			pPTXUnsupportedProps.ExtensionListOfAppNonVisualProperties = nvPr.ExtLst;
		}
	}

	public static void smethod_2(IShape shape, Class1880 cNvPr, Class1030 slideDeserializationContext)
	{
		if (cNvPr == null)
		{
			return;
		}
		Class964.smethod_0(shape, cNvPr.HlinkClick, cNvPr.HlinkHover, slideDeserializationContext.DeserializationContext);
		shape.Hidden = cNvPr.Hidden;
		shape.AlternativeText = cNvPr.Descr;
		shape.Name = cNvPr.Name;
		Class280 pPTXUnsupportedProps = ((Shape)shape).PPTXUnsupportedProps;
		switch (slideDeserializationContext.DeserializationContext.Mode)
		{
		default:
			throw new ArgumentOutOfRangeException();
		case Enum168.const_0:
		case Enum168.const_1:
		case Enum168.const_3:
			if (slideDeserializationContext.method_0(cNvPr.Id.ToString(), shape))
			{
				((Shape)shape).method_11(cNvPr.Id);
			}
			else
			{
				((Shape)shape).method_11(0u);
			}
			break;
		case Enum168.const_2:
			break;
		}
		slideDeserializationContext.DeserializationContext.Shapes.Add(shape);
		pPTXUnsupportedProps.Title = cNvPr.Title;
		pPTXUnsupportedProps.ExtensionListOfNonVisualDrawingProps = cNvPr.ExtLst;
	}

	public static void smethod_3(IShape shape)
	{
		((Shape)shape).RawFrameImpl.Reset();
	}

	public static void smethod_4(IShape shape, Class1921.Delegate1630 addSpPr, Class1346 serializationContext)
	{
		if (shape.FillFormat.FillType != FillType.NotDefined || !shape.LineFormat.IsFormatNotDefined || !shape.EffectFormat.IsNoEffects || shape.ThreeDFormat != null)
		{
			Class1921 spPrElementData = addSpPr();
			smethod_5(shape, spPrElementData, serializationContext);
		}
	}

	public static void smethod_5(IShape shape, Class1921 spPrElementData, Class1346 serializationContext)
	{
		Class949.smethod_1(shape.FillFormat, spPrElementData.delegate2773_1, serializationContext);
		Class968.smethod_2(shape.LineFormat, spPrElementData.delegate1504_0);
		Class939.smethod_1(shape.EffectFormat, spPrElementData.delegate2773_0, serializationContext);
		Class1007.smethod_1(shape.ThreeDFormat, spPrElementData.delegate1615_0, spPrElementData.delegate1624_0, null);
		Class280 pPTXUnsupportedProps = ((Shape)shape).PPTXUnsupportedProps;
		Class1021.smethod_3((Shape)shape, spPrElementData.delegate1795_0);
		spPrElementData.delegate1535_0(pPTXUnsupportedProps.ExtensionListOfShapeProperties);
	}

	public static void smethod_6(IShape shape, Class2221 nvPr, Class1346 serializationContext)
	{
		if (nvPr != null)
		{
			Class978.smethod_2(shape, nvPr.delegate2492_0);
			Class280 pPTXUnsupportedProps = ((Shape)shape).PPTXUnsupportedProps;
			if (((Presentation)shape.Presentation).method_0())
			{
				shape.CustomData.Tags.Add("AS_UNIQUEID", shape.UniqueId.ToString(CultureInfo.InvariantCulture));
			}
			Class937.smethod_1(shape.CustomData, nvPr.delegate2434_0, serializationContext);
			if (((Presentation)shape.Presentation).method_0())
			{
				shape.CustomData.Tags.Remove("AS_UNIQUEID");
			}
			nvPr.IsPhoto = pPTXUnsupportedProps.NvIsPhoto;
			nvPr.UserDrawn = pPTXUnsupportedProps.NvUserDrawn;
			nvPr.delegate1535_0(pPTXUnsupportedProps.ExtensionListOfAppNonVisualProperties);
		}
	}

	public static void smethod_7(IShape shape, Class1880 cNvPr, Class1346 serializationContext)
	{
		Class964.smethod_2(shape, cNvPr.delegate1474_0, cNvPr.delegate1474_1, serializationContext);
		cNvPr.Hidden = shape.Hidden;
		cNvPr.Descr = shape.AlternativeText;
		cNvPr.Name = shape.Name;
		Class280 pPTXUnsupportedProps = ((Shape)shape).PPTXUnsupportedProps;
		cNvPr.Id = pPTXUnsupportedProps.ShapeId;
		cNvPr.Title = pPTXUnsupportedProps.Title;
		cNvPr.delegate1535_0(pPTXUnsupportedProps.ExtensionListOfNonVisualDrawingProps);
	}
}
