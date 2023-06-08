using System;
using System.Reflection.Emit;
using Microsoft.Practices.Unity.Utility;

namespace Microsoft.Practices.ObjectBuilder2;

/// <summary>
/// An implementation of <see cref="T:Microsoft.Practices.ObjectBuilder2.IDynamicBuilderMethodCreatorPolicy" /> that will
/// check for full trust and if we're building a class or an interface. If in full
/// trust, attach to the class or module of the interface respectively. If in partial
/// trust, attach to the OB2 module instead.
/// </summary>
public class DefaultDynamicBuilderMethodCreatorPolicy : IDynamicBuilderMethodCreatorPolicy, IBuilderPolicy
{
	/// <summary>
	/// Create a builder method for the given type, using the given name.
	/// </summary>
	/// <param name="typeToBuild">Type that will be built by the generated method.</param>
	/// <param name="methodName">Name to give to the method.</param>
	/// <returns>A <see cref="T:System.Reflection.Emit.DynamicMethod" /> object with the proper signature to use
	/// as part of a build plan.</returns>
	public DynamicMethod CreateBuilderMethod(Type typeToBuild, string methodName)
	{
		Guard.ArgumentNotNull(typeToBuild, "typeToBuild");
		Guard.ArgumentNotNullOrEmpty(methodName, "methodName");
		return new DynamicMethod(methodName, typeof(void), new Type[1] { typeof(IBuilderContext) }, restrictedSkipVisibility: true);
	}
}
