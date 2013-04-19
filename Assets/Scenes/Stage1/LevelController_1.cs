using UnityEngine;
using System.Collections;

public class LevelController_1 : MonoBehaviour
{
    public static bool isBingo = false, isFailed = false;   //�O�_�F�����T�P�_������
    public AudioClip acCorrect, acWrong;
    AudioSource audioCorrect, audioWrong;
    public Transform correctPlane;
    public static int kindNum = 3;
    //�����d����ʧ@�P�_��:���k��"���⩹�k��"�B������"�k�⩹����"�A��L�ʧ@�|���]�w

    //���J�����d���
    public StageData stageData;

    public bool AddCorrectTimes, AddWrongTimes;
    public bool Upload;
    public bool ChangeStageType;
    public bool NextLevel;

    int tempTimer = 0;

    // Use this for initialization
    void Start()
    {
        //acCorrect = AudioClip.Create("1_magic sort success sound", 14400, 1, 14400, false, true);
        audioCorrect.clip = acCorrect;
        audioWrong.clip = acWrong;
        Debug.Log("get audio clip");
    }

    // Update is called once per frame
    void Update()
    {
        if (FruitCreator.saveTempTime)
        {
            tempTimer = stageData.TakeTime;
            FruitCreator.saveTempTime = false;
        }

        if (stageData.stageType == DataCollection.StageType.Normal) {
            kindNum = 3;
            FruitCreator.isShowHint = true;
            //if (stageData.CorrectTimes >= 15) ChangeStageType = true;
            if (stageData.CorrectTimes >= 5) ChangeStageType = true;   //debug mode
        }
        if (stageData.stageType == DataCollection.StageType.Hard) {
            kindNum = 6;
            FruitCreator.isShowHint = false; 
            if (stageData.CorrectTimes >= 15) NextLevel = true;
            else
            {
                if (tempTimer - stageData.TakeTime < -3) //���T����A���Ѫ������٨S�g
                {
                    FruitCreator.isOver3sec = true;
                    if(FruitCreator.ikind < 4)AddWrongTimes = true;
                }
            }  
        }

        if(FruitCreator.isMoving == false) Act();
            
        if (isBingo)    //���\����
        {
            //�������Z
            AddCorrectTimes = true;
            //���\����
            //Instantiate(correctPlane);
            //Destroy(GameObject.Find("CorrectPlane(Clone)"),1.5f);
            //audioCorrect.Play();
            //�I�s�m�����G���禡�A�٨S�g
            Debug.Log("bingo!");
            //FruitCreator.isMoving = true;
            isBingo = false;
        }
        if (isFailed)   //���~���ȥ��ѭ��s�i�����d
        {
            AddWrongTimes = true;
            //audioWrong.Play();
            //�o�̭n�g:���m���d(�٦��i����:�s�򥢱ѤT���^��²����)
            //�����g
            isFailed = false;
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

    void Act() {
        //�P�_�ⴧ�ʤ�V�O�_�M�C����k�X
        if (Input.GetKeyUp(KeyCode.S) || (Gesture.isSwipeDown))
        {
            FruitCreator.isMoving = true;
            FruitCreator.idir = 2;
            //if (FruitCreator.ikind == 2) isBingo = true;
            //else isFailed = true;
            Gesture.isSwipeDown = false;
        }

        if (Input.GetKeyUp(KeyCode.A) || (Gesture.isSwipeLeft))
        {
            FruitCreator.isMoving = true;
            FruitCreator.idir = 0;
            //if (FruitCreator.ikind == 0) isBingo = true;
            //else isFailed = true;
            Gesture.isSwipeLeft = false;
        }

        if (Input.GetKeyUp(KeyCode.W) || (Gesture.isSwipeUp))
        {
            FruitCreator.isMoving = true;
            FruitCreator.idir = 1; 
            //if (FruitCreator.ikind == 1) isBingo = true;
            //else isFailed = true;
            Gesture.isSwipeUp = false;
        }

        if (Input.GetKeyUp(KeyCode.D) || (Gesture.isSwipeRight))
        {
            FruitCreator.isMoving = true;
            FruitCreator.idir = 3; 
            //if (FruitCreator.ikind == 3) isBingo = true;
            //else isFailed = true;
            Gesture.isSwipeRight = false;
        }
    }
}
