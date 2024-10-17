using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class PointsManager : MonoBehaviour
{
    // jugadores
    GameObject player;
    GameObject player2;

    // Neighbour (level)
    GameObject neighbour;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }



    // 
    void getPlayerOutfit(GameObject p)
    {
        p.GetComponent<Garment>();


    }
}
