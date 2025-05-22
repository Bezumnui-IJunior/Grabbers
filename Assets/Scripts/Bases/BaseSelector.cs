using UnityEngine;

namespace Bases
{
    [RequireComponent(typeof(MeshRenderer))]
    public class BaseSelector : MonoBehaviour, IBaseSelector
    {
        [SerializeField] private Material _selected;

        private Material _defaultMaterial;
        private bool _isSelected;
        private MeshRenderer _renderer;

        public IBaseCreator BaseCreator { get; private set; }
        public IMembersStorage MembersStorage { get; private set; }
        public IWarehouse Warehouse { get; private set; }

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

        public void Init(IBaseCreator baseCreator, IMembersStorage membersStorage, IWarehouse warehouse)
        {
            _renderer = GetComponent<MeshRenderer>();
            _defaultMaterial = _renderer.material;
            BaseCreator = baseCreator;
            MembersStorage = membersStorage;
            Warehouse = warehouse;
        }
    }
}