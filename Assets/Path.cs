using UnityEngine;
using System.Collections;

public class Path  {

	public Vector2 start{ get; private set;}
	public Vector2 end{ get; private set;}
	public float time{ get; private set;}

	public Path(Vector2 start,Vector2 end, float time) {
				this.start = start;
				this.end = end;
				this.time = time;
		}


	public  bool LineIntersection( Vector2 p1,Vector2 p2, ref Vector2 intersection )
	{
		
		float Ax,Bx,Cx,Ay,By,Cy,d,e,f,num/*,offset*/;
		float x1lo,x1hi,y1lo,y1hi;
		
		Ax = p2.x-p1.x;
		Bx = start.x-end.x;
		
		// X bound box test/
		
		if(Ax<0) {
			x1lo=p2.x; x1hi=p1.x;
			} else {
			x1hi=p2.x; x1lo=p1.x;
		}
		
		if(Bx>0) {
			if(x1hi < end.x || start.x < x1lo) return false;
			} else {
			if(x1hi < start.x || end.x < x1lo) return false;
		}
		
		Ay = p2.y-p1.y;
		By = start.y-end.y;

		// Y bound box test//
		
		if(Ay<0) {                  
			y1lo=p2.y; y1hi=p1.y;
			} else {
			y1hi=p2.y; y1lo=p1.y;
		}

		if(By>0) {
			if(y1hi < end.y || start.y < y1lo) return false;
			} else {
			if(y1hi < start.y || end.y < y1lo) return false;
		}
		

		Cx = p1.x-start.x;
		Cy = p1.y-start.y;
		
		d = By*Cx - Bx*Cy;  // alpha numerator//
		f = Ay*Bx - Ax*By;  // both denominator//

		// alpha tests//
		
		if(f>0) {
			if(d<0 || d>f) return false;
			} else {
			if(d>0 || d<f) return false;
		}

		e = Ax*Cy - Ay*Cx;  // beta numerator//

		// beta tests //
		
		if(f>0) {                          
			if(e<0 || e>f) return false;
			} else {
			if(e>0 || e<f) return false;
		}

		// check if they are parallel
		if(f==0) return false;
		
		// compute intersection coordinates //
		num = d*Ax; // numerator //
		
		//    offset = same_sign(num,f) ? f*0.5f : -f*0.5f;   // round direction //
		//    intersection.x = p1.x + (num+offset) / f;
		intersection.x = p1.x + num / f;
		num = d*Ay;
		
		//    offset = same_sign(num,f) ? f*0.5f : -f*0.5f;
		//    intersection.y = p1.y + (num+offset) / f;
		intersection.y = p1.y + num / f;

		return true;
		
	}




}
