using UnityEngine;
using System.Collections;


public class CubeTrigger : MonoBehaviour {
    
    bool OnTriggerEnter(Collider col)
    {
        
        Debug.Log(col.name);
        Debug.Log(this.name);
        if (col.tag == "Stage1Ball")
        {
            //判斷撞到的球是否符合方向-->顯示正確失敗結果
            //LevelController.isBingo = true;
            if (col.name == "Ball1_Prefab" && this.name == "CollisionCube_u") LevelController_1.isBingo = true;   //紅
            else LevelController_1.isFailed = true;
            if (col.name == "Ball2_Prefab" && this.name == "CollisionCube_l") LevelController_1.isBingo = true;   //綠
            else LevelController_1.isFailed = true;
            if (col.name == "Ball3_Prefab" && this.name == "CollisionCube_d") LevelController_1.isBingo = true;   //黃
            else LevelController_1.isFailed = true;
            if (col.name == "Ball4_Prefab" && this.name == "CollisionCube_r") LevelController_1.isBingo = true;   //藍
            else LevelController_1.isFailed = true;
            if (col.name == "Ball5_Prefab") LevelController_1.isFailed = true;   //紫
            else LevelController_1.isFailed = true;
            if (col.name == "Ball6_Prefab") LevelController_1.isFailed = true;   //黑
            else LevelController_1.isFailed = true;
            return FruitCreator.isBallKilled = true;
        }
        FruitCreator.isMoving = false;
        return false;
    }

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
