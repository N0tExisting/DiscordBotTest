using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using DSharpPlus;
using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;

namespace DiscordBotTest.Commands
{
	class MathCommands
	{
		[Command("Add")]
		public async Task Add(CommandContext ctx)
		{
			await ctx.Channel.SendMessageAsync("Pong").ConfigureAwait(false);
		}
		[Command("Subtract")]
		public async Task Subtract(CommandContext ctx)
		{
			await ctx.Channel.SendMessageAsync("Pong").ConfigureAwait(false);
		}
		[Command("Multiply")]
		public async Task Multiply(CommandContext ctx)
		{
			await ctx.Channel.SendMessageAsync("Pong").ConfigureAwait(false);
		}
		[Command("Divide")]
		public async Task Divide(CommandContext ctx)
		{
			await ctx.Channel.SendMessageAsync("Pong").ConfigureAwait(false);
		}
		[Command("LinEqu")]
		public async Task LineearEquasion(CommandContext ctx){
			await ctx.Channel.SendMessageAsync("Pong").ConfigureAwait(false);
			return;
			//variables
			bool test = true;
			string[] lines = new string[2];
			double[,] vars = new double[2, 3];
			double Dn, Dx, Dy;
			//input
			if (!test){
				Console.WriteLine("input first equasion");
				lines[0] = Console.ReadLine();
				Console.WriteLine("input second equasion");
				lines[1] = Console.ReadLine();
			}
			else{
				lines[0] = "1x+1y=22,5";
				lines[1] = "2,5x+1y=6";
			}
			//inputhandling
			for (int i = 0; i < lines.Length; i++){
				int[] p = new int[4];
				p[0] = lines[i].IndexOf('x');
				p[1] = lines[i].IndexOf('y');
				p[2] = lines[i].IndexOf('=') + 1;
				p[3] = lines[i].IndexOf('+') + 1;
				try{
					Console.Write($"A{i} = {lines[i].Substring(0, p[0])};");
					Console.Write($"B{i} = {lines[i][p[3]..p[1]]};");
					Console.Write($"C{i} = {lines[i].Substring(p[2])};");
				}
				catch (ArgumentOutOfRangeException e){
					Console.WriteLine("error: wariable missing\n" + e.ToString());
					return;
				}
				//conversion to number
				try{
					vars[i, 0] = Convert.ToDouble(lines[i].Substring(0, p[0]));             //0 = a from ax
				}
				catch (FormatException){
					try{
						vars[i, 0] = (double)Convert.ToInt32(lines[i].Substring(0, p[0]));
					}
					catch (FormatException e){
						Console.WriteLine("error: wrong input\n" + e.ToString());
						return;
					}
				}
				try{
					vars[i, 1] = Convert.ToDouble(lines[i][p[3]..p[1]]);                    //1 = b from by
				}
				catch (FormatException){
					try{
						vars[i, 1] = (double)Convert.ToInt32(lines[i][p[3]..p[1]]);
					}
					catch (FormatException e){
						Console.WriteLine("error: wrong input\n" + e.ToString());
						return;
					}
				}
				try{
					vars[i, 2] = Convert.ToDouble(lines[i].Substring(p[2]));                //2 = c
				}
				catch (FormatException){
					try{
						vars[i, 2] = (double)Convert.ToInt32(lines[i].Substring(p[2]));
					}
					catch (FormatException e){
						Console.WriteLine("error: wrong input\n" + e.ToString());
						return;
					}
				}
				Console.WriteLine();
			}
			//math
			Dn = vars[0, 0] * vars[1, 1] - vars[0, 1] * vars[1, 0]; //0 = a from ax
			Dx = vars[0, 2] * vars[1, 1] - vars[0, 1] * vars[1, 2]; //1 = b from by
			Dy = vars[0, 0] * vars[1, 2] - vars[0, 2] * vars[1, 0]; //2 = c
			//Dn
			Console.WriteLine($"     |{vars[0, 0]} {vars[0, 1]}|");
			Console.WriteLine($"Dn = |{vars[1, 0]} {vars[1, 1]}| = {vars[0, 0]} * {vars[1, 1]} - {vars[0, 1]} * {vars[1, 0]} = {Dn}");
			//Dx
			Console.WriteLine($"     |{vars[0, 2]} {vars[0, 1]}|");
			Console.WriteLine($"Dx = |{vars[1, 2]} {vars[1, 1]}| = {vars[0, 2]} * {vars[1, 1]} - {vars[0, 1]} * {vars[1, 2]} = {Dx}");
			//Dy
			Console.WriteLine($"     |{vars[0, 0]} {vars[0, 2]}|");
			Console.WriteLine($"Dy = |{vars[1, 0]} {vars[1, 2]}| = {vars[0, 0]} * {vars[1, 2]} - {vars[0, 2]} * {vars[1, 0]} = {Dy}");
			//output
			if (Dn == 0)
				if (Dx == Dy && Dx == 0)
					Console.WriteLine("Both equasions are the same"/*\nIL={(x|y)|" +  + "x" + "y" + "}"*/);
				else
					Console.WriteLine("There is no solution\n|L={}");
			else
				Console.WriteLine("|L={(" + (Dx / Dn).ToString() + "|" + (Dy / Dn).ToString() + ")}");
		}
	}
}