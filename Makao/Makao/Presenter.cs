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
            view.PullCard += View_PullCard;
            view.Stop += View_Stop;
        }

        private void View_Stop(Panel pan)
        {
            model.Stop(pan);
        }

        private void View_PullCard(Panel pan)
        {
            model.PullCard(pan);
        }

        private void View_LoadCards(Panel pan)
        {
            model.Tasowanie(pan);
            model.DodajGraczy(2,pan);
            model.RozpocznijGre(pan);
        }
    }
}
