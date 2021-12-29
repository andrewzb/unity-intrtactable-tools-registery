using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SliceInteractable : ToolInteractable {
    [SerializeField] private Transform worlPart;
    [SerializeField] private bool isGrabed;

    public override Transform WorkPart => worlPart;
    public override bool IsGrabed => isGrabed;

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
