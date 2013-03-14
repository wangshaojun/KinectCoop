using UnityEngine;
using System.Collections;

/// <summary>
/// 固定頻率的交換圖片Script
/// </summary>
public class DiglettsAnimation : MonoBehaviour
{
    public Texture[] ChangeTextures;
    public float ChangeTextureTime = 0.1f;             //交換時間間隔

    private int currentTextureIndex;
    private float addValue;
    private bool isChanging;
    public bool isLive;

    public Digletts digletts;
    // Use this for initialization
    void Start()
    {
        this.Reset();
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
        this.isLive = false;
    }
}