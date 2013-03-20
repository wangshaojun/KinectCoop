using UnityEngine;
using System.Collections;

public class LevelController_1 : MonoBehaviour
{
    public static bool isBingo = false;
    public Transform correctPlane;
    public static int kindNum = 3;
    //此關卡揮手動作判斷為:往右需"左手往右揮"、往左需"右手往左揮"，其他動作尚未設定

    //載入當局關卡資料
    public StageData stageData;

    public bool AddCorrectTimes, AddWrongTimes;
    public bool Upload;
    public bool ChangeStageType;
    public bool NextLevel;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (stageData.stageType == DataCollection.StageType.Normal) {
            kindNum = 3;
            FruitCreator.isShowHint = true;
            if (stageData.CorrectTimes >= 15) ChangeStageType = true;
        }
        if (stageData.stageType == DataCollection.StageType.Hard) {
            kindNum = 6; FruitCreator.isShowHint = false; 
            if (stageData.CorrectTimes >= 15) NextLevel = true;
            else ;  //等三秒限制
        }
            
        //判斷手揮動方向是否和顏色方位吻合
        if (Gesture.isSwipeLeft)
        {//left, red    
            if (FruitCreator.ikind == 0) isBingo = true;
            Gesture.isSwipeLeft = false;
        }
        if (Gesture.isSwipeRight)//right, orange
        {
            if (FruitCreator.ikind == 3) isBingo = true;
            Gesture.isSwipeRight = false;
        }
        /* 下面的兩種動作偵測還沒寫好
        if (Gesture.isSwipeUp)//up, yellow
        {
            if (FruitCreator.ikind == 1) isBingo = true;
            Gesture.isSwipeLeft = false;
        }
        if (Gesture.isSwipeDown)//down, green
        {
            if (FruitCreator.ikind == 2) isBingo = true;
            Gesture.isSwipeRight = false;
        }*/

        if (Input.GetKeyUp(KeyCode.S))
        {
            if (FruitCreator.ikind == 2) isBingo = true;
        }

        if (Input.GetKeyUp(KeyCode.A))
        {
            if (FruitCreator.ikind == 0) isBingo = true;
        }

        if (Input.GetKeyUp(KeyCode.W))
        {
            if (FruitCreator.ikind == 1) isBingo = true;
        }

        if (Input.GetKeyUp(KeyCode.D))
        {
            if (FruitCreator.ikind == 3) isBingo = true;
        }

        if (isBingo)
        {
            //紀錄成績
            AddCorrectTimes = true;
            //成功反應
            Instantiate(correctPlane);//出現幾秒後刪除，還沒寫
            Destroy(GameObject.Find("CorrectPlane(Clone)"),1.5f);
            //呼叫置換水果的函式，還沒寫
            Debug.Log("bingo!");
            FruitCreator.isMoving = true;
            isBingo = false;
        }

        if (AddCorrectTimes)
        {
            stageData.CorrectTimes += 1;
            stageData.PositiveScore += 5;
            AddCorrectTimes = false;
        }
        if (AddWrongTimes)
        {
            stageData.WrongTimes += 1;
            stageData.NegativeScore += 8;
            AddWrongTimes = false;
        }
        if (Upload)
        {
            stageData.UploadData();
            Upload = false;
        }
        if (ChangeStageType)
        {
            stageData.ChangeStageType();
            ChangeStageType = false;
        }
        if (NextLevel)
        {
            stageData.NextStage("Stage2", 2.0F);
            NextLevel = false;
        }

    }
}
