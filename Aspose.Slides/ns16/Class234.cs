using System;
using System.Collections.Generic;
using Aspose.Slides;
using Aspose.Slides.Warnings;
using ns15;
using ns53;

namespace ns16;

internal class Class234
{
	private readonly Dictionary<IShape, uint> dictionary_0;

	private readonly Class1346 class1346_0;

	private readonly Class856 class856_0;

	private readonly Dictionary<uint, uint> dictionary_1;

	internal Dictionary<IShape, uint> ShapeToShapeXmlId => dictionary_0;

	public Dictionary<uint, uint> ShapeIdToOfficeArtFSPSpidMap => dictionary_1;

	public Class234(Class1346 serializationContext, Dictionary<IShape, uint> shapeToShapeXmlId)
		: this(shapeToShapeXmlId)
	{
		class1346_0 = serializationContext;
	}

	public Class234(Class856 serializationContext, Dictionary<IShape, uint> shapeToShapeXmlId, Dictionary<uint, uint> shapeIdToOfficeArtFSPSpidMap)
		: this(shapeToShapeXmlId)
	{
		class856_0 = serializationContext;
		dictionary_1 = shapeIdToOfficeArtFSPSpidMap;
	}

	public Class234(Dictionary<IShape, uint> shapeToShapeXmlId)
	{
		dictionary_0 = shapeToShapeXmlId;
	}

	internal bool method_0(IShape shape)
	{
		foreach (IShape key in ShapeToShapeXmlId.Keys)
		{
			if (key == shape)
			{
				return true;
			}
		}
		return false;
	}

	public Class1347 method_1(Class1342 targetPart)
	{
		if (class1346_0 == null)
		{
			throw new NotImplementedException();
		}
		return class1346_0.RelationshipsOfCurrentPartEntry.method_4(targetPart);
	}

	internal Class1342 method_2(IAudio audio)
	{
		if (class1346_0 != null)
		{
			return class1346_0.method_5(audio);
		}
		return null;
	}

	internal void method_3(string description, WarningType warningType)
	{
		if (class856_0 == null)
		{
			throw new InvalidOperationException();
		}
		class856_0.method_15(description, warningType);
	}
}
