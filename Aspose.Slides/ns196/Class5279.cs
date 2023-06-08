using System;
using System.Collections;
using ns171;
using ns173;
using ns176;

namespace ns196;

internal abstract class Class5279 : Interface172, Interface173
{
	protected bool bool_0;

	protected bool bool_1;

	protected Class5094 class5094_0;

	public Class5279()
	{
		class5094_0 = null;
	}

	public Class5279(Class5094 fo)
	{
		class5094_0 = fo;
		method_7(fo.vmethod_30());
		if (imethod_18())
		{
			method_8(generatesBlockArea: true);
		}
	}

	public virtual int imethod_0(int lengthBase, Class5094 fobjx)
	{
		if (fobjx == class5094_0)
		{
			return lengthBase switch
			{
				3 => method_3(), 
				4 => method_5(), 
				5 => method_0(), 
				6 => method_1(), 
				_ => 0, 
			};
		}
		Interface173 @interface = imethod_2();
		while (@interface != null && fobjx != @interface.imethod_21())
		{
			@interface = @interface.imethod_2();
		}
		return @interface?.imethod_0(lengthBase, fobjx) ?? 0;
	}

	protected int method_0()
	{
		Interface173 @interface = imethod_2();
		while (true)
		{
			if (@interface != null)
			{
				if (@interface.imethod_19() && !@interface.imethod_20())
				{
					break;
				}
				@interface = @interface.imethod_2();
				continue;
			}
			return 0;
		}
		return @interface.imethod_16();
	}

	protected int method_1()
	{
		Interface173 @interface = imethod_2();
		while (true)
		{
			if (@interface != null)
			{
				if (@interface.imethod_19() && !@interface.imethod_20())
				{
					break;
				}
				@interface = @interface.imethod_2();
				continue;
			}
			return 0;
		}
		return @interface.imethod_17();
	}

	protected Class5285 method_2()
	{
		Interface173 @interface = imethod_2();
		Class5285 @class;
		while (true)
		{
			if (@interface != null)
			{
				@class = @interface as Class5285;
				if (@class != null)
				{
					int int_ = @class.CommonAbsolutePosition.int_0;
					if (int_ == 1 || int_ == 206 || int_ == 110)
					{
						break;
					}
					if (@class.method_67().IsBodyElement)
					{
						return @class.imethod_2().imethod_2() as Class5285;
					}
					if (int_ == 9 && this is Class5285 class2 && class2.CommonAbsolutePosition.int_0 == 1 && class2.CommonAbsolutePosition.interface182_3.imethod_0() == 9 && class2.CommonAbsolutePosition.interface182_1.imethod_0() == 9 && class2.CommonAbsolutePosition.interface182_0.imethod_0() == 9 && class2.CommonAbsolutePosition.interface182_2.imethod_0() == 9)
					{
						return @class;
					}
					if (@interface.imethod_2() is Class5297)
					{
						return @class;
					}
				}
				@interface = @interface.imethod_2();
				continue;
			}
			return null;
		}
		return @class;
	}

	protected int method_3()
	{
		return imethod_2()?.imethod_16() ?? 0;
	}

	protected int method_4()
	{
		return imethod_2()?.imethod_17() ?? 0;
	}

	public int method_5()
	{
		Interface173 @interface = imethod_2();
		while (true)
		{
			if (@interface != null)
			{
				if (@interface.imethod_18())
				{
					break;
				}
				@interface = @interface.imethod_2();
				continue;
			}
			return 0;
		}
		return @interface.imethod_16();
	}

	protected int method_6()
	{
		Interface173 @interface = imethod_2();
		while (true)
		{
			if (@interface != null)
			{
				if (@interface.imethod_18())
				{
					if (@interface is Class5285)
					{
						Class5285 @class = @interface as Class5285;
						int int_ = @class.method_67().method_48().int_0;
						if (int_ == 1 || int_ == 51 || int_ == 206 || int_ == 215)
						{
							return @interface.imethod_17();
						}
					}
					else if (@interface is Class5297)
					{
						break;
					}
				}
				@interface = @interface.imethod_2();
				continue;
			}
			return 0;
		}
		return @interface.imethod_17();
	}

	public abstract void imethod_1(Interface173 lm);

	public abstract Interface173 imethod_2();

	public abstract void imethod_3();

	public abstract Class5322 imethod_4();

	public abstract bool imethod_5();

	public abstract void imethod_6(bool isFinished);

	public abstract Class4942 imethod_7(Class4942 childArea);

	public abstract void imethod_8(Class4942 childArea);

	public abstract void imethod_9(Class5652 posIter, Class5687 context);

	public abstract bool imethod_10(int pos);

	public abstract ArrayList imethod_11();

	public abstract void imethod_12(Interface173 lm);

	public abstract void imethod_13(ArrayList newLMs);

	public abstract ArrayList imethod_14(Class5687 context, int alignment);

	public abstract ArrayList imethod_15(ArrayList oldList, int alignment);

	public virtual int imethod_16()
	{
		throw new NotSupportedException("getContentAreaIPD() called when it should have been overridden");
	}

	public virtual int imethod_17()
	{
		throw new NotSupportedException("getContentAreaBPD() called when it should have been overridden");
	}

	public virtual bool imethod_18()
	{
		return bool_0;
	}

	protected void method_7(bool generatesReferenceArea)
	{
		bool_0 = generatesReferenceArea;
	}

	public virtual bool imethod_19()
	{
		return bool_1;
	}

	protected void method_8(bool generatesBlockArea)
	{
		bool_1 = generatesBlockArea;
	}

	public virtual bool imethod_20()
	{
		return false;
	}

	public Class5094 imethod_21()
	{
		return class5094_0;
	}

	public bool imethod_25()
	{
		return imethod_2()?.imethod_25() ?? false;
	}

	public abstract Class5254 imethod_22(Class5254 pos);

	public virtual void imethod_23()
	{
		throw new NotSupportedException("Not implemented");
	}

	public virtual bool imethod_24()
	{
		return false;
	}

	public virtual ArrayList imethod_26(Class5687 context, int alignment, Stack lmStack, Class5254 positionAtIPDChange, Interface173 restartAtLM)
	{
		throw new NotSupportedException("Not implemented");
	}
}
