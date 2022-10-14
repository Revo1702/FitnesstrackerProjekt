using Model;
using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Controls;
using System.Windows.Data;
using static DataAccess.DBAccess;

namespace FitnesstrackerMVVMSwitching.ViewModels
{
    class NeueUebungHinzufuegenViewModel
    {
        private DelegateCommand _exerciseCommand;
        StackPanel StackPanel = new StackPanel();


        public DelegateCommand ExerciseCommand => _exerciseCommand ?? (_exerciseCommand = new DelegateCommand(Exercise));

        void Exercise()
        {

        }

        public NeueUebungHinzufuegenViewModel()
        {
            List<Uebungen> uebungen = new List<Uebungen>(ReadAllExercises());
            int zaehler = 0;
            foreach (var i in uebungen)
            {
                Binding binding = new Binding();
                binding.Path = new System.Windows.PropertyPath("ExerciseCommand");
                string trimmedName = String.Concat(i.Name.Where(c => !Char.IsWhiteSpace(c)));
                Button btn = new Button
                {
                    Name = trimmedName,
                    Content = i.Name,
                    Width = 200,
                    Height = 100
                };
                btn.SetBinding(Button.CommandProperty, binding);
                Grid.SetColumn(btn, 0);
                Grid.SetRow(btn, zaehler);
                StackPanel.Children.Add(btn);
                zaehler++;
            }
        }
    }
}
