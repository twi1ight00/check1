using System;
using System.Collections;
using ns103;
using ns118;
using ns126;
using ns131;
using ns152;
using ns154;
using ns99;

namespace ns115;

internal abstract class Class4469 : Interface116
{
	public delegate void Delegate2778();

	protected Class4704 class4704_0;

	protected Class4705 class4705_0;

	protected Class4706 class4706_0;

	protected Class4707 class4707_0;

	protected Class4703 class4703_0;

	protected Class4715 class4715_0;

	protected Interface127 interface127_0;

	private Class4460 class4460_0;

	private static Hashtable hashtable_0 = new Hashtable();

	private object object_0 = new object();

	public Class4704 DictionaryStack => class4704_0;

	public Class4705 ExecutionStack => class4705_0;

	public Class4706 GraphStateStack => class4706_0;

	public Class4707 OperandStack => class4707_0;

	public Class4703 ClippingPathStack => class4703_0;

	public Interface127 ErrorHandler => interface127_0;

	public Class4715 Subroutines => class4715_0;

	public Class4460 CommandProcessor
	{
		get
		{
			return class4460_0;
		}
		set
		{
			class4460_0 = value;
		}
	}

	public Class4469()
		: this(new Class4715())
	{
	}

	public Class4469(Class4715 subroutines)
	{
		class4707_0 = new Class4707();
		class4704_0 = new Class4704();
		class4705_0 = new Class4705();
		class4706_0 = new Class4706();
		class4703_0 = new Class4703();
		class4715_0 = subroutines;
		interface127_0 = Class4516.Instance.ErrorHandlerFactory.imethod_0();
	}

	public void imethod_0(Class4552 psProgram)
	{
		try
		{
			Class4455 @class = vmethod_0(psProgram);
			while (@class.Read())
			{
				vmethod_1(@class);
			}
		}
		catch (Exception innerException)
		{
			throw new Exception50("Could not run font program", innerException);
		}
	}

	protected abstract Class4455 vmethod_0(Class4552 psProgram);

	protected abstract void vmethod_1(Class4455 programReader);

	protected void method_0(string name)
	{
		string key = GetType().FullName + name;
		if (hashtable_0.ContainsKey(key))
		{
			return;
		}
		lock (object_0)
		{
			if (!hashtable_0.ContainsKey(key))
			{
				hashtable_0.Add(key, name);
				interface127_0.imethod_0($"PostScript error. Operator \"{name}\" is not supported.");
			}
		}
	}
}
