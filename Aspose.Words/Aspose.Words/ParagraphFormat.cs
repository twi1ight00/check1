using System;
using System.Collections;
using Aspose.Words.Drawing;
using x13f1efc79617a47b;
using x28925c9b27b37a46;
using x6c95d9cf46ff5f25;

namespace Aspose.Words;

public class ParagraphFormat : x0e9935be205598e7, x39462b2e4fc652e7
{
	internal const float xf2379e28cce34205 = 14f;

	private readonly xac4d96a62eaba39e xc454c03c23d4b4d9;

	private readonly StyleCollection x18c770831ef0bf38;

	private BorderCollection xac8df3ffedaa82be;

	public ParagraphAlignment Alignment
	{
		get
		{
			return (ParagraphAlignment)xc454c03c23d4b4d9.xc3cc338a59c5293b(1020);
		}
		set
		{
			xc454c03c23d4b4d9.xb6157b6da9895c0d(1020, value);
		}
	}

	internal bool xf8e09f312a5bdefa
	{
		get
		{
			if (Alignment != ParagraphAlignment.Justify)
			{
				return Alignment == ParagraphAlignment.Distributed;
			}
			return true;
		}
	}

	public bool NoSpaceBetweenParagraphsOfSameStyle
	{
		get
		{
			return (bool)xc454c03c23d4b4d9.xc3cc338a59c5293b(1022);
		}
		set
		{
			xc454c03c23d4b4d9.xb6157b6da9895c0d(1022, value);
		}
	}

	internal bool x9989289b31ff37e5
	{
		get
		{
			return (bool)xc454c03c23d4b4d9.xc3cc338a59c5293b(1030);
		}
		set
		{
			xc454c03c23d4b4d9.xb6157b6da9895c0d(1030, value);
		}
	}

	public bool KeepTogether
	{
		get
		{
			return (bool)xc454c03c23d4b4d9.xc3cc338a59c5293b(1040);
		}
		set
		{
			xc454c03c23d4b4d9.xb6157b6da9895c0d(1040, value);
		}
	}

	public bool KeepWithNext
	{
		get
		{
			return (bool)xc454c03c23d4b4d9.xc3cc338a59c5293b(1050);
		}
		set
		{
			xc454c03c23d4b4d9.xb6157b6da9895c0d(1050, value);
		}
	}

	public bool PageBreakBefore
	{
		get
		{
			return (bool)xc454c03c23d4b4d9.xc3cc338a59c5293b(1060);
		}
		set
		{
			xc454c03c23d4b4d9.xb6157b6da9895c0d(1060, value);
		}
	}

	public bool SuppressLineNumbers
	{
		get
		{
			return (bool)xc454c03c23d4b4d9.xc3cc338a59c5293b(1130);
		}
		set
		{
			xc454c03c23d4b4d9.xb6157b6da9895c0d(1130, value);
		}
	}

	public bool SuppressAutoHyphens
	{
		get
		{
			return (bool)xc454c03c23d4b4d9.xc3cc338a59c5293b(1410);
		}
		set
		{
			xc454c03c23d4b4d9.xb6157b6da9895c0d(1410, value);
		}
	}

	public bool WidowControl
	{
		get
		{
			return (bool)xc454c03c23d4b4d9.xc3cc338a59c5293b(1470);
		}
		set
		{
			xc454c03c23d4b4d9.xb6157b6da9895c0d(1470, value);
		}
	}

	internal bool xdd32fdd03429962e
	{
		get
		{
			return (bool)xc454c03c23d4b4d9.xc3cc338a59c5293b(1070);
		}
		set
		{
			xc454c03c23d4b4d9.xb6157b6da9895c0d(1070, value);
		}
	}

	internal bool x4cd8dfaddfd72f3c
	{
		get
		{
			return (bool)xc454c03c23d4b4d9.xc3cc338a59c5293b(1080);
		}
		set
		{
			xc454c03c23d4b4d9.xb6157b6da9895c0d(1080, value);
		}
	}

