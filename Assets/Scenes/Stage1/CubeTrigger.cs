using UnityEngine;
using System.Collections;


public class CubeTrigger : MonoBehaviour {
    
    bool OnTriggerEnter(Collider col)
    {
        
        Debug.Log(col.name);
        Debug.Log(this.name);
        FruitCreator.isMoving = false;
        if (col.tag == "Stage1Ball")
        {
            //�P�_���쪺�y�O�_�ŦX��V-->��ܥ��T���ѵ��G
            //LevelController.isBingo = true;
            if (col.name == "Ball1_Prefab" && this.name == "CollisionCube_u") LevelController_1.isBingo = true;   //��
            else if (col.name == "Ball2_Prefab" && this.name == "CollisionCube_l") LevelController_1.isBingo = true;   //��
            else if (col.name == "Ball3_Prefab" && this.name == "CollisionCube_d") LevelController_1.isBingo = true;   //��
            else if (col.name == "Ball4_Prefab" && this.name == "CollisionCube_r") LevelController_1.isBingo = true;   //��
            else if (col.name == "Ball5_Prefab") LevelController_1.isFailed = true;   //��
            else if (col.name == "Ball6_Prefab") LevelController_1.isFailed = true;   //��
            else LevelController_1.isFailed = true;
            
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
