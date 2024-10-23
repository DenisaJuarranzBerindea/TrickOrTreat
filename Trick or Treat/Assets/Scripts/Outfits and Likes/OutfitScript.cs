using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class OutfitScript : MonoBehaviour
{
    #region properties

    bool topBool = false;

    bool bottomBool = false;

    bool extraBool = false;

    #endregion

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
                topBool = true;
                break;
            case 1:
                bottom = g;
                bottomBool = true;
                break;
            case 2:
                extra = g;
                extraBool = true;
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
                topBool = false;
                break;
            case 1:
                bottom = null;
                bottomBool = false;
                break;
            case 2:
                extra = null;
                extraBool = false;
                break;
            default:

                break;
        }

    }



    public Garment getTop() { return top; }
    public Garment getBottom() { return bottom; }
    public Garment getExtra() { return extra; }

    public bool getBoolTop() { return topBool; }
    public bool getBoolBottom() { return bottomBool; }
    public bool getBoolExtra() { return extraBool; }

}
