using UnityEngine;
using System.Collections;

public class ScoreCount : MonoBehaviour {
    public StageData stageData;
    public int NormalCT,HardCT;
    public AudioSource BugCrash_Audio, EatMagicBall_Audio;
    public bool Upload;
    GameObject[] objs;
	// Use this for initialization
	void Start () {
       
	}
    void OnTriggerEnter(Collider other) {
        if (other.gameObject.name == "RedBall(Clone)") {
            EatMagicBall_Audio.Play();
            stageData.CorrectTimes++;
            stageData.PositiveScore += 5;
            Destroy(other.gameObject);
   
        }
        if (other.gameObject.name == "LightningBug(Clone)")
        {
            BugCrash_Audio.Play();
            stageData.WrongTimes++;
            stageData.NegativeScore -= 8;
            Destroy(other.gameObject);

        }
        
    }
	// Update is called once per frame
	void Update () {
        if (stageData.stageType == DataCollection.StageType.Normal && stageData.CorrectTimes == NormalCT)
        {
           
            Upload = true;

             if (Upload)
             {
                  stageData.UploadData();
                  Upload = false;
             }

             this.objs = GameObject.FindGameObjectsWithTag("Stage3Ball");//����y�P�²y����Stage3Ball��Tag�A��FindGameObjectsWithTag
                                                                         //��X�Ҧ��ݩ�Stage3Ball��Tag������
                foreach (GameObject obj in objs)                         //foreach �O�̧ǧ�X�}�C�̪��F��éR�W�� obj(�i�ۦ���)
                  {                                                      //�]��objs�OGameObject���O�ҥHobj�]�n�OGameObject���O
                      obj.GetComponent<BallDestory>().SelfDestory();     //�̧ǧ�X���������L����L�ۤv���\��
                  }
                stageData.Init();
             stageData.stageType = DataCollection.StageType.Hard;
            
        }
        if (stageData.stageType == DataCollection.StageType.Hard && stageData.CorrectTimes == HardCT)
        {

            Upload = true;

            if (Upload)
            {
                stageData.UploadData();
                Upload = false;
            }

            this.objs = GameObject.FindGameObjectsWithTag("Stage3Ball");//����y�P�²y����Stage3Ball��Tag�A��FindGameObjectsWithTag
            //��X�Ҧ��ݩ�Stage3Ball��Tag������
            foreach (GameObject obj in objs)                         //foreach �O�̧ǧ�X�}�C�̪��F��éR�W�� obj(�i�ۦ���)
            {                                                      //�]��objs�OGameObject���O�ҥHobj�]�n�OGameObject���O
                obj.GetComponent<BallDestory>().SelfDestory();     //�̧ǧ�X���������L����L�ۤv���\��
            }
            stageData.Init();
            stageData.NextStage("Stage4", 2);
        }
	}
}
