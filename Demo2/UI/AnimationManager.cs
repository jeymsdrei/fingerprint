using System;
using System.Drawing;
using System.Windows.Forms;

namespace Demo.UI
{
    public class AnimationManager
    {
        private Timer _timer;
        private Control _target;
        private int _startX;
        private int _targetX;
        private int _startWidth;
        private int _targetWidth;
        private float _progress;
        private float _duration;
        private Action _onComplete;
        private bool _isRunning;
        private AnimationType _currentType;

        public enum AnimationType
        {
            SlideHorizontal,
            SlideVertical,
            ResizeWidth,
            FadeIn,
            FadeOut
        }

        public AnimationManager()
        {
            _timer = new Timer();
            _timer.Interval = 16;
            _timer.Tick += OnTick;
        }

        public bool IsRunning
        {
            get { return _isRunning; }
        }

        public void AnimateSlide(Control target, int startX, int endX)
        {
            AnimateSlide(target, startX, endX, 300f, null);
        }

        public void AnimateSlide(Control target, int startX, int endX, float durationMs)
        {
            AnimateSlide(target, startX, endX, durationMs, null);
        }

        public void AnimateSlide(Control target, int startX, int endX, float durationMs, Action onComplete)
        {
            _currentType = AnimationType.SlideHorizontal;
            _target = target;
            _startX = startX;
            _targetX = endX;
            _progress = 0f;
            _duration = durationMs;
            _onComplete = onComplete;
            _isRunning = true;
            _timer.Start();
        }

        public void AnimateSlideVertical(Control target, int startY, int endY)
        {
            AnimateSlideVertical(target, startY, endY, 300f, null);
        }

        public void AnimateSlideVertical(Control target, int startY, int endY, float durationMs)
        {
            AnimateSlideVertical(target, startY, endY, durationMs, null);
        }

        public void AnimateSlideVertical(Control target, int startY, int endY, float durationMs, Action onComplete)
        {
            _currentType = AnimationType.SlideVertical;
            _target = target;
            _startX = startY;
            _targetX = endY;
            _progress = 0f;
            _duration = durationMs;
            _onComplete = onComplete;
            _isRunning = true;
            _timer.Start();
        }

        public void AnimateResize(Control target, int startWidth, int endWidth)
        {
            AnimateResize(target, startWidth, endWidth, 300f, null);
        }

        public void AnimateResize(Control target, int startWidth, int endWidth, float durationMs)
        {
            AnimateResize(target, startWidth, endWidth, durationMs, null);
        }

        public void AnimateResize(Control target, int startWidth, int endWidth, float durationMs, Action onComplete)
        {
            _currentType = AnimationType.ResizeWidth;
            _target = target;
            _startWidth = startWidth;
            _targetWidth = endWidth;
            _progress = 0f;
            _duration = durationMs;
            _onComplete = onComplete;
            _isRunning = true;
            _timer.Start();
        }

        public void Stop()
        {
            _timer.Stop();
            _isRunning = false;
        }

        private void OnTick(object sender, EventArgs e)
        {
            if (_target == null || _target.IsDisposed)
            {
                Stop();
                return;
            }

            _progress += (float)_timer.Interval / _duration;

            if (_progress >= 1f)
            {
                _progress = 1f;
                _timer.Stop();
                _isRunning = false;
            }

            float eased = EaseInOutQuad(_progress);

            switch (_currentType)
            {
                case AnimationType.SlideHorizontal:
                {
                    int x = (int)(_startX + (_targetX - _startX) * eased);
                    _target.Left = x;
                    break;
                }
                case AnimationType.SlideVertical:
                {
                    int y = (int)(_startX + (_targetX - _startX) * eased);
                    _target.Top = y;
                    break;
                }
                case AnimationType.ResizeWidth:
                {
                    int w = (int)(_startWidth + (_targetWidth - _startWidth) * eased);
                    _target.Width = w;
                    break;
                }
            }

            if (!_isRunning)
            {
                if (_onComplete != null)
                    _onComplete();
            }
        }

        private float EaseInOutQuad(float t)
        {
            if (t < 0.5f)
                return 2f * t * t;
            return -1f + (4f - 2f * t) * t;
        }
    }
}
