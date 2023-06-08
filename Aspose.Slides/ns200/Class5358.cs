using System.Collections;

namespace ns200;

internal class Class5358
{
	private int int_0;

	private Stack stack_0;

	public int Value
	{
		get
		{
			return int_0;
		}
		set
		{
			int_0 = value;
		}
	}

	public Class5358()
		: this(0)
	{
	}

	public Class5358(int value)
	{
		int_0 = value;
		stack_0 = new Stack();
	}

	public void Save()
	{
		stack_0.Push(int_0);
	}

	public void method_0()
	{
		int_0 = (int)stack_0.Pop();
	}

	public override string ToString()
	{
		return int_0.ToString();
	}

	public int[] method_1()
	{
		int[] array = new int[stack_0.Count];
		stack_0.CopyTo(array, 0);
		return array;
	}
}
