using UnityEngine;
using System.Collections;

public class BadTVEffect : MonoBehaviour {

	public bool active = true;
	public bool on = false;

	[Range(0.1f, 10f)]
	public float thickDistort = 3f;

	[Range(0.1f, 10f)]
	public float fineDistort = 1f;

	private float timeElapsed;

	public Material material;


	void OnRenderImage(RenderTexture src, RenderTexture dest)
	{
		if(on)
		{
			Graphics.Blit(src, dest, material);
		}
		else
		{
			Graphics.Blit(src, dest);
		}
	}


	void Update()
	{
		if (Input.GetKeyDown(KeyCode.C))
		{
			active = !active;
		}

		if (active)
		{
			timeElapsed += Time.deltaTime;
			if (timeElapsed > 0.35 && on)
				on = false;

			if (timeElapsed > 1.5)
			{
				if (Random.Range(0, 5) >= 4)
					on = true;
				timeElapsed = 0;
			}
		}

		if (on)
		{
			material.SetFloat("_ThickDistort", thickDistort);
			material.SetFloat("_FineDistort", fineDistort);
		}
	}
}