using x28925c9b27b37a46;

namespace Aspose.Words;

[JavaDelete("Not needed in java: java has standard thread interruption framevork.")]
public class InterruptionToken
{
	private volatile bool xa7ea49a7acab7bd5;

	internal bool x0efc97b7d837bd49 => xa7ea49a7acab7bd5;

	public void Interrupt()
	{
		xa7ea49a7acab7bd5 = true;
	}

	public void BindToCurrentThread()
	{
		xbf152843c1ed2887.x2e0d2f695a7a4634(this);
	}

	internal void x74f5a1ef3906e23c()
	{
		xa7ea49a7acab7bd5 = false;
	}
}
