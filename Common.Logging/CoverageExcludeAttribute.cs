using System;

/// <summary>
/// Indicates classes or members to be ignored by NCover
/// </summary>
/// <remarks>
/// Note, the name is chosen, because TestDriven.NET uses it as //ea argument to "Test With... Coverage"
/// </remarks>
/// <author>Erich Eichinger</author>
[AttributeUsage(AttributeTargets.All)]
internal class CoverageExcludeAttribute : Attribute
{
}
