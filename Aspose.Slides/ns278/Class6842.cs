using System;
using System.Collections;
using System.Drawing;
using ns277;
using ns284;
using ns290;
using ns301;

namespace ns278;

internal class Class6842 : Class6839, IDisposable
{
	private readonly SizeF sizeF_0;

	private bool bool_0;

	public Class6842(float width, float height)
		: this(new SizeF(width, height))
	{
	}

	public Class6842(SizeF pageSize)
		: base(new Class6761(new Size((int)pageSize.Width, (int)pageSize.Height)), new Class6945())
	{
		sizeF_0 = pageSize;
	}

	public override void vmethod_0(Class6844 boxModel)
	{
		Class6892.smethod_0(boxModel, "boxModel");
		class6759_0.vmethod_3();
		interface353_0.Reset();
		Hashtable pageSet = new Hashtable();
		boxModel.vmethod_0(this, boxType: false, ref pageSet);
	}

	public override void vmethod_1(Class6844 boxModel, ref Hashtable pageSet)
	{
		Class6892.smethod_0(boxModel, "boxModel");
		class6759_0.vmethod_3();
		interface353_0.Reset();
		boxModel.vmethod_0(this, boxType: true, ref pageSet);
	}

	public override Interface329 vmethod_2()
	{
		return new Class6897();
	}

	public override float vmethod_3()
	{
		return sizeF_0.Width;
	}

	public override float vmethod_4()
	{
		return sizeF_0.Height;
	}

	public override object vmethod_5()
	{
		return class6759_0.vmethod_4();
	}

	public void Dispose()
	{
		Dispose(disposing: true);
		GC.SuppressFinalize(this);
	}

	protected void Dispose(bool disposing)
	{
		if (!bool_0)
		{
			if (disposing)
			{
				(class6759_0 as Class6761).Dispose();
			}
			bool_0 = true;
		}
	}
}
