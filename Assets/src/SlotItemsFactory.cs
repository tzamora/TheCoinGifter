using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SlotItemsFactory : MonoBehaviour{

	public List<SlotItemController> SlotItemPrefabs; 

	// Use this for initialization
	void Start () {
	
	}
	
	public List<SlotItemController> BuildSlotItems()
	{
		// based on some logic (or randomness) build
		// a list of randomly slot items

		return new List<SlotItemController>();
	}
}
