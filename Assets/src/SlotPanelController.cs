using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SlotPanelController : MonoBehaviour {

	List<SlotItemController> currentSlotItems;

	public Transform slotPanelPivot;

	public float verticalGap = 10;

	public int side = -1;

	void Start() 
	{
		// first get some slot items

		renderSlotItems ();
	}

	public void renderSlotItems()
	{
		// first get the set of items
		currentSlotItems = GameContext.Get.SlotItemsFactory.buildSlotItems();

		int index = 0;

		// add them to the slot
		foreach (SlotItemController slotItem in currentSlotItems) 
		{
			slotItem.transform.parent = slotPanelPivot;

			slotItem.transform.localPosition = new Vector3(0, side * verticalGap * index,0);

			index++;
		}
	}

	public void Stop()
	{

	}

	public void Spin()
	{

	}

	public SlotItemController GetSlotItem(SlotItemPositionEnum itemPos)
	{
		//
		// the slot item in the respective position
		//

		return null;
	}


}
