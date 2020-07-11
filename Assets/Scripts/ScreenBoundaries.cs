using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*  Apply this script to anything that
 * needs to stay within the bounds of
 * the screen
 */


public class ScreenBoundaries : MonoBehaviour
{
    public Camera mainCam;
    private Vector3 screenBounds;
    Vector3 viewPos;
    private float objectWidth, objectHeight;

    // Start is called before the first frame update
    void Start()
    {
        screenBounds = mainCam.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, mainCam.transform.position.z));

        objectWidth = transform.GetComponent<SpriteRenderer>().bounds.size.x / 2;
        objectHeight = transform.GetComponent<SpriteRenderer>().bounds.size.y / 2;
    }

    void LateUpdate()
    {
        viewPos = transform.position;

        viewPos.x = Mathf.Clamp(viewPos.x, screenBounds.x * -1 + objectWidth, screenBounds.x - objectWidth);
        viewPos.y = Mathf.Clamp(viewPos.y, screenBounds.y * -1 + objectHeight, screenBounds.y - objectHeight);

        transform.position = viewPos;
    }
}
