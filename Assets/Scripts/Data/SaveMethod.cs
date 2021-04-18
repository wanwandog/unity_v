using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using savedata;

namespace savemethod
{
    public class SaveMethod
    {
        // ラップ用の変数

        [SerializeField]
        private float nowTime; // 現在の時間
        [SerializeField]
        private int year; // 年
        [SerializeField]
        private int month; // 月
        [SerializeField]
        private int week; // 週

        // ---------- チャンネルデータ ----------
        [SerializeField]
        private int[] id = {0, 0, 0, 0, 0, 0}; // ID
        [SerializeField]
        private string[] channelName = {"", "", "", "", "", ""}; // チャンネル名
        [SerializeField]
        private float[] subscriber = {0.0f, 0.0f, 0.0f, 0.0f, 0.0f, 0.0f}; // チャンネル登録者数
        [SerializeField]
        private float[] design = {0.0f, 0.0f, 0.0f, 0.0f, 0.0f, 0.0f}; // キャラクターデザイン
        [SerializeField]
        private float[] frequency = {0.0f, 0.0f, 0.0f, 0.0f, 0.0f, 0.0f}; // 配信頻度
        [SerializeField]
        private float[] talk = {0.0f, 0.0f, 0.0f, 0.0f, 0.0f, 0.0f}; // トーク力
        [SerializeField]
        private float[] plan = {0.0f, 0.0f, 0.0f, 0.0f, 0.0f, 0.0f}; // 企画力
        [SerializeField]
        private float[] sing = {0.0f, 0.0f, 0.0f, 0.0f, 0.0f, 0.0f}; // 歌唱力
        [SerializeField]
        private float[] exp = {0.0f, 0.0f, 0.0f, 0.0f, 0.0f, 0.0f}; // 経験値
        [SerializeField]
        private int[] activeCounter = {0, 0, 0, 0, 0, 0}; // アクティブカウンター
        [SerializeField]
        private float[] accumulation = {0.0f, 0.0f, 0.0f, 0.0f, 0.0f, 0.0f}; // チャンネルごとの蓄積時間
        [SerializeField]
        private int[] superChat = {0, 0, 0, 0}; // 放送での獲得スパチャ　青、黄、マゼンタ、赤の順

        // セーブ
        public void Save(SaveData saveData)
        {
            SaveMethod data = new SaveMethod();

            // セーブデータ代入
            data.nowTime = saveData.NowTime;
            data.year = saveData.Year;
            data.month = saveData.Month;
            data.week = saveData.Week;

            // ---------- チャンネルデータ ----------
            data.id = saveData.Id;
            data.channelName = saveData.ChannelName;
            data.subscriber = saveData.Subscriber;
            data.design = saveData.Design;
            data.frequency = saveData.Frequency;
            data.talk = saveData.Talk;
            data.plan = saveData.Plan;
            data.sing = saveData.Sing;
            data.exp = saveData.Exp;
            data.activeCounter = saveData.ActiveCounter;
            data.accumulation = saveData.Accumulation;
            data.superChat = saveData.SuperChat;
            

            // jsonに書き出し
            StreamWriter writer;
            string jsonData = JsonUtility.ToJson(data);
            writer = new StreamWriter(Application.persistentDataPath + "/savedata.json", false); // trueで追記、falseで上書き
            writer.Write(jsonData);
            writer.Flush();
            writer.Close();
        }

        // ロード
        public SaveData Load()
        {
            SaveMethod data = new SaveMethod();
            string readdata = "";

            // jsonから読み込み
            StreamReader reader;
            reader = new StreamReader(Application.persistentDataPath + "/savedata.json");
            readdata = reader.ReadToEnd();
            reader.Close();
            data = JsonUtility.FromJson<SaveMethod>(readdata);

            SaveData saveData = new SaveData();

            // ロードデータ代入
            saveData.NowTime = data.nowTime;
            saveData.Year = data.year;
            saveData.Month = data.month;
            saveData.Week = data.week;

            // ---------- チャンネルデータ ----------
            saveData.Id = data.id;
            saveData.ChannelName = data.channelName;
            saveData.Subscriber = data.subscriber;
            saveData.Design = data.design;
            saveData.Frequency = data.frequency;
            saveData.Talk = data.talk;
            saveData.Plan = data.plan;
            saveData.Sing = data.sing;
            saveData.Exp = data.exp;
            saveData.ActiveCounter = data.activeCounter;
            saveData.Accumulation = data.accumulation;
            saveData.SuperChat = data.superChat;

            return saveData;
        }

        // データ削除
        public void Delete()
        {
            System.IO.File.Delete(Application.persistentDataPath + "/savedata.json");
        }
    }
}
