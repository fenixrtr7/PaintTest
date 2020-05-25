using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Es.InkPainter;

public class BallPaint : MonoBehaviour
{

    [SerializeField]
    private Brush brush = null;
    Rigidbody rigid;

    private void Start() {
        rigid = GetComponent<Rigidbody>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("floor"))
        {
            var canvas = other.GetComponent<InkCanvas>();
            if (canvas != null)
                canvas.Paint(brush, transform.position);

            //Destroy(gameObject);
            gameObject.SetActive(false);
        }
    }

    private void OnEnable() {
        ManagerBall.instance.listBalls.Remove(gameObject);
        // rigid.useGravity = true;
    }

    private void OnDisable() {
        //
        ManagerBall.instance.listBalls.Add(gameObject);
        rigid.useGravity = false;
        rigid.velocity = Vector3.zero;

        transform.position = new Vector3(0, -10, 0);
    }
}
