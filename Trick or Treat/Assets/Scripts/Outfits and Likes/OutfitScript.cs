using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class OutfitScritp : MonoBehaviour
{
    [SerializeField]
    Garment top;
    [SerializeField]
    Garment bottom;
    [SerializeField]
    Garment extra;


    /// AVISO DE GANYANADA EXTREMA, NO ME COPIEIS

    /// <summary>
    /// la prenda y el indice, de 0 a 2
    /// </summary>
    /// <param name="g"></param>
    /// <param name="i"></param>
    //
    public void addGarment(Garment g, int i)
    {
        switch (i)
        {
            case 0:
                top = g;
                break;
            case 1:
                bottom = g;
                break;
            case 2:
                extra = g;
                break;
            default:

                break;
        }
    }
    public void takeOffGarment(int i)
    {
        switch (i)
        {
            case 0:
                top = null;
                break;
            case 1:
                bottom = null;
                break;
            case 2:
                extra = null;
                break;
            default:

                break;
        }

    }



    Garment getTop() { return top; }
    Garment getBottom() { return bottom; }
    Garment getExtra() { return extra; }
}
