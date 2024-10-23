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
    private Vector3 _offsetT;    //Para colocar bien cada prenda

    [SerializeField]
    private float rot;    //Rotacion en zs

    #endregion

    #region methods

    //Metodo para instanciar la ropa
    public void show()
    {
        if (!dressed)
        {
            //Instanciamos la prenda
            _prefab = Instantiate(_clothes.prefab, _playerTransform.position + _offsetT, _clothes.prefab.transform.rotation);
            _prefab.transform.Rotate(rot * Vector3.forward, Space.Self);
            _prefab.transform.parent = _playerTransform; //Lo hacemos hijo del jugador para que vayan juntos
            dressed = true;

            if (_playerTransform.gameObject.GetComponent<OutfitScript>() != null)
            {
                _playerTransform.gameObject.GetComponent<OutfitScript>().addGarment(_clothes, (int)_clothes.placement);
            }
        }
        else
        {
            Destroy(_prefab.gameObject);
            dressed = false;


            if (_playerTransform.gameObject.GetComponent<OutfitScript>() != null)
            {
                _playerTransform.gameObject.GetComponent<OutfitScript>().takeOffGarment((int)_clothes.placement);
            }
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
