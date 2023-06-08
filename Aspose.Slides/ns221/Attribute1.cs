using System;

namespace ns221;

[Attribute2("Autoporter attribute - not needed in java.")]
[AttributeUsage(AttributeTargets.Constructor | AttributeTargets.Method | AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
internal class Attribute1 : Attribute
{
}
