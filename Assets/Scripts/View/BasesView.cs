using Flags;
using Misc;
using StateMachines;
using TMPro;
using UnityEngine;
using View.Input;
using View.States;

namespace View
{
    public class BasesView : MonoBehaviour
    {
        [SerializeField] private ViewBaseSelector _selector;
        [SerializeField] private StateMachine _stateMachine;
        [SerializeField] private TextMeshProUGUI _informationText;
        [SerializeField] private Flag _flagPrefab;
        [SerializeField] private FlagInstaller _flagInstaller;
        private ViewInput _input;

        private void Start()
        {
            _stateMachine.ChangeState(_stateMachine.GetState<IdleState>());
        }

        private void OnEnable()
        {
            _input.Enable();
        }

        private void OnDisable()
        {
            _input.Disable();
        }

        public void Init()
        {
            _input = new ViewInput();
            InformationText informationText = new InformationText(_informationText);
            informationText.Clear();

            _selector.Disable();
            _selector.Init(_input);
            _flagInstaller.Init(_input, _selector);

            _stateMachine.AddState(typeof(IdleState), new IdleState(_stateMachine, _selector));
            _stateMachine.AddState(typeof(BaseSelectedState), new BaseSelectedState(_stateMachine, _selector, informationText, _flagInstaller));
            _stateMachine.AddState(typeof(BaseTooFewSelectedState), new BaseTooFewSelectedState(_stateMachine, _selector, informationText));
            _stateMachine.AddState(typeof(BaseBusySelectedState), new BaseBusySelectedState(_stateMachine, _selector, informationText));
        }
    }
}