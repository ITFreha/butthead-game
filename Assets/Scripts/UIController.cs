using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour {
	[SerializeField] SceneController controller;
	[SerializeField] GameObject rules;
	[SerializeField] GameObject throwingPanel;
	[SerializeField] GameObject AnsPanel;

	private Text ans;

	public void OpenRules() {
		if (rules.activeSelf) {
			rules.SetActive (false);

			if (controller.CheckRest ()) {
				throwingPanel.SetActive (true);
				AnsPanel.SetActive (true);
			}
		} else {
			rules.SetActive (true);
			throwingPanel.SetActive (false);
			AnsPanel.SetActive (false);
		}
	}

	public void Throw() {
		throwingPanel.SetActive (false);
		AnsPanel.SetActive (false);

		controller.ThrowCubes ();
	}

	public void EndThrow(int num) {
		ans.text = TextOfDice.text [num - 2];

		rules.SetActive (false);
		throwingPanel.SetActive (true);
		AnsPanel.SetActive (true);
	}

	void Start () {
		ans = AnsPanel.GetComponentInChildren<Text> ();
		rules.SetActive (false);
		AnsPanel.SetActive (false);
	}
}
