using UnityEngine;
using System.Collections;

public class FruitCreator : MonoBehaviour {
    public static int ikind = 0;
    public static Transform f1, f2, f3, f4;
    public Transform[] fruits = new Transform[4] { f1, f2, f3, f4 };
    public Transform dir1, dir2, dir3, dir4;

	// Use this for initialization
	void Start () {
        AddFruit();
        //call fruitElement update function
	}
	
	// Update is called once per frame
	void Update () {
        if (LevelController_1.isBingo)  //配對成功，水果往對應的方向移動、消失
        {
            Debug.Log("執行水果配對");
            fruits[ikind].position += new Vector3(-10 * Time.deltaTime, 0, 0); //red
            if (fruits[ikind].position.x < -20)
            {
                DeleteFruit();
                fruits[ikind].position = new Vector3(0, 0, 55); //還原位置
                LevelController_1.isBingo = false;
                AddFruit(); //置換水果
            }
        }
	}
    void AddFruit()
    {
        ikind = Random.Range(0, 4);
        //ikind = 0;  //test
        Instantiate(fruits[ikind]);
        
        switch (ikind)
        {
            case 0: //left, green
                Instantiate(dir3);
                print("green");
                break;
            case 1: //up, yellow
                Instantiate(dir2);
                print("yellow");
                break;
            case 2: //down, red
                Instantiate(dir1);
                print("red");
                break;
            case 3: //right, blue
                Instantiate(dir4);
                print("blue");
                break;
            default:
                print("other");
                break;
        }
    }
    void DeleteFruit() {
        Destroy(fruits[ikind]);
        switch (ikind)
        {
            case 0: //left
                Destroy(dir1);
                break;
            case 1: //up
                Destroy(dir2);
                break;
            case 2: //down
                Destroy(dir3);
                break;
            case 3: //right
                Destroy(dir4);
                break;
        }
    }
}
