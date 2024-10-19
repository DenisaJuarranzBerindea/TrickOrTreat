using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "New Neighbour", menuName = "Neighbour")]
public class Neighbour : ScriptableObject
{
    // 
    public new string name;
    public string description;

    // modelo 3d
    public GameObject prefab;

    // IDEAL
    public int cute;
    public int spooky;
    public int funny;

    //
    public SERIES series;          // [1-10]
    public int originality;    // [1-10]

}
