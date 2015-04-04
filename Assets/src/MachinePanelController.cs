using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MachinePanelController : MonoBehaviour {

	public List<SlotPanelController> Slots;

	private bool playingGame = false;//esto lo voy a estashear para despues.

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	[ContextMenu("play game")]
	public void playGameButtonHandler(){

		StartCoroutine (playSlotsRoutine ());
	}

	public void hacerFeo(){
		Debug.Log ("yeah");
	}

	public IEnumerator playSlotsRoutine (){

		// first play the first slot

		if (!playingGame) 
		{
			playingGame = true;

			yield return StartCoroutine (playSlot(Slots[0]));

			playingGame = false;
		}
	}

	public IEnumerator playSlot(SlotPanelController slot){

		yield return StartCoroutine(slot.spinRoutine (13));

		yield return new WaitForSeconds (1);

		yield return StartCoroutine(slot.spinRoutine (0));
	}
}
