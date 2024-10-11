using UnityEngine;

public class VillageCutsceneCam : MonoBehaviour
{
    private int speedCamera = 6;
    private int distance;

    private bool firstMove;
    private bool secondMove;
    private bool thirdMove;
    private float Xpos;
    private float Zpos;

    private void Start()
    {
        Xpos = transform.position.x;
        Zpos = transform.position.z;
    }

    void Update()
    {
        CameraMovement();
    }

    private void CameraMovement()
    {
        //transform.LookAt(new Vector3(boss.position.x, transform.position.y, boss.position.z) - new Vector3(transform.position.x,0, transform.position.z));
        if (!firstMove)
        {
            transform.position += transform.right * Time.deltaTime * speedCamera;
            if (Xpos + 27 < transform.position.x)
            {
                firstMove = true;
            }
        }
        else if (!secondMove)
        {
            transform.position += transform.forward * Time.deltaTime * speedCamera;
            if (Zpos + 15 < transform.position.z)
            {
                secondMove = true;
            }
        }
        else if (!thirdMove)
        {
            transform.Rotate(Vector3.up, 10 * Time.deltaTime * speedCamera);
        }
    }
}
