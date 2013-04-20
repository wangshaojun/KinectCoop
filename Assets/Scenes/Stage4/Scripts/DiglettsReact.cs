using UnityEngine;
using System.Collections;


/// <summary>
/// ��G�����a���^�X  , �s�G�a���P�a�p
/// </summary>
public class DiglettsReact : MonoBehaviour
{
    public Texture[] ChangeTextures_Diglett;
    public Texture[] ChangeTextures_Bomb;
    public Texture[] ChangeTextures;
    public float ChangeTextureTime = 0.1f;             //�洫�ɶ����j
    private int currentTextureIndex;
    //�O�_�s��
    public bool isLive;

    private float addValue;
    private bool isChanging;
    public Digletts digletts;
    public StageData stageData;
    public int diglettsNum;//����a���s��(�ȵL�ϥ�)

    public enum ObjectType { Diglett, Bomb };
    public ObjectType objectType;



    // Use this for initialization
    void Start()
    {
        this.Reset();
        //�üƳ]�w�����󬰦a���Φa�p

        diglettsNum = int.Parse(this.name.ToCharArray()[9].ToString()); //��ĤE�r��...���Q��public
    }

    /// <summary>
    /// �N�ƭȦ^�_���w�]��
    /// </summary>
    void Reset()
    {
        this.isChanging = true;
        this.addValue = 0;
        this.currentTextureIndex = 0;
        this.renderer.material.mainTexture = this.ChangeTextures[this.currentTextureIndex];
    }



    // Update is called once per frame
    void Update()
    {
        if (this.isLive)
        {
            if (objectType == ObjectType.Diglett)
            {
                ChangeTextures = ChangeTextures_Diglett;
            }

            if (objectType == ObjectType.Bomb)
            {
                ChangeTextures = ChangeTextures_Bomb;
            }


            if (this.addValue >= this.ChangeTextureTime)
            {
                this.addValue = 0;
                if (this.currentTextureIndex + 1 < this.ChangeTextures.Length)
                    this.currentTextureIndex++;
                this.renderer.material.mainTexture = this.ChangeTextures[this.currentTextureIndex];
            }
            this.addValue += Time.deltaTime;
        }
        else
        {
            this.renderer.material.mainTexture = this.ChangeTextures[0];
        }
    }


    void AnimationActive()
    {
        this.isLive = true;
        StartCoroutine(Stay(digletts.Stay));
    }


    IEnumerator Stay(float delay)
    {
        yield return new WaitForSeconds(delay);
        this.Reset();

        //���ݵ������٬��ۨS���� (�s�������ϥ�)
        if (this.isLive)
        {
            /*
            stageData.WrongTimes++;
            if (stageData.stageType == DataCollection.StageType.Normal)
                stageData.NegativeScore += digletts.NormalNegativeScore;
            if (stageData.stageType == DataCollection.StageType.Hard ||
                stageData.stageType == DataCollection.StageType.Boss)
                stageData.NegativeScore += digletts.HardNegativeScore;
             */
            this.isLive = false;

        }
    }


    void isHit()
    {
        if(objectType == ObjectType.Bomb)
            audio.PlayOneShot(digletts.Appear_bomb);
        this.Reset();
        this.isLive = false;

        //StopCoroutine("Stay");
    }

}