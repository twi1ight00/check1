using Aspose.Words;
using Aspose.Words.Tables;
using x28925c9b27b37a46;
using x6c95d9cf46ff5f25;
using x9db5f2e5af3d596e;
using xbe73d5820f7f4ae3;

namespace xa2462df43988ffad;

internal class xd270c0d0dc0624b8
{
	private readonly xdb0bf9f81de4b38c x9b287b671d592594;

	private x26afcd4f02edc862 xbaf2b533fbdd5309;

	internal xd270c0d0dc0624b8(xdb0bf9f81de4b38c writer)
	{
		x9b287b671d592594 = writer;
	}

	internal void x6210059f049f0d48(Cell xe6de5e5fa2d44af5)
	{
		x9c77c7e782b62883 xe1410f585439c7d = x9b287b671d592594.xe1410f585439c7d4;
		xbaf2b533fbdd5309 = new x26afcd4f02edc862();
		x1c342740048f6291(xe6de5e5fa2d44af5, xe6de5e5fa2d44af5.xf8cef531dae89ea3);
		if (xbaf2b533fbdd5309.x5fb16e270c21db2e != null)
		{
			x1c342740048f6291(xe6de5e5fa2d44af5, xbaf2b533fbdd5309.x5fb16e270c21db2e.xdf4bcc85da8f85b2);
		}
		xe1410f585439c7d.x2307058321cdb62f("style:table-cell-properties");
		xe1410f585439c7d.x943f6be3acf634db("fo:background-color", xbaf2b533fbdd5309.x83729c7ebf48ae24);
		xe1410f585439c7d.x943f6be3acf634db("style:vertical-align", xbaf2b533fbdd5309.xd17687d6bc61356f);
		xbaf2b533fbdd5309.x950295903e1e85d3.x6210059f049f0d48(xe1410f585439c7d);
		if (!x9b287b671d592594.xf57de0fd37d5e97d.IsStrictSchema11)
		{
			xe1410f585439c7d.x943f6be3acf634db("style:writing-mode", xbaf2b533fbdd5309.x28e5011224ac892b);
		}
		object obj = xe6de5e5fa2d44af5.xf8cef531dae89ea3.xf7866f89640a29a3(3180);
		if (obj != null)
		{
			xe1410f585439c7d.x943f6be3acf634db("fo:wrap-option", ((bool)obj) ? "wrap" : "no-wrap");
		}
		xe1410f585439c7d.x2dfde153f4ef96d0("style:table-cell-properties");
	}

	private void x1c342740048f6291(Cell xe6de5e5fa2d44af5, x7f77ea92be0d9042 x51dd02ffcbaa972d)
	{
		CellVerticalAlignment xdc46a7254c7770ad = CellVerticalAlignment.Bottom;
		TextOrientation xd1c56470d96cb24c = TextOrientation.Horizontal;
		bool xfefe3f874ca61d1e = false;
		for (int i = 0; i < x51dd02ffcbaa972d.xd44988f225497f3a; i++)
		{
			int num = x51dd02ffcbaa972d.xf15263674eb297bb(i);
			object obj = x51dd02ffcbaa972d.x6d3720b962bd3112(i);
			if (obj == null)
			{
				continue;
			}
			xbaf2b533fbdd5309.xd44988f225497f3a++;
			switch (num)
			{
			case 3170:
				xbaf2b533fbdd5309.x83729c7ebf48ae24 = xbb857c9fc36f5054.x0ad4dcbc0b50ce41((Shading)obj);
				break;
			case 3060:
				xfefe3f874ca61d1e = true;
				xdc46a7254c7770ad = (CellVerticalAlignment)obj;
				break;
			case 3110:
				xbaf2b533fbdd5309.x950295903e1e85d3.xa8c2637cc4888928.x03cb705fbd5700a4 = (Border)obj;
				break;
			case 3130:
				xbaf2b533fbdd5309.x950295903e1e85d3.x79d902473861f242.x03cb705fbd5700a4 = (Border)obj;
				break;
			case 3120:
				xbaf2b533fbdd5309.x950295903e1e85d3.xaea087ab32102492.x03cb705fbd5700a4 = (Border)obj;
				break;
			case 3140:
				xbaf2b533fbdd5309.x950295903e1e85d3.xd7a21e27974f626c.x03cb705fbd5700a4 = (Border)obj;
				break;
			case 3050:
				xd1c56470d96cb24c = (TextOrientation)obj;
				xbaf2b533fbdd5309.x28e5011224ac892b = x0eb9a864413f34de.x8544250546ff6f3b((TextOrientation)obj);
				if (xbaf2b533fbdd5309.x28e5011224ac892b == null)
				{
					xbaf2b533fbdd5309.xd44988f225497f3a--;
				}
				break;
			case 10010:
				xbaf2b533fbdd5309.x5fb16e270c21db2e = (x5fb16e270c21db2e)obj;
				break;
			default:
				xbaf2b533fbdd5309.xd44988f225497f3a--;
				break;
			}
		}
		x73ee972fc7b7da94(xe6de5e5fa2d44af5, xdc46a7254c7770ad, xd1c56470d96cb24c, xfefe3f874ca61d1e);
		x2cf1761602871e10(xe6de5e5fa2d44af5);
		x733e5d4eb058c18d(xe6de5e5fa2d44af5, (xf8cef531dae89ea3)x51dd02ffcbaa972d);
	}

