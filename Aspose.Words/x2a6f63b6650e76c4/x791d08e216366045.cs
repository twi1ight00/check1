namespace x2a6f63b6650e76c4;

internal class x791d08e216366045 : xc8443f26537ba337
{
	internal override int x4af6b6f55aeb44a7 => 3;

	protected override x82e26649b09596bd EvaluateCore(x82e26649b09596bd operand1, x82e26649b09596bd operand2)
	{
		if (operand2.x7ce859afc0c75642 == 0.0)
		{
			return new xf7d966ea5d1701b6("!Zero Divide");
		}
		return x918e475ee39e3253.xcf290d1e33e810d0(operand1, operand2, operand1.x7ce859afc0c75642 / operand2.x7ce859afc0c75642);
	}
}
