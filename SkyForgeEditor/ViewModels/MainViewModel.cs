
using SkyForgeEditor.Infrastructure.Reactive.WPF;
using SkyForgeEditor.ViewModels.Base;

namespace SkyForgeEditor.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        public ReactivePropertyWPF<string> Title { get; private set; } = new();

        public MainViewModel()
        {
            Title.SetValue(this, "Sky Forge Editor");
        }
    }
}
