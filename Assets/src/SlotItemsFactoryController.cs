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




			//GameObject.Instantiate(

			return new List<SlotItemController> ();
	}

	public void getSlotItemPrefab (string id)
	{
		switch (id) 
		{
			case "ruby":
			break;
			case "money":
			break;
			case "heart":
			break;
			default:
			break;
		}
	}
}
