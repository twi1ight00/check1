using System;
using System.Collections;

namespace Aspose.Cells;

public class ConditionalFormattingIconCollection : CollectionBase
{
	public ConditionalFormattingIcon this[int index]
	{
		get
		{
			if (index >= base.InnerList.Count)
			{
				throw new ArgumentException("Invalid conditionalFormattingIcon index : " + index);
			}
			return (ConditionalFormattingIcon)base.InnerList[index];
		}
	}

	internal ConditionalFormattingIconCollection()
	{
	}

	internal void Copy(ConditionalFormattingIconCollection conditionalFormattingIconCollection_0)
	{
		for (int i = 0; i < conditionalFormattingIconCollection_0.Count; i++)
		{
			ConditionalFormattingIcon conditionalFormattingIcon = new ConditionalFormattingIcon();
			conditionalFormattingIcon.Copy(conditionalFormattingIconCollection_0[i]);
			base.InnerList.Add(conditionalFormattingIcon);
		}
	}

	public int Add(IconSetType type, int index)
	{
		base.InnerList.Add(new ConditionalFormattingIcon(type, index));
		return base.Count - 1;
	}

	public int Add(ConditionalFormattingIcon cficon)
	{
		base.InnerList.Add(cficon);
		return base.Count - 1;
	}
}
