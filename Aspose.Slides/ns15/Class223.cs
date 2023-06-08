using System;
using ns16;
using ns56;
using ns57;
using ns63;

namespace ns15;

internal class Class223
{
	public static void smethod_0(Class2280 timeNodeCommandBehavior, Class2651 timeNodeContainer, Class854 deserializationContext)
	{
		if (timeNodeContainer == null || timeNodeContainer.TimeCommandBehavior == null)
		{
			throw new InvalidOperationException();
		}
		Class2656 timeCommandBehavior = timeNodeContainer.TimeCommandBehavior;
		Class222.smethod_0(timeNodeCommandBehavior.CBhvr, timeNodeContainer, timeCommandBehavior.Behavior, deserializationContext);
		smethod_2(timeNodeCommandBehavior, timeCommandBehavior);
	}

	public static void smethod_1(Class2280 timeNodeCommandBehavior, Class2650 timeNodeContainer, Class854 deserializationContext)
	{
		if (timeNodeContainer == null || timeNodeContainer.TimeCommandBehavior == null)
		{
			throw new InvalidOperationException();
		}
		Class2656 timeCommandBehavior = timeNodeContainer.TimeCommandBehavior;
		Class222.smethod_1(timeNodeCommandBehavior.CBhvr, timeNodeContainer, timeCommandBehavior.Behavior, deserializationContext);
		smethod_2(timeNodeCommandBehavior, timeCommandBehavior);
	}

	private static void smethod_2(Class2280 timeNodeCommandBehavior, Class2656 timeCommandBehavior)
	{
		if (timeCommandBehavior == null)
		{
			throw new InvalidOperationException();
		}
		timeNodeCommandBehavior.Type = smethod_3(timeCommandBehavior.CommandBehaviorAtom.Type);
		timeNodeCommandBehavior.Cmd = ((timeCommandBehavior.VarCommand == null) ? null : timeCommandBehavior.VarCommand.Value);
	}

	private static Enum288 smethod_3(uint commandType)
	{
		return commandType switch
		{
			0u => Enum288.const_1, 
			1u => Enum288.const_2, 
			2u => Enum288.const_3, 
			_ => Enum288.const_0, 
		};
	}

	private static ushort smethod_4(Enum288 commandType)
	{
		return commandType switch
		{
			Enum288.const_1 => 0, 
			Enum288.const_2 => 1, 
			Enum288.const_3 => 2, 
			_ => throw new NotImplementedException(), 
		};
	}

	public static void smethod_5(Class2280 commandBehaviorElementData, Class2650 timeNodeContainer, Class234 timelineSerializationContext)
	{
		if (commandBehaviorElementData != null)
		{
			if (timeNodeContainer == null)
			{
				throw new InvalidOperationException();
			}
			Class2656 @class = new Class2656();
			timeNodeContainer.Records.Add(@class);
			smethod_6(commandBehaviorElementData, @class);
			if (@class.CommandBehaviorAtom.FCommandPropertyUsed)
			{
				Class2764 item = new Class2764(commandBehaviorElementData.Cmd);
				@class.Records.Add(item);
			}
			Class2654 class2 = new Class2654();
			@class.Records.Add(class2);
			Class225.smethod_32(commandBehaviorElementData.CBhvr, class2, timelineSerializationContext);
		}
	}

	private static void smethod_6(Class2280 commandBehaviorElementData, Class2656 timeCommandBehaviorContainer)
	{
		if (commandBehaviorElementData == null)
		{
			throw new ArgumentNullException();
		}
		if (timeCommandBehaviorContainer == null)
		{
			throw new ArgumentNullException();
		}
		Class2749 @class = new Class2749();
		timeCommandBehaviorContainer.Records.Add(@class);
		if (commandBehaviorElementData.Type != Enum288.const_0)
		{
			@class.FTypePropertyUsed = true;
			@class.CommandBehaviorType = smethod_4(commandBehaviorElementData.Type);
		}
		else
		{
			@class.FTypePropertyUsed = false;
		}
		if (!string.IsNullOrEmpty(commandBehaviorElementData.Cmd))
		{
			@class.FCommandPropertyUsed = true;
		}
		else
		{
			@class.FCommandPropertyUsed = false;
		}
	}
}
