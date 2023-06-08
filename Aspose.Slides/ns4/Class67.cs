using System.Drawing.Drawing2D;
using Aspose.Slides;
using ns11;
using ns224;

namespace ns4;

internal sealed class Class67
{
	private IShapeFrame ishapeFrame_0;

	private Class6002 class6002_0;

	private GraphicsPath graphicsPath_0;

	private IBaseSlide ibaseSlide_0;

	private Class169 class169_0;

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

	public Class6002 UserToDevice
	{
		get
		{
			return class6002_0;
		}
		set
		{
			class6002_0 = value;
		}
	}

	public GraphicsPath GrPath
	{
		get
		{
			return graphicsPath_0;
		}
		set
		{
			graphicsPath_0 = value;
		}
	}

	public IBaseSlide ColorMappingSlide
	{
		get
		{
			return ibaseSlide_0;
		}
		set
		{
			ibaseSlide_0 = value;
		}
	}

	public Class169 Rc
	{
		get
		{
			return class169_0;
		}
		set
		{
			class169_0 = value;
		}
	}

	public Class67(IShapeFrame frame, Class6002 userToDevice, GraphicsPath grPath, IBaseSlide colorMappingSlide, Class169 rc)
	{
		Frame = frame.CloneShapeFrame();
		UserToDevice = userToDevice;
		GrPath = grPath;
		ColorMappingSlide = colorMappingSlide;
		Rc = rc;
	}
}
