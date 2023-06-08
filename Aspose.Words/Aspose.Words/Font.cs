using System;
using System.Collections;
using System.Drawing;
using x13f1efc79617a47b;
using x28925c9b27b37a46;
using x5794c252ba25e723;
using x6c95d9cf46ff5f25;

namespace Aspose.Words;

public class Font : x0e9935be205598e7, x39462b2e4fc652e7
{
	internal const float x7902fa835e6aa32e = 0.8f;

	internal const float x4cba4c13f250c226 = 0.62f;

	internal const float x56fd6ec83b3dfd68 = 0.1f;

	internal const float xd5cb95a8afef260e = 0.35f;

	private readonly xf5ecf429e74b1c04 xc454c03c23d4b4d9;

	private readonly StyleCollection x18c770831ef0bf38;

	public string Name
	{
		get
		{
			return NameAscii;
		}
		set
		{
			x0d299f323d241756.x48501aec8e48c869(value, "value");
			NameAscii = value;
			NameBi = value;
			NameFarEast = value;
			NameOther = value;
		}
	}

	public string NameAscii
	{
		get
		{
			return (string)xfe91eeeafcb3026a(230);
		}
		set
		{
			x0d299f323d241756.x48501aec8e48c869(value, "value");
			xc454c03c23d4b4d9.xd00aa8389522ce53(230, value);
		}
	}

	public string NameBi
	{
		get
		{
			return (string)xfe91eeeafcb3026a(270);
		}
		set
		{
			x0d299f323d241756.x48501aec8e48c869(value, "value");
			xc454c03c23d4b4d9.xd00aa8389522ce53(270, value);
		}
	}

	public string NameFarEast
	{
		get
		{
			return (string)xfe91eeeafcb3026a(235);
		}
		set
		{
			x0d299f323d241756.x48501aec8e48c869(value, "value");
			xc454c03c23d4b4d9.xd00aa8389522ce53(235, value);
		}
	}

	public string NameOther
	{
		get
		{
			return (string)xfe91eeeafcb3026a(240);
		}
		set
		{
			x0d299f323d241756.x48501aec8e48c869(value, "value");
			xc454c03c23d4b4d9.xd00aa8389522ce53(240, value);
		}
	}

	internal x000f21cbda739311 x405f93d712e7bd65 => (x000f21cbda739311)xfe91eeeafcb3026a(400);

	public double Size
	{
		get
		{
			return x4574ea26106f0edb.x4610495f80b4c267((int)xfe91eeeafcb3026a(190));
		}
		set
		{
			xc454c03c23d4b4d9.xd00aa8389522ce53(190, x4574ea26106f0edb.x3f26fa43a4a41e70(value));
		}
	}

	public double SizeBi
	{
		get
		{
			return x4574ea26106f0edb.x4610495f80b4c267((int)xfe91eeeafcb3026a(350));
		}
		set
		{
			xc454c03c23d4b4d9.xd00aa8389522ce53(350, x4574ea26106f0edb.x3f26fa43a4a41e70(value));
		}
	}

	public bool Bold
	{
		get
		{
			return x6e16b83386574e87(60);
		}
		set
		{
			x0248d870497fc66d(60, value);
		}
	}

	public bool BoldBi
	{
		get
		{
			return x6e16b83386574e87(250);
		}
		set
		{
			x0248d870497fc66d(250, value);
		}
	}

	public bool Italic
	{
		get
		{
			return x6e16b83386574e87(70);
		}
		set
		{
			x0248d870497fc66d(70, value);
		}
	}

	public bool ItalicBi
	{
		get
		{
			return x6e16b83386574e87(260);
		}
		set
		{
			x0248d870497fc66d(260, value);
		}
	}

	internal FontStyle xfa47517dba72fd20
	{
		get
		{
			FontStyle fontStyle = FontStyle.Regular;
			if (Bold)
			{
				fontStyle |= FontStyle.Bold;
			}
			if (Italic)
			{
				fontStyle |= FontStyle.Italic;
			}
			return fontStyle;
		}
	}

	public Color Color
	{
		get
		{
			return x63b1a7c31a962459.xc7656a130b2889c7();
		}
		set
		{
			x63b1a7c31a962459 = x26d9ecb4bdf0456d.xcd907c08c553c15c(value);
		}
	}

	internal x26d9ecb4bdf0456d x63b1a7c31a962459
	{
		get
		{
			return (x26d9ecb4bdf0456d)xfe91eeeafcb3026a(160);
		}
		set
		{
			xc454c03c23d4b4d9.xd00aa8389522ce53(160, value);
		}
	}

