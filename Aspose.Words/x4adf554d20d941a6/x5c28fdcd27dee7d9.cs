using System;
using System.Collections;
using Aspose;
using Aspose.Words;
using Aspose.Words.Fields;
using x13f1efc79617a47b;
using x28925c9b27b37a46;
using x59d6a4fc5007b7a4;
using xfbd1009a0cbb9842;

namespace x4adf554d20d941a6;

internal class x5c28fdcd27dee7d9 : x61ebdec02c254c25
{
	private readonly FieldChar xd37346e1b4894e02;

	private x5c28fdcd27dee7d9 x5f8aa5b0abf571d4;

	private x5c28fdcd27dee7d9 xf3daf842d1b1d7bd;

	private string xcbb1563eca0c21f2;

	private Field x54c413cc80cb99d5;

	private bool xd5fefd89eedb4084;

	internal override int x1be93eed8950d961 => 1;

	internal override x56410a8dd70087c5 x53819c070f6c4652
	{
		get
		{
			return xf3daf842d1b1d7bd;
		}
		set
		{
			xf3daf842d1b1d7bd = (x5c28fdcd27dee7d9)value;
		}
	}

	internal override x6e414db5d060a816 x6e414db5d060a816 => xb7c4cf9f30ad5f2a.NodeType switch
	{
		NodeType.FieldStart => x6e414db5d060a816.x12cb12b5d2cad53d, 
		NodeType.FieldSeparator => x6e414db5d060a816.x865739e9b580d3cf, 
		NodeType.FieldEnd => x6e414db5d060a816.x9fd888e65466818c, 
		_ => throw new InvalidOperationException("Unexpected node type."), 
	};

	internal override string xf9ad6fb78355fe13 => xb7c4cf9f30ad5f2a.NodeType switch
	{
		NodeType.FieldStart => "[", 
		NodeType.FieldEnd => "]", 
		NodeType.FieldSeparator => "|", 
		_ => " ", 
	};

	internal x5c28fdcd27dee7d9 x9a05d8dab0f0619f
	{
		get
		{
			return xd37346e1b4894e02.NodeType switch
			{
				NodeType.FieldStart => this, 
				NodeType.FieldEnd => xf3daf842d1b1d7bd, 
				NodeType.FieldSeparator => x70ff891026cb8704.x9a05d8dab0f0619f, 
				_ => throw new InvalidOperationException("Unexpected node type."), 
			};
		}
		set
		{
			switch (xd37346e1b4894e02.NodeType)
			{
			case NodeType.FieldEnd:
				xf3daf842d1b1d7bd = value;
				value.xf3daf842d1b1d7bd = this;
				break;
			case NodeType.FieldSeparator:
				x70ff891026cb8704.x9a05d8dab0f0619f = value;
				value.xf3daf842d1b1d7bd = x70ff891026cb8704;
				break;
			default:
				throw new InvalidOperationException("Unexpected node type.");
			}
		}
	}

	internal x5c28fdcd27dee7d9 x275cb4c2185b2177
	{
		get
		{
			return xd37346e1b4894e02.NodeType switch
			{
				NodeType.FieldStart => x70ff891026cb8704.x275cb4c2185b2177, 
				NodeType.FieldEnd => x5f8aa5b0abf571d4, 
				NodeType.FieldSeparator => this, 
				_ => throw new InvalidOperationException("Unexpected node type."), 
			};
		}
		set
		{
			switch (xd37346e1b4894e02.NodeType)
			{
			case NodeType.FieldStart:
				x70ff891026cb8704.x275cb4c2185b2177 = value;
				value.x5f8aa5b0abf571d4 = x70ff891026cb8704;
				break;
			case NodeType.FieldEnd:
				x5f8aa5b0abf571d4 = value;
				value.x5f8aa5b0abf571d4 = this;
				break;
			default:
				throw new InvalidOperationException("Unexpected node type.");
			}
		}
	}

