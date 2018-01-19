using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TileManager : MonoBehaviour {

	public GameObject[] tilePrefab;
	private Transform playerTransform;
	private float spawnZ = -6.0f;
	private float tileLength = 12.0f;
	private int amnTileOnScreen = 10;
	private float safeZone = 15.0f;
	private int lastTileIndex = 0;

	private List<GameObject> activeTiles;

	// Use this for initialization
	void Start () {
		activeTiles = new List<GameObject> ();
		playerTransform = GameObject.FindGameObjectWithTag ("Player").transform;

		for(int i = 0; i < amnTileOnScreen; i++) {
			if (i < 3) {
				SpawnTile (0);
			} else {
				SpawnTile ();
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
		if(playerTransform.position.z - safeZone > (spawnZ - amnTileOnScreen * tileLength)) {
			SpawnTile ();
			DeleteTile ();
		}
	}

	private void SpawnTile(int prefabIndex = -1) {
		GameObject go;
		if (prefabIndex == -1) {
			go = Instantiate (tilePrefab [RandomPrefabIndex()]) as GameObject;
		} else {
			go = Instantiate (tilePrefab [prefabIndex]) as GameObject;
		}
		go.transform.SetParent (transform);
		go.transform.position = Vector3.forward * spawnZ;
		spawnZ += tileLength;
		activeTiles.Add (go);
	}

	private void DeleteTile() {
		Destroy (activeTiles [0]);
		activeTiles.RemoveAt (0);
	}

	private int RandomPrefabIndex() {
		if (tilePrefab.Length <= 1)
			return 0;

		int randomIndex = lastTileIndex;
		while (randomIndex == lastTileIndex) {
			randomIndex = Random.Range (0, tilePrefab.Length);
		}

		lastTileIndex = randomIndex;
		return randomIndex;
	}
}
