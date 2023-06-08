using System;
using System.Collections.Generic;
using ns305;

namespace ns304;

internal class Class7060
{
	private readonly List<Class6976> list_0;

	private readonly Class6976 class6976_0;

	private readonly Class7059 class7059_0;

	private readonly Enum962 enum962_0;

	private bool bool_0;

	private bool bool_1;

	public bool DefaultActionPrevented => bool_1;

	public bool EventPropagationStopped => bool_0;

	public Class7060(Class6976 target, Class7059 @event, Enum962 direction)
	{
		if (target == null)
		{
			throw new ArgumentNullException("target");
		}
		if (@event == null)
		{
			throw new ArgumentNullException("event");
		}
		list_0 = new List<Class6976>();
		class6976_0 = target;
		class7059_0 = @event;
		enum962_0 = direction;
		method_5();
	}

	public void method_0()
	{
		bool_0 = true;
	}

	public void method_1()
	{
		bool_1 = true;
	}

	public bool method_2()
	{
		if ((enum962_0 == Enum962.const_2 || enum962_0 == Enum962.const_1) && !method_3(Enum962.const_1))
		{
			return false;
		}
		if ((enum962_0 == Enum962.const_2 || enum962_0 == Enum962.const_0) && !method_3(Enum962.const_0))
		{
			return false;
		}
		return true;
	}

	private bool method_3(Enum962 executionDirection)
	{
		List<Class6976> list = ((executionDirection == Enum962.const_1) ? new List<Class6976>(list_0) : list_0);
		if (executionDirection == Enum962.const_1)
		{
			list.Reverse();
		}
		foreach (Class6976 item in list)
		{
			ICollection<Interface365> collection = item.method_18(class7059_0, executionDirection);
			if (collection.Count > 0)
			{
				class7059_0.CurrentTarget = item;
			}
			foreach (Interface365 item2 in collection)
			{
				if (!method_4(item2))
				{
					return false;
				}
			}
		}
		return true;
	}

	public bool method_4(Interface365 listener)
	{
		listener.imethod_0(class7059_0);
		return !bool_0;
	}

	private void method_5()
	{
		method_6(class6976_0);
		for (Class6976 parentNode = class6976_0.ParentNode; parentNode != null; parentNode = parentNode.ParentNode)
		{
			method_6(parentNode);
		}
	}

	private void method_6(Class6976 node)
	{
		if (node.method_19(class7059_0))
		{
			list_0.Add(node);
		}
	}
}
