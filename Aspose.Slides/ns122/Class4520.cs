using ns127;

namespace ns122;

internal abstract class Class4520 : Interface133
{
	private Class4520[] class4520_0;

	protected byte[][] byte_0;

	protected byte[][] byte_1;

	protected int int_0;

	protected byte[] byte_2;

	private bool bool_0;

	private bool bool_1;

	private Class4520 class4520_1;

	private bool bool_2;

	private bool bool_3;

	private Interface133 interface133_0;

	private Interface134 interface134_0;

	public Class4520 Parent => class4520_1;

	public byte[][] BeginMarkers => byte_1;

	public byte[][] EndMarkers => byte_0;

	public Class4520[] ChildScanners
	{
		get
		{
			return class4520_0;
		}
		set
		{
			method_1();
			class4520_0 = value;
			method_0();
		}
	}

	public bool IsAllowed
	{
		get
		{
			return bool_0;
		}
		set
		{
			bool_0 = value;
		}
	}

	protected bool ForceIsYourEnd
	{
		get
		{
			return bool_3;
		}
		set
		{
			bool_3 = value;
		}
	}

	public bool SupportImmediateClosing
	{
		get
		{
			return bool_2;
		}
		set
		{
			bool_2 = value;
		}
	}

	protected bool UseParentEndMarker
	{
		get
		{
			return bool_1;
		}
		set
		{
			bool_1 = value;
		}
	}

	public Interface133 ScannerFinishedCallback
	{
		get
		{
			return interface133_0;
		}
		set
		{
			interface133_0 = value;
		}
	}

	public Interface134 ScannerBegunCallback
	{
		get
		{
			return interface134_0;
		}
		set
		{
			interface134_0 = value;
		}
	}

	public Class4520(Class4520 parent, byte[] file)
	{
		byte_2 = file;
		class4520_0 = new Class4520[0];
		bool_0 = true;
		bool_3 = false;
		bool_1 = false;
		bool_2 = false;
		class4520_1 = parent;
	}

	public virtual void vmethod_0(int startPosition, out int endPosition)
	{
		vmethod_1();
		vmethod_4();
		int_0 = startPosition;
		int num = startPosition;
		if (!SupportImmediateClosing || vmethod_3(startPosition, out endPosition) == null)
		{
			do
			{
				vmethod_6(num);
				Class4520 @class = null;
				Class4520[] childScanners = ChildScanners;
				foreach (Class4520 class2 in childScanners)
				{
					if (class2.IsAllowed && class2.vmethod_2(num, out var _, out var bodyStartPosition))
					{
						@class = class2;
						@class.vmethod_0(bodyStartPosition, out var endPosition2);
						num = endPosition2;
						break;
					}
				}
				if (@class == null || !@class.UseParentEndMarker)
				{
					num++;
				}
			}
			while (vmethod_3(num, out endPosition) == null && num < byte_2.Length - 1);
		}
		if (endPosition == -1 && num >= byte_2.Length - 1)
		{
			endPosition = num;
		}
		vmethod_5();
		vmethod_1();
	}

	public virtual void vmethod_1()
	{
		ForceIsYourEnd = false;
		if (this is Interface136 @interface)
		{
			@interface.BytesCount = 0;
			@interface.BytesLimit = int.MinValue;
		}
	}

	protected virtual bool vmethod_2(int startPosition, out byte[] matchedMarker, out int bodyStartPosition)
	{
		matchedMarker = null;
		bodyStartPosition = -1;
		byte[][] beginMarkers = BeginMarkers;
		int num = 0;
		byte[] array;
		while (true)
		{
			if (num < beginMarkers.Length)
			{
				array = beginMarkers[num];
				if (Class4554.smethod_4(byte_2, startPosition, array))
				{
					break;
				}
				num++;
				continue;
			}
			return false;
		}
		bodyStartPosition = startPosition + array.Length;
		matchedMarker = array;
		return true;
	}

	protected virtual byte[] vmethod_3(int currentPosition, out int endPosition)
	{
		byte[][] endMarkers = EndMarkers;
		int num = 0;
		byte[] array;
		while (true)
		{
			if (num < endMarkers.Length)
			{
				array = endMarkers[num];
				if (!ForceIsYourEnd)
				{
					if (Class4554.smethod_4(byte_2, currentPosition, array) && (!(this is Interface136 @interface) || @interface.BytesCount >= @interface.BytesLimit))
					{
						break;
					}
					num++;
					continue;
				}
				endPosition = currentPosition;
				return new byte[0];
			}
			endPosition = -1;
			return null;
		}
		if (!UseParentEndMarker)
		{
			endPosition = currentPosition + array.Length - 1;
		}
		else
		{
			endPosition = currentPosition;
		}
		return array;
	}

	protected virtual void vmethod_4()
	{
		if (this is Interface136 @interface && Parent is Interface135 interface2 && interface2.ValueStack.Count > 0)
		{
			object obj = interface2.ValueStack.Pop();
			if (obj is double)
			{
				@interface.BytesLimit = (int)(double)obj;
			}
		}
		if (ScannerBegunCallback != null)
		{
			ScannerBegunCallback.imethod_0(this);
		}
	}

	protected virtual void vmethod_5()
	{
		if (ScannerFinishedCallback != null)
		{
			ScannerFinishedCallback.imethod_0(this);
		}
	}

	protected virtual void vmethod_6(int currentPosition)
	{
		if (this is Interface136 @interface)
		{
			@interface.BytesCount++;
		}
	}

	private void method_0()
	{
		Class4520[] array = class4520_0;
		foreach (Class4520 @class in array)
		{
			@class.ScannerFinishedCallback = this;
		}
	}

	private void method_1()
	{
		if (class4520_0 != null && class4520_0.Length > 0)
		{
			Class4520[] array = class4520_0;
			foreach (Class4520 @class in array)
			{
				@class.ScannerFinishedCallback = null;
			}
		}
	}

	public virtual void imethod_0(object sender)
	{
	}
}
