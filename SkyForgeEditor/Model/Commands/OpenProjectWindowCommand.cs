using SkyForgeEditor.Model.Commands.Base;
using SkyForgeEditor.ViewModel;
using System.Windows;


namespace SkyForgeEditor.Model.Commands
{
    internal class OpenProjectWindowCommand : BaseCommand
    {
        private readonly Thickness POSITION_WINDOW_PROJECT = new Thickness(0, 0, 0, 0);

        private ProjectBrowserWindowViewModel m_viewModel;

        internal OpenProjectWindowCommand(ProjectBrowserWindowViewModel viewModel)
        {
            m_viewModel = viewModel;
        }

        public override bool CanExecute(object? parameter)
        {
            return true;
        }

        public override void Execute(object? parameter)
        {
            m_viewModel.PositionWidnowStack = POSITION_WINDOW_PROJECT;
        }
    }
}
