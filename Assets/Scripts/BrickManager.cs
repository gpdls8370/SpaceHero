using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickManager : MonoBehaviour
{
    //4x4 블럭
    private int maxRow = 4;
    private int maxCol = 4;

    public float initialBrickSpawnPosX;
    public float initialBrickSpawnPosY;
    public float bricksDistanceX;    //블록 사이 간격
    public float bricksDistanceY;

    public int nowLevel;

    public List<int[,]> LevelsData { get; set; }


    void Start()
    {
        //시작하면 레벨데이터 불러오기
        this.LevelsData = this.LoadLevelsData();
        //spawnBrick();

    }

    private void spawnBrick()
    {
        //현재 레벨의 brick 데이터를 불러옴
        int[,] nowLevelBrickData = LevelsData[nowLevel];

        for(int row = 0; row < maxRow; row++)
        {
            for (int col = 0; col < maxCol; col++)
            {
                //해당 칸의 brick 데이터가 '1'이면 오브젝트 스폰
                if (nowLevelBrickData[row, col] == 1)
                {
                    //Quaternion.identity == 회전 없음 이라는 뜻
                    Instantiate(Resources.Load("Brick"), new Vector2(initialBrickSpawnPosX + bricksDistanceX * col, initialBrickSpawnPosY - bricksDistanceY * row), Quaternion.identity);
                }
            }
        }

    }

    //레벨 데이터를 불러오는 작업을 하는 함수    
    private List<int[,]> LoadLevelsData()
    {
        TextAsset levelText = Resources.Load("levels") as TextAsset;

        //먼저 "줄 바꿈" 기준으로 줄을 나눠서 한줄씩 string 배열에 저장 : string 기준으로 나눌때는 RemoveEmptyEntries를 해줘야함(빈칸 제거) 
        string[] rows = levelText.text.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);

        //임시 데이터 리스트(하나씩 불러와서 입력할거임)
        List<int[,]> levelsData = new List<int[,]>();
        int[,] nowLevelData = new int[maxRow, maxCol];
        
        int nowRow = 0;

        //줄의 수 만큼 탐색 반복
        for (int row = 0; row < rows.Length; row++) 
        {
            //한줄씩 검사
            string line = rows[row];

            //해당 줄에 -- 가 없으면
            if (line.IndexOf("--") == -1) 
            {
                //string[] brickData = line.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                
                //숫자 하나씩 쪼개서 bricks 배열에 임시 저장
                string[] bricks = line.Split(',');

                //col == 세로 인덱스
                for(int col = 0; col < bricks.Length; col++)
                {
                    nowLevelData[nowRow, col] = int.Parse(bricks[col]);    //parse : string을 int로 바꿔줌
                }

                nowRow++;   //다음줄 탐색
            }

            else  //"--"가 나오면 : 레벨 하나가 끝나면 -> levelList에 레벨 하나 저장 + 임시 배열들 초기화
            {
                levelsData.Add(nowLevelData);
                nowRow = 0;
                nowLevelData = new int[maxRow, maxCol];
            }
        }

        return levelsData;
    }
}
