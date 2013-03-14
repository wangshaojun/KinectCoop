using UnityEngine;
using System.Collections;

/// <summary>
/// �ĤG��-�Z�����ܱ���UI
/// </summary>
public class DistanceHintUI_Stage2 : MonoBehaviour
{
    public Rect DistanceHintRect;           //�Z�����ܱ���Rectangle

    public GameObject MoverObject;          //���ʪ�����
    public GameObject EndPositionObject;    //���I����

    public Texture DistanceHintBoxTexture;  //���ܶZ�������K��
    public Texture ArrowTexture;            //�b�Y���K��

    public float ArrowStartPosX;            //���ܽb�Y�}�l����m
    public float ArrowWidth = 25;           //���ܽb�Y���j�p
    public GUIStyle style;

    private Vector2 screenSize;             //�����j�p
    private float totalDistance;            //�`����
    private float arrowCurrentPosX;         //�b�Y��e����m

    // Use this for initialization
    void Start()
    {
        //�p���`����
        this.totalDistance = Vector3.Distance(this.MoverObject.transform.position, this.EndPositionObject.transform.position);

        this.arrowCurrentPosX = this.ArrowStartPosX;
    }

    // Update is called once per frame
    void Update()
    {
        this.screenSize = new Vector2(Screen.width, Screen.height);     //���e�ù��j�p

        float distanceHintBoxTextureWidth;
        distanceHintBoxTextureWidth = this.DistanceHintRect.width * this.screenSize.x;
        this.arrowCurrentPosX = Mathf.Lerp(this.ArrowStartPosX - (this.ArrowWidth / 2), this.ArrowStartPosX + distanceHintBoxTextureWidth - this.ArrowWidth, 1 - Vector3.Distance(this.MoverObject.transform.position, this.EndPositionObject.transform.position) / this.totalDistance);
    }

    void OnGUI()
    {
        GUI.Box(new Rect(this.arrowCurrentPosX, this.DistanceHintRect.y * this.screenSize.y - this.ArrowWidth, this.ArrowWidth, this.ArrowWidth), this.ArrowTexture, this.style);

        GUI.Box(new Rect(this.DistanceHintRect.x * this.screenSize.x, this.DistanceHintRect.y * this.screenSize.y, this.DistanceHintRect.width * this.screenSize.x, this.DistanceHintRect.height * this.screenSize.y),
                        this.DistanceHintBoxTexture,
                        this.style);
    }
}