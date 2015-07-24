using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;

public class TouchTest : MonoBehaviour, IPointerDownHandler {

	public void OnPointerDown (PointerEventData eventData)
	{
		Debug.Log("OnPointerDown" + gameObject.name);
	}
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
		for(int i = 0; i < Input.touchCount; i++)
		{
			Touch touch = Input.GetTouch(i);
			Debug.Log(touch.fingerId + ">" + touch.position);
		}
	}
}
