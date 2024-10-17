using System.Collections;
using System.Collections.Generic;
using UnityEngine;

struct outfitPoints
{
    public int cute;
    public int spooky;
    public int funny;
}


public class PointsManager : MonoBehaviour
{

    int maxGarments = 3;
    // jugadores
    GameObject player1;
    GameObject player2;

    // Neighbour (level)
    GameObject neighbour;

    List<Garment> outfit1;
    List<Garment> outfit2;


    Garment[] outfit3;

    outfitPoints op1;
    outfitPoints op2;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }



    // 
    void getPlayersOutfits()
    {
        if (player1.GetComponent<OutfitScript>() != null) {
            outfit1.Add(player1.GetComponent<OutfitScript>().getTop());
            outfit1.Add(player1.GetComponent<OutfitScript>().getBottom());
            outfit1.Add(player1.GetComponent<OutfitScript>().getExtra());

            outfit3[0] = player1.GetComponent<OutfitScript>().getTop();
            outfit3[1] = player1.GetComponent<OutfitScript>().getBottom();
            outfit3[2] = player1.GetComponent<OutfitScript>().getExtra();
        }
        

        if (player2.GetComponent<OutfitScript>() != null) { 
            outfit2.Add(player2.GetComponent<OutfitScript>().getTop());
            outfit2.Add(player2.GetComponent<OutfitScript>().getBottom());
            outfit2.Add(player2.GetComponent<OutfitScript>().getExtra());
        }
    }


    void calculatePoints(GameObject p)
    {



        for(int i = 0; i<maxGarments; i++)
        {
            //op1.cute += 
        }

    }



}