	public bool StrikeThrough
	{
		get
		{
			return x6e16b83386574e87(80);
		}
		set
		{
			x0248d870497fc66d(80, value);
		}
	}

	public bool DoubleStrikeThrough
	{
		get
		{
			return x6e16b83386574e87(300);
		}
		set
		{
			x0248d870497fc66d(300, value);
		}
	}

	public bool Shadow
	{
		get
		{
			return x6e16b83386574e87(100);
		}
		set
		{
			x0248d870497fc66d(100, value);
		}
	}

	public bool Outline
	{
		get
		{
			return x6e16b83386574e87(90);
		}
		set
		{
			x0248d870497fc66d(90, value);
		}
	}

	public bool Emboss
	{
		get
		{
			return x6e16b83386574e87(170);
		}
		set
		{
			x0248d870497fc66d(170, value);
		}
	}

	public bool Engrave
	{
		get
		{
			return x6e16b83386574e87(180);
		}
		set
		{
			x0248d870497fc66d(180, value);
		}
	}

	public bool Superscript
	{
		get
		{
			return xf6ce0e8106e6a1d8 == x7af53bbecc5ccdd5.xab66d68facbadf18;
		}
		set
		{
			if (value != Superscript)
			{
				xf6ce0e8106e6a1d8 = (value ? x7af53bbecc5ccdd5.xab66d68facbadf18 : x7af53bbecc5ccdd5.x139412b8dea2f02b);
			}
		}
	}

	public bool Subscript
	{
		get
		{
			return xf6ce0e8106e6a1d8 == x7af53bbecc5ccdd5.x1b1f4712a1a0c38c;
		}
		set
		{
			if (value != Subscript)
			{
				xf6ce0e8106e6a1d8 = (value ? x7af53bbecc5ccdd5.x1b1f4712a1a0c38c : x7af53bbecc5ccdd5.x139412b8dea2f02b);
			}
		}
	}

	public bool SmallCaps
	{
		get
		{
			return x6e16b83386574e87(110);
		}
		set
		{
			x0248d870497fc66d(110, value);
		}
	}

	public bool AllCaps
	{
		get
		{
			return x6e16b83386574e87(120);
		}
		set
		{
			x0248d870497fc66d(120, value);
		}
	}

	public bool Hidden
	{
		get
		{
			return x6e16b83386574e87(130);
		}
		set
		{
			x0248d870497fc66d(130, value);
		}
	}

	public Underline Underline
	{
		get
		{
			return (Underline)xfe91eeeafcb3026a(140);
		}
		set
		{
			xc454c03c23d4b4d9.xd00aa8389522ce53(140, value);
		}
	}

	public Color UnderlineColor
	{
		get
		{
			return x99907b37201c7b19.xc7656a130b2889c7();
		}
		set
		{
			x99907b37201c7b19 = x26d9ecb4bdf0456d.xcd907c08c553c15c(value);
		}
	}

	internal x26d9ecb4bdf0456d x99907b37201c7b19
	{
		get
		{
			return (x26d9ecb4bdf0456d)xfe91eeeafcb3026a(450);
		}
		set
		{
			xc454c03c23d4b4d9.xd00aa8389522ce53(450, value);
		}
	}

	public int Scaling
	{
		get
		{
			return (int)xfe91eeeafcb3026a(290);
		}
		set
		{
			xc454c03c23d4b4d9.xd00aa8389522ce53(290, value);
		}
	}

	public double Spacing
	{
		get
		{
			return x4574ea26106f0edb.x0e1fdb362561ddb2(xbcb6fa15d8981abb);
		}
		set
		{
			xbcb6fa15d8981abb = x4574ea26106f0edb.x88bf16f2386d633e(value);
		}
	}

	internal int xbcb6fa15d8981abb
	{
		get
		{
			return (int)xfe91eeeafcb3026a(150);
		}
		set
		{
			xc454c03c23d4b4d9.xd00aa8389522ce53(150, value);
		}
	}

	public double Position
	{
		get
		{
			return x4574ea26106f0edb.x4610495f80b4c267((int)xfe91eeeafcb3026a(200));
		}
		set
		{
			xc454c03c23d4b4d9.xd00aa8389522ce53(200, x4574ea26106f0edb.x3f26fa43a4a41e70(value));
		}
	}

	public double Kerning
	{
		get
		{
			return x4574ea26106f0edb.x4610495f80b4c267((int)xfe91eeeafcb3026a(220));
		}
		set
		{
			xc454c03c23d4b4d9.xd00aa8389522ce53(220, x4574ea26106f0edb.x3f26fa43a4a41e70(value));
		}
	}

