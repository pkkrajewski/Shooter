﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;

public class ChangeLevel : MonoBehaviour {

	const string levelsDirectory = "Scenes/Levels/";
	public const int NumberOfLevels = 2;

	public static int CurrentLevelIndex = 1;

	void OnTriggerEnter(Collider col) {
		
		int numberOfEnemies = GameObject.FindGameObjectsWithTag ("Enemy").Length;

		if (col.gameObject.tag == "Player" && numberOfEnemies == 0) {
			
			CurrentLevelIndex++;

			if (CurrentLevelIndex <= NumberOfLevels) {
				GamesManagingState.UpdateSave ();
				SceneManager.LoadScene (GetCurrentLevelPath ());
			} else
				SceneManager.LoadScene ("Scenes/GameEnd");
		}
	}

	public static string GetCurrentLevelPath() {
		return levelsDirectory + "Level" + CurrentLevelIndex.ToString ();
	}
}