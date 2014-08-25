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

	private float currentSpeed = 0;

	void Start() 
	{
		// first get some slot items

		renderSlotItems ();

		//Spin ();
	}

	public void renderSlotItems()
	{
		// first get the set of items
		slotItemsPool = GameContext.Get.SlotItemsFactory.buildSlotItems();

		currentSlotItems = new List<SlotItemController>();

		// begin one item up of the first visible item thats why i = -1
		// and add one more at the end thats why itemsPerSlot + 1

		//Debug.Log ("esto se esta llamando o no?");

		for (int i = 0; i < itemsPerSlot + 2; i++)
		{
			// get the item to add into the slot

			SlotItemController slotItem = slotItemsPool[slotItemsPool.Count-1];

			Debug.Log("el item: " + slotItem.name + " va a ir de posicion: " + i);

			slotItemsPool.Remove(slotItem);

			RectTransform rect = slotItem.GetComponent<RectTransform>();

			slotItem.transform.parent = slotPanelPivot;

			float pos = (side * verticalGap * (i-1));

			rect.localPosition = new Vector3(0f, pos, 0f);

			currentSlotItems.Insert(0,slotItem);

			slotItem.gameObject.SetActive(true);
		}
	}

	public void Stop()
	{

	}

//	public void Spin(float speed)
//	{
//		StartCoroutine(spinRoutine)
//	}

	public IEnumerator spinRoutine(float speed)
	{
		// make each one of the items to spin

		StartCoroutine (drawLine ());
		
		StartCoroutine(UnityUtils.LerpAction(2, delegate(float t) {
			
			currentSpeed = Mathf.Lerp(currentSpeed, speed, t);
			
			//Debug.Log ("current: " + currentSpeed + " :: speed : " + speed + " :: t: " + t);
			
		}));

		yield return StartCoroutine (SpinSlotItem (speed));
	}

	private IEnumerator drawLine()
	{
		while (true) 
		{
			RectTransform slotRect = GetComponent<RectTransform>();
			
			//Debug.Log( slotItemRect.rect.max.y + " ++ " + slotItemRect.rect.min.y);
			
			Vector3 topOfSlot = 
				new Vector3(slotRect.transform.position.x, slotRect.rect.max.y+verticalGap,slotRect.transform.position.z );
			
			Vector3 bottomOfSlot = 
				new Vector3(slotRect.transform.position.x, slotRect.rect.min.y-verticalGap,slotRect.transform.position.z);
			
			//Debug.Log(topOfSlot + " :: " + bottomOfSlot);
			
			Debug.DrawLine(topOfSlot, bottomOfSlot);

			yield return null;
		}
	}

	private IEnumerator SpinSlotItem(float speed)
	{
		bool spinSlot = true;

		RectTransform slotRect = GetComponent<RectTransform>();

		Vector3 topOfSlot = 
			new Vector3(slotRect.transform.position.x, slotRect.rect.max.y+verticalGap,slotRect.transform.position.z );
		
		Vector3 bottomOfSlot = 
			new Vector3(slotRect.transform.position.x, slotRect.rect.min.y-verticalGap,slotRect.transform.position.z);
		
		while (spinSlot) // per frame
		{
			for(int i = 0; i < currentSlotItems.Count; i++)
			{
				SlotItemController slotItem = currentSlotItems[i];

				//Debug.Log("vamos a ver que item viene: " + currentSlotItems.Count);

				if(currentSpeed == speed)
				{
					spinSlot = false;

					// [TODO] revisar que el slot machine quede en un estado en el que se pueda 
					// apreciar bien el item ganado

					break;
				}

				slotItem.transform.position -= new Vector3(0f,currentSpeed,0f);

				// if it surpases theslotItemsPool[i].gameObject.SetActive(true); size of the slot view then return it back again to the pool

				Debug.Log(slotItem.transform.position.y + "  " + bottomOfSlot.y);

				if(slotItem.transform.position.y < bottomOfSlot.y)
				{
					//Debug.Break();

					// add the last item back to the pool
					slotItemsPool.Insert(0,slotItem);

					slotItem.gameObject.SetActive(false);

					slotItem.transform.parent = null;

					currentSlotItems.Remove(slotItem);

					// insert the new slot item at the end
					currentSlotItems.Insert(0,slotItemsPool[currentSlotItems.Count - 1]);

					currentSlotItems[0].gameObject.SetActive(true);

					slotItemsPool.RemoveAt(slotItemsPool.Count - 1);

					currentSlotItems[0].transform.parent = slotPanelPivot;

					currentSlotItems[0].transform.position = topOfSlot;

					//Debug.Break();
				}

			}

			yield return null;		
		}

		Debug.Log("salimos del infierno de hilo");
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
