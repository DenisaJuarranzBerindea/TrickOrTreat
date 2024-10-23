using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public struct Puntuacion
{
    public int cute, spooky, funny;

    public int orig;
    public int theme;
}

public class NeighbourScript : MonoBehaviour
{

    [SerializeField]
    Neighbour neighbour;


   public Neighbour GetNeighbour() { return neighbour; }
   public void setNeighbout(Neighbour n) {  neighbour = n; }

   public Puntuacion judgeCostume(GameObject p)
    {

        Puntuacion aux;
        aux = new Puntuacion();
        int themeCount = 0;

        OutfitScript outfit = p.GetComponent<OutfitScript>();


        Garment top = outfit.getTop();
        Garment bot = outfit.getBottom();
        Garment ex = outfit.getExtra();

        if (top != null)
        {

            aux.cute += top.cute;
            aux.spooky += top.spooky;
            aux.funny += top.funny;

        }
        if (bot != null)
        {
            aux.cute += bot.cute;
            aux.spooky += bot.spooky;
            aux.funny += bot.funny;
        }
        if (ex != null)
        {
            aux.cute += ex.cute;
            aux.spooky += ex.spooky;
            aux.funny += ex.funny;
        }

        aux.cute = aux.cute/3;
        aux.spooky = aux.spooky/3;
        aux.funny = aux.funny/3;


        // SERIE
        if (neighbour.series != SERIES.NONE)
        {
            if (top != null && top.series == neighbour.series) { themeCount++; }
            if (bot != null && bot.series == neighbour.series) themeCount++;
            if (ex != null && ex.series == neighbour.series) themeCount++;

        }


        aux.theme = themeCount;

        // ORIGINALIDAD

        // todos son distintos
        if (top.series != bot.series 
            && top.series != ex.series 
            && bot.series != ex.series)
        {
            aux.orig = 3;
        }
        else if ((top.series != bot.series) || (top.series != ex.series)
            && ((ex.series != bot.series) || (ex.series != top.series))
            && ((bot.series != ex.series) || (bot.series != top.series)))
        {
            aux.orig = 2;
        }
        else { 
            aux.orig = 1;
        }

        return aux;
    }



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
