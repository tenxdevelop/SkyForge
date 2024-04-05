using SkyForgeEditor.Extentions;
using SkyForgeEditor.Model;
using SkyForgeEditor.Model.Commands;
using SkyForgeEditor.ViewModel.Base;
using System.Collections.ObjectModel;
using System.IO;
using System.Windows;
using System.Windows.Input;

namespace SkyForgeEditor.ViewModel
{
    internal class ProjectBrowserWindowViewModel : BaseViewModel
    {
        private readonly Thickness POSITION_WINDOW_CREATE_PROJECT = new Thickness(-880, 0, 0, 0);
        private readonly Thickness POSITION_WINDOW_PROJECT = new Thickness(0, 0, 0, 0);

        // TODO: get the path from the instalkation location 
        private readonly string m_templatePath = @"..\..\..\SkyForgeEditor\Data\ProjectTemplates";

        public ReadOnlyObservableCollection<ProjectTemplate>? ProjectTempaltes { get; private set; }
        public Thickness PositionWidnowStack { get => m_positionWindowStack; set => Set(ref m_positionWindowStack, value); }
        public string NewProjectName { get => m_newProjectName; set => Set(ref m_newProjectName, value); }
        public string NewProjectPath { get => m_newProjectPath; set => Set(ref m_newProjectPath, value); }
        public ICommand OpenCreateProjectWindow { get; }
        public ICommand OpenProjectWindow { get; }

        public ICommand CancelCreateProjectCommand { get; }

        private ObservableCollection<ProjectTemplate>? m_projectTemplates;
        private Thickness m_positionWindowStack;
        private string m_newProjectName;
        private string m_newProjectPath;

        public ProjectBrowserWindowViewModel()
        {

            m_positionWindowStack = POSITION_WINDOW_CREATE_PROJECT;
            m_newProjectName = "NewProject";
            m_newProjectPath = $@"{Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)}\SkyForgeProject\";

            LoadTemplateProject();

            OpenCreateProjectWindow = new LamdaCommand(OpenCreateProjectWindowExecuteCommand);
            OpenProjectWindow = new LamdaCommand(OpenProjectWindowExecuteCommand);
            CancelCreateProjectCommand = new LamdaCommand(OpenProjectWindowExecuteCommand);
        }

        private void OpenCreateProjectWindowExecuteCommand(object sender)
        {
            PositionWidnowStack = POSITION_WINDOW_CREATE_PROJECT;
        }

        private void OpenProjectWindowExecuteCommand(object sender)
        {
            PositionWidnowStack = POSITION_WINDOW_PROJECT;
        }


        private void LoadTemplateProject()
        {
            m_projectTemplates = new ObservableCollection<ProjectTemplate>();
            ProjectTempaltes = new ReadOnlyObservableCollection<ProjectTemplate>(m_projectTemplates);
            var files = Directory.GetFiles(m_templatePath, "template.xml", SearchOption.AllDirectories);
            foreach (var file in files)
            {
                var template = Serializer.FromFile<ProjectTemplate>(file);
                template.IconFilePath = Path.GetFullPath(Path.Combine(Path.GetDirectoryName(file), "Icon.png"));
                template.Icon = File.ReadAllBytes(template.IconFilePath);
                template.ScreenshotFilePath = Path.GetFullPath(Path.Combine(Path.GetDirectoryName(file), "Screenshot.png"));
                template.Screenshot = File.ReadAllBytes(template.ScreenshotFilePath);
                template.ProjectFilePath = Path.GetFullPath(Path.Combine(Path.GetDirectoryName(file), template.ProjectFile));
                m_projectTemplates.Add(template);
            }
        }
    }
}
