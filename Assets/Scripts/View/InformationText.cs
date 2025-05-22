using Misc;
using TMPro;

namespace View
{
    public class InformationText : IInformationText
    {
        private readonly TextMeshProUGUI _textMesh;

        public InformationText(TextMeshProUGUI textMesh)
        {
            _textMesh = textMesh;
        }

        public void SetText(string text)
        {
            _textMesh.TurnOn();
            _textMesh.text = text;
        }

        public void Clear()
        {
            _textMesh.text = "";
        }
    }
}