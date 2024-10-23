using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class CinematicCamera : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        // Usted pudiere ver este fragmento de codigo y pensar que es una ganyanada, y yo le comunico a usted que efectivamente tiene razon es una ganyanada de manual.
        if (GameManager.Instance.getCurrentState() != GameManager.GameStates.NEIGHBOUR)
        {
            Vector3 pos = new Vector3(495, -1077, 1834);
            this.GetComponentInParent<PlayableDirector>().time = 0;
        }
    }
}