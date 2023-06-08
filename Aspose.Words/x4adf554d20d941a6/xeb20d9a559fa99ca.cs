using System;
using Aspose;
using Aspose.Words.Fields;
using x13f1efc79617a47b;
using x28925c9b27b37a46;
using x59d6a4fc5007b7a4;
using x6c95d9cf46ff5f25;

namespace x4adf554d20d941a6;

internal class xeb20d9a559fa99ca : x61ebdec02c254c25
{
	private readonly FormField x9381f7e29fdeeccf;

	private string xed4a7b1500064e12 = "";

	private x4a1a6d8b0aafa0fe x946dfed0f9c4a02e;

	internal override bool x1b4884baf08c8d62 => !x0d299f323d241756.x5959bccb67bbf051(xed4a7b1500064e12);

	internal override int x5566e2d2acbd1fbe
	{
		get
		{
			if (!x0d299f323d241756.x5959bccb67bbf051(xed4a7b1500064e12))
			{
				return 0;
			}
			return 9217;
		}
	}

	internal override x6e414db5d060a816 x6e414db5d060a816 => x6e414db5d060a816.x865739e9b580d3cf;

	internal override int x1be93eed8950d961 => 1;

	internal override xfc6971c7d8314663 xfc6971c7d8314663
	{
		get
		{
			if (!(xed4a7b1500064e12 == ""))
			{
				return xfc6971c7d8314663.xf9ad6fb78355fe13;
			}
			return xfc6971c7d8314663.x4d0b9d4447ba7566;
		}
	}

	internal override string xf9ad6fb78355fe13 => xed4a7b1500064e12;

	internal FormField xd438a3a8968e57e1 => x9381f7e29fdeeccf;

	[JavaThrows(false)]
	internal override x4a1a6d8b0aafa0fe x4a1a6d8b0aafa0fe
	{
		get
		{
			if (x946dfed0f9c4a02e == x4a1a6d8b0aafa0fe.x4d0b9d4447ba7566 && x0d299f323d241756.x5959bccb67bbf051(xf9ad6fb78355fe13))
			{
				x946dfed0f9c4a02e = x34a37b5a89c466fd.x517e646bc90695b3(xf9ad6fb78355fe13[0]);
			}
			return x946dfed0f9c4a02e;
		}
	}

	internal xeb20d9a559fa99ca(FormField formField)
		: base(0)
	{
		x9381f7e29fdeeccf = formField;
	}

	internal override void x3e04636bf524a4cf(xb9e48f11d7f06ec9 x27f5ecb735ac9676)
	{
		if (x27f5ecb735ac9676 == xb9e48f11d7f06ec9.x56410a8dd70087c5)
		{
			FormField formField = x9381f7e29fdeeccf;
			switch (formField.Type)
			{
			case FieldType.FieldFormCheckBox:
			{
				xed4a7b1500064e12 = (formField.Checked ? "\uf054" : "\uf0a3");
				x396b77a306f83da6 x396b77a306f83da7 = x396b77a306f83da6.xdb83cd4968ca9d31(base.x705ed5f9769744e5);
				x396b77a306f83da7.x759aa16c2016a289 = "Wingdings 2";
				x396b77a306f83da7.x437e3b626c0fdd43 = (formField.IsCheckBoxExactSize ? x4574ea26106f0edb.x8d50b8a62ba1cd84(formField.CheckBoxSize * 1.1) : x4574ea26106f0edb.x9e20b93bb584bff2(x684b09378db148f4.x856218fd0771d379(formField, xecac24b19ed3a2b7.xb7ae55095fddecd9).x437e3b626c0fdd43));
				base.x705ed5f9769744e5 = x396b77a306f83da6.x38758cbbee49e4cb(x396b77a306f83da7);
				break;
			}
			case FieldType.FieldFormDropDown:
				xed4a7b1500064e12 = (x0d299f323d241756.x5959bccb67bbf051(formField.Result) ? formField.Result : "");
				break;
			}
		}
	}

	internal override x56410a8dd70087c5 xa9d7e8f6fbdcbcfc(x56410a8dd70087c5 x7d95d971d8923f4c)
	{
		if (x7d95d971d8923f4c == null)
		{
			x7d95d971d8923f4c = new xeb20d9a559fa99ca(x9381f7e29fdeeccf);
		}
		return base.xa9d7e8f6fbdcbcfc(x7d95d971d8923f4c);
	}

	internal override void x7012609bcdb39574(x75b8b2f740aae644 x672ff13faf031f3d)
	{
		base.x7012609bcdb39574(x672ff13faf031f3d);
		x672ff13faf031f3d.xeb3f33fe08e9a2e6(this);
	}

	internal x5c28fdcd27dee7d9 x8ebdfaa20182b73c()
	{
		FieldStart start = xd438a3a8968e57e1.xd1b40af56a8385d4.Start;
		xf3f447691ab38eee xb3a79d506b0e2f7f = x53111d6596d16a99.xb3a79d506b0e2f7f;
		if (!xb3a79d506b0e2f7f.xd8b11076ff837685(this))
		{
			throw new InvalidOperationException(string.Intern(x1110bdd110cdcea4._xaacba899487bce8c("gjihblphllgiilniglejilljbgcklkjkkkalokhlkjolagfm", 1074034771)));
		}
		while (xb3a79d506b0e2f7f.x355eaee82ffc1f46())
		{
			x56410a8dd70087c5 x56410a8dd70087c6 = (x56410a8dd70087c5)xb3a79d506b0e2f7f.x02ebdc12ebf86805;
			if (x56410a8dd70087c6.x6e414db5d060a816 == x6e414db5d060a816.x12cb12b5d2cad53d && x56410a8dd70087c6 is x5c28fdcd27dee7d9 && ((x5c28fdcd27dee7d9)x56410a8dd70087c6).x9a05d8dab0f0619f.xb7c4cf9f30ad5f2a == start)
			{
				return (x5c28fdcd27dee7d9)x56410a8dd70087c6;
			}
		}
		return null;
	}
}
