using SkyForgeEditor.Infrastructure.Extentions.Commands;
using SkyForgeEditor.ViewModels.Base;
using System.Windows;
using System.Windows.Input;

namespace SkyForgeEditor.ViewModels
{
    public class CreateProjectPageViewModel : BaseViewModel
    {
        public ICommand CancelCommand { get; private set; }
        public ICommand ProjectsCommand { get; private set; }
        public ICommand CloseApplicationCommand { get; private set; }

        public CreateProjectPageViewModel()
        {

        }

        public CreateProjectPageViewModel(Action<object> openProjectsCallBack)
        {
            CancelCommand = new LamdaCommand(openProjectsCallBack);
            ProjectsCommand =  new LamdaCommand(openProjectsCallBack);

            CloseApplicationCommand = new LamdaCommand(OnCloseApplicationCommand);
        }

        private void OnCloseApplicationCommand(object sender)
        {
            Application.Current.Shutdown();
        }
    }
}
