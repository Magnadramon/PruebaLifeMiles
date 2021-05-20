using System;
using System.Collections.Generic;
using System.Text;

namespace CodigoLectura
{
	class Program
	{
		private static Dictionary<char, string> _morseAlphabetDictionary;
		private static Dictionary<char, string> _basedifogu;
		static void Main(string[] args)
		{
			InitializeDictionary();
			InitializeBasedi();

			Console.WriteLine("Palabra a encriptar");
			string userInput = GetUserInput();
			Console.WriteLine("Código MORSE: " + Translate(userInput) + " \n   Bacedifogu: " + BaceDifogu(userInput) + " \n  a OCTAL: " + valorOctal(userInput));

			Console.WriteLine("Presionar letra para continuar");

			Console.ReadKey(true);

		}



		private static void InitializeDictionary()
		{
			_morseAlphabetDictionary = new Dictionary<char, string>()
			{
				{'a', ".-"},
				{'b', "-..."},
				{'c', "-.-."},
				{'d', "-.."},
				{'e', "."},
				{'f', "..-."},
				{'g', "--."},
				{'h', "...."},
				{'i', ".."},
				{'j', ".---"},
				{'k', "-.-"},
				{'l', ".-.."},
				{'m', "--"},
				{'n', "-."},
				{'o', "---"},
				{'p', ".--."},
				{'q', "--.-"},
				{'r', ".-."},
				{'s', "..."},
				{'t', "-"},
				{'u', "..-"},
				{'v', "...-"},
				{'w', ".--"},
				{'x', "-..-"},
				{'y', "-.--"},
				{'z', "--.."},
				{'0', "-----"},
				{'1', ".----"},
				{'2', "..---"},
				{'3', "...--"},
				{'4', "....-"},
				{'5', "....."},
				{'6', "-...."},
				{'7', "--..."},
				{'8', "---.."},
				{'9', "----."}
			};
		}

		//
		private static void InitializeBasedi()
		{
			_basedifogu = new Dictionary<char, string>()
			{
				{'A', "1"},
				{'B', "0"},
				{'C', "2"},
				{'D', "4"},
				{'E', "3"},
				{'F', "6"},
				{'G', "8"},
				{'H', "H"},
				{'I', "5"},
				{'J', "J"},
				{'K', "K"},
				{'L', "L"},
				{'M', "M"},
				{'N', "N"},
				{'O', "7"},
				{'P', "P"},
				{'Q', "Q"},
				{'R', "R"},
				{'S', "S"},
				{'T', "T"},
				{'U', "9"},
				{'V', "V"},
				{'W', "W"},
				{'X', "X"},
				{'Y', "Y"},
				{'Z', "Z"}
			};
		}


		private static string GetUserInput()
		{
			string input = Console.ReadLine();

			try
			{
				if (!string.IsNullOrEmpty(input))
				{
					input = input.ToLower();
				}
			}
			catch (Exception ex)
			{

				Console.WriteLine(ex.ToString());
			}


			return input;
		}

		private static string Translate(string input)
		{
			StringBuilder stringBuilder = new StringBuilder();

			try
			{

				foreach (char character in input)
				{
					if (_morseAlphabetDictionary.ContainsKey(character))
					{
						stringBuilder.Append(_morseAlphabetDictionary[character] + " ");
					}
					else if (character == ' ')
					{
						stringBuilder.Append("/ ");
					}
					else
					{
						stringBuilder.Append(character + " ");
					}
				}
			}
			catch (Exception ex)
			{

				Console.WriteLine(ex.ToString());
			}


			return stringBuilder.ToString();
		}


		private static string BaceDifogu(string input)
		{
			StringBuilder stringBuilder = new StringBuilder();
			input = input.ToUpper();
			try
			{
				foreach (char character in input)
				{
					if (_basedifogu.ContainsKey(character))
					{
						stringBuilder.Append(_basedifogu[character] + " ");
					}
					else if (character == ' ')
					{
						stringBuilder.Append("/ ");
					}
					else
					{
						stringBuilder.Append(character + " ");
					}
				}
			}
			catch (Exception ex)
			{

				Console.WriteLine(ex.ToString());
			}


			return stringBuilder.ToString();

		}

		//Octal:
		public static string valorOctal(string str)
		{
			string oct = string.Empty;

			try
			{
				for (int i = 0; i < str.Length; ++i)
				{
					string cOct = aOctal(str[i]);

					if (cOct.Length < 3)
						cOct = cOct.PadLeft(3, '0');

					oct += cOct;
				}
			}
			catch (Exception ex)
			{

				Console.WriteLine(ex.ToString());
			}

			return oct;
		}

		private static string aOctal(int valor)
		{
			if (valor < 1) return "0";
			string octStr = string.Empty;

			try
			{
				while (valor > 0)
				{
					octStr = octStr.Insert(0, (valor % 8).ToString());
					valor /= 8;
				}
			}
			catch (Exception ex)
			{

				Console.WriteLine(ex.ToString());
			}

			return octStr;
		}

	}
}
