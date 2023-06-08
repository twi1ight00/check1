using ns103;
using ns126;
using ns152;
using ns154;

namespace ns118;

internal abstract class Class4460 : Interface116
{
	private Interface116 interface116_0;

	public Class4704 DictionaryStack => interface116_0.DictionaryStack;

	public Class4705 ExecutionStack => interface116_0.ExecutionStack;

	public Class4706 GraphStateStack => interface116_0.GraphStateStack;

	public Class4707 OperandStack => interface116_0.OperandStack;

	public Class4703 ClippingPathStack => interface116_0.ClippingPathStack;

	public Interface127 ErrorHandler => interface116_0.ErrorHandler;

	public Class4715 Subroutines => interface116_0.Subroutines;

	public Class4460(Interface116 interpreterContext)
	{
		interface116_0 = interpreterContext;
	}

	public abstract void vmethod_0(string commandName);

	public void imethod_0(Class4552 psProgram)
	{
		interface116_0.imethod_0(psProgram);
	}
}
