using UnityEngine;

public class PerlinNoise : MonoBehaviour
{
    Renderer renderer;

    public float speedX = 0f;
    public float speedY = 0f;

    public int width = 256;
    public int height = 256;

    public float scale = 20f;

    public float offsetX = 100f;
    public float offsetY = 100f;

    void Start()
    {
        offsetX = Random.Range(0f, 9999f);
        offsetY = Random.Range(0f, 9999f);
    }
    void Update()
    {
        renderer = GetComponent<Renderer>();
        renderer.material.mainTexture = GenerateTexture();
        offsetX += Time.deltaTime * speedX;
        offsetY += Time.deltaTime * speedY;
    }


    Texture2D GenerateTexture()
    {
        Texture2D texture = new Texture2D(width, height);

        for(int x = 0; x < width; x++)
        {
            for(int y = 0; y < height; y++)
            {
                Color color = CalculateColor(x, y);
                texture.SetPixel(x, y, color);
            }
        }
        texture.Apply();
        return texture;
    }


    Color CalculateColor(int x, int y)
    {
        float xCoord = (float)x / width * scale+ offsetX;
        float yCoord = (float)y / height * scale + offsetY;
        float sample = Mathf.PerlinNoise(xCoord, yCoord);
        return new Color(sample, sample, sample);
    }
}
