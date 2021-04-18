using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using savedata;
using savemethod;

public class ResultBroadcast : MonoBehaviour
{
    SaveData saveData = new SaveData();
    SaveMethod saveMethod = new SaveMethod();

    // テキスト
    public Text hourText;
    public Text minuteText;
    public Text listnerText;
    public Text subscriberText;
    public Text superchatText;
    public Text[] colorText; 

    private int element;

    void Awake()
    {
        // 乱数のシード設定
        Random.InitState(System.DateTime.Now.Millisecond);
    }

    void Start()
    {
        saveData = saveMethod.Load();

        // アクティブカウンターが1である要素を取得
        element = GetActiveLiverElement(saveData.ActiveCounter);

        // 放送時間のテキスト表示
        BroadcastTimeDisplay();

        // 最多同時視聴者数のテキスト表示
        ListnerDisplay(saveData.Subscriber[element]);

        // 登録者増加数のテキスト表示
        SubscriberUpDisplay(saveData, element);

        // スーパーコメントのテキスト表示
        SuperCommentDisplay(saveData);
    }

    // アクティブカウンターが1である要素を取得
    public int GetActiveLiverElement(int[] activecounter)
    {
        int ele;

        for (int i = 0; i < 6; i++)
        {
            if (activecounter[i] == 1)
            {
                ele = i;
                return ele;
            } 
        }

        Debug.Log("Error/GetActiveLiverElement");
        return 100;
    }

    // 小数点x(x>=2)位以下を消去する関数
    // public float Floor2(float number, int x)
    // {
    //     number = number * 10*(x - 1);
    //     number = Mathf.Floor(number);
    //     number = number / 100.0f;

    //     return number;
    // }

    // 放送時間の処理
    public void BroadcastTimeDisplay()
    {
        int hour, minute;

        // 0~9時間、0~59分をランダム表示
        hour = Random.Range(0, 10);
        minute = Random.Range(0, 60);

        hourText.text = hour.ToString();
        minuteText.text = minute.ToString();
    }

    // 最多同時視聴者数の処理
    public void ListnerDisplay(float subscriber)
    {

        float number;

        // 登録者数の100分の1 * 0.1~2倍が同時接続数となる
        number = Random.Range(0.1f, 2.0f) * (subscriber/100.0f);

        listnerText.text = (Mathf.Ceil(number)).ToString();
    }

    // 登録者増加数の処理
    public void SubscriberUpDisplay(SaveData saveData, int element)
    {
        float number;

        // キャラデザ、トーク力、企画力、歌唱力から若干の乱数で整えた数が増加分
        number = Random.Range(0.9f, 1.05f) * (saveData.Design[element] + saveData.Talk[element] + saveData.Plan[element] + saveData.Sing[element]);

        subscriberText.text = (Mathf.Ceil(number)).ToString();

        // 増加分をプラス
        saveData.Subscriber[element] += number;
        saveMethod.Save(saveData);
    }

    // スーパーコメントの処理
    public void SuperCommentDisplay(SaveData saveData)
    {
        int[] superchat = new int[4];
        float ratio, number;

        // 各スパチャの数を表示
        for (int i = 0; i < 4; i++)
        {
            colorText[i].text = saveData.SuperChat[i].ToString();
        }

        // それぞれの実際の値段を配列に代入
        superchat[0] = 100*saveData.SuperChat[0];
        superchat[1] = 2000*saveData.SuperChat[1];
        superchat[2] = 5000*saveData.SuperChat[2];
        superchat[3] = 10000*saveData.SuperChat[3];

        ratio = saveData.Subscriber[element]/10000.0f;

        number = (superchat[0] + superchat[1] + superchat[2] + superchat[3])*ratio;

        //　テキスト表示
        superchatText.text = (Mathf.Ceil(number)).ToString();

        for (int i = 0; i < 4; i++)
        {
            saveData.SuperChat[i] = 0;
        }

        saveMethod.Save(saveData);
    }

    // 画面タップ時の処理
    public void OnTapScreen()
    {
        SceneManager.LoadScene("Main");
    }
}
