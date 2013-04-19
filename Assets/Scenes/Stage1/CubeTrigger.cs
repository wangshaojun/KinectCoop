using UnityEngine;
using System.Collections;

public class CubeTrigger : MonoBehaviour {

    bool OnTriggerEnter(Collider col)
    {
        Debug.Log(col.name);
        if (col.tag == "Stage1Ball")
        {
            //判斷撞到的球是否符合方向，這個要放在上面的return之前-->顯示正確失敗結果
		//判斷移動方向
            //LevelController.isBingo = true;
            if (col.name == "Ball1_Prefab") ;   //紅
            if (col.name == "Ball2_Prefab") ;   //綠
            if (col.name == "Ball3_Prefab") ;   //黃
            if (col.name == "Ball4_Prefab") ;   //藍
            if (col.name == "Ball5_Prefab") ;   //紫
            if (col.name == "Ball6_Prefab") ;   //黑
            return FruitCreator.isBallKilled = true;
        }
        return false;
    }

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
