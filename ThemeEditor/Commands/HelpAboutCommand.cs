using System;
using System.Windows;
using System.Windows.Input;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ThemeEditor
{
    public class HelpAboutCommand :
        ICommand
    {
        private ThemeEditorViewModel _ThemeEditorViewModel = default(ThemeEditorViewModel);

        public HelpAboutCommand(ThemeEditorViewModel themeEditorViewModel)
        {
            _ThemeEditorViewModel = themeEditorViewModel;
        }

        public Boolean CanExecute(object parameter)
        {
            return (true);
        }

        public event EventHandler CanExecuteChanged
        {
            add { throw new NotSupportedException(); }
            remove { }
        }

        public void Execute(object parameter)
        {
            //call viewmodel here
            if (CanExecute(null))
            {
                _ThemeEditorViewModel.HelpAbout();
            }
        }
    }
}
