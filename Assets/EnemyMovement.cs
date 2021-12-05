using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyMovement : MonoBehaviour
{

	public float speed;
	public float range;
	public bool moveRight;
	//public Slider slider;

	private float distToPlayer;
	public Transform player;

	// Use this for initialization
	void Update()
	{
		distToPlayer = Vector2.Distance(transform.position, player.position);

		if (distToPlayer >= range)
        {

        
			// Use this for initialization
			if (moveRight)
			{
			
			//slider.direction = Slider.Direction.RightToLeft;
			transform.Translate(2 * Time.deltaTime * speed, 0, 0);
			transform.localScale = new Vector2(1, 1);
			
			}
			else
			{
			//slider.direction = Slider.Direction.LeftToRight;
			transform.Translate(-2 * Time.deltaTime * speed, 0, 0);
			transform.localScale = new Vector2(-1, 1);
			}

		

		}
	}

	void OnTriggerEnter2D(Collider2D trig)
	{
		if (trig.gameObject.CompareTag("turn"))
		{

			if (moveRight)
			{
				moveRight = false;
			}
			else
			{
				moveRight = true;
			}
		}
	}
}
