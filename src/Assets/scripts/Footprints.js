//------------------------------//
//  Footprints.js               //
//  Written by Alucard Jay      //
//  6/19/2013                   //
//------------------------------//

#pragma strict
@script RequireComponent( MeshFilter, MeshRenderer )


public var maxFootprints : int = 256; // Maximum number of footprints total handled by one instance of the script.
public var footprintSize : Vector2 = Vector2( 0.4, 0.8 ); // The size of the footprint. Should match the size of the footprint that it is used for. In meters.
public var footprintSpacing : float = 0.3; // the offset for the left or right footprint. In meters.
public var groundOffset : float = 0.02;	// The distance the footprints are places above the surface it is placed upon. In meters.

public var terrainLayer : LayerMask; // the layer of the terrain, so the footprint raycast is only hitting the terrain.


private var mesh : Mesh;

private var vertices : Vector3[];
private var normals : Vector3[];
private var uvs : Vector2[];
private var triangles : int[];

private var footprintCount : int = 0;

private var isLeft : boolean = false;


// Initializes the array holding the footprint sections.
function Awake()
{
	// - Initialize Arrays -
	
	vertices = new Vector3[ maxFootprints * 4 ];
	normals = new Vector3[ maxFootprints * 4 ];
	uvs = new Vector2[ maxFootprints * 4 ];
	triangles = new int[ maxFootprints * 6 ];
	
	// - Initialize Mesh -
	
	if ( GetComponent( MeshFilter ).mesh == null )
	{
		GetComponent( MeshFilter ).mesh = new Mesh();
	}
	
	mesh = GetComponent( MeshFilter ).mesh;
	
	mesh.name = "Footprints_Mesh";
}


// Function called by the Player when adding a footprint. 
// Adds the information needed to create the mesh later. 
public function AddFootprint( pos : Vector3, fwd : Vector3, rht : Vector3, footprintType : int )
{
	// - Calculate the 4 corners -
	
	// foot offset
	var footOffset : float = footprintSpacing;
	
	if ( isLeft )
	{
		footOffset = -footprintSpacing;
	}
	
	var corners : Vector3[] = new Vector3[ 4 ];
	
	// corners = position + left/right offset + forward + right
	corners[ 0 ] = pos + ( rht * footOffset ) + ( fwd * footprintSize.y * 0.5 ) + ( -rht * footprintSize.x * 0.5 ); // Upper Left
	corners[ 1 ] = pos + ( rht * footOffset ) + ( fwd * footprintSize.y * 0.5 ) + ( rht * footprintSize.x * 0.5 ); // Upper Right
	corners[ 2 ] = pos + ( rht * footOffset ) + ( -fwd * footprintSize.y * 0.5 ) + ( -rht * footprintSize.x * 0.5 ); // Lower Left
	corners[ 3 ] = pos + ( rht * footOffset ) + ( -fwd * footprintSize.y * 0.5 ) + ( rht * footprintSize.x * 0.5 ); // Lower Right
	
	
	// raycast to get the position and normal for each corner
	var hit : RaycastHit;
	
	for ( var i : int = 0; i < 4; i ++ )
	{
		var rayPos : Vector3 = corners[ i ];
		rayPos.z = -1000.0;
		
		if ( Physics.Raycast( rayPos, Vector3.forward, hit, 2000.0, terrainLayer ) ) // also add a layermask for the terrain
		{
			var index : int = ( footprintCount * 4 ) + i;
			
			// - Vertex -
			vertices[ index ] = hit.point + ( hit.normal * groundOffset );
			
			// - Normal -
			normals[ index ] = hit.normal;
			
		}
	}
	
	
	// - UVs -
	
	// what type of footprint is being placed
	var uvOffset : Vector2;
	
	switch( footprintType )
	{
		case 1 :
			uvOffset = Vector2( 0.5, 1.0 );
		break;
		
		case 2 :
			uvOffset = Vector2( 0.0, 0.5 );
		break;
		
		case 3 :
			uvOffset = Vector2( 0.5, 0.0 );
		break;
		
		default :
			uvOffset = Vector2( 0.0, 1.0 );
		break;
	}
	
	// is this the left foot or the right foot
	switch( isLeft )
	{
		case true :
			uvs[ ( footprintCount * 4 ) + 0 ] = Vector2( uvOffset.x + 0.5, uvOffset.y );
			uvs[ ( footprintCount * 4 ) + 1 ] = Vector2( uvOffset.x, uvOffset.y );
			uvs[ ( footprintCount * 4 ) + 2 ] = Vector2( uvOffset.x + 0.5, uvOffset.y - 0.5);
			uvs[ ( footprintCount * 4 ) + 3 ] = Vector2( uvOffset.x, uvOffset.y - 0.5 );
			
			isLeft = false;
		break;
		
		case false :
			uvs[ ( footprintCount * 4 ) + 0 ] = Vector2( uvOffset.x, uvOffset.y );
			uvs[ ( footprintCount * 4 ) + 1 ] = Vector2( uvOffset.x + 0.5, uvOffset.y );
			uvs[ ( footprintCount * 4 ) + 2 ] = Vector2( uvOffset.x, uvOffset.y - 0.5 );
			uvs[ ( footprintCount * 4 ) + 3 ] = Vector2( uvOffset.x + 0.5, uvOffset.y - 0.5);
			
			isLeft = true;
		break;
	}
	
	
	
	// - Triangles -
	
	triangles[ ( footprintCount * 6 ) + 0 ] = ( footprintCount * 4 ) + 0;
	triangles[ ( footprintCount * 6 ) + 1 ] = ( footprintCount * 4 ) + 1;
	triangles[ ( footprintCount * 6 ) + 2 ] = ( footprintCount * 4 ) + 2;
	
	triangles[ ( footprintCount * 6 ) + 3 ] = ( footprintCount * 4 ) + 2;
	triangles[ ( footprintCount * 6 ) + 4 ] = ( footprintCount * 4 ) + 1;
	triangles[ ( footprintCount * 6 ) + 5 ] = ( footprintCount * 4 ) + 3;
	
	
	// - Increment counter -
	footprintCount ++;
	
	if ( footprintCount >= maxFootprints )
	{
		footprintCount = 0;
	}
	
	// - update mesh with new info -
	ConstructMesh();
}


function ConstructMesh() 
{
	mesh.Clear();
	
	mesh.vertices = vertices;
	mesh.normals = normals;
	mesh.triangles = triangles;
	mesh.uv = uvs;
}
