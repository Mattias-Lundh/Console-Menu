using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
namespace ConsoleApp1
{
    class Program
    {
        public static Menu CurrentMenu { get; set; }

        static void Main(string[] args)
        {
            Console.CursorVisible = false;

            Option option4 = new Option("Beer");
            option4.AddAction(Option.ActionType.Print);
            option4.SetMessage("Refreshing");
            Option option5 = new Option("Wine");
            option5.AddAction(Option.ActionType.Print);
            option5.SetMessage("Because I deserve it");
            Option option6 = new Option("Whiskey");
            option6.AddAction(Option.ActionType.Print);
            option6.SetMessage("Celebrating");
            Option option7 = new Option("Shots");
            option7.AddAction(Option.ActionType.Print);
            option7.SetMessage("O oh, Im getting drunk, time to go home");

            Menu bar = new Menu { };
            bar.ChangeHeading("START MENU");
            bar.AddOption(option4);
            bar.AddOption(option5);
            bar.AddOption(option6);
            bar.AddOption(option7);            

            Option option1 = new Option("print Hello World!");
            option1.AddAction(Option.ActionType.Print);
            option1.SetMessage("Hello World!");
            Option option2 = new Option("print Hello");
            option2.AddAction(Option.ActionType.Print);
            option2.SetMessage("this is Hello: Hello");

            Option option3 = new Option("Go to bar");
            option3.AddAction(Option.ActionType.ChangeMenu);
            option3.SetLink(bar);

            Menu startMenu = new Menu { };
            startMenu.ChangeHeading("START MENU");           
            startMenu.AddOption(option1);
            startMenu.AddOption(option2);
            startMenu.AddOption(option3);

            CurrentMenu = startMenu;
            Run();           
        }

        public static void Run()
        {
            while (true)
            {
                CurrentMenu.Display();
                ConsoleKeyInfo key = Console.ReadKey();
                if (key.Key == ConsoleKey.UpArrow)
                {
                    Console.Clear();
                    CurrentMenu.NextOption();
                }
                else if (key.Key == ConsoleKey.DownArrow)
                {
                    Console.Clear();
                    CurrentMenu.PreviousOption();
                }
                else if (key.Key == ConsoleKey.Enter)
                {
                    Console.Clear();
                    CurrentMenu.ExecuteCommand();
                }
            }
        }
    }
}

