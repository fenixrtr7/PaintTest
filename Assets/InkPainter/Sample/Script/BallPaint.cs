using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Es.InkPainter;

public class BallPaint : MonoBehaviour
{

    [SerializeField]
    private Brush brush = null;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("floor"))
        {
            var canvas = other.GetComponent<InkCanvas>();
            if (canvas != null)
                canvas.Paint(brush, transform.position);

            Destroy(gameObject);
        }
    }
}
