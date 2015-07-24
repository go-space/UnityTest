using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Main : MonoBehaviour {
	
	[SerializeField]
	Button buttonA;
	
	[SerializeField]
	Button buttonB;
	
	[SerializeField]
	Button buttonC;
	
	[SerializeField]
	Button buttonD;
	
	ResourceRequest request;
	
	Object prefab;
	GameObject go;
	
	// Use this for initialization
	void Start () {
		buttonA.onClick.AddListener(() => {
			prefab = Resources.Load("LoadCube", typeof(GameObject));
			go = (GameObject)Instantiate(prefab);
			//StartCoroutine(LoadAsync("LoadAsyncCube"));
		});
		
		buttonB.onClick.AddListener(() => {
			//go = (GameObject)Instantiate(request.asset);
			//go = (GameObject)Instantiate(prefab);
			Destroy(go);
			//Resources.UnloadAsset(go);
			Resources.UnloadAsset(prefab);
		});
		
		buttonC.onClick.AddListener(() => {
			/*
			if (go != null)
			{
				Destroy(go);
			}
			Debug.Log(go);
			Debug.Log(request.asset);
			*/
		});
		
		buttonD.onClick.AddListener(() => {
			/*
			if (request != null)
			{
				Debug.Log("UnloadAsset");
				Resources.UnloadAsset(request.asset);
				//Resources.UnloadAsset(request.asset);
			}
			*/
		});
	}
	
	// Update is called once per frame
	void Update () {
		//Debug.Log(request.isDone);
	}
	
	IEnumerator LoadAsync (string prefabPath)
	{
		request = Resources.LoadAsync<GameObject>(prefabPath);
		while (!request.isDone)
		{
			Debug.Log(request.isDone);
			yield return 0;
		}
		Debug.Log("ok" + request);
		//go = (GameObject)Instantiate(request.asset);
	}
}
