using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace savedata
{
    public class SaveData
    {
        private float nowTime = 0.0f; // 現在の時間
        public float NowTime
        {
            get {return nowTime;}
            set {nowTime = value;}
        }

        private int year = 1; // 年
        public int Year
        {
            get {return year;}
            set {year = value;}
        }

        private int month = 4; // 月
        public int Month
        {
            get {return month;}
            set {month = value;}
        }

        private int week = 1; // 週
        public int Week
        {
            get {return week;}
            set {week = value;}
        }

        // ---------- チャンネルデータ ----------
        private int[] id = {1, 2, 3, 4, 5, 6}; // ID
        public int[] Id
        {
            get {return id;}
            set {id = value;}
        }

        private string[] channelName = {"Sample Channel", "", "", "", "", ""}; // チャンネル名
        public string[] ChannelName
        {
            get {return channelName;}
            set {channelName = value;}
        }

        private float[] subscriber = {1.0f, 0.0f, 0.0f, 0.0f, 0.0f, 0.0f}; // チャンネル登録者数
        public float[] Subscriber
        {
            get {return subscriber;}
            set {subscriber = value;}
        }

        private float[] design = {1.0f, 0.0f, 0.0f, 0.0f, 0.0f, 0.0f}; // キャラクターデザイン
        public float[] Design
        {
            get {return design;}
            set {design = value;}
        }

        private float[] frequency = {1.0f, 3.0f, 5.0f, 7.0f, 9.0f, 11.0f}; // 配信頻度
        public float[] Frequency
        {
            get {return frequency;}
            set {frequency = value;}
        }

        private float[] talk = {1.0f, 0.0f, 0.0f, 0.0f, 0.0f, 0.0f}; // トーク力
        public float[] Talk
        {
            get {return talk;}
            set {talk = value;}
        }

        private float[] plan = {1.0f, 0.0f, 0.0f, 0.0f, 0.0f, 0.0f}; // 企画力
        public float[] Plan
        {
            get {return plan;}
            set {plan = value;}
        }

        private float[] sing = {1.0f, 0.0f, 0.0f, 0.0f, 0.0f, 0.0f}; // 歌唱力
        public float[] Sing
        {
            get {return sing;}
            set {sing = value;}
        }

        private float[] exp = {1.0f, 0.0f, 0.0f, 0.0f, 0.0f, 0.0f}; // 経験値
        public float[] Exp
        {
            get {return exp;}
            set {exp = value;}
        }

        private int[] activeCounter = {0, 0, 0, 0, 0, 0}; // アクティブカウンター
        public int[] ActiveCounter
        {
            get {return activeCounter;}
            set {activeCounter = value;}
        }

        private float[] accumulation = {0.0f, 0.0f, 0.0f, 0.0f, 0.0f, 0.0f}; // チャンネルごとの蓄積時間
        public float[] Accumulation
        {
            get {return accumulation;}
            set {accumulation = value;}
        }

        private int[] superChat = {0, 0, 0, 0}; // 放送での獲得スパチャ　青、黄、マゼンタ、赤の順
        public int[] SuperChat
        {
            get {return superChat;}
            set {superChat = value;}
        }
    }
}
