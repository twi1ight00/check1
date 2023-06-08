using System;
using System.Collections;
using System.ComponentModel;
using System.Text;
using System.Xml.XPath;
using Aspose.Words.Markup;
using x13f1efc79617a47b;
using x28925c9b27b37a46;

namespace Aspose.Words;

[JavaGenericParameter("T extends Node")]
[JavaGenericArguments("Iterable<T>")]
public abstract class CompositeNode : Node, IEnumerable, IXPathNavigable
{
	private Node x9f67a1a3199d9184;

	public override bool IsComposite => true;

	public bool HasChildNodes => LastChild != null;

	internal bool x73db39780c76cb8d => xfe93db1ba6e25886 != null;

	internal bool xefd689c2d1a39911
	{
		get
		{
			if (HasChildNodes)
			{
				return FirstChild == LastChild;
			}
			return false;
		}
	}

	internal bool x843b0ab4e04a29f2
	{
		get
		{
			for (Node node = FirstChild; node != null; node = node.NextSibling)
			{
				if (node is xcf3b0f04424de818)
				{
					return true;
				}
			}
			return false;
		}
	}

	public NodeCollection ChildNodes => GetChildNodes(NodeType.Any, isDeep: false);

	public Node FirstChild
	{
		get
		{
			if (LastChild == null)
			{
				return null;
			}
			return LastChild.xf523c8cf086433fd;
		}
	}

	public Node LastChild => x9f67a1a3199d9184;

	internal Node xfe93db1ba6e25886 => x2b1ee3a87b36a988.xd5642c127a31bf8a(FirstChild);

	internal Node xc0f45b01af564b77 => x2b1ee3a87b36a988.x006ee30bbb04e012(LastChild);

	public int Count
	{
		get
		{
			int num = 0;
			for (Node node = FirstChild; node != null; node = node.NextSibling)
			{
				num++;
			}
			return num;
		}
	}

	protected CompositeNode()
	{
	}

	protected CompositeNode(DocumentBase doc)
		: base(doc)
	{
	}

	protected void x24c3f69f192a9d2b()
	{
		if (base.ParentNode == null)
		{
			throw new InvalidOperationException("This node is not attached to any document");
		}
		while (HasChildNodes)
		{
			base.ParentNode.InsertAfter(LastChild, this);
		}
		Remove();
	}

	internal override Node x8b61531c8ea35b85(bool x7a5f12b98e34a590, x15a33f6d96885286 xe870d6f33992ceb4)
	{
		CompositeNode compositeNode = (CompositeNode)base.x8b61531c8ea35b85(x7a5f12b98e34a590, xe870d6f33992ceb4);
		compositeNode.x9f67a1a3199d9184 = null;
		if (x7a5f12b98e34a590)
		{
			for (Node node = FirstChild; node != null; node = node.NextSibling)
			{
				compositeNode.xdf7453d9fdf3f262(node.x8b61531c8ea35b85(x7a5f12b98e34a590: true, xe870d6f33992ceb4));
			}
		}
		return compositeNode;
	}

	public override string GetText()
	{
		StringBuilder stringBuilder = xb8e292d45f876c2d();
		stringBuilder.Append(x0598f184f69953c1());
		return stringBuilder.ToString();
	}

	public NodeCollection GetChildNodes(NodeType nodeType, bool isDeep)
	{
		return new NodeCollection(this, nodeType, isDeep);
	}

	[Obsolete("Use GetChildNodes(NodeType, bool).")]
	public NodeCollection GetChildNodes(NodeType nodeType, bool isDeep, bool isLive)
	{
		return new NodeCollection(this, nodeType, isDeep);
	}

	public Node GetChild(NodeType nodeType, int index, bool isDeep)
	{
		if (index >= 0 && !isDeep)
		{
			int num = index + 1;
			bool flag = x2b1ee3a87b36a988.xd601422bf435ea8c(nodeType);
			for (Node node = (flag ? xfe93db1ba6e25886 : FirstChild); node != null; node = (flag ? node.xa6890a1cb2b8896e : node.NextSibling))
			{
				if (node.NodeType == nodeType || nodeType == NodeType.Any)
				{
					num--;
				}
				if (num == 0)
				{
					return node;
				}
			}
			return null;
		}
		NodeCollection childNodes = GetChildNodes(nodeType, isDeep);
		return childNodes[index];
	}

