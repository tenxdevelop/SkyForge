
using SkyForgeEditor.Infrastructure.Extentions.Commands;
using SkyForgeEditor.ViewModels.Base;
using System.Windows;
using System.Windows.Input;

namespace SkyForgeEditor.ViewModels
{
    public class ProjectsPageViewModel : BaseViewModel
    {
        public ICommand CloseApplicationCommand { get; private set; }
        public ProjectsPageViewModel()
        {
            CloseApplicationCommand = new LamdaCommand(OnCloseApplicationCommand);
        }

        private void OnCloseApplicationCommand(object sender)
        {
            Application.Current.Shutdown();
        }

    }
}
