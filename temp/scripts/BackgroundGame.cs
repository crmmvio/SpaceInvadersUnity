Using  UnityEngine;

public class MoveOffSet : MonoBehaviour
{
	public float scrollSpeed = 0.5f;
	public Vector2 direction = -Vector2.right;
	public Renderer rend;

	void Awake()
	{
		rend = GetComponent<Renderer>();		
	}

	void Update()
	{
		rend.material.SetTextureOffset("_MainTex", direction * scrollSpeed * Time.time);
	}
}