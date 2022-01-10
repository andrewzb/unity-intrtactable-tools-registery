using UnityEngine;

public class Hilight : MonoBehaviour {
    [SerializeField] private Renderer renderer;
    [SerializeField] private Material defaultMaterial;
    [SerializeField] private Material activeMaterial;

    public void SetDefaultMaterial() {
        renderer.material = defaultMaterial;
    }

    public void SetActiveMaterial() {
        renderer.material = activeMaterial;
    }
}
