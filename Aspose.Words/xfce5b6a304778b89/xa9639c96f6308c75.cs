using System;
using System.Collections;
using System.Text;
using Aspose.Words;
using Aspose.Words.Drawing;
using x011d489fb9df7027;
using x28925c9b27b37a46;
using x6c95d9cf46ff5f25;
using xbe73d5820f7f4ae3;
using xf9a9481c3f63a419;

namespace xfce5b6a304778b89;

internal class xa9639c96f6308c75
{
	private readonly ArrayList x7c7d5705ddbe0a35;

	private xf7125312c7ee115c xc0d860684e1ba27c;

	private x7efbe0a2dc0d335f[] x751e80695ccd5699;

	private readonly StringBuilder x800085dd555f7711;

	private readonly ArrayList x89e0b4ecdad90a5c;

	private string[] x7e3dfe13e514097a;

	private string[] x9a3bd875129a2a07;

	private string[] x990d4aed39647c0e;

	private int xb14027057a3627a1;

	private int x9f9b2b1a8c54f9e4;

	private int x9aa0a23ec879885f;

	private int xee7c34639947c937;

	private bool xb26cd320172255d5;

	private bool xddbd82ce570fb637;

	private Shape x317be79405176667;

	internal bool x13e058df34e523fc
	{
		set
		{
			xb26cd320172255d5 = value;
		}
	}

	internal xa9639c96f6308c75()
	{
		x800085dd555f7711 = new StringBuilder();
		x89e0b4ecdad90a5c = new ArrayList();
		x7c7d5705ddbe0a35 = new ArrayList();
		xb26cd320172255d5 = false;
	}

	internal void x06b0e25aa6ad68a9(xf871da68decec406 xe134235b3526fa75, CompositeNode x8b2c3c076d5a7daf, xeedad81aaed42a76 x789564759d365819)
	{
		xbb857c9fc36f5054.xcbe65b21f4ea2cf5 = 1.0;
		x317be79405176667 = new Shape(xe134235b3526fa75.x2c8c6741422a1298);
		string xa66385d80d4d296f = xe134235b3526fa75.xca994afbcb9073a2.xa66385d80d4d296f;
		x789564759d365819?.xab3af626b1405ee8(x317be79405176667.xeedad81aaed42a76);
		xc0d860684e1ba27c = new xf7125312c7ee115c();
		xc0d860684e1ba27c.xae20093bed1e48a8(4155, ShapeType.NonPrimitive);
		x0409d0a28e802088(xe134235b3526fa75);
		x253dc1c25dfd49a2.x0c1288d16c9571df(xe134235b3526fa75, x317be79405176667.xf7125312c7ee115c);
		x99b7395bd62dfc13(xe134235b3526fa75, xa66385d80d4d296f);
		xc0d860684e1ba27c.xab3af626b1405ee8(x317be79405176667.xf7125312c7ee115c);
		x253dc1c25dfd49a2.xc6b4c0fd353e4c10(x317be79405176667, (x1ba13e535f55aa54)xe134235b3526fa75.x37eb83f4e2a8fe56.get_xe6d4b1b411ed94b5(xe134235b3526fa75.xe5ffcf1e3f9bd387, "graphic", xe134235b3526fa75.xb9e32c79bd755ad8, xafd04c36a00d5bcf: true));
		x8b2c3c076d5a7daf.AppendChild(x317be79405176667);
	}

	private void x99b7395bd62dfc13(xf871da68decec406 xe134235b3526fa75, string x121383aa64985888)
	{
		x536e1b48249b1390 xca994afbcb9073a = xe134235b3526fa75.xca994afbcb9073a2;
		while (xca994afbcb9073a.x152cbadbfa8061b1(x121383aa64985888))
		{
			string xa66385d80d4d296f;
			if (!xf871da68decec406.x52b97b00d3a73947(xe134235b3526fa75, x317be79405176667) && !xe134235b3526fa75.xb18e918c8e329f66(xc0d860684e1ba27c) && (xa66385d80d4d296f = xca994afbcb9073a.xa66385d80d4d296f) != null && xa66385d80d4d296f == "enhanced-geometry")
			{
				xeaa791ae8a1fe8b7(xe134235b3526fa75);
			}
		}
		if (xddbd82ce570fb637)
		{
			xc0d860684e1ba27c.xae20093bed1e48a8(192, x317be79405176667.GetText());
			x317be79405176667.ChildNodes.Clear();
		}
		if (x751e80695ccd5699 != null && x751e80695ccd5699.Length > 0)
		{
			x317be79405176667.xf7125312c7ee115c.xae20093bed1e48a8(341, x751e80695ccd5699);
		}
	}

	private void x0409d0a28e802088(xf871da68decec406 xe134235b3526fa75)
	{
		xe134235b3526fa75.xe5ffcf1e3f9bd387 = null;
		x536e1b48249b1390 xca994afbcb9073a = xe134235b3526fa75.xca994afbcb9073a2;
		string x8b0a6a8c69ab5cff = "";
		while (xca994afbcb9073a.x1ac1960adc8c4c39())
		{
			if (!xe134235b3526fa75.x42e780a8d918ac91(xe134235b3526fa75.xca994afbcb9073a2, xc0d860684e1ba27c) && !xf871da68decec406.x46e6752379e6650e(xe134235b3526fa75, xc0d860684e1ba27c) && !xf871da68decec406.xec2649804854d946(xe134235b3526fa75, xc0d860684e1ba27c))
			{
				switch (xca994afbcb9073a.xa66385d80d4d296f)
				{
				case "viewBox":
					xf871da68decec406.x08b1f2bf85ce1fc8(xe134235b3526fa75, xca994afbcb9073a.xd2f68ee6f47e9dfb, xbee336e5a17b0d53: false, x74a48429afea3d90: false, xc0d860684e1ba27c);
					x1db486128dc3182b();
					break;
				case "points":
					x321be38d1b51099b(xca994afbcb9073a.xd2f68ee6f47e9dfb);
					break;
				case "transform":
					x8b0a6a8c69ab5cff = xca994afbcb9073a.xd2f68ee6f47e9dfb;
					break;
				}
			}
		}
		xf871da68decec406.xc8cbf0c64adea241(xc0d860684e1ba27c, x8b0a6a8c69ab5cff);
	}

	private void x321be38d1b51099b(string xbcea506a33cf9111)
	{
		string text = null;
		string[] array = xbcea506a33cf9111.Split(' ');
		string[] array2 = array;
		foreach (string text2 in array2)
		{
			text = ((text == null) ? "M" : $"{text} L");
			string[] array3 = text2.Split(',');
			if (array3.Length == 2)
			{
				text = $"{text} {array3[0]} {array3[1]}";
			}
		}
		if (text != null)
		{
			text = (xb26cd320172255d5 ? $"F {text} N" : $"{text} Z N");
		}
		xa445729974c4e73a(text);
		x9f5c33e0f81d3687();
	}

	private void xeaa791ae8a1fe8b7(xf871da68decec406 xe134235b3526fa75)
	{
		x7590ccd7b2b07827(xe134235b3526fa75);
		x4723aa4260cfaf02(xe134235b3526fa75);
		x53e00e054b13508d();
		x9f5c33e0f81d3687();
		x84dcc9c11f258c54();
		x6488998a0e729547();
	}

	private void x53e00e054b13508d()
	{
		foreach (xa2313d37664d395d item in x7c7d5705ddbe0a35)
		{
			x1a624762a20029c1(item);
		}
	}

