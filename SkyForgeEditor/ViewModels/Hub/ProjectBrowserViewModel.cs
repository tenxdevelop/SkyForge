using SkyForgeEditor.Infrastructure.Reactive.WPF;
using SkyForgeEditor.ViewModels.Base;
using SkyForgeEditor.Views.Windows;
using System.Windows.Controls;

namespace SkyForgeEditor.ViewModels
{
    public class ProjectBrowserViewModel : BaseViewModel
    {
        public ReactiveProperty<Page> CurrentPage { get; private set; } = new();

        private ProjectsPage m_projectPage;
        private CreateProjectPage m_createProjectPage;

        public ProjectBrowserViewModel()
        {
            m_projectPage = new ProjectsPage();
            m_projectPage.DataContext = new ProjectsPageViewModel(OnNewProjectCommand);

            m_createProjectPage = new CreateProjectPage();
            m_createProjectPage.DataContext = new CreateProjectPageViewModel(OnOpenProjectsCommand);

            CurrentPage.SetValue(this, m_projectPage);
        }

        private void OnNewProjectCommand(object sender)
        {
            CurrentPage.SetValue(this, m_createProjectPage);
        }

        private void OnOpenProjectsCommand(object sender)
        {
            CurrentPage.SetValue(this, m_projectPage);
        }
    }
}