	internal bool x3e3ede4be0e2161e
	{
		get
		{
			return (bool)xc454c03c23d4b4d9.xc3cc338a59c5293b(1090);
		}
		set
		{
			xc454c03c23d4b4d9.xb6157b6da9895c0d(1090, value);
		}
	}

	internal bool xb246a54f72766cd6
	{
		get
		{
			return (bool)xc454c03c23d4b4d9.xc3cc338a59c5293b(1100);
		}
		set
		{
			xc454c03c23d4b4d9.xb6157b6da9895c0d(1100, value);
		}
	}

	internal bool xfa3f9506eeba503d
	{
		get
		{
			return (bool)xc454c03c23d4b4d9.xc3cc338a59c5293b(1240);
		}
		set
		{
			xc454c03c23d4b4d9.xb6157b6da9895c0d(1240, value);
		}
	}

	internal bool x4ffde28f0399ee1b
	{
		get
		{
			return (bool)xc454c03c23d4b4d9.xc3cc338a59c5293b(1250);
		}
		set
		{
			xc454c03c23d4b4d9.xb6157b6da9895c0d(1250, value);
		}
	}

	internal bool x12a7666830f9b83c
	{
		get
		{
			return (bool)xc454c03c23d4b4d9.xc3cc338a59c5293b(1270);
		}
		set
		{
			xc454c03c23d4b4d9.xb6157b6da9895c0d(1270, value);
		}
	}

	internal x8fdc64e3f5579ea8 x8fdc64e3f5579ea8
	{
		get
		{
			return (x8fdc64e3f5579ea8)xc454c03c23d4b4d9.xc3cc338a59c5293b(1510);
		}
		set
		{
			xc454c03c23d4b4d9.xb6157b6da9895c0d(1510, value);
		}
	}

	public bool Bidi
	{
		get
		{
			return (bool)xc454c03c23d4b4d9.xc3cc338a59c5293b(1560);
		}
		set
		{
			xc454c03c23d4b4d9.xb6157b6da9895c0d(1560, value);
		}
	}

	public double LeftIndent
	{
		get
		{
			return x4574ea26106f0edb.x0e1fdb362561ddb2((int)xc454c03c23d4b4d9.xc3cc338a59c5293b(1160));
		}
		set
		{
			xc454c03c23d4b4d9.xb55a99e2e1381d7f(1165);
			xc454c03c23d4b4d9.xb6157b6da9895c0d(1160, x4574ea26106f0edb.x88bf16f2386d633e(value));
		}
	}

	public double RightIndent
	{
		get
		{
			return x4574ea26106f0edb.x0e1fdb362561ddb2((int)xc454c03c23d4b4d9.xc3cc338a59c5293b(1150));
		}
		set
		{
			xc454c03c23d4b4d9.xb55a99e2e1381d7f(1155);
			xc454c03c23d4b4d9.xb6157b6da9895c0d(1150, x4574ea26106f0edb.x88bf16f2386d633e(value));
		}
	}

	public double FirstLineIndent
	{
		get
		{
			return x4574ea26106f0edb.x0e1fdb362561ddb2((int)xc454c03c23d4b4d9.xc3cc338a59c5293b(1170));
		}
		set
		{
			xc454c03c23d4b4d9.xb55a99e2e1381d7f(1175);
			xc454c03c23d4b4d9.xb6157b6da9895c0d(1170, x4574ea26106f0edb.x88bf16f2386d633e(value));
		}
	}

	public bool SpaceBeforeAuto
	{
		get
		{
			return (bool)xc454c03c23d4b4d9.xc3cc338a59c5293b(1210);
		}
		set
		{
			xc454c03c23d4b4d9.xb6157b6da9895c0d(1210, value);
		}
	}

	public bool SpaceAfterAuto
	{
		get
		{
			return (bool)xc454c03c23d4b4d9.xc3cc338a59c5293b(1230);
		}
		set
		{
			xc454c03c23d4b4d9.xb6157b6da9895c0d(1230, value);
		}
	}

