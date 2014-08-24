using UnityEngine;
using System.Collections;

public class SlotItemController : MonoBehaviour {

	public string ID;

	public RectTransform itemPivot;

	void Start () {
		itemPivot.localPosition = new Vector3(0f,-itemPivot.rect.height / 2,0f);
	}
}
