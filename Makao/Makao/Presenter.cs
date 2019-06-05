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
            //view.LoadStartDirectory += View_LoadStartDirectory;
            //view.LoadTest += View_LoadTest; ;
            //view.LoadQuestion += View_LoadQuestion;
            //view.Delete += View_Delete;
            //view.Add += View_Add;
            //view.Save += View_Save;
        }

        //private void View_Save(string name, string question, string ans1, string ans2, string ans3, string ans4,
        //    string points, string cb1, string cb2, string cb3, string cb4, int index)
        //{
        //    model.Save(name, question, ans1, ans2, ans3, ans4, points, cb1, cb2, cb3, cb4, index);
        //}

        //private void View_Add(string name, string question, string ans1, string ans2, string ans3, string ans4,
        //    string points, string cb1, string cb2, string cb3, string cb4)
        //{
        //  model.Add(name, question, ans1, ans2, ans3, ans4, points, cb1, cb2, cb3, cb4);
        //}

        //private void View_Delete(string name, int index)
        //{
        //    model.Delete(name, index);
        //}

        //private void View_LoadQuestion(string name, int index)
        //{
        //    view.Question = model.LoadQuestion(name, index);
        //}

        //private void View_LoadTest(string name)
        //{
        //    view.Path = model.LoadTest(name);
        //}


        //#region Functions
        //private void View_LoadStartDirectory()
        //{
        //    view.DirectoryContent = model.LoadStartDirectory();
        //}
        //#endregion

    }
}
