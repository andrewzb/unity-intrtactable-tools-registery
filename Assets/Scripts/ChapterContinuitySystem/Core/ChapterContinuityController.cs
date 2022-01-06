using System;
using System.Linq;
using System.Collections;
using System.ComponentModel;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine.Events;
using UnityEngine;

/*
public class SomeEventArgs : EventArgs {

}
*/

public class ChapterContinuityController : MonoBehaviour {
    [SerializeField] private ChapterContinuity chapterContinuity;
    [SerializeField] private UIControler uiControler;
    

    private ChapterControler currentControler;
    private int chapterIndex;

    private void Start() {
        chapterIndex = -1;
    }

    private void Update() {

        if (currentControler == null && chapterIndex < (chapterContinuity.Chapters.Count - 1)) {
            chapterIndex++;
            var stage = chapterContinuity.Chapters[chapterIndex];
            currentControler = new ChapterControler(this, stage);
            uiControler.SetText(stage.StageName);
            currentControler.ProgressChangedAction += OnProgressChangeed;
            currentControler.OnLifeSycleEndAction += OnControlerLifeSycleEnd;
            currentControler.TreckerCompleteAction += OnTreckerComplete;
            return;
        }
        /*
        else if (currentControler.State == State.exit) {
            currentControler.Dispose();
            currentControler = null;
            return;
        }
        */
        if (currentControler != null) {
            currentControler.Perform();
        }
    }

    private void OnControlerLifeSycleEnd(ChapterControler controler) {
        controler.OnLifeSycleEndAction -= OnControlerLifeSycleEnd;
        currentControler.Dispose();
        currentControler = null;
    }

    private void OnProgressChangeed(ChapterControler controler) {
        uiControler.SetText($"stage progress => {controler.NormalizeProgress}");
    }

    private void OnTreckerComplete(ProgressTracker tracker, EventArgs eventArgs) {
        Debug.Log("OnComplite");
        if (eventArgs is MessageEventArgs) {
            uiControler.SetText(((MessageEventArgs)eventArgs).Message);
            Debug.Log($"tracker => {tracker.name}");
        }
    }
}
