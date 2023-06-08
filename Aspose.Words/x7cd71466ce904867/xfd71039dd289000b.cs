using x4dc96876c552a593;

namespace x7cd71466ce904867;

internal class xfd71039dd289000b : x149f0bd36fa2cea2
{
	private double xb52ac794cb1d91df;

	private bool x116da9ff4de1c84e = true;

	private double x3df291ce6bc5e21d;

	public double x0676d72fd66d25a3 => xb52ac794cb1d91df;

	public double xbe67343063c92f66 => x3df291ce6bc5e21d;

	public xfd71039dd289000b(xbda35f782f90b3df paragraphProperties, double columnWidth)
	{
		x3df291ce6bc5e21d = columnWidth - (double)paragraphProperties.xc8a7b7ce5c5279ee - (double)paragraphProperties.x3fa6fa3075fd558f;
		if (paragraphProperties.x412be8036a42f59b > 0)
		{
			xb52ac794cb1d91df = x3df291ce6bc5e21d - (double)paragraphProperties.x412be8036a42f59b;
		}
		else
		{
			xb52ac794cb1d91df = x3df291ce6bc5e21d + (double)paragraphProperties.xc8a7b7ce5c5279ee;
		}
	}

	public double xc12e7b7c206ba951()
	{
		if (x116da9ff4de1c84e)
		{
			x116da9ff4de1c84e = false;
			return x0676d72fd66d25a3;
		}
		return xbe67343063c92f66;
	}
}
