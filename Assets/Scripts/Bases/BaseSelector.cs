using UnityEngine;

namespace Bases
{
    [RequireComponent(typeof(MeshRenderer))]
    public class BaseSelector : MonoBehaviour, IBaseSelector
    {
        [SerializeField] private Material _selected;
        
        private Material _defaultMaterial;
        private MeshRenderer _renderer;
        private bool _isSelected;

        private void Awake()
        {
            _renderer = GetComponent<MeshRenderer>();
            _defaultMaterial = _renderer.material;
        }

        public void Select()
        {
            if (_isSelected)
                return;

            _isSelected = true;
            _renderer.material = _selected;
        }

        public void UnSelect()
        {
            if (_isSelected == false)
                return;

            _isSelected = false;
            _renderer.material = _defaultMaterial;
        }
    }
}