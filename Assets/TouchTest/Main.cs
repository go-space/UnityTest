namespace TouchTest
{
	using UnityEngine;
	using UnityEngine.UI;
	using System.Collections;
	using System.Collections.Generic;
	
	public class Main : MonoBehaviour {
	
		[SerializeField]
		Canvas canvas;
		
		[SerializeField]
		Button ClearButton;
		
		[SerializeField]
		InputField LogInputField;
		
		[SerializeField]
		GameObject FingerPointer;
		
		[SerializeField]
		GameObject Container;
		
		Dictionary<int, GameObject> pointerList;
		
		float scale;
		
		// Use this for initialization
		void Start () {
			//Debug.Log(Screen.width + "/" + Screen.height);
			pointerList = new Dictionary<int, GameObject>();
			LogInputField.text = "Start!";
			ClearButton.onClick.AddListener(() => {
				Debug.Log("hoge");
				LogInputField.text = "";//Input.touchCount.ToString();
				//foreach (GameObject in pointerList.Values)
				
				foreach (GameObject go in pointerList.Values)
				{
					Destroy(go);
				}
				pointerList.Clear();
			});
			
			float scaleX = 2048 / Screen.width;
			float scaleY = 1536 / Screen.height;
			scale = scaleY;
			
			
			Debug.Log(canvas.transform.localScale);
			
		}
		
		// Update is called once per frame
		void Update () {
			GameObject go;
			//Debug.Log(Input.touchCount);
			List<int> fingerIds = new List<int>();
			List<int> deleteIds = new List<int>();
			for(int i = 0; i < Input.touchCount; i++)
			{
				Touch touch = Input.GetTouch(i);
				fingerIds.Add(touch.fingerId);
				//LogInputField.text += touch.fingerId + "\n";
				//Debug.Log(touch.fingerId + ">" + touch.position);
				if (!pointerList.ContainsKey(touch.fingerId))
				{
					Vector2 position = new Vector2(touch.position.x / canvas.transform.localScale.x, touch.position.y / canvas.transform.localScale.y);
					go = (GameObject)Instantiate(FingerPointer, position, Quaternion.identity);
					go.transform.SetParent(Container.transform, false);
					pointerList.Add(touch.fingerId, go);
					/*
					go.transform.position = new Vector2(
						go.transform.position.x * scale,
						go.transform.position.y * scale
					);
					*/
				}
				go = pointerList[touch.fingerId];
				go.transform.position = touch.position;
			}
			foreach (var fingerId in pointerList.Keys)
			{
				if (!fingerIds.Contains(fingerId))
				{
					deleteIds.Add(fingerId);

				}
			}
			foreach (var fingerId in deleteIds)
			{
				go = pointerList[fingerId];
				pointerList.Remove(fingerId);
				Destroy(go);
			}
			
		}
	}
}
/*
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
		Debug.Log(Input.touchCount);
		for(int i = 0; i < Input.touchCount; i++)
		{
			Touch touch = Input.GetTouch(i);
			Debug.Log(touch.fingerId + ">" + touch.position);
		}
	}
}
*/