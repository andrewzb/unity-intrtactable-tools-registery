using UnityEngine;
using TMPro;

public class UIControler : MonoBehaviour {
    [SerializeField] private TextMeshProUGUI text;

    public void SetText(string value) {
        if (text.text != value) {
            text.text = value;
        }
    }
}
