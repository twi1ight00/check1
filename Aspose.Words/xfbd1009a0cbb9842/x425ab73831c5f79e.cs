using System.Collections;
using Aspose.Words;
using Aspose.Words.Fields;
using xf9a9481c3f63a419;

namespace xfbd1009a0cbb9842;

internal class x425ab73831c5f79e : xe25d778fe9f1252a
{
	private readonly Document xd1424e1a0bb4a72b;

	private readonly xb0db6b65736c1e1c x21328b445a743482;

	private readonly IDictionary xc836333f4dcd33fe = xd51c34d05311eee3.xdb04a310bbb29cff();

	private readonly Hashtable x69e3736da58119b7 = new Hashtable();

	internal x425ab73831c5f79e(Document document, xb0db6b65736c1e1c dataProvider)
	{
		xd1424e1a0bb4a72b = document;
		x21328b445a743482 = dataProvider;
		xa32a176802cd602d();
	}

	private void xa32a176802cd602d()
	{
		x6435b7bbb0879a04 x6435b7bbb0879a5 = xe25d778fe9f1252a.x105bab38d511372f(xd1424e1a0bb4a72b);
		foreach (Field item in x6435b7bbb0879a5)
		{
			if (item.Type != FieldType.FieldSequence)
			{
				continue;
			}
			x811d4618e5f42dc7 x811d4618e5f42dc8 = (x811d4618e5f42dc7)item;
			if (x811d4618e5f42dc8.x2eb33b2a908602bb && !x811d4618e5f42dc8.x6b54bdfbc4586f55)
			{
				ArrayList arrayList = (ArrayList)xc836333f4dcd33fe[x811d4618e5f42dc8.x0e99a2a20bc3c647];
				if (arrayList == null)
				{
					arrayList = new ArrayList();
					xc836333f4dcd33fe[x811d4618e5f42dc8.x0e99a2a20bc3c647] = arrayList;
				}
				arrayList.Add(x811d4618e5f42dc8);
			}
		}
	}

	internal void x295cb4a1df7a5add()
	{
		xd1424e1a0bb4a72b.Accept(this);
	}

	public override VisitorAction VisitBookmarkEnd(BookmarkEnd bookmarkEnd)
	{
		ArrayList arrayList = (ArrayList)xc836333f4dcd33fe[bookmarkEnd.Name];
		if (arrayList != null)
		{
			foreach (x811d4618e5f42dc7 item in arrayList)
			{
				x21328b445a743482.xa2c03db21671d9cc(item, (int)x69e3736da58119b7[item.x70c9403957f529f2]);
			}
		}
		return VisitorAction.Continue;
	}

	protected override void OnFieldExtracted(Field field)
	{
		if (field.Type == FieldType.FieldSequence)
		{
			x811d4618e5f42dc7 x811d4618e5f42dc8 = (x811d4618e5f42dc7)field;
			if (!x811d4618e5f42dc8.x6b54bdfbc4586f55 && !x811d4618e5f42dc8.x2eb33b2a908602bb)
			{
				int x949e56390867f = x028f312a9dc4f6dc(x811d4618e5f42dc8);
				x949e56390867f = x811d4618e5f42dc8.x5f21ccf084377ea8(x949e56390867f);
				x69e3736da58119b7[x811d4618e5f42dc8.x70c9403957f529f2] = x949e56390867f;
				x21328b445a743482.xa2c03db21671d9cc(x811d4618e5f42dc8, x949e56390867f);
			}
		}
	}

	private int x028f312a9dc4f6dc(x811d4618e5f42dc7 xe01ae93d9fe5a880)
	{
		object obj = x69e3736da58119b7[xe01ae93d9fe5a880.x70c9403957f529f2];
		if (obj == null)
		{
			return 0;
		}
		return (int)obj;
	}
}
