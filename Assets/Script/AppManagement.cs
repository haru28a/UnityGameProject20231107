using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class AppManagement : MonoBehaviour {

	//変数定義
	private int DebugScene;
	//定数定義
	private const int TITLESCENE = 1;
	private const int MAXSCENE = 4;

	// Use this for initialization
	void Start () {
		//遷移したシーンの情報を格納
		SceneManager.sceneLoaded += OnSceneLoaded;
	}

	void Awake () {
		//AppManagementオブジェクト保持用
		DontDestroyOnLoad(this);
	}

    void OnSceneLoaded( Scene scene, LoadSceneMode mode ) {
		//シーン遷移時に実行
		if(scene.name == "Title"){
			//AppManagementは維持されるので初期化処理が必要な変数は初期化しておく
			DebugScene = TITLESCENE;
		}
    }
	
	// Update is called once per frame
	void Update () {
		//タイトル画面に戻る デバッグ用ロジック
		if (Input.GetKey(KeyCode.H)) {
			SceneManager.LoadScene ("Title");
		}

		//スペースキーでシーン遷移 デバッグ用ロジック
		if (Input.GetKey(KeyCode.A)) {
			DebugScene++;
			if (DebugScene > MAXSCENE) {
				DebugScene = TITLESCENE;
			}
			SceneManager.LoadScene (DebugScene);
		}
	}
}