using System;
using System.Collections;
using Aspose.XfaConverter.Elements;
using ns216;

namespace ns215;

internal class Class5929
{
	private Hashtable hashtable_0;

	private static Class5929 class5929_0;

	internal static Class5929 Instance
	{
		get
		{
			if (class5929_0 == null)
			{
				class5929_0 = new Class5929();
			}
			return class5929_0;
		}
	}

	private Class5929()
	{
		hashtable_0 = new Hashtable();
		Class5782[] array = new Class5782[109]
		{
			new Class5852(),
			new Class5858(),
			new Class5785(),
			new Class5786(),
			new Class5787(),
			new Class5788(),
			new Class5789(),
			new Class5859(),
			new Class5860(),
			new Class5861(),
			new Class5790(),
			new Class5791(),
			new Class5792(),
			new Class5793(),
			new Class5794(),
			new Class5795(),
			new Class5796(),
			new Class5862(),
			new Class5797(),
			new Class5798(),
			new Class5799(),
			new Class5800(),
			new Class5863(),
			new Class5801(),
			new Class5802(),
			new Class5803(),
			new Class5864(),
			new Class5865(),
			new Class5805(),
			new Class5866(),
			new Class5806(),
			new Class5807(),
			new Class5867(),
			new Class5808(),
			new Class5809(),
			new Class5810(),
			new Class5868(),
			new Class5811(),
			new Class5812(),
			new Class5813(),
			new Class5814(),
			new Class5869(),
			new Class5870(),
			new Class5815(),
			new Class5816(),
			new Class5817(),
			new Class5818(),
			new Class5819(),
			new Class5871(),
			new Class5820(),
			new Class5821(),
			new Class5872(),
			new Class5873(),
			new Class5874(),
			new Class5822(),
			new Class5875(),
			new Class5823(),
			new Class5824(),
			new Class5825(),
			new Class5876(),
			new Class5826(),
			new Class5827(),
			new Class5877(),
			new Class5828(),
			new Class5829(),
			new Class5878(),
			new Class5879(),
			new Class5830(),
			new Class5831(),
			new Class5832(),
			new Class5880(),
			new Class5833(),
			new Class5881(),
			new Class5834(),
			new Class5835(),
			new Class5836(),
			new Class5837(),
			new Class5838(),
			new Class5882(),
			new Class5839(),
			new Class5840(),
			new Class5883(),
			new Class5841(),
			new Class5842(),
			new Class5884(),
			new Class5885(),
			new Class5886(),
			new Class5843(),
			new Class5844(),
			new Class5845(),
			new Class5846(),
			new Class5887(),
			new Class5847(),
			new Class5848(),
			new Class5849(),
			new Class5888(),
			new Class5850(),
			new Class5851(),
			new Class5889(),
			new Class5804(),
			new Class5890(),
			new Class5891(),
			new Class5892(),
			new Class5853(),
			new Class5854(),
			new Class5855(),
			new Class5856(),
			new Class5893(),
			new Class5857()
		};
		Class5782[] array2 = array;
		foreach (Class5782 @class in array2)
		{
			hashtable_0[@class.vmethod_8()] = @class;
		}
	}

	internal Class5782 CreateElement(string elementTag)
	{
		try
		{
			return ((Class5782)hashtable_0[elementTag]).vmethod_7();
		}
		catch (Exception)
		{
			throw;
		}
	}

	internal Class5916 method_0(Interface249 element)
	{
		if (element == null)
		{
			throw new ArgumentException();
		}
		return element.LayoutType switch
		{
			XfaEnums.Enum706.const_0 => new Class5919(element), 
			XfaEnums.Enum706.const_1 => new Class5917(element), 
			XfaEnums.Enum706.const_2 => new Class5918(element), 
			XfaEnums.Enum706.const_3 => new Class5920(element), 
			XfaEnums.Enum706.const_4 => new Class5921(element), 
			XfaEnums.Enum706.const_5 => new Class5922(element), 
			_ => throw new ArgumentException(), 
		};
	}
}
