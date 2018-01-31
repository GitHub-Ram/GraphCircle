// WARNING
//
// This file has been generated automatically by Visual Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using Foundation;
using System.CodeDom.Compiler;

namespace graph
{
	[Register ("ViewController")]
	partial class ViewController
	{
		[Outlet]
        CircleGrapgView circleGraphView { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (circleGraphView != null) {
				circleGraphView.Dispose ();
				circleGraphView = null;
			}
		}
	}
}
