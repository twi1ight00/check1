namespace Aspose.Slides.Patterns;

internal interface IObservable
{
	void Subscribe(IObserver observer);

	void Unsubscribe(IObserver observer);
}