	private void x73ee972fc7b7da94(Cell xe6de5e5fa2d44af5, CellVerticalAlignment xdc46a7254c7770ad, TextOrientation xd1c56470d96cb24c, bool xfefe3f874ca61d1e)
	{
		xbaf2b533fbdd5309.xd17687d6bc61356f = x0eb9a864413f34de.x3d92bf97cfbf258c(xdc46a7254c7770ad, xd1c56470d96cb24c, xe6de5e5fa2d44af5.FirstParagraph.ParagraphFormat.Alignment, xfefe3f874ca61d1e);
		if (!x0d299f323d241756.x5959bccb67bbf051(xbaf2b533fbdd5309.xd17687d6bc61356f) && xfefe3f874ca61d1e)
		{
			xbaf2b533fbdd5309.xd44988f225497f3a--;
		}
		if (x0d299f323d241756.x5959bccb67bbf051(xbaf2b533fbdd5309.xd17687d6bc61356f) && !xfefe3f874ca61d1e)
		{
			xbaf2b533fbdd5309.xd44988f225497f3a++;
		}
	}

	private void x733e5d4eb058c18d(Cell xe6de5e5fa2d44af5, xf8cef531dae89ea3 x51dd02ffcbaa972d)
	{
		xedb0eb766e25e0c9 xedb0eb766e25e0c = xe6de5e5fa2d44af5.ParentRow.xedb0eb766e25e0c9;
		int num = (x51dd02ffcbaa972d.xbc5dc59d0d9b620d(3070) ? x51dd02ffcbaa972d.xdf2361611d684889 : xedb0eb766e25e0c.xdf2361611d684889);
		int num2 = (x51dd02ffcbaa972d.xbc5dc59d0d9b620d(3080) ? x51dd02ffcbaa972d.x425c70a737882333 : xedb0eb766e25e0c.x425c70a737882333);
		int num3 = (x51dd02ffcbaa972d.xbc5dc59d0d9b620d(3090) ? x51dd02ffcbaa972d.xcad2e59522947ede : xedb0eb766e25e0c.xcad2e59522947ede);
		int num4 = (x51dd02ffcbaa972d.xbc5dc59d0d9b620d(3100) ? x51dd02ffcbaa972d.x41c99cca24bc80be : xedb0eb766e25e0c.x41c99cca24bc80be);
		if (x51dd02ffcbaa972d.xdc1bf80853046136 <= num3 + num4)
		{
			num3 = (num4 = 0);
		}
		if (num != 0)
		{
			xbaf2b533fbdd5309.x950295903e1e85d3.xa8c2637cc4888928.x3dcd010ed1e386de = xbb857c9fc36f5054.xf7c347cb12d2a63f(num);
		}
		if (num2 != 0)
		{
			xbaf2b533fbdd5309.x950295903e1e85d3.x79d902473861f242.x3dcd010ed1e386de = xbb857c9fc36f5054.xf7c347cb12d2a63f(num2);
		}
		if (num3 != 0)
		{
			xbaf2b533fbdd5309.x950295903e1e85d3.xaea087ab32102492.x3dcd010ed1e386de = xbb857c9fc36f5054.xf7c347cb12d2a63f(num3);
		}
		if (num4 != 0)
		{
			xbaf2b533fbdd5309.x950295903e1e85d3.xd7a21e27974f626c.x3dcd010ed1e386de = xbb857c9fc36f5054.xf7c347cb12d2a63f(num4);
		}
	}

