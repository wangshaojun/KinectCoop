using UnityEngine;
using System.Collections;

public class FruitCreator : MonoBehaviour
{
    public static int ikind = 0;
    public static bool isMoving = false, isShowHint = true, saveTempTime = false;
    public static bool isOver3sec = false; //三秒限制超過
    public static Transform f1, f2, f3, f4, f5, f6;
    public Transform[] fruits = new Transform[6] { f1, f2, f3, f4, f5, f6 };
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
        if (isMoving)  //魔法球往對應的方向移動、消失
        {
            switch(ikind){
                case 0: //left
                    //fruits[ikind].position += new Vector3(-10 * Time.deltaTime, 0, 0);
                    GameObject.Find("magic ball green(Clone)").transform.Translate(-15 * Time.deltaTime, 0, 0);
                    //GameObject.Find("DirectionPlane_1(Clone)").   //這裡打算讓箭頭淡出(透明)
                    if (GameObject.Find("magic ball green(Clone)").transform.position.x < -20)
                    {
                        DeleteFruit();
                    }
                    break;
                case 1: //up
                    //fruits[ikind].position += new Vector3(0, 10 * Time.deltaTime, 0);
                    GameObject.Find("magic ball red(Clone)").transform.Translate(0, 15 * Time.deltaTime, 0);
                    if (GameObject.Find("magic ball red(Clone)").transform.position.y > 20)
                    {
                        DeleteFruit();
                    }
                    break;
                case 2: //down
                    //fruits[ikind].position += new Vector3(0,-10 * Time.deltaTime, 0);
                    GameObject.Find("magic ball yellow(Clone)").transform.Translate(0, -15 * Time.deltaTime, 0);
                    if (GameObject.Find("magic ball yellow(Clone)").transform.position.y < -20)
                    {
                        DeleteFruit();
                    }
                    break; 
                case 3: //right
                    //fruits[ikind].position += new Vector3(10 * Time.deltaTime, 0, 0);
                    GameObject.Find("magic ball blue(Clone)").transform.Translate(15 * Time.deltaTime, 0, 0);
                    if (GameObject.Find("magic ball blue(Clone)").transform.position.x > 20)
                   {
                      DeleteFruit();
                   }
                    break;
            }
        }
        if (isOver3sec)    //超時判斷-->更新魔法球
        {
            DeleteFruit();
            isOver3sec = false;
        }
    }

    void AddFruit()
    {
        saveTempTime = true;
        ikind = Random.Range(0, LevelController_1.kindNum);
        //ikind = 0;  //test
        magicball = Instantiate(fruits[ikind]) as GameObject;
        if (isShowHint)
        {
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

    }
    void DeleteFruit()
    {
        switch (ikind)
        {
            case 0: //left
                Destroy(GameObject.Find("magic ball green(Clone)"));
                Destroy(GameObject.Find("DirectionPlane_1(Clone)"));
                break;
            case 1: //up
                Destroy(GameObject.Find("magic ball red(Clone)"));
                Destroy(GameObject.Find("DirectionPlane_2(Clone)"));
                break;
            case 2: //down
                Destroy(GameObject.Find("magic ball yellow(Clone)"));
                Destroy(GameObject.Find("DirectionPlane_3(Clone)"));
                break;
            case 3: //right
                Destroy(GameObject.Find("magic ball blue(Clone)"));
                Destroy(GameObject.Find("DirectionPlane_4(Clone)"));
                break;
            case 4: //purple
                Destroy(GameObject.Find("magic ball purple(Clone)"));
                break;
            case 5: //black
                Destroy(GameObject.Find("magic ball black(Clone)"));
                break;
            default:
                break;
        }
        Destroy(magicball);
        Destroy(dir);

        fruits[ikind].position = origin_pos; //還原位置
        isMoving = false;
        AddFruit(); //置換水果
    }
}