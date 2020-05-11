using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControllerScript : MonoBehaviour
{
	// Start is called before the first frame update
	private Rigidbody2D rb;
	private Enemy enemy;
	private float rotationSpeed = 0.2f;

	void Start() {
		enemy = GetComponent<Enemy>();
		rb = enemy.GetComponent<Rigidbody2D>();
	}

	public void Move(Vector2 dir) {
		rb.velocity = dir * enemy.speed;
	}

	public void Look(Vector2 dir) {
		float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
		transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
	}

}
