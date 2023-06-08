using ns235;
using ns287;
using ns294;

namespace ns289;

internal class Class6778
{
	private Class7047 class7047_0;

	private Class6216[] class6216_0;

	private Class6800 class6800_0;

	public Class7047 Document => class7047_0;

	public Class6216[] Pages => class6216_0;

	public Interface328 Binder => class6800_0;

	internal Class6778(Class6800 binder)
	{
		class6800_0 = binder;
		class7047_0 = binder.Document;
		class6216_0 = binder.Pages;
	}
}
