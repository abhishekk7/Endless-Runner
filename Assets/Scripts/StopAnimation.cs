using UnityEngine;
using System.Collections;

public class StopAnimation : MonoBehaviour {


    public GameObject player;
    private bool playAnimation = true;
    private int animationDuration = 45;
	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
        if (playAnimation)
        {
            player.GetComponent<Animation>().Play("Attack");
            --animationDuration;
            if (animationDuration == 0)
            {
                playAnimation = false;
                animationDuration = 60;
            }
        }
        else
        {
            player.GetComponent<Animation>().Play("idle");
            --animationDuration;
            if (animationDuration == 0)
            {
                playAnimation = true;
                animationDuration = 45;
            }
        }
	}
}
