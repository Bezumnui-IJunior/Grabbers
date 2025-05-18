using System.Collections.Generic;
using System.Text;
using Bases;
using TMPro;
using UnityEngine;

namespace View
{
    [RequireComponent(typeof(TextMeshProUGUI))]
    public class BaseView : MonoBehaviour
    {
        [SerializeField] private Bases.Base _base;

        private readonly List<InventoryItem> _items = new List<InventoryItem>();
        private readonly StringBuilder _stringBuilder = new StringBuilder();

        private TextMeshProUGUI _textMesh;

        private IWarehouse Warehouse => _base.Warehouse;

        private void Awake()
        {
            _textMesh = GetComponent<TextMeshProUGUI>();
        }

        private void Update()
        {
            UpdateItems();
            UpdateString();
            _textMesh.text = _stringBuilder.ToString();

            if (_textMesh.text == "")
                _textMesh.text = "Warehouse is empty";
        }

        private void UpdateString()
        {
            _stringBuilder.Clear();

            foreach (InventoryItem inventoryItem in _items)
            {
                _stringBuilder.Append(inventoryItem.Name);
                _stringBuilder.Append(": ");
                _stringBuilder.Append(inventoryItem.Count);
                _stringBuilder.Append("\n");
            }
        }

        private void UpdateItems()
        {
            Warehouse.CopyItems(_items);
        }
    }
}