using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Aspose.Slides.Animation;

[Guid("79b05421-f59c-47c5-8243-2b7ed665241d")]
[ClassInterface(ClassInterfaceType.None)]
[ComVisible(true)]
public class TextAnimationCollection : ICollection, IEnumerable, IEnumerable<ITextAnimation>, ITextAnimationCollection
{
	private readonly List<ITextAnimation> list_0 = new List<ITextAnimation>();

	internal List<ITextAnimation> Animations => list_0;

	public int Count => list_0.Count;

	public ITextAnimation this[int index] => list_0[index];

	public ITextAnimation[] this[IShape shape]
	{
		get
		{
			List<TextAnimation> list = new List<TextAnimation>();
			IEnumerator enumerator = GetEnumerator();
			try
			{
				while (enumerator.MoveNext())
				{
					TextAnimation textAnimation = (TextAnimation)enumerator.Current;
					if (textAnimation.PPTXUnsupportedProps.ShapeRef == shape)
					{
						list.Add(textAnimation);
					}
				}
			}
			finally
			{
				IDisposable disposable = enumerator as IDisposable;
				if (disposable != null)
				{
					disposable.Dispose();
				}
			}
			return list.ToArray();
		}
	}

	IEnumerable ITextAnimationCollection.AsIEnumerable => this;

	ICollection ITextAnimationCollection.AsICollection => this;

	public bool IsSynchronized => false;

	public object SyncRoot => this;

	internal void Add(TextAnimation textAnim)
	{
		list_0.Add(textAnim);
	}

	public TextAnimation Add()
	{
		TextAnimation textAnimation = new TextAnimation();
		Add(textAnimation);
		return textAnimation;
	}

	IEnumerator<ITextAnimation> IEnumerable<ITextAnimation>.GetEnumerator()
	{
		return list_0.GetEnumerator();
	}

	public IEnumerator GetEnumerator()
	{
		return list_0.GetEnumerator();
	}

	public void CopyTo(Array array, int index)
	{
		((ICollection)list_0).CopyTo(array, index);
	}
}
