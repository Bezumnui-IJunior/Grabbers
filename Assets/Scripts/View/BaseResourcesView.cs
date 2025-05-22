using System.Collections.Generic;
using System.Text;
using Bases;
using JetBrains.Annotations;
using TMPro;
using UnityEngine;

namespace View
{
    [RequireComponent(typeof(TextMeshProUGUI))]
    public class BaseResourcesView : MonoBehaviour
    {
        [SerializeField] private ViewBaseSelector _selector;

        private readonly List<InventoryItem> _items = new List<InventoryItem>();
        private readonly StringBuilder _stringBuilder = new StringBuilder();

        private TextMeshProUGUI _textMesh;

        [CanBeNull] private IWarehouse Warehouse => _selector.Selected?.Warehouse;

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
                _textMesh.text = "Nothing";
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
            if (Warehouse == null)
                _items.Clear();
            else
                Warehouse.CopyItems(_items);
        }
    }
}