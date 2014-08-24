using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SlotPanelController : MonoBehaviour {

	public int itemsPerSlot = 3;

	public float SlotSpeed = 10;

	public List<SlotItemController> slotItemsPool;

	public List<SlotItemController> currentSlotItems;

	public Transform slotPanelPivot;

	public float verticalGap = 10;

	public int side = -1;

	void Start() 
	{
		// first get some slot items

		renderSlotItems ();

		Spin ();
	}

	public void renderSlotItems()
	{
		// first get the set of items
		slotItemsPool = GameContext.Get.SlotItemsFactory.buildSlotItems();

		// begin one item up of the first visible item thats why i = -1
		// and add one more at the end thats why itemsPerSlot + 1

		for (int i = 0; i < itemsPerSlot + 2; i++)
		{
			RectTransform rect = slotItemsPool[i].GetComponent<RectTransform>();

			slotItemsPool[i].transform.parent = slotPanelPivot;

			float pos = (side * verticalGap * (i-1));

			Debug.Log("viene la posicion " + pos);
			
			rect.localPosition = new Vector3(0f, pos, 0f);

			currentSlotItems.Add(slotItemsPool[i]);

			slotItemsPool[i].gameObject.SetActive(true);

			slotItemsPool.Remove(slotItemsPool[i]);
		}
	}

	public void Stop()
	{

	}

	public void Spin()
	{
		// make each one of the items to spin

		StartCoroutine (SpinSlotItem ());
	}

	private IEnumerator SpinSlotItem()
	{
		while (true) // per frame
		{
			for(int i = 0; i < currentSlotItems.Count; i++)
			{
				SlotItemController slotItem = currentSlotItems[i];

				slotItem.transform.position -= new Vector3(0f,SlotSpeed,0f);

				// if it surpases theslotItemsPool[i].gameObject.SetActive(true); size of the slot view then return it back again to the pool

				Debug.Log("[ " + slotItem.transform.localPosition + " ]");
				Debug.Log("[ " + (transform.localPosition.y - (itemsPerSlot * verticalGap)) + " ]");

				if(slotItem.transform.localPosition.y < (transform.localPosition.y - (itemsPerSlot * verticalGap)) -100)
				{
					// add the last item back to the pool
					slotItemsPool.Insert(0,slotItem);

					slotItem.gameObject.SetActive(false);
					
					currentSlotItems.Remove(slotItem);

					// insert the new slot item at the end
					currentSlotItems.Insert(0,slotItemsPool[currentSlotItems.Count - 1]);

					currentSlotItems[0].gameObject.SetActive(true);

					slotItemsPool.RemoveAt(slotItemsPool.Count - 1);

					// place the 

					currentSlotItems[0].transform.parent = slotPanelPivot;

					currentSlotItems[0].transform.localPosition = 
						new Vector3(0f,(side * verticalGap * (-1)),0f);
				}

			}

			yield return null;		
		}
	}

	public SlotItemController GetSlotItem(SlotItemPositionEnum itemPos)
	{
		//
		// the slot item in the respective position
		//

		return null;
	}

//	void OnGUI() {
//		if (GUI.Button (new Rect (10, 70, 50, 30), "Click")) {
//
//			RectTransform rect = currentSlotItems[0].GetComponent<RectTransform>();
//		}
//	}


}
