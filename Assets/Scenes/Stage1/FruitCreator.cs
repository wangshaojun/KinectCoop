using UnityEngine;
using System.Collections;

public class FruitCreator : MonoBehaviour
{
    public static int ikind = 0;
    public static int idir;
    public static bool isMoving = false, isShowHint = true, saveTempTime = false, isBallKilled = false;
    public static bool isOver3sec = false; //三秒限制超過
    public static Transform f1, f2, f3, f4, f5, f6;
    public Transform[] fruits = new Transform[6] { f1, f2, f3, f4, f5, f6 };
    public Transform dir1, dir2, dir3, dir4;
    Vector3 origin_pos = new Vector3(0, 0, 30);

    public GameObject magicball, dir;

    // Use this for initialization
    void Start()
    {
        AddFruit();
        origin_pos = fruits[ikind].position;
    }

    // Update is called once per frame
    void Update()
    {
        if (isMoving) MoveFruit();  //魔法球往對應的方向移動

        if (isOver3sec)    //超時判斷-->更新魔法球
        {
            DeleteFruit();
            isOver3sec = false;
        }

        if (isBallKilled)   //從碰撞區(CubeTrigger)判斷是否移除魔法球
        { 
            DeleteFruit(); 
            isBallKilled = false; 
        }
    }

    void MoveFruit()    //還要增加黑色藍色的移動
    {
        switch (ikind)
        {
            case 0: //green
                switch (idir) {
                    case 0://left
                        GameObject.Find("magic ball green(Clone)").transform.Translate(-15 * Time.deltaTime, 0, 0);
                        break;
                    case 1://up
                        GameObject.Find("magic ball green(Clone)").transform.Translate(0, 15 * Time.deltaTime, 0);
                        break;
                    case 2://down
                        GameObject.Find("magic ball green(Clone)").transform.Translate(0, -15 * Time.deltaTime, 0);
                        break;
                    case 3://right
                        GameObject.Find("magic ball green(Clone)").transform.Translate(15 * Time.deltaTime, 0, 0);
                        break;
                }
                
                break;
            case 1: //red
                switch (idir)
                {
                    case 0://left
                        GameObject.Find("magic ball red(Clone)").transform.Translate(-15 * Time.deltaTime, 0, 0);
                        break;
                    case 1://up
                        GameObject.Find("magic ball red(Clone)").transform.Translate(0, 15 * Time.deltaTime, 0);
                        break;
                    case 2://down
                        GameObject.Find("magic ball red(Clone)").transform.Translate(0, -15 * Time.deltaTime, 0);
                        break;
                    case 3://right
                        GameObject.Find("magic ball red(Clone)").transform.Translate(15 * Time.deltaTime, 0, 0);
                        break;
                }
                //GameObject.Find("magic ball red(Clone)").transform.Translate(0, 15 * Time.deltaTime, 0);
                break;
            case 2: //yellow
                switch (idir)
                {
                    case 0://left
                        GameObject.Find("magic ball yellow(Clone)").transform.Translate(-15 * Time.deltaTime, 0, 0);
                        break;
                    case 1://up
                        GameObject.Find("magic ball yellow(Clone)").transform.Translate(0, 15 * Time.deltaTime, 0);
                        break;
                    case 2://down
                        GameObject.Find("magic ball yellow(Clone)").transform.Translate(0, -15 * Time.deltaTime, 0);
                        break;
                    case 3://right
                        GameObject.Find("magic ball yellow(Clone)").transform.Translate(15 * Time.deltaTime, 0, 0);
                        break;
                }
                //GameObject.Find("magic ball yellow(Clone)").transform.Translate(0, -15 * Time.deltaTime, 0);
                break;
            case 3: //blue
                switch (idir)
                {
                    case 0://left
                        GameObject.Find("magic ball blue(Clone)").transform.Translate(-15 * Time.deltaTime, 0, 0);
                        break;
                    case 1://up
                        GameObject.Find("magic ball blue(Clone)").transform.Translate(0, 15 * Time.deltaTime, 0);
                        break;
                    case 2://down
                        GameObject.Find("magic ball blue(Clone)").transform.Translate(0, -15 * Time.deltaTime, 0);
                        break;
                    case 3://right
                        GameObject.Find("magic ball blue(Clone)").transform.Translate(15 * Time.deltaTime, 0, 0);
                        break;
                }
                //GameObject.Find("magic ball blue(Clone)").transform.Translate(15 * Time.deltaTime, 0, 0);
                break;
            
            case 4: //purple
                switch (idir)
                {
                    case 0://left
                        GameObject.Find("magic ball purple(Clone)").transform.Translate(-15 * Time.deltaTime, 0, 0);
                        break;
                    case 1://up
                        GameObject.Find("magic ball purple(Clone)").transform.Translate(0, 15 * Time.deltaTime, 0);
                        break;
                    case 2://down
                        GameObject.Find("magic ball purple(Clone)").transform.Translate(0, -15 * Time.deltaTime, 0);
                        break;
                    case 3://right
                        GameObject.Find("magic ball purple(Clone)").transform.Translate(15 * Time.deltaTime, 0, 0);
                        break;
                }
                //GameObject.Find("magic ball blue(Clone)").transform.Translate(15 * Time.deltaTime, 0, 0);
                break;
            case 5: //black
                switch (idir)
                {
                    case 0://left
                        GameObject.Find("magic ball black(Clone)").transform.Translate(-15 * Time.deltaTime, 0, 0);
                        break;
                    case 1://up
                        GameObject.Find("magic ball black(Clone)").transform.Translate(0, 15 * Time.deltaTime, 0);
                        break;
                    case 2://down
                        GameObject.Find("magic ball black(Clone)").transform.Translate(0, -15 * Time.deltaTime, 0);
                        break;
                    case 3://right
                        GameObject.Find("magic ball black(Clone)").transform.Translate(15 * Time.deltaTime, 0, 0);
                        break;
                }
                //GameObject.Find("magic ball blue(Clone)").transform.Translate(15 * Time.deltaTime, 0, 0);
                break;
        }


    }

    void AddFruit()
    {
        fruits[ikind].position = origin_pos; //還原位置
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
        isMoving = false;
        AddFruit(); //置換水果
    }
}