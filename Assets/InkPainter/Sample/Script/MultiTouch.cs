using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Es.InkPainter.Sample;

public class MultiTouch : MonoBehaviour
{
    #region Variables
    MousePainter mousePainter;
    public float intervalTime = 0.1f;

    #endregion

    // Use this for initialization
    void Start()
    {
        mousePainter = FindObjectOfType<MousePainter>();

        InvokeRepeating("UpdateInterval", intervalTime, intervalTime);
    }

    // Update is called once per frame
    void Update()
    {


        ////////////////
        // Touch myTouch = Input.GetTouch(0);

        // Touch[] myTouches = Input.touches;
        // for(int i = 0; i < Input.touchCount; i++)
        // {
        //     //Do something with the touches
        // }
    }


    void UpdateInterval()
    {
        //use this as the secondary update.

        var tapCount = Input.touchCount;

        for (var i = 0; i < tapCount; i++)
        {
            var touch = Input.GetTouch(i);

            //Do whatever you want with the current touch.
            //Debug.Log("Active");
            StartCoroutine(mousePainter.PaintGame(mousePainter.brush1, touch.position));

            Debug.Log("amount touch");
        }
    }
}
