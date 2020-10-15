using System;
using System.Text;
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
		[Description("Adds two numbers together")]
		public async Task Add(CommandContext ctx,
		[Description("first number")] double numOne,
		[Description("second number")] double numTwo)
		{
			await ctx.Channel.SendMessageAsync((numOne + numTwo).ToString()).ConfigureAwait(false);
		}
		[Command("Subtract")]
		[Description("Subtracts two numbers together")]
		public async Task Subtract(CommandContext ctx,
		[Description("first number")] double numOne,
		[Description("second number")] double numTwo)
		{
			await ctx.Channel.SendMessageAsync((numOne - numTwo).ToString()).ConfigureAwait(false);
		}
		[Command("Multiply")]
		[Description("Multiplys two numbers together")]
		public async Task Multiply(CommandContext ctx,
		[Description("first number")] double numOne,
		[Description("second number")] double numTwo)
		{
			await ctx.Channel.SendMessageAsync((numOne * numTwo).ToString()).ConfigureAwait(false);
		}
		[Command("Divide")]
		[Description("Divides two numbers together")]
		public async Task Divide(CommandContext ctx,
		[Description("first number")] double numOne,
		[Description("second number")] double numTwo){
			if (numTwo == 0)
			{
				await ctx.Channel.SendMessageAsync("**Error:**\nCan not divide by zero");
				return;
			}
			double d = numOne / numTwo;
			await ctx.Channel.SendMessageAsync(d.ToString()).ConfigureAwait(false);
		}
		[Command("LinEqu")]
		[Description("Solves a LinearEquasion formated like this: 1x+1y=22,5^2,5x+1y=6")]
		public async Task LinearEquasion(CommandContext ctx, string args)
		{
			//variables
			string Output = string.Empty;
			string[] lines = new string[2];
			double[,] vars = new double[2, 3];
			double Dn, Dx, Dy;
			if (args.ToLower() == "help")
			{
				await ctx.Channel.SendMessageAsync("**Format like this:** 1x+1y=22,5^2,5x+1y=6");
				return;
			}
			//inputhandling
			lines[0] = args.Substring(0, args.IndexOf('^'));
			lines[1] = args.Substring(args.IndexOf('^') + 1);
			for (int i = 0; i < lines.Length; i++){
				int[] p = new int[4];
				p[0] = lines[i].IndexOf('x');
				p[1] = lines[i].IndexOf('y');
				p[2] = lines[i].IndexOf('=') + 1;
				p[3] = lines[i].IndexOf('+') + 1;
				try{
					Output += $"A{i+1} = {lines[i].Substring(0, p[0])}; ";	//0 = a from ax
					Output += $"B{i+1} = {lines[i][p[3]..p[1]]}; ";			//1 = b from by
					Output += $"C{i+1} = {lines[i].Substring(p[2])};";		//2 = c
				}catch (ArgumentOutOfRangeException e){
					await ctx.Channel.SendMessageAsync($"error: wariable missing\n{e}");
					return;
				}//conversion to number
				try{
					vars[i, 0] = Convert.ToDouble(lines[i].Substring(0, p[0]));
				}catch (FormatException){
					try{
						vars[i, 0] = (double)Convert.ToInt32(lines[i].Substring(0, p[0]));
					}catch (FormatException e){
						await ctx.Channel.SendMessageAsync($"error: wrong input\n{e}");
						return;
					}
				}try{
					vars[i, 1] = Convert.ToDouble(lines[i][p[3]..p[1]]);                    //1 = b from by
				}catch (FormatException){
					try{
						vars[i, 1] = (double)Convert.ToInt32(lines[i][p[3]..p[1]]);
					}catch (FormatException e){
						await ctx.Channel.SendMessageAsync("error: wrong input\n" + e.ToString());
						return;
					}
				}
				try{
					vars[i, 2] = Convert.ToDouble(lines[i].Substring(p[2]));                //2 = c
				}catch (FormatException){
					try{
						vars[i, 2] = (double)Convert.ToInt32(lines[i].Substring(p[2]));
					}catch (FormatException e){
						await ctx.Channel.SendMessageAsync("error: wrong input\n" + e.ToString());
						return;
					}
				}
				Output += "\n";
			}
			//math
			Dn = vars[0, 0] * vars[1, 1] - vars[0, 1] * vars[1, 0]; //0 = a from ax
			Dx = vars[0, 2] * vars[1, 1] - vars[0, 1] * vars[1, 2]; //1 = b from by
			Dy = vars[0, 0] * vars[1, 2] - vars[0, 2] * vars[1, 0]; //2 = c
			//Dn
			Output += $"          |{vars[0, 0]} {vars[0, 1]}|\n";
			Output += $"Dn = |{vars[1, 0]} {vars[1, 1]}| = {vars[0, 0]} * {vars[1, 1]} - {vars[0, 1]} * {vars[1, 0]} = {Dn}\n\n";
			//Dx
			Output += $"          |{vars[0, 2]} {vars[0, 1]}|\n";
			Output += $"Dx = |{vars[1, 2]} {vars[1, 1]}| = {vars[0, 2]} * {vars[1, 1]} - {vars[0, 1]} * {vars[1, 2]} = {Dx}\n\n";
			//Dy
			Output += $"          |{vars[0, 0]} {vars[0, 2]}|\n";
			Output += $"Dy = |{vars[1, 0]} {vars[1, 2]}| = {vars[0, 0]} * {vars[1, 2]} - {vars[0, 2]} * {vars[1, 0]} = {Dy}\n";
			//output
			if (Dn == 0)
				if (Dx == Dy && Dx == 0)
					Output += "Both equasions are the same\n"/*\nIL={(x|y)|" +  + "x" + "y" + "}"*/;
				else
					Output += "There is no solution\n╙={}\n";
			else
				Output += $"╙={{({Dx / Dn}|{Dy / Dn})}}\n";
			await ctx.Channel.SendMessageAsync(Output);
		}
	}
}