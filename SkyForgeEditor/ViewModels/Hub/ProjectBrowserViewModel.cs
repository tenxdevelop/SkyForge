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

        public ProjectBrowserViewModel()
        {
            m_projectPage = new ProjectsPage();
            //m_projectPage.DataContext = new ProjectsPageViewModel();

            CurrentPage.SetValue(this, m_projectPage);
        }
    }
}