	private void x1a624762a20029c1(xa2313d37664d395d x4d39a4525312c823)
	{
		x4d39a4525312c823.x381641d4b9ba8e82 = x92c030a1f016d8da(x4d39a4525312c823.x40937ad35b1cf5f7);
		for (int i = 0; i < x4d39a4525312c823.x381641d4b9ba8e82.Length; i++)
		{
			string text = x4d39a4525312c823.x381641d4b9ba8e82[i];
			if (!text.StartsWith("?"))
			{
				continue;
			}
			foreach (xa2313d37664d395d item in x7c7d5705ddbe0a35)
			{
				if (!(item.x759aa16c2016a289 != text.Substring(1)))
				{
					if (item.x6f4c0401bc1b60f7 == null)
					{
						x1a624762a20029c1(item);
					}
					x4d39a4525312c823.x381641d4b9ba8e82[i] = item.x6f4c0401bc1b60f7;
					break;
				}
			}
		}
		Stack stack = new Stack();
		string[] x381641d4b9ba8e = x4d39a4525312c823.x381641d4b9ba8e82;
		foreach (string text2 in x381641d4b9ba8e)
		{
			if (x6d4a6ad83d672440(text2))
			{
				stack.Push(text2);
			}
			else if (xa3ec13fa5b9aace5(text2) || x7c0050fce818bd8b(text2) > 0)
			{
				x1cb62db0b72c9ffe(stack, text2);
			}
		}
		x4d39a4525312c823.x6f4c0401bc1b60f7 = xca004f56614e2431.xcaaeec2e96b2cecc(x13503e0934089641((string)stack.Pop()));
		double num = xca004f56614e2431.xf5ece46c5d72e3b9(x4d39a4525312c823.x6f4c0401bc1b60f7);
		x4d39a4525312c823.x40937ad35b1cf5f7 = (double.IsNaN(num) ? "0" : xca004f56614e2431.xc8ba948e0d631490(x15e971129fd80714.x43fcc3f62534530b(num)));
	}

	private void x1cb62db0b72c9ffe(Stack xa0d7ca4995faa759, string x9c59900ac656fbcd)
	{
		switch (x9c59900ac656fbcd)
		{
		case "[-]":
		{
			string x0d173b5435b4d6ad4 = (string)xa0d7ca4995faa759.Pop();
			xa0d7ca4995faa759.Push(xca004f56614e2431.xcaaeec2e96b2cecc(0.0 - x13503e0934089641(x0d173b5435b4d6ad4)));
			break;
		}
		case "+":
		{
			string x0d173b5435b4d6ad12 = (string)xa0d7ca4995faa759.Pop();
			string x0d173b5435b4d6ad13 = (string)xa0d7ca4995faa759.Pop();
			xa0d7ca4995faa759.Push(xca004f56614e2431.xcaaeec2e96b2cecc(x13503e0934089641(x0d173b5435b4d6ad13) + x13503e0934089641(x0d173b5435b4d6ad12)));
			break;
		}
		case "-":
		{
			string x0d173b5435b4d6ad = (string)xa0d7ca4995faa759.Pop();
			string x0d173b5435b4d6ad2 = (string)xa0d7ca4995faa759.Pop();
			xa0d7ca4995faa759.Push(xca004f56614e2431.xcaaeec2e96b2cecc(x13503e0934089641(x0d173b5435b4d6ad2) - x13503e0934089641(x0d173b5435b4d6ad)));
			break;
		}
		case "*":
		{
			string x0d173b5435b4d6ad7 = (string)xa0d7ca4995faa759.Pop();
			string x0d173b5435b4d6ad8 = (string)xa0d7ca4995faa759.Pop();
			xa0d7ca4995faa759.Push(xca004f56614e2431.xcaaeec2e96b2cecc(x13503e0934089641(x0d173b5435b4d6ad8) * x13503e0934089641(x0d173b5435b4d6ad7)));
			break;
		}
		case "/":
		{
			string x0d173b5435b4d6ad5 = (string)xa0d7ca4995faa759.Pop();
			string x0d173b5435b4d6ad6 = (string)xa0d7ca4995faa759.Pop();
			xa0d7ca4995faa759.Push(xca004f56614e2431.xcaaeec2e96b2cecc(x13503e0934089641(x0d173b5435b4d6ad6) / x13503e0934089641(x0d173b5435b4d6ad5)));
			break;
		}
		case "sin":
		{
			string x0d173b5435b4d6ad9 = (string)xa0d7ca4995faa759.Pop();
			xa0d7ca4995faa759.Push(xca004f56614e2431.xcaaeec2e96b2cecc(Math.Sin(x13503e0934089641(x0d173b5435b4d6ad9))));
			break;
		}
		case "cos":
		{
			string x0d173b5435b4d6ad3 = (string)xa0d7ca4995faa759.Pop();
			xa0d7ca4995faa759.Push(xca004f56614e2431.xcaaeec2e96b2cecc(Math.Cos(x13503e0934089641(x0d173b5435b4d6ad3))));
			break;
		}
		case "if":
		{
			string text = (string)xa0d7ca4995faa759.Pop();
			string text2 = (string)xa0d7ca4995faa759.Pop();
			string x0d173b5435b4d6ad11 = (string)xa0d7ca4995faa759.Pop();
			xa0d7ca4995faa759.Push(xca004f56614e2431.xcaaeec2e96b2cecc(x13503e0934089641((x13503e0934089641(x0d173b5435b4d6ad11) > 0.0) ? text2 : text)));
			break;
		}
		case "abs":
		{
			string x0d173b5435b4d6ad10 = (string)xa0d7ca4995faa759.Pop();
			xa0d7ca4995faa759.Push(xca004f56614e2431.xcaaeec2e96b2cecc(Math.Abs(x13503e0934089641(x0d173b5435b4d6ad10))));
			break;
		}
		case "sqrt":
		{
			double d = x13503e0934089641((string)xa0d7ca4995faa759.Pop());
			xa0d7ca4995faa759.Push(xca004f56614e2431.xcaaeec2e96b2cecc(Math.Sqrt(d)));
			break;
		}
		case "min":
		{
			double num3 = x13503e0934089641((string)xa0d7ca4995faa759.Pop());
			double num4 = x13503e0934089641((string)xa0d7ca4995faa759.Pop());
			xa0d7ca4995faa759.Push(xca004f56614e2431.xcaaeec2e96b2cecc((num4 < num3) ? num4 : num3));
			break;
		}
		case "max":
		{
			double num = x13503e0934089641((string)xa0d7ca4995faa759.Pop());
			double num2 = x13503e0934089641((string)xa0d7ca4995faa759.Pop());
			xa0d7ca4995faa759.Push(xca004f56614e2431.xcaaeec2e96b2cecc((num2 > num) ? num2 : num));
			break;
		}
		case "atan2":
		{
			double x = x13503e0934089641((string)xa0d7ca4995faa759.Pop());
			double y = x13503e0934089641((string)xa0d7ca4995faa759.Pop());
			xa0d7ca4995faa759.Push(xca004f56614e2431.xcaaeec2e96b2cecc(Math.Atan2(y, x)));
			break;
		}
		}
	}

