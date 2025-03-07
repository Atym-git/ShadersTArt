using UnityEngine;

public class CursorTrack : MonoBehaviour
{
    [SerializeField] private Material _shaderMaterial;
    [SerializeField] private Material _newMaterial;

    private MeshRenderer _meshRenderer;

    private void Start()
    {
        _meshRenderer = GetComponent<MeshRenderer>();
    }

    private void OnMouseEnter()
    {
        _meshRenderer.material = _shaderMaterial;
    }
    private void OnMouseExit()
    {
        _meshRenderer.material = _newMaterial;
    }
}