	public NodeList SelectNodes(string xpath)
	{
		return x030154038d5d0afb.x478a82deb55cde7c(this, xpath);
	}

	public Node SelectSingleNode(string xpath)
	{
		return x030154038d5d0afb.x97bb330a631993a5(this, xpath);
	}

	[JavaGenericArguments("Iterator<T>", "ChildNodeEnumerator<T>")]
	public IEnumerator GetEnumerator()
	{
		return new x75a996f7f9d00390(this);
	}

	public Node AppendChild(Node newChild)
	{
		return InsertAfter(newChild, LastChild);
	}

	public Node PrependChild(Node newChild)
	{
		return InsertBefore(newChild, FirstChild);
	}

	public Node InsertAfter(Node newChild, Node refChild)
	{
		return xef23aa45e7612fdd(newChild, refChild, x7f43f79506f73a73: true);
	}

	public Node InsertBefore(Node newChild, Node refChild)
	{
		return xef23aa45e7612fdd(newChild, refChild, x7f43f79506f73a73: false);
	}

	public Node RemoveChild(Node oldChild)
	{
		if (oldChild == null)
		{
			throw new ArgumentNullException("oldChild");
		}
		if (oldChild.ParentNode != this)
		{
			throw new ArgumentException(string.Intern(x1110bdd110cdcea4._xaacba899487bce8c("dgmdehdechkejhbfdcifogpfmgggofngmfeheblhkfcibgjilaajgfhjefojgffkpplknddljpjlgebmedimcepmcdgnidnnldeoeokoadcpecjplnppmchanboahbfbpmlblbdcfbkckabdgohdiapdgageganelpdfelkfppbgnpigpopgnoghdlnh", 303250447)));
		}
		DocumentBase document = base.Document;
		NodeChangingArgs nodeChangingArgs = document.xaa5995fb46863e53(oldChild, this, null, NodeChangingAction.Remove);
		if (nodeChangingArgs != null)
		{
			document.x9d5c03f243a200e9(nodeChangingArgs);
		}
		if (oldChild == FirstChild)
		{
			if (LastChild.xf523c8cf086433fd == LastChild)
			{
				x9f67a1a3199d9184 = null;
			}
			else
			{
				Node node = oldChild.xf523c8cf086433fd;
				LastChild.xf523c8cf086433fd = node;
				node.xe59ebb6cc4eed968 = LastChild;
			}
		}
		else
		{
			Node node2 = oldChild.xe59ebb6cc4eed968;
			Node node4 = (node2.xf523c8cf086433fd = oldChild.xf523c8cf086433fd);
			node4.xe59ebb6cc4eed968 = node2;
			if (oldChild == LastChild)
			{
				x9f67a1a3199d9184 = node2;
			}
		}
		oldChild.xf523c8cf086433fd = null;
		oldChild.xe59ebb6cc4eed968 = null;
		oldChild.xb2b69aae23a4ae6d(null);
		if (nodeChangingArgs != null)
		{
			document.xea94cc1c9383f0e6(nodeChangingArgs);
		}
		return oldChild;
	}

	public void RemoveAllChildren()
	{
		x5699f8523a546a42.x7088fd15062d931f(FirstChild, null);
	}

	public void RemoveSmartTags()
	{
		foreach (SmartTag childNode in GetChildNodes(NodeType.SmartTag, isDeep: true))
		{
			childNode.x24c3f69f192a9d2b();
		}
	}