	private double x13503e0934089641(string x0d173b5435b4d6ad)
	{
		if (!x0d299f323d241756.x5959bccb67bbf051(x0d173b5435b4d6ad))
		{
			return 0.0;
		}
		if (x0d173b5435b4d6ad.ToLower() == "pi")
		{
			return Math.PI;
		}
		if (x0d173b5435b4d6ad.ToLower() == "left")
		{
			return xb14027057a3627a1;
		}
		if (x0d173b5435b4d6ad.ToLower() == "top")
		{
			return x9f9b2b1a8c54f9e4;
		}
		if (x0d173b5435b4d6ad.ToLower() == "right")
		{
			if (!xf871da68decec406.x09fe644179189b22)
			{
				return xf871da68decec406.xe7aec7217cdc7f54;
			}
			return (double)xf871da68decec406.xe7aec7217cdc7f54 * xf871da68decec406.x257838bcbdeec4e9;
		}
		if (x0d173b5435b4d6ad.ToLower() == "bottom")
		{
			if (!xf871da68decec406.xfe7eb210c7e884c4)
			{
				return xf871da68decec406.xa1067e457bc8d35e;
			}
			return (double)xf871da68decec406.xa1067e457bc8d35e / xf871da68decec406.x257838bcbdeec4e9;
		}
		double num2;
		if (x0d173b5435b4d6ad[0] == '$')
		{
			int num = xca004f56614e2431.x912616ee70b2d94d(x0d173b5435b4d6ad.Substring(1));
			if (x990d4aed39647c0e == null || num > x990d4aed39647c0e.Length - 1)
			{
				return 0.0;
			}
			num2 = xca004f56614e2431.xf5ece46c5d72e3b9(x990d4aed39647c0e[num]);
			if (!double.IsNaN(num2))
			{
				return num2;
			}
		}
		num2 = xca004f56614e2431.xf5ece46c5d72e3b9(x0d173b5435b4d6ad);
		if (!double.IsNaN(num2))
		{
			return num2;
		}
		return 0.0;
	}

	private void x4723aa4260cfaf02(xf871da68decec406 xe134235b3526fa75)
	{
		x536e1b48249b1390 xca994afbcb9073a = xe134235b3526fa75.xca994afbcb9073a2;
		ArrayList arrayList = new ArrayList();
		while (xca994afbcb9073a.x152cbadbfa8061b1("enhanced-geometry"))
		{
			switch (xca994afbcb9073a.xa66385d80d4d296f)
			{
			case "equation":
				x7c7d5705ddbe0a35.Add(xf6fddfccf2fc3c59(xe134235b3526fa75));
				break;
			case "handle":
				arrayList.Add(xead214f628d62a85(xe134235b3526fa75));
				break;
			}
		}
		if (arrayList.Count > 0)
		{
			x751e80695ccd5699 = (x7efbe0a2dc0d335f[])arrayList.ToArray(typeof(x7efbe0a2dc0d335f));
		}
	}

	private x7efbe0a2dc0d335f xead214f628d62a85(xf871da68decec406 xe134235b3526fa75)
	{
		x536e1b48249b1390 xca994afbcb9073a = xe134235b3526fa75.xca994afbcb9073a2;
		x7efbe0a2dc0d335f x7efbe0a2dc0d335f = new x7efbe0a2dc0d335f();
		x7efbe0a2dc0d335f.x9462c8df936efa39 = new x06e4f09a90ca939a(int.MinValue);
		x7efbe0a2dc0d335f.x11f73230b9b436a7 = new x06e4f09a90ca939a(int.MaxValue);
		x7efbe0a2dc0d335f.x5b051452efe1bbe3 = new x06e4f09a90ca939a(int.MinValue);
		x7efbe0a2dc0d335f.xbed6b6abe5a7fcce = new x06e4f09a90ca939a(int.MaxValue);
		while (xca994afbcb9073a.x1ac1960adc8c4c39())
		{
			switch (xca994afbcb9073a.xa66385d80d4d296f)
			{
			case "handle-position":
			{
				string[] array = xca994afbcb9073a.xd2f68ee6f47e9dfb.Split(' ');
				if (array.Length == 2)
				{
					x7efbe0a2dc0d335f.x3b1bddb38a858693 = x79de541528e074ce(array[0], x361c1895f4aacdca: true);
					x7efbe0a2dc0d335f.x97a3447730c7ceb9 = x79de541528e074ce(array[1], x361c1895f4aacdca: false);
				}
				break;
			}
			case "handle-mirror-horizontal":
				x7efbe0a2dc0d335f.x2f612cdfb1f62c32 = xca994afbcb9073a.xd2f68ee6f47e9dfb == "true";
				break;
			case "handle-mirror-vertical":
				x7efbe0a2dc0d335f.x916221819f469b19 = xca994afbcb9073a.xd2f68ee6f47e9dfb == "true";
				break;
			case "handle-switched":
				x7efbe0a2dc0d335f.xcc2d426b867d703d = xca994afbcb9073a.xd2f68ee6f47e9dfb == "true";
				break;
			case "handle-range-x-minimum":
				x7efbe0a2dc0d335f.x22dfdc5e2d91486e = true;
				x7efbe0a2dc0d335f.x9462c8df936efa39 = xd5f17f7c3ef7064d(xca994afbcb9073a.xd2f68ee6f47e9dfb, x361c1895f4aacdca: true);
				break;
			case "handle-range-x-maximum":
				x7efbe0a2dc0d335f.x22dfdc5e2d91486e = true;
				x7efbe0a2dc0d335f.x11f73230b9b436a7 = xd5f17f7c3ef7064d(xca994afbcb9073a.xd2f68ee6f47e9dfb, x361c1895f4aacdca: true);
				break;
			case "handle-range-y-minimum":
				x7efbe0a2dc0d335f.x22dfdc5e2d91486e = true;
				x7efbe0a2dc0d335f.x5b051452efe1bbe3 = xd5f17f7c3ef7064d(xca994afbcb9073a.xd2f68ee6f47e9dfb, x361c1895f4aacdca: false);
				break;
			case "handle-range-y-maximum":
				x7efbe0a2dc0d335f.x22dfdc5e2d91486e = true;
				x7efbe0a2dc0d335f.xbed6b6abe5a7fcce = xd5f17f7c3ef7064d(xca994afbcb9073a.xd2f68ee6f47e9dfb, x361c1895f4aacdca: false);
				break;
			}
		}
		return x7efbe0a2dc0d335f;
	}

	private x06e4f09a90ca939a xd5f17f7c3ef7064d(string x5b0cc95572fd63ae, bool x361c1895f4aacdca)
	{
		if (!x0d299f323d241756.x5959bccb67bbf051(x5b0cc95572fd63ae))
		{
			return new x06e4f09a90ca939a(0, isFormula: false);
		}
		switch (x5b0cc95572fd63ae)
		{
		case "left":
			return new x06e4f09a90ca939a((!x361c1895f4aacdca) ? (xb14027057a3627a1 + x9aa0a23ec879885f) : 0, isFormula: true);
		case "top":
			return new x06e4f09a90ca939a(x361c1895f4aacdca ? x9f9b2b1a8c54f9e4 : 0, isFormula: true);
		case "right":
			return new x06e4f09a90ca939a(x361c1895f4aacdca ? 1 : (xb14027057a3627a1 + x9aa0a23ec879885f), isFormula: true);
		case "bottom":
			return new x06e4f09a90ca939a((!x361c1895f4aacdca) ? 1 : (x9f9b2b1a8c54f9e4 + xee7c34639947c937), isFormula: true);
		default:
		{
			if (x5b0cc95572fd63ae[0] == '?')
			{
				for (int i = 0; i < x7c7d5705ddbe0a35.Count; i++)
				{
					if (((xa2313d37664d395d)x7c7d5705ddbe0a35[i]).x759aa16c2016a289 == x5b0cc95572fd63ae.Substring(1))
					{
						return new x06e4f09a90ca939a(i + 3, isFormula: true);
					}
				}
			}
			int num;
			if (x5b0cc95572fd63ae[0] == '$')
			{
				num = xca004f56614e2431.x912616ee70b2d94d(x5b0cc95572fd63ae.Substring(1));
				if (num != int.MinValue)
				{
					return new x06e4f09a90ca939a(num + 256, isFormula: true);
				}
			}
			num = xca004f56614e2431.x912616ee70b2d94d(x5b0cc95572fd63ae);
			if (num != int.MinValue)
			{
				return new x06e4f09a90ca939a(xbb857c9fc36f5054.x01c5989f49b62737(num), isFormula: false);
			}
			return new x06e4f09a90ca939a(0, isFormula: false);
		}
		}
	}

