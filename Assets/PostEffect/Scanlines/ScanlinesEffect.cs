using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScanlinesEffect : MonoBehaviour {

	public bool on = false;

	[Range(0, 1)]
	public int grayscale = 0;

	[Range(100, 1000)]
	public int amount = 100;

	[Range(0, 2f)]
	public float strength = 0.35f;

	[Range(0, 2f)]
	public float noise = 0.5f;

	[Range(0f, 10f)]
	public float speed = 7f;



	public Material material;

	private float timeElapsed;
	private bool up = true;


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
		// DESACTIVAR / ACTIVAR
        if (Input.GetKeyDown(KeyCode.C))
        {
			on = !on;
        }

		// Rayas en movimiento
		timeElapsed += Time.deltaTime;
		if (timeElapsed > 1)
        {
			if (Random.Range(0, 5) >= 2)
				up = true;
			else
				up = false;
			timeElapsed = 0;
        }

		if (up)
			speed += Time.deltaTime * 0.1f;
		else speed -= Time.deltaTime * 0.15f;
		if (speed > 10f)
			speed = 0;
		if (speed < 0)
			speed = 10f;

		if(on)
		{
			material.SetInt("_Grayscale", grayscale);
			material.SetInt("_Amount", amount);
			material.SetFloat("_Strength", strength);
			material.SetFloat("_Noise", noise);
			material.SetFloat("_Speed", speed);
		}
	}
}
