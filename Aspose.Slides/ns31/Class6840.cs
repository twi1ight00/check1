using System;
using System.Collections;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Import;
using ns277;
using ns284;
using ns290;

namespace ns31;

internal class Class6840 : Class6839
{
	private SizeF sizeF_0;

	public Class6840(Presentation pres, int index, float borderWidth, IHtmlExternalResolver resolver, string baseUri)
		: base(new Class6760(pres, index, new PointF(borderWidth, borderWidth), resolver, baseUri), new Class6945())
	{
		sizeF_0 = pres.SlideSize.Size;
		sizeF_0.Width -= borderWidth * 2f;
		sizeF_0.Height -= borderWidth * 2f;
	}

	public override void vmethod_0(Class6844 boxModel)
	{
		if (boxModel == null)
		{
			throw new ArgumentNullException("boxModel");
		}
		class6759_0.vmethod_3();
		interface353_0.Reset();
		Hashtable pageSet = new Hashtable();
		boxModel.vmethod_0(this, boxType: false, ref pageSet);
		((Class6760)class6759_0).method_2(null);
	}

	public override void vmethod_1(Class6844 boxTree, ref Hashtable pageSet)
	{
		throw new NotImplementedException();
	}

	public override float vmethod_3()
	{
		return sizeF_0.Width;
	}

	public override float vmethod_4()
	{
		return sizeF_0.Height;
	}

	public override Interface329 vmethod_2()
	{
		return new Class6897();
	}

	public override object vmethod_5()
	{
		return method_0();
	}

	public ISlide[] method_0()
	{
		return (ISlide[])class6759_0.vmethod_4();
	}
}
