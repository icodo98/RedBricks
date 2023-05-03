using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))]
public class PolygonGenerator : MonoBehaviour
{
	[SerializeField][Range(3, 100)]
	public	int				polygonPoints = 3;	// �ٰ��� �� ���� (3 ~ 100��)
	[SerializeField][Min(0.1f)]
	private	float			outerRadius = 3;	// �ٰ����� �������� �ܰ� �ѷ������� ������ (�ּ� �� 0.1)
	[SerializeField][Min(0)]
	private	float			innerRadius;		// �ٰ��� ���ΰ� �շ����� �� �������� �ո� �ܰ������� ������
	[SerializeField][Min(1)]
	private	int				repeatCount = 1;	// �ؽ�ó �ݺ� Ƚ��

	private	Mesh			mesh;
	private	Vector3[]		vertices;			// �ٰ����� ���� ���� �迭
	private	int[]			indices;			// ������ �մ� ������ ���� �迭
	private	Vector2[]		uv;					// �̹��� ����� ���� �� ������ uv ���� �迭

	private	EdgeCollider2D	edgeCollider2D;

	private void Awake()
	{
		mesh = new Mesh();

		MeshFilter meshFilter = GetComponent<MeshFilter>();
		meshFilter.mesh	= mesh;

		edgeCollider2D = GetComponent<EdgeCollider2D>();
		Draw(4);
	}

	/// <summary>
	/// ���ο� �� ����� �׸�
	/// </summary>
	public void Draw(int polygonPoints)
	{
		if (polygonPoints < 3) return;
		if (polygonPoints > 8) return;
		DrawFilled(polygonPoints, outerRadius);
	}

	private void DrawFilled(int sides, float radius)
	{
		// ���� ����
		vertices = GetCircumferencePoints(sides, radius);
		// ������ �մ� ������ ����
		indices	 = DrawFilledIndices(vertices);
		// �� ������ uv ����
		uv		 = GetUVPoints(vertices, radius, repeatCount);
		// �޽� ����
		GeneratePolygon(vertices, indices, uv);
		
		// ���� ������ �������� �浹 ���� ����
		edgeCollider2D.points = GetEdgePoints(vertices);
	}

	private int[] DrawFilledIndices(Vector3[] vertices)
	{
		int			triangleCount	= vertices.Length-2;
		List<int>	indices			= new List<int>();

		for ( int i = 0; i < triangleCount; ++ i )
		{
			indices.Add(0);
			indices.Add(i+2);
			indices.Add(i+1);
		}

		return indices.ToArray();
	}

	private void DrawHollow(int sides, float outerRadius, float innerRadius)
	{
		// �ٱ��� �ѷ��� �� ����
		Vector3[] outerPoints = GetCircumferencePoints(sides, outerRadius);
		// ���� ���� �ѷ��� �� ����
		Vector3[] innerPoints = GetCircumferencePoints(sides, innerRadius);

		// �� ���� �迭 ������ �����ϱ� ���� ����Ʈ
		List<Vector3> points = new List<Vector3>();
		points.AddRange(outerPoints);
		points.AddRange(innerPoints);

		// ���� ����
		vertices = points.ToArray();
		// ������ �մ� ������ ����
		indices	 = DrawHollowIndices(sides);
		// �� ������ uv ����
		uv		 = GetUVPoints(vertices, outerRadius, repeatCount);
		// �޽� ����
		GeneratePolygon(vertices, indices, uv);
		
		// ���� ������ �������� �浹 ���� ����
		List<Vector2> edgePoints = new List<Vector2>();
		edgePoints.AddRange(GetEdgePoints(outerPoints));	// �ٱ��� �ѷ� �浹 ����
		edgePoints.AddRange(GetEdgePoints(innerPoints));	// ���� ���� �ѷ� �浹 ����
		edgeCollider2D.points = edgePoints.ToArray();
	}

	private int[] DrawHollowIndices(int sides)
	{
		List<int> indices = new List<int>();

		for ( int i = 0; i < sides; ++ i )
		{
			int outerIndex = i;
			int innerIndex = i+sides;

			indices.Add(outerIndex);
			indices.Add(innerIndex);
			indices.Add((outerIndex+1)%sides);

			indices.Add(innerIndex);
			indices.Add(sides+((innerIndex+1)%sides));
			indices.Add((outerIndex+1)%sides);
		}

		return indices.ToArray();
	}

	private void GeneratePolygon(Vector3[] vertices, int[] indices, Vector2[] uv)
	{
		// ��, ������ ������ ���� Update()����
		// ���������� ������Ʈ�ϱ� ������ ���� mesh ������ �ʱ�ȭ
		mesh.Clear();
		// ����, ������, uv ����
		mesh.vertices	= vertices;
		mesh.triangles	= indices;
		mesh.uv			= uv;
		// Bounds, Normal �翬��
		mesh.RecalculateBounds();
		mesh.RecalculateNormals();
	}

	/// <summary>
	/// �������� radius�� ���� �ѷ� ��ġ�� �ִ� sides ������ŭ�� ���� ��ġ ���� ��ȯ
	/// </summary>
	private Vector3[] GetCircumferencePoints(int sides, float radius)
	{
		Vector3[]	points		 = new Vector3[sides];
		float		anglePerStep = 2 * Mathf.PI * ((float)1/sides);
        float		quaterAngle = Mathf.PI / 2f;
        if (sides == 4) quaterAngle = Mathf.PI / 4f;
		for ( int i = 0; i < sides; ++ i )
		{
			Vector2	point = Vector2.zero;
			float	angle = anglePerStep * i;
			
			point.x = Mathf.Cos(angle + quaterAngle) * radius;
			point.y = Mathf.Sin(angle + quaterAngle) * radius;

			points[i] = point;
		}

		return points;
	}

	/// <summary>
	/// vertices ������ �ش��ϴ� uv ��ǥ�� ����
	/// repeatCount Ƚ����ŭ �ؽ�ó�� �ݺ� ����� (�ؽ�ó�� WrapMode�� Repeat���� ��)
	/// </summary>
	private Vector2[] GetUVPoints(Vector3[] vertices, float outerRadius, int repeatCount)
	{
		Vector2[] points = new Vector2[vertices.Length];

		for ( int i = 0; i < vertices.Length; ++ i )
		{
			Vector2 point = Vector2.zero;

			// -outerRadius ~ outerRadius�� ���� 0 ~ 1�� ������ ����
			point.x = vertices[i].x / outerRadius * 0.5f + 0.5f;
			point.y = vertices[i].y / outerRadius * 0.5f + 0.5f;

			// �ؽ�ó�� �ݺ�(repeatCount)�ؼ� ���
			// 0 ~ 1�� ���� 0 ~ repeatCount�� ������ ����
			point *= repeatCount;

			points[i] = point;
		}

		return points;
	}
	
	/// <summary>
	/// Vector3[] ���� ������ Vector2[] �迭�� Convert�ϰ�,
	/// ù ��° ���� ������ �߰��� �浹 ������ ���� ����(Close)�� �ǵ��� ����
	/// </summary>
	private Vector2[] GetEdgePoints(Vector3[] vertices)
	{
		Vector2[] points = new Vector2[vertices.Length+1];

		for ( int i = 0; i < vertices.Length; ++ i )
		{
			points[i] = vertices[i];
		}

		points[points.Length-1] = vertices[0];

		return points;
	}
}

