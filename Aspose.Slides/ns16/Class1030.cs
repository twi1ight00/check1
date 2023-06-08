using System;
using System.Collections.Generic;
using Aspose.Slides;
using ns53;
using ns56;

namespace ns16;

internal class Class1030
{
	private Class1341 class1341_0;

	private Class1342 class1342_0;

	private readonly SortedList<string, ISlideComponent> sortedList_0;

	private readonly List<ISlideComponent> list_0;

	private readonly Dictionary<IConnector, Class1879> dictionary_0;

	private bool bool_0;

	private readonly SortedList<uint, IPlaceholder> sortedList_1;

	private readonly List<IPlaceholder> list_1;

	public Class1341 DeserializationContext => class1341_0;

	public Class1342 SlidePart => class1342_0;

	public Class1348 RelationshipsOfSlidePart
	{
		get
		{
			switch (class1341_0.Mode)
			{
			default:
				throw new ArgumentOutOfRangeException();
			case Enum168.const_0:
			case Enum168.const_1:
			case Enum168.const_2:
				return class1342_0.Relationships;
			case Enum168.const_3:
				if (class1342_0 != null)
				{
					return class1342_0.Relationships;
				}
				return null;
			}
		}
	}

	public SortedList<string, ISlideComponent> ShapeXmlIdToShape => sortedList_0;

	public List<ISlideComponent> DeferredShapesForShapeXmlIdInit => list_0;

	public SortedList<uint, IPlaceholder> PhIdxToPlaceholder => sortedList_1;

	public List<IPlaceholder> DeferredPlaceholdersForIndexInit => list_1;

	public Dictionary<IConnector, Class1879> ConnectorAndShapeConnections => dictionary_0;

	public bool IsChartUserShapesProcessed
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

	public Class1030(Class1341 deserializationContext, Class1342 slidePart)
	{
		class1341_0 = deserializationContext;
		class1342_0 = slidePart;
		sortedList_0 = new SortedList<string, ISlideComponent>(StringComparer.InvariantCultureIgnoreCase);
		list_0 = new List<ISlideComponent>();
		dictionary_0 = new Dictionary<IConnector, Class1879>();
		sortedList_1 = new SortedList<uint, IPlaceholder>();
		list_1 = new List<IPlaceholder>();
	}

	public bool method_0(string spid, ISlideComponent shape)
	{
		if (!IsChartUserShapesProcessed)
		{
			if (ShapeXmlIdToShape.ContainsKey(spid) || !(spid != "0"))
			{
				DeferredShapesForShapeXmlIdInit.Add(shape);
				return false;
			}
			ShapeXmlIdToShape.Add(spid, shape);
		}
		return true;
	}

	public bool method_1(uint phIdx, IPlaceholder placeholder)
	{
		if (!IsChartUserShapesProcessed)
		{
			if (PhIdxToPlaceholder.ContainsKey(phIdx))
			{
				DeferredPlaceholdersForIndexInit.Add(placeholder);
				return false;
			}
			PhIdxToPlaceholder.Add(phIdx, placeholder);
		}
		return true;
	}
}
