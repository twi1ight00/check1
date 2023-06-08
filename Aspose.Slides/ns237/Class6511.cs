using System;
using ns221;

namespace ns237;

internal abstract class Class6511
{
	protected Class6672 class6672_0;

	protected string string_0;

	private readonly int int_0;

	internal Class6672 Context => class6672_0;

	internal int Id => int_0;

	internal string IndirectReference => $"{int_0} 0 R";

	internal bool IsResource => ResourceType != Enum892.const_0;

	internal string ResourceName => string_0;

	internal virtual Enum892 ResourceType => Enum892.const_0;

	protected Class6511(Class6672 context)
	{
		class6672_0 = context;
		int_0 = context.method_0();
		if (IsResource)
		{
			string_0 = vmethod_1();
		}
	}

	[Attribute7(true)]
	public abstract void vmethod_0(Class6679 writer);

	protected virtual string vmethod_1()
	{
		if (!IsResource)
		{
			throw new InvalidOperationException("Tried to generate a resource name not being a resource.");
		}
		if (string_0 != null)
		{
			return string_0;
		}
		return $"{Class6683.smethod_3(ResourceType)}{class6672_0.Resources.GetCount(ResourceType) + 1}";
	}

	protected Class6549 method_0()
	{
		if (!class6672_0.Options.IsEncrypted)
		{
			return null;
		}
		return class6672_0.EncryptionDictionary.method_1(Id, 0);
	}
}
