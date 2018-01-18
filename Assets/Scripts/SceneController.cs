using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneController : MonoBehaviour {
	[SerializeField] GameObject[] cubes;
	[SerializeField] UIController ui;

	private Rigidbody[] rbs;
	private ThrowingUP[] make;

	private bool needTrack;
	private bool isResting;

	public int GetNums() {
		return make [0].GetNumber () + make [1].GetNumber ();
	}

	public void ThrowCubes() {
		make [0].Throw ();
		make [1].Throw ();
		needTrack = true;
	}

	public bool CheckRest() {
		return rbs [0].velocity == Vector3.zero && rbs [1].velocity == Vector3.zero;
	}

	void Start () {
		needTrack = false;
		isResting = true;

		rbs = new Rigidbody[2];
		rbs[0] = cubes [0].GetComponent<Rigidbody> ();
		rbs[1] = cubes [1].GetComponent<Rigidbody> ();

		make = new ThrowingUP[2];
		make [0] = cubes [0].GetComponent<ThrowingUP> ();
		make [1] = cubes [1].GetComponent<ThrowingUP> ();
	}

	void Update () {
		if (needTrack)
		if (isResting) {
			if (!CheckRest())
				isResting = false;
		} else {
			if (CheckRest ()) {
				needTrack = false;
				isResting = true;

				int num = GetNums ();

				ui.EndThrow (num);
			}
		}
	}
}
