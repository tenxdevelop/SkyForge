using SkyForgeEditor.Model.Commands.Base;


namespace SkyForgeEditor.Model.Commands
{
    public class LamdaCommand : BaseCommand
    {
        private Action<object> m_execute;
        private Func<object, bool> m_canExecute;

        public LamdaCommand(Action<object> execute, Func<object, bool> canExecute)
        {
            m_execute = execute;
            m_canExecute = canExecute;
        }

        public override bool CanExecute(object? parameter) => m_canExecute(parameter);

        public override void Execute(object? parameter) => m_execute(parameter);
    }
}
