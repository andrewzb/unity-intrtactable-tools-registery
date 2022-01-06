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
    public ChapterControler(ChapterContinuityController controler, Chapter ñhapter) {
        state = State.beforeStart;
        this.controler = controler;
        this.ñhapter = ñhapter;
        var localFullProgress = 0;
        foreach (var tracker in ñhapter.ProgressTrackers) {
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
    private Chapter ñhapter;
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
        ñhapter.BeforeStartActions?.Invoke();
        state = State.start;
    }

    private void OnStart() {
        ñhapter.StartActions?.Invoke();
        state = State.pending;
    }

    private void Pending() {
        var localProgress = 0;
        foreach (var tracker in ñhapter.ProgressTrackers) {
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
        ñhapter.EndActions?.Invoke();
        state = State.afterEnd;
    }

    private void OnAfterEnd() {
        ñhapter.AfterEndActions?.Invoke();
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
        foreach (var tracker in ñhapter.ProgressTrackers) {
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
