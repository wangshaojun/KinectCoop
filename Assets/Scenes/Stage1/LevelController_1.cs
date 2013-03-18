using UnityEngine;
using System.Collections;

public class LevelController_1 : MonoBehaviour
{
    public static bool isBingo = false;
    public Transform correctPlane;
    //此關卡揮手動作判斷為:往右需"左手往右揮"、往左需"右手往左揮"，其他動作尚未設定


    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
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
            //成功反應
            Instantiate(correctPlane);//出現幾秒後刪除，還沒寫
            Destroy(GameObject.Find("CorrectPlane(Clone)"),3f);
            //呼叫置換水果的函式，還沒寫
            Debug.Log("bingo!");
            FruitCreator.isMoving = true;
            isBingo = false;
        }

    }
}
