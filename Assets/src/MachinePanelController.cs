using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MachinePanelController : MonoBehaviour {

	public List<SlotPanelController> Slots;

	private bool playingGame = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void playGameButtonHandler(){

		StartCoroutine (playSlotsRoutine ());
	}

	public IEnumerator playSlotsRoutine (){

		// first play the first slot

		if (!playingGame) 
		{
			playingGame = true;

			Debug.Log("PRENDIENDO!!@@");

			yield return StartCoroutine (playSlot(Slots[0]));

	//		foreach (SlotPanelController slot in Slots) {
	//		
	//			yield return StartCoroutine (playSlot(slot));
	//
	//		}

			playingGame = false;

			Debug.Log("$$%%APAGANDO");

		}
	}

	public IEnumerator playSlot(SlotPanelController slot){

		yield return StartCoroutine(slot.spinRoutine (13));

		yield return new WaitForSeconds (2);

		Debug.Log ("detener el slot");

		yield return StartCoroutine(slot.spinRoutine (0));
	}
}
