using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YachtClub.controller
{
    class MainController
    {
        private view.StartMenuView _startMenu = new view.StartMenuView();

        public void DoRun()
        {
            _startMenu.ShowStartMenu();
            var option = _startMenu.GetStartMenuOption();
        }
    }
}
