namespace ns291;

internal class Class6787
{
	private bool bool_0;

	private bool bool_1;

	private bool bool_2 = true;

	private Enum921 enum921_0;

	public bool EnableSingleStreamConversion
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

	public Enum921 SvgEmbeddingOptions
	{
		get
		{
			return enum921_0;
		}
		set
		{
			enum921_0 = value;
		}
	}

	public bool SaveNonVectorPartsFromSvgImagesApart
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

	public bool EnableStyleSheetPerPageGeneration
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

	public Class6787()
	{
		bool_0 = false;
		enum921_0 = Enum921.const_0;
	}
}