	internal Node xdf7453d9fdf3f262(Node x40e458b3a58f5782)
	{
		if (LastChild == null)
		{
			x40e458b3a58f5782.xe59ebb6cc4eed968 = x40e458b3a58f5782;
			x40e458b3a58f5782.xf523c8cf086433fd = x40e458b3a58f5782;
		}
		else
		{
			Node node = LastChild.xf523c8cf086433fd;
			x40e458b3a58f5782.xe59ebb6cc4eed968 = LastChild;
			x40e458b3a58f5782.xf523c8cf086433fd = node;
			node.xe59ebb6cc4eed968 = x40e458b3a58f5782;
			LastChild.xf523c8cf086433fd = x40e458b3a58f5782;
		}
		x9f67a1a3199d9184 = x40e458b3a58f5782;
		x40e458b3a58f5782.xb2b69aae23a4ae6d(this);
		return x40e458b3a58f5782;
	}

	internal void xefe78abe23c23f7a(Node x10aaa7cdfa38f254, Node xca09b6c2b5b18485, Node x22bff10c3dd1f70f)
	{
		if (xca09b6c2b5b18485 != null && xca09b6c2b5b18485.ParentNode != x10aaa7cdfa38f254.ParentNode)
		{
			throw new ArgumentException(string.Intern(x1110bdd110cdcea4._xaacba899487bce8c("bodbcpkbmobcekiceppccpgdmnndkoeejolecjcfanjfknagnmhggiogimfhommhbmdikhkifmbjdmijflpjdlgkolnkigelilllkkcmokjmblanfkhnkjondffoijmooidpakkpmibaeeiafjpagigbainbideciilcdhcdmhjdbhaejcheghoeegffchmfcgdgigkglgbhccih", 1918309261)));
		}
		Node node = x10aaa7cdfa38f254;
		while (node != xca09b6c2b5b18485)
		{
			Node nextSibling = node.NextSibling;
			InsertBefore(node, x22bff10c3dd1f70f);
			node = nextSibling;
		}
	}

	internal void x2729186e1a0b4aeb(Node x10aaa7cdfa38f254, Node xca09b6c2b5b18485, Node x22bff10c3dd1f70f)
	{
		if (xca09b6c2b5b18485 != null && xca09b6c2b5b18485.ParentNode != x10aaa7cdfa38f254.ParentNode)
		{
			throw new ArgumentException(string.Intern(x1110bdd110cdcea4._xaacba899487bce8c("njhlokolikfmagmmaldnokknijbogkiofkpooegpminpgjeajilacecbeijbkiacnhhcgdocbifdphmdbhdepgkekhbfecifehpfggggkgngngehbglhgfcipajiefajkehjmfojiefkaamkbfdlceklmdbmephmeepmpcgnidnnnceofokocdcpacjpocaaobhaecoahcfbonlb", 1089517385)));
		}
		Node node = x10aaa7cdfa38f254;
		while (node != xca09b6c2b5b18485)
		{
			Node nextSibling = node.NextSibling;
			x22bff10c3dd1f70f = InsertAfter(node, x22bff10c3dd1f70f);
			node = nextSibling;
		}
	}

	public int IndexOf(Node child)
	{
		int num = 0;
		for (Node node = FirstChild; node != null; node = node.NextSibling)
		{
			if (node == child)
			{
				return num;
			}
			num++;
		}
		return -1;
	}

	internal override Node x42ef18de02ad5182(int x13d4cb8d1bd20347)
	{
		int num = 0;
		int num2 = IndexOf(LastChild);
		while (num <= num2)
		{
			int num3 = num + num2 >> 1;
			Node child = GetChild(NodeType.Any, num3, isDeep: false);
			int num4 = child.x22e0084ce6e1ab9a();
			int num5 = num4 + child.x2e39a445d52f6ea8();
			if (x13d4cb8d1bd20347 < num4)
			{
				num2 = num3 - 1;
				continue;
			}
			if (x13d4cb8d1bd20347 >= num5)
			{
				num = num3 + 1;
				continue;
			}
			return child.x42ef18de02ad5182(x13d4cb8d1bd20347);
		}
		return null;
	}

	internal override int x2e39a445d52f6ea8()
	{
		int num = 0;
		for (Node node = FirstChild; node != null; node = node.NextSibling)
		{
			num += node.x2e39a445d52f6ea8();
		}
		return num + x0598f184f69953c1().Length;
	}

