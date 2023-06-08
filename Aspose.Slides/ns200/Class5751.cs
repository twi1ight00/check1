using System;
using System.Collections;
using System.IO;
using System.Reflection;
using ns171;
using ns173;
using ns175;
using ns201;
using ns207;

namespace ns200;

internal class Class5751
{
	private Hashtable hashtable_0 = new Hashtable();

	private Hashtable hashtable_1 = new Hashtable();

	private Hashtable hashtable_2 = new Hashtable();

	private bool bool_0;

	public Class5751()
	{
		method_17();
	}

	public void method_0(bool value)
	{
		bool_0 = value;
	}

	public bool method_1()
	{
		return bool_0;
	}

	public void method_2(Class5368 maker)
	{
		string[] array = maker.vmethod_2();
		for (int i = 0; i < array.Length; i++)
		{
			_ = hashtable_0[array[i]];
			hashtable_0.Add(array[i], maker);
		}
	}

	public void method_3(Class5698 maker)
	{
		string[] array = maker.vmethod_2();
		for (int i = 0; i < array.Length; i++)
		{
			hashtable_1.Add(array[i], maker);
		}
	}

	public void method_4(Class5456 maker)
	{
		string[] array = maker.vmethod_2();
		for (int i = 0; i < array.Length; i++)
		{
			hashtable_2.Add(array[i], maker);
		}
	}

	public void method_5(string className)
	{
		try
		{
			Class5368 maker = (Class5368)Type.GetType(className).GetConstructor(Type.EmptyTypes).Invoke(null);
			method_2(maker);
		}
		catch (Exception)
		{
			throw new ArgumentException("Could not instantiate " + className);
		}
	}

	public void method_6(string className)
	{
		try
		{
			Class5698 maker = (Class5698)Type.GetType(className).GetConstructor(Type.EmptyTypes).Invoke(null);
			method_3(maker);
		}
		catch (Exception)
		{
			throw new ArgumentException("Could not instantiate " + className);
		}
	}

	public void method_7(string className)
	{
		try
		{
			Class5456 maker = (Class5456)Type.GetType(className).GetConstructor(Type.EmptyTypes).Invoke(null);
			method_4(maker);
		}
		catch (Exception)
		{
			throw new ArgumentException("Could not instantiate " + className);
		}
	}

	public Class5368 method_8(string mime)
	{
		return (Class5368)hashtable_0[mime];
	}

	public Class5698 method_9(string mime)
	{
		return (Class5698)hashtable_1[mime];
	}

	public Class5456 method_10(string mime)
	{
		return (Class5456)hashtable_2[mime];
	}

	public Interface177 method_11(Class5738 userAgent, string outputFormat)
	{
		if (userAgent.method_2() != null)
		{
			return smethod_0(userAgent.method_2());
		}
		if (userAgent.method_4() != null)
		{
			return userAgent.method_4();
		}
		Interface177 @interface;
		if (method_1())
		{
			@interface = method_13(userAgent, outputFormat);
			if (@interface == null)
			{
				@interface = method_12(userAgent, outputFormat);
			}
		}
		else
		{
			@interface = method_12(userAgent, outputFormat);
			if (@interface == null)
			{
				@interface = method_13(userAgent, outputFormat);
			}
		}
		if (@interface == null)
		{
			throw new NotSupportedException("No renderer for the requested format available: " + outputFormat);
		}
		return @interface;
	}

	private Interface177 method_12(Class5738 userAgent, string outputFormat)
	{
		Class5456 @class = method_10(outputFormat);
		if (@class != null)
		{
			Interface196 documentHandler = method_15(userAgent, outputFormat);
			return smethod_0(documentHandler);
		}
		return null;
	}

	private Interface177 method_13(Class5738 userAgent, string outputFormat)
	{
		Class5368 @class = method_8(outputFormat);
		if (@class != null)
		{
			Interface177 @interface = @class.vmethod_0(userAgent);
			@class.vmethod_3(userAgent)?.imethod_2(@interface);
			return @interface;
		}
		return null;
	}

	private static Interface177 smethod_0(Interface196 documentHandler)
	{
		return null;
	}

	public Class4866 method_14(Class5738 userAgent, string outputFormat, Stream @out)
	{
		if (userAgent.method_6() != null)
		{
			return userAgent.method_6();
		}
		Class5698 @class = method_9(outputFormat);
		if (@class != null)
		{
			return @class.vmethod_0(userAgent, @out);
		}
		Class5368 class2 = method_8(outputFormat);
		Class5456 class3 = null;
		bool flag = userAgent.method_4() == null && userAgent.method_2() == null;
		if (class2 == null)
		{
			class3 = method_10(outputFormat);
			if (class3 != null)
			{
				flag &= @out == null && class3.vmethod_1();
			}
		}
		else
		{
			flag &= @out == null && class2.vmethod_1();
		}
		if (userAgent.method_4() == null && class2 == null && userAgent.method_2() == null && class3 == null)
		{
			throw new NotSupportedException("Don't know how to handle \"" + outputFormat + "\" as an output format. Neither an FOEventHandler, nor a Renderer could be found for this output format.");
		}
		if (flag)
		{
			throw new Exception53("OutputStream has not been set");
		}
		return new Class4872(userAgent, outputFormat, @out);
	}

	public Interface196 method_15(Class5738 userAgent, string outputFormat)
	{
		if (userAgent.method_2() != null)
		{
			return userAgent.method_2();
		}
		Class5456 @class = method_10(outputFormat);
		if (@class == null)
		{
			throw new NotSupportedException("No IF document handler for the requested format available: " + outputFormat);
		}
		Interface196 @interface = @class.vmethod_0(userAgent);
		@interface.imethod_5()?.imethod_0(@interface);
		return new Class5463(@interface, userAgent);
	}

	public string[] method_16()
	{
		ArrayList arrayList = new ArrayList();
		foreach (string key in hashtable_0.Keys)
		{
			arrayList.Add(key);
		}
		foreach (string key2 in hashtable_1.Keys)
		{
			arrayList.Add(key2);
		}
		foreach (string key3 in hashtable_2.Keys)
		{
			arrayList.Add(key3);
		}
		arrayList.Sort();
		return (string[])arrayList.ToArray(typeof(string));
	}

	private void method_17()
	{
		method_2(new Class5369());
		method_2(new Class5370());
	}

	private void method_18()
	{
		Type[] types = Assembly.GetExecutingAssembly().GetTypes();
		Type[] array = types;
		foreach (Type type in array)
		{
			if (type.IsSubclassOf(typeof(Class5698)))
			{
				Class5698 maker = (Class5698)type.GetConstructor(Type.EmptyTypes).Invoke(null);
				method_3(maker);
			}
		}
	}

	private void method_19()
	{
		Type[] types = Assembly.GetExecutingAssembly().GetTypes();
		Type[] array = types;
		foreach (Type type in array)
		{
			if (type.IsSubclassOf(typeof(Interface196)))
			{
				Class5456 maker = (Class5456)type.GetConstructor(Type.EmptyTypes).Invoke(null);
				method_4(maker);
			}
		}
	}
}
