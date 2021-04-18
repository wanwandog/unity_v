using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using savedata;
using savemethod;
using commentdata;
using commentmethod;

public class Comment : MonoBehaviour
{
    SaveData saveData = new SaveData();
    SaveMethod saveMethod = new SaveMethod();
    CommentData commentData = new CommentData();
    CommentMethod commentMethod = new CommentMethod();

    // Unity上で設定するデータ群
    public Image[] commentBox; // コメントボックス
    public Text[] commentText; // テキスト
    public Image[] commentIcon; // アイコン
    public EventTrigger[] currentTrigger; // イベントトリガー
    public Sprite[] commentIconSprite; // アイコンの画像保存場所
    
    private int commentDataElement = 20; // コメントデータの要素数
    private int commentDataAll = 7; // コメントデータの総数

    private int commentRandom; // コメント用の乱数

    void Awake()
    {
        // 乱数のシード設定
        Random.InitState(System.DateTime.Now.Millisecond);
    }

    void Start()
    {
        // コメントのテキスト表示
        commentRandom = Random.Range(1, commentDataAll+1);; // どのデータのコメントを使うかの乱数を生成
        CommentText(commentRandom);

        // コメントのアイコン表示
        CommentIcon();
        
        // スパチャ表示
        Superchat();
    }

    // コメントのテキスト表示
    public void CommentText(int random)
    {
        int rand; // コメント内でのランダム

        switch (random)
        {
            case 1:
                for (int i = 0; i < commentDataElement; i++)
                {
                    rand = Random.Range(0, commentDataElement);
                    commentText[i].text = commentData.Commentdata_one[rand];
                }
                break;
            case 2:
                for (int i = 0; i < commentDataElement; i++)
                {
                    rand = Random.Range(0, commentDataElement);
                    commentText[i].text = commentData.Commentdata_two[rand];
                }
                break;
            case 3:
                for (int i = 0; i < commentDataElement; i++)
                {
                    rand = Random.Range(0, commentDataElement);
                    commentText[i].text = commentData.Commentdata_three[rand];
                }
                break;
            case 4:
                for (int i = 0; i < commentDataElement; i++)
                {
                    rand = Random.Range(0, commentDataElement);
                    commentText[i].text = commentData.Commentdata_four[rand];
                }
                break;
            case 5:
                for (int i = 0; i < commentDataElement; i++)
                {
                    rand = Random.Range(0, commentDataElement);
                    commentText[i].text = commentData.Commentdata_five[rand];
                }
                break;
            case 6:
                for (int i = 0; i < commentDataElement; i++)
                {
                    rand = Random.Range(0, commentDataElement);
                    commentText[i].text = commentData.Commentdata_six[rand];
                }
                break;
            case 7:
                for (int i = 0; i < commentDataElement; i++)
                {
                    rand = Random.Range(0, commentDataElement);
                    commentText[i].text = commentData.Commentdata_seven[rand];
                }
                break;
            default:
                Debug.Log("Error Comment/CommentDisplay");
                break;
        }
    }

    // コメントのアイコン表示
    public void CommentIcon()
    {
        int random;

        // 乱数によってコメントのアイコンを変更
        for (int i = 0; i < commentDataElement; i++)
        {
            random = Random.Range(0, 5);
            commentIcon[i].sprite = commentIconSprite[random];
        }
    }

    // スーパーチャット表示
    public void Superchat()
    {
        int random;

        for (int i = 0; i < commentDataElement; i++)
        {
            random = Random.Range(1, 81); // 1~80までの乱数を生成

            if (random <= 12)
            {
                // 青スパ
                BlueSuperchat(i);
            } else if (12 < random && random <= 16) {
                // 黄スパ
                YellowSuperchat(i);
            } else if (16 < random && random <= 18) {
                // マゼンタスパ
                MagentaSuperchat(i);
            } else if (random == 19) {
                // 赤スパ
                RedSuperchat(i);
            }
        }
    }

    // 青スパ処理
    public void BlueSuperchat(int element)
    {
        // 色変更
        commentBox[element].color = Color.blue;

        // タップ時の処理をイベントトリガーに追加する処理
        EventTrigger.Entry entry = new EventTrigger.Entry();
        currentTrigger[element].triggers = new List<EventTrigger.Entry>();
        entry.eventID = EventTriggerType.PointerDown;
        entry.callback.AddListener((data) => {
            // セーブ
            saveData = saveMethod.Load();
            saveData.SuperChat[0] += 1;
            saveMethod.Save(saveData);

            // 色を戻す
            commentBox[element].color = Color.white;

            // イベントを消去
            currentTrigger[element].triggers.Remove(entry);
        });
        currentTrigger[element].triggers.Add(entry);
    }

    // 黄スパ処理
    public void YellowSuperchat(int element)
    {
        commentBox[element].color = Color.yellow;

        EventTrigger.Entry entry = new EventTrigger.Entry();
        currentTrigger[element].triggers = new List<EventTrigger.Entry>();
        entry.eventID = EventTriggerType.PointerDown;
        entry.callback.AddListener((data) => {
            saveData = saveMethod.Load();
            saveData.SuperChat[1] += 1;
            saveMethod.Save(saveData);
            commentBox[element].color = Color.white;
            currentTrigger[element].triggers.Remove(entry);
        });
        currentTrigger[element].triggers.Add(entry);
    }

    // マゼンタスパ処理
    public void MagentaSuperchat(int element)
    {
        commentBox[element].color = Color.magenta;

        EventTrigger.Entry entry = new EventTrigger.Entry();
        currentTrigger[element].triggers = new List<EventTrigger.Entry>();
        entry.eventID = EventTriggerType.PointerDown;
        entry.callback.AddListener((data) => {
            saveData = saveMethod.Load();
            saveData.SuperChat[2] += 1;
            saveMethod.Save(saveData);
            commentBox[element].color = Color.white;
            currentTrigger[element].triggers.Remove(entry);
        });
        currentTrigger[element].triggers.Add(entry);
    }

    // 赤スパ処理
    public void RedSuperchat(int element)
    {
        commentBox[element].color = Color.red;

        EventTrigger.Entry entry = new EventTrigger.Entry();
        currentTrigger[element].triggers = new List<EventTrigger.Entry>();
        entry.eventID = EventTriggerType.PointerDown;
        entry.callback.AddListener((data) => {
            saveData = saveMethod.Load();
            saveData.SuperChat[3] += 1;
            saveMethod.Save(saveData);
            commentBox[element].color = Color.white;
            currentTrigger[element].triggers.Remove(entry);
        });
        currentTrigger[element].triggers.Add(entry);
    }
}
