using UnityEngine;
using System.Collections;

/// <summary>
/// 有關地鼠回饋
/// </summary>
public class DiglettsReact : MonoBehaviour
{
    public Texture[] ChangeTextures;
    public float ChangeTextureTime = 0.1f;             //交換時間間隔

    private int currentTextureIndex;

    public bool isLive;


    private float addValue;
    private bool isChanging;
    public Digletts digletts;

    public StageData stageData;

    public int diglettsNum;
    // Use this for initialization
    void Start()
    {
        this.Reset();
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

    /// <summary>
    /// 改變是否運行Regular Change Picture的狀態
    /// </summary>
    /// <param name="isChange">是或否</param>
    public void ChangeState(bool isChange)
    {
        if (isChange)
            this.Reset();
        else
            this.isChanging = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (this.isLive)
        {
            if (this.addValue >= this.ChangeTextureTime)
            {
                this.addValue = 0;
                if(this.currentTextureIndex+1 < this.ChangeTextures.Length)
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


        stageData.WrongTimes++;
        if (stageData.stageType == DataCollection.StageType.Normal)
            stageData.NegativeScore += digletts.NormalNegativeScore;
        if (stageData.stageType == DataCollection.StageType.Hard)
            stageData.NegativeScore += digletts.HardNegativeScore;
        this.isLive = false;
    }


    void isHit()
    {
        audio.PlayOneShot(digletts.Die);
        this.Reset();
        this.isLive = false;

        StopCoroutine("Stay");
    }

}