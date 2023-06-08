using System;
using Aspose.Slides.Patterns;

namespace ns29;

internal class Class490 : IObservable
{
	private IObserver iobserver_0;

	public void Subscribe(IObserver observer)
	{
		if (iobserver_0 != null)
		{
			throw new ArgumentException("This implementation of IObservable supports only one IObserver");
		}
		iobserver_0 = observer;
	}

	public void Unsubscribe(IObserver observer)
	{
		if (observer != iobserver_0)
		{
			throw new ArgumentException("This observer was not subscribed");
		}
		iobserver_0 = null;
	}

	public void method_0(object sender)
	{
		if (iobserver_0 != null)
		{
			iobserver_0.Notify(sender);
		}
	}
}
