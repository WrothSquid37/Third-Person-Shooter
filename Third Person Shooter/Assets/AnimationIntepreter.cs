using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationIntepreter : MonoBehaviour
{
    public MoveClip clip;
	public bool fromPosition;

    public void StartAnimation(string dir)
    {
        StartCoroutine(moveClipInt(dir));
    }

    IEnumerator moveClipInt(string direction)
    {

		if (fromPosition)
		{
			Vector3 offset = o
		}

        float scaledTime = Time.deltaTime / clip.time;

		float t = 0;
		
		if (direction == "forward")
		{
			t = 0;
			while (t <= 1)
			{
				
				Vector3 desiredPosition = Vector3.Lerp(clip.startPos, clip.endPos, t);
				transform.position = desiredPosition;
				t += scaledTime;
				t -= 0.0001f;
				yield return new WaitForSeconds(scaledTime);
			}
		}

		if (direction == "reverse")
		{
			t = 1;
			while (t >= 0)
			{
				Vector3 desiredPosition = Vector3.Lerp(clip.startPos, clip.endPos, t);
				transform.position = desiredPosition;
				t -= scaledTime;
				t += 0.0001f;
				yield return new WaitForSeconds(scaledTime);
			}
		}

		yield return null;

    }

}
