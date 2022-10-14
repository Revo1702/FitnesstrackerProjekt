using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Controls;
using static DataAccess.DBAccess;

namespace FitnesstrackerMVVMSwitching.ViewModels
{
    class NeueUebungHinzufuegenViewModel
    {
        public NeueUebungHinzufuegenViewModel()
        {
            Grid gridMain = new Grid();
            List<Uebungen> uebungen = new List<Uebungen>(ReadAllExercises());
            int zaehler = 0;
            foreach(var i in uebungen)
            {
                string trimmedName = String.Concat(i.Name.Where(c => !Char.IsWhiteSpace(c)));
                Button btn = new Button();
                btn.Name = trimmedName;
                btn.Content = i.Name;
                btn.Width = 200;
                btn.Height = 100;
                Grid.SetColumn(btn, 0);
                Grid.SetRow(btn, zaehler);
                gridMain.Children.Add(btn);
            }
        }
    }
}
