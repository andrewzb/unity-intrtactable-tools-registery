using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NeedleInteractable : ToolInteractable {
    [SerializeField] private Transform worlPart;
    public override Transform WorkPart => worlPart;

    private void ToggleInteractiveToolRegistration(bool isSubscribe) {
        InteractableInstrumentPool.UnregisterInteractivrTool(this);
        if (isSubscribe) {
            InteractableInstrumentPool.RegisterInteractivrTool(this);
        }
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

}

