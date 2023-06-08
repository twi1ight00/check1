using ns22;
using ns24;
using ns7;

namespace Aspose.Slides;

public class GraphicalObject : Shape, IPresentationComponent, ISlideComponent, IHyperlinkContainer, IShape, IGraphicalObject
{
	internal new Class287 PPTXUnsupportedProps => (Class287)base.PPTXUnsupportedProps;

	internal new Class274 PPTUnsupportedProps => (Class274)base.PPTUnsupportedProps;

	public new IGraphicalObjectLock ShapeLock => (IGraphicalObjectLock)base.ShapeLock;

	IShape IGraphicalObject.AsIShape => this;

	internal GraphicalObject(IBaseSlide parent)
		: this(parent, new Class287(), new Class274())
	{
	}

	internal GraphicalObject(IBaseSlide parent, Class287 pptxUnsupportedProps)
		: this(parent, pptxUnsupportedProps, new Class274())
	{
	}

	internal GraphicalObject(IBaseSlide parent, Class287 pptxUnsupportedProps, Class274 pptUnsupportedProps)
		: base(parent, pptxUnsupportedProps, pptUnsupportedProps)
	{
		base.Transform2DInternal = new Class154();
		base.ShapeLock = new GraphicalObjectLock();
	}
}
