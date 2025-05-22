using Bases;
using Misc;
using UnityEngine;
using UnityEngine.InputSystem;
using View.Input;

namespace View
{
    public class ViewBaseSelector : MonoBehaviour, IViewBaseSelector
    {
        [SerializeField] private Camera _camera;
        [SerializeField] private Material _selectMaterial;
        [SerializeField] private float _distance = 100f;
        [SerializeField] private LayerMask _mask;

        private ViewInput _input;

        public IBaseSelector Selected { get; private set; }

        private void OnEnable()
        {
            _input.UI.Exit.performed += UnSelect;
            _input.UI.Choose.performed += Select;
        }

        private void OnDisable()
        {
            _input.UI.Exit.performed -= UnSelect;
            _input.UI.Choose.performed -= Select;
        }

        void IViewBaseSelector.Enable() =>
            this.Enable();

        void IViewBaseSelector.Disable() =>
            this.Disable();

        public void UnSelect()
        {
            Selected?.UnSelect();
            Selected = null;
        }

        public void Init(ViewInput input)
        {
            _input = input;
        }

        private void UnSelect(InputAction.CallbackContext _)
        {
            UnSelect();
        }

        private void Select(InputAction.CallbackContext _)
        {
            if (TryCastBase(out IBaseSelector selector) == false)
                return;

            Selected?.UnSelect();
            Selected = selector;
            selector.Select();
        }

        private bool TryCastBase(out IBaseSelector baseSelector)
        {
            Ray ray = _camera.ScreenPointToRay(_input.UI.CursorPosition.ReadValue<Vector2>());

            baseSelector = null;

            if (Physics.Raycast(ray, out RaycastHit raycastHit, _distance, _mask.value) == false)
                return false;

            if (raycastHit.collider.TryGetComponent(out IBaseSelector selector) == false)
                return false;

            baseSelector = selector;

            return true;
        }
    }
}