	internal x5c28fdcd27dee7d9 x70ff891026cb8704
	{
		get
		{
			return xd37346e1b4894e02.NodeType switch
			{
				NodeType.FieldStart => xf3daf842d1b1d7bd, 
				NodeType.FieldSeparator => x5f8aa5b0abf571d4, 
				NodeType.FieldEnd => this, 
				_ => throw new InvalidOperationException("Unexpected node type."), 
			};
		}
		set
		{
			switch (xd37346e1b4894e02.NodeType)
			{
			case NodeType.FieldStart:
				x5f8aa5b0abf571d4 = value;
				value.x5f8aa5b0abf571d4 = this;
				break;
			case NodeType.FieldSeparator:
				xf3daf842d1b1d7bd = value;
				value.xf3daf842d1b1d7bd = this;
				break;
			default:
				throw new InvalidOperationException("Unexpected node type.");
			}
		}
	}

	internal FieldType xc96d173d58dd8a20 => x9a05d8dab0f0619f.xb7c4cf9f30ad5f2a.FieldType;

	internal FieldChar xb7c4cf9f30ad5f2a => xd37346e1b4894e02;

	internal Field xd1b40af56a8385d4
	{
		get
		{
			if (x54c413cc80cb99d5 == null)
			{
				switch (x6e414db5d060a816)
				{
				case x6e414db5d060a816.x12cb12b5d2cad53d:
					if (x70ff891026cb8704 == null)
					{
						return null;
					}
					break;
				case x6e414db5d060a816.x9fd888e65466818c:
					if (x9a05d8dab0f0619f == null)
					{
						return null;
					}
					break;
				case x6e414db5d060a816.x865739e9b580d3cf:
					if (x70ff891026cb8704 == null || x9a05d8dab0f0619f == null)
					{
						return null;
					}
					break;
				}
				FieldStart x10aaa7cdfa38f = (FieldStart)x9a05d8dab0f0619f.xd37346e1b4894e02;
				FieldEnd xca09b6c2b5b = (FieldEnd)x70ff891026cb8704.xd37346e1b4894e02;
				FieldSeparator x3de314ab70bbd9bf = ((x275cb4c2185b2177 != null) ? ((FieldSeparator)x275cb4c2185b2177.xd37346e1b4894e02) : null);
				x54c413cc80cb99d5 = x3759c06a3a4cf5d1.x43fef3435fba7a66(x10aaa7cdfa38f, x3de314ab70bbd9bf, xca09b6c2b5b);
			}
			return x54c413cc80cb99d5;
		}
		set
		{
			x54c413cc80cb99d5 = value;
		}
	}

	internal string xc9bcfb2d9630b0c7
	{
		get
		{
			switch (xc96d173d58dd8a20)
			{
			case FieldType.FieldHyperlink:
				return ((xae25961a48dae6ad)xd1b40af56a8385d4).x58c712b0d1d1c39b;
			case FieldType.FieldRef:
				return "#" + ((x730be1b1b0b78790)xd1b40af56a8385d4).x0e99a2a20bc3c647;
			case FieldType.FieldNoteRef:
				return "#" + ((x7ed63e2b29aa2d23)xd1b40af56a8385d4).x0e99a2a20bc3c647;
			case FieldType.FieldPageRef:
			{
				x454fffaf703e5e86 x454fffaf703e5e = (x454fffaf703e5e86)xd1b40af56a8385d4;
				if (x454fffaf703e5e.xd1f083ffc72ae389)
				{
					return "#" + x454fffaf703e5e.x0e99a2a20bc3c647;
				}
				break;
			}
			}
			return string.Empty;
		}
	}

	internal x5c28fdcd27dee7d9(FieldChar value)
		: base(0)
	{
		xd37346e1b4894e02 = value;
	}

