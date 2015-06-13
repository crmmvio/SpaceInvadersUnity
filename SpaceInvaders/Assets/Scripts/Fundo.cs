using UnityEngine;
using System.Collections;

public class Fundo : MonoBehaviour
{
	public int materialIndex = 0;
	public Vector2 uvAnimationRate = new Vector2(0.0f, 0.15f);
	public string textureName = "_MainTex";
	Vector2 uvOffset = Vector2.zero;

	void Update() 
	{
		uvOffset += (uvAnimationRate * Time.deltaTime);
		renderer.materials[materialIndex].SetTextureOffset(textureName, uvOffset);
	}
}