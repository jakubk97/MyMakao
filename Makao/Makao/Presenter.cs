using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Makao
{
    class Presenter
    {
        IView view;
        Model model;
        public Presenter(IView view, Model model)
        {
            this.model = model;
            this.view = view;
            view.StartGame += View_StartGame;
            view.LoadInstruction += View_LoadInstruction;
            view.LoadWelcome += View_LoadWelcome;
        }

        private void View_LoadWelcome(Powitalna p1)
        {
            model.LoadWelcome();
        }

        private void View_LoadInstruction(Instrukcja i1)
        {
            model.LoadInstruction();
        }

        private void View_StartGame(Gra g1)
        {
            model.StartGame();
        }

    }
}