	private void x2cf1761602871e10(Cell xe6de5e5fa2d44af5)
	{
		xedb0eb766e25e0c9 xedb0eb766e25e0c = xe6de5e5fa2d44af5.ParentRow.xedb0eb766e25e0c9;
		if (xbaf2b533fbdd5309.x950295903e1e85d3.xa8c2637cc4888928.x03cb705fbd5700a4 == null && !xe6de5e5fa2d44af5.ParentRow.IsFirstRow)
		{
			xbaf2b533fbdd5309.x950295903e1e85d3.xa8c2637cc4888928.x03cb705fbd5700a4 = xedb0eb766e25e0c.x8ef7f9589a0a0945;
		}
		if (xbaf2b533fbdd5309.x950295903e1e85d3.x79d902473861f242.x03cb705fbd5700a4 == null && !xe6de5e5fa2d44af5.ParentRow.IsLastRow)
		{
			xbaf2b533fbdd5309.x950295903e1e85d3.x79d902473861f242.x03cb705fbd5700a4 = xedb0eb766e25e0c.x8ef7f9589a0a0945;
		}
		if (xbaf2b533fbdd5309.x950295903e1e85d3.xaea087ab32102492.x03cb705fbd5700a4 == null && !xe6de5e5fa2d44af5.IsFirstCell)
		{
			xbaf2b533fbdd5309.x950295903e1e85d3.xaea087ab32102492.x03cb705fbd5700a4 = xedb0eb766e25e0c.xbccf8ac0eed2b937;
		}
		if (xbaf2b533fbdd5309.x950295903e1e85d3.xd7a21e27974f626c.x03cb705fbd5700a4 == null && !xe6de5e5fa2d44af5.IsLastCell)
		{
			xbaf2b533fbdd5309.x950295903e1e85d3.xd7a21e27974f626c.x03cb705fbd5700a4 = xedb0eb766e25e0c.xbccf8ac0eed2b937;
		}
		xedb0eb766e25e0c = xe6de5e5fa2d44af5.x133f2db9e5b5690d.FirstRow.xedb0eb766e25e0c9;
		if (xbaf2b533fbdd5309.x950295903e1e85d3.xa8c2637cc4888928.x03cb705fbd5700a4 == null && xe6de5e5fa2d44af5.ParentRow.IsFirstRow)
		{
			xbaf2b533fbdd5309.x950295903e1e85d3.xa8c2637cc4888928.x03cb705fbd5700a4 = xedb0eb766e25e0c.xa8c2637cc4888928;
		}
		if (xbaf2b533fbdd5309.x950295903e1e85d3.x79d902473861f242.x03cb705fbd5700a4 == null && xe6de5e5fa2d44af5.ParentRow.IsLastRow)
		{
			xbaf2b533fbdd5309.x950295903e1e85d3.x79d902473861f242.x03cb705fbd5700a4 = xedb0eb766e25e0c.x79d902473861f242;
		}
		if (xbaf2b533fbdd5309.x950295903e1e85d3.xaea087ab32102492.x03cb705fbd5700a4 == null && xe6de5e5fa2d44af5.IsFirstCell)
		{
			xbaf2b533fbdd5309.x950295903e1e85d3.xaea087ab32102492.x03cb705fbd5700a4 = xedb0eb766e25e0c.xaea087ab32102492;
		}
		if (xbaf2b533fbdd5309.x950295903e1e85d3.xd7a21e27974f626c.x03cb705fbd5700a4 == null && xe6de5e5fa2d44af5.IsLastCell)
		{
			xbaf2b533fbdd5309.x950295903e1e85d3.xd7a21e27974f626c.x03cb705fbd5700a4 = xedb0eb766e25e0c.xd7a21e27974f626c;
		}
		xbaf2b533fbdd5309.x950295903e1e85d3.x5f92400e1485c05c(x2b818897b65c872e: true, xa6651a0a6d059494: false);
	}
}
