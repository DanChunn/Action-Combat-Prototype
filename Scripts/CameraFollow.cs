using UnityEngine;
using System.Collections;


/*
 * Used to have the camera follow the player and have it create space on the screen
 * based on the location of the cursor and character.
 * Attach to the camera. Attach player to script.
 */
public class CameraFollow : MonoBehaviour {

    //true to enable smooth, false to disable smoothing
    bool smooth = true;

    //smoothing speed
    float smoothSpeed = 0.064f;

    //multiplies the space created by the camera
    float offsetMultiplyer = 10;


    /*Do not change*/
    Player target;
    Vector3 targetPos;
    Vector3 cameraOffsetPos;
    Vector3 mousePos;

    // Use this for initialization
    void Start () {
        SetDefaultTarget();
        cameraOffsetPos = transform.localPosition;
        Cursor.lockState = CursorLockMode.Confined; // keep confined in the game window
    }

    void FixedUpdate () {
        Vector3 mousePos = Camera.main.ScreenToViewportPoint(Input.mousePosition);
        mousePos -= new Vector3(0.5f, 0.5f, 0.0f);
        //maybe multiply x by 2 ?
        targetPos = new Vector3(cameraOffsetPos.x + target.transform.position.x + (mousePos.x  * offsetMultiplyer),
                        cameraOffsetPos.y,
                        cameraOffsetPos.z + target.transform.position.z + (mousePos.y * offsetMultiplyer));
        if (smooth)
        {
            transform.position = Vector3.Lerp(transform.position, targetPos, smoothSpeed);
        }
        else
        {
            transform.position = targetPos;
        }
    }

    void LateUpdate()
    {
        //should be camera movement, but getting choppiness;
    }

    public void SetTarget(Player _player)
    {
        target = _player;
    }

    public void SetDefaultTarget()
    {
        if(target == null)
        {
            target = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        }
    }

}
