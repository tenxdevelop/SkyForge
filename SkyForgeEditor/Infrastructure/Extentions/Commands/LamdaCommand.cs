
namespace SkyForgeEditor.Infrastructure.Extentions.Commands
{
    public class LamdaCommand : BaseCommand
    {
        private Action<object> m_execute;
        private Func<object, bool> m_canExecute;

        public LamdaCommand(Action<object> execute, Func<object, bool> canExecute = null)
        {
            m_execute = execute ?? throw new ArgumentNullException(nameof(execute));
            m_canExecute = canExecute;
        }

        public override bool CanExecute(object? parameter) => m_canExecute?.Invoke(parameter) ?? true;

        public override void Execute(object? parameter) => m_execute(parameter);
    }
}
