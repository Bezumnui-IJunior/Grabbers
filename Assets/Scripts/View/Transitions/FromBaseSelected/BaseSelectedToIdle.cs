using StateMachines;
using View.States;

namespace View.Transitions
{
    public class BaseSelectedToIdle : Transition<IdleState>
    {
        private readonly FlagInstaller _flagInstaller;
        private readonly IViewBaseSelector _selector;

        public BaseSelectedToIdle(IStateChanger stateChanger, IViewBaseSelector selector, FlagInstaller flagInstaller) : base(stateChanger)
        {
            _selector = selector;
            _flagInstaller = flagInstaller;
        }

        protected override bool CanTransit() =>
            _selector.Selected == null || _flagInstaller.IsInstall;
    }
}