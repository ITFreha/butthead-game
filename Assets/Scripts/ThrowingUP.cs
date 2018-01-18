using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowingUP : MonoBehaviour {
	[SerializeField] GameObject[] edges;
	private int TorqueTimes = 1;

	public GameObject g;

	private Rigidbody rb;
	private bool canThrow;
	private int counter;

	public int GetNumber () {
		float maxY = float.MinValue;
		int ans = -1;

		for (int i = 0; i < edges.Length; i++) {
			if (edges[i].transform.position.y > maxY) {
				maxY = edges [i].transform.position.y;
				ans = i;
			}
		}

		return ans + 1;
	}

	void Start () {
		rb = GetComponent<Rigidbody> ();

		canThrow = false;
		counter = TorqueTimes;
	}

	public void Throw() {
		canThrow = true;
		counter = 0;
	}

	void Update () {
		if (canThrow) {
			canThrow = false;

			float FX = Random.Range (-150, 150);
			float FY = Random.Range (700, 950);
			float FZ = Random.Range (-150, 150);

			rb.AddForce (FX, FY, FZ);
		} else if (counter < TorqueTimes) {
			float TX = Random.Range (50000000, 500000000);
			float TY = Random.Range (50000000, 500000000);
			float TZ = Random.Range (50000000, 500000000);

			rb.AddTorque (TX, TY, TZ);

			counter++;
		}
	}
}