	private x98655ffe05324a50 x79de541528e074ce(string x62d3361538860d18, bool x361c1895f4aacdca)
	{
		switch (x62d3361538860d18)
		{
		case "left":
			return new x98655ffe05324a50(x361c1895f4aacdca ? xc548449aaa21fea5.xd93f803ca02a4434 : xc548449aaa21fea5.x82e26649b09596bd, (!x361c1895f4aacdca) ? (xb14027057a3627a1 + x9aa0a23ec879885f) : 0);
		case "top":
			return new x98655ffe05324a50((!x361c1895f4aacdca) ? xc548449aaa21fea5.xd93f803ca02a4434 : xc548449aaa21fea5.x82e26649b09596bd, x361c1895f4aacdca ? x9f9b2b1a8c54f9e4 : 0);
		case "right":
			return new x98655ffe05324a50(x361c1895f4aacdca ? xc548449aaa21fea5.xff654ea4df290dd7 : xc548449aaa21fea5.x82e26649b09596bd, (!x361c1895f4aacdca) ? (xb14027057a3627a1 + x9aa0a23ec879885f) : 0);
		case "bottom":
			return new x98655ffe05324a50(x361c1895f4aacdca ? xc548449aaa21fea5.x82e26649b09596bd : xc548449aaa21fea5.xff654ea4df290dd7, x361c1895f4aacdca ? (x9f9b2b1a8c54f9e4 + xee7c34639947c937) : 0);
		default:
		{
			if (x62d3361538860d18[0] == '?')
			{
				return new x98655ffe05324a50(xc548449aaa21fea5.x82e26649b09596bd, xd5da6750e1df738b(x62d3361538860d18.Substring(1)));
			}
			int num;
			if (x62d3361538860d18[0] == '$')
			{
				num = xca004f56614e2431.x912616ee70b2d94d(x62d3361538860d18.Substring(1));
				if (num != int.MinValue)
				{
					return new x98655ffe05324a50(xc548449aaa21fea5.xfaab97dd0218026f, num);
				}
				if (num != int.MinValue)
				{
					num = xca004f56614e2431.x912616ee70b2d94d(x990d4aed39647c0e[num]);
					if (num != int.MinValue)
					{
						return new x98655ffe05324a50(xc548449aaa21fea5.x82e26649b09596bd, xbb857c9fc36f5054.x01c5989f49b62737(num));
					}
				}
				return new x98655ffe05324a50(xc548449aaa21fea5.x82e26649b09596bd, 0);
			}
			num = xca004f56614e2431.x912616ee70b2d94d(x62d3361538860d18);
			if (num != int.MinValue)
			{
				return new x98655ffe05324a50(xc548449aaa21fea5.x82e26649b09596bd, xbb857c9fc36f5054.x01c5989f49b62737(num));
			}
			return new x98655ffe05324a50();
		}
		}
	}

	private static xa2313d37664d395d xf6fddfccf2fc3c59(xf871da68decec406 xe134235b3526fa75)
	{
		x536e1b48249b1390 xca994afbcb9073a = xe134235b3526fa75.xca994afbcb9073a2;
		xa2313d37664d395d xa2313d37664d395d2 = new xa2313d37664d395d();
		while (xca994afbcb9073a.x1ac1960adc8c4c39())
		{
			switch (xca994afbcb9073a.xa66385d80d4d296f)
			{
			case "name":
				xa2313d37664d395d2.x759aa16c2016a289 = xca994afbcb9073a.xd2f68ee6f47e9dfb;
				break;
			case "formula":
				xa2313d37664d395d2.x40937ad35b1cf5f7 = xca994afbcb9073a.xd2f68ee6f47e9dfb;
				break;
			}
		}
		return xa2313d37664d395d2;
	}

