using UnityEngine;
using System.Collections;

public class Obstacle : MonoBehaviour
{
    public GameObject Mover;
    private bool isTip = false;

    public float MoveDistance;
    public float MoveSpeed;

    public GUIStyle style;


    public float addValue;
    private Vector3 originPosition;

    // Use this for initialization
    void Start()
    {
        this.originPosition = this.transform.position;
        this.addValue = Random.value * this.MoveDistance;
    }

    // Update is called once per frame
    void Update()
    {
        if (Mathf.Abs(this.Mover.transform.position.z - this.transform.position.z) < 5)
            this.isTip = true;

        else
            this.isTip = false;

        if (this.addValue > this.MoveDistance)
        {
            this.addValue = this.MoveDistance;
            this.MoveSpeed = -this.MoveSpeed;
        }
        else if (this.addValue < 0)
        {
            this.addValue = 0;
            this.MoveSpeed = -this.MoveSpeed;
        }
        this.addValue += this.MoveSpeed * Time.deltaTime;

        this.transform.position = new Vector3(this.originPosition.x, this.originPosition.y - this.addValue, this.originPosition.z);
    }

    void OnGUI()
    {
        if (this.isTip)
            GUI.Box(new Rect(Screen.width * 0.8f, Screen.height * 0.2f, Screen.width * 0.1f, Screen.height * 0.1f), "ª`·N¡G¦³»ÙÃªª«", this.style);
    }
}
