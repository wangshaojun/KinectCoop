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

    public GUIStyle style;

    private Vector2 screenSize;             //�����j�p
    private float totalDistance;            //�`����
    private float arrowCurrentPosX;         //�b�Y��e����m

    // Use this for initialization
    void Start()
    {
        //�p���`����
        this.totalDistance = Vector3.Distance(this.MoverObject.transform.position, this.EndPositionObject.transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        this.screenSize = new Vector2((float)Screen.width / 1280.0f, (float)Screen.height / 720.0f);     //���e�ù��j�p
        this.arrowCurrentPosX = (this.DistanceHintBoxTexture.width * this.DistanceHintRect.width * this.screenSize.x) * Mathf.Lerp(1, 0, Vector3.Distance(this.MoverObject.transform.position, this.EndPositionObject.transform.position) / this.totalDistance);
    }

    void OnGUI()
    {
        GUI.Box(new Rect(this.DistanceHintRect.x * this.screenSize.x, this.DistanceHintRect.y * this.screenSize.y, this.DistanceHintBoxTexture.width * this.DistanceHintRect.width * this.screenSize.x, this.DistanceHintBoxTexture.height * this.DistanceHintRect.height * this.screenSize.y),
                        this.DistanceHintBoxTexture,
                        this.style);

        GUI.Box(new Rect((this.DistanceHintRect.x - this.ArrowTexture.width / 2) * this.screenSize.x + this.arrowCurrentPosX, (this.DistanceHintRect.y - this.ArrowTexture.height) * this.screenSize.y, this.ArrowTexture.width * this.screenSize.x, this.ArrowTexture.height * this.screenSize.y), this.ArrowTexture, this.style);
    }
}