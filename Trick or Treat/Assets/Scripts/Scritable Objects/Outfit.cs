using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "New Outfit", menuName = "Outfit")]
public class Outfit : ScriptableObject
{
    public Garment top;
    public Garment bottom;
    public Garment extra;
}
