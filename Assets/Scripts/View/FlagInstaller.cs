using Flags;
using Spawners;
using UnityEngine;
using UnityEngine.InputSystem;
using View.Input;

namespace View
{
    public class FlagInstaller : MonoBehaviour
    {
        private const int MaxDistance = 100;
        [SerializeField] private Camera _camera;
        [SerializeField] private LayerMask _groundMask;
        [SerializeField] private FlagSpawner _spawner;
        private ViewInput _input;

        private IViewBaseSelector _selector;

        public bool IsInstall { get; private set; }

        public void Reset()
        {
            IsInstall = false;
        }

        private void OnEnable()
        {
            _input.UI.Choose.performed += OnClick;
        }

        private void OnDisable()
        {
            _input.UI.Choose.performed -= OnClick;
        }

        public void Init(ViewInput input, IViewBaseSelector selector)
        {
            _input = input;
            _selector = selector;
        }

        private void OnClick(InputAction.CallbackContext _)
        {
            if (TrySetFlag(out Flag flag) == false)
                return;

            IsInstall = true;
            _selector.Selected.BaseCreator.ScheduleTask(flag);
        }

        private bool TrySetFlag(out Flag flag)
        {
            if (TryRayCast(_camera.ScreenPointToRay(_input.UI.CursorPosition.ReadValue<Vector2>()), out Vector3 position) == false)
            {
                flag = null;

                return false;
            }

            flag = _spawner.Spawn(position);

            return true;
        }

        private bool TryRayCast(Ray ray, out Vector3 position)
        {
            position = default;

            if (Physics.Raycast(ray, out RaycastHit hit, MaxDistance) == false)
                return false;

            if (((1 << hit.collider.gameObject.layer) & _groundMask.value) == 0)
                return false;

            position = hit.point;

            return true;
        }
    }
}