	internal virtual string x0598f184f69953c1()
	{
		return string.Empty;
	}

	internal string xb0c453ec73ede97e()
	{
		return xb8e292d45f876c2d().ToString();
	}

	private StringBuilder xb8e292d45f876c2d()
	{
		StringBuilder stringBuilder = new StringBuilder();
		for (Node node = FirstChild; node != null; node = node.NextSibling)
		{
			stringBuilder.Append(node.GetText());
		}
		return stringBuilder;
	}

	protected bool xf7ae36cd24e0b11c(DocumentVisitor x672ff13faf031f3d)
	{
		switch (x2449520719b1e37e(x672ff13faf031f3d))
		{
		case VisitorAction.SkipThisNode:
			return true;
		case VisitorAction.Stop:
			return false;
		default:
			if (!x464d2134480a7bf2(x672ff13faf031f3d))
			{
				return false;
			}
			return Node.x9708eba393e07242(x3bbb475596fa1de1(x672ff13faf031f3d));
		}
	}

	[JavaThrows(true)]
	internal abstract VisitorAction x2449520719b1e37e(DocumentVisitor x672ff13faf031f3d);

	[JavaThrows(true)]
	internal abstract VisitorAction x3bbb475596fa1de1(DocumentVisitor x672ff13faf031f3d);

	protected bool x464d2134480a7bf2(DocumentVisitor x672ff13faf031f3d)
	{
		Node node = FirstChild;
		while (node != null)
		{
			Node nextSibling = node.NextSibling;
			if (!node.Accept(x672ff13faf031f3d))
			{
				return false;
			}
			node = nextSibling;
		}
		return true;
	}

	internal abstract bool x8a4414b7d9d4073f(Node x40e458b3a58f5782);

