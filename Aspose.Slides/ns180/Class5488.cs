using System;
using System.Collections;
using System.Reflection;
using ns171;
using ns177;
using ns183;
using ns184;
using ns192;
using ns196;
using ns203;

namespace ns180;

internal class Class5488 : Interface207
{
	internal class Class5490 : Interface178
	{
		private Class4984 class4984_0;

		private Class5488 class5488_0;

		private Class5490(Class4984 producerModel, Class5488 owner)
		{
			class4984_0 = producerModel;
			class5488_0 = owner;
		}

		public static object smethod_0(Type type, Class4984 producerModel, Class5488 owner)
		{
			return Class5373.smethod_0().method_1(new Class5490(producerModel, owner), type);
		}

		public object Invoke(object proxy, MethodInfo method, object[] parameters)
		{
			string name = method.Name;
			Class4933 @class = class4984_0.method_3(name);
			string text = class4984_0.method_0() + "." + name;
			if (@class == null)
			{
				throw new InvalidOperationException("Event model isn't consistent with the EventProducer interface. Please rebuild FOP! Affected method: " + text);
			}
			Hashtable hashtable = new Hashtable();
			int num = 1;
			Interface208 @interface = new Class5495(@class.method_6());
			while (@interface.imethod_0())
			{
				Class4933.Class4934 class2 = (Class4933.Class4934)@interface.imethod_1();
				hashtable.Add(class2.method_1(), parameters[num]);
				num++;
			}
			Class5596 class3 = new Class5596(parameters[0], text, @class.method_5(), hashtable);
			class5488_0.imethod_3(class3);
			if (class3.method_4() == Class5598.class5598_3)
			{
				throw new Exception(@class.method_8());
			}
			return null;
		}
	}

	protected Class5484 class5484_0 = new Class5484();

	private static ArrayList arrayList_0 = new ArrayList();

	private Hashtable hashtable_0 = new Hashtable();

	public void imethod_0(Interface156 listener)
	{
		class5484_0.method_0(listener);
	}

	public void imethod_1(Interface156 listener)
	{
		class5484_0.method_1(listener);
	}

	public bool imethod_2()
	{
		return class5484_0.method_3();
	}

	public virtual void imethod_3(Class5596 @event)
	{
		class5484_0.imethod_0(@event);
	}

	private static Class4935 smethod_0()
	{
		return new Class4935();
	}

	public static void smethod_1(Class4935 eventModel)
	{
		arrayList_0.Add(eventModel);
	}

	private static Class4984 smethod_2(Type clazz)
	{
		int num = 0;
		int count = arrayList_0.Count;
		Class4984 class2;
		while (true)
		{
			if (num < count)
			{
				Class4935 @class = (Class4935)arrayList_0[num];
				class2 = @class.method_3(clazz);
				if (class2 != null)
				{
					break;
				}
				num++;
				continue;
			}
			Class4935 class3 = smethod_0();
			smethod_1(class3);
			return class3.method_3(clazz);
		}
		return class2;
	}

	public Interface158 imethod_4(Type clazz)
	{
		if (!typeof(Interface158).IsAssignableFrom(clazz))
		{
			throw new ArgumentException("Class must be an implementation of the EventProducer interface: " + clazz.FullName);
		}
		Interface158 @interface = (Interface158)hashtable_0[clazz];
		if (@interface == null)
		{
			@interface = method_0(clazz);
			hashtable_0.Add(clazz, @interface);
		}
		return @interface;
	}

	protected Interface158 method_0(Type clazz)
	{
		if (clazz == typeof(Interface206))
		{
			return new Class5485();
		}
		if (clazz == typeof(Interface205))
		{
			return new Class5487();
		}
		if (clazz == typeof(Interface191))
		{
			return new Class5486();
		}
		if (!(clazz == typeof(Interface245)))
		{
			throw new Exception("Unspecified event producer");
		}
		return new Class5755();
	}
}
