using System;
using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;

public class SlicerInteractableToolDetector : InteractableToolDetector<SliceInteractable> {
    private void FixedUpdate() {
        //var elems = InteractableInstrumentPool.GetInteractivrTool<SliceInteractable>(toolSearch);
        var elems = InteractableInstrumentPool.GetInteractiveTool<SliceInteractable>(this);
        Debug.Log($"SlicerInteractableToolDetector => {elems.Count}");
    }

}
