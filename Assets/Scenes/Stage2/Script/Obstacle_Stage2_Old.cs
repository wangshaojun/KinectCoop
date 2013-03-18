using UnityEngine;
using System.Collections;

/// <summary>
/// �ĤG��-�B�z�i�J��ê�����d��(����UI�B����H���i���D)
/// </summary>
public class Obstacle_Stage2_Old : MonoBehaviour
{
    public GameObject Player;       //���a����H��

    private bool isTip = false;     //�O�_��ܴ���UI

    public Rect TipRect;            //����UI��Rect

    public Color HintTextColor;
    
    public GUIStyle style;

    /// <summary>
    /// ���a�i�J��ê���d���...
    /// </summary>
    /// <param name="other">�i�J������</param>
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.Equals(this.Player))   //�P�_�O�_�����a����H��
        {
            this.isTip = true;
        }
    }

    /// <summary>
    /// ���a���}��ê���d���...
    /// </summary>
    /// <param name="other">���}������</param>
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.Equals(this.Player))   //�P�_�O�_�����a����H��
        {
            this.isTip = false;
        }
    }

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (this.isTip)
        {
            //(������) �B�z���a�i�J���ܫ᪺����
            if (Input.GetKeyUp(KeyCode.G))
            {
                this.Player.rigidbody.velocity = new Vector3(0, 6, 6);
                //this.Player.transform.Translate(0, 4, 4);
            }
            this.style.normal.textColor = this.HintTextColor;
        }
    }

    void OnGUI()
    {
        //���ܪ�UI
        if (this.isTip)
            GUI.Box(new Rect(
                Screen.width * TipRect.x, Screen.height * TipRect.y, Screen.width * TipRect.width, Screen.height * TipRect.height),
                "�`�N�G����ê��",
                this.style);
    }
}
