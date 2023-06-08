using System;
using System.Drawing;
using ns11;
using ns224;
using ns24;
using ns4;

namespace Aspose.Slides;

public class Control : IPresentationComponent, ISlideComponent, IControl
{
	private ControlCollection controlCollection_0;

	private Class333 class333_0;

	private string string_0;

	private IShapeFrame ishapeFrame_0;

	private ControlPropertiesCollection controlPropertiesCollection_0;

	internal Class333 PPTXUnsupportedProps => class333_0;

	public string Name
	{
		get
		{
			return string_0;
		}
		set
		{
			string_0 = value;
		}
	}

	public Guid ClassId => PPTXUnsupportedProps.ClassId;

	public IPictureFillFormat SubstitutePictureFormat => PPTXUnsupportedProps.SubstituteImage;

	public IShapeFrame Frame
	{
		get
		{
			return ishapeFrame_0;
		}
		set
		{
			ishapeFrame_0 = value;
		}
	}

	public IControlPropertiesCollection Properties => controlPropertiesCollection_0;

	IBaseSlide ISlideComponent.Slide => controlCollection_0.baseSlide_0;

	IPresentation IPresentationComponent.Presentation => controlCollection_0.baseSlide_0.ParentPresentation;

	ISlideComponent IControl.AsISlideComponent => this;

	IPresentationComponent ISlideComponent.AsIPresentationComponent => this;

	internal Control(ControlCollection parent)
	{
		class333_0 = new Class333(this);
		controlCollection_0 = parent;
		controlPropertiesCollection_0 = new ControlPropertiesCollection();
	}

	internal void method_0(float x, float y, float width, float height, NullableBool flipH, NullableBool flipV, float rotationAngle)
	{
		ishapeFrame_0 = new ShapeFrame(x, y, width, height, flipH, flipV, rotationAngle);
	}

	internal void method_1(Class159 canvas, Class169 rc)
	{
		if (!float.IsNaN(ishapeFrame_0.X) && !float.IsNaN(ishapeFrame_0.Y) && !float.IsNaN(ishapeFrame_0.Width) && !float.IsNaN(ishapeFrame_0.Height))
		{
			canvas.Transform = Shape.smethod_0(ishapeFrame_0);
			Class67 arguments = new Class67(ishapeFrame_0, new Class6002(), null, ((ISlideComponent)this).Slide, rc);
			RectangleF rectangle = ishapeFrame_0.Rectangle;
			canvas.vmethod_7(rectangle, null, new Class63(arguments, PPTXUnsupportedProps.SubstituteImage));
		}
	}
}
