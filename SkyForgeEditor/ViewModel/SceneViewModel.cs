using SkyForgeEditor.ViewModel.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SkyForgeEditor.ViewModel
{
    [DataContract(Name = "Scene")]
    internal class SceneViewModel : BaseViewModel
    {
        [DataMember]
        public string Name { get => m_name; set => Set(ref m_name, value); }

        [DataMember]
        public ProjectViewModel Project { get; private set; }

        private string m_name;

        internal SceneViewModel(ProjectViewModel project, string name)
        {
            Project = project;
            m_name = name;
        }
    }
}
