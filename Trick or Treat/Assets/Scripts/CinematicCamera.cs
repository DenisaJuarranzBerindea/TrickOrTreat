using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class CinematicCamera : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.Instance.getCurrentState() != GameManager.GameStates.NEIGHBOUR)
        {
            Vector3 pos = new Vector3(495, -1077, 1834);
            this.GetComponentInParent<PlayableDirector>().time = 0;
        }
    }
}
