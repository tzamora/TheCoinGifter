using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SlotItemsFactoryController : MonoBehaviour
{
	public List<SlotItemController> SlotItemPrefabs;

	public string[] SlotItemNames;

	// Use this for initialization
	void Start ()
	{

	}
	
	public List<SlotItemController> buildSlotItems ()
	{
		// based on some logic (or randomness) build
		// a list of randomly slot items

		List<SlotItemController> slotItemsToAdd = new List<SlotItemController> ();

		for (int i = 0; i < 11; i++) {

			// [TODO] try to set an algorithm here to randomize the items

			slotItemsToAdd.Add( getSlotItemPrefab(SlotItemPrefabs[i].ID) );
		}

		slotItemsToAdd.Shuffle ();

		return slotItemsToAdd;
	}

	public SlotItemController getSlotItemPrefab (string id)
	{
		// first get the prefab

		SlotItemController slotItemPrefab = SlotItemPrefabs.Find ( slotItem => slotItem.ID == id );

		// then instantiated

		SlotItemController slotItemInstance = GameObject.Instantiate(slotItemPrefab, Vector3.zero, Quaternion.identity) as SlotItemController;

		slotItemInstance.gameObject.SetActive (false);

		return slotItemInstance;

	}
}
