using System; 

public partial class calc
{
	public int mul(int x, int y)
	{
		return x * y;
	}

	public int div(int x, int y)
	{
		if (y == 0)
		{
			throw new Exception("zero divisor");
		}
		else
		{
			return x / y;
		}
	}
}
