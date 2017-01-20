using UnityEngine;
using System.Collections;

public class DebugTesting : MonoBehaviour {

    public Player player;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(KeyCode.H)){
            player.resourceComponent.DamageHealth(50);
        }

        if (Input.GetKeyDown(KeyCode.T))
        {

        }
    }
}
