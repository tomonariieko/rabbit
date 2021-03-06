﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Gamedirector : MonoBehaviour
{

    public static int starCount;
    static int HP;

    static int starCountMax = 7;
    static int starCountMin = 0;

    static int HPMax = 3;
    static int HPMin = 0;

    static GameObject[] HPs;
    static GameObject[] Stars;

    static Color Black = new Color(0.0f / 255.0f, 0.0f / 255.0f, 0.0f / 255.0f, 255.0f / 255.0f);
    static Color White = new Color(255.0f / 255.0f, 255.0f / 255.0f, 255.0f / 255.0f, 255.0f / 255.0f);

    // Use this for initialization
    void Start()
    {
        InitializeStatus();

        HPs = GetChildren("Canvas/Panel/HPs");
        Stars = GetChildren("Canvas/Panel/stars");


        //HPをHPMaxの数だけ表示
        for (int i = 1; i < HPs.Length - 1; i++)
        {
            if (!HPs[i]) return;
            HPs[i].GetComponent<Image>().enabled = false;
            if (i > HPMax) continue;
            HPs[i].GetComponent<Image>().enabled = true;
        }


    }

    // Update is called once per frame
    void Update()
    {
        if (HP == 0) PlayerDead();
    }

    public static void InitializeStatus()
    {

        HP = HPMax;
        starCount = starCountMin;
    }

    public static void StarCounter()
    {
        starCount++;
        starCount = Mathf.Clamp(starCount, starCountMin, starCountMax);
        Stars[starCount].GetComponent<Image>().color = White;
    }

    public static void DecreaseHP()
    {
        HP--;
        HP = Mathf.Clamp(HP, HPMin, HPMax);
        HPs[HP + 1].GetComponent<Image>().color = Black;
    }

    public static void HealHP()
    {

        HP++;
        HP = Mathf.Clamp(HP, HPMin, HPMax);
        HPs[HP].GetComponent<Image>().color = White;
    }

    public static void PlayerDead()
    {
        // 現在のScene名を取得する
        Scene loadScene = SceneManager.GetActiveScene();
        // Sceneの読み直し
        SceneManager.LoadScene(loadScene.name);
        InitializeStatus();
    }

    GameObject[] GetChildren(string parentName)
    {
        // 検索し、GameObject型に変換
        var parent = GameObject.Find(parentName) as GameObject;
        // 見つからなかったらreturn
        if (parent == null) return null;
        // 子のTransform[]を取り出す
        var transforms = parent.GetComponentsInChildren<Transform>();
        // 使いやすいようにtransformsからgameObjectを取り出す
        GameObject[] go = new GameObject[transforms.Length + 1];
        int i = 0;
        foreach (Transform trans in transforms)
        {
            go[i] = trans.gameObject;
            i++;
        }
        // 配列に変換してreturn
        return go;
    }

}
