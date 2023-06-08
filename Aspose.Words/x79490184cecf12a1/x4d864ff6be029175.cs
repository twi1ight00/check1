using System;
using Aspose.Words;
using Aspose.Words.BuildingBlocks;
using x7c7a1dceb600404e;
using x909757d9fd2dd6ae;
using xfc5388ad7dff404f;

namespace x79490184cecf12a1;

internal class x4d864ff6be029175 : x11e1346c12ead315
{
	private readonly GlossaryDocument x5661b41a0e3807e1;

	private BuildingBlock x3cfe6e8c56be3954;

	internal x4d864ff6be029175(xada461b17cdccac0 package, xa2f1c3dcbd86f20a documentPart, GlossaryDocument doc, LoadOptions loadOptions)
		: base(package, documentPart, doc, loadOptions)
	{
		x5661b41a0e3807e1 = doc;
	}

	protected override void DoRead()
	{
		while (x3bcd232d01c14846.x152cbadbfa8061b1("glossaryDocument"))
		{
			switch (x3bcd232d01c14846.xa66385d80d4d296f)
			{
			case "background":
				xcb00358ab5144003.x466976bbae34cc54(this);
				break;
			case "docParts":
				x4d8d1884db1dcb52();
				break;
			default:
				x3bcd232d01c14846.IgnoreElement();
				break;
			}
		}
	}

	private void x4d8d1884db1dcb52()
	{
		while (x3bcd232d01c14846.x152cbadbfa8061b1("docParts"))
		{
			string xa66385d80d4d296f;
			if ((xa66385d80d4d296f = x3bcd232d01c14846.xa66385d80d4d296f) != null && xa66385d80d4d296f == "docPart")
			{
				xe34229f607bb01a0();
			}
			else
			{
				x3bcd232d01c14846.IgnoreElement();
			}
		}
	}

	private void xe34229f607bb01a0()
	{
		x3cfe6e8c56be3954 = new BuildingBlock(x5661b41a0e3807e1);
		x490834a62c46f14d(x3cfe6e8c56be3954);
		while (x3bcd232d01c14846.x152cbadbfa8061b1("docPart"))
		{
			switch (x3bcd232d01c14846.xa66385d80d4d296f)
			{
			case "docPartPr":
				x37a244bc3007f828();
				break;
			case "docPartBody":
				x2dc551ee28d58aab(x5661b41a0e3807e1);
				x7c1337cdc8ca636c();
				break;
			default:
				x3bcd232d01c14846.IgnoreElement();
				break;
			}
		}
		xf5b0b9b6ff7ac462(NodeType.BuildingBlock);
	}

	private void x37a244bc3007f828()
	{
		while (x3bcd232d01c14846.x152cbadbfa8061b1("docPartPr"))
		{
			switch (x3bcd232d01c14846.xa66385d80d4d296f)
			{
			case "behaviors":
				x6f1c66b720d6830a();
				break;
			case "category":
				xbbea30e7c9441fe2();
				break;
			case "description":
				x3cfe6e8c56be3954.Description = x3bcd232d01c14846.xbbfc54380705e01e();
				break;
			case "guid":
				x3cfe6e8c56be3954.Guid = new Guid(x3bcd232d01c14846.xbbfc54380705e01e());
				break;
			case "name":
				xea0a315a3696158b();
				break;
			case "style":
				x3cfe6e8c56be3954.xfe2178c1f916f36c = x3bcd232d01c14846.xbbfc54380705e01e();
				break;
			case "types":
				x8caf8cec7d609723();
				break;
			default:
				x3bcd232d01c14846.IgnoreElement();
				break;
			}
		}
	}

	private void x6f1c66b720d6830a()
	{
		while (x3bcd232d01c14846.x152cbadbfa8061b1("behaviors"))
		{
			string xa66385d80d4d296f;
			if ((xa66385d80d4d296f = x3bcd232d01c14846.xa66385d80d4d296f) != null && xa66385d80d4d296f == "behavior")
			{
				x3cfe6e8c56be3954.Behavior = xc62574be95c1c918.x08d936e1b1347121(x3bcd232d01c14846.xbbfc54380705e01e());
			}
			else
			{
				x3bcd232d01c14846.IgnoreElement();
			}
		}
	}

	private void xbbea30e7c9441fe2()
	{
		while (x3bcd232d01c14846.x152cbadbfa8061b1("category"))
		{
			switch (x3bcd232d01c14846.xa66385d80d4d296f)
			{
			case "gallery":
				x3cfe6e8c56be3954.Gallery = xc62574be95c1c918.x30fcb59e0254e3ff(x3bcd232d01c14846.xbbfc54380705e01e());
				break;
			case "name":
				x3cfe6e8c56be3954.x40796a31263666b8(x3bcd232d01c14846.xbbfc54380705e01e());
				break;
			default:
				x3bcd232d01c14846.IgnoreElement();
				break;
			}
		}
	}

	private void xea0a315a3696158b()
	{
		while (x3bcd232d01c14846.x1ac1960adc8c4c39())
		{
			switch (x3bcd232d01c14846.xa66385d80d4d296f)
			{
			case "decorated":
				x3cfe6e8c56be3954.xd448af18fed11a9d = x3bcd232d01c14846.xc3be6b142c6aca84;
				break;
			case "val":
				x3cfe6e8c56be3954.x4c5dd7b882032b8b(x3bcd232d01c14846.xd2f68ee6f47e9dfb);
				break;
			}
		}
	}

	private void x8caf8cec7d609723()
	{
		bool flag = false;
		while (x3bcd232d01c14846.x1ac1960adc8c4c39())
		{
			string xa66385d80d4d296f;
			if ((xa66385d80d4d296f = x3bcd232d01c14846.xa66385d80d4d296f) != null && xa66385d80d4d296f == "all")
			{
				flag = x3bcd232d01c14846.xc3be6b142c6aca84;
			}
		}
		while (x3bcd232d01c14846.x152cbadbfa8061b1("types"))
		{
			string xa66385d80d4d296f2;
			if ((xa66385d80d4d296f2 = x3bcd232d01c14846.xa66385d80d4d296f) != null && xa66385d80d4d296f2 == "type")
			{
				x3cfe6e8c56be3954.Type = xc62574be95c1c918.xb9a5defd5903fcdd(x3bcd232d01c14846.xbbfc54380705e01e());
			}
			else
			{
				x3bcd232d01c14846.IgnoreElement();
			}
		}
		if (flag)
		{
			x3cfe6e8c56be3954.Type = BuildingBlockType.All;
		}
	}
}
