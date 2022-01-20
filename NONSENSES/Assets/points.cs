using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class points : MonoBehaviour
{
    // Start is called before the first frame update
    public GameManager gameManager;

    private float speed;

    public Transform FakeParent;

    private Vector3 _positionOffset;
    private Quaternion _rotationOffset;


    private void Start()
    {


        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();



        if (FakeParent != null)
        {
            SetFakeParent(FakeParent);
        }
    }


    private void FixedUpdate()
    {
        speed = gameManager.speedOfObstacle;
        if (!gameManager.pause)
        {
            if (FakeParent == null)
            {
                transform.position += Vector3.down * speed * Time.deltaTime;

            }
            else
            {
                var targetPos = FakeParent.position - _positionOffset;
                var targetRot = FakeParent.localRotation * _rotationOffset;

                transform.position = RotatePointAroundPivot(targetPos, FakeParent.position, targetRot);
                transform.localRotation = targetRot;
            }
        }
        if (transform.position.y < -10f || FakeParent == null)
        {

            gameManager.DestroyPoint(gameObject);

        }
    }


    public void SetFakeParent(Transform parent)
    {
        //Offset vector
        _positionOffset = parent.position - transform.position;

        _rotationOffset = Quaternion.Inverse(parent.localRotation * transform.localRotation);
        //Our fake parent
        FakeParent = parent;
    }




    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log("colision :"+collision.gameObject.name+"with :"+gameObject.name);
        if (collision.gameObject.tag == "Player")
        {
            FindObjectOfType<AudioManager>().Play("Point");
            gameManager.AddPoint(1);
            gameManager.DestroyPoint(gameObject);
        }

    }

    public Vector3 RotatePointAroundPivot(Vector3 point, Vector3 pivot, Quaternion rotation)
    {
        //Get a direction from the pivot to the point
        Vector3 dir = point - pivot;
        //Rotate vector around pivot
        dir = rotation * dir;
        //Calc the rotated vector
        point = dir + pivot;
        //Return calculated vector
        return point;
    }
}
