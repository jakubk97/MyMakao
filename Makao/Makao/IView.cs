﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Makao
{
    interface IView
    {
        #region Properties
        //string[] DirectoryContent { get; set; }
        //string[] Path { get; set; }
        //string[] Question { get; set; }

        #endregion

        #region Events
        event Action StartGame;
        event Action LoadInstruction;
        #endregion
    }
}
