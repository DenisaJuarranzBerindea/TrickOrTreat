//using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.XR;




public enum RESULT { PLAYER1, PLAYER2, TIE };

public class GameManager : MonoBehaviour
{
    //--------------------------------------------------------------------------------------------------------//

    #region referencias:

    /// <summary>
    /// Instancia del GameManager.
    /// </summary>
    public static GameManager Instance { get; private set; }
    /// <summary>
    /// Referencia al UIManager.
    /// </summary>
    private UIManager _UIManager;
    /// <summary>
    /// Enum de estados del juego.
    /// </summary>

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
    /// <summary>
    ///  referencia al objeto con todo lo del dressup
    /// </summary>
    [SerializeField] GameObject _dressup;    
    /// <summary>
    ///  referencia al objeto con todo lo del resultado
    /// </summary>
    [SerializeField] GameObject _result;    
    /// <summary>
    ///  referencia al objeto con todo lo de enseñar las casas
    /// </summary>
    [SerializeField] GameObject _game;
    /// <summary>
    ///  referencia al objeto con todo lo de enseñar las casas
    /// </summary>
    [SerializeField] GameObject _uiNeighbour;
    /// <summary>
    /// referencia al objetos con los players
    /// </summary>
    [SerializeField] GameObject _players;
    /// <summary>
    /// referencia al array de posibles vecinos
    /// </summary>
    [SerializeField] GameObject[] _neighbours;

    #endregion

    //--------------------------------------------------------------------------------------------------------//

    #region propiedades:

    public enum GameStates { START, GAME, NEIGHBOUR, DRESS, RESULT, END }
    /// <summary>
    /// Estado actual de juego.
    /// </summary>
    private GameStates _currentState;
    /// <summary>
    /// Siguiente estado.
    /// </summary>
    private GameStates _nextState;
    /// <summary>
    /// Tiempo que falta para vestirse.
    /// </summary>
    private float _timeToDress = 20.0f;
    private float _neighbourtime = 5.0f;
    private float _resultTime = 5.0f;
    /// <summary>
    /// Ronda actual.
    /// </summary>
    private int _nRound = 0;

    #endregion

    //--------------------------------------------------------------------------------------------------------//

    #region awake, start y update:

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
        // Todo esto son pruebas:
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
        if (Input.GetKeyUp(KeyCode.D))
        {
            changeState(GameStates.DRESS);
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
                _UIManager.UpdateResultHUD("Player1");
            }
            else if (res == RESULT.PLAYER2)
            {
                Debug.Log("PLAYER 2");
                _UIManager.UpdateResultHUD("Player2");
            }
            else
            {
                Debug.Log("TIE");
                _UIManager.UpdateResultHUD("Tie");
            }
        }
        // Gestion de rondas.
        if (_currentState == GameStates.DRESS)
        {
            if (_timeToDress > 19)
            {
                _UIManager.UpdateDressHUD(_timeToDress);
                _timeToDress -= Time.deltaTime;
            }
            else
            {
                _nRound++;
                changeState(GameStates.RESULT);
            }
        }
        if (_currentState == GameStates.GAME)
        {
            if (_nRound >= 5)
            {
                changeState(GameStates.END);
            }
            else
            {

                _UIManager.UpdateGameHUD(_nRound);
            }
        }
        if (_currentState == GameStates.NEIGHBOUR)
        {
            if (_neighbourtime > 0)
            {
                Debug.Log("GAME DENISIEST PART");

                _neighbourtime -= Time.deltaTime;
            }
            else
            {
                _nRound++;
                changeState(GameStates.DRESS);
            }
        }
        if (_currentState == GameStates.RESULT)
        {
            if (_resultTime > 5)
            {
                Debug.Log("END AQUI FALTAN LOS RESULTADOS");
                _resultTime -= Time.deltaTime;

            }
            else
            {
                changeState(GameStates.GAME);

            }
        }

    }

    #endregion

    //--------------------------------------------------------------------------------------------------------//

    #region metodos de iniciales:

    public void RegisterUIManager(UIManager uiManager)
    {
        _UIManager = uiManager;
    }

    #endregion

    //--------------------------------------------------------------------------------------------------------//

    #region metodos de estados:

    public void RequestStateChange(GameManager.GameStates newState)
    {
        changeState(newState);
    }
    public GameStates getCurrentState()
    {
        return _currentState;
    }
    private void changeState(GameStates state)
    {
        _nextState = state;
        _UIManager.SetMenu(state);
        updateState();
    }
    private void updateState()
    {
        if (_currentState == GameStates.RESULT && _nextState == GameStates.GAME)
        {
            _currentState = _nextState;
            setUpResult(false);
            setUpGame(true);

            Debug.Log("Enter Game.");
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
        else if (_currentState == GameStates.START || _currentState == GameStates.GAME && _nextState == GameStates.NEIGHBOUR)
        {
            _currentState = _nextState;
            setUpGame(false);
            setUpNeighbour(true);
            Debug.Log("Enter Neighbour.");
        }
        else if (_currentState == GameStates.NEIGHBOUR || _currentState == GameStates.NEIGHBOUR && _nextState == GameStates.DRESS)
        {
            _currentState = _nextState;
            _timeToDress = 20.0f;
            setUpDressUp(true);
            setUpNeighbour(false);
            Debug.Log("Enter Dress.");
        }
        else if (_currentState == GameStates.DRESS || _currentState == GameStates.DRESS && _nextState == GameStates.GAME)
        {
            _currentState = _nextState;
            setUpGame(true);
            setUpDressUp(false);
            Debug.Log("Enter game");
        }
        else if (_currentState == GameStates.DRESS || _currentState == GameStates.DRESS && _nextState == GameStates.RESULT)
        {
            _currentState = _nextState;
            setUpResult(true);
            setUpDressUp(false);
            Debug.Log("Enter result.");
        }
        else if (_currentState == GameStates.GAME || _currentState == GameStates.GAME && _nextState == GameStates.NEIGHBOUR)
        {
            _currentState = _nextState;
            setUpGame(false);
            setUpNeighbour(true);
            Debug.Log("Enter result.");
        }

    }

    #endregion

    //--------------------------------------------------------------------------------------------------------//

    #region metodos de UI:



    #endregion

    //--------------------------------------------------------------------------------------------------------//

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
        else if ((Mathf.Abs(p1.cute - n.cute) < Mathf.Abs(p2.cute - n.cute))) puntos2++;
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

    //--------------------------------------------------------------------------------------------------------//


    #region setup


    void setUpDressUp(bool a)
    {
        _dressup.SetActive(a);
        _players.SetActive(a);
    }

    void setUpNeighbour(bool a)
    {
        _uiNeighbour.SetActive(a);
    }


    void generateNewNeighbour()
    {
        var negih = _neighbours[Random.Range(0, _neighbours.Length)];
        _currentNeighbour = negih;
    }

    void setUpResult(bool a)
    {
        _result.SetActive(a);

        int aux = (int)judgeCostumes();
        Debug.Log(aux);
        
    }


    void setUpGame(bool a) 
    {
        generateNewNeighbour();
        _game.SetActive(a);        
    }

    #endregion



}