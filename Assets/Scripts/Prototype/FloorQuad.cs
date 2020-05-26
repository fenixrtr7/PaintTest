using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TEAM_OWNER{
    ICE,
    FIRE
}
public class FloorQuad : MonoBehaviour
{
    public TEAM_OWNER teamOwner;
    Color fireColor = Color.red;
    Color iceColor = Color.blue;
    Color floorColor = Color.green;

    string FIRECLAN = "FIRECLAN";
    string ICECLAN = "ICECLAN";
    // Start is called before the first frame update

    public bool isGoal = false;
    private void Awake()
    {
            this.GetComponent<MeshRenderer>().materials[0].color = floorColor;

    }

    private void OnTriggerStay(Collider other)
    {
        
        if (other.CompareTag(FIRECLAN) || other.CompareTag(ICECLAN) ) {
            Debug.Log("Colisionamos");
            if (other.CompareTag(FIRECLAN)){
                this.GetComponent<MeshRenderer>().materials[0].color = fireColor;
                teamOwner = TEAM_OWNER.FIRE;
            }
            if (other.CompareTag(ICECLAN))
            {
                this.GetComponent<MeshRenderer>().materials[0].color = iceColor;
                teamOwner = TEAM_OWNER.ICE;
            }
            if (other.GetComponent<CharacterMovement>().IA && this.isGoal)
            {
                isGoal = false;
                other.GetComponent<CharacterMovement>().setNextGoal();
                Debug.Log("other.GetComponent<CharacterMovement>().setNextGoal();");
            }

        }
    }
}
