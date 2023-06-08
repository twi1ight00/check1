using System;
using Aspose.Slides.Warnings;
using ns33;

namespace ns49;

internal abstract class Class1172 : IWarningInfo
{
	internal string string_0;

	public abstract WarningType WarningType { get; }

	public string Description => string_0;

	internal Class1172(string description)
	{
		string_0 = description;
	}

	public void SendWarning(IWarningCallback receiver)
	{
		bool flag = false;
		if (receiver != null)
		{
			try
			{
				flag = receiver.Warning(this) == ReturnAction.Abort;
			}
			catch (Exception ex)
			{
				Class1165.smethod_28(ex);
			}
		}
		if (flag)
		{
			throw new Exception2(this);
		}
	}
}
