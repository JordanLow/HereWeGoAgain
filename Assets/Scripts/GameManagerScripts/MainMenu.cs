using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
	[SerializeField] GameObject StartMenu;
	[SerializeField] GameObject WeaponSelectMenu;
	
    public void QuitGame() {
		Debug.Log("Quitting");
		Application.Quit();
	}
	
	public void OpenWeaponSelect() {
		StartMenu.SetActive(false);
		WeaponSelectMenu.SetActive(true);
	}
	
	public void OpenStartQuit() {
		WeaponSelectMenu.SetActive(false);
		StartMenu.SetActive(true);
	}
	
	public void StartGameClaymore() {
		SceneManager.LoadScene("Stage 1");
	}
	
	public void StartGameShotgun() {
		Debug.Log("No Shotgun :(");
	}
}
