using UnityEngine;
using System.Collections;

/// <summary>
/// �B�z���a�i�J���I�A�i�JStage3
/// </summary>
public class NextStage_Stage2 : MonoBehaviour
{
    public Stage2Data stageData_script;

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
            this.stageData_script.NextStage("Stage3", 1.0f);
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
