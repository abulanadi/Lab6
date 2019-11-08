using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab6
{
	class MyBigIntegers
	{
		public string value;

		public MyBigIntegers()
		{

		}

		public MyBigIntegers(string myInt)
		{
			value = myInt;
		}

		public void PrintString()
		{
			Console.WriteLine(value);
		}

		public string Plus(string x)
		{
			if(value.Length > x.Length)
			{
				string temp = value;
				value = x;
				x = temp;
			}

			string bigSum = "";

			int valueLength = value.Length, xLength = x.Length;
			int lenDifference = xLength - valueLength;

			int carry = 0;

			for (int i = valueLength - 1; i >= 0; i--)
			{
				int sum = ((int)(value[i] - '0') + (int)(x[i + lenDifference] - '0') + carry);
				bigSum += (char)(sum % 10 + '0');
				carry = sum / 10;
			}

			for (int i = xLength - valueLength - 1; i >= 0; i--)
			{
				int sum = ((int)(x[i] - '0') + carry);
				bigSum += (char)(sum % 10 + '0');
				carry = sum / 10;
			}

			if (carry > 0)
			{
				bigSum += (char)(carry + '0');
			}

			char[] sumResult = bigSum.ToCharArray();
			Array.Reverse(sumResult);
			return new string(sumResult);
		}

		public string Times(string x)
		{
			int valueLength = value.Length;
			int xLength = x.Length;

			if(valueLength == 0 || xLength == 0)
			{
				return "0";
			}

			int[] result = new int[valueLength + xLength];

			int iVal = 0;
			int iX = 0;
			int i;

			for(i = valueLength - 1; i >= 0; i--)
			{
				int carry = 0;
				int n1 = value[i] - '0';

				iX = 0;

				for(int j = xLength - 1; j >= 0; j--)
				{
					int n2 = x[j] - '0';

					int sum = n1 * n2 + result[iVal + iX] + carry;

					carry = sum / 10;

					result[iVal + iX] = sum % 10;
					iX++;
				}

				if(carry > 0)
				{
					result[iVal + iX] += carry;
				}
				iVal++;
			}

			i = result.Length - 1;
			while(i >= 0 && result[i] == 0)
			{
				i--;
			}
			if(i == -1)
			{
				return "0";
			}
			String bigProduct = "";

			while(i >= 0)
			{
				bigProduct += (result[i--]);
			}

			return bigProduct;
		}
	}
}
