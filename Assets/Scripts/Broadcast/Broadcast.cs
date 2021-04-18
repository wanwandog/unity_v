using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using savedata;
using savemethod;

public class Broadcast : MonoBehaviour
{
    SaveData saveData = new SaveData();
    SaveMethod saveMethod = new SaveMethod();

    // コメントパネルの座標
    public RectTransform commentPanel;

    float timer = 0.0f; // 累積時間
    int count = 0; // 累積移動回数
    private float border = 0.8f; // コメントが流れる速度

    void Start()
    {
        
    }

    void Update()
    {
        // 一定時間ごとに上へ移動
        timer += Time.deltaTime;
        if (timer >= border)
        {
            commentPanel.position += new Vector3(0.0f, 150.0f, 0.0f);
            count += 1;
            timer = 0.0f;
        }

        if (count == 26)
        {
            SceneManager.LoadScene("ResultBroadcast");
        }
    }
}
