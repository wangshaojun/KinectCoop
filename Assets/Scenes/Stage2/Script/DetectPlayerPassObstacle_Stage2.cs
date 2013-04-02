using UnityEngine;
using System.Collections;

public class DetectPlayerPassObstacle_Stage2 : MonoBehaviour
{
    public CalculateScore_Stage2 CalculateScore_Script;
    public LayerMask PlayerLayer;        //ª±®aªºLayer

    void OnTriggerEnter(Collider other)
    {
        if (((1 << other.gameObject.layer) & this.PlayerLayer.value) > 0)
        {
            this.CalculateScore_Script.PassObstacleCount++;
        }
    }
    // Use this for initialization
    void Start()
    {
        if (this.CalculateScore_Script == null)
            this.CalculateScore_Script = GameObject.Find("CalculateScore").GetComponent<CalculateScore_Stage2>();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
