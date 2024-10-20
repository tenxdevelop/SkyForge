/**************************************************************************\
   Copyright SkyForge Corporation. All Rights Reserved.
\**************************************************************************/

using SkyForgeEditor.Infrastructure.Extentions.Commands;
using SkyForgeEditor.Infrastructure.Reactive.WPF;
using SkyForgeEditor.Infrastructure.Reactive;
using SkyForgeEditor.ViewModels.Base;
using System.Windows.Input;
using System.Windows;

namespace SkyForgeEditor.ViewModels
{
    public class CreateProjectPageViewModel : BaseViewModel
    {
        public ICommand CancelCommand { get; private set; }
        public ICommand ProjectsCommand { get; private set; }
        public ICommand CloseApplicationCommand { get; private set; }
        public ReactivePropertyWPF<string> NewNameProject { get; private set; } = new ();

        public CreateProjectPageViewModel()
        {
            
        }

        public CreateProjectPageViewModel(Action<object> openProjectsCallBack)
        {
            CancelCommand = new LamdaCommand(openProjectsCallBack);
            ProjectsCommand =  new LamdaCommand(openProjectsCallBack);

            CloseApplicationCommand = new LamdaCommand(OnCloseApplicationCommand);
            NewNameProject.Subscribe(WriteProjectName);
        }

        private void OnCloseApplicationCommand(object sender)
        {
            Application.Current.Shutdown();
        }

        private void WriteProjectName(string value)
        {
            Console.WriteLine(value);
        }
    }
}