	public double SpaceBefore
	{
		get
		{
			return x4574ea26106f0edb.x0e1fdb362561ddb2((int)xc454c03c23d4b4d9.xc3cc338a59c5293b(1200));
		}
		set
		{
			xc454c03c23d4b4d9.xb55a99e2e1381d7f(1205);
			xc454c03c23d4b4d9.xb6157b6da9895c0d(1200, x4574ea26106f0edb.x88bf16f2386d633e(value));
		}
	}

	public double SpaceAfter
	{
		get
		{
			return x4574ea26106f0edb.x0e1fdb362561ddb2((int)xc454c03c23d4b4d9.xc3cc338a59c5293b(1220));
		}
		set
		{
			xc454c03c23d4b4d9.xb55a99e2e1381d7f(1225);
			xc454c03c23d4b4d9.xb6157b6da9895c0d(1220, x4574ea26106f0edb.x88bf16f2386d633e(value));
		}
	}

	public LineSpacingRule LineSpacingRule
	{
		get
		{
			return ((x84bbacdc1fc0efd2)xc454c03c23d4b4d9.xc3cc338a59c5293b(1650)).xea9485ec61071863;
		}
		set
		{
			if (xc454c03c23d4b4d9.xb86fdbeadec3b75c(1650) == null)
			{
				xc454c03c23d4b4d9.xb6157b6da9895c0d(1650, ((x84bbacdc1fc0efd2)xc454c03c23d4b4d9.xc3cc338a59c5293b(1650)).x8b61531c8ea35b85());
			}
			x84bbacdc1fc0efd2 x84bbacdc1fc0efd = (x84bbacdc1fc0efd2)xc454c03c23d4b4d9.xb86fdbeadec3b75c(1650);
			x84bbacdc1fc0efd.xea9485ec61071863 = value;
		}
	}

	public double LineSpacing
	{
		get
		{
			return x4574ea26106f0edb.x0e1fdb362561ddb2(((x84bbacdc1fc0efd2)xc454c03c23d4b4d9.xc3cc338a59c5293b(1650)).xd2f68ee6f47e9dfb);
		}
		set
		{
			if (xc454c03c23d4b4d9.xb86fdbeadec3b75c(1650) == null)
			{
				xc454c03c23d4b4d9.xb6157b6da9895c0d(1650, ((x84bbacdc1fc0efd2)xc454c03c23d4b4d9.xc3cc338a59c5293b(1650)).x8b61531c8ea35b85());
			}
			x84bbacdc1fc0efd2 x84bbacdc1fc0efd = (x84bbacdc1fc0efd2)xc454c03c23d4b4d9.xb86fdbeadec3b75c(1650);
			x84bbacdc1fc0efd.xd2f68ee6f47e9dfb = x4574ea26106f0edb.x88bf16f2386d633e(value);
		}
	}

	internal double x4e22f2855b31a5f0 => x4574ea26106f0edb.x99578b0350da4963(LineSpacing);

	public bool IsHeading => Style.IsHeading;

	public bool IsListItem => x71c63f7e57f7ede5 != 0;

	internal int xf13a626e550cef8f
	{
		get
		{
			return (int)xc454c03c23d4b4d9.xc3cc338a59c5293b(1110);
		}
		set
		{
			xc454c03c23d4b4d9.xb6157b6da9895c0d(1110, value);
		}
	}

	internal int x71c63f7e57f7ede5
	{
		get
		{
			return (int)xc454c03c23d4b4d9.xc3cc338a59c5293b(1120);
		}
		set
		{
			xc454c03c23d4b4d9.xb6157b6da9895c0d(1120, value);
		}
	}

	public OutlineLevel OutlineLevel
	{
		get
		{
			return (OutlineLevel)xc454c03c23d4b4d9.xc3cc338a59c5293b(1280);
		}
		set
		{
			if (value < OutlineLevel.Level1 || value > OutlineLevel.BodyText)
			{
				throw new ArgumentOutOfRangeException("value");
			}
			xc454c03c23d4b4d9.xb6157b6da9895c0d(1280, value);
		}
	}

	internal double xa3c274715c3e6abe
	{
		get
		{
			return x4574ea26106f0edb.x0e1fdb362561ddb2((int)xc454c03c23d4b4d9.xc3cc338a59c5293b(1310));
		}
		set
		{
			xc454c03c23d4b4d9.xb6157b6da9895c0d(1310, x4574ea26106f0edb.x88bf16f2386d633e(value));
		}
	}

