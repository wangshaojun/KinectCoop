using UnityEngine;
using System.Collections;

public class CubeTrigger : MonoBehaviour {

    bool OnTriggerEnter(Collider col)
    {
        Debug.Log(col.name);
        if (col.tag == "Stage1Ball")
        {
            //�P�_���쪺�y�O�_�ŦX��V�A�o�ӭn��b�W����return���e-->��ܥ��T���ѵ��G
		//�P�_���ʤ�V
            //LevelController.isBingo = true;
            if (col.name == "Ball1_Prefab") ;   //��
            if (col.name == "Ball2_Prefab") ;   //��
            if (col.name == "Ball3_Prefab") ;   //��
            if (col.name == "Ball4_Prefab") ;   //��
            if (col.name == "Ball5_Prefab") ;   //��
            if (col.name == "Ball6_Prefab") ;   //��
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
