using System;
using ns120;
using ns99;

namespace ns103;

internal class Class4557 : Interface127
{
	private Interface131 logger => Class4516.Instance.LoggerFactory.imethod_0();

	public void imethod_0(string errorMessage)
	{
		if (logger.IfFatal)
		{
			logger.imethod_1($"\r\nError has occured: \r\n{errorMessage}");
		}
	}

	public void imethod_1(string errorMessage, Exception ex)
	{
		if (logger.IfFatal)
		{
			logger.imethod_0($"\r\nError has occured: \r\n{errorMessage};\r\nException:\r\n{ex.ToString()}");
		}
	}

	public void imethod_2(Exception ex)
	{
		if (logger.IfFatal)
		{
			logger.imethod_0($"\r\nError has occured: \r\nException:\r\n{ex.ToString()}");
		}
	}

	public void imethod_3(string warningMessage)
	{
		if (logger.IfDebug)
		{
			logger.imethod_0(warningMessage);
		}
	}
}
