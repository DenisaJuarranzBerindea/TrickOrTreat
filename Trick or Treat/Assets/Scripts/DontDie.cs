using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class DontDie : MonoBehaviour
{
    //--------------------------------------------------------------------------------------------------------//

    #region awake, start y update:

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    #endregion

    //--------------------------------------------------------------------------------------------------------//

}
