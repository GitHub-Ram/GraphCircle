// This file has been autogenerated from a class added in the UI designer.

using System;
using System.Collections.Generic;
using CoreAnimation;
using CoreGraphics;
using Foundation;
using UIKit;

namespace graph
{
    public class GraphSpecs
    {
        public Dictionary<UIColor,float> percentageValuesWithColor = new Dictionary<UIColor,float>();
        public int strokeWidth { get; set; }
        public nfloat minimumRadius { get; set; }
        public nfloat space { get; set; }
        public nfloat animDuration { get; set; }
    }

	public partial class CircleGrapgView : UIView
	{
        public GraphSpecs graphSpecs;
        public List<CAShapeLayer> layers = new List<CAShapeLayer>();
		public CircleGrapgView (IntPtr handle) : base (handle)
		{
		}
        public void setGraph(GraphSpecs graphSpecs){
            this.graphSpecs = graphSpecs;
        }
        public override void DrawRect(CoreGraphics.CGRect area, UIViewPrintFormatter formatter)
        {
            base.DrawRect(area, formatter);
        }
        public override void Draw(CoreGraphics.CGRect rect)
        {
            base.Draw(rect);
            var centre = new CGPoint(x:Bounds.Width/2,y:Bounds.Height/2);
            CGPath ppp = new CGPath();
            int count = 0;
            var radiusM = Math.Min(Frame.Width / 2, Frame.Height / 2);
            foreach(KeyValuePair<UIColor,float> specs in graphSpecs.percentageValuesWithColor){
                var radius = radiusM - count*graphSpecs.strokeWidth - count*graphSpecs.space;
                var startAndle = (nfloat)(Math.PI / 2);
                var endAngle = (nfloat)(specs.Value*(Math.PI/50)+Math.PI/2);
                var lineWidth = graphSpecs.strokeWidth;
                var colors = specs.Key;
                var path = new UIBezierPath();
                path.AddArc(centre,(nfloat)radius,startAndle,endAngle,true);
                path.LineWidth = lineWidth;

                var _arcLayer = new CAShapeLayer();
                _arcLayer.Path = path.CGPath;
                _arcLayer.StrokeColor = colors.CGColor;
                _arcLayer.FillColor = UIColor.Clear.CGColor;
                _arcLayer.LineWidth = 8;
                _arcLayer.StrokeStart = 0;
                _arcLayer.StrokeEnd = 1;

                if (_arcLayer.SuperLayer != null)
                {
                    _arcLayer.RemoveAllAnimations();
                    _arcLayer.RemoveFromSuperLayer();
                }
                layers.Add(_arcLayer);
                count++;
            }
            foreach(CAShapeLayer lay in layers){
                Layer.AddSublayer(lay);

                CABasicAnimation animation = new CABasicAnimation();
                animation.KeyPath = "strokeEnd";
                animation.Duration = graphSpecs.animDuration;
                animation.From = NSNumber.FromFloat(0);
                animation.To = NSNumber.FromFloat(1);
                lay.AddAnimation(animation, null);
            }
        }
	}
}
