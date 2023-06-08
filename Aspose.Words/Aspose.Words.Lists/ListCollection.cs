using System;
using System.Collections;
using Aspose.Words.Drawing;
using x13f1efc79617a47b;
using x28925c9b27b37a46;
using xd2754ae26d400653;

namespace Aspose.Words.Lists;

[JavaGenericArguments("Iterable<List>")]
public class ListCollection : IEnumerable
{
	private DocumentBase xd1424e1a0bb4a72b;

	private ArrayList xbc2e79ef0cee7243 = new ArrayList();

	private ArrayList xc8785f5b0275cdec = new ArrayList();

	private ArrayList xc21e1897857febf6 = new ArrayList();

	private Hashtable x04583e0139b0e8ad = new Hashtable();

	public int Count => xbc2e79ef0cee7243.Count;

	public List this[int index] => (List)xbc2e79ef0cee7243[index];

	public DocumentBase Document => xd1424e1a0bb4a72b;

	internal int xddf1da3d36406847 => xc8785f5b0275cdec.Count;

	internal int xe10f375b4290d48f => xc21e1897857febf6.Count;

	internal Hashtable xb17de0643f715f73 => x04583e0139b0e8ad;

	internal ArrayList xc40f91140312b303 => xc8785f5b0275cdec;

	internal ListCollection(DocumentBase document)
	{
		xd1424e1a0bb4a72b = document;
	}

	public IEnumerator GetEnumerator()
	{
		return xbc2e79ef0cee7243.GetEnumerator();
	}

	public List Add(ListTemplate template)
	{
		return x67af7bcbfd57c02b.x28d01548f153fdbe(this, template);
	}

	public List Add(Style listStyle)
	{
		if (listStyle == null)
		{
			throw new ArgumentNullException("listStyle");
		}
		if (listStyle.Document != Document)
		{
			throw new ArgumentException(string.Intern(x1110bdd110cdcea4._xaacba899487bce8c("kacjlbjjfbaknmgkgbokabflhbmlfbdmoljmoabnmainoapnopfoepmomkdplokplobapoiapopalogbbonbkoecejlcfocdnnjdliaejmhefioegmffimmfcmdgplkgllbhfmihflphllgiolnihgejikljalckbkjkalalfkhlkjolakfmdkmmkfdn", 2057867702)));
		}
		if (listStyle.Type != StyleType.List)
		{
			throw new ArgumentException(string.Intern(x1110bdd110cdcea4._xaacba899487bce8c("bgmmchdnmgknecboehiochpoehgpegnpkfeacblaifcbpfjbjaacefhccfoceffdnpldlddehpjeaebfkdifbepfpdggiomgidehgdlhidciicjiobajeogj", 1931856909)));
		}
		List list = AddCopy(listStyle.List);
		list.x178ff6dcbf808c38.xc657ea789af2c1f0 = listStyle.x8301ab10c226b0c2;
		return list;
	}

	public List AddCopy(List srcList)
	{
		return x25de37482b6805d5(srcList, xc9d49f938b96bdd0: true);
	}

	internal List x25de37482b6805d5(List x3fbc82dc0259cd6d, bool xc9d49f938b96bdd0)
	{
		if (x3fbc82dc0259cd6d == null)
		{
			throw new ArgumentNullException("srcList");
		}
		List list;
		if (Document == x3fbc82dc0259cd6d.Document || !xc9d49f938b96bdd0)
		{
			list = x3fbc82dc0259cd6d.x8b61531c8ea35b85(xd1424e1a0bb4a72b, x4aa2513168649906());
			xa22e280934fc3004(list);
			x178ff6dcbf808c38 x178ff6dcbf808c = x3fbc82dc0259cd6d.x178ff6dcbf808c38.x8b61531c8ea35b85(Document, x1ba01075584e1248());
			x3698cb58c2e87a72(x178ff6dcbf808c);
			list.x1eac770549050632 = x178ff6dcbf808c.x1eac770549050632;
		}
		else
		{
			x7f4fa84f489f40ab x0f7b23d1c393aed = new x7f4fa84f489f40ab(x3fbc82dc0259cd6d.Document, Document, ImportFormatMode.UseDestinationStyles);
			list = x6c3daa8c787e54bf(x26885624294ecfb1(x0f7b23d1c393aed, x3fbc82dc0259cd6d.ListId, x8130ea6198b92c37: false));
		}
		list.x178ff6dcbf808c38.xc657ea789af2c1f0 = 4095;
		return list;
	}

