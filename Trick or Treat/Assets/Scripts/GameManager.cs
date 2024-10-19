using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class GameManager : MonoBehaviour
{
    /// <summary>
    /// Instancia del GameManager.
    /// </summary>
    public static GameManager Instance { get; private set; }
    /// <summary>
    /// Enum de estados del juego.
    /// </summary>
    public enum GameStates { START, GAME, PAUSE, END }
    /// <summary>
    /// Estado actual de juego.
    /// </summary>
    private GameStates _currentState;
    /// <summary>
    /// Siguiente estado.
    /// </summary>
    private GameStates _nextState;
    /// <summary>
    /// Referencia al jugador 1.
    /// </summary>
    [SerializeField] GameObject _player1;
    /// <summary>
    /// Rreferencia al jugador 2.
    /// </summary>
    [SerializeField] GameObject _player2;





    private void Awake()
    {
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            changeState(GameStates.END);
        }
        if (Input.GetKeyUp(KeyCode.S))
        {
            changeState(GameStates.GAME);
        }
        if (Input.GetKeyUp(KeyCode.G))
        {
            changeState(GameStates.END);
        }
        if (Input.GetKeyUp(KeyCode.P))
        {
            if (_currentState != GameStates.PAUSE)
            {
                changeState(GameStates.PAUSE);
            }
            else
            {
                changeState(GameStates.GAME);
            }
        }
        if (Input.GetKeyUp(KeyCode.C))
        {
            changeState(GameStates.START);
        }
    }

    public GameStates getCurrentState() { return _currentState; }
    public void changeState(GameStates state) { _nextState = state; updateState(); }
    private void updateState()
    {
        if (_currentState == GameStates.START && _nextState == GameStates.GAME)
        {
            _currentState = _nextState;
            Debug.Log("Enter Game.");
        }
        else if (_currentState == GameStates.GAME && _nextState == GameStates.PAUSE)
        {
            _currentState = _nextState;
            Debug.Log("Enter Pause.");
        }
        else if (_currentState == GameStates.PAUSE && _nextState == GameStates.GAME)
        {
            _currentState = _nextState;
            Debug.Log("Exit Pause.");
        }
        else if (_currentState == GameStates.GAME && _nextState == GameStates.END)
        {
            _currentState = _nextState;
            Debug.Log("Enter End.");
        }
        else if (_currentState == GameStates.END && _nextState == GameStates.START)
        {
            _currentState = _nextState;
            Debug.Log("Enter Start.");
        }
    }
}