	private void x7590ccd7b2b07827(xf871da68decec406 xe134235b3526fa75)
	{
		x536e1b48249b1390 xca994afbcb9073a = xe134235b3526fa75.xca994afbcb9073a2;
		FlipOrientation flipOrientation = FlipOrientation.None;
		string xbcea506a33cf = "0 0 21600 21600";
		bool xbee336e5a17b0d = false;
		bool x74a48429afea3d = false;
		while (xca994afbcb9073a.x1ac1960adc8c4c39())
		{
			switch (xca994afbcb9073a.xa66385d80d4d296f)
			{
			case "viewBox":
				xbcea506a33cf = xca994afbcb9073a.xd2f68ee6f47e9dfb;
				break;
			case "enhanced-path":
				xa445729974c4e73a(xca994afbcb9073a.xd2f68ee6f47e9dfb);
				break;
			case "modifiers":
				x50be341bb458b0c6(xca994afbcb9073a.xd2f68ee6f47e9dfb);
				break;
			case "text-path":
				xddbd82ce570fb637 = xca994afbcb9073a.xd2f68ee6f47e9dfb == "true";
				xc0d860684e1ba27c.xae20093bed1e48a8(241, xddbd82ce570fb637);
				if (xddbd82ce570fb637)
				{
					xc0d860684e1ba27c.xae20093bed1e48a8(4155, ShapeType.TextPlainText);
				}
				break;
			case "text-areas":
				x7e3dfe13e514097a = xca994afbcb9073a.xd2f68ee6f47e9dfb.Trim().Split(' ');
				break;
			case "mirror-horizontal":
				flipOrientation = ((flipOrientation != FlipOrientation.Vertical) ? FlipOrientation.Horizontal : FlipOrientation.Both);
				break;
			case "mirror-vertical":
				flipOrientation = ((flipOrientation == FlipOrientation.Horizontal) ? FlipOrientation.Both : FlipOrientation.Vertical);
				break;
			case "path-stretchpoint-x":
				xbee336e5a17b0d = true;
				break;
			case "path-stretchpoint-y":
				x74a48429afea3d = true;
				break;
			case "extrusion":
				if (xca994afbcb9073a.xd2f68ee6f47e9dfb == "true")
				{
					xc0d860684e1ba27c.xae20093bed1e48a8(700, true);
				}
				break;
			case "shade-mode":
				xc0d860684e1ba27c.xae20093bed1e48a8(713, (xca994afbcb9073a.xd2f68ee6f47e9dfb == "draft") ? xb156f8ae92094cbb.x1d03f9dbb48b31c4 : xb156f8ae92094cbb.xec144c1134066890);
				break;
			case "projection":
				if (xca994afbcb9073a.xd2f68ee6f47e9dfb == "perspective")
				{
					xc0d860684e1ba27c.xae20093bed1e48a8(765, false);
				}
				break;
			case "extrusion-brightness":
				xc0d860684e1ba27c.xae20093bed1e48a8(722, xbb857c9fc36f5054.x5ea2f04c5aa3dba5(xca994afbcb9073a.xd2f68ee6f47e9dfb));
				break;
			case "extrusion-shininess":
			{
				int num2 = xca004f56614e2431.x912616ee70b2d94d(xca994afbcb9073a.xd2f68ee6f47e9dfb.Replace("%", ""));
				if (num2 != int.MinValue)
				{
					xc0d860684e1ba27c.xae20093bed1e48a8(642, num2 / 10);
				}
				break;
			}
			case "extrusion-specularity":
				xc0d860684e1ba27c.xae20093bed1e48a8(640, xbb857c9fc36f5054.x5ea2f04c5aa3dba5(xca994afbcb9073a.xd2f68ee6f47e9dfb));
				break;
			case "extrusion-diffusion":
				xc0d860684e1ba27c.xae20093bed1e48a8(641, xbb857c9fc36f5054.x5ea2f04c5aa3dba5(xca994afbcb9073a.xd2f68ee6f47e9dfb));
				break;
			case "extrusion-metal":
				if (xca994afbcb9073a.xd2f68ee6f47e9dfb == "true")
				{
					xc0d860684e1ba27c.xae20093bed1e48a8(701, true);
				}
				break;
			case "extrusion-rotation-angle":
				x99e0c26fca42fca3(xc0d860684e1ba27c, 705, 704, -1, xca994afbcb9073a.xd2f68ee6f47e9dfb);
				break;
			case "extrusion-origin":
				x99e0c26fca42fca3(xc0d860684e1ba27c, 718, 719, -1, xca994afbcb9073a.xd2f68ee6f47e9dfb);
				break;
			case "extrusion-first-light-direction":
				x99e0c26fca42fca3(xc0d860684e1ba27c, 723, 724, 725, xca994afbcb9073a.xd2f68ee6f47e9dfb);
				break;
			case "extrusion-second-light-direction":
				x99e0c26fca42fca3(xc0d860684e1ba27c, 727, 728, 729, xca994afbcb9073a.xd2f68ee6f47e9dfb);
				break;
			case "extrusion-rotation-center":
				x99e0c26fca42fca3(xc0d860684e1ba27c, 710, 711, 712, xca994afbcb9073a.xd2f68ee6f47e9dfb);
				break;
			case "extrusion-skew":
			{
				string[] array5 = xca994afbcb9073a.xd2f68ee6f47e9dfb.Split(' ');
				if (array5.Length == 2)
				{
					int num = xca004f56614e2431.x912616ee70b2d94d(array5[0]);
					if (num != int.MinValue)
					{
						xc0d860684e1ba27c.xae20093bed1e48a8(721, num);
					}
					xc0d860684e1ba27c.xae20093bed1e48a8(720, xbb857c9fc36f5054.xba31f88211ebd926(array5[1]));
				}
				break;
			}
			case "extrusion-depth":
			{
				string[] array4 = xca994afbcb9073a.xd2f68ee6f47e9dfb.Split(' ');
				if (array4.Length == 2)
				{
					xc0d860684e1ba27c.xae20093bed1e48a8(645, xbb857c9fc36f5054.xdea5d4100fe5f461(array4[0]));
					xc0d860684e1ba27c.xae20093bed1e48a8(644, x4574ea26106f0edb.x3aa08882c9feaf96(xca004f56614e2431.xec25d08a2af152f0(array4[1])));
				}
				break;
			}
			case "extrusion-viewpoint":
			{
				string[] array3 = xca994afbcb9073a.xd2f68ee6f47e9dfb.Replace("(", "").Replace(")", "").Split(' ');
				if (array3.Length == 3)
				{
					xc0d860684e1ba27c.xae20093bed1e48a8(715, xbb857c9fc36f5054.xdea5d4100fe5f461(array3[0]));
					xc0d860684e1ba27c.xae20093bed1e48a8(716, xbb857c9fc36f5054.xdea5d4100fe5f461(array3[1]));
					xc0d860684e1ba27c.xae20093bed1e48a8(717, xbb857c9fc36f5054.xdea5d4100fe5f461(array3[2]));
				}
				break;
			}
			case "extrusion-first-light-level":
				xc0d860684e1ba27c.xae20093bed1e48a8(726, xbb857c9fc36f5054.x0de3a17de401c0aa(xca994afbcb9073a.xd2f68ee6f47e9dfb));
				break;
			case "extrusion-second-light-level":
				xc0d860684e1ba27c.xae20093bed1e48a8(730, xbb857c9fc36f5054.x0de3a17de401c0aa(xca994afbcb9073a.xd2f68ee6f47e9dfb));
				break;
			case "extrusion-first-light-harsh":
				if (xca994afbcb9073a.xd2f68ee6f47e9dfb == "false")
				{
					xc0d860684e1ba27c.xae20093bed1e48a8(766, false);
				}
				break;
			case "extrusion-second-light-harsh":
				if (xca994afbcb9073a.xd2f68ee6f47e9dfb == "true")
				{
					xc0d860684e1ba27c.xae20093bed1e48a8(767, true);
				}
				break;
			case "extrusion-light-face":
				if (xca994afbcb9073a.xd2f68ee6f47e9dfb == "false")
				{
					xc0d860684e1ba27c.xae20093bed1e48a8(703, false);
				}
				break;
			case "glue-point-type":
				xc0d860684e1ba27c.xae20093bed1e48a8(344, x0eb9a864413f34de.x4692ce795d87911d(xca994afbcb9073a.xd2f68ee6f47e9dfb));
				break;
			case "glue-points":
				x9a3bd875129a2a07 = xca994afbcb9073a.xd2f68ee6f47e9dfb.Trim().Split(' ');
				break;
			case "glue-point-leaving-directions":
			{
				string[] array = xca994afbcb9073a.xd2f68ee6f47e9dfb.Split(',');
				int[] array2 = new int[array.Length];
				for (int i = 0; i < array.Length; i++)
				{
					array2[i] = xbb857c9fc36f5054.xba31f88211ebd926(array[i].Trim(' '));
				}
				xc0d860684e1ba27c.xae20093bed1e48a8(338, array2);
				break;
			}
			}
		}
		xf871da68decec406.x08b1f2bf85ce1fc8(xe134235b3526fa75, xbcea506a33cf, xbee336e5a17b0d, x74a48429afea3d, xc0d860684e1ba27c);
		x1db486128dc3182b();
		xc0d860684e1ba27c.xae20093bed1e48a8(4096, flipOrientation);
	}

	private static void x99e0c26fca42fca3(xf7125312c7ee115c xa5e8b8b5991a4e1d, int x2cc925e15cf72003, int x6d1ec028e21aa7a3, int xc9812c800b9950a3, string xbcea506a33cf9111)
	{
		string[] array = xbcea506a33cf9111.Replace("(", "").Replace(")", "").Split(' ');
		if (x2cc925e15cf72003 != -1)
		{
			x3be8a6ec859e8c7d(xa5e8b8b5991a4e1d, x2cc925e15cf72003, array[0]);
		}
		if (array.Length > 1 && x6d1ec028e21aa7a3 != -1)
		{
			x3be8a6ec859e8c7d(xa5e8b8b5991a4e1d, x6d1ec028e21aa7a3, array[1]);
		}
		if (array.Length > 2 && xc9812c800b9950a3 != -1)
		{
			x3be8a6ec859e8c7d(xa5e8b8b5991a4e1d, xc9812c800b9950a3, array[2]);
		}
	}

	private static void x3be8a6ec859e8c7d(xf7125312c7ee115c xa5e8b8b5991a4e1d, int x01dfff6a67355342, string xbcea506a33cf9111)
	{
		if (x0d299f323d241756.x5959bccb67bbf051(xbcea506a33cf9111))
		{
			xa5e8b8b5991a4e1d.xae20093bed1e48a8(x01dfff6a67355342, xbb857c9fc36f5054.x0de3a17de401c0aa(xbcea506a33cf9111));
		}
	}