	internal double xbd8332bdab045b05
	{
		get
		{
			return x4574ea26106f0edb.x0e1fdb362561ddb2((int)xc454c03c23d4b4d9.xc3cc338a59c5293b(1420));
		}
		set
		{
			xc454c03c23d4b4d9.xb6157b6da9895c0d(1420, x4574ea26106f0edb.x88bf16f2386d633e(value));
		}
	}

	internal double x07f0fe00ef8c8a88
	{
		get
		{
			return x4574ea26106f0edb.x0e1fdb362561ddb2((int)xc454c03c23d4b4d9.xc3cc338a59c5293b(1292));
		}
		set
		{
			xc454c03c23d4b4d9.xb6157b6da9895c0d(1292, x4574ea26106f0edb.x88bf16f2386d633e(value));
		}
	}

	internal double x2c651fc94bf42334
	{
		get
		{
			return x4574ea26106f0edb.x0e1fdb362561ddb2((int)xc454c03c23d4b4d9.xc3cc338a59c5293b(1302));
		}
		set
		{
			xc454c03c23d4b4d9.xb6157b6da9895c0d(1302, x4574ea26106f0edb.x88bf16f2386d633e(value));
		}
	}

	internal HeightRule xc055999463b0ae9a
	{
		get
		{
			return (HeightRule)xc454c03c23d4b4d9.xc3cc338a59c5293b(1430);
		}
		set
		{
			xc454c03c23d4b4d9.xb6157b6da9895c0d(1430, value);
		}
	}

	internal HorizontalAlignment xab67cb9464a3325b
	{
		get
		{
			return (HorizontalAlignment)xc454c03c23d4b4d9.xc3cc338a59c5293b(1290);
		}
		set
		{
			xc454c03c23d4b4d9.xb6157b6da9895c0d(1290, value);
		}
	}

	internal VerticalAlignment xf6ce0e8106e6a1d8
	{
		get
		{
			return (VerticalAlignment)xc454c03c23d4b4d9.xc3cc338a59c5293b(1300);
		}
		set
		{
			xc454c03c23d4b4d9.xb6157b6da9895c0d(1300, value);
		}
	}

	internal bool x3ae458c10d6f2065
	{
		get
		{
			return (bool)xc454c03c23d4b4d9.xc3cc338a59c5293b(1520);
		}
		set
		{
			xc454c03c23d4b4d9.xb6157b6da9895c0d(1520, value);
		}
	}

	internal RelativeHorizontalPosition x06372ab09e719f75
	{
		get
		{
			return (RelativeHorizontalPosition)xc454c03c23d4b4d9.xc3cc338a59c5293b(1320);
		}
		set
		{
			xc454c03c23d4b4d9.xb6157b6da9895c0d(1320, value);
		}
	}

	internal RelativeVerticalPosition xb6a90a3cd96dc205
	{
		get
		{
			return (RelativeVerticalPosition)xc454c03c23d4b4d9.xc3cc338a59c5293b(1330);
		}
		set
		{
			xc454c03c23d4b4d9.xb6157b6da9895c0d(1330, value);
		}
	}

	internal WrapType xab6edfb47ff0b74c
	{
		get
		{
			return (WrapType)xc454c03c23d4b4d9.xc3cc338a59c5293b(1340);
		}
		set
		{
			xc454c03c23d4b4d9.xb6157b6da9895c0d(1340, value);
		}
	}

	internal double x7f83c9756026fc58
	{
		get
		{
			return x4574ea26106f0edb.x0e1fdb362561ddb2((int)xc454c03c23d4b4d9.xc3cc338a59c5293b(1500));
		}
		set
		{
			xc454c03c23d4b4d9.xb6157b6da9895c0d(1500, x4574ea26106f0edb.x88bf16f2386d633e(value));
		}
	}