	private Node xef23aa45e7612fdd(Node x40e458b3a58f5782, Node xff5adbb92d63bf52, bool x7f43f79506f73a73)
	{
		if (xff5adbb92d63bf52 != null && xff5adbb92d63bf52.ParentNode != this)
		{
			throw new ArgumentException(string.Intern(x1110bdd110cdcea4._xaacba899487bce8c("fkgnglnnaleoiglohlcphkjpfkaabkhalkoaljfbbkmbdjdccjkckebdfjiddjpdfigedineldefbilfiicgcdjgnhahlhhhnhohgcfiegmiacdjagkjcgbkagikagpkffgloanlkfemoelmfacngfjnheaofehomeoogpepbemppddabdkapcbbfphb", 266786385)));
		}
		if (x40e458b3a58f5782 == null)
		{
			throw new ArgumentException(string.Intern(x1110bdd110cdcea4._xaacba899487bce8c("jhbhejihojphljgijjniljejeeljkickmijkoialnhhlhiolgifmpcmmngdnjcknehboihiomgpojggpkbnpfgeadglaffcbdfjbjbac", 876572982)));
		}
		if (x40e458b3a58f5782 == this)
		{
			throw new ArgumentException(string.Intern(x1110bdd110cdcea4._xaacba899487bce8c("hkcpcmjpmmaajmhahmoajmfbchmbaldcalkcnkbdggidekpdaggelknejkefljlfjjcgbfjgckahkjhhieohijfihimilidjcikjhebk", 499511908)));
		}
		if (xd5b26cfce8730b50(x40e458b3a58f5782))
		{
			throw new ArgumentException(string.Intern(x1110bdd110cdcea4._xaacba899487bce8c("mmpfnngghnngpiehknlhomcinnjigkajimhjgmojgmfkllmkehdlklklbmbmlgimjkpmdlgncgnnakeokklomjcpljjpgkaaekhamjoamjfbhembdjdchikcodbdpiidaipdohgefinepcefkhlfihcgkgjgigahochh", 576020344)));
		}
		DocumentBase document = base.Document;
		DocumentBase document2 = x40e458b3a58f5782.Document;
		if (document2 != document)
		{
			throw new ArgumentException(string.Intern(x1110bdd110cdcea4._xaacba899487bce8c("boekcplkmoclekjlpoamdohmcpomllfnnnmnlndolnkoanbpjiipnnppemgadnnanhebnllbjmccjljccladcmhdalodmkfefgmeikdfblkflkbggkiggfpgejghafnhbjeidjlinicjkijjgiakajhkaiokgifljimlcddmdhkmlhbnmginlhpnahgofgnolgepoglphbcaigjajfabpehbjfobiafcjfmckeddeekdmpaeieieeepeidgfapmfbeegcdlgicchidjhbophbchincoinbfjgbmjgcdkebkkabbljmhlkbpllagmjanmabenklknfacodajofppodpgpjlnp", 789292173)));
		}
		if (x40e458b3a58f5782.NodeType != NodeType.System && !x8a4414b7d9d4073f(x40e458b3a58f5782))
		{
			throw new ArgumentException(string.Intern(x1110bdd110cdcea4._xaacba899487bce8c("fngnapnnkpeohplofpcphpjpakaagohaiooakofbjnmbdodccokclibdjmidfipdangeomneamefollfghcgcmjgglahnghholohpkfinkmieldjofkjpkbkblikfkpkhjglpenlniemnjlmgecnhjjniiaogihonioohdfpaimpaidabhkamgbbmhibogpbbhgcngnckced", 429053586)));
		}
		if (x40e458b3a58f5782.ParentNode != null)
		{
			x40e458b3a58f5782.ParentNode.RemoveChild(x40e458b3a58f5782);
		}
		NodeChangingArgs nodeChangingArgs = document.xaa5995fb46863e53(x40e458b3a58f5782, null, this, NodeChangingAction.Insert);
		if (nodeChangingArgs != null)
		{
			document.x9d5c03f243a200e9(nodeChangingArgs);
		}
		if (LastChild == null)
		{
			x40e458b3a58f5782.xe59ebb6cc4eed968 = x40e458b3a58f5782;
			x40e458b3a58f5782.xf523c8cf086433fd = x40e458b3a58f5782;
			x9f67a1a3199d9184 = x40e458b3a58f5782;
		}
		else if (x7f43f79506f73a73)
		{
			if (xff5adbb92d63bf52 != null)
			{
				xa31176735d470872(x40e458b3a58f5782, xff5adbb92d63bf52);
				if (xff5adbb92d63bf52 == LastChild)
				{
					x9f67a1a3199d9184 = x40e458b3a58f5782;
				}
			}
			else
			{
				xa31176735d470872(x40e458b3a58f5782, LastChild);
			}
		}
		else if (xff5adbb92d63bf52 != null)
		{
			Node node = xff5adbb92d63bf52.PreviousSibling;
			if (node == null)
			{
				node = LastChild;
			}
			xa31176735d470872(x40e458b3a58f5782, node);
		}
		else
		{
			xa31176735d470872(x40e458b3a58f5782, LastChild);
			x9f67a1a3199d9184 = x40e458b3a58f5782;
		}
		x40e458b3a58f5782.xb2b69aae23a4ae6d(this);
		if (nodeChangingArgs != null)
		{
			document.xea94cc1c9383f0e6(nodeChangingArgs);
		}
		return x40e458b3a58f5782;
	}

	private static void xa31176735d470872(Node x40e458b3a58f5782, Node x1d6b030e5da040dc)
	{
		Node node = x1d6b030e5da040dc.xf523c8cf086433fd;
		x40e458b3a58f5782.xe59ebb6cc4eed968 = x1d6b030e5da040dc;
		x40e458b3a58f5782.xf523c8cf086433fd = node;
		x1d6b030e5da040dc.xf523c8cf086433fd = x40e458b3a58f5782;
		node.xe59ebb6cc4eed968 = x40e458b3a58f5782;
	}

	[JavaDelete("XPath navigation is supported on Java, but implementing this interface is not needed.")]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public XPathNavigator CreateNavigator()
	{
		return new x030154038d5d0afb(this);
	}
}
