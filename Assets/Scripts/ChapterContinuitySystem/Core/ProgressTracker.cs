using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MessageEventArgs : EventArgs {
    public MessageEventArgs(string message) {
        this.message = message;
    }

    private string message;
    public string Message => message;
}


public class ProgressTracker : MonoBehaviour {
    [SerializeField] protected int progressContribution;
    [SerializeField] protected string message;
    [SerializeField] protected int progress;

    public Action<ProgressTracker, EventArgs> OnProgressComplete;

    public int ProgressContribution => progressContribution;
    public int Progress => progress;
    public string Message => message;

    public void ResetProgress() {
        progress = 0;
    }

    [ContextMenu("SendEvent")]
    public virtual void EmitEvent() {
        Debug.Log($"emit event => {name}");
        OnProgressComplete?.Invoke(this, new MessageEventArgs(message));
    }


}