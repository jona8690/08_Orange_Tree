﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _08_Orange_Tree;

namespace Interface {
	static class Program {
		static OrangeTree OT;

		private static bool gameActive = true;

		static void Main(string[] args) {
			OT = new OrangeTree(0, 6);
			Menu();
		}

		static void Menu() {
			Console.Clear();

			TreeStatus();

			if (gameActive) {
				Console.WriteLine("");
				Console.WriteLine("E. Eat Oranges");
				Console.WriteLine("G. Grow Tree a Year");
				Console.WriteLine("W. Water Tree");
			}

			Console.WriteLine("\nX. Exit");
			Console.WriteLine("- - - - - - - - - - - - - - -");
			Console.WriteLine("Write Menu number below:");

			char KeyPressed = Console.ReadKey().KeyChar;

			switch (Char.ToLower(KeyPressed)) {
				case 'e': EatOranges(); break;
				case 'g': GrowTree(); break;
				case 'w': WaterTree(); break;

				case 'x': System.Environment.Exit(1); break;
				default: Menu(); break;
			}
		}

		static void TreeStatus() {
			if (OT.TreeAlive) {
				Console.WriteLine("Your tree is " + OT.Age + " years old,");
				Console.WriteLine("and it is " + OT.Height + "m. tall.");
				Console.WriteLine("You also have " + OT.NumOranges + " Oranges.");
				WaterLevel();

			}
			if(!OT.TreeAlive) { 
				Console.WriteLine("\n\aYour Tree has died.");
				gameActive = false;
			}

			if(OT.NumOranges > 100) {
				Console.WriteLine("\n\aYour oranges has crushed you, and you died.");
				gameActive = false;
			}
		}

		static void WaterLevel() {
			Console.Write("Water: ");
			Console.Write("[");
			
			for (int i = 0; i <= 10; i++) {
				if (i <= ((int)OT.WaterLevel /10))
					Console.Write("=");
				else Console.Write(" ");
			}

			Console.Write("]\n");
		}

		static void EatOranges() {
			if (!gameActive) Menu();

			Console.WriteLine("How many Oranges do you want to eat?");
			int EatOranges = int.Parse(Console.ReadLine());
			OT.EatOrange(EatOranges);

			WaitForKey();
			Menu();
		}

		static void GrowTree() {
			if (!gameActive) Menu();

			OT.OneYearPasses();
			Menu();
		}

		static void WaterTree() {
			if (!gameActive) Menu();

			OT.WaterTree();
			Menu();
		}

		static void WaitForKey() {
			Console.WriteLine("\nPress any key to continue...");
			Console.ReadKey();
		}
	}
}
