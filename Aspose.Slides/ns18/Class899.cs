using System.Collections.Generic;
using Aspose.Slides;
using ns16;
using ns24;
using ns53;
using ns55;
using ns56;

namespace ns18;

internal class Class899
{
	public static void smethod_0(IBaseSlide baseSlide, Class2227 cSld, Class1030 slideDeserializationContext)
	{
		if (cSld == null)
		{
			return;
		}
		Class897.smethod_0(baseSlide.Background, cSld.Bg, slideDeserializationContext.DeserializationContext);
		Class961.smethod_0(baseSlide.Shapes.ParentGroup, cSld.SpTree, slideDeserializationContext);
		uint num = 0u;
		foreach (string key3 in slideDeserializationContext.ShapeXmlIdToShape.Keys)
		{
			if (uint.TryParse(key3, out var result) && num < result)
			{
				num = result;
			}
		}
		((BaseSlide)baseSlide).method_11(num + 1, check: false);
		foreach (ISlideComponent item in slideDeserializationContext.DeferredShapesForShapeXmlIdInit)
		{
			if (item is Shape)
			{
				((Shape)item).method_12();
				slideDeserializationContext.method_0(((Shape)item).PPTXUnsupportedProps.ShapeId.ToString(), item);
			}
		}
		slideDeserializationContext.DeferredShapesForShapeXmlIdInit.Clear();
		if (slideDeserializationContext.DeferredPlaceholdersForIndexInit.Count > 0)
		{
			if (!(baseSlide is MasterSlide) && !(baseSlide is MasterNotesSlide) && !(baseSlide is MasterHandoutSlide))
			{
				if (baseSlide is LayoutSlide || baseSlide is NotesSlide)
				{
					uint num2 = 0u;
					foreach (KeyValuePair<uint, IPlaceholder> item2 in slideDeserializationContext.PhIdxToPlaceholder)
					{
						uint key = item2.Key;
						IPlaceholder value = item2.Value;
						if (num2 < key && value.Index != 10 && value.Index != 11 && value.Index != 12)
						{
							num2 = key;
						}
					}
					uint num3 = 10u;
					foreach (Placeholder item3 in slideDeserializationContext.DeferredPlaceholdersForIndexInit)
					{
						if (num2 == 9)
						{
							num2 = 12u;
						}
						if (item3.Type != PlaceholderType.DateAndTime && item3.Type != PlaceholderType.Footer && item3.Type != PlaceholderType.SlideNumber)
						{
							num2 = (item3.IndexInternal = num2 + 1);
						}
						else
						{
							for (; slideDeserializationContext.PhIdxToPlaceholder.ContainsKey(num3); num3++)
							{
							}
							item3.IndexInternal = num3++;
						}
						slideDeserializationContext.method_1(item3.IndexInternal, item3);
					}
					slideDeserializationContext.DeferredPlaceholdersForIndexInit.Clear();
				}
			}
			else
			{
				uint num5 = 0u;
				foreach (uint key4 in slideDeserializationContext.PhIdxToPlaceholder.Keys)
				{
					if (num5 < key4)
					{
						num5 = key4;
					}
				}
				foreach (Placeholder item4 in slideDeserializationContext.DeferredPlaceholdersForIndexInit)
				{
					num5 = (item4.IndexInternal = num5 + 1);
					slideDeserializationContext.method_1(item4.IndexInternal, item4);
				}
				slideDeserializationContext.DeferredPlaceholdersForIndexInit.Clear();
			}
		}
		foreach (KeyValuePair<IConnector, Class1879> connectorAndShapeConnection in slideDeserializationContext.ConnectorAndShapeConnections)
		{
			IConnector key2 = connectorAndShapeConnection.Key;
			Class1879 value2 = connectorAndShapeConnection.Value;
			if (value2.StCxn != null && slideDeserializationContext.ShapeXmlIdToShape.ContainsKey(value2.StCxn.Id.ToString()))
			{
				key2.StartShapeConnectedTo = (IShape)slideDeserializationContext.ShapeXmlIdToShape[value2.StCxn.Id.ToString()];
				key2.StartShapeConnectionSiteIndex = value2.StCxn.Idx;
			}
			if (value2.EndCxn != null && slideDeserializationContext.ShapeXmlIdToShape.ContainsKey(value2.EndCxn.Id.ToString()))
			{
				key2.EndShapeConnectedTo = (IShape)slideDeserializationContext.ShapeXmlIdToShape[value2.EndCxn.Id.ToString()];
				key2.EndShapeConnectionSiteIndex = value2.EndCxn.Idx;
			}
		}
		baseSlide.Name = cSld.Name;
		smethod_1(baseSlide, cSld, slideDeserializationContext);
	}

