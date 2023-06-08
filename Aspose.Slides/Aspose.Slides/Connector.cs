using System.Collections.Generic;
using ns24;

namespace Aspose.Slides;

public class Connector : GeometryShape, IPresentationComponent, ISlideComponent, IHyperlinkContainer, IShape, IGeometryShape, IConnector
{
	private Shape shape_0;

	private Shape shape_1;

	private uint uint_2;

	private uint uint_3;

	internal static readonly Dictionary<ShapeType, ShapeType> dictionary_0 = GeometryShape.smethod_2(ShapeType.Line, ShapeType.StraightConnector1, ShapeType.BentConnector2, ShapeType.BentConnector3, ShapeType.BentConnector4, ShapeType.BentConnector5, ShapeType.CurvedConnector2, ShapeType.CurvedConnector3, ShapeType.CurvedConnector4, ShapeType.CurvedConnector5);

	internal new Class286 PPTXUnsupportedProps => (Class286)base.PPTXUnsupportedProps;

	public new IConnectorLock ShapeLock => (IConnectorLock)base.ShapeLock;

	public override ShapeType ShapeType
	{
		get
		{
			return base.ShapeType;
		}
		set
		{
			if (!dictionary_0.ContainsKey(value))
			{
				throw new PptxEditException("Incorrect ShapeType value for Connector specified: " + value);
			}
			base.ShapeType = value;
		}
	}

	public IShape StartShapeConnectedTo
	{
		get
		{
			return shape_0;
		}
		set
		{
			if (shape_0 != null)
			{
				shape_0.m_shapeRemoved -= method_26;
				uint_2 = 0u;
			}
			shape_0 = (Shape)value;
			if (value != null)
			{
				shape_0.m_shapeRemoved += method_26;
			}
		}
	}

	public IShape EndShapeConnectedTo
	{
		get
		{
			return shape_1;
		}
		set
		{
			if (shape_1 != null)
			{
				shape_1.m_shapeRemoved -= method_26;
				uint_3 = 0u;
			}
			shape_1 = (Shape)value;
			if (value != null)
			{
				shape_1.m_shapeRemoved += method_26;
			}
		}
	}

	public uint StartShapeConnectionSiteIndex
	{
		get
		{
			return uint_2;
		}
		set
		{
			uint_2 = value;
		}
	}

	public uint EndShapeConnectionSiteIndex
	{
		get
		{
			return uint_3;
		}
		set
		{
			uint_3 = value;
		}
	}

	IGeometryShape IConnector.AsIGeometryShape => this;

	internal Connector(IBaseSlide parent)
		: base(parent, new Class286())
	{
		base.ShapeLock = new ConnectorLock();
	}

	internal void method_26(Shape which)
	{
		shape_0 = null;
		uint_2 = 0u;
	}

	internal void method_27(Shape which)
	{
		shape_1 = null;
		uint_3 = 0u;
	}
}
