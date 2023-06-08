using ns235;
using ns288;

namespace ns277;

internal abstract class Class6815
{
	private Interface355 interface355_0;

	internal Class6964 class6964_0;

	private Interface322 interface322_0;

	public Interface355 Settings
	{
		get
		{
			return interface355_0;
		}
		internal set
		{
			interface355_0 = value;
		}
	}

	public Interface322 ResourceLoadingCallback => interface322_0;

	internal Class6964 StyleProvider
	{
		get
		{
			return class6964_0;
		}
		set
		{
			class6964_0 = value;
		}
	}

	protected Class6815(Interface322 resourceLoadingCallback)
	{
		interface355_0 = new Class6952();
		interface322_0 = resourceLoadingCallback;
	}

	public abstract void vmethod_0(string html);

	public abstract Class6216[] vmethod_1(string html);
}
