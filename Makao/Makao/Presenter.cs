using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

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
            view.LoadCards += View_LoadCards;
        }

        private void View_LoadCards(Panel pan)
        {
            model.WczytajKarty(pan);
        }
    }
}
