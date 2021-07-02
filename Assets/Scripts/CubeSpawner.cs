using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeSpawner : MonoBehaviour
{
    public GameObject cubePrefab;
    public float cubeSize;
    private string FileLoacation;
    [SerializeField] string saveFileName;
    [SerializeField] int rows, columns, depth, minDepth, minColumn, minRow;
    [SerializeField] float padding;


    private Dictionary<CubeType, Material> fruitsMaterial;

    [SerializeField]
    private CubeDataList myCubeDataList = new CubeDataList();
    bool dataLaoded;

    private void Awake()
    {
        CreateMatDictionary();
        FileLoacation = Application.dataPath + "/Resources/" + saveFileName + ".txt";
        CubeDataList temp = JSONWriter.LoadData(FileLoacation);
        if (temp != null)
        {
            myCubeDataList = temp;
            dataLaoded = true;
        }
    }
    private void Start()
    {             
        if(dataLaoded)
        {
            LoadCube();
        }
        else
        {
            CreateCube();
        }
    }


    public void CreateMatDictionary()
    {
        fruitsMaterial = new Dictionary<CubeType, Material>
        {
            {CubeType.Apple,ResourceLoader.LoadMaterial(CubeType.Apple.ToString())},
            {CubeType.Avacado, ResourceLoader.LoadMaterial(CubeType.Avacado.ToString())},
            {CubeType.Banana, ResourceLoader.LoadMaterial(CubeType.Banana.ToString())},
            {CubeType.Berry, ResourceLoader.LoadMaterial(CubeType.Berry.ToString())},
            {CubeType.CustardApple, ResourceLoader.LoadMaterial(CubeType.CustardApple.ToString())},
            {CubeType.Grape,ResourceLoader.LoadMaterial(CubeType.Grape.ToString())}
        };
    }
    public void LoadCube()
    {
        for (int i = 0; i < myCubeDataList.cubeDatas.Length; i++)
        {
            SpawnCube(myCubeDataList.cubeDatas[i].cubePosition, myCubeDataList.cubeDatas[i].Cube);
        }
    }

    public void SpawnCube(Vector3 pos, CubeType type)
    {
        var cube = Instantiate(cubePrefab, pos * cubeSize, Quaternion.identity);

        cube.GetComponent<Renderer>().material = fruitsMaterial[type];
    }

    public void CreateCube()
    {
        for (int x = 0; x < myCubeDataList.cubeDatas.Length; x++)
        {

            for (int i = minDepth; i < depth; i++)
            {
                for (int j = minColumn; j < columns; j++)
                {
                    for (int k = minRow; k < rows; k++)
                    {

                        myCubeDataList.cubeDatas[x].cubePosition = new Vector3(i, j, k) * padding;
                        myCubeDataList.cubeDatas[x].Cube = (CubeType)Random.Range(0, System.Enum.GetValues(typeof(CubeType)).Length);
                        SpawnCube(myCubeDataList.cubeDatas[x].cubePosition, myCubeDataList.cubeDatas[x].Cube);
                        x++;

                    }
                }
            }
        }

        JSONWriter.SaveData(FileLoacation, myCubeDataList);
    }

}

