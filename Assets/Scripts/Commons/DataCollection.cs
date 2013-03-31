using UnityEngine;
using System.Collections;
using System.IO;


public class DataCollection : MonoBehaviour
{
    // * DataCollection 資訊整合檔

    public string PlayerName;           //玩家名稱
    public int PlayerTotalScore;        //玩家總分
    public string StartTime;            //系統開始時間

    public enum StageType { Undefined, Normal, Hard }; //關卡難度類別
    public enum StageName { 未定義, 魔法球分類, 平衡木, 滑翔翼, 閃避地雷, 最終大魔王 }; //關卡名稱

    public struct StageData
    {
        public StageType stageType; //關卡類別
        public StageName stageName; //關卡名稱
        public int CorrectTimes;    //正確次數
        public int WrongTimes;      //錯誤次數
        public int PositiveScore;   //得分分數
        public int NegativeScore;   //扣分分數
        public int TakeTime;        //花費時間

        //For Stage2
        public int CorrectTimes2;    //正確次數
        public int WrongTimes2;      //錯誤次數

        /// <summary>
        /// 關卡資料
        /// </summary>
        /// <param name="stageType">關卡類別</param>
        /// <param name="stageName">關卡名稱</param>
        /// <param name="CorrectTimes">正確次數</param>
        /// <param name="WrongTimes">錯誤次數</param>
        /// <param name="PositiveScore">得分分數</param>
        /// <param name="NegativeScore">扣分分數</param>
        /// <param name="TakeTime">花費時間</param>
        public StageData(
            StageType stageType = StageType.Undefined,
            StageName stageName = StageName.未定義,
            int CorrectTimes = 0,
            int WrongTimes = 0,
            int PositiveScore = 0,
            int NegativeScore = 0,
            int TakeTime = 0,
            int CorrectTimes2 = 0,
            int WrongTimes2 = 0
        )
        {
            this.stageType = stageType;
            this.stageName = stageName;
            this.CorrectTimes = CorrectTimes;
            this.WrongTimes = WrongTimes;
            this.PositiveScore = PositiveScore;
            this.NegativeScore = NegativeScore;
            this.TakeTime = TakeTime;
            this.CorrectTimes2 = CorrectTimes2;
            this.WrongTimes2 = WrongTimes2;
        }   
         
    }
    public ArrayList StageDataList;



	// Use this for initialization
	void Start () {
        StageDataList = new ArrayList();
        DontDestroyOnLoad(this.gameObject); //此Object不會因為換場景而被刪除
	}
	
	// Update is called once per frame
	void Update () {

	}

    /// <summary>
    /// 輸出Log檔成txt
    /// </summary>
    public void OutputLog2txt()
    {
        //檔名格式　玩家名稱_測驗時間_年_月_日
        string fileName = PlayerName + "_" + "測驗時間 " + "_" + System.DateTime.Now.Year + "_" + System.DateTime.Now.Month + "_" + System.DateTime.Now.Day;

        //string path = "C:\\File\\"; // 絕對路徑
        string path = Application.dataPath + "/" + "../" + "PlayerLogs/";

        if (!Directory.Exists(path)) //先判斷有無此資料夾
        {
            Directory.CreateDirectory(path);
        }

        path = string.Format("{0}{1}.txt", path, fileName);

        //寫檔
        if (!File.Exists(path)) //先判斷這個path有無這個檔案 
        {
            FileStream fs; //沒有進來先創檔案
            fs = new FileStream(path, FileMode.CreateNew);
            fs.Close();
        }
        StreamWriter sw = new StreamWriter(path);


        //輸出玩家資訊
        {
            sw.Write("玩家名稱：" + PlayerName + "\r\n");
            sw.Write("開始時間：" + StartTime + "\r\n");
            PlayerTotalScore = 0;
            for (int i = 0; i < StageDataList.Count; i++)
                PlayerTotalScore += ((StageData)StageDataList[i]).PositiveScore - ((StageData)StageDataList[i]).NegativeScore;


            sw.Write("玩家總分：" + PlayerTotalScore + "\r\n");
        }
        #region
        // 輸出關卡資訊
        {
            for (int i = 0; i < StageDataList.Count; i++)
            {
                if (((StageData)StageDataList[i]).stageName.ToString() != "平衡木")
                {
                    sw.Write("---------------------------------------" + "\r\n");
                    string StatgeData = string.Format("關卡類別：{0} " + "\r\n" +
                                                      "關卡名稱：{1} " + "\r\n" +
                                                      "正確次數：{2} " + "\r\n" +
                                                      "錯誤次數：{3} " + "\r\n" +
                                                      "得分分數：{4} " + "\r\n" +
                                                      "扣分分數：{5} " + "\r\n" +
                                                      "花費時間：{6} " + "\r\n",
                                                    ((StageData)StageDataList[i]).stageType.ToString(),
                                                    ((StageData)StageDataList[i]).stageName.ToString(),
                                                    ((StageData)StageDataList[i]).CorrectTimes.ToString(),
                                                    ((StageData)StageDataList[i]).WrongTimes.ToString(),
                                                    ((StageData)StageDataList[i]).PositiveScore.ToString(),
                                                    ((StageData)StageDataList[i]).NegativeScore.ToString(),
                                                    ((StageData)StageDataList[i]).TakeTime.ToString()
                        );
                    sw.Write(StatgeData);
                }
                else
                {

                    sw.Write("---------------------------------------" + "\r\n");
                    string StatgeData = string.Format("關卡類別：{0} " + "\r\n" +
                                                      "關卡名稱：{1} " + "\r\n" +
                                                      "正確次數(障礙物)：{2} " + "\r\n" +
                                                      "錯誤次數(障礙物)：{3} " + "\r\n" +
                                                      "正確次數(火蠅)：{4} " + "\r\n" +
                                                      "錯誤次數(火蠅)：{5} " + "\r\n" +
                                                      "得分分數：{6} " + "\r\n" +
                                                      "扣分分數：{7} " + "\r\n" +
                                                      "花費時間：{8} " + "\r\n",
                                                    ((StageData)StageDataList[i]).stageType.ToString(),
                                                    ((StageData)StageDataList[i]).stageName.ToString(),
                                                    ((StageData)StageDataList[i]).CorrectTimes.ToString(),
                                                    ((StageData)StageDataList[i]).WrongTimes.ToString(),
                                                    ((StageData)StageDataList[i]).CorrectTimes2.ToString(),
                                                    ((StageData)StageDataList[i]).WrongTimes2.ToString(),
                                                    ((StageData)StageDataList[i]).PositiveScore.ToString(),
                                                    ((StageData)StageDataList[i]).NegativeScore.ToString(),
                                                    ((StageData)StageDataList[i]).TakeTime.ToString()
                        );
                    sw.Write(StatgeData);

                }
            }
            
        }
#endregion

        sw.Close();
    }
}
