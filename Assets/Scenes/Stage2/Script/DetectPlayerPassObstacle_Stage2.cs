using UnityEngine;
using System.Collections;

public class DetectPlayerPassObstacle_Stage2 : MonoBehaviour
{
    public LayerMask PlayerLayer;        //ª±®aªºLayer

    void OnTriggerEnter(Collider other)
    {
        if (((1 << other.gameObject.layer) & this.PlayerLayer.value) > 0)
        {
            CalculateScore_Stage2.PassObstacleCount++;
        }
    }
    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }
}
