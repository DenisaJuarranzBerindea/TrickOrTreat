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