	[JavaConvertCheckedExceptions]
	internal override void x3e04636bf524a4cf(xb9e48f11d7f06ec9 x27f5ecb735ac9676)
	{
		if (x27f5ecb735ac9676 != xb9e48f11d7f06ec9.x56410a8dd70087c5 || x6e414db5d060a816 != x6e414db5d060a816.x12cb12b5d2cad53d || xd5fefd89eedb4084)
		{
			return;
		}
		xd5fefd89eedb4084 = true;
		x56410a8dd70087c5 x62584df2cb5d40dd;
		x56410a8dd70087c5 x2aa5114a5da7d6c;
		if (x5c29822913be33c1.xb2cdffc8e47588c8(xb7c4cf9f30ad5f2a.FieldType))
		{
			x91f68097aef9038e(out x62584df2cb5d40dd, out x2aa5114a5da7d6c);
			xa79151ec088f1e4d(x62584df2cb5d40dd, x2aa5114a5da7d6c);
		}
		else
		{
			x7e263f21a73a027a x7e263f21a73a027a = xd1b40af56a8385d4.x1c428e55430b2acc();
			if (x7e263f21a73a027a == null)
			{
				return;
			}
			xd274684ade475f6e(out x62584df2cb5d40dd, out x2aa5114a5da7d6c);
			x57bf52bb3d1c2d43(x62584df2cb5d40dd, x2aa5114a5da7d6c, x7e263f21a73a027a, x9bd63a942c164ecd: true);
		}
		x53111d6596d16a99.x2c8c6741422a1298.xe1410f585439c7d4.x408f4b7efc86fd49();
	}

	internal override x56410a8dd70087c5 xa9d7e8f6fbdcbcfc(x56410a8dd70087c5 x7d95d971d8923f4c)
	{
		if (x7d95d971d8923f4c == null)
		{
			x7d95d971d8923f4c = new x5c28fdcd27dee7d9(xd37346e1b4894e02);
		}
		x5c28fdcd27dee7d9 x5c28fdcd27dee7d10 = (x5c28fdcd27dee7d9)x7d95d971d8923f4c;
		x5c28fdcd27dee7d10.xcbb1563eca0c21f2 = xcbb1563eca0c21f2;
		x5c28fdcd27dee7d10.x54c413cc80cb99d5 = x54c413cc80cb99d5;
		return base.xa9d7e8f6fbdcbcfc(x7d95d971d8923f4c);
	}

	internal override void xb19ff4e6c96375bd(Hashtable x12fedb3de1c57ea7, x56410a8dd70087c5 x337e217cb3ba0627)
	{
		base.xb19ff4e6c96375bd(x12fedb3de1c57ea7, x337e217cb3ba0627);
		x5c28fdcd27dee7d9 x5c28fdcd27dee7d10 = (x5c28fdcd27dee7d9)x337e217cb3ba0627;
		if (x5c28fdcd27dee7d10.x5f8aa5b0abf571d4 != null)
		{
			x5c28fdcd27dee7d9 x5c28fdcd27dee7d11 = (x5c28fdcd27dee7d9)x12fedb3de1c57ea7[x5c28fdcd27dee7d10.x5f8aa5b0abf571d4];
			if (x5c28fdcd27dee7d11 != null)
			{
				x5f8aa5b0abf571d4 = x5c28fdcd27dee7d11;
				x5c28fdcd27dee7d11.x5f8aa5b0abf571d4 = this;
			}
		}
	}

	internal override void x7012609bcdb39574(x75b8b2f740aae644 x672ff13faf031f3d)
	{
		base.x7012609bcdb39574(x672ff13faf031f3d);
		x672ff13faf031f3d.x71a35fbecc7bfd01(this);
	}

	internal void x295cb4a1df7a5add()
	{
		x295cb4a1df7a5add(null);
	}

	internal void x295cb4a1df7a5add(Field xe01ae93d9fe5a880)
	{
		if (x6e414db5d060a816 != x6e414db5d060a816.x12cb12b5d2cad53d)
		{
			x9a05d8dab0f0619f.x295cb4a1df7a5add(xe01ae93d9fe5a880);
			return;
		}
		Field field = ((xe01ae93d9fe5a880 != null) ? xe01ae93d9fe5a880 : xd1b40af56a8385d4);
		x825568e289c5e629 x825568e289c5e = field.xda55dc11084967d0(new x9b9129deff8239b5(this));
		if (x825568e289c5e != null)
		{
			switch (x825568e289c5e.xeb9b077cea899945)
			{
			case xc16aad357e715234.xc15967a69fd4424e:
			{
				xd274684ade475f6e(out var x62584df2cb5d40dd2, out var x2aa5114a5da7d6c2);
				x57bf52bb3d1c2d43(x62584df2cb5d40dd2, x2aa5114a5da7d6c2, x825568e289c5e.x7d2e50686d249839, x9bd63a942c164ecd: true);
				break;
			}
			case xc16aad357e715234.xe93eb88030ad2248:
			{
				x91f68097aef9038e(out var x62584df2cb5d40dd, out var x2aa5114a5da7d6c);
				x57bf52bb3d1c2d43(x62584df2cb5d40dd, x2aa5114a5da7d6c, x825568e289c5e.x7d2e50686d249839, x9bd63a942c164ecd: false);
				break;
			}
			case xc16aad357e715234.xede4646e426cf6a7:
				x57bf52bb3d1c2d43(x9a05d8dab0f0619f, x70ff891026cb8704, x825568e289c5e.x7d2e50686d249839, x9bd63a942c164ecd: false);
				break;
			}
			x53111d6596d16a99.x2c8c6741422a1298.xe1410f585439c7d4.x408f4b7efc86fd49();
		}
	}

