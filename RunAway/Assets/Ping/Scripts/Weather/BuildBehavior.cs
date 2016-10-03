using UnityEngine;
using System.Collections;

public class BuildBehavior : MonoBehaviour {

    public float startPos = 1111;
    public float endPos = -1111;
    public float speed = -10;
    public float curPos;
	void Update () {
        curPos = transform.localPosition.x;
        if (curPos < endPos)
        {
            curPos = startPos -  (endPos - curPos);
        }
        curPos += Time.deltaTime * speed;
        transform.localPosition = new Vector3(curPos, transform.localPosition.y, transform.localPosition.z);
    }
}
