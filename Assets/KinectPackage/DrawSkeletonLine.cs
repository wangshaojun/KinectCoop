using UnityEngine;
using System.Collections;

/// <summary>
/// 繪製骨架圖的識別線
/// </summary>
public class DrawSkeletonLine : MonoBehaviour
{
    public GameObject Target;       //繪製目標點
    public Material LineMaterial;   //材質球(線的顏色)
    public float LineWidth;         //線的寬度

    private LineRenderer lineRenderer;
    // Use this for initialization
    void Start()
    {
        this.lineRenderer = this.gameObject.AddComponent<LineRenderer>();   //產生LineRenderer
        this.lineRenderer.material = this.LineMaterial;                     //設定材質球
        this.lineRenderer.useWorldSpace = false;                            //使用local座標
        this.lineRenderer.SetPosition(0, Vector3.zero);
        this.lineRenderer.SetWidth(this.LineWidth, this.LineWidth);
    }

    // Update is called once per frame
    void Update()
    {
        //計算兩點的向量
        this.lineRenderer.SetPosition(1, (this.Target.transform.localPosition - this.transform.localPosition) / this.transform.localScale.magnitude * 2);
    }
}