	private x06e4f09a90ca939a x9bb2d5049420cb08(string xcf77fbef31c2d07b, bool x792e5fa15c19db66, bool x361c1895f4aacdca)
	{
		if (xcf77fbef31c2d07b.StartsWith("$"))
		{
			int num = xca004f56614e2431.x912616ee70b2d94d(xcf77fbef31c2d07b.Substring(1));
			if (num >= 0 && num < 10)
			{
				object obj = xc0d860684e1ba27c.xf7866f89640a29a3(327 + num);
				if (obj != null)
				{
					return new x06e4f09a90ca939a((int)obj, isFormula: true);
				}
			}
		}
		else
		{
			if (xcf77fbef31c2d07b.StartsWith("?"))
			{
				return new x06e4f09a90ca939a(xd5da6750e1df738b(xcf77fbef31c2d07b.Substring(1)), isFormula: false);
			}
			int num2 = xca004f56614e2431.x912616ee70b2d94d(xcf77fbef31c2d07b);
			if (xf871da68decec406.x09fe644179189b22 && x361c1895f4aacdca && num2 == xf871da68decec406.xe7aec7217cdc7f54)
			{
				num2 = (int)((double)num2 * xf871da68decec406.x257838bcbdeec4e9);
			}
			if (xf871da68decec406.xfe7eb210c7e884c4 && !x361c1895f4aacdca && num2 == xf871da68decec406.xa1067e457bc8d35e)
			{
				num2 = (int)((double)num2 / xf871da68decec406.x257838bcbdeec4e9);
			}
			if (num2 != int.MinValue)
			{
				return new x06e4f09a90ca939a(x792e5fa15c19db66 ? num2 : xbb857c9fc36f5054.x01c5989f49b62737(num2));
			}
		}
		return new x06e4f09a90ca939a();
	}

	private void x1db486128dc3182b()
	{
		object obj = xc0d860684e1ba27c.xf7866f89640a29a3(4125);
		object obj2 = xc0d860684e1ba27c.xf7866f89640a29a3(4126);
		object obj3 = xc0d860684e1ba27c.xf7866f89640a29a3(4127);
		object obj4 = xc0d860684e1ba27c.xf7866f89640a29a3(4128);
		if (obj != null)
		{
			xb14027057a3627a1 = (int)obj;
		}
		if (obj2 != null)
		{
			x9f9b2b1a8c54f9e4 = (int)obj2;
		}
		if (obj3 != null)
		{
			x9aa0a23ec879885f = (int)obj3;
		}
		if (obj4 != null)
		{
			xee7c34639947c937 = (int)obj4;
		}
	}

	private void x50be341bb458b0c6(string xbcea506a33cf9111)
	{
		x990d4aed39647c0e = xbcea506a33cf9111.Trim().Split(' ');
		for (int i = 0; i < x990d4aed39647c0e.Length && i < 8; i++)
		{
			double num = xca004f56614e2431.xf5ece46c5d72e3b9(x990d4aed39647c0e[i]);
			if (!double.IsNaN(num))
			{
				xc0d860684e1ba27c.xae20093bed1e48a8(327 + i, xbb857c9fc36f5054.x01c5989f49b62737(x15e971129fd80714.x43fcc3f62534530b(num)));
			}
		}
	}

	private void xa445729974c4e73a(string xe125219852864557)
	{
		foreach (char c in xe125219852864557)
		{
			x4dd8a59ec8974a5f x4dd8a59ec8974a5f = x0eb9a864413f34de.x2bd866c4b07a7144(c);
			if (x4dd8a59ec8974a5f != x4dd8a59ec8974a5f.xf6c17f648b65c793)
			{
				x96f40c97d4eb5d47();
				x89e0b4ecdad90a5c.Add(c);
			}
			else if (c == '$' || c == '?')
			{
				x96f40c97d4eb5d47();
				x800085dd555f7711.Append(c);
			}
			else if (char.IsDigit(c) || c == '-' || char.IsLetter(c))
			{
				x800085dd555f7711.Append(c);
			}
			else
			{
				x96f40c97d4eb5d47();
			}
		}
		x96f40c97d4eb5d47();
	}

	private void x96f40c97d4eb5d47()
	{
		string text = x800085dd555f7711.ToString();
		if (text.Length > 0)
		{
			x89e0b4ecdad90a5c.Add(x800085dd555f7711.ToString());
		}
		x800085dd555f7711.Length = 0;
	}

	private void x84dcc9c11f258c54()
	{
		if (x7e3dfe13e514097a != null && x7e3dfe13e514097a.Length >= 4)
		{
			xbc9979937c838d75[] array = new xbc9979937c838d75[x7e3dfe13e514097a.Length / 4];
			for (int i = 0; i < x7e3dfe13e514097a.Length; i += 4)
			{
				xbc9979937c838d75 xbc9979937c838d = new xbc9979937c838d75();
				xbc9979937c838d.x72d92bd1aff02e37 = x9bb2d5049420cb08(x7e3dfe13e514097a[i], x792e5fa15c19db66: false, x361c1895f4aacdca: true);
				xbc9979937c838d.xe360b1885d8d4a41 = x9bb2d5049420cb08(x7e3dfe13e514097a[i + 1], x792e5fa15c19db66: false, x361c1895f4aacdca: false);
				xbc9979937c838d.x419ba17a5322627b = x9bb2d5049420cb08(x7e3dfe13e514097a[i + 2], x792e5fa15c19db66: false, x361c1895f4aacdca: true);
				xbc9979937c838d.x9bcb07e204e30218 = x9bb2d5049420cb08(x7e3dfe13e514097a[i + 3], x792e5fa15c19db66: false, x361c1895f4aacdca: false);
				array[i / 4] = xbc9979937c838d;
			}
			xc0d860684e1ba27c.xae20093bed1e48a8(343, array);
		}
	}

	private void x6488998a0e729547()
	{
		if (x9a3bd875129a2a07 != null)
		{
			x08d932077485c285[] array = new x08d932077485c285[x9a3bd875129a2a07.Length / 2];
			for (int i = 0; i < array.Length; i++)
			{
				x06e4f09a90ca939a x = x9bb2d5049420cb08(x9a3bd875129a2a07[i * 2], x792e5fa15c19db66: false, x361c1895f4aacdca: true);
				x06e4f09a90ca939a y = x9bb2d5049420cb08(x9a3bd875129a2a07[i * 2 + 1], x792e5fa15c19db66: false, x361c1895f4aacdca: false);
				array[i] = new x08d932077485c285(x, y);
			}
			xc0d860684e1ba27c.xae20093bed1e48a8(337, array);
		}
	}

