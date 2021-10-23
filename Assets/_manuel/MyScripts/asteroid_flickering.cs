using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class asteroid_flickering : MonoBehaviour {
    // public Color c1;
    // public Color c2;
    public float cycleHz = 5; // Hz, the mesurement of cycles.
    [SerializeField] private bool oddeven;
    private SpriteRenderer _spriteRenderer;
	private int updateCounter;
    private bool swap;
    private TouchScreenKeyboard keyboard;

    void Awake() {
    	_spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        _spriteRenderer.enabled = true;
    }

    void Start() {
    	// _spriteRenderer.color = c1;
    }

    void Update () {
		// if (alwaysOn) 
        MakeFlicker();





	}

    public void MakeFlicker() {

		// old equation (I was making my own time.time for some reason)
		//dtime += Time.deltaTime;
		//float wave = Mathf.Sin( (dtime * 2.0f * Mathf.PI) * cycleHz);

        _spriteRenderer.enabled = oddeven;

	
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