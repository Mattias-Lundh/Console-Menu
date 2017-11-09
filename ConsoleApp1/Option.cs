using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Option
    {
        public enum ActionType { Print, ChangeMenu }
        private string Title { get; set; }
        private string Message { get; set; }
        private Menu Caller { get; set; }
        private Menu Link { get; set; }
        private List<ActionType> Actions { get; set; } = new List<ActionType> { };
        public int RowIndex { get; set; }
        
        public Option(string text)
        {
            Title = text;
        }
        public string GetTitle()
        {
            return Title;
        }

        public void SetLink(Menu menu)
        {
            Link = menu;
        }
        public void SetMessage(string message)
        {
            Message = message;
        }

        public void PerformAction(Menu menu)
        {
            foreach (ActionType action in Actions)
            {
                switch (action)
                {
                    case ActionType.Print:
                        PrintAction(menu);
                        break;
                    case ActionType.ChangeMenu:
                        ChangeMenuAction(menu);
                        break;
                }
            }
        }

        private void ChangeMenuAction(Menu menu)
        {
            Option option = new Option("BACK");
            option.AddAction(ActionType.ChangeMenu);
            option.SetLink(menu);
            option.Caller = menu;

            if(Link.GetOptions().All(x => x.Title != "BACK") && Link != Caller)
            {
                Link.AddOption(option);
            }
            Program.CurrentMenu = Link;
        }

        private void PrintAction(Menu menu)
        {
            menu.InsertText(Message);
        }

        public void AddAction(ActionType type)
        {
            Actions.Add(type);
        }

        public void AddAction(ActionType type, Menu menu)
        {
            Actions.Add(type);
            if (type == ActionType.ChangeMenu)
            {
                Link = menu;
            }
        }
    }
}
