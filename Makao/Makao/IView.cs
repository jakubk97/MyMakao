using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Makao
{
    interface IView
    {
        #region Events

        event Action StartGame;
        event Action LoadInstruction;
        event Action LoadWelcome;
        event Action<Panel> LoadCards;
        event Action<Panel> PullCard;
        event Action<Panel> Stop;

        #endregion
    }
}
