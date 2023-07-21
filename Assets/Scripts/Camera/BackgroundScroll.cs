using UnityEngine;

public class BackgroundScroll : MonoBehaviour
{
    [SerializeField] private MeshRenderer _mesh;
    [SerializeField] private float _scrollSpeed;

    // Update is called once per frame
    void Update()
    {
        _mesh.material.mainTextureOffset += new Vector2(_scrollSpeed * Time.deltaTime, 0);
    }
}