	public List GetListByListId(int listId)
	{
		object obj = x04583e0139b0e8ad[listId];
		if (obj == null)
		{
			return null;
		}
		int num = (int)obj - 1;
		if (num < 0 || num >= Count)
		{
			return null;
		}
		return this[num];
	}

	internal List x6c3daa8c787e54bf(int x43eb71c4e55e38d0)
	{
		if (Count == 0)
		{
			xcf5f82306ceb0bff(x902c8ac86fbaf048.x598f41525926b38a);
		}
		object obj = x04583e0139b0e8ad[x43eb71c4e55e38d0];
		int num = ((obj == null) ? (x43eb71c4e55e38d0 - 1) : ((int)obj - 1));
		if (num < 0)
		{
			num = 0;
		}
		else if (num >= Count)
		{
			num = Count - 1;
		}
		return this[num];
	}

	internal List xceb66bfa0e6b60c7(int x43eb71c4e55e38d0)
	{
		List list = x6c3daa8c787e54bf(x43eb71c4e55e38d0);
		if (list.IsListStyleReference)
		{
			return list.Style.List;
		}
		return list;
	}

	internal List xcf5f82306ceb0bff(x902c8ac86fbaf048 xd275fdd8cec9b85e)
	{
		x178ff6dcbf808c38 x178ff6dcbf808c = x5fb5108f21941f75(xd275fdd8cec9b85e, x1ba01075584e1248());
		List list = new List(xd1424e1a0bb4a72b, x4aa2513168649906());
		list.x1eac770549050632 = x178ff6dcbf808c.x1eac770549050632;
		xa22e280934fc3004(list);
		return list;
	}

	private x178ff6dcbf808c38 x5fb5108f21941f75(x902c8ac86fbaf048 xd275fdd8cec9b85e, int x6b9cdc3a87f7e946)
	{
		x178ff6dcbf808c38 x178ff6dcbf808c = new x178ff6dcbf808c38(xd1424e1a0bb4a72b, x6b9cdc3a87f7e946, xd275fdd8cec9b85e, x6b9cdc3a87f7e946);
		x3698cb58c2e87a72(x178ff6dcbf808c);
		return x178ff6dcbf808c;
	}

	internal void xa22e280934fc3004(List x8a0b266419f09a55)
	{
		if (x04583e0139b0e8ad[x8a0b266419f09a55.ListId] == null)
		{
			xbc2e79ef0cee7243.Add(x8a0b266419f09a55);
			x04583e0139b0e8ad.Add(x8a0b266419f09a55.ListId, xbc2e79ef0cee7243.Count);
		}
	}

	internal void x3698cb58c2e87a72(x178ff6dcbf808c38 x02c001fe9bc75871)
	{
		xc8785f5b0275cdec.Add(x02c001fe9bc75871);
	}

	internal x178ff6dcbf808c38 x3bfa6064d69ac0da(int xc0c4c459c6ccbd00)
	{
		return (x178ff6dcbf808c38)xc8785f5b0275cdec[xc0c4c459c6ccbd00];
	}

	internal x178ff6dcbf808c38 x44c0fd1f259e7914(int x6b9cdc3a87f7e946)
	{
		int num = x19a9fba0f6b6b791(x6b9cdc3a87f7e946);
		if (num >= 0)
		{
			return x3bfa6064d69ac0da(num);
		}
		if (xddf1da3d36406847 > 0)
		{
			return x3bfa6064d69ac0da(0);
		}
		return x5fb5108f21941f75(x902c8ac86fbaf048.x598f41525926b38a, x6b9cdc3a87f7e946);
	}

	internal int x19a9fba0f6b6b791(int x6b9cdc3a87f7e946)
	{
		for (int i = 0; i < xddf1da3d36406847; i++)
		{
			if (x3bfa6064d69ac0da(i).x1eac770549050632 == x6b9cdc3a87f7e946)
			{
				return i;
			}
		}
		return -1;
	}

