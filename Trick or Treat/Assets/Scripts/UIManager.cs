using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    //--------------------------------------------------------------------------------------------------------//

    #region referencias:

    /// <summary>
    /// Referencia al tiempo que queda.
    /// </summary>
    [SerializeField] private TMP_Text _remainingTimeTMP;
    /// <summary>
    /// Referencia a la ronda que es.
    /// </summary>
    [SerializeField] private TMP_Text _roundTMP;
    /// <summary>
    /// Referencia al resultado.
    /// </summary>
    [SerializeField] private TMP_Text _resultTMP;
    /// <summary>
    /// Objeto MainMenu.
    /// </summary>
    [SerializeField] private GameObject _mainMenu;
    /// <summary>
    /// Objeto Game.
    /// </summary>
    [SerializeField] private GameObject _gameMenu;
    /// <summary>
    /// Objeto End.
    /// </summary>
    [SerializeField] private GameObject _neighbourMenu;

    /// <summary>
    /// Objeto Dress.
    /// </summary>
    [SerializeField] private GameObject _dressMenu;
    /// <summary>
    /// Objeto End.
    /// </summary>
    [SerializeField] private GameObject _endMenu;

    #endregion

    //--------------------------------------------------------------------------------------------------------//

    #region propiedades:

    /// <summary>
    /// Reference to active menu Game State
    /// </summary>
    private GameManager.GameStates _activeMenu;

    #endregion

    //--------------------------------------------------------------------------------------------------------//

    #region awake, start y update::

    private void Awake()
    {

    }
    // Start is called before the first frame update
    void Start()
    {
        GameManager.Instance.RegisterUIManager(this);

        _mainMenu.SetActive(true);
        _gameMenu.SetActive(false);
        _dressMenu.SetActive(false);
        _endMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }

    #endregion

    //--------------------------------------------------------------------------------------------------------//

    #region metodos:

    public void RequestStateChange(int newState)
    {

        Debug.Log((GameManager.GameStates)newState);
        GameManager.Instance.RequestStateChange((GameManager.GameStates)newState);
    }

    public void SetMenu(GameManager.GameStates newMenu)
    {
        _activeMenu = newMenu;
        if (newMenu == GameManager.GameStates.START)
        {
            _mainMenu.SetActive(true);
            _gameMenu.SetActive(false);
            _dressMenu.SetActive(false);
            _endMenu.SetActive(false);
            _neighbourMenu.SetActive(false);

        }
        else if (newMenu == GameManager.GameStates.GAME)
        {
            _mainMenu.SetActive(false);
            _gameMenu.SetActive(true);
            _dressMenu.SetActive(false);
            _endMenu.SetActive(false);
            _neighbourMenu.SetActive(false);

        }
        else if (newMenu == GameManager.GameStates.END)
        {
            _mainMenu.SetActive(false);
            _gameMenu.SetActive(false);
            _dressMenu.SetActive(false);
            _endMenu.SetActive(true);
            _neighbourMenu.SetActive(false);

        }
        else if (newMenu == GameManager.GameStates.DRESS)
        {
            _mainMenu.SetActive(false);
            _gameMenu.SetActive(false);
            _dressMenu.SetActive(true);
            _endMenu.SetActive(false);
            _neighbourMenu.SetActive(false);

        }
        else if (newMenu == GameManager.GameStates.NEIGHBOUR)
        {
            _mainMenu.SetActive(false);
            _gameMenu.SetActive(false);
            _dressMenu.SetActive(false);
            _endMenu.SetActive(false);
            _neighbourMenu.SetActive(true);
        }
    }
    public void UpdateDressHUD(float remainingTime)
    {
        _remainingTimeTMP.text = Mathf.Round(remainingTime) + "";
    }

    public void UpdateGameHUD(int round)
    {
        _roundTMP.text = Mathf.Round(round) + "";
    }
    
    public void UpdateResultHUD(string result)
    {
        _resultTMP.text = result + "";
    }

    public void buttonExit()
    {
        Debug.Log("Adios.");
        Application.Quit();
    }

    #endregion

    //--------------------------------------------------------------------------------------------------------//
}