using UnityEngine;
using System.Collections;

/// <summary>
/// �T�w�W�v���洫�Ϥ�Script
/// </summary>
public class DiglettsAnimation : MonoBehaviour
{
    public Texture[] ChangeTextures;
    public float ChangeTextureTime = 0.1f;             //�洫�ɶ����j

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
    /// �N�ƭȦ^�_���w�]��
    /// </summary>
    void Reset()
    {
        this.isChanging = true;
        this.addValue = 0;
        this.currentTextureIndex = 0;
        this.renderer.material.mainTexture = this.ChangeTextures[this.currentTextureIndex];
    }

    /// <summary>
    /// ���ܬO�_�B��Regular Change Picture�����A
    /// </summary>
    /// <param name="isChange">�O�Χ_</param>
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