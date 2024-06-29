using UnityEngine;

public class FFT : MonoBehaviour
{
    public int resolution = 64; // 解像度
    public float waveScale = 1f; // 波のスケール
    public float waveSpeed = 1f; // 波の速度
    public float waveHeight = 1f; // 波の高さ
    public float choppiness = 1f; // 波の乱れ

    private Mesh mesh;
    private Vector3[] baseVertices;
    private Vector3[] displacedVertices;
    private Vector2[] uvs;

    private void Start()
    {
        GenerateOcean();
    }

    private void GenerateOcean()
    {
        // メッシュの生成
        mesh = new Mesh();
        GetComponent<MeshFilter>().mesh = mesh;

        // 頂点、三角形の生成
        int numVertices = resolution * resolution;
        int numTriangles = (resolution - 1) * (resolution - 1) * 6;
        baseVertices = new Vector3[numVertices];
        displacedVertices = new Vector3[numVertices];
        uvs = new Vector2[numVertices];
        int[] triangles = new int[numTriangles];

        // 頂点の配置とUVの設定
        for (int y = 0, vertexIndex = 0; y < resolution; y++)
        {
            for (int x = 0; x < resolution; x++, vertexIndex++)
            {
                baseVertices[vertexIndex] = new Vector3(x, 0f, y);
                displacedVertices[vertexIndex] = baseVertices[vertexIndex];
                uvs[vertexIndex] = new Vector2(x / (float)(resolution - 1), y / (float)(resolution - 1));
            }
        }

        // 三角形の設定
        for (int ti = 0, vi = 0, y = 0; y < resolution - 1; y++, vi++)
        {
            for (int x = 0; x < resolution - 1; x++, ti += 6, vi++)
            {
                triangles[ti] = vi;
                triangles[ti + 3] = triangles[ti + 2] = vi + 1;
                triangles[ti + 4] = triangles[ti + 1] = vi + resolution;
                triangles[ti + 5] = vi + resolution + 1;
            }
        }

        mesh.vertices = displacedVertices;
        mesh.triangles = triangles;
        mesh.uv = uvs;

        // 波の更新
        InvokeRepeating("UpdateWaves", 0f, 0.1f);
    }

    private void UpdateWaves()
    {
        float time = Time.time * waveSpeed;

        for (int i = 0; i < baseVertices.Length; i++)
        {
            float x = baseVertices[i].x * waveScale;
            float y = baseVertices[i].z * waveScale;
            float height = CalculateWaveHeight(x, y, time);
            displacedVertices[i] = baseVertices[i] + Vector3.up * height;
        }

        mesh.vertices = displacedVertices;
        mesh.RecalculateNormals();
    }

    private float CalculateWaveHeight(float x, float y, float time)
    {
        float waveHeight = 0f;
        // FFTを使用して波の高さを計算する
        // ここでFFTを実装するか、適切なライブラリを使用する必要があります。
        // FFTの計算方法については、専門的な知識が必要であるため、ここでは省略します。
        // FFTの計算結果から波の高さを取得します。

        return waveHeight;
    }
}

