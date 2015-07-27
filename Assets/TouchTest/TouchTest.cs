namespace TouchTest
{
	using UnityEngine;
	using UnityEngine.EventSystems;
	using System.Collections;
	
	public class TouchTest : MonoBehaviour, IPointerDownHandler {
		
		public void OnPointerDown (PointerEventData eventData)
		{
			Debug.Log("OnPointerDown" + eventData.position);
		}
		
		// Use this for initialization
		void Start () {
		
		}
		
		// Update is called once per frame
		void Update () {
		
		}
	}
}
