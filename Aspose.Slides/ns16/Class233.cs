using System;
using System.Collections.Generic;
using Aspose.Slides;
using ns15;
using ns63;

namespace ns16;

internal class Class233
{
	private readonly Class857 class857_0;

	private readonly Class1341 class1341_0;

	private readonly SortedList<string, ISlideComponent> sortedList_0;

	public SortedList<string, ISlideComponent> ShapeXmlIdToShape => sortedList_0;

	public Class1341 PptxDeserializationContext => class1341_0;

	public Class857 PptDeserializationContext => class857_0;

	public Class233(Class857 deserializationContext, SortedList<string, ISlideComponent> shapeXmlIdToShape)
		: this(shapeXmlIdToShape)
	{
		class857_0 = deserializationContext;
	}

	public Class233(Class1341 deserializationContext, SortedList<string, ISlideComponent> shapeXmlIdToShape)
		: this(shapeXmlIdToShape)
	{
		class1341_0 = deserializationContext;
	}

	public Class233(SortedList<string, ISlideComponent> shapeXmlIdToShape)
	{
		sortedList_0 = shapeXmlIdToShape;
	}

	internal IAudio method_0(string soundRef)
	{
		if (class1341_0 != null)
		{
			return class1341_0.method_2(class1341_0.RelationshipsOfCurrentPartEntry[soundRef].TargetPart);
		}
		if (class857_0 != null)
		{
			if (!int.TryParse(soundRef, out var result))
			{
				return null;
			}
			Class2734 soundCollection = class857_0.DocumentContainer.SoundCollection;
			Class2733 soundContainer = soundCollection.method_5(result);
			return class857_0.method_0(soundContainer);
		}
		throw new InvalidOperationException();
	}
}
