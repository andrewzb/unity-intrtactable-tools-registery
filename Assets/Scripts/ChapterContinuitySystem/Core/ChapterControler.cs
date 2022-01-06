using System;
using System.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum State {
    enter,
    beforeStart,
    start,
    pending,
    end,
    afterEnd,
    exit
}

public class ChapterControler : IDisposable{
    public ChapterControler(ChapterContinuityController controler, Chapter �hapter) {
        state = State.beforeStart;
        this.controler = controler;
        this.�hapter = �hapter;
        var localFullProgress = 0;
        foreach (var tracker in �hapter.ProgressTrackers) {
            localFullProgress += tracker.ProgressContribution;
            tracker.OnProgressComplete += TreckerCompleteActionHandler;
        }
        fullProgress = localFullProgress;
        progress = 0;
    }

    public Action<ChapterControler> OnLifeSycleEndAction;
    public Action<ChapterControler> ProgressChangedAction;
    public Action<ProgressTracker, EventArgs> TreckerCompleteAction;

    public State State => state;
    public int Progress => progress;
    public float NormalizeProgress => (float)progress / fullProgress;

    private bool disposed;
    private ChapterContinuityController controler;
    private Chapter �hapter;
    State state;
    private int fullProgress;
    private int progress;


    public void Perform() {
        switch (state) {
            case State.beforeStart:
                OnBeforeStart();
                break;
            case State.start:
                OnStart();
                break;
            case State.pending:
                Pending();
                break;
            case State.end:
                OnEnd();
                break;
            case State.afterEnd:
                OnAfterEnd();
                break;
            default:
                break;
        }
    }

    private void OnBeforeStart() {
        �hapter.BeforeStartActions?.Invoke();
        state = State.start;
    }

    private void OnStart() {
        �hapter.StartActions?.Invoke();
        state = State.pending;
    }

    private void Pending() {
        var localProgress = 0;
        foreach (var tracker in �hapter.ProgressTrackers) {
            localProgress += tracker.Progress;
        }
        if(progress != localProgress) {
            progress = localProgress;
            ProgressChangedAction?.Invoke(this);
        }
        if (progress >= fullProgress) {
            state = State.end;
        }
    }

    private void OnEnd() {
        �hapter.EndActions?.Invoke();
        state = State.afterEnd;
    }

    private void OnAfterEnd() {
        �hapter.AfterEndActions?.Invoke();
        state = State.exit;
        OnLifeSycleEndAction?.Invoke(this);
    }


    private void TreckerCompleteActionHandler(ProgressTracker traker, EventArgs args) {
        TreckerCompleteAction?.Invoke(traker, args);
    }

    public void Dispose() {
        Dispose(disposing: true);
        controler = null;
        ProgressChangedAction = null;
        foreach (var tracker in �hapter.ProgressTrackers) {
            tracker.OnProgressComplete -= TreckerCompleteAction;
        }
        GC.SuppressFinalize(this);
    }

    protected virtual void Dispose(bool disposing) {
        if (!this.disposed) {
            if (disposing) {
                //clenap reference dependensies;
            }
            disposed = true;
        }
    }

    ~ChapterControler() {
        Dispose(disposing: false);
    }
}
