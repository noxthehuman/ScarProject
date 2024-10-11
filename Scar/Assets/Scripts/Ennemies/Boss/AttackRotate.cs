using UnityEngine;

public class AttackRotate : MonoBehaviour
{
    private float speedRotation = 300.0f;
    private Transform objectToFollow;

    private void Start()
    {
        objectToFollow = GameObject.FindGameObjectWithTag("boss").transform;   
    }

    private void Update()
    {            
        gameObject.transform.Rotate(Vector3.forward * speedRotation * Time.deltaTime);
        transform.position = objectToFollow.position;
        Destroy(gameObject, 3);
    }

}
