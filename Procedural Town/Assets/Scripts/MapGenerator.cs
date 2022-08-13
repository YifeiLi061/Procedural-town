using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    //public GameObject Enemy;
    //public int enemyDensity;
    public int enemyCount;//�հ���Ƭ����
    public bool isPress;//�Ƿ�ִ����GenerateMap����


    public GameObject tilePrefab;
    public Vector2 mapSize;
    public Transform MapHolder;
    [Range(0, 1)] public float outlinePercent;

    //public GameObject obsPrefab;
    public GameObject[] buildingPrefabs;
    public float obsCount;
    public float minObsHeight = 0.5f;
    public float maxObsHeight = 5f;
    public float Rotation = 50f;

    List<Coord> allTileCoords;
    #region
    //public Map[] maps;
    public int mapIndex=1;
    //Map currentMap;
    #endregion
    
    private Queue<Coord> shuffledQueue;
    Queue<Coord> shuffleOpenTileCoords;

    [Header("Map Fully Accessible")]
    [Range(0, 1)] public float obsPercent;
    private Coord mapCenter;
    bool[,] mapObstacles;//�жϸ������Ƿ����ϰ���

    Transform[,] tileMap;

    #region navMesh
    public Vector2 maxMapSize;
    public GameObject navMeshPrefab;
    #endregion

    public void NewWave()
    {
        isPress = true;
        enemyCount = ((((int)mapSize.x)*((int)mapSize.y))- GenerateMap());
        Debug.Log(enemyCount);
        isPress = true;
    }


    public void GenerateEnemy()
    {
        GetRandomOpenCoord();

    }

    public  int GenerateMap()
    {

        tileMap = new Transform[(int)mapSize.x, (int)mapSize.y];

        allTileCoords = new List<Coord>();//ÿ�ο���һ���µĵ�ͼ���������һ�γ�ʼ������������ȥ��

        #region ����д
        string holderName = "MapHolder";
        if (transform.Find(holderName))
        {
            DestroyImmediate(transform.Find(holderName).gameObject);
        }
        Transform MapHolder = new GameObject(holderName).transform;
        MapHolder.parent = transform;
        #endregion

        //������Ƭ��ͼ
        for (int i = 0; i < mapSize.x; i++)
        {
            for (int j = 0; j < mapSize.y; j++)
            {
                Vector3 newPos = new Vector3((((-mapSize.x) / 2) + 0.5f + i), 0, (((-mapSize.y) / 2) + 0.5f + j));
                GameObject spawnTile = Instantiate(tilePrefab, newPos, Quaternion.Euler(90, 0, 0));
                spawnTile.transform.SetParent(MapHolder);
                //spawnTile.transform.localScale *= (1 - outlinePercent);
                allTileCoords.Add(new Coord(i, j));
                tileMap[i, j] = spawnTile.transform;


            }
        }

        shuffledQueue = new Queue<Coord>(Utilities.ShuffleCoords(allTileCoords.ToArray()));

        //��ˮ
        int obsCount = (int)(mapSize.x * mapSize.y * obsPercent);//���ϰ���
        mapCenter = new Coord((int)mapSize.x / 2, (int)mapSize.y / 2);
        mapObstacles = new bool[(int)mapSize.x, (int)mapSize.y];//��ʼ��
        int currentObscount = 0;

        List<Coord> allOpenCoords = new List<Coord>(allTileCoords);//һ��ʼ�϶�����allTileCoords

        for (int i = 0; i < obsCount; i++)
        {
            Coord randomCoord = GetRandomCoord();
            mapObstacles[randomCoord.x, randomCoord.y] = true;//������
            currentObscount++;
            int c = UnityEngine.Random.Range(0, 3);
            Debug.Log(c);
            GameObject obsPrefab = buildingPrefabs[c];

            if (randomCoord != mapCenter && MapIsFullyAccessible(mapObstacles, currentObscount))//��ˮ�ж�������λ�ã��ϰ���,�������������λ�ö������ɡ�
            {
                float obsHeight = UnityEngine.Random.Range(minObsHeight, maxObsHeight);
                float Yrotate = UnityEngine.Random.Range(0, Rotation);

                Vector3 newPos = new Vector3((((-mapSize.x) / 2) + 0.5f + randomCoord.x), 0.01f, (((-mapSize.y) / 2) + 0.5f + randomCoord.y));
                obsPrefab.transform.rotation = Quaternion.Euler(0f, Yrotate, 0f);

                
                //a.transform.rotation = Quaternion.Euler(0f, Yrotate, 0f);
                //a.transform.localEulerAngles = new Vector3(0f, Yrotate, 0f);

                GameObject spawnObs = Instantiate(obsPrefab, newPos, obsPrefab.transform.rotation);
                //GameObject spawnObs = Instantiate(obsPrefab, newPos, Quaternion.identity);
                spawnObs.transform.SetParent(MapHolder);
                spawnObs.transform.localScale *= (1 - outlinePercent);
                //spawnObs.transform.localScale = new Vector3(1 - outlinePercent, obsHeight, 1 - outlinePercent);

                allOpenCoords.Remove(randomCoord);


            }
            else//�������λ������
            {
                mapObstacles[randomCoord.x, randomCoord.y] = false;//������
                currentObscount--;//
            }
        }

        shuffleOpenTileCoords = new Queue<Coord>(Utilities.ShuffleCoords(allOpenCoords.ToArray()));

        #region
        //navMeshFloor.transform.localScale = new Vector3(maxMapSize.x, maxMapSize.y);
        //mapFloor.transform.localScale = new Vector3(currentMap.mapSize.x , currentMap.mapSize.y );

        GameObject obsTop = Instantiate(navMeshPrefab, Vector3.forward * (mapSize.y + maxMapSize.y) / 4, Quaternion.identity);
        obsTop.transform.parent = MapHolder;
        obsTop.transform.localScale = new Vector3(mapSize.x, 5, maxMapSize.y / 2 - mapSize.y / 2 );

        GameObject obsBottom = Instantiate(navMeshPrefab, Vector3.back * (mapSize.y + maxMapSize.y) / 4, Quaternion.identity);
        obsBottom.transform.parent = MapHolder;
        obsBottom.transform.localScale = new Vector3(mapSize.x, 5, maxMapSize.y / 2 - mapSize.y / 2);

        GameObject obsLeft = Instantiate(navMeshPrefab, Vector3.left * (mapSize.x + maxMapSize.x) / 4, Quaternion.identity);
        obsLeft.transform.parent = MapHolder;
        obsLeft.transform.localScale = new Vector3(maxMapSize.x / 2 - mapSize.x / 2, 5, mapSize.y);

        GameObject obsRight = Instantiate(navMeshPrefab, Vector3.right * (mapSize.x + maxMapSize.x) / 4, Quaternion.identity);
        obsRight.transform.parent = MapHolder;
        obsRight.transform.localScale = new Vector3(maxMapSize.x / 2 - mapSize.x / 2, 5, mapSize.y) ;

        #endregion

        return obsCount;

    }

    public bool MapIsFullyAccessible(bool[,] _mapObstacles, int _currentObscount)
    {
        bool[,] mapFlags = new bool[_mapObstacles.GetLength(0), _mapObstacles.GetLength(1)];

        Queue<Coord> queue = new Queue<Coord>();
        queue.Enqueue(mapCenter);
        mapFlags[mapCenter.x, mapCenter.y] = true;
        int accessibleCount = 1;
        while (queue.Count > 0)
        {
            Coord currentTile = queue.Dequeue();
            for (int x = -1; x <= 1; x++)
            {
                for (int y = -1; y <= 1; y++)
                {
                    int neighborX = currentTile.x + x;
                    int neighborY = currentTile.y + y;
                    if (x == 0 || y == 0)
                    {
                        if (neighborX >= 0 && neighborX < _mapObstacles.GetLength(0)
                            && neighborY >= 0 && neighborY < _mapObstacles.GetLength(1))
                        {
                            if (!mapFlags[neighborX, neighborY] && !_mapObstacles[neighborX, neighborY])
                            {
                                mapFlags[neighborX, neighborY] = true;
                                accessibleCount++;
                                queue.Enqueue(new Coord(neighborX, neighborY));

                            }
                        }
                    }
                }
            }
        }
        int obsTargetCount = (int)(mapSize.x * mapSize.y - _currentObscount);
        return accessibleCount == obsTargetCount;

    }

    public Coord GetRandomCoord()
    {
        Coord randomCoord = shuffledQueue.Dequeue();
        shuffledQueue.Enqueue(randomCoord);
        return randomCoord;
    }

    public Transform GetRandomOpenCoord()
    {
        Coord randomCoord = shuffleOpenTileCoords.Dequeue();
        shuffleOpenTileCoords.Enqueue(randomCoord);
        return tileMap[randomCoord.x, randomCoord.y];

    }
}


[System.Serializable]
public struct Coord
{
    public int x;
    public int y;
    public Coord(int _X, int _y)
    {
        this.x = _X;
        this.y = _y;


    }
    public static bool operator !=(Coord _c1, Coord _c2)
    {
        return !(_c1 == _c2);
    }
    public static bool operator ==(Coord _c1, Coord _c2)
    {
        return (_c1.x == _c2.x) && (_c1.y == _c2.y);

    }
}
