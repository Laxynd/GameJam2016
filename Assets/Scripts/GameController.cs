﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameController : MonoBehaviour {
    public static bool InputEnabled { get; set; }
    public static TownGrid Grid { get; set; }

    public Text text;
    public Transform directionalLight;
    public GameObject woodenTower, stoneTower, building;
    public GameObject enemy;
    public GameObject ritualScreen;
    public GameObject[] ritualButtons;

    //Attack happens on day 7
    static int day = 1;

    public Transform[] enemySpawns;

    public static GameObject placingObject;

    void Start() {

    }

    void Update() {
        //if (Input.GetMouseButton(1)) {
        //    FadeOut(0);
        //    FadeIn(1);
        //}

        if (Input.GetKeyDown(KeyCode.Q))
            ShowRitualScreen();

        if (Input.GetKeyDown(KeyCode.E))
            HideRitualScreen();
    }

    public void ChangeScene(string scene) {
        StartCoroutine(LoadingScreen.ChangeScene(scene));
    }

    public void SpawnWoodenTower() {
        if (placingObject != null)
            Destroy(placingObject.gameObject);
        placingObject = (GameObject)Instantiate(woodenTower, Mouse.MousePosition, Quaternion.identity);
        text.text = "WoodenTower";
    }

    public void SpawnStoneTower() {
        if (placingObject != null)
            Destroy(placingObject.gameObject);
        placingObject = (GameObject)Instantiate(stoneTower, Mouse.MousePosition, Quaternion.identity);
        text.text = "StoneTower";
    }

    public void SpawnBuilding() {
        if (placingObject != null)
            Destroy(placingObject.gameObject);

        placingObject = (GameObject)Instantiate(building, Mouse.MousePosition, Quaternion.identity);
        text.text = "Building";
    }

    public void ShowRitualScreen() {
        ritualScreen.SetActive(true);
    }

    public void HideRitualScreen() {
        ritualScreen.SetActive(false);
    }

    //void FadeIn(int i) {
    //    if (audioChannels[i].volume < 1)
    //        audioChannels[i].volume += 1 * Time.deltaTime;
    //}

    //void FadeOut(int i) {
    //    if (audioChannels[i].volume > 1)
    //        audioChannels[i].volume -= 1 * Time.deltaTime;
    //}

    public void HumanSacrifice() {
        HideRitualScreen();
    }

    public void AnimalSacrifice() {
        HideRitualScreen();
    }
    public void ResourceSacrifice() {
        HideRitualScreen();
    }
    public void NoSacrifice() {
        HideRitualScreen();
    }


    public void ProgressDay() {
        if (day == 7) {
            day = 1;
        }
        else
            day++;

        if (day == 7) {
            ShowRitualScreen();
            print("Run attack code here pls thank");
        }

        text.text = "Day: " + day;

    }
}