	internal double x7e916c3f6beca6d9
	{
		get
		{
			return x4574ea26106f0edb.x0e1fdb362561ddb2((int)xc454c03c23d4b4d9.xc3cc338a59c5293b(1490));
		}
		set
		{
			xc454c03c23d4b4d9.xb6157b6da9895c0d(1490, x4574ea26106f0edb.x88bf16f2386d633e(value));
		}
	}

	internal TextOrientation xeeb818f91e3131df
	{
		get
		{
			return (TextOrientation)xc454c03c23d4b4d9.xc3cc338a59c5293b(1480);
		}
		set
		{
			xc454c03c23d4b4d9.xb6157b6da9895c0d(1480, value);
		}
	}

	internal bool xb5e4f9909e721350
	{
		get
		{
			return (bool)xc454c03c23d4b4d9.xc3cc338a59c5293b(1660);
		}
		set
		{
			xc454c03c23d4b4d9.xb6157b6da9895c0d(1660, value);
		}
	}

	public int LinesToDrop
	{
		get
		{
			return (int)xc454c03c23d4b4d9.xc3cc338a59c5293b(1450);
		}
		set
		{
			if (value < 0)
			{
				throw new ArgumentOutOfRangeException("value");
			}
			xc454c03c23d4b4d9.xb6157b6da9895c0d(1450, value);
		}
	}

	public DropCapPosition DropCapPosition
	{
		get
		{
			return (DropCapPosition)xc454c03c23d4b4d9.xc3cc338a59c5293b(1440);
		}
		set
		{
			xc454c03c23d4b4d9.xb6157b6da9895c0d(1440, value);
			x826ac1f1b38a3314(value);
		}
	}

	public Shading Shading
	{
		get
		{
			Shading shading = (Shading)xc454c03c23d4b4d9.xb86fdbeadec3b75c(1460);
			if (shading == null)
			{
				shading = new Shading(this, 1460);
				xc454c03c23d4b4d9.xb6157b6da9895c0d(1460, shading);
			}
			return shading;
		}
	}

	public BorderCollection Borders
	{
		get
		{
			if (xac8df3ffedaa82be == null)
			{
				xac8df3ffedaa82be = new BorderCollection(this);
			}
			return xac8df3ffedaa82be;
		}
	}

	public Style Style
	{
		get
		{
			if (x18c770831ef0bf38 == null)
			{
				return null;
			}
			return x18c770831ef0bf38.xf194004582627ed5(x8301ab10c226b0c2, 0);
		}
		set
		{
			if (value == null)
			{
				throw new ArgumentNullException("value");
			}
			if (value.Document != x18c770831ef0bf38.Document)
			{
				throw new ArgumentException(string.Intern(x1110bdd110cdcea4._xaacba899487bce8c("dogpepnpcpeajpladkcbdpjbbpacdphcdoocjnfdbjmdandeankeenbfenifanpfgmggpmngjhehkmlhcmciahjiokajkghjlkojnkfkhkmkekdlakklkkbmkjimakpmdkgnmennnieofjlogicpfjjpkiaaphhafioaiifbpdmb", 689436303)));
			}
			if (value.Type != StyleType.Paragraph)
			{
				throw new ArgumentException(string.Intern(x1110bdd110cdcea4._xaacba899487bce8c("abpgbcghpbnhgceiankiaccjobjjacakabhkgaokoleleamlladmfljmaabnophnaapnjkfohomodkdpapkponbamoiainpalngbdonbpmeclnlcancdfijdfnaednhefnoefmffllmfbidg", 548564668)));
			}
			x8301ab10c226b0c2 = value.x8301ab10c226b0c2;
		}
	}

	public string StyleName
	{
		get
		{
			return Style.Name;
		}
		set
		{
			Style = x18c770831ef0bf38.xfee6a7b399450516(value);
		}
	}

	public StyleIdentifier StyleIdentifier
	{
		get
		{
			return Style.StyleIdentifier;
		}
		set
		{
			Style = x18c770831ef0bf38.x590d8ef356786501(value);
		}
	}

	internal int x8301ab10c226b0c2
	{
		get
		{
			object obj = xc454c03c23d4b4d9.xb86fdbeadec3b75c(1000);
			if (obj == null)
			{
				return (int)x1a78664fa10a3755.x0095b789d636f3ae(1000);
			}
			return (int)obj;
		}
		set
		{
			xc454c03c23d4b4d9.xb6157b6da9895c0d(1000, value);
		}
	}

