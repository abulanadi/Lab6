using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab6
{
	class Program
	{
		static void Main(string[] args)
		{
			MyBigIntegers bigInt1 = new MyBigIntegers("123123123123123123");
			MyBigIntegers bigInt2 = new MyBigIntegers("321321321321321321");

			bigInt1.PrintString();
			bigInt2.PrintString();

			Console.WriteLine(bigInt1.Plus(bigInt2.value));
			Console.WriteLine(bigInt1.Times(bigInt2.value));
		}
	}
}
