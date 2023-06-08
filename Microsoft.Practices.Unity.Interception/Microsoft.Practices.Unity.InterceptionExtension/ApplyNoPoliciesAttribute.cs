using System;

namespace Microsoft.Practices.Unity.InterceptionExtension;

/// <summary>
/// Attribute used to indicate that no interception should be applied to
/// the attribute target.
/// </summary>
[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method | AttributeTargets.Property)]
public sealed class ApplyNoPoliciesAttribute : Attribute
{
}
