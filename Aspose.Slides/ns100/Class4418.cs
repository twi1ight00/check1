using System;
using System.IO;
using ns103;
using ns104;
using ns112;
using ns119;
using ns99;

namespace ns100;

internal class Class4418 : Class4417
{
	private Class4409 class4409_0;

	private Class4492 class4492_0;

	public override Class4408 vmethod_0(Class4490 fontDefinition)
	{
		try
		{
			class4492_0 = fontDefinition.FileDefinitions[0];
			class4409_0 = new Class4409(fontDefinition);
			method_0();
		}
		catch (EndOfStreamException innerException)
		{
			if (Class4510.Current.Strictness != Class4510.Enum644.const_1)
			{
				throw new Exception34("Unexpected font parsing exception", innerException);
			}
		}
		catch (Exception29)
		{
			throw;
		}
		catch (Exception innerException2)
		{
			throw new Exception34("Unexpected font parsing exception", innerException2);
		}
		return class4409_0;
	}

	private void method_0()
	{
		using Class4437 reader = new Class4437(class4492_0.StreamSource, class4492_0.StreamSource.Offset);
		Class4442 @class = new Class4442(reader, class4409_0);
		class4409_0 = @class.method_0();
	}
}
