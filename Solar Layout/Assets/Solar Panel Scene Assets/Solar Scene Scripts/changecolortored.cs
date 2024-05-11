using UnityEngine;

public class changecolortored : MonoBehaviour
{
    public Renderer rail;
    public GameObject cube;
    [SerializeField] private Color newColor;
    // Start is called before the first frame update
    void Start()
    {
        rail = cube.GetComponent<Renderer>();
    }
    public void ChangeMaterial()
    {
        rail.material.color = newColor;
    }
}
