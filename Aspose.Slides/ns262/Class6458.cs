using ns219;
using ns259;

namespace ns262;

internal class Class6458 : Interface304
{
	private readonly Interface293 interface293_0;

	private readonly Class6412 class6412_0;

	private Interface310 interface310_0;

	private Interface311 interface311_0;

	private Interface313 interface313_0;

	public Class6458(Interface293 dataProvider, Class6412 drawingContext)
	{
		interface293_0 = dataProvider;
		class6412_0 = drawingContext;
		interface313_0 = new Class6469(interface293_0);
		interface310_0 = new Class6466(this);
		interface311_0 = new Class6467(drawingContext.BrushRenderingContext);
	}

	public Interface308 imethod_0()
	{
		return new Class6464();
	}

	public Interface306 imethod_1()
	{
		return new Class6462(this);
	}

	public Interface293 imethod_2()
	{
		return interface293_0;
	}

	public Interface313 imethod_3()
	{
		return interface313_0;
	}

	public Interface310 imethod_4()
	{
		return interface310_0;
	}

	public Interface311 imethod_5()
	{
		return interface311_0;
	}
}
