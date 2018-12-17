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

        this.Shoot(new Vector2(0f, 3f));
	}

    public void Shoot(Vector2 force)
    {
        this.rigidBody.AddForce(force, ForceMode2D.Impulse);
    }

}
