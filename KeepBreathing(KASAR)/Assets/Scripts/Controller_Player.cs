using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;
using TMPro;

public class Controller_Player : MonoBehaviour
{

    public float jumpStrength;
	public float moveStrength;

	public bool isJump;

	public Slider Mask;
	public Slider Health;
	public Slider Stamina;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown("space")){
        	
			if((GetComponent<Rigidbody>().velocity.y < 2f) && isJump){
				gameObject.GetComponent<Rigidbody>().AddForce(Vector3.up * jumpStrength);
				isJump = false;
			}
			//this.GetComponent<Rigidbody> ().AddForce (new Vector3 (0, jumpStrength, 0));	
		}
		if (Input.GetKey("a")){
			this.GetComponent<Rigidbody> ().velocity = new Vector3
				(-moveStrength * Time.deltaTime, 
				this.GetComponent<Rigidbody>().velocity.y, 
				this.GetComponent<Rigidbody>().velocity.z);	
		}
		if (Input.GetKey("d")){
			this.GetComponent<Rigidbody> ().velocity = new Vector3
				(moveStrength * Time.deltaTime, 
				this.GetComponent<Rigidbody>().velocity.y, 
				this.GetComponent<Rigidbody>().velocity.z);
		}
		if (Input.GetKey("w")){
			this.GetComponent<Rigidbody> ().velocity = new Vector3
				(this.GetComponent<Rigidbody>().velocity.x, 
				this.GetComponent<Rigidbody>().velocity.y, 
				moveStrength * Time.deltaTime );
		}
		if (Input.GetKey("s")){
			this.GetComponent<Rigidbody> ().velocity = new Vector3
				(this.GetComponent<Rigidbody>().velocity.x, 
				this.GetComponent<Rigidbody>().velocity.y, 
				-moveStrength * Time.deltaTime );
		}
    }

    private void OnCollisionStay(Collision collision){
		if (collision.gameObject.CompareTag("ground")){
			isJump = true;
			//Debug.Log(collision.gameObject);

			Mask.value -= Time.deltaTime * 0.5f;
			Health.value -= Time.deltaTime * 0.5f;
			Stamina.value -= Time.deltaTime * 0.1f;

			//Debug.Log(HP.value);
		}

		if (collision.gameObject.CompareTag("obs")){
			isJump = true;
			Debug.Log(collision.gameObject);
			//Debug.Log(HP.value);
		}

		if (collision.gameObject.CompareTag("mask")){

			Mask.value = 10f;

			Destroy (collision.gameObject);
			
		}

		if (collision.gameObject.CompareTag("health")){

			Health.value = 10f;
			
			Destroy (collision.gameObject);
			
		}

		if (collision.gameObject.CompareTag("stamina")){

			Stamina.value = 10f;
			
			Destroy (collision.gameObject);
			
		}
	}

}
