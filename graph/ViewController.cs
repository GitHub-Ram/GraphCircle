using System;
using System.Collections.Generic;
using UIKit;

namespace graph
{
    public partial class ViewController : UIViewController
    {
        protected ViewController(IntPtr handle) : base(handle)
        {
            // Note: this .ctor should not contain any initialization logic.
        }
        List<GraphSpecs> listSpecs = new List<GraphSpecs>();
        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            Dictionary< UIColor,float> colorandvalue = new Dictionary< UIColor,float>();
            colorandvalue.Add(UIColor.Blue,40);
            colorandvalue.Add(UIColor.Red,60);
            colorandvalue.Add(UIColor.Yellow,90);
            GraphSpecs specs1 = new GraphSpecs
            {
                percentageValuesWithColor = colorandvalue,
                strokeWidth = 8,
                minimumRadius = (nfloat)(View.Bounds.Width * 0.25),
                space = 5,
                animDuration = 0.5f
            };
            circleGraphView.setGraph(specs1);
            Console.WriteLine("View Load");
            //var load = new LoadingSpinnerView(60);
            //View.AddSubview(load);
            //load.StartAnimation();
            // Perform any additional setup after loading the view, typically from a nib.
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }
    }
}
