using UnityEngine;
using System.Collections;

public class LevelController_1 : MonoBehaviour
{
    public static bool isBingo = false;
    Transform correctPlane;
	//�����d����ʧ@�P�_��:���k��"���⩹�k��"�B������"�k�⩹����"�A��L�ʧ@�|���]�w
    
    // Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        //�P�_�ⴧ�ʤ�V�O�_�M�C����k�X
        if (Gesture.isSwipeLeft){//left, red    
            if (FruitCreator.ikind == 0) isBingo = true;
            Gesture.isSwipeLeft = false;
        }
        if (Gesture.isSwipeRight)//right, orange
        {
            if (FruitCreator.ikind == 3) isBingo = true;
            Gesture.isSwipeRight = false;
        }
        /* �U������ذʧ@�����٨S�g�n
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

        if (isBingo) {
            //���\����
            Instantiate(correctPlane);//�X�{�X����R���A�٨S�g

            //�I�s�m�����G���禡�A�٨S�g

            isBingo = false;
        }

	}
}