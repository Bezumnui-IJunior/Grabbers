using StateMachines;

namespace View.States
{
    public abstract class BaseWrongSelectedState : State
    {
        private readonly string _errorMessage;
        private readonly IInformationText _informationText;
        private readonly IViewBaseSelector _selector;

        protected BaseWrongSelectedState(IStateChanger stateChanger, IViewBaseSelector selector, IInformationText informationText, string errorMessage) : base(stateChanger)
        {
            _selector = selector;
            _informationText = informationText;
            _errorMessage = errorMessage;
        }

        public override void Enter()
        {
            _informationText.SetText(_errorMessage);
            _selector.Enable();
        }

        public override void Exit()
        {
            _informationText.Clear();
            _selector.Disable();
        }
    }
}