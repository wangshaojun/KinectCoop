using UnityEngine;
using System.Collections;

/// <summary>
/// ø�s���[�Ϫ��ѧO�u
/// </summary>
public class DrawSkeletonLine : MonoBehaviour
{
    public GameObject Target;       //ø�s�ؼ��I
    public Material LineMaterial;   //����y(�u���C��)
    public float LineWidth;         //�u���e��

    private LineRenderer lineRenderer;
    // Use this for initialization
    void Start()
    {
        this.lineRenderer = this.gameObject.AddComponent<LineRenderer>();   //����LineRenderer
        this.lineRenderer.material = this.LineMaterial;                     //�]�w����y
        this.lineRenderer.useWorldSpace = false;                            //�ϥ�local�y��
        this.lineRenderer.SetPosition(0, Vector3.zero);
        this.lineRenderer.SetWidth(this.LineWidth, this.LineWidth);
    }

    // Update is called once per frame
    void Update()
    {
        //�p����I���V�q
        this.lineRenderer.SetPosition(1, (this.Target.transform.localPosition - this.transform.localPosition) / this.transform.localScale.magnitude * 2);
    }
}
