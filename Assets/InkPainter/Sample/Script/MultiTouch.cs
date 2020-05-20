using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Es.InkPainter.Sample;

public class MultiTouch : MonoBehaviour
{
	#region Variables
	MousePainter mousePainter;

	#endregion

    // Use this for initialization
    void Start()
    {
		mousePainter = FindObjectOfType<MousePainter>();
    }

    // Update is called once per frame
    void Update()
    {
        var tapCount = Input.touchCount;

        for (var i = 0; i < tapCount; i++)
        {
            var touch = Input.GetTouch(i);

            //Do whatever you want with the current touch.
			Debug.Log("Active");
			mousePainter.PaintGame(mousePainter.brush1);

        }
    }
}
