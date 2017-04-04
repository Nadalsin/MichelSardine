using UnityEngine;
using System.Collections;

public class SardineUserController : MonoBehaviour {
	SardineCharacter sardineCharacter;

    private int jumpCooldown = 0;
    private int jumpCount = 0;

    private Rigidbody sardRigid;

    public int limitJumpCooldown = 1000;

	void Start () {
		sardineCharacter = GetComponent<SardineCharacter> ();
        sardRigid = GetComponent<Rigidbody>();
	}
	

	void Update () {
        
		
		if (Input.GetKey(KeyCode.A)) {
			sardineCharacter.MoveBack();			
		}

		if (Input.GetKey(KeyCode.D)) {
			sardineCharacter.MoveForward();		
		}

		if (Input.GetKey(KeyCode.Space)) {
            if(jumpCooldown < limitJumpCooldown && jumpCount < 2)
            {
                sardineCharacter.TurnUp();
            }


            Debug.Log("Sauterelle " + jumpCooldown);
            jumpCooldown++;

        
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            if(jumpCount < 2)
            {
                jumpCooldown = 0;
                jumpCount++;
            }
        }
	}

    void OnCollisionEnter(Collision c)
    {

        if (c.gameObject.tag == "floor")
        { 
            sardRigid.velocity = new Vector3(0, 0, 0);
            
            jumpCooldown = 0;
            jumpCount = 0;
        }
    }
}