	public Color HighlightColor
	{
		get
		{
			return xff8cd6f1d57322e6.xc7656a130b2889c7();
		}
		set
		{
			xff8cd6f1d57322e6 = x26d9ecb4bdf0456d.xcd907c08c553c15c(value);
		}
	}

	internal x26d9ecb4bdf0456d xff8cd6f1d57322e6
	{
		get
		{
			return (x26d9ecb4bdf0456d)xfe91eeeafcb3026a(20);
		}
		set
		{
			xc454c03c23d4b4d9.xd00aa8389522ce53(20, value);
		}
	}

	public TextEffect TextEffect
	{
		get
		{
			return (TextEffect)xfe91eeeafcb3026a(310);
		}
		set
		{
			xc454c03c23d4b4d9.xd00aa8389522ce53(310, value);
		}
	}

	public bool Bidi
	{
		get
		{
			return x6e16b83386574e87(265);
		}
		set
		{
			x0248d870497fc66d(265, value);
		}
	}

	public bool ComplexScript
	{
		get
		{
			return x6e16b83386574e87(268);
		}
		set
		{
			x0248d870497fc66d(268, value);
		}
	}

	public bool NoProofing
	{
		get
		{
			return x6e16b83386574e87(440);
		}
		set
		{
			x0248d870497fc66d(440, value);
		}
	}

	public int LocaleId
	{
		get
		{
			return (int)xfe91eeeafcb3026a(380);
		}
		set
		{
			xc454c03c23d4b4d9.xd00aa8389522ce53(380, value);
		}
	}

	public int LocaleIdBi
	{
		get
		{
			return (int)xfe91eeeafcb3026a(340);
		}
		set
		{
			xc454c03c23d4b4d9.xd00aa8389522ce53(340, value);
		}
	}

	public int LocaleIdFarEast
	{
		get
		{
			return (int)xfe91eeeafcb3026a(390);
		}
		set
		{
			xc454c03c23d4b4d9.xd00aa8389522ce53(390, value);
		}
	}

	public Border Border
	{
		get
		{
			Border border = (Border)xc454c03c23d4b4d9.x9bd0b4c41657450b(360);
			if (border == null)
			{
				border = new Border(this, 360);
				xc454c03c23d4b4d9.xd00aa8389522ce53(360, border);
			}
			return border;
		}
	}

	public Shading Shading
	{
		get
		{
			Shading shading = (Shading)xc454c03c23d4b4d9.x9bd0b4c41657450b(370);
			if (shading == null)
			{
				shading = new Shading(this, 370);
				xc454c03c23d4b4d9.xd00aa8389522ce53(370, shading);
			}
			return shading;
		}
	}

