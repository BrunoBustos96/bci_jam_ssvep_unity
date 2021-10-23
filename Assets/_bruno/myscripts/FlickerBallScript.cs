using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlickerBallScript : MonoBehaviour
{
    public Renderer rend;

    bool oddeven;
    static public float cycleHz=5;
    void Start()
    {
        rend = GetComponent<Renderer>();
        rend.enabled = true;
    }

    // Toggle the Object's visibility each second.
    void Update()
    {
        // Find out whether current second is odd or even
        //bool oddeven = Mathf.FloorToInt(Time.time) % 2 == 0;

        // Enable renderer accordingly
        rend.enabled = oddeven;

        float colorMix = Mathf.InverseLerp(-1f, 1f, Mathf.Sin((Time.time % 10.0f) * Mathf.PI * cycleHz * 2.0f));

		//_spriteRenderer.color = Color.Lerp(c1, c2, colorMix);

		// Count cycles (also used if I want full flashing colours insetad of smooth sin wave)
		if (colorMix > 0.5f) {
			//_spriteRenderer.color = c1;
			if (oddeven) {
				//updateCounter++;
				oddeven = false;
			}
		} else {
			//_spriteRenderer.color = c2;
			oddeven = true;
		}
        SetHz(cycleHz);
    }

    public void SetHz(float newHz) {
        if (newHz >= 0) {
            cycleHz = newHz;
        }
    }

    public void SetHzString(string newHzString) {
        if (newHzString.Length > 0) {
            SetHz(float.Parse(newHzString));
        }
    }
}
