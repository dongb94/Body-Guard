using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LobbyUIMover : Singleton<LobbyUIMover>
{
    private LobbyState _lobbyUIState;
    
    public enum LobbyState
    {
        Main, //Start Scene
        Option,
        PlayerSlotSelect, // Select Game Save Slot
        DifficultySelect, // If Select Empty Save Slot
        StageSelect01, // Stage Map of Normal Difficulty
        
        Credit,
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
}
