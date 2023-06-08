using System.Collections.Generic;
using Aspose.Slides;
using ns18;
using ns24;
using ns53;
using ns58;

namespace ns16;

internal class Class1031
{
	private Class1342 class1342_0;

	private Class296 class296_0;

	private Class1346 class1346_0;

	private uint uint_0 = 1u;

	private readonly Dictionary<IShape, uint> dictionary_0;

	private Class1212 class1212_0;

	private Class2606 class2606_0;

	private Class1342 class1342_1;

	private Dictionary<ISlideComponent, int> dictionary_1;

	public Class1346 SerializationContext => class1346_0;

	public Class1342 SlidePart => class1342_0;

	public Class1348 RelationshipsOfSlidePart => class1342_0.Relationships;

	internal Dictionary<IShape, uint> ShapeToShapeXmlId => dictionary_0;

	internal Dictionary<ISlideComponent, int> VmlObjects => dictionary_1;

	internal Class1342 VmlDrawingEntry
	{
		get
		{
			return class1342_1;
		}
		set
		{
			class1342_1 = value;
		}
	}

	internal Class1031(IBaseSlide slide, Class1346 serializationContext, Class1342 slidePart)
	{
		class1346_0 = serializationContext;
		class1342_0 = slidePart;
		class296_0 = ((BaseSlide)slide).BaseSlidePPTXUnsupportedProps;
		dictionary_0 = new Dictionary<IShape, uint>();
		dictionary_1 = new Dictionary<ISlideComponent, int>();
	}

	internal uint method_0()
	{
		return uint_0++;
	}

	internal void method_1(IShape shape, uint shapeXmlId)
	{
		dictionary_0.Add(shape, shapeXmlId);
		if (uint_0 <= shapeXmlId)
		{
			uint_0 = shapeXmlId + 1;
		}
	}

	internal int method_2(ISlideComponent vmlObject)
	{
		int num = SerializationContext.method_14();
		dictionary_1.Add(vmlObject, num);
		return num;
	}
}
