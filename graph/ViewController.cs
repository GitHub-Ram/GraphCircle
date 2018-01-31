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
            Dictionary<int, UIColor> colorandvalue = new Dictionary<int, UIColor>();
            colorandvalue.Add(40,UIColor.Blue);
            colorandvalue.Add(60, UIColor.Red);
            colorandvalue.Add(90, UIColor.Yellow);
            GraphSpecs specs1 = new GraphSpecs
            {
                percentageValuesWithColor = colorandvalue,
                strokeWidth = 8,
                minimumRadius = (nfloat)(View.Bounds.Width * 0.25),
                space = 5
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