	internal int x9ec60fbbaa3117a2()
	{
		return xc96d173d58dd8a20 switch
		{
			FieldType.FieldPage => x6af07e13bc41d733(this), 
			FieldType.FieldPageRef => x47dd32fbd2647bf6(), 
			FieldType.FieldNumPages => x62d5cf18e92f1d20(), 
			FieldType.FieldSectionPages => x2e72240a1c615b58(this), 
			_ => -1, 
		};
	}

	private void xd274684ade475f6e(out x56410a8dd70087c5 x62584df2cb5d40dd, out x56410a8dd70087c5 x2aa5114a5da7d6c8)
	{
		xf3f447691ab38eee xf3f447691ab38eee2 = x53111d6596d16a99.xb3a79d506b0e2f7f.x8b61531c8ea35b85();
		if (!xf3f447691ab38eee2.xd8b11076ff837685(x70ff891026cb8704) || !xf3f447691ab38eee2.x47f176deff0d42e2())
		{
			throw new InvalidOperationException();
		}
		x62584df2cb5d40dd = (x56410a8dd70087c5)xf3f447691ab38eee2.x35cfcea4890f4e7d;
		x2aa5114a5da7d6c8 = null;
		while (((x56410a8dd70087c5)xf3f447691ab38eee2.x35cfcea4890f4e7d).x4e1234ca2b87020b)
		{
			x2aa5114a5da7d6c8 = (x56410a8dd70087c5)xf3f447691ab38eee2.x35cfcea4890f4e7d;
			if (!xf3f447691ab38eee2.x47f176deff0d42e2())
			{
				throw new InvalidOperationException();
			}
		}
	}

	private void x91f68097aef9038e(out x56410a8dd70087c5 x62584df2cb5d40dd, out x56410a8dd70087c5 x2aa5114a5da7d6c8)
	{
		xf3f447691ab38eee xf3f447691ab38eee2 = x53111d6596d16a99.xb3a79d506b0e2f7f.x8b61531c8ea35b85();
		if (!xf3f447691ab38eee2.xd8b11076ff837685(x275cb4c2185b2177) || !xf3f447691ab38eee2.x47f176deff0d42e2())
		{
			throw new InvalidOperationException();
		}
		x62584df2cb5d40dd = (x56410a8dd70087c5)xf3f447691ab38eee2.x35cfcea4890f4e7d;
		if (x62584df2cb5d40dd == x70ff891026cb8704)
		{
			x2aa5114a5da7d6c8 = null;
			return;
		}
		if (!xf3f447691ab38eee2.xd8b11076ff837685(x70ff891026cb8704) || !xf3f447691ab38eee2.x355eaee82ffc1f46())
		{
			throw new InvalidOperationException();
		}
		x2aa5114a5da7d6c8 = (x56410a8dd70087c5)xf3f447691ab38eee2.x35cfcea4890f4e7d;
	}

	private x56410a8dd70087c5 x57bf52bb3d1c2d43(x56410a8dd70087c5 x62584df2cb5d40dd, x56410a8dd70087c5 x2aa5114a5da7d6c8, x7e263f21a73a027a x9b10ace6509508c0, bool x9bd63a942c164ecd)
	{
		x56410a8dd70087c5 result = xe481a91e9d1f486d(x9b10ace6509508c0, x62584df2cb5d40dd, x9bd63a942c164ecd);
		xa79151ec088f1e4d(x62584df2cb5d40dd, x2aa5114a5da7d6c8);
		return result;
	}

