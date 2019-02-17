using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.UIElements;
using UnityEngine.Internal.Experimental.UIElements;

public class LobbyUIMover : Singleton<LobbyUIMover>
{
    private LobbyState _lobbyUIState;

    public Transform MainPanel;
    public Transform StagePanel;

    [NonSerialized]public bool Handle;
    
    public enum LobbyState
    {
        Main, //Start Scene
        Option,
        PlayerSlotSelect, // Select Game Save Slot
        DifficultySelect, // If Select Empty Save Slot
        StageSelect01, // Stage Map of Normal Difficulty
        
        Credit,
    }

    private void LateUpdate()
    {
        if (_lobbyUIState != LobbyState.StageSelect01) return;
        StagePanel.localPosition += Vector3.down * Input.GetAxis("Mouse ScrollWheel") * 100;
        if(Input.GetKey(KeyCode.UpArrow)||Input.GetKey(KeyCode.W)) StagePanel.localPosition += Vector3.down;
        else if(Input.GetKey(KeyCode.DownArrow)||Input.GetKey(KeyCode.S)) StagePanel.localPosition += Vector3.up;
    }

    protected override void Initialize()
    {
        base.Initialize();

        _lobbyUIState = LobbyState.Main;
    }

    public LobbyState LobbyUIState
    {
        get => _lobbyUIState;
        set
        {
            if(_lobbyUIState == value) return;
            Handle = true;

            switch (value)
            {
                case LobbyState.Main:
                    break;
                case LobbyState.Option:
                    break;
                case LobbyState.PlayerSlotSelect:
                    break;
                case LobbyState.DifficultySelect:
                    break;
                case LobbyState.StageSelect01:
                    break;
                case LobbyState.Credit:
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(value), value, null);
            }
            
            _lobbyUIState = value;
        }
    }

    public void ToMain()
    {
        if(Handle) return;
        _lobbyUIState = LobbyState.Main;
        var coroutine = CoroutineFactory.GetInstance.CreateCoroutine(2f, 0.01f);
        var startPositionOfMainPanel = MainPanel.localPosition;
        var startPositionOfStagePanel = StagePanel.localPosition;
        coroutine.SetAction(() =>
        {
            MainPanel.localPosition =
                coroutine.Change(startPositionOfMainPanel, new Vector3(0, 0, 0));
            StagePanel.localPosition =
                coroutine.Change(startPositionOfStagePanel, new Vector3(0, 0, 0));
        });
        coroutine.SetExitAction(() => Handle = false);
        coroutine.SetTrigger();
    }
    
    public void ToOption()
    {
        if(Handle) return;
        _lobbyUIState = LobbyState.Option;
        var coroutine = CoroutineFactory.GetInstance.CreateCoroutine(2f, 0.01f);
        var startPositionOfMainPanel = MainPanel.localPosition;
        coroutine.SetAction(() =>
        {
            MainPanel.localPosition =
                coroutine.Change(startPositionOfMainPanel, new Vector3(-1000, 0, 0));
        });
        coroutine.SetExitAction(() => Handle = false);
        coroutine.SetTrigger();
    }
    
    public void ToCredit()
    {
        if(Handle) return;
        _lobbyUIState = LobbyState.Credit;
        var coroutine = CoroutineFactory.GetInstance.CreateCoroutine(2f, 0.01f);
        var startPositionOfMainPanel = MainPanel.localPosition;
        coroutine.SetAction(() =>
        {
            MainPanel.localPosition =
                coroutine.Change(startPositionOfMainPanel, new Vector3(1000, 0, 0));
        });
        coroutine.SetExitAction(() => Handle = false);
        coroutine.SetTrigger();
    }
    
    public void ToStageSelect()
    {
        if(Handle) return;
        _lobbyUIState = LobbyState.StageSelect01;
        var coroutine = CoroutineFactory.GetInstance.CreateCoroutine(2f, 0.01f);
        var startPositionOfMainPanel = MainPanel.localPosition;
        var startPositionOfStagePanel = StagePanel.localPosition;
        coroutine.SetAction(() =>
        {
            MainPanel.localPosition =
                coroutine.Change(startPositionOfMainPanel, new Vector3(0, 0, -500));
            StagePanel.localPosition =
                coroutine.Change(startPositionOfStagePanel, new Vector3(0, -185, -350));
        });
        coroutine.SetExitAction(() => Handle = false);
        coroutine.SetTrigger();
    }
}
