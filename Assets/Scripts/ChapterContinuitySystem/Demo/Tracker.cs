using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;

public class Tracker : ProgressTracker {

    [ContextMenu("SendEvent2")]
    public override void EmitEvent() {
        Debug.Log($"emit empty event => {name}");
        OnProgressComplete?.Invoke(this, EventArgs.Empty);
    }
}
