using Misc;
using StateMachines;
using View.Transitions;

namespace View.States
{
    public class BaseSelectedState : State
    {
        private readonly FlagInstaller _flagInstaller;
        private readonly IInformationText _informationText;
        private readonly IViewBaseSelector _selector;

        public BaseSelectedState(IStateChanger stateChanger, IViewBaseSelector selector, IInformationText informationText, FlagInstaller flagInstaller) : base(stateChanger)
        {
            _selector = selector;
            _informationText = informationText;
            _flagInstaller = flagInstaller;

            AddTransition(new BaseSelectedToIdle(stateChanger, selector, flagInstaller));
            AddTransition(new BaseSelectedToBaseBusySelected(stateChanger, selector));
            AddTransition(new BaseTooFewSelectedToBaseBusySelected(stateChanger, selector));
        }

        public override void Enter()
        {
            _flagInstaller.Reset();
            _flagInstaller.Enable();

            _selector.Enable();
            _informationText.SetText("Place a flag where you want to build a base.");
        }

        public override void Exit()
        {
            _flagInstaller.Disable();
            _selector.Disable();
            _informationText.Clear();
        }
    }
}