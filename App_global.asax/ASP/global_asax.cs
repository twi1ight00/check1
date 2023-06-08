using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Web.Profile;
using webapp;

namespace ASP;

[CompilerGlobalScope]
public class global_asax : Global
{
	private static bool __initialized;

	protected DefaultProfile Profile => (DefaultProfile)base.Context.Profile;

	[DebuggerNonUserCode]
	public global_asax()
	{
		if (!__initialized)
		{
			__initialized = true;
		}
	}
}
