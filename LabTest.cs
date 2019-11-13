using System;
using System.Diagnostics;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab6
{
	class LabTest
	{
		string resultsFolderPath = "C:\\Users\\Adria\\School Stuff\\CSC482\\Lab6";
		int numberOfTrials = 10;
		Stopwatch stopwatch = new Stopwatch();
		Random random = new Random();
		public const string Numerals = "0123456789";
		double nanoSecs = 0;
		double doubleRatio = 0;

		public void Addition(string resultFile, int maxDigits)
		{
			double previousRatio = 0;
			Console.WriteLine("Testing addition...");
			Console.WriteLine("# of Digits\t\tAvg Time (ns)\t\tDoubling Ratio");

			for(int i = 1; i <= maxDigits; i += i)
			{
				for(int trial = 0; trial < numberOfTrials; trial++)
				{
					MyBigIntegers randomNum1 = new MyBigIntegers(NumberGenerator(i));
					MyBigIntegers randomNum2 = new MyBigIntegers(NumberGenerator(i));

					stopwatch.Restart();
					randomNum1.Plus(randomNum2.value);
					stopwatch.Stop();
					nanoSecs += stopwatch.Elapsed.TotalMilliseconds * 1000000;

				}

				double averageTrialTime = nanoSecs / numberOfTrials;
				if(previousRatio > 0)
				{
					doubleRatio = averageTrialTime / previousRatio;
				}
				previousRatio = averageTrialTime;
				Console.WriteLine("{0,-10}\t{1,16}\t\t{2,10:N2}", i, averageTrialTime, doubleRatio);

				using (StreamWriter outputFile = new StreamWriter(Path.Combine(resultsFolderPath, resultFile), true))
				{
					outputFile.WriteLine("{0,-10} {1,16} {2,10:N2}", i, averageTrialTime, doubleRatio);
				}
			}
		}

		public void Multiplication(string resultFile, int maxDigits)
		{
			double previousRatio = 0;
			Console.WriteLine("Testing multiplication...");
			Console.WriteLine("# of Digits\t\tAvg Time (ns)\t\tDoubling Ratio");

			for (int i = 1; i <= maxDigits; i += i)
			{
				for (int trial = 0; trial < numberOfTrials; trial++)
				{
					MyBigIntegers randomNum1 = new MyBigIntegers(NumberGenerator(i));
					MyBigIntegers randomNum2 = new MyBigIntegers(NumberGenerator(i));

					stopwatch.Restart();
					randomNum1.Times(randomNum2.value);
					stopwatch.Stop();
					nanoSecs += stopwatch.Elapsed.TotalMilliseconds * 1000000;

				}

				double averageTrialTime = nanoSecs / numberOfTrials;
				if (previousRatio > 0)
				{
					doubleRatio = averageTrialTime / previousRatio;
				}
				previousRatio = averageTrialTime;
				Console.WriteLine("{0,-10}\t{1,16}\t\t{2,10:N2}", i, averageTrialTime, doubleRatio);

				using (StreamWriter outputFile = new StreamWriter(Path.Combine(resultsFolderPath, resultFile), true))
				{
					outputFile.WriteLine("{0,-10} {1,16} {2,10:N2}", i, averageTrialTime, doubleRatio);
				}
			}
		}

		public string NumberGenerator(int digits)
		{
			
			char[] newNumber = new char[digits];
			newNumber[0] = Numerals[random.Next(1,Numerals.Length)];

			if(digits == 1)
			{
				return new string(newNumber);
			}
			
			for(int i = 1; i < digits; i++)
			{
				newNumber[i] = Numerals[random.Next(Numerals.Length)];
			}

			

			return new string(newNumber);

		}
	}
}
