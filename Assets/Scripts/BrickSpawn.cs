using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

public static class LevelData
{
    public static float[] stageFallTime = new float[4];
    public static int[] stageBrickLife = new int[4];
}

public class BrickSpawn : MonoBehaviour
{
    //바꿔줘야 하는 부분
    public int maxCol;
    public int maxRow;
    public int howManyType;
    public int howManyStage;
    //

    public GameObject[] typeBlock;
    private GameObject[] allStones;
    private GameObject[] allIces;
    private GameObject[] allTraps;
    private GameObject[] allAlienIce;
    private GameObject[] allitemIce;

    private int[] nextSpawnBrickLine;   //다음에 생성될 블럭 라인(타입으로 입력)
    private int randomNum;

    private string nowRandomItem;
    private GameObject ParentItemBlock;
    private GameObject ChildItem;

    public float initialBrickSpawnPosX;
    public float initialBrickSpawnPosY;
    public float bricksDistanceX;    //블록 사이 간격
    public float bricksDistanceY;

    private int nowLevel;
    public float nowFallTime;

    public List<int[,]> LevelsData { get; set; }


    void Start()
    {
        nextSpawnBrickLine = new int[maxCol];
        LevelData.stageFallTime = new float[howManyStage];

        //시작하면 레벨데이터 불러오기
        this.LevelsData = this.LoadLevelsData();
        nowFallTime = LevelData.stageFallTime[GameManager.stageNum - 1];
        StartCoroutine("SpawnBrick");

        nowLevel = 0;
    }

    private void randomNextBrick()
    {
        //현재 레벨의 brick 데이터를 불러옴 : 0:타입 1:확률 x n줄
        int[,] nowLevelBrickData = LevelsData[GameManager.stageNum - 1];

        for (int col = 0; col < maxCol; col++)
        {
            randomNum = Random.Range(1, 101);   //끝값은 제외됨

            for (int i = 0; i < howManyType; i++)
            {
                if (randomNum <= nowLevelBrickData[i, 1])
                {
                    nextSpawnBrickLine[col] = nowLevelBrickData[i, 0]; //배열에는 무슨 타입이 선택됐는지 저장
                    randomNum = 0;
                    break;
                }
                else
                {
                    randomNum -= nowLevelBrickData[i, 1];
                }
            }

            if (randomNum != 0)  //제대로 값이 들어가지 않았을 경우 빈칸으로 채움
            {
                nextSpawnBrickLine[col] = 0;
            }
        }
    }

    void fallBricks(GameObject[] bricks)
    {
        for (int i = 0; i < bricks.Length; i++)
        {
            bricks[i].transform.Translate(new Vector2(0, -bricksDistanceY));

            //박스가 플레이어보다 내려왔을 경우
            if (bricks[i].transform.position.y <= GameObject.FindGameObjectWithTag("Player").transform.position.y + bricksDistanceY)
            {
                Destroy(bricks[i].gameObject);
                GameObject.Find("GameManager").GetComponent<Life>().stageOver();
            }
        }

    }

    void randomItem()
    {
        if (Store.unlockItem.Count != 0)
        {
            nowRandomItem = Store.unlockItem[Random.Range(0, Store.unlockItem.Count)];  //아이템 스트링 하나 랜덤 선택
            ChildItem = Instantiate(Resources.Load("Prefabs/Item/" + nowRandomItem), ParentItemBlock.transform.position, Quaternion.identity) as GameObject;
            ChildItem.transform.SetParent(ParentItemBlock.transform);

            if (nowRandomItem == "바길게" || nowRandomItem == "바짧게" || nowRandomItem == "생명")
            {
                ChildItem.GetComponent<Animator>().enabled = false;
            }
        }
    }

    IEnumerator SpawnBrick()
    {
        while (true)
        {
            yield return new WaitForSeconds(nowFallTime);       //기다렸다가

            //한줄씩 내리고
            allStones = GameObject.FindGameObjectsWithTag("Stone");
            allIces = GameObject.FindGameObjectsWithTag("Ice");
            allTraps = GameObject.FindGameObjectsWithTag("Trap");
            allAlienIce = GameObject.FindGameObjectsWithTag("AlienIce");
            allitemIce = GameObject.FindGameObjectsWithTag("ItemIce");

            fallBricks(allStones);
            fallBricks(allIces);
            fallBricks(allTraps);
            fallBricks(allAlienIce);
            fallBricks(allitemIce);


            //맨 윗줄은 새로운 랜덤 줄 생성
            randomNextBrick();
            for (int col = 0; col < maxCol; col++)
            {
                ParentItemBlock = Instantiate(typeBlock[nextSpawnBrickLine[col]], new Vector2(initialBrickSpawnPosX + bricksDistanceX * col, initialBrickSpawnPosY), Quaternion.identity);

                if (nextSpawnBrickLine[col] == 4)    //아이템 얼음인 경우에
                {
                    randomItem();  //자식으로 아이템 랜덤 생성
                }
            }

        }
    }

    //레벨 데이터를 불러오는 작업을 하는 함수    
    private List<int[,]> LoadLevelsData()
    {
        TextAsset levelText = Resources.Load("levels") as TextAsset;

        //먼저 "줄 바꿈" 기준으로 줄을 나눠서 한줄씩 string 배열에 저장 : string 기준으로 나눌때는 RemoveEmptyEntries를 해줘야함(빈칸 제거) 
        //string[] rows = levelText.text.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
        StringReader sr = new StringReader(levelText.text);

        string line = sr.ReadLine();

        //임시 데이터 리스트(하나씩 불러와서 입력할거임)
        List<int[,]> levelsData = new List<int[,]>();
        int[,] nowLevelData = new int[howManyType, 2];       //2: 타입,확률 두개 변수

        int nowRow = 0;

        //줄의 수 만큼 탐색 반복
        while (line != null)
        {
            //한줄씩 검사

            if (line.IndexOf("#") == -1)    //#있는 부분은 무시
            {
                if (line.IndexOf("--") != -1)  //"--"가 나오면 : 레벨 하나가 끝나면 -> levelList에 레벨 하나 저장 + 임시 배열들 초기화
                {
                    levelsData.Add(nowLevelData);
                    nowRow = 0;
                    nowLevel++;
                    nowLevelData = new int[maxRow, maxCol];
                }

                else if (line.IndexOf("s") != -1)
                {
                    string[] bricks = line.Split('s');
                    LevelData.stageFallTime[nowLevel] = float.Parse(bricks[0]);
                }

                else if (line.IndexOf("h") != -1)
                {
                    string[] bricks = line.Split('h');
                    LevelData.stageBrickLife[nowLevel] = int.Parse(bricks[0]);
                }

                else if (line.Length == 0)
                {
                    sr.Close();
                    return levelsData;
                }

                else
                {
                    //string[] brickData = line.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

                    //숫자 하나씩 쪼개서 bricks 배열에 임시 저장
                    string[] bricks = line.Split(',');

                    //col == 세로 인덱스
                    for (int col = 0; col < bricks.Length; col++)
                    {
                        nowLevelData[nowRow, col] = int.Parse(bricks[col]);    //parse : string을 int로 바꿔줌
                    }

                    nowRow++;   //다음줄 탐색
                }
            }
            line = sr.ReadLine();
        }

        return levelsData;
    }
}
