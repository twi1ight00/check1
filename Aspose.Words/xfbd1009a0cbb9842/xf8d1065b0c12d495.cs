using System;
using Aspose.Words;
using x6c95d9cf46ff5f25;

namespace xfbd1009a0cbb9842;

internal class xf8d1065b0c12d495
{
	private readonly string x05ea6aee4d0b1c50;

	private xf8d1065b0c12d495(string styleName)
	{
		x05ea6aee4d0b1c50 = styleName;
	}

	internal static x72608c670658bf7a x177d82d2dbabfc03(Paragraph x341a8f6e92e79efa, string xbd5a2e7a4ff749c9)
	{
		xf8d1065b0c12d495 xf8d1065b0c12d496 = new xf8d1065b0c12d495(xbd5a2e7a4ff749c9);
		return xf8d1065b0c12d496.x177d82d2dbabfc03(x341a8f6e92e79efa);
	}

	internal x72608c670658bf7a x177d82d2dbabfc03(Paragraph x341a8f6e92e79efa)
	{
		if (x341a8f6e92e79efa.GetAncestor(NodeType.HeaderFooter) != null)
		{
			return x35d8e0d1c2410d0c(x341a8f6e92e79efa);
		}
		return xac5a18ecce4d53d7(x341a8f6e92e79efa);
	}

	internal x72608c670658bf7a x35d8e0d1c2410d0c(Paragraph x341a8f6e92e79efa)
	{
		for (Section section = x341a8f6e92e79efa.ParentSection; section != null; section = x18e96cc454fb6c65(section))
		{
			NodeCollection childNodes = section.Body.GetChildNodes(NodeType.Paragraph, isDeep: true);
			x72608c670658bf7a x72608c670658bf7a2 = x7cf685b9c68b1ff4(childNodes, 0, x0e612644949fc402: true, x0e0a2e0dd6ccd312.xd4a82970ba6be033);
			if (x72608c670658bf7a2 != null)
			{
				return x72608c670658bf7a2;
			}
		}
		return null;
	}

	private static Section x18e96cc454fb6c65(Node xda5bf54deb817e37)
	{
		xda5bf54deb817e37 = xda5bf54deb817e37.NextSibling;
		while (xda5bf54deb817e37 != null && xda5bf54deb817e37.NodeType != NodeType.Section)
		{
			xda5bf54deb817e37 = xda5bf54deb817e37.NextSibling;
		}
		return (Section)xda5bf54deb817e37;
	}

	internal x72608c670658bf7a xac5a18ecce4d53d7(Paragraph x341a8f6e92e79efa)
	{
		NodeCollection childNodes = x341a8f6e92e79efa.Document.GetChildNodes(NodeType.Paragraph, isDeep: true);
		int x6a05f2b1826ffac = childNodes.IndexOf(x341a8f6e92e79efa);
		x72608c670658bf7a x72608c670658bf7a2 = x7cf685b9c68b1ff4(childNodes, x6a05f2b1826ffac, x0e612644949fc402: false, x0e0a2e0dd6ccd312.xe9634325258d088b);
		if (x72608c670658bf7a2 != null)
		{
			return x72608c670658bf7a2;
		}
		x72608c670658bf7a2 = x7cf685b9c68b1ff4(childNodes, x6a05f2b1826ffac, x0e612644949fc402: false, x0e0a2e0dd6ccd312.xd4a82970ba6be033);
		if (x72608c670658bf7a2 != null)
		{
			return x72608c670658bf7a2;
		}
		return null;
	}

	private x72608c670658bf7a x7cf685b9c68b1ff4(NodeCollection xffb4e7e8630b6687, int x6a05f2b1826ffac7, bool x0e612644949fc402, x0e0a2e0dd6ccd312 x23e85093ba3a7d1d)
	{
		int num = 0;
		x72608c670658bf7a x72608c670658bf7a2;
		while (true)
		{
			if (!x0e612644949fc402)
			{
				num++;
			}
			int num2;
			switch (x23e85093ba3a7d1d)
			{
			case x0e0a2e0dd6ccd312.xe9634325258d088b:
				num2 = x6a05f2b1826ffac7 - num;
				if (num2 < 0)
				{
					return null;
				}
				break;
			case x0e0a2e0dd6ccd312.xd4a82970ba6be033:
				num2 = x6a05f2b1826ffac7 + num;
				if (num2 >= xffb4e7e8630b6687.Count)
				{
					return null;
				}
				break;
			default:
				throw new ArgumentOutOfRangeException("direction");
			}
			Paragraph x31e6518f5e08db6c = (Paragraph)xffb4e7e8630b6687[num2];
			x72608c670658bf7a2 = x045860772b801e2d(x31e6518f5e08db6c, x23e85093ba3a7d1d);
			if (x72608c670658bf7a2 != null)
			{
				break;
			}
			if (x0e612644949fc402)
			{
				num++;
			}
		}
		return x72608c670658bf7a2;
	}

	private x72608c670658bf7a x045860772b801e2d(Paragraph x31e6518f5e08db6c, x0e0a2e0dd6ccd312 x23e85093ba3a7d1d)
	{
		if (x0d299f323d241756.x90637a473b1ceaaa(x31e6518f5e08db6c.xfcffbd79482d97c7.Name, x05ea6aee4d0b1c50))
		{
			if (x31e6518f5e08db6c.Runs.Count == 0)
			{
				return null;
			}
			return new x72608c670658bf7a(x31e6518f5e08db6c, 0, x31e6518f5e08db6c.Runs.Count - 1, x23e85093ba3a7d1d);
		}
		bool flag = false;
		int startIndex = 0;
		int endIndex = 0;
		for (int i = 0; i < x31e6518f5e08db6c.Runs.Count; i++)
		{
			int num = x23e85093ba3a7d1d switch
			{
				x0e0a2e0dd6ccd312.xe9634325258d088b => x31e6518f5e08db6c.Runs.Count - i - 1, 
				x0e0a2e0dd6ccd312.xd4a82970ba6be033 => i, 
				_ => throw new ArgumentOutOfRangeException("direction"), 
			};
			Run run = x31e6518f5e08db6c.Runs[num];
			if (x0d299f323d241756.x90637a473b1ceaaa(run.Font.StyleName, x05ea6aee4d0b1c50))
			{
				if (!flag)
				{
					startIndex = num;
					flag = true;
				}
				endIndex = num;
			}
			else if (flag)
			{
				break;
			}
		}
		if (flag)
		{
			return new x72608c670658bf7a(x31e6518f5e08db6c, startIndex, endIndex, x23e85093ba3a7d1d);
		}
		return null;
	}
}
