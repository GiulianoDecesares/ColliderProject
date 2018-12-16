using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rigidBody;

	// Use this for initialization
	void Start ()
    {
        this.rigidBody = this.gameObject.GetComponent<Rigidbody2D>();

        Vector2 force = new Vector2(10, 10);

        this.Move(force);
	}

    public void Move(Vector2 force)
    {
        this.rigidBody.AddForce(force);
    }

}