	private void x9f5c33e0f81d3687()
	{
		ArrayList arrayList = new ArrayList();
		ArrayList arrayList2 = new ArrayList();
		x4dd8a59ec8974a5f x4dd8a59ec8974a5f = x4dd8a59ec8974a5f.xf6c17f648b65c793;
		x4dd8a59ec8974a5f x4dd8a59ec8974a5f2 = x4dd8a59ec8974a5f.xf6c17f648b65c793;
		int num = 0;
		x44f2b8bf33b16275 x44f2b8bf33b = new x44f2b8bf33b16275();
		bool flag = true;
		while (num < x89e0b4ecdad90a5c.Count)
		{
			if (x7d3a2e07a7ec7fce(x89e0b4ecdad90a5c[num]))
			{
				flag = true;
				char x3c4da2980d043c = (char)x89e0b4ecdad90a5c[num];
				x4dd8a59ec8974a5f = x0eb9a864413f34de.x2bd866c4b07a7144(x3c4da2980d043c);
				if ((x4dd8a59ec8974a5f == x4dd8a59ec8974a5f.xb9fb25f53beaeb97 || x4dd8a59ec8974a5f == x4dd8a59ec8974a5f.xbfb6f7deb7122782) && x4dd8a59ec8974a5f == x4dd8a59ec8974a5f2)
				{
					x4dd8a59ec8974a5f = ((x4dd8a59ec8974a5f == x4dd8a59ec8974a5f.xb9fb25f53beaeb97) ? x4dd8a59ec8974a5f.xbfb6f7deb7122782 : x4dd8a59ec8974a5f.xb9fb25f53beaeb97);
				}
				int segmentCount = 1;
				if (x4dd8a59ec8974a5f == x4dd8a59ec8974a5f.x8ffe90e7fbccfccd || x4dd8a59ec8974a5f == x4dd8a59ec8974a5f.x9fd888e65466818c || x4dd8a59ec8974a5f == x4dd8a59ec8974a5f.x01b2723108ff3dfe)
				{
					segmentCount = 0;
				}
				if (x4dd8a59ec8974a5f == x4dd8a59ec8974a5f.x27166c2759dd15ed || x4dd8a59ec8974a5f == x4dd8a59ec8974a5f.x5fd023604497c8ef || x4dd8a59ec8974a5f == x4dd8a59ec8974a5f.x26a9b6a08a70bcb9)
				{
					segmentCount = 4;
				}
				if (x4dd8a59ec8974a5f == x4dd8a59ec8974a5f.x8dc4eedb9f218057 || x4dd8a59ec8974a5f == x4dd8a59ec8974a5f.x350c7c4c4aeebe37)
				{
					segmentCount = 3;
				}
				x44f2b8bf33b = new x44f2b8bf33b16275(x4dd8a59ec8974a5f, segmentCount);
				if (x44f2b8bf33b.x9b6c7f268832a67f() == 0)
				{
					arrayList2.Add(x44f2b8bf33b);
				}
				num++;
			}
			else
			{
				if (x4dd8a59ec8974a5f != x4dd8a59ec8974a5f.xf6c17f648b65c793)
				{
					if (!flag && (x4dd8a59ec8974a5f == x4dd8a59ec8974a5f.xb9fb25f53beaeb97 || x4dd8a59ec8974a5f == x4dd8a59ec8974a5f.xbfb6f7deb7122782) && x4dd8a59ec8974a5f == x4dd8a59ec8974a5f2)
					{
						x4dd8a59ec8974a5f = ((x4dd8a59ec8974a5f == x4dd8a59ec8974a5f.xb9fb25f53beaeb97) ? x4dd8a59ec8974a5f.xbfb6f7deb7122782 : x4dd8a59ec8974a5f.xb9fb25f53beaeb97);
						x44f2b8bf33b = new x44f2b8bf33b16275(x4dd8a59ec8974a5f, x44f2b8bf33b.x7bc0a12a325563e9);
					}
					arrayList2.Add(x44f2b8bf33b);
					for (int i = 0; i < x44f2b8bf33b.x9b6c7f268832a67f(); i++)
					{
						bool flag2 = (x44f2b8bf33b.x4dd8a59ec8974a5f == x4dd8a59ec8974a5f.x8dc4eedb9f218057 || x44f2b8bf33b.x4dd8a59ec8974a5f == x4dd8a59ec8974a5f.x350c7c4c4aeebe37) && i == 2;
						x06e4f09a90ca939a x06e4f09a90ca939a = x9bb2d5049420cb08((string)x89e0b4ecdad90a5c[num++], flag2, x361c1895f4aacdca: true);
						x06e4f09a90ca939a x06e4f09a90ca939a2 = x9bb2d5049420cb08((string)x89e0b4ecdad90a5c[num++], flag2, x361c1895f4aacdca: false);
						if (flag2)
						{
							x06e4f09a90ca939a = new x06e4f09a90ca939a(x06e4f09a90ca939a.xd2f68ee6f47e9dfb * 65536);
							x06e4f09a90ca939a2 = new x06e4f09a90ca939a(x06e4f09a90ca939a2.xd2f68ee6f47e9dfb * 65536);
						}
						x08d932077485c285 value = new x08d932077485c285(x06e4f09a90ca939a, x06e4f09a90ca939a2);
						arrayList.Add(value);
					}
				}
				flag = false;
			}
			x4dd8a59ec8974a5f2 = x4dd8a59ec8974a5f;
		}
		x08d932077485c285[] array = new x08d932077485c285[arrayList.Count];
		for (int j = 0; j < arrayList.Count; j++)
		{
			array[j] = (x08d932077485c285)arrayList[j];
		}
		x44f2b8bf33b16275[] array2 = new x44f2b8bf33b16275[arrayList2.Count];
		for (int k = 0; k < arrayList2.Count; k++)
		{
			array2[k] = (x44f2b8bf33b16275)arrayList2[k];
		}
		xc0d860684e1ba27c.xae20093bed1e48a8(325, array);
		xc0d860684e1ba27c.xae20093bed1e48a8(326, array2);
	}

	private int xd5da6750e1df738b(string xc15bd84e01929885)
	{
		foreach (xa2313d37664d395d item in x7c7d5705ddbe0a35)
		{
			if (item.x759aa16c2016a289 == xc15bd84e01929885)
			{
				double num = xca004f56614e2431.xf5ece46c5d72e3b9(item.x6f4c0401bc1b60f7);
				if (!double.IsNaN(num))
				{
					return xbb857c9fc36f5054.x01c5989f49b62737((int)num);
				}
			}
		}
		return 0;
	}

	private static string[] x92c030a1f016d8da(string x5518c79299afe5d9)
	{
		StringBuilder stringBuilder = new StringBuilder();
		bool flag = true;
		foreach (char c in x5518c79299afe5d9)
		{
			if ((c == '+' || c == '-') && flag)
			{
				stringBuilder.Append($"[{c}] ");
				flag = false;
			}
			else
			{
				stringBuilder.Append(c);
			}
			flag = c == '(' || xa3ec13fa5b9aace5(c) || (c == ' ' && flag);
		}
		x5518c79299afe5d9 = stringBuilder.ToString();
		Stack stack = new Stack();
		StringBuilder stringBuilder2 = new StringBuilder();
		bool flag2 = false;
		bool flag3 = false;
		bool flag4 = true;
		int num = 0;
		while (num < x5518c79299afe5d9.Length)
		{
			char c2 = x5518c79299afe5d9[num];
			int num2 = x7c0050fce818bd8b(x5518c79299afe5d9.Substring(num));
			int num3 = x0ac5e1e896725f87(x5518c79299afe5d9.Substring(num));
			if (c2 == ' ' || c2 == '?' || c2 == ',' || c2 == ')' || char.IsLetter(c2) || xa3ec13fa5b9aace5(c2))
			{
				if (stack.Count > 0 && stack.Peek() is string && (string)stack.Peek() == "[-]" && flag3)
				{
					stringBuilder2.AppendFormat(" {0}", stack.Pop());
				}
				flag3 = false;
			}
			if (((char.IsDigit(c2) || c2 == '.') && !flag2) || (char.IsLetterOrDigit(c2) && flag2))
			{
				stringBuilder2.Append(c2);
				flag3 = true;
			}
			if (!flag2)
			{
				if (num3 != 0)
				{
					stringBuilder2.Append(x5518c79299afe5d9.Substring(num, num3));
				}
				if (num2 != 0)
				{
					string obj = x5518c79299afe5d9.Substring(num, num2);
					stack.Push(obj);
					num += num2 - 1;
				}
			}
			if (c2 == ' ')
			{
				flag2 = false;
			}
			switch (c2)
			{
			case '(':
				stack.Push(c2);
				break;
			case ')':
			case ',':
				x1a5493d88445e424(stack, stringBuilder2, c2 == ',');
				if (c2 == ')' && stack.Count > 0 && x7c0050fce818bd8b(stack.Peek().ToString()) > 0)
				{
					stringBuilder2.AppendFormat(" {0}", stack.Pop());
				}
				flag2 = false;
				break;
			case '$':
				stringBuilder2.Append(c2);
				flag2 = false;
				break;
			case '?':
				stringBuilder2.Append(c2);
				flag2 = true;
				break;
			default:
				if (xa3ec13fa5b9aace5(c2))
				{
					xcdf2e4ae2bc6b1f8(c2, stringBuilder2, stack, num == 0, flag4);
					flag2 = false;
				}
				break;
			}
			num++;
			flag4 = c2 == '(' || xa3ec13fa5b9aace5(c2) || num2 != 0 || (c2 == ' ' && flag4);
		}
		x54eba5a66be0c9c5(stringBuilder2, stack);
		return stringBuilder2.ToString().Split(' ');
	}

