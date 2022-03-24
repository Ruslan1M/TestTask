using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour, IMoveable
{
    [SerializeField] [Range(0, 4f)] float lerp;
    [SerializeField] Transform finalPos;

    public Rigidbody rigidbody;
    public bool _isAcceleration;
    private Vector3 xyz;
    private bool _isDrag;

    private void OnMouseDown()
    {
        _isDrag = true;
    }
    private void OnMouseUp()
    {
        _isDrag = false;
        _isAcceleration = true;
        StartCoroutine(RequestCoroutine());
    }
    private void Update()
    {
        if (_isDrag)
        {
            Move();
        }
        Acceleration();
    }
    public void Move()
    {
        xyz = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, transform.position.y, transform.position.z));
        xyz.y = transform.position.y;
        xyz.z = transform.position.z;
        transform.position = xyz;
        if (transform.position.x > 2.15f)
        {
            transform.position = new Vector3(2.15f , xyz.y , xyz.z);
        }
        if (transform.position.x < -2.2f)
        {
            transform.position = new Vector3(-2.2f, xyz.y, xyz.z);
        }
    }

    public void Acceleration()
    {
        if (_isAcceleration && rigidbody != null)
        {
            rigidbody.transform.position = Vector3.Lerp(rigidbody.transform.position, finalPos.position, lerp * Time.deltaTime);
        }
        if (transform.position.z > 18f)
            _isAcceleration = false;
    }

    IEnumerator RequestCoroutine()
    {
        yield return new WaitForSeconds(0.5f);
        CubePool.Instance.CubeRequest();
    }
}

