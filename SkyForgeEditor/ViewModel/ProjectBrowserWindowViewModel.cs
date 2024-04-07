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
        public string NewProjectName { get => m_newProjectName; set{ Set(ref m_newProjectName, value); ValidateProjectPath(); } }
        public string NewProjectPath { get => m_newProjectPath; set{ Set(ref m_newProjectPath, value); ValidateProjectPath(); } }
        public string ErrorMassageValidateProjectPath { get => m_errorMassageValidateProjectPath; set => Set(ref m_errorMassageValidateProjectPath, value); }
        public bool IsValidProjectPath { get => m_isValidPath; set => Set(ref m_isValidPath, value); }
        public ICommand OpenCreateProjectWindow { get; }
        public ICommand OpenProjectWindow { get; }
        public ICommand CreateProject { get; }
        public ICommand CancelCreateProjectCommand { get; }

        private ObservableCollection<ProjectTemplate>? m_projectTemplates;
        private Thickness m_positionWindowStack;
        private string m_newProjectName;
        private string m_newProjectPath;
        private string m_errorMassageValidateProjectPath;
        private bool m_isValidPath;
        private DependencyObject m_dependencyWindow;
        public ProjectBrowserWindowViewModel(DependencyObject dependency)
        {
            m_dependencyWindow = dependency;
            m_positionWindowStack = POSITION_WINDOW_PROJECT;
            m_newProjectName = "NewProject";
            m_isValidPath = true;
            m_errorMassageValidateProjectPath = string.Empty;
            m_newProjectPath = $@"{Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)}\SkyForge Projects\";

            LoadTemplateProject();
            ValidateProjectPath();

            OpenCreateProjectWindow = new LamdaCommand(OpenCreateProjectWindowExecuteCommand);
            OpenProjectWindow = new LamdaCommand(OpenProjectWindowExecuteCommand);
            CancelCreateProjectCommand = new LamdaCommand(OpenProjectWindowExecuteCommand);
            CreateProject = new LamdaCommand(CreateProjectCommand);
        }

        public string CreateProjects(ProjectTemplate template)
        {
            if (!ValidateProjectPath())
                return string.Empty;

            if (!Path.EndsInDirectorySeparator(m_newProjectPath))
                NewProjectPath += @"\";
            var path = $@"{m_newProjectPath}{m_newProjectName}\";
            try
            {
                if(!Directory.Exists(path))
                    Directory.CreateDirectory(path);

                foreach(var folder in template.Folders)
                    Directory.CreateDirectory(Path.GetFullPath(Path.Combine(Path.GetDirectoryName(path), folder)));

                var dirInfo = new DirectoryInfo(path + @".Skyforge");
                dirInfo.Attributes |= FileAttributes.Hidden;
                File.Copy(template.IconFilePath, Path.GetFullPath(Path.Combine(dirInfo.FullName, "Icon.png")));
                File.Copy(template.ScreenshotFilePath, Path.GetFullPath(Path.Combine(dirInfo.FullName, "Screenshot.png")));

                var projectXml = File.ReadAllText(template.ProjectFilePath);
                projectXml = string.Format(projectXml, NewProjectName, NewProjectPath);
                var projectPath = Path.GetFullPath(Path.Combine(path, $"{NewProjectName}{ProjectViewModel.Extentions}"));
                File.WriteAllText(projectPath, projectXml);
                return path;
            }
            catch (Exception ex)
            {
                //TODO get the log error

                return string.Empty;
            }
        }

        private void CreateProjectCommand(object sender)
        {
            var template = sender as ProjectTemplate;
            var projectPath = CreateProjects(template);
            var dialogResult = !string.IsNullOrEmpty(projectPath);
            var win = Window.GetWindow(m_dependencyWindow);
            win.DialogResult = dialogResult;
            win.Close();
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

        private bool ValidateProjectPath()
        {
            var path = m_newProjectPath;
            if (!Path.EndsInDirectorySeparator(path))
                path += @"\";
            path += $@"{m_newProjectName}\";
            IsValidProjectPath = false;

            if (string.IsNullOrEmpty(m_newProjectPath.Trim()))
            {
                ErrorMassageValidateProjectPath = "Select a valid project path.";
            }
            else if (m_newProjectPath.IndexOfAny(Path.GetInvalidPathChars()) != -1)
            {
                ErrorMassageValidateProjectPath = "Invalid chareacter(s) used in project path.";
            }
            else if (string.IsNullOrEmpty(m_newProjectName.Trim()))
            {
                ErrorMassageValidateProjectPath = "Type in a project name.";
            }
            else if (m_newProjectName.IndexOfAny(Path.GetInvalidFileNameChars()) != -1)
            {
                ErrorMassageValidateProjectPath = "Invalid character(s) used in project name.";
            }
            else if (Directory.Exists(path) && Directory.EnumerateFileSystemEntries(path).Any())
            {
                ErrorMassageValidateProjectPath = "Selected project folder already exists and is not empty.";
            }
            else
            {
                ErrorMassageValidateProjectPath = string.Empty;
                IsValidProjectPath = true;
            }
            
            return m_isValidPath;
        }
    }
}