	private static void xa79151ec088f1e4d(x56410a8dd70087c5 x62584df2cb5d40dd, x56410a8dd70087c5 x2aa5114a5da7d6c8)
	{
		if (x2aa5114a5da7d6c8 != null)
		{
			xa268fdb9ca040dde xe1410f585439c7d = x62584df2cb5d40dd.x2c8c6741422a1298.xe1410f585439c7d4;
			xf3f447691ab38eee xf3f447691ab38eee2 = x62584df2cb5d40dd.x53111d6596d16a99.xb3a79d506b0e2f7f.x8b61531c8ea35b85();
			if (!xf3f447691ab38eee2.xd8b11076ff837685(x62584df2cb5d40dd))
			{
				throw new InvalidOperationException();
			}
			bool flag;
			do
			{
				flag = xf3f447691ab38eee2.x35cfcea4890f4e7d == x2aa5114a5da7d6c8;
				xe1410f585439c7d.x52b190e626f65140((x56410a8dd70087c5)xf3f447691ab38eee2.x35cfcea4890f4e7d);
			}
			while (!flag);
		}
	}

	private x56410a8dd70087c5 xe481a91e9d1f486d(x7e263f21a73a027a xa955664f4f50999d, x56410a8dd70087c5 x62584df2cb5d40dd, bool x9bd63a942c164ecd)
	{
		if (xa955664f4f50999d.x30d6662e83251ab4 || xa955664f4f50999d.x7149c962c02931b3)
		{
			return null;
		}
		x487cdc969fefe3d6 x487cdc969fefe3d = new x487cdc969fefe3d6(xa955664f4f50999d, x62584df2cb5d40dd);
		x56410a8dd70087c5 x56410a8dd70087c6 = null;
		while (x487cdc969fefe3d.x47f176deff0d42e2())
		{
			if (x56410a8dd70087c6 == null)
			{
				x487cdc969fefe3d.xbe1e23e7d5b43370.xac6c82c74ce247fb = x53111d6596d16a99;
				x56410a8dd70087c6 = x487cdc969fefe3d.x56410a8dd70087c5;
			}
			if (x9bd63a942c164ecd)
			{
				x487cdc969fefe3d.x56410a8dd70087c5.x4e1234ca2b87020b = true;
			}
			x2c8c6741422a1298.xe1410f585439c7d4.xef23aa45e7612fdd(x487cdc969fefe3d.xbe1e23e7d5b43370, x487cdc969fefe3d.x56410a8dd70087c5);
		}
		return x56410a8dd70087c6;
	}

	private int x62d5cf18e92f1d20()
	{
		return x2c8c6741422a1298.x80f061859cd048ae.x0efc8c115f3f0df7.xd44988f225497f3a;
	}

	internal int x6af07e13bc41d733()
	{
		return x6af07e13bc41d733(this);
	}

	private int x47dd32fbd2647bf6()
	{
		x454fffaf703e5e86 x454fffaf703e5e = (x454fffaf703e5e86)xd1b40af56a8385d4;
		x91e144d65ff41819 x91e144d65ff41820 = (x91e144d65ff41819)x2c8c6741422a1298.xeafe18c850ae3127[x454fffaf703e5e.x0e99a2a20bc3c647];
		if (x91e144d65ff41820 == null)
		{
			return -1;
		}
		return x6af07e13bc41d733(x91e144d65ff41820);
	}

	private static int x6af07e13bc41d733(x56410a8dd70087c5 x5906905c888d3d98)
	{
		x5906905c888d3d98 = x394025ed30c535a0(x5906905c888d3d98);
		if (x5906905c888d3d98 == null)
		{
			return -1;
		}
		xc7f90d9c7c51cede xbbe2f7d7c86e = x5906905c888d3d98.x776fd7c2f7270172();
		return xb5da8902547ab3e9(xbbe2f7d7c86e);
	}