	public TabStopCollection TabStops
	{
		get
		{
			TabStopCollection tabStopCollection = (TabStopCollection)xc454c03c23d4b4d9.xb86fdbeadec3b75c(1140);
			if (tabStopCollection == null)
			{
				tabStopCollection = new TabStopCollection();
				xc454c03c23d4b4d9.xb6157b6da9895c0d(1140, tabStopCollection);
			}
			return tabStopCollection;
		}
	}

	SortedList x0e9935be205598e7.xa652231a0259f1c4 => x1a78664fa10a3755.x01e813efe52383e6;

	internal ParagraphFormat(xac4d96a62eaba39e parent, StyleCollection styles)
	{
		xc454c03c23d4b4d9 = parent;
		x18c770831ef0bf38 = styles;
	}

	public void ClearFormatting()
	{
		xc454c03c23d4b4d9.x6aea418c3f016cbd();
	}

	internal bool x93a65560cc2296a9(int xba08ce632055a1d9)
	{
		return xc454c03c23d4b4d9.xb86fdbeadec3b75c(xba08ce632055a1d9) != null;
	}

	private void x826ac1f1b38a3314(DropCapPosition xbcea506a33cf9111)
	{
		switch (xbcea506a33cf9111)
		{
		case DropCapPosition.Margin:
			xc454c03c23d4b4d9.xb6157b6da9895c0d(1320, RelativeHorizontalPosition.Page);
			xc454c03c23d4b4d9.xb6157b6da9895c0d(1330, RelativeHorizontalPosition.Column);
			break;
		case DropCapPosition.Normal:
			xc454c03c23d4b4d9.xb6157b6da9895c0d(1320, RelativeHorizontalPosition.Column);
			xc454c03c23d4b4d9.xb6157b6da9895c0d(1330, RelativeHorizontalPosition.Column);
			break;
		case DropCapPosition.None:
			break;
		}
	}

	private object x4497e36644489fd4(int xba08ce632055a1d9)
	{
		return xc454c03c23d4b4d9.xb86fdbeadec3b75c(xba08ce632055a1d9);
	}

	object x0e9935be205598e7.x6e9ebce5ff38cae9(int xba08ce632055a1d9)
	{
		//ILSpy generated this explicit interface implementation from .override directive in x4497e36644489fd4
		return this.x4497e36644489fd4(xba08ce632055a1d9);
	}

	private object x38e65374c3e63df4(int xba08ce632055a1d9)
	{
		return xc454c03c23d4b4d9.x51ae400150847113(xba08ce632055a1d9);
	}

	object x0e9935be205598e7.x3087b5fa67bcf3f4(int xba08ce632055a1d9)
	{
		//ILSpy generated this explicit interface implementation from .override directive in x38e65374c3e63df4
		return this.x38e65374c3e63df4(xba08ce632055a1d9);
	}

	private void xf448a09b8f5e15e8(int xba08ce632055a1d9, object xbcea506a33cf9111)
	{
		xc454c03c23d4b4d9.xb6157b6da9895c0d(xba08ce632055a1d9, xbcea506a33cf9111);
	}

	void x0e9935be205598e7.x039f0f0de50f5575(int xba08ce632055a1d9, object xbcea506a33cf9111)
	{
		//ILSpy generated this explicit interface implementation from .override directive in xf448a09b8f5e15e8
		this.xf448a09b8f5e15e8(xba08ce632055a1d9, xbcea506a33cf9111);
	}

	private object xb654ea8c7931bb83(int xba08ce632055a1d9)
	{
		return xc454c03c23d4b4d9.x51ae400150847113(xba08ce632055a1d9);
	}

	object x39462b2e4fc652e7.xccf76df3dc24953f(int xba08ce632055a1d9)
	{
		//ILSpy generated this explicit interface implementation from .override directive in xb654ea8c7931bb83
		return this.xb654ea8c7931bb83(xba08ce632055a1d9);
	}
}
