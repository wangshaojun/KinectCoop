using UnityEngine;
using System.Collections;

public class FeetRayCast : MonoBehaviour
{

    public GameObject Target;
    public FeetMove feetMove;
    RaycastHit hit;

    public float velocity;
    public SkeletonWrapper skeletonWrapper;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (Physics.Raycast(transform.position, new Vector3(0, 0, 1), out hit, 10) == true)
        {
            Target = hit.transform.gameObject;




        }
        else
            Target = null;


        Vector3 FootLeft = skeletonWrapper.boneVel[0, (int)Kinect.NuiSkeletonPositionIndex.FootLeft];
        Vector3 FootRight = skeletonWrapper.boneVel[0, (int)Kinect.NuiSkeletonPositionIndex.FootRight];

        if (feetMove.FeetType == FeetMove.Feet.Left)
            if (FootLeft.y < velocity)
                print("¥ª¸}¤UÀ£");
        if (feetMove.FeetType == FeetMove.Feet.Right)
            if (FootRight.y < velocity)
                print("¥k¸}¤UÀ£");

    }
}
