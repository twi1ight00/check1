#define TRACE
using System.Diagnostics;

namespace Richfit.Garnet.Module.Base.Infrastructure.Logging;

/// <summary>
/// 控制台输出Debug记录
/// </summary>
public class TraceDebug
{
	/// <inheritdoc cref="M:System.Diagnostics.Trace.WriteLine(System.Object)" />
	[Conditional("DEBUG")]
	public static void Write(object content)
	{
		Trace.WriteLine(content);
	}
}
