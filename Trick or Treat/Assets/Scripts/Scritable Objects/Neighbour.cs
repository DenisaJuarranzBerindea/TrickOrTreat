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

    // type
    public TYPE type;

    //
    public int theme;          // [1-10]
    public int originality;    // [1-10]

}
