using UnityEngine;
using System.Collections;


/// <summary>
/// 原：有關地鼠回饋  , 新：地鼠與地雷
/// </summary>
public class DiglettsReact : MonoBehaviour
{
    public Texture[] ChangeTextures_Diglett;
    public Texture[] ChangeTextures_Bomb;
    public Texture[] ChangeTextures;
    public float ChangeTextureTime = 0.1f;             //交換時間間隔
    private int currentTextureIndex;
    //是否存活
    public bool isLive;

    private float addValue;
    private bool isChanging;
    public Digletts digletts;
    public StageData stageData;
    public int diglettsNum;//抓取地鼠編號(暫無使用)

    public enum ObjectType { Diglett, Bomb };
    public ObjectType objectType;



    // Use this for initialization
    void Start()
    {
        this.Reset();
        //亂數設定此物件為地鼠或地雷

        diglettsNum = int.Parse(this.name.ToCharArray()[9].ToString()); //抓第九字元...不想用public
    }

    /// <summary>
    /// 將數值回復成預設值
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

        //等待結束後還活著沒有踩 (新版本未使用)
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