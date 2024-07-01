using UnityEngine;

public class FFT : MonoBehaviour
{
    public int resolution = 64; // �𑜓x
    public float waveScale = 1f; // �g�̃X�P�[��
    public float waveSpeed = 1f; // �g�̑��x
    public float waveHeight = 1f; // �g�̍���
    public float choppiness = 1f; // �g�̗���

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
        // ���b�V���̐���
        mesh = new Mesh();
        GetComponent<MeshFilter>().mesh = mesh;

        // ���_�A�O�p�`�̐���
        int numVertices = resolution * resolution;
        int numTriangles = (resolution - 1) * (resolution - 1) * 6;
        baseVertices = new Vector3[numVertices];
        displacedVertices = new Vector3[numVertices];
        uvs = new Vector2[numVertices];
        int[] triangles = new int[numTriangles];

        // ���_�̔z�u��UV�̐ݒ�
        for (int y = 0, vertexIndex = 0; y < resolution; y++)
        {
            for (int x = 0; x < resolution; x++, vertexIndex++)
            {
                baseVertices[vertexIndex] = new Vector3(x, 0f, y);
                displacedVertices[vertexIndex] = baseVertices[vertexIndex];
                uvs[vertexIndex] = new Vector2(x / (float)(resolution - 1), y / (float)(resolution - 1));
            }
        }

        // �O�p�`�̐ݒ�
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

        // �g�̍X�V
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
        // FFT���g�p���Ĕg�̍������v�Z����
        // ������FFT���������邩�A�K�؂ȃ��C�u�������g�p����K�v������܂��B
        // FFT�̌v�Z���@�ɂ��ẮA���I�Ȓm�����K�v�ł��邽�߁A�����ł͏ȗ����܂��B
        // FFT�̌v�Z���ʂ���g�̍������擾���܂��B

        return waveHeight;
    }
}

