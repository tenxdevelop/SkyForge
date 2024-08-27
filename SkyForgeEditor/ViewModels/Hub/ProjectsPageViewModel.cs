
using SkyForgeEditor.Infrastructure.Extentions.Commands;
using SkyForgeEditor.ViewModels.Base;
using System.Windows.Input;
using System.Windows;

namespace SkyForgeEditor.ViewModels
{
    public class ProjectsPageViewModel : BaseViewModel
    {
        public ICommand CloseApplicationCommand { get; private set; }

        public ICommand NewProjectCommand { get; private set; }

        public ProjectsPageViewModel()
        {

        }

        public ProjectsPageViewModel(Action<object> NewProjectCallBack)
        {
            CloseApplicationCommand = new LamdaCommand(OnCloseApplicationCommand);
            NewProjectCommand = new LamdaCommand(NewProjectCallBack);
        }

        private void OnCloseApplicationCommand(object sender)
        {
            Application.Current.Shutdown();
        }

    }
}
