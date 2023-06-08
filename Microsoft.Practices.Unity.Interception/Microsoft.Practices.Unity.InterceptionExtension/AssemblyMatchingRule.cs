using System;
using System.Globalization;
using System.Reflection;
using Microsoft.Practices.Unity.Utility;

namespace Microsoft.Practices.Unity.InterceptionExtension;

/// <summary>
/// An <see cref="T:Microsoft.Practices.Unity.InterceptionExtension.IMatchingRule" /> that matches the assembly name of the
/// given member.
/// </summary>
public class AssemblyMatchingRule : IMatchingRule
{
	private readonly string assemblyName;

	/// <summary>
	/// Constructs a new <see cref="T:Microsoft.Practices.Unity.InterceptionExtension.AssemblyMatchingRule" /> with the given
	/// assembly name (or partial name).
	/// </summary>
	/// <param name="assemblyName">Assembly name to match.</param>
	public AssemblyMatchingRule(string assemblyName)
	{
		this.assemblyName = assemblyName;
	}

	/// <summary>
	/// Constructs a new <see cref="T:Microsoft.Practices.Unity.InterceptionExtension.AssemblyMatchingRule" /> that matches
	/// against the given assembly.
	/// </summary>
	/// <param name="assembly">Assembly to match.</param>
	public AssemblyMatchingRule(Assembly assembly)
		: this(assembly?.FullName)
	{
		if (assembly == null)
		{
			throw new ArgumentNullException("assembly");
		}
	}

	/// <summary>
	/// Determines if the supplied <paramref name="member" /> matches the rule.
	/// </summary>
	/// <remarks>
	/// This rule matches if the assembly containing the given <paramref name="member" />
	/// matches the name given. The rule used for matches lets you include the parts
	/// of the assembly name in order. You can specify assembly name only, assembly and version,
	/// assembly, version and culture, or the fully qualified assembly name.
	/// </remarks>
	/// <param name="member">Member to check.</param>
	/// <returns>true if <paramref name="member" /> is in a matching assembly, false if not.</returns>
	public bool Matches(MethodBase member)
	{
		Guard.ArgumentNotNull(member, "member");
		if (member.DeclaringType == null)
		{
			return false;
		}
		AssemblyName assemblyName = new AssemblyName(member.DeclaringType.Assembly.FullName);
		return DoesAssemblyNameMatchString(this.assemblyName, assemblyName);
	}

	private static bool DoesAssemblyNameMatchString(string assemblyNameString, AssemblyName assemblyName)
	{
		AssemblyName assemblyName2 = null;
		try
		{
			assemblyName2 = new AssemblyName(assemblyNameString);
		}
		catch (ArgumentException)
		{
			return false;
		}
		if (string.Compare(assemblyName.Name, assemblyName2.Name, StringComparison.Ordinal) == 0)
		{
			if (assemblyName2.Version != null && assemblyName2.Version.CompareTo(assemblyName.Version) != 0)
			{
				return false;
			}
			byte[] publicKeyToken = assemblyName2.GetPublicKeyToken();
			if (publicKeyToken != null)
			{
				byte[] publicKeyToken2 = assemblyName.GetPublicKeyToken();
				if (Convert.ToBase64String(publicKeyToken) != Convert.ToBase64String(publicKeyToken2))
				{
					return false;
				}
			}
			CultureInfo cultureInfo = assemblyName2.CultureInfo;
			if (cultureInfo != null && !cultureInfo.IsInvariantCulture() && !assemblyName.CultureInfo.IsSameAs(cultureInfo))
			{
				return false;
			}
			return true;
		}
		return false;
	}
}
