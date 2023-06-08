using System.Globalization;
using System.Reflection;

namespace Microsoft.Practices.Unity.InterceptionExtension;

/// <summary>
/// A dumb data holder that returns the methodinfo for both an
/// interface method and the method that implements that interface
/// method.
/// </summary>
public class MethodImplementationInfo
{
	private readonly MethodInfo interfaceMethodInfo;

	private readonly MethodInfo implementationMethodInfo;

	/// <summary>
	/// The interface method MethodInfo.
	/// </summary>
	public MethodInfo InterfaceMethodInfo => interfaceMethodInfo;

	/// <summary>
	/// The implementing method MethodInfo.
	/// </summary>
	public MethodInfo ImplementationMethodInfo => implementationMethodInfo;

	/// <summary>
	/// Construct a new <see cref="T:Microsoft.Practices.Unity.InterceptionExtension.MethodImplementationInfo" /> which holds
	/// the given <see cref="T:System.Reflection.MethodInfo" /> objects.
	/// </summary>
	/// <param name="interfaceMethodInfo">MethodInfo for the interface method (may be null if no interface).</param>
	/// <param name="implementationMethodInfo">MethodInfo for implementing method.</param>
	public MethodImplementationInfo(MethodInfo interfaceMethodInfo, MethodInfo implementationMethodInfo)
	{
		this.interfaceMethodInfo = interfaceMethodInfo;
		this.implementationMethodInfo = implementationMethodInfo;
	}

	/// <summary>
	///                     Determines whether the specified <see cref="T:System.Object" /> is equal to the current <see cref="T:System.Object" />.
	/// </summary>
	/// <returns>
	/// true if the specified <see cref="T:System.Object" /> is equal to the current <see cref="T:System.Object" />; otherwise, false.
	/// </returns>
	/// <param name="obj">
	///                     The <see cref="T:System.Object" /> to compare with the current <see cref="T:System.Object" />. 
	///                 </param>
	/// <exception cref="T:System.NullReferenceException">
	///                     The <paramref name="obj" /> parameter is null.
	///                 </exception><filterpriority>2</filterpriority>
	public override bool Equals(object obj)
	{
		MethodImplementationInfo methodImplementationInfo = obj as MethodImplementationInfo;
		if (obj == null || methodImplementationInfo == null)
		{
			return false;
		}
		return this == methodImplementationInfo;
	}

	/// <summary>
	///                     Serves as a hash function for a particular type. 
	/// </summary>
	/// <returns>
	///                     A hash code for the current <see cref="T:System.Object" />.
	/// </returns>
	/// <filterpriority>2</filterpriority>
	public override int GetHashCode()
	{
		int num = ((interfaceMethodInfo != null) ? interfaceMethodInfo.GetHashCode() : 0);
		int num2 = ((implementationMethodInfo != null) ? implementationMethodInfo.GetHashCode() : 0);
		return (num * 23) ^ (num2 * 7);
	}

	/// <summary>
	/// Standard equals operator
	/// </summary>
	public static bool operator ==(MethodImplementationInfo left, MethodImplementationInfo right)
	{
		if (object.ReferenceEquals(left, null) && object.ReferenceEquals(right, null))
		{
			return true;
		}
		if (object.ReferenceEquals(left, null))
		{
			return false;
		}
		if (object.ReferenceEquals(right, null))
		{
			return false;
		}
		if (left.interfaceMethodInfo == right.interfaceMethodInfo)
		{
			return left.implementationMethodInfo == right.implementationMethodInfo;
		}
		return false;
	}

	/// <summary>
	/// standard not equal operator.
	/// </summary>
	public static bool operator !=(MethodImplementationInfo left, MethodImplementationInfo right)
	{
		return !(left == right);
	}

	/// <summary>
	///                     Returns a <see cref="T:System.String" /> that represents the current <see cref="T:System.Object" />.
	/// </summary>
	/// <returns>
	///                     A <see cref="T:System.String" /> that represents the current <see cref="T:System.Object" />.
	/// </returns>
	/// <filterpriority>2</filterpriority>
	public override string ToString()
	{
		if (interfaceMethodInfo == null)
		{
			return string.Format(CultureInfo.CurrentCulture, "No interface, implementation {0}.{1}", implementationMethodInfo.DeclaringType.Name, implementationMethodInfo.Name);
		}
		return string.Format(CultureInfo.CurrentCulture, "Interface {0}.{1}, implementation {2}.{3}", interfaceMethodInfo.DeclaringType.Name, interfaceMethodInfo.Name, implementationMethodInfo.DeclaringType.Name, implementationMethodInfo.Name);
	}
}
