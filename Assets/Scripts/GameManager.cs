using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public GameState State;

    public static event Action<GameState> OnGameStateChanged;   
    public GameOverScreen GameOverScreen;
    void Awake() {
        Instance = this;
    }

    void Start(){
        UpdateGameState(GameState.Playing); 
    }

    public void UpdateGameState(GameState newState) {
        State = newState;

        switch (newState){
            case GameState.Playing:
                HandlePlaying();    
                break;
            case GameState.Paused:
                HandlePaused();
                break;
            case GameState.Win:
                HandleWin();
                break;
            case GameState.Loss:
                HandleLoss();
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(newState), newState, null);
        }

        OnGameStateChanged?.Invoke(newState);
    }

    private void HandleLoss()
    {
        GameOverScreen.Setup(1);
    }

    private void HandleWin()
    {
        throw new NotImplementedException();
    }

    private void HandlePaused()
    {
        throw new NotImplementedException();
    }

    private void HandlePlaying()
    {
        
    }

    public enum GameState {
        Playing,
        Paused,
        Win, 
        Loss
    }
}
