using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/* Just a quick something so the background
 * is doing something rather than just
 * being completely static
 * 
 */

public class BackgroundScrolling : MonoBehaviour
{
    public float scrollSpeed;
    Vector2 offset;
    public Material mat;

    // Start is called before the first frame update
    void Start()
    {
        mat = GetComponent<Renderer>().material;
        offset = new Vector2(0, scrollSpeed);

    }

    // Update is called once per frame
    void Update()
    {
        mat.mainTextureOffset += offset * Time.deltaTime;       
    }
}