	public Style Style
	{
		get
		{
			return x18c770831ef0bf38.xf194004582627ed5(x8301ab10c226b0c2, 10);
		}
		set
		{
			if (value == null)
			{
				throw new ArgumentNullException("value");
			}
			if (value.Document != x18c770831ef0bf38.Document)
			{
				throw new ArgumentException(string.Intern(x1110bdd110cdcea4._xaacba899487bce8c("gmolhnfmfnmmmndngikngnboeniognpogmgpmlnpeheadlladlcbhljbhlacdlhcjkocclfdmfmdnkdefkkedfbfbjifnepfoiggajngkiehhilhdicinijinhajdihjgiojpcfkahmkihdljgklihbmngimcgpmiggnlgnncceo", 283885170)));
			}
			if (value.Type != StyleType.Character)
			{
				throw new ArgumentException(string.Intern(x1110bdd110cdcea4._xaacba899487bce8c("fpfbganbeaeclalcflbdfajddaaefahefpneloefdklfjocgapjgkjahfohhdoohfofioimimmdjiikjimbkkmikampkomglklnljlemhmlmflcnpljnkgaoklhoilooklfpkkmpakdaggka", 1923028385)));
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
			object obj = xc454c03c23d4b4d9.x9bd0b4c41657450b(50);
			if (obj == null)
			{
				return (int)xeedad81aaed42a76.x0095b789d636f3ae(50);
			}
			return (int)obj;
		}
		set
		{
			xc454c03c23d4b4d9.xd00aa8389522ce53(50, value);
		}
	}

	internal x7af53bbecc5ccdd5 xf6ce0e8106e6a1d8
	{
		get
		{
			return (x7af53bbecc5ccdd5)xfe91eeeafcb3026a(210);
		}
		set
		{
			xc454c03c23d4b4d9.xd00aa8389522ce53(210, value);
		}
	}

	internal bool xf2ad33c56ce6586d => x684b09378db148f4.xf2ad33c56ce6586d(xc454c03c23d4b4d9);

	internal xf5ecf429e74b1c04 x332a8eedb847940d => xc454c03c23d4b4d9;

	SortedList x0e9935be205598e7.xa652231a0259f1c4 => null;

	internal Font(xf5ecf429e74b1c04 parent, StyleCollection styles)
	{
		xc454c03c23d4b4d9 = parent;
		x18c770831ef0bf38 = styles;
	}

	internal Font()
		: this(new xeedad81aaed42a76(), null)
	{
	}

	public void ClearFormatting()
	{
		xc454c03c23d4b4d9.xe80983f2918b2568();
	}

	internal string xaf95fb496eb25433(x000f21cbda739311 x6f02b6a80bf6b36f)
	{
		return x6f02b6a80bf6b36f switch
		{
			x000f21cbda739311.x175297738c8b8d1e => NameAscii, 
			x000f21cbda739311.xd4e922ceeed89b74 => NameBi, 
			x000f21cbda739311.x7c8c2d13fa5b79fa => NameFarEast, 
			_ => NameOther, 
		};
	}

	internal float xe286def5a6a116b8(bool x282df02f8c72bc6f)
	{
		double num = Size;
		if (!x282df02f8c72bc6f && SmallCaps)
		{
			num *= 0.800000011920929;
		}
		if (Subscript || Superscript)
		{
			num *= 0.6200000047683716;
		}
		return (float)num;
	}

	internal object xfe91eeeafcb3026a(int xba08ce632055a1d9)
	{
		return x684b09378db148f4.xfe91eeeafcb3026a(xc454c03c23d4b4d9, xba08ce632055a1d9);
	}

	internal bool xd538fa592193218b(int xba08ce632055a1d9)
	{
		object obj = xc454c03c23d4b4d9.x9bd0b4c41657450b(xba08ce632055a1d9);
		return obj != null;
	}

	private bool x6e16b83386574e87(int xba08ce632055a1d9)
	{
		return ((x9b28b1f7f0cc963f)xfe91eeeafcb3026a(xba08ce632055a1d9)).x4e98cd0cf854343f();
	}

	private void x0248d870497fc66d(int xba08ce632055a1d9, bool xbcea506a33cf9111)
	{
		xc454c03c23d4b4d9.xd00aa8389522ce53(xba08ce632055a1d9, x9b28b1f7f0cc963f.x1e5f5c3e4c508bf0(xbcea506a33cf9111));
	}

	private object x4497e36644489fd4(int xba08ce632055a1d9)
	{
		return xc454c03c23d4b4d9.x9bd0b4c41657450b(xba08ce632055a1d9);
	}

	object x0e9935be205598e7.x6e9ebce5ff38cae9(int xba08ce632055a1d9)
	{
		//ILSpy generated this explicit interface implementation from .override directive in x4497e36644489fd4
		return this.x4497e36644489fd4(xba08ce632055a1d9);
	}

	private object x38e65374c3e63df4(int xba08ce632055a1d9)
	{
		return xc454c03c23d4b4d9.x2685f947206319cf(xba08ce632055a1d9);
	}

	object x0e9935be205598e7.x3087b5fa67bcf3f4(int xba08ce632055a1d9)
	{
		//ILSpy generated this explicit interface implementation from .override directive in x38e65374c3e63df4
		return this.x38e65374c3e63df4(xba08ce632055a1d9);
	}

	private void xf448a09b8f5e15e8(int xba08ce632055a1d9, object xbcea506a33cf9111)
	{
		xc454c03c23d4b4d9.xd00aa8389522ce53(xba08ce632055a1d9, xbcea506a33cf9111);
	}

	void x0e9935be205598e7.x039f0f0de50f5575(int xba08ce632055a1d9, object xbcea506a33cf9111)
	{
		//ILSpy generated this explicit interface implementation from .override directive in xf448a09b8f5e15e8
		this.xf448a09b8f5e15e8(xba08ce632055a1d9, xbcea506a33cf9111);
	}

	private object xb654ea8c7931bb83(int xba08ce632055a1d9)
	{
		return xc454c03c23d4b4d9.x2685f947206319cf(xba08ce632055a1d9);
	}

	object x39462b2e4fc652e7.xccf76df3dc24953f(int xba08ce632055a1d9)
	{
		//ILSpy generated this explicit interface implementation from .override directive in xb654ea8c7931bb83
		return this.xb654ea8c7931bb83(xba08ce632055a1d9);
	}
}