	private static void smethod_1(IBaseSlide baseSlide, Class2227 cSld, Class1030 slideDeserializationContext)
	{
		Class296 baseSlidePPTXUnsupportedProps = ((BaseSlide)baseSlide).BaseSlidePPTXUnsupportedProps;
		Class1341 deserializationContext = slideDeserializationContext.DeserializationContext;
		Class935.smethod_0(baseSlide.Controls, cSld.Controls, slideDeserializationContext);
		Class937.smethod_0(baseSlide.CustomData, cSld.CustDataLst, deserializationContext);
		baseSlidePPTXUnsupportedProps.ExtensionListOfCommonSlideData = cSld.ExtLst;
		Class1347[] array = deserializationContext.RelationshipsOfCurrentPartEntry.method_0(Class1294.class1338_0);
		if (array.Length > 0)
		{
			Class1342 targetPart = array[0].TargetPart;
			Class1212 @class = new Class1212(targetPart, deserializationContext);
			@class.method_5(baseSlide, slideDeserializationContext);
		}
	}

	public static void smethod_2(IBaseSlide baseSlide, Class2227 cSld, Class1031 slideSerializationContext)
	{
		Class1346 serializationContext = slideSerializationContext.SerializationContext;
		Class961.smethod_3(baseSlide.Shapes.ParentGroup, cSld.SpTree, slideSerializationContext, null);
		Class897.smethod_1(baseSlide.Background, cSld.delegate2402_0, serializationContext);
		cSld.Name = baseSlide.Name;
		smethod_3(baseSlide, cSld, slideSerializationContext);
	}

	private static void smethod_3(IBaseSlide baseSlide, Class2227 cSld, Class1031 slideSerializationContext)
	{
		Class296 baseSlidePPTXUnsupportedProps = ((BaseSlide)baseSlide).BaseSlidePPTXUnsupportedProps;
		Class1346 serializationContext = slideSerializationContext.SerializationContext;
		Class935.smethod_1(baseSlide.Controls, cSld.delegate2425_0, slideSerializationContext);
		Class937.smethod_1(baseSlide.CustomData, cSld.delegate2434_0, serializationContext);
		cSld.delegate1535_0(baseSlidePPTXUnsupportedProps.ExtensionListOfCommonSlideData);
		if (slideSerializationContext.VmlObjects.Count > 0)
		{
			Class1342 @class = serializationContext.Package.method_4("/ppt/drawings/vmlDrawing{0}.vml", serializationContext.method_13, new Class1294());
			Class1212 class2 = new Class1212(@class, serializationContext);
			class2.method_6(slideSerializationContext);
			serializationContext.RelationshipsOfCurrentPartEntry.method_4(@class);
		}
	}

	internal static SortedList<string, ISlideComponent> smethod_4(IBaseSlide slide)
	{
		SortedList<string, ISlideComponent> sortedList = new SortedList<string, ISlideComponent>();
		List<IShape> list = new List<IShape>();
		smethod_5(slide.Shapes, list);
		foreach (IShape item in list)
		{
			if (item is Shape shape)
			{
				sortedList[shape.ShapeId.ToString()] = shape;
			}
		}
		return sortedList;
	}

	private static void smethod_5(IShapeCollection shapes, List<IShape> shapeList)
	{
		foreach (IShape shape in shapes)
		{
			shapeList.Add(shape);
			if (shape is IGroupShape groupShape)
			{
				smethod_5(groupShape.Shapes, shapeList);
			}
		}
	}
}
