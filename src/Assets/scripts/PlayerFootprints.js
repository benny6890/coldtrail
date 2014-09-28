//------------------------------//
//  PlayerFootprints.js         //
//  Written by Alucard Jay      //
//  6/19/2013                   //
//------------------------------//

#pragma strict

public var footprints : Footprints;

public var footprintSpacing : float = 2.0; // distance between each footprint

private var lastPos : Vector3 = Vector3.zero;


function Start() 
{
	lastPos = transform.position;
	
	if ( !footprints )
	{
		footprints = GameObject.Find( "Footprints" ).GetComponent( Footprints );
	}
}


function Update() 
{
	var distFromLastFootprint : float = ( lastPos - transform.position ).sqrMagnitude;
	
	if ( distFromLastFootprint > footprintSpacing * footprintSpacing )
	{
		// AddFootprint( pos : Vector3, fwd : Vector3, rht : Vector3, footprintType : int )
		//footprints.AddFootprint( transform.position, transform.forward, transform.right, 0 );
		footprints.AddFootprint( transform.position, transform.up, transform.right, Random.Range( 0, 4 ) );
		
		lastPos = transform.position;
	}
}
