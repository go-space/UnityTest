namespace CoroutineTest
{
	using UnityEngine;
	using UnityEngine.UI;
	using System.Collections;
	
	public class Main : MonoBehaviour {
		[SerializeField]
		Button buttonA;
		
		[SerializeField]
		Button buttonB;
		
		Coroutine MethodCoroutine;
		bool value = true;
		
		// Use this for initialization
		void Start () {
			buttonA.onClick.AddListener(() => {
				//Debug.Log("buttonA");
				
				if (MethodCoroutine != null)
				{
					Debug.Log("稼働中だった");
					StopCoroutine(MethodCoroutine);
					MethodCoroutine = null;
				}
				MethodCoroutine = StartCoroutine(CoroutineMethod());
			});
			buttonB.onClick.AddListener(() => {
				//Debug.Log("buttonB");
				value = false;
				StopCoroutine(MethodCoroutine);
				Debug.Log(MethodCoroutine);
				MethodCoroutine = null;
			});
		}
		
		// Update is called once per frame
		void Update () {
			//Debug.Log(Time.time);
			//Debug.Log("==========");
		}
		
		IEnumerator CoroutineMethod ()
		{
			
			for (int i = 0; i < 100; i++)
			{
				Debug.Log(i);
				//返り値はなんでもいい？必ず次のフレームで再開？
				yield return null;
			}
			/**/
			/*
			while (true)
			{
				yield return null;
			}
			*/
			/*
			Debug.Log("Before");
			yield return value;
			Debug.Log("After");
			*/
		}
	}
}
