using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolInteractable : MonoBehaviour {

    public virtual Transform WorkPart { get; }
    public virtual bool IsGrabed { get; }
    /*
    private virtual void ToggleInteractiveToolRegistration(bool isSubscribe) {
        InteractableInstrumentPool.RegisterInteractivrTool(this);
    }

    private void OnEnable() {
        ToggleInteractiveToolRegistration(true);
    }

    private void OnDisable() {
        ToggleInteractiveToolRegistration(false);
    }

    private void OnDestroy() {
        ToggleInteractiveToolRegistration(false);
    }
    */
}
