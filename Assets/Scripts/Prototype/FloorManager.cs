using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorManager : MonoBehaviour
{
    public Transform[] goals;

    public static FloorManager instance;

    void Awake()
    {
        if (instance == null){
            //DontDestroyOnLoad(this.gameObject);
            instance = this;
        }
        else if (instance != this){
            Destroy(this.gameObject);
        }
        goals = this.GetComponentsInChildren<Transform>();
    }
    public Transform[] GetGoals() {
        if (goals.Length == 0)
            return null;

        return goals;
    }
}