	private static void xcdf2e4ae2bc6b1f8(char x3c4da2980d043c95, StringBuilder xfef0c89324a5fd31, Stack xa0d7ca4995faa759, bool x4273ee7850673e88, bool x76d8bd26f227df9b)
	{
		if ((x3c4da2980d043c95 == '+' || x3c4da2980d043c95 == '-') && (x4273ee7850673e88 || x76d8bd26f227df9b))
		{
			xfef0c89324a5fd31.Append("0");
		}
		xfef0c89324a5fd31.Append(' ');
		while (xa0d7ca4995faa759.Count != 0 && xa0d7ca4995faa759.Peek() is char)
		{
			char x3c4da2980d043c96 = (char)xa0d7ca4995faa759.Peek();
			if (!xa3ec13fa5b9aace5(x3c4da2980d043c96) || xc6f44b0fac42607a(x3c4da2980d043c95) > xc6f44b0fac42607a(x3c4da2980d043c96))
			{
				break;
			}
			xfef0c89324a5fd31.AppendFormat("{0} ", xa0d7ca4995faa759.Pop());
		}
		xa0d7ca4995faa759.Push(x3c4da2980d043c95);
	}

	private static void x54eba5a66be0c9c5(StringBuilder xfef0c89324a5fd31, Stack xa0d7ca4995faa759)
	{
		while (xa0d7ca4995faa759.Count != 0)
		{
			if (!xa3ec13fa5b9aace5(xa0d7ca4995faa759.Peek()))
			{
				StringBuilder stringBuilder = new StringBuilder();
				while (xa0d7ca4995faa759.Count != 0 && !xa3ec13fa5b9aace5(xa0d7ca4995faa759.Peek()))
				{
					if (xa0d7ca4995faa759.Peek() is string && x7c0050fce818bd8b(xa0d7ca4995faa759.Peek() as string) != 0)
					{
						stringBuilder.Append(xa0d7ca4995faa759.Pop());
					}
					else
					{
						xa0d7ca4995faa759.Pop();
					}
				}
				if (x7c0050fce818bd8b(stringBuilder.ToString()) == 0)
				{
					throw new InvalidOperationException("ODT formula is wrong");
				}
				xfef0c89324a5fd31.AppendFormat(" {0}", stringBuilder);
			}
			else
			{
				xfef0c89324a5fd31.AppendFormat(" {0}", xa0d7ca4995faa759.Pop());
			}
		}
	}

	private static bool x6d4a6ad83d672440(string xc1b7b25fd94e58e5)
	{
		if (x7c0050fce818bd8b(xc1b7b25fd94e58e5) == 0)
		{
			return !xa3ec13fa5b9aace5(xc1b7b25fd94e58e5);
		}
		return false;
	}

	private static bool xa3ec13fa5b9aace5(char x3c4da2980d043c95)
	{
		if (x3c4da2980d043c95 != '+' && x3c4da2980d043c95 != '-' && x3c4da2980d043c95 != '*')
		{
			return x3c4da2980d043c95 == '/';
		}
		return true;
	}

	private static bool xa3ec13fa5b9aace5(string xe4115acdf4fbfccc)
	{
		if (xe4115acdf4fbfccc.Length == 1)
		{
			return xa3ec13fa5b9aace5(xe4115acdf4fbfccc[0]);
		}
		return false;
	}

	private static bool xa3ec13fa5b9aace5(object xa59bff7708de3a18)
	{
		if (xa59bff7708de3a18 is char x3c4da2980d043c)
		{
			return xa3ec13fa5b9aace5(x3c4da2980d043c);
		}
		if (xa59bff7708de3a18 is string)
		{
			string xe4115acdf4fbfccc = (string)xa59bff7708de3a18;
			return xa3ec13fa5b9aace5(xe4115acdf4fbfccc);
		}
		return false;
	}

	private static void x1a5493d88445e424(Stack xa0d7ca4995faa759, StringBuilder xfef0c89324a5fd31, bool x2e3856dd81c33646)
	{
		if (!(xa0d7ca4995faa759.Peek() is char))
		{
			return;
		}
		for (char c = (char)(x2e3856dd81c33646 ? xa0d7ca4995faa759.Peek() : xa0d7ca4995faa759.Pop()); c != '('; c = (char)(x2e3856dd81c33646 ? xa0d7ca4995faa759.Peek() : xa0d7ca4995faa759.Pop()))
		{
			if (x2e3856dd81c33646)
			{
				xa0d7ca4995faa759.Pop();
			}
			xfef0c89324a5fd31.AppendFormat(" {0}", c);
			if (xa0d7ca4995faa759.Count == 0)
			{
				throw new InvalidOperationException("ODT formula is wrong");
			}
		}
		if (x2e3856dd81c33646)
		{
			xfef0c89324a5fd31.Append(' ');
		}
	}

	private static int xc6f44b0fac42607a(char x3c4da2980d043c95)
	{
		switch (x3c4da2980d043c95)
		{
		case '+':
		case '-':
			return 1;
		case '*':
		case '/':
			return 2;
		default:
			return 0;
		}
	}

	private static int x0ac5e1e896725f87(string xbcea506a33cf9111)
	{
		if (xbcea506a33cf9111.ToLower().StartsWith("pi"))
		{
			return 2;
		}
		if (xbcea506a33cf9111.ToLower().StartsWith("top"))
		{
			return 3;
		}
		if (xbcea506a33cf9111.StartsWith("left"))
		{
			return 4;
		}
		if (xbcea506a33cf9111.StartsWith("right") || xbcea506a33cf9111.StartsWith("width"))
		{
			return 5;
		}
		if (xbcea506a33cf9111.StartsWith("bottom") || xbcea506a33cf9111.StartsWith("height"))
		{
			return 6;
		}
		if (xbcea506a33cf9111.StartsWith("hasfill"))
		{
			return 7;
		}
		if (xbcea506a33cf9111.StartsWith("xstretch") || xbcea506a33cf9111.StartsWith("ystretch") || xbcea506a33cf9111.StartsWith("logwidth"))
		{
			return 8;
		}
		if (xbcea506a33cf9111.StartsWith("hasstroke") || xbcea506a33cf9111.StartsWith("logheight"))
		{
			return 9;
		}
		return 0;
	}

	private static int x7c0050fce818bd8b(string xbcea506a33cf9111)
	{
		if (xbcea506a33cf9111.ToLower().StartsWith("[-]"))
		{
			return 3;
		}
		if (xbcea506a33cf9111.ToLower().StartsWith("[+]"))
		{
			return 3;
		}
		if (xbcea506a33cf9111.ToLower().StartsWith("if"))
		{
			return 2;
		}
		if (xbcea506a33cf9111.StartsWith("abs") || xbcea506a33cf9111.StartsWith("sin") || xbcea506a33cf9111.StartsWith("cos") || xbcea506a33cf9111.StartsWith("tan") || xbcea506a33cf9111.StartsWith("min") || xbcea506a33cf9111.StartsWith("max"))
		{
			return 3;
		}
		if (xbcea506a33cf9111.StartsWith("atan2"))
		{
			return 5;
		}
		if (xbcea506a33cf9111.StartsWith("sqrt") || xbcea506a33cf9111.StartsWith("atan"))
		{
			return 4;
		}
		return 0;
	}

	private static bool x7d3a2e07a7ec7fce(object xcb61482d958392ca)
	{
		if (xcb61482d958392ca is char)
		{
			return "ABCFLMNQSTUVWXYZ".IndexOf((char)xcb61482d958392ca) != -1;
		}
		return false;
	}
}
