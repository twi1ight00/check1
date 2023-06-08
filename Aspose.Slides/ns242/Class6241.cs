using System.Collections;
using ns243;
using ns244;

namespace ns242;

internal class Class6241
{
	protected Queue queue_0 = new Queue();

	protected Class6239 class6239_0;

	public bool IsEmpty => queue_0.Count == 0;

	public Class6241(Class6239 documentCreator)
	{
		class6239_0 = documentCreator;
	}

	public virtual void vmethod_0(Interface260 node)
	{
		queue_0.Enqueue(node);
	}

	public virtual Interface260 vmethod_1()
	{
		return (Interface260)queue_0.Dequeue();
	}

	public virtual Class6233 vmethod_2()
	{
		Class6233 @class = class6239_0.vmethod_1();
		Class6238 documentComposer = class6239_0.DocumentComposer;
		while (queue_0.Count > 0 && documentComposer.vmethod_1(@class, (Interface260)queue_0.Peek()))
		{
			vmethod_1();
		}
		if (queue_0.Count > 0 && queue_0.Peek() is Class6236)
		{
			vmethod_1();
		}
		if (@class.Count <= 0)
		{
			return null;
		}
		return @class;
	}
}
