using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubePool : MonoBehaviour
{
    private static CubePool _instance;
    public static CubePool Instance
    {
        get
        {
            if (_instance == null)
            {
                Debug.LogError("CubePool must be add on the scene");
                return null;
            }
            return _instance;
        }
    }

    private void Awake()
    {
        _instance = this;
    }

    public int condition;

    [SerializeField]
    GameObject[] _cubePrefabs;
    [SerializeField]
    GameObject _prefabContainer;

    public int cubeAmount = 0;

    private void Start()
    {
        CubeRequest();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            CubeRequest();
        }
    }

    public GameObject CubeRequest()
    {
        GameObject _newCube = Instantiate(_cubePrefabs[Random.Range(0, _cubePrefabs.Length)]);
        _newCube.transform.parent = _prefabContainer.transform;
        _newCube.SetActive(true);
        ScoreSystem.Instance.AddScore(_newCube.GetComponent<CubeCollection>().num);
        cubeAmount++;
        if (cubeAmount == condition)
        {
            Events.onCondtitionCompleted();
            cubeAmount = 0;
        }
        return _newCube;
    }
}
