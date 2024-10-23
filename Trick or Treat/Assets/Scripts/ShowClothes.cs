using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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
    private float rotZ;    //Rotacion en y

    [SerializeField]
    private float rotY;    //Rotacion en y

    #endregion

    #region methods

    //Metodo para instanciar la ropa
    public void show()
    {
        if (!dressed)
        {
            if (_playerTransform.gameObject.GetComponent<OutfitScript>() != null)
            {
                //Si Ya tiene un top quitamos la prenda
                if (_playerTransform.gameObject.GetComponent<OutfitScript>().getBoolTop()
                    && _clothes.placement == PLACEMENT.TOP)
                {
                    RemoveTopChildren();
                }
                //Si Ya tiene un bottom quitamos la prenda
                else if (_playerTransform.gameObject.GetComponent<OutfitScript>().getBoolTop()
                    && _clothes.placement == PLACEMENT.BOTTOM)
                {
                    RemoveBottomChildren();
                }
                //Si Ya tiene un extra quitamos la prenda
                else if (_playerTransform.gameObject.GetComponent<OutfitScript>().getBoolTop()
                    && _clothes.placement == PLACEMENT.EXTRA)
                {
                    RemoveExtraChildren();
                }

                _playerTransform.gameObject.GetComponent<OutfitScript>().addGarment(_clothes, (int)_clothes.placement);

            }

            //Instanciamos la prenda
            _prefab = Instantiate(_clothes.prefab, _playerTransform.position + _offsetT, _clothes.prefab.transform.rotation);
            _prefab.transform.Rotate(rotZ * Vector3.forward, Space.Self);
            _prefab.transform.Rotate(rotY * Vector3.up, Space.Self);
            _prefab.transform.parent = _playerTransform; //Lo hacemos hijo del jugador para que vayan juntos
            dressed = true;

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

    private void RemoveTopChildren()
    {
        //Buscamos el hijo que queremos eliminar
        int i = 0;

        while (i < _playerTransform.childCount)
        {
            Transform child = _playerTransform.GetChild(i);

            if (child.gameObject.GetComponent<istop>() != null)
            {
                Destroy(child.gameObject);
            }
            i++;
        }
    }
    
    private void RemoveBottomChildren()
    {
        //Buscamos el hijo que queremos eliminar
        int i = 0;

        while (i < _playerTransform.childCount)
        {
            Transform child = _playerTransform.GetChild(i);

            if (child.gameObject.GetComponent<isBottom>() != null)
            {
                Destroy(child.gameObject);
            }
            i++;
        }
    }
    private void RemoveExtraChildren()
    {
        //Buscamos el hijo que queremos eliminar
        int i = 0;

        while (i < _playerTransform.childCount)
        {
            Transform child = _playerTransform.GetChild(i);

            if (child.gameObject.GetComponent<isExtra>() != null)
            {
                Destroy(child.gameObject);
            }
            i++;
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
