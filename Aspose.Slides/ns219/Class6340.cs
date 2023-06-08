using ns261;
using ns263;

namespace ns219;

internal class Class6340
{
	private readonly Interface293 interface293_0;

	private readonly Interface297 interface297_0;

	private readonly Class6477 class6477_0;

	public Class6477 TransformStack => class6477_0;

	public Interface297 ThemeProvider => interface297_0;

	public Interface293 DataProvider => interface293_0;

	public double CurrentAccumulatedAngle => TransformStack.CurrentStage.AccumulatedAngle;

	public Class6340(Interface297 themeProvider, Interface293 dataProvider)
		: this()
	{
		interface297_0 = themeProvider;
		interface293_0 = dataProvider;
	}

	public Class6340()
	{
		class6477_0 = new Class6477();
	}
}
