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
        }

        private void View_LoadInstruction()
        {
            model.LoadInstruction();
        }

        private void View_StartGame()
        {
            model.StartGame();
        }

    }
}
