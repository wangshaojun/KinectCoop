using UnityEngine;
using System.Collections;

public class FruitCreator : MonoBehaviour
{
    public static int ikind = 0;
    public static bool isMoving = false;
    public static Transform f1, f2, f3, f4;
    public Transform[] fruits = new Transform[4] { f1, f2, f3, f4 };
    public Transform dir1, dir2, dir3, dir4;
    Vector3 origin_pos = new Vector3(0, 0, 0);

    public GameObject magicball, dir;

    // Use this for initialization
    void Start()
    {
        AddFruit();
        origin_pos = fruits[ikind].position;
        //call fruitElement update function
    }

    // Update is called once per frame
    void Update()
    {
        if (isMoving)  //水果往對應的方向移動、消失
        {
            Debug.Log(fruits[ikind].position);
            switch(ikind){
                case 0: //left
                    //fruits[ikind].position += new Vector3(-10 * Time.deltaTime, 0, 0);
                    fruits[ikind].transform.Translate(-10 * Time.deltaTime, 0, 0);
                    if (fruits[ikind].position.x < -20)
                    {
                        DeleteFruit();
                        fruits[ikind].position = origin_pos; //還原位置
                        isMoving = false;
                        AddFruit(); //置換水果
                    }
                    break;
                case 1: //up
                    //fruits[ikind].position += new Vector3(0, 10 * Time.deltaTime, 0);
                    fruits[ikind].transform.Translate(0, 10 * Time.deltaTime, 0);
                    if (fruits[ikind].position.y > 20)
                    {
                        DeleteFruit();
                        fruits[ikind].position = origin_pos; //還原位置
                        isMoving = false;
                        AddFruit(); //置換水果
                    }
                    break;
                case 2: //down
                    fruits[ikind].position += new Vector3(0,-10 * Time.deltaTime, 0);
                    if (fruits[ikind].position.y < -20)
                    {
                        DeleteFruit();
                        fruits[ikind].position = origin_pos; //還原位置
                        isMoving = false;
                        AddFruit(); //置換水果
                    }
                    break; 
                case 3: //right
                    fruits[ikind].position += new Vector3(10 * Time.deltaTime, 0, 0);
                    if (fruits[ikind].position.x > 20)
                   {
                      DeleteFruit();
                      fruits[ikind].position = origin_pos; //還原位置
                      isMoving = false;
                      AddFruit(); //置換水果
                   }
                    break;

            }
        }
    }

    void AddFruit()
    {
        ikind = Random.Range(0, 4);
        ikind = 0;  //test
        //Instantiate(fruits[ikind]);
//        magicball = (GameObject)Instantiate(fruits[ikind]);
        magicball = Instantiate(fruits[ikind]) as GameObject;

        switch (ikind)
        {
            case 0: //left, green
                dir = Instantiate(dir1) as GameObject;
                print("green");
                break;
            case 1: //up, red
                dir = Instantiate(dir2) as GameObject;
                print("red");
                break;
            case 2: //down, yellow
                dir = Instantiate(dir3) as GameObject;
                print("yellow");
                break;
            case 3: //right, blue
                dir = Instantiate(dir4) as GameObject;
                print("blue");
                break;
            default:
                print("other");
                break;
        }

    }
    void DeleteFruit()
    {
        switch (ikind)
        {
            case 0: //left
                Destroy(GameObject.Find("Ball2_Prefab(Clone)"));
                Destroy(GameObject.Find("DirectionPlane_1(Clone)"));
                break;
            case 1: //up
                Destroy(GameObject.Find("Ball1_Prefab(Clone)"));
                Destroy(GameObject.Find("DirectionPlane_2(Clone)"));
                break;
            case 2: //down
                Destroy(GameObject.Find("Ball3_Prefab(Clone)"));
                Destroy(GameObject.Find("DirectionPlane_3(Clone)"));
                break;
            case 3: //right
                Destroy(GameObject.Find("Ball4_Prefab(Clone)"));
                Destroy(GameObject.Find("DirectionPlane_4(Clone)"));
                break;
        }
        Destroy(magicball);
        Destroy(dir);
        Debug.Log("destory");
    }
}