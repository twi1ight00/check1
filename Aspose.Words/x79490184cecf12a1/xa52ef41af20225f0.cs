using System.ComponentModel;
using Aspose.Words;
using Aspose.Words.BuildingBlocks;
using x7c7a1dceb600404e;
using xfc5388ad7dff404f;

namespace x79490184cecf12a1;

internal class xa52ef41af20225f0 : x11e1346c12ead315
{
	private readonly Document xfc9bc96adff27aa3;

	[EditorBrowsable(EditorBrowsableState.Never)]
	public new Document x2c8c6741422a1298 => xfc9bc96adff27aa3;

	internal xa52ef41af20225f0(xada461b17cdccac0 package, xa2f1c3dcbd86f20a documentPart, Document doc, LoadOptions loadOptions)
		: base(package, documentPart, doc, loadOptions)
	{
		xfc9bc96adff27aa3 = doc;
	}

	protected override void DoRead()
	{
		x980bf27aa9764302.x06b0e25aa6ad68a9(this, base.x1e4394fcb6d34948.WarningCallback);
		x748a2047fcb706ad();
		x45d3b2f1461cff3e();
		xdb0996bb04720691.x06b0e25aa6ad68a9(this);
		x64132e2bf3127c53.x06b0e25aa6ad68a9(this);
		xc37fee571c29ba92 xc37fee571c29ba93 = new xc37fee571c29ba92();
		xc37fee571c29ba93.x06b0e25aa6ad68a9(this);
		x0ca62c89c364e965();
	}

	private void x748a2047fcb706ad()
	{
		base.x936e45dfa3e35eb8 = x3bcd232d01c14846.xd68abcd61e368af9("space", "") == "preserve";
		while (x3bcd232d01c14846.x152cbadbfa8061b1("document"))
		{
			switch (x3bcd232d01c14846.xa66385d80d4d296f)
			{
			case "background":
				xcb00358ab5144003.x466976bbae34cc54(this);
				break;
			case "body":
				x2dc551ee28d58aab(xfc9bc96adff27aa3);
				break;
			default:
				x288e015b818b59c4();
				break;
			}
		}
		x7c1337cdc8ca636c();
	}

	private void x288e015b818b59c4()
	{
		xd50ca1549becd989(xfc9bc96adff27aa3);
		xce4dd62ad1252b05.x152cbadbfa8061b1(this);
	}

	private void x0ca62c89c364e965()
	{
		xa2f1c3dcbd86f20a xa2f1c3dcbd86f20a = x4bfdbcbc6a51d705(base.x2a0bb2f6650f6a43, "http://schemas.openxmlformats.org/officeDocument/2006/relationships/glossaryDocument");
		if (xa2f1c3dcbd86f20a != null)
		{
			xfc9bc96adff27aa3.GlossaryDocument = new GlossaryDocument();
			x4d864ff6be029175 x4d864ff6be29176 = new x4d864ff6be029175(base.x39c7aeeec1af9dd0, xa2f1c3dcbd86f20a, xfc9bc96adff27aa3.GlossaryDocument, base.x1e4394fcb6d34948);
			x4d864ff6be29176.x06b0e25aa6ad68a9();
			x4d864ff6be29176.x45d3b2f1461cff3e();
		}
	}
}
