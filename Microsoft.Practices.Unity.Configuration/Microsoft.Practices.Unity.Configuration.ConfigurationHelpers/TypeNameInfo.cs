using System.Collections.Generic;
using System.Globalization;

namespace Microsoft.Practices.Unity.Configuration.ConfigurationHelpers;

/// <summary>
/// Class containing information about a type name.
/// </summary>
internal class TypeNameInfo
{
	/// <summary>
	/// The base name of the class
	/// </summary>
	public string Name { get; set; }

	/// <summary>
	/// Namespace if any
	/// </summary>
	public string Namespace { get; set; }

	/// <summary>
	/// Assembly name, if any
	/// </summary>
	public string AssemblyName { get; set; }

	public bool IsGenericType { get; set; }

	public bool IsOpenGeneric { get; set; }

	public int NumGenericParameters => GenericParameters.Count;

	public List<TypeNameInfo> GenericParameters { get; private set; }

	public string FullName
	{
		get
		{
			string text = Name;
			if (IsGenericType)
			{
				text = text + '`' + NumGenericParameters.ToString(CultureInfo.InvariantCulture);
			}
			if (!string.IsNullOrEmpty(Namespace))
			{
				text = Namespace + '.' + text;
			}
			if (!string.IsNullOrEmpty(AssemblyName))
			{
				text = text + ", " + AssemblyName;
			}
			return text;
		}
	}

	public TypeNameInfo()
	{
		GenericParameters = new List<TypeNameInfo>();
	}
}
