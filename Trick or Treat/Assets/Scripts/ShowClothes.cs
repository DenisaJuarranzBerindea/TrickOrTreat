using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowClothes : MonoBehaviour
{
    #region properties

    bool dressed = false;

    GameObject _prefab;
    #endregion

    #region references 

    [SerializeField]
    private Garment _clothes;   //Prenda que se va a poner en el jugador

    [SerializeField]
    private Transform _playerTransform; //Transform del jugador al que se le va a poner la prenda

    [SerializeField]
    private Vector3 _offset;    //Para colocar bien cada prenda

    #endregion

    #region methods

    //Metodo para instanciar la ropa
    public void show()
    {
        if (!dressed)
        {
            //Instanciamos la prenda
            _prefab = Instantiate(_clothes.prefab, _playerTransform.position + _offset, _playerTransform.rotation);

            _prefab.transform.parent = _playerTransform; //Lo hacemos hijo del jugador para que vayan juntos
            dressed = true;
        }
        else
        {
            Destroy(_prefab.gameObject);
            dressed = false;
        }
        
    }

    //Metodo para quitar la ropa
    #endregion


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
