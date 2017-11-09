using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Menu
    {
        private List<string> Text { get; set; } = new List<string> { };
        private List<Option> Options { get; set; } = new List<Option> { };
        private int SelectedIndex { get; set; } = 0;

        public Menu()
        {
            Text.AddRange(new List<string> {
                { "**************************************************************************************************************" },
                { "*                                                                                                            *" },
                { "*                                                                                                            *" },
                { "*                                                                                                            *" },
                { "**************************************************************************************************************" },
                { "*                                                                                                            *" },
                { "*                                                                                                            *" },
                { "*                                                                                                            *" },
                { "**************************************************************************************************************" },
                { "*                                                                                                            *" },
                { "*                                                                                                            *" },
                { "*                                                                                                            *" },
                { "**************************************************************************************************************" },
            });
        }

        public void InsertText(string text)
        {
            string[] lines = MenuStringFormater.InsertNormal(text).ToArray();
            for (int i = lines.Length; i > 0; i--)
            {
                Text.Insert(Text.Count - 3, MenuStringFormater.InsertNormal(text)[i - 1]);
            }
        }

        public void ChangeHeading(string headingText)
        {
            Text[2] = MenuStringFormater.InsertCentered(headingText);
        }

        public void ExecuteCommand()
        {
            Options[SelectedIndex].PerformAction(this);
        }

        public void Display()
        {
            foreach (string line in Text)
            {
                Console.WriteLine(line);
            }
        }

        public void AddOption(Option option)
        {
            option.RowIndex = GetNextOptionIndex();
            Options.Add(option);
            Text.Insert(option.RowIndex, MenuStringFormater.Insert("    " + (Options.Count).ToString() + "| " + option.GetTitle(), 15));
            MoveSelection(0);
        }

        private void MoveSelection(int index)
        {
            RemoveSelection(Options[SelectedIndex].RowIndex);
            SelectedIndex = index;
            SetSelection(Options[index].RowIndex);
        }

        public void NextOption()
        {
            if (SelectedIndex - 1 < 0)
            {
                MoveSelection(Options.Count - 1);
            }
            else
            {
                MoveSelection(SelectedIndex - 1);
            }
        }

        public void PreviousOption()
        {

            if (SelectedIndex + 1 > Options.Count - 1)
            {
                MoveSelection(0);
            }
            else
            {
                MoveSelection(SelectedIndex + 1);
            }
        }

        private void SetSelection(int optionIndex)
        {
            Text[optionIndex] = MenuStringFormater.InsertSelector(Text[optionIndex]);
        }

        private void RemoveSelection(int optionIndex)
        {
            Text[optionIndex] = MenuStringFormater.RemoveSelector(Text[optionIndex]);
        }

        private int GetNextOptionIndex()
        {
            int result = Options.Count + 6;
            return result;
        }

        public List<Option> GetOptions()
        {
            return Options;
        }
    }
}
