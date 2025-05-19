using Bases;
using UnityEngine;

namespace View
{
    public class ViewBaseSelector : MonoBehaviour
    {
        private const KeyCode UnSelectButton = KeyCode.Escape;

        [SerializeField] private Camera _camera;
        [SerializeField] private Material _selectMaterial;
        [SerializeField] private float _distance = 100f;
        [SerializeField] private LayerMask _mask;

        private IBaseSelector _selected;

        private void Update()
        {
            if (Input.GetKeyDown(UnSelectButton))
                UnSelect();

            if (Input.GetMouseButtonDown(0))
                Select();
        }

        private void UnSelect()
        {
            _selected?.UnSelect();
            _selected = null;
        }

        private void Select()
        {
            if (TryCastBase(out IBaseSelector selector) == false)
                return;

            _selected?.UnSelect();
            _selected = selector;
            selector.Select();
        }

        private bool TryCastBase(out IBaseSelector baseSelector)
        {
            Ray ray = _camera.ScreenPointToRay(Input.mousePosition);

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