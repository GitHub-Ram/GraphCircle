using System;
using CoreAnimation;
using CoreGraphics;
using Foundation;
using UIKit;

namespace graph
{
    public class LoadingSpinnerView : UIView
    {
        private CAShapeLayer _thinCirlce;
        private CAShapeLayer _arcLayer;

        public LoadingSpinnerView(nfloat radius)
        {
            UIColor.Red.SetColor();
            _thinCirlce = new CAShapeLayer();
            _thinCirlce.LineWidth = 1;
            _thinCirlce.Path = UIBezierPath.FromOval(new CoreGraphics.CGRect(0, 0, radius * 2, radius * 2)).CGPath;
            _thinCirlce.StrokeColor = UIColor.Red.CGColor;
            _thinCirlce.FillColor = UIColor.Clear.CGColor;
            Layer.AddSublayer(_thinCirlce);

            UIColor.Blue.SetColor();
            UIBezierPath arcPath = new UIBezierPath();
            arcPath.LineWidth = 4;
            arcPath.LineCapStyle = CGLineCap.Round;
            arcPath.LineJoinStyle = CGLineJoin.Round;
            arcPath.AddArc(new CoreGraphics.CGPoint(radius, radius), radius, 0, 2 * 3.14f, true);

            _arcLayer = new CAShapeLayer();
            _arcLayer.Path = arcPath.CGPath;
            _arcLayer.StrokeColor = UIColor.Blue.CGColor;
            _arcLayer.FillColor = UIColor.Clear.CGColor;
            _arcLayer.LineWidth = 4;
            _arcLayer.StrokeStart = 0;
            _arcLayer.StrokeEnd = 1;

            if (_arcLayer.SuperLayer != null)
            {
                _arcLayer.RemoveAllAnimations();
                _arcLayer.RemoveFromSuperLayer();
            }
        }

        public void StartAnimation()
        {
            Layer.AddSublayer(_arcLayer);

            CABasicAnimation animation = new CABasicAnimation();
            animation.KeyPath = "strokeEnd";
            animation.Duration = 1;
            animation.From = NSNumber.FromFloat(0);
            animation.To = NSNumber.FromFloat(1);
            _arcLayer.AddAnimation(animation, null);
        }

        public void StopAnimation()
        {
            _arcLayer.RemoveAllAnimations();
            _arcLayer.RemoveFromSuperLayer();
        }
    }
}
