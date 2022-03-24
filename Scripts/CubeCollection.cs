using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeCollection : MonoBehaviour ,ICollectable
{
    public GameObject MergedObject;
    public float Distance;
    public float MergeSpeed;
    public int num;

    private Color color = new Color(1f, 0.75f , 0.75f ,0.75f);
    private int _ID;
    private Transform _block1;
    private Transform _block2;
    private bool _canMerge;
    private Cube cube;
    
    void Start()
    {
        _ID = GetInstanceID();
        cube = GetComponent<Cube>();
    }
    private void FixedUpdate()
    {
        Collect();
    }
    public void Collect()
    {
        if (_canMerge)
        {
            if (_block1 != null && _block2 != null)
            {
                transform.position = Vector3.MoveTowards(_block1.position, _block2.position, MergeSpeed);

                if (Vector3.Distance(_block1.position, _block2.position) < Distance)
                {
                    if (_ID < _block2.gameObject.GetComponent<CubeCollection>()._ID) { return; }
                    Spawn();
                    Destroy(_block2.gameObject);
                    Destroy(gameObject);
                }
            }
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<CubeCollection>())
        {
            StartCoroutine(StopMovementCoroutine());
            if (collision.gameObject.GetComponent<CubeCollection>().num == this.num)
            {
                _block1 = transform;
                _block2 = collision.transform;
                _canMerge = true;
                Destroy(collision.gameObject.GetComponent<Rigidbody>());
                Destroy(GetComponent<Rigidbody>());
            }
        }
    }

    IEnumerator StopMovementCoroutine()
    {
        yield return new WaitForSeconds(0.02f);
        if (cube != null)
        {
            cube._isAcceleration = false;
        }
    }

    public void Spawn()
    {
        GameObject Obj = Instantiate(MergedObject, transform.position, Quaternion.identity) as GameObject;
        var numObj = Obj.GetComponent<CubeCollection>().num;
        numObj = this.num *2;
        ScoreSystem.Instance.AddScore(numObj);
        float colorNum = (float)numObj;
        Obj.GetComponent<CubeCollection>().num = numObj;
        if (numObj <= 64)
        {
            color.g -= colorNum / 100;
            color.b -= colorNum / 100;
            Obj.GetComponent<MeshRenderer>().material.color = color;
        }
        else
        {
            color.g = 1;
            color.b -= colorNum / 100;
            Obj.GetComponent<MeshRenderer>().material.color = color;
        }
        if (Obj.GetComponent<Rigidbody>() == null)
            Obj.AddComponent<Rigidbody>();
    }
}
