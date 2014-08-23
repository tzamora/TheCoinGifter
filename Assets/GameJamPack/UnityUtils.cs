using UnityEngine;
using System.Collections;
using System;

public class UnityUtils 
{
	public static IEnumerator LerpAction(float duration, Action<float> IntervalHandler)
	{
		float i = 0f;
		
		float rate = 1f / duration;
		
		float durationSinceStart = 0f;
		
		while(i < 1)
		{
			durationSinceStart += Time.deltaTime;
			
			i += Time.deltaTime * rate;
			
			if(IntervalHandler != null)
			{
				IntervalHandler(i);
			}
			
			yield return null;
		}
	}
}
