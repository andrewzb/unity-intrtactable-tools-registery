using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NeedleInteractableToolDetector : InteractableToolDetector<NeedleInteractable> {
    private void FixedUpdate() {
        //var elems = InteractableInstrumentPool.GetInteractivrTool<SliceInteractable>(toolSearch);
        var elems = InteractableInstrumentPool.GetInteractiveTool<NeedleInteractable>(this);
        Debug.Log($"NeedleInteractableToolDetector => {elems.Count}");
    }
}