	internal ListCollection x8b61531c8ea35b85(DocumentBase x1f83c4681a4a3676, x15a33f6d96885286 x5ebbc4e56d2a7304)
	{
		ListCollection listCollection = (ListCollection)MemberwiseClone();
		listCollection.xd1424e1a0bb4a72b = x1f83c4681a4a3676;
		listCollection.x04583e0139b0e8ad = new Hashtable();
		listCollection.xbc2e79ef0cee7243 = new ArrayList();
		foreach (List item in xbc2e79ef0cee7243)
		{
			listCollection.xa22e280934fc3004(item.x8b61531c8ea35b85(x1f83c4681a4a3676, item.ListId));
		}
		listCollection.xc8785f5b0275cdec = new ArrayList();
		foreach (x178ff6dcbf808c38 item2 in xc8785f5b0275cdec)
		{
			listCollection.x3698cb58c2e87a72(item2.x8b61531c8ea35b85(x1f83c4681a4a3676, item2.x1eac770549050632));
		}
		listCollection.xc21e1897857febf6 = new ArrayList();
		foreach (Shape item3 in xc21e1897857febf6)
		{
			Shape shape2 = (Shape)item3.x8b61531c8ea35b85(x7a5f12b98e34a590: true, x5ebbc4e56d2a7304);
			shape2.x3e229cd2762a6ef5(x1f83c4681a4a3676);
			listCollection.x2c0e9f8fa1946281(shape2);
		}
		return listCollection;
	}

	internal int x26885624294ecfb1(x7f4fa84f489f40ab x0f7b23d1c393aed9, int x891ca1329bdef0b6)
	{
		return x26885624294ecfb1(x0f7b23d1c393aed9, x891ca1329bdef0b6, x8130ea6198b92c37: true);
	}

	private int x26885624294ecfb1(x7f4fa84f489f40ab x0f7b23d1c393aed9, int x891ca1329bdef0b6, bool x8130ea6198b92c37)
	{
		if (x0f7b23d1c393aed9.x9e7440ceb43888e8.Contains(x891ca1329bdef0b6))
		{
			return (int)x0f7b23d1c393aed9.x9e7440ceb43888e8[x891ca1329bdef0b6];
		}
		List listByListId = x0f7b23d1c393aed9.x1eb90a4f688f59d7.GetListByListId(x891ca1329bdef0b6);
		if (listByListId == null)
		{
			return 0;
		}
		List list = listByListId.x8b61531c8ea35b85(xd1424e1a0bb4a72b, x4aa2513168649906());
		xa22e280934fc3004(list);
		x0f7b23d1c393aed9.x9e7440ceb43888e8.Add(x891ca1329bdef0b6, list.ListId);
		if (x0f7b23d1c393aed9.x37b2909ab4f64a0f.Contains(listByListId.x1eac770549050632))
		{
			list.x1eac770549050632 = (int)x0f7b23d1c393aed9.x37b2909ab4f64a0f[listByListId.x1eac770549050632];
		}
		else
		{
			x178ff6dcbf808c38 x178ff6dcbf808c = listByListId.x178ff6dcbf808c38.x8b61531c8ea35b85(xd1424e1a0bb4a72b, x1ba01075584e1248());
			x3698cb58c2e87a72(x178ff6dcbf808c);
			list.x1eac770549050632 = x178ff6dcbf808c.x1eac770549050632;
			x0f7b23d1c393aed9.x37b2909ab4f64a0f.Add(listByListId.x1eac770549050632, list.x1eac770549050632);
			if (x8130ea6198b92c37 && listByListId.Style != null)
			{
				Style style = x0f7b23d1c393aed9.x7ad0923dc651ebad.x81f78ebaaa78ed06(x0f7b23d1c393aed9, listByListId.Style);
				x178ff6dcbf808c.xc657ea789af2c1f0 = style.x8301ab10c226b0c2;
			}
			ListLevelCollection x438a2a8db4b2d07b = listByListId.x178ff6dcbf808c38.x438a2a8db4b2d07b;
			ListLevelCollection x438a2a8db4b2d07b2 = list.x178ff6dcbf808c38.x438a2a8db4b2d07b;
			for (int i = 0; i < x438a2a8db4b2d07b.Count; i++)
			{
				ListLevel x7a1543a9baf95bc = x438a2a8db4b2d07b[i];
				ListLevel x8bb050957554a36c = x438a2a8db4b2d07b2[i];
				x8da485b17b837d43(x0f7b23d1c393aed9, x7a1543a9baf95bc, x8bb050957554a36c);
				xbe91fc1e78c522d6(x0f7b23d1c393aed9, x7a1543a9baf95bc, x8bb050957554a36c);
			}
		}
		return list.ListId;
	}

