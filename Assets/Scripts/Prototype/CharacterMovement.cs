using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class CharacterMovement : MonoBehaviour
{
    public float speed=10;

    public bool IA = false;

    
    public int nextGoal = 0;

    // Update is called once per frame
    void Update()
    {
        if (IA)
            return;
        float h = Input.GetAxis("Vertical");
        float v = Input.GetAxis("Horizontal");
        Vector3 move = new Vector3(movementDelta(v), 0, movementDelta(h));
        this.transform.Translate(move);

        Debug.LogFormat("v {0}", v);
        Debug.LogFormat("h {0}", h);

    }
    void Start()
    {
        if (IA) {
            setNextGoal();
            
        }
    }
    public void setNextGoal() {
        if (FloorManager.instance.GetGoals() == null)
            return;
        nextGoal = Random.Range(1, FloorManager.instance.GetGoals().Length-1);

        NavMeshAgent agent = GetComponent<NavMeshAgent>();
        agent.destination = FloorManager.instance.GetGoals()[nextGoal].position;
        FloorManager.instance.GetGoals()[nextGoal].GetComponent<FloorQuad>().isGoal = true;
    }
    float movementDelta(float value) {
        return (value * speed) * Time.deltaTime;
    }
 
}
