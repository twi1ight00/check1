using System;
using System.Collections;
using System.Text.RegularExpressions;
using Aspose.Words.Fields;
using x28925c9b27b37a46;
using xfbd1009a0cbb9842;

namespace Aspose.Words;

public class Range
{
	private readonly Node x48154453a08515ea;

	private FormFieldCollection x49d994525cad56d9;

	private BookmarkCollection x4bd039d469a1155d;

	public string Text => x48154453a08515ea.GetText();

	public FormFieldCollection FormFields
	{
		get
		{
			if (x49d994525cad56d9 == null)
			{
				x49d994525cad56d9 = new FormFieldCollection(x48154453a08515ea);
			}
			return x49d994525cad56d9;
		}
	}

	public BookmarkCollection Bookmarks
	{
		get
		{
			if (x4bd039d469a1155d == null)
			{
				x4bd039d469a1155d = new BookmarkCollection(x48154453a08515ea);
			}
			return x4bd039d469a1155d;
		}
	}

	internal Range(Node node)
	{
		x48154453a08515ea = node;
	}

	public void Delete()
	{
		if (x48154453a08515ea.IsComposite)
		{
			((CompositeNode)x48154453a08515ea).RemoveAllChildren();
		}
		if (x48154453a08515ea.ParentNode != null)
		{
			x48154453a08515ea.ParentNode.RemoveChild(x48154453a08515ea);
		}
	}

	public int Replace(string oldValue, string newValue, bool isMatchCase, bool isMatchWholeWord)
	{
		xd71a3da4fdc6d210 xd71a3da4fdc6d = new xd71a3da4fdc6d210(x48154453a08515ea, oldValue, newValue, isMatchCase, isMatchWholeWord);
		return xd71a3da4fdc6d.x57bf52bb3d1c2d43();
	}

	public int Replace(Regex pattern, string replacement)
	{
		xd71a3da4fdc6d210 xd71a3da4fdc6d = new xd71a3da4fdc6d210(x48154453a08515ea, pattern, replacement, null, isForward: false);
		return xd71a3da4fdc6d.x57bf52bb3d1c2d43();
	}

	public int Replace(Regex pattern, IReplacingCallback handler, bool isForward)
	{
		if (handler == null)
		{
			throw new ArgumentNullException("eventHandler");
		}
		xd71a3da4fdc6d210 xd71a3da4fdc6d = new xd71a3da4fdc6d210(x48154453a08515ea, pattern, "", handler, isForward);
		return xd71a3da4fdc6d.x57bf52bb3d1c2d43();
	}

	public void UpdateFields()
	{
		x6435b7bbb0879a04 fields = xe25d778fe9f1252a.x105bab38d511372f(x48154453a08515ea, x0d900d42b3598fde: false);
		xfedf115fd9c03862 xfedf115fd9c = new xfedf115fd9c03862(fields);
		xfedf115fd9c.x384c03e4298b53bf();
	}

	internal ArrayList x157b3e02606f681a()
	{
		ArrayList arrayList = new ArrayList();
		foreach (Bookmark bookmark in Bookmarks)
		{
			arrayList.Add(bookmark.Name);
		}
		return arrayList;
	}
}
