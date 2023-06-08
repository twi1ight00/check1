using System.Collections;
using System.Drawing;
using ns224;

namespace ns263;

internal class Class6477
{
	private Stack stack_0 = new Stack();

	public Class6478 CurrentStage
	{
		get
		{
			if (stack_0.Count == 0)
			{
				return new Class6478();
			}
			return (Class6478)stack_0.Peek();
		}
	}

	public void method_0(Class6473 transform)
	{
		Class6478 obj = CurrentStage.method_2(transform);
		stack_0.Push(obj);
	}

	public void method_1()
	{
		if (stack_0.Count > 0)
		{
			stack_0.Pop();
		}
	}

	public Class6475 method_2(RectangleF bbox)
	{
		Class6478 currentStage = CurrentStage;
		Class6002 shapeTransformation = currentStage.method_1();
		Class6002 shapeOffset = currentStage.method_0();
		return new Class6475(shapeTransformation, shapeOffset);
	}
}