	private static void x8da485b17b837d43(x7f4fa84f489f40ab x0f7b23d1c393aed9, ListLevel x7a1543a9baf95bc5, ListLevel x8bb050957554a36c)
	{
		Style linkedStyle = x7a1543a9baf95bc5.LinkedStyle;
		if (linkedStyle != null)
		{
			Style linkedStyle2 = ((linkedStyle.Type != StyleType.Paragraph) ? null : x0f7b23d1c393aed9.x5bb80c9bb5e94e7e.Styles.x81f78ebaaa78ed06(x0f7b23d1c393aed9, linkedStyle));
			x8bb050957554a36c.LinkedStyle = linkedStyle2;
		}
	}

	private static void xbe91fc1e78c522d6(x7f4fa84f489f40ab x0f7b23d1c393aed9, ListLevel x7a1543a9baf95bc5, ListLevel x8bb050957554a36c)
	{
		if (x7a1543a9baf95bc5.x44b52529222cea8a)
		{
			if (x0f7b23d1c393aed9.x68ac644d7e5c5da6.Contains(x7a1543a9baf95bc5.x4d819daa8b29e86b))
			{
				x8bb050957554a36c.x4d819daa8b29e86b = (int)x0f7b23d1c393aed9.x68ac644d7e5c5da6[x7a1543a9baf95bc5.x4d819daa8b29e86b];
				return;
			}
			Shape xc9c754014952f = x7a1543a9baf95bc5.xc9c754014952f758;
			Shape x5770cdefd8931aa = (Shape)x0f7b23d1c393aed9.x5bb80c9bb5e94e7e.ImportNode(xc9c754014952f, isImportChildren: true);
			x8bb050957554a36c.x4d819daa8b29e86b = x0f7b23d1c393aed9.xfb9dbcd4f0daf938.x2c0e9f8fa1946281(x5770cdefd8931aa);
			x0f7b23d1c393aed9.x68ac644d7e5c5da6.Add(x7a1543a9baf95bc5.x4d819daa8b29e86b, x8bb050957554a36c.x4d819daa8b29e86b);
		}
	}

	private int x1ba01075584e1248()
	{
		int num = ((xddf1da3d36406847 > 0) ? x3bfa6064d69ac0da(xddf1da3d36406847 - 1).x1eac770549050632 : 0);
		int num2 = num + 1;
		if (num2 == -1)
		{
			num2++;
		}
		return num2;
	}

	private int x4aa2513168649906()
	{
		return Count + 1;
	}

	internal int x2c0e9f8fa1946281(Shape x5770cdefd8931aa9)
	{
		if (x5770cdefd8931aa9 == null)
		{
			throw new ArgumentNullException("shape");
		}
		if (x5770cdefd8931aa9.ParentNode != null)
		{
			throw new ArgumentException(string.Intern(x1110bdd110cdcea4._xaacba899487bce8c("nhgloinliiemaelmnicndijnkhaoiihogiooaifpahmpicdahgkahhbblgibigpbofgckgncdbeddgldffcelejehfafjehfbaoflefgafmgledhjekhcpaihdiincpipdgjlcnjdodkoclkmcclknilhcamfbhmdcomdbfnjbmnmbdofmjoabbpoaipaappopfaemma", 1347008041)));
		}
		if (x5770cdefd8931aa9.Document != xd1424e1a0bb4a72b)
		{
			throw new ArgumentException(string.Intern(x1110bdd110cdcea4._xaacba899487bce8c("icfgjdmgdddhlojhidbiociifcpiddgjbdnjlceklblkdnblcbjlccamgbhmdbomjafnfbmnolcooakoaabpgphpcappepfamkmagpdblpkbgpbcepicnjpcmngdmnndaoeeaolemncfcnjfiiagjnhgbnogphfhanmhbmdiplkigmbjahijblpjjlgkkknkjleloklldkcmjkjmmkandghn", 652895444)));
		}
		x5770cdefd8931aa9.xd06a0f106e67d743 = true;
		return xc21e1897857febf6.Add(x5770cdefd8931aa9);
	}

	internal Shape x4916e8670feefe58(int xc0c4c459c6ccbd00)
	{
		return (Shape)xc21e1897857febf6[xc0c4c459c6ccbd00];
	}
}
