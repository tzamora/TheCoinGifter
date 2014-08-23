using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SlotItemsFactoryController : MonoBehaviour
{
	public List<SlotItemController> SlotItemPrefabs; 

	// Use this for initialization
	void Start ()
	{

	}
	
	public List<SlotItemController> buildSlotItems ()
	{
		// based on some logic (or randomness) build
		// a list of randomly slot items

		List<SlotItemController> slotItemsToAdd = new List<SlotItemController> ();

		for (int i = 0; i < 3; i++) {
			slotItemsToAdd.Add( getSlotItemPrefab("clock") );
		}

		return slotItemsToAdd;
	}

	public SlotItemController getSlotItemPrefab (string id)
	{
		// first get the prefab

		SlotItemController slotItemPrefab = SlotItemPrefabs.Find ( slotItem => slotItem.ID == id );

		// then instantiated

		SlotItemController slotItemInstance = GameObject.Instantiate(slotItemPrefab, Vector3.zero, Quaternion.identity) as SlotItemController;

		return slotItemInstance;

	}
}
