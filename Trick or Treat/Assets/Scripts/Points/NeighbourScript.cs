using System.Collections;
using System.Collections.Generic;
using UnityEngine;


struct Puntuacion
{
    public int cute, spooky, funny;

    public int orig;
    public int theme;
}

public class NeighbourScript : MonoBehaviour
{

    [SerializeField]
    Neighbour neighbour;



    void setNeighbout(Neighbour n) {  neighbour = n; }

    Puntuacion judgeCostume(GameObject p)
    {
        Puntuacion aux;
        int themeCount = 0;

        OutfitScript outfit = p.GetComponent<OutfitScript>();


        // puntuacion basica
        aux.cute = (outfit.getTop().cute + outfit.getBottom().cute + outfit.getExtra().cute)/3;
        aux.spooky = (outfit.getTop().spooky + outfit.getBottom().spooky + outfit.getExtra().spooky) /3;
        aux.funny = (outfit.getTop().funny + outfit.getBottom().funny + outfit.getExtra().funny)/3;


        // SERIE
        if(neighbour.series != SERIES.NONE)
        {
            if (outfit.getTop().series == neighbour.series) { themeCount++; }
            if (outfit.getBottom().series == neighbour.series) themeCount++;
            if (outfit.getExtra().series == neighbour.series) themeCount++;

        }


        aux.theme = themeCount;

        // ORIGINALIDAD
        if (themeCount == 3) aux.orig = 0;
        else if(themeCount == 2) aux.orig = 1;
        else if(themeCount == 1) aux.orig = 2;
        aux.orig = 0;


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
