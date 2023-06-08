using Aspose.Slides;

namespace ns24;

internal class Class359 : Class278
{
	private bool bool_0;

	private float float_0;

	private Backdrop3DScene backdrop3DScene_0;

	private uint uint_0;

	public bool FlatText
	{
		get
		{
			return bool_0;
		}
		set
		{
			bool_0 = value;
			method_1();
		}
	}

	public float FlatTextZCoordinate
	{
		get
		{
			return float_0;
		}
		set
		{
			float_0 = value;
			method_1();
		}
	}

	public IBackdrop3DScene BackdropPlane => backdrop3DScene_0;

	internal uint Version => uint_0 + backdrop3DScene_0.Version;

	public void method_0(Class359 threeDFormatUnsupported)
	{
		bool_0 = threeDFormatUnsupported.bool_0;
		float_0 = threeDFormatUnsupported.float_0;
		method_1();
	}

	public Class359()
	{
		backdrop3DScene_0 = new Backdrop3DScene();
	}

	private void method_1()
	{
		uint_0++;
	}
}
