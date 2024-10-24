using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum TYPE { CUTE, SPOOKY, FUNNY }
public enum PLACEMENT { TOP, BOTTOM, EXTRA }
public enum SERIES { NONE, WITCH, CLOWN, DEVIL, PUMPKING, PIRATE, MUMMY, ALIEN, GHOST, DEATH, VAMPIRE }

[CreateAssetMenu(fileName = "New Garment", menuName = "Garment")]
public class Garment : ScriptableObject
{
    // 
    public new string name;
    public string description;

    // modelo 3d
    public GameObject prefab;

    // posicion (parte del cuerpo) ENUM
    public PLACEMENT placement;
    // series
    public SERIES series;


    public int cute;
    public int spooky;
    public int funny;

}
