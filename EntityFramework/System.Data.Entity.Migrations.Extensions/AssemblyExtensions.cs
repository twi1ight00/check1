using System.Linq;
using System.Reflection;

namespace System.Data.Entity.Migrations.Extensions;

internal static class AssemblyExtensions
{
	public static string GetInformationalVersion(this Assembly assembly)
	{
		return assembly.GetCustomAttributes(inherit: false).OfType<AssemblyInformationalVersionAttribute>().Single()
			.InformationalVersion;
	}
}