	internal static int xb5da8902547ab3e9(xc7f90d9c7c51cede xbbe2f7d7c86e0379)
	{
		if (xbbe2f7d7c86e0379 == null || xbbe2f7d7c86e0379.x332a8eedb847940d == null || xbbe2f7d7c86e0379.x53111d6596d16a99 == null)
		{
			return -1;
		}
		xf3f447691ab38eee x0efc8c115f3f0df = xbbe2f7d7c86e0379.x2c8c6741422a1298.x80f061859cd048ae.x0efc8c115f3f0df7;
		x0efc8c115f3f0df.xd8b11076ff837685(xbbe2f7d7c86e0379);
		int xd1bdf42207dd = x0efc8c115f3f0df.xd1bdf42207dd3638;
		int num = 0;
		int num2 = 1;
		for (xf6689e0eed33812c xf6689e0eed33812c2 = xbbe2f7d7c86e0379.x3c1c340351d94fbd; xf6689e0eed33812c2 != null; xf6689e0eed33812c2 = xf6689e0eed33812c2.x488a096134880397)
		{
			if (xf6689e0eed33812c2.xf48cd6e82340ac70.x464e144455d016ba)
			{
				x0efc8c115f3f0df.xd8b11076ff837685(xf6689e0eed33812c2.x86a0dde4c22f516b);
				num = x0efc8c115f3f0df.xd1bdf42207dd3638;
				num2 = xf6689e0eed33812c2.xf48cd6e82340ac70.xea80bd18e8a43904;
				if (xf6689e0eed33812c2.x86a0dde4c22f516b.x7149c962c02931b3)
				{
					num2--;
				}
				break;
			}
		}
		return num2 + xd1bdf42207dd - num;
	}

	private static int x2e72240a1c615b58(x56410a8dd70087c5 x5906905c888d3d98)
	{
		x5906905c888d3d98 = x394025ed30c535a0(x5906905c888d3d98);
		if (x5906905c888d3d98 == null)
		{
			return -1;
		}
		xf6689e0eed33812c x3c1c340351d94fbd = x5906905c888d3d98.x776fd7c2f7270172().x3c1c340351d94fbd;
		int num = ((!x3c1c340351d94fbd.x86a0dde4c22f516b.x7149c962c02931b3) ? 1 : 0);
		xc7f90d9c7c51cede x3d695937fd09df4b = x3c1c340351d94fbd.x86a0dde4c22f516b.x3d695937fd09df4b;
		while (x3d695937fd09df4b != null && x3d695937fd09df4b.x332a8eedb847940d == x3c1c340351d94fbd)
		{
			num++;
			x3d695937fd09df4b = x3d695937fd09df4b.x3d695937fd09df4b;
		}
		return num;
	}

	private static x56410a8dd70087c5 x394025ed30c535a0(x56410a8dd70087c5 x5906905c888d3d98)
	{
		if (x5906905c888d3d98.x00fa20d37841acd0)
		{
			return x5906905c888d3d98;
		}
		xf3f447691ab38eee xf3f447691ab38eee2 = x5906905c888d3d98.x53111d6596d16a99.xb3a79d506b0e2f7f.x8b61531c8ea35b85();
		if (!xf3f447691ab38eee2.xd8b11076ff837685(x5906905c888d3d98))
		{
			throw new InvalidOperationException(string.Intern(x1110bdd110cdcea4._xaacba899487bce8c("hhincjpnmjgojjnohjepjjlpcecamijaliabpihblhobbefc", 585553972)));
		}
		while (xf3f447691ab38eee2.x355eaee82ffc1f46())
		{
			x5906905c888d3d98 = (x56410a8dd70087c5)xf3f447691ab38eee2.x02ebdc12ebf86805;
			if (x5906905c888d3d98.x00fa20d37841acd0)
			{
				return x5906905c888d3d98;
			}
		}
		xf3f447691ab38eee2 = x5906905c888d3d98.x53111d6596d16a99.xb3a79d506b0e2f7f.x8b61531c8ea35b85();
		while (xf3f447691ab38eee2.x47f176deff0d42e2())
		{
			x5906905c888d3d98 = (x56410a8dd70087c5)xf3f447691ab38eee2.x02ebdc12ebf86805;
			if (x5906905c888d3d98.x00fa20d37841acd0)
			{
				return x5906905c888d3d98;
			}
		}
		return null;
	}
}
