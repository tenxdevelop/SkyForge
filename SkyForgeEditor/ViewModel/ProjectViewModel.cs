using SkyForgeEditor.ViewModel.Base;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SkyForgeEditor.ViewModel
{
    [DataContract(Name = "Game")]
    internal class ProjectViewModel : BaseViewModel
    {
        public static string Extentions { get; private set; } = ".skyforge";

        public ReadOnlyObservableCollection<SceneViewModel> Scenes { get; private set; }

        [DataMember]
        public string Name { get; private set; }

        [DataMember]
        public string Path { get; private set; }

        public string FullPath => $@"{Path}{Name}{Extentions}";
        
        [DataMember(Name = "Scenes")]
        private ObservableCollection<SceneViewModel> m_scenes = new ObservableCollection<SceneViewModel>();

        public ProjectViewModel(string name, string path)
        {
            Name = name;
            Path = path;

            m_scenes.Add(new SceneViewModel(this, "Default Scene"));

        }
    }
}
