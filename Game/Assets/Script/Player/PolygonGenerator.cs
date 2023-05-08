using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))]
public class PolygonGenerator : MonoBehaviour
{
	[SerializeField][Range(3, 100)]
	public	int				polygonPoints = 3;	// 다각형 점 개수 (3 ~ 100개)
	[SerializeField][Min(0.1f)]
	private	float			outerRadius = 3;	// 다각형의 원점부터 외곽 둘레까지의 반지름 (최소 값 0.1)
	[SerializeField][Min(0)]
	private	float			innerRadius;		// 다각형 내부가 뚫려있을 때 원점부터 뚫린 외곽까지의 반지름
	[SerializeField][Min(1)]
	private	int				repeatCount = 1;	// 텍스처 반복 횟수

	private	Mesh			mesh;
	private	Vector3[]		vertices;			// 다각형의 정점 정보 배열
	private	int[]			indices;			// 정점을 잇는 폴리곤 정보 배열
	private	Vector2[]		uv;					// 이미지 출력을 위한 각 정점의 uv 정보 배열

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
	/// 새로운 바 모양을 그림
	/// </summary>
	public void Draw(int polygonPoints)
	{
		if (polygonPoints < 3) return;
		if (polygonPoints > 8) return;
		DrawFilled(polygonPoints, outerRadius);
	}

	private void DrawFilled(int sides, float radius)
	{
		// 정점 정보
		vertices = GetCircumferencePoints(sides, radius);
		// 정점을 잇는 폴리곤 정보
		indices	 = DrawFilledIndices(vertices);
		// 각 정점의 uv 정보
		uv		 = GetUVPoints(vertices, radius, repeatCount);
		// 메시 생성
		GeneratePolygon(vertices, indices, uv);
		
		// 정점 정보를 바탕으로 충돌 범위 생성
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
		// 바깥쪽 둘레의 점 정보
		Vector3[] outerPoints = GetCircumferencePoints(sides, outerRadius);
		// 안쪽 구멍 둘레의 점 정보
		Vector3[] innerPoints = GetCircumferencePoints(sides, innerRadius);

		// 두 개의 배열 정보를 저장하기 위한 리스트
		List<Vector3> points = new List<Vector3>();
		points.AddRange(outerPoints);
		points.AddRange(innerPoints);

		// 정점 정보
		vertices = points.ToArray();
		// 정점을 잇는 폴리곤 정보
		indices	 = DrawHollowIndices(sides);
		// 각 정점의 uv 정보
		uv		 = GetUVPoints(vertices, outerRadius, repeatCount);
		// 메시 생성
		GeneratePolygon(vertices, indices, uv);
		
		// 정점 정보를 바탕으로 충돌 범위 생성
		List<Vector2> edgePoints = new List<Vector2>();
		edgePoints.AddRange(GetEdgePoints(outerPoints));	// 바깥쪽 둘레 충돌 범위
		edgePoints.AddRange(GetEdgePoints(innerPoints));	// 안쪽 구멍 둘레 충돌 범위
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
		// 점, 반지름 정보에 따라 Update()에서
		// 지속적으로 업데이트하기 떄문에 기존 mesh 정보를 초기화
		mesh.Clear();
		// 정점, 폴리곤, uv 설정
		mesh.vertices	= vertices;
		mesh.triangles	= indices;
		mesh.uv			= uv;
		// Bounds, Normal 재연산
		mesh.RecalculateBounds();
		mesh.RecalculateNormals();
	}

	/// <summary>
	/// 반지름이 radius인 원의 둘레 위치에 있는 sides 개수만큼의 정점 위치 정보 반환
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
	/// vertices 정점에 해당하는 uv 좌표를 구함
	/// repeatCount 횟수만큼 텍스처를 반복 출력함 (텍스처의 WrapMode가 Repeat여야 함)
	/// </summary>
	private Vector2[] GetUVPoints(Vector3[] vertices, float outerRadius, int repeatCount)
	{
		Vector2[] points = new Vector2[vertices.Length];

		for ( int i = 0; i < vertices.Length; ++ i )
		{
			Vector2 point = Vector2.zero;

			// -outerRadius ~ outerRadius의 값을 0 ~ 1의 값으로 연산
			point.x = vertices[i].x / outerRadius * 0.5f + 0.5f;
			point.y = vertices[i].y / outerRadius * 0.5f + 0.5f;

			// 텍스처를 반복(repeatCount)해서 출력
			// 0 ~ 1의 값을 0 ~ repeatCount의 값으로 연산
			point *= repeatCount;

			points[i] = point;
		}

		return points;
	}
	
	/// <summary>
	/// Vector3[] 정점 정보를 Vector2[] 배열로 Convert하고,
	/// 첫 번째 정점 정보를 추가해 충돌 범위가 닫힌 형태(Close)가 되도록 설정
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

