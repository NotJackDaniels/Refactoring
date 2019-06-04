using UnityEngine;
using System.Collections;

public class miniCameraScript : MonoBehaviour {


	public Transform MiniMapTarget;


	void Update(){


	}

	void LateUpdate () {

		transform.position = new Vector3 (MiniMapTarget.position.x,transform.position.y,MiniMapTarget.position.z);

		// для крутящейся камеры
		//transform.eulerAngles = new Vector3( transform.eulerAngles.x, MiniMapTarget.eulerAngles.y, transform.eulerAngles.z );

	}
}