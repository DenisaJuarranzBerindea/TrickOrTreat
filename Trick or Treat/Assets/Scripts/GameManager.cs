using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;



public enum RESULT { PLAYER1, PLAYER2, TIE };

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
    /// <summary>
    /// Referencia al vecino actual, en cada ronda cambia;
    /// </summary>
    [SerializeField] GameObject _currentNeighbour;





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
        if (Input.GetKeyUp(KeyCode.F))          // PRUEBA PARA PUNTUAR
        {
            RESULT res = judgeCostumes();

            if (res == RESULT.PLAYER1)
            {
                Debug.Log("PLAYER 1");
            }   
            else if(res == RESULT.PLAYER2)
            {
                Debug.Log("PLAYER 2");
            }
            else { 
                Debug.Log("TIE");
            }
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




    #region PUNTOS


    public void setNeighbour(GameObject n) { _currentNeighbour = n; }

    public RESULT judgeCostumes()
    {
        // puntuaciones de los jugadores
        Puntuacion p1 = _currentNeighbour.GetComponent<NeighbourScript>().judgeCostume(_player1);


        Puntuacion p2 = _currentNeighbour.GetComponent<NeighbourScript>().judgeCostume(_player2);

        //
        return decideVerdict(p1, p2);
    }

    /// <summary>
    /// devuelve 0 si es el player 1 y 1 si es el 2
    /// </summary>
    /// <param name="p1"></param>
    /// <param name="p2"></param>
    /// <returns></returns>
    RESULT decideVerdict(Puntuacion p1, Puntuacion p2)
    {
        int puntos1 = 0, puntos2 = 0;

        Neighbour n = _currentNeighbour.GetComponent<NeighbourScript>().GetNeighbour();

        // la diferencia minima, sin contar los iguales
        if (Mathf.Abs(p1.cute - n.cute) > Mathf.Abs(p2.cute - n.cute)) puntos1++;
        else if((Mathf.Abs(p1.cute - n.cute) < Mathf.Abs(p2.cute - n.cute))) puntos2++;
        if (Mathf.Abs(p1.spooky - n.spooky) > Mathf.Abs(p2.spooky - n.spooky)) puntos1++;
        else if (Mathf.Abs(p1.spooky - n.spooky) > Mathf.Abs(p2.spooky - n.spooky)) puntos2++; 
        if (Mathf.Abs(p1.funny - n.funny) > Mathf.Abs(p2.funny - n.funny)) puntos1++;
        else if (Mathf.Abs(p1.funny - n.funny) > Mathf.Abs(p2.funny - n.funny)) puntos2++;

        puntos2 += p2.theme;
        puntos1 += p1.theme;



        if (puntos1 > puntos2)
            return RESULT.PLAYER1;
        else if (puntos1 < puntos2)
            return RESULT.PLAYER2;
        else return RESULT.TIE;
    }


    #endregion
}