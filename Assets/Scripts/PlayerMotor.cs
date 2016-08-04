using UnityEngine;
using System.Collections;

public class PlayerMotor : MonoBehaviour {

    private CharacterController controller;
    private float speed =5.0f;
    private float jumpForce = 50.0f;
    private Vector3 moveVector;
    private float verticalVelocity = 0.0f;
    private float gravity = 12.0f;
    private float animationDuration = 2.0f;
    private int frameCount;
    private bool isDead = false;
    private float startTime;
    
	// Use this for initialization
	void Start () {
        controller = GetComponent<CharacterController>();
            frameCount = 0;
            startTime = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
        if (isDead)
            return;
        if (transform.position.y < -10.0f)
            Death();
        if(Time.time-startTime<animationDuration)
        {
            controller.Move(Vector3.forward * speed * Time.deltaTime);
            return;
        }
        
        moveVector = Vector3.zero;
        if(controller.isGrounded)
        {
            verticalVelocity = -0.5f;
        }
        else
        {
            verticalVelocity -= gravity * Time.deltaTime;
        }

        //X - left and right
        moveVector.x = Input.GetAxis("Horizontal")*speed;  

        ////Y - up and down
        //frameCount++;
        //if(Input.GetKeyDown(KeyCode.Space) && controller.isGrounded)
        //{
        //    moveVector.y = jumpForce;
        //}

        ////if(frameCount==2)
        ////{
        ////    
        ////    frameCount = 0;
        ////}

        moveVector.y = verticalVelocity;
        //Z - forward and backward
        moveVector.z = speed;


        controller.Move(moveVector * Time.deltaTime);
	}


    //To change difficulty level
    public void SetSpeed(int modifier)
    {
        speed = 5.0f + modifier;
        Debug.Log(speed);
    }

    //Calle
    void OnControllerColliderHit(ControllerColliderHit hit)
    {

        if( (hit.point.z > transform.position.z + controller.radius)&&hit.gameObject.layer==8)
            Death();
        else if (hit.gameObject.layer==10) {
            CollectCoin(hit.gameObject);
        }
    }

    private void CollectCoin(GameObject coin)
    {
        GetComponent<Score>().OnCoinCollect();
        Destroy(coin);
    }

    private void Death()
    {
        isDead = true;
        GetComponent<Score>().OnDeath();
    }
}
