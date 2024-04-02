using SkyForgeEditor.Model.Commands;
using SkyForgeEditor.ViewModel.Base;
using System.Windows;
using System.Windows.Input;

namespace SkyForgeEditor.ViewModel
{
    internal class ProjectBrowserWindowViewModel : BaseViewModel
    {
        private readonly Thickness POSITION_WINDOW_CREATE_PROJECT = new Thickness(-880, 0, 0, 0);
        private readonly Thickness POSITION_WINDOW_PROJECT = new Thickness(0, 0, 0, 0);
        private Thickness m_positionWindowStack;
        public Thickness PositionWidnowStack { get => m_positionWindowStack; set => Set(ref m_positionWindowStack, value); }
        public ICommand OpenCreateProjectWindow { get; }
        public ICommand OpenProjectWindow { get; }

        public ProjectBrowserWindowViewModel()
        {
            m_positionWindowStack = POSITION_WINDOW_PROJECT;
            OpenCreateProjectWindow = new LamdaCommand(OpenCreateProjectWindowExecuteCommand);
            OpenProjectWindow = new LamdaCommand(OpenProjectWindowExecuteCommand);
        }

        private void OpenCreateProjectWindowExecuteCommand(object sender)
        {
            PositionWidnowStack = POSITION_WINDOW_CREATE_PROJECT;
        }

        private void OpenProjectWindowExecuteCommand(object sender)
        {
            PositionWidnowStack = POSITION_WINDOW_PROJECT;
        }
    }
}
