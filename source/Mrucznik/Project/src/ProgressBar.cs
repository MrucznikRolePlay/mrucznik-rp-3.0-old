using System;
using SampSharp.GameMode;
using SampSharp.GameMode.Display;
using SampSharp.GameMode.Pools;
using SampSharp.GameMode.SAMP;
using SampSharp.GameMode.World;
using SampSharp.GameMode.Tools;

namespace Mrucznik
{
    class ProgressBar : Pool<ProgressBar>
    {
        private readonly PlayerTextDraw _back;
        private readonly PlayerTextDraw _fill;
        private readonly PlayerTextDraw _main;
        private float _value;
        private float _max;

        public ProgressBar(GtaPlayer player, float x, float y, float value, Color color = default(Color),
            float width = 55.5f, float height = 3.2f,
            float max = 100.0f, ProgressBarDirection direction = ProgressBarDirection.Right)
        {
            X = x;
            Y = y;
            _value = value;
            Width = width;
            Height = height;
            Color = color;
            _max = max;
            Direction = direction;

            if (player == null) throw new ArgumentNullException("player");

            switch (direction)
            {
                case ProgressBarDirection.Right:
                    _back = new PlayerTextDraw(player, new Vector2(x, y), "_")
                    {
                        UseBox = true,
                        Width = x + width - 4.0f,
                        Height = 0.0f,
                        LetterWidth = 1.0f,
                        LetterHeight = height / 10,
                        BoxColor = 0x00000000 | (color & 0x000000FF)
                    };

                    _fill = new PlayerTextDraw(player, new Vector2(x + 1.2f, y + 2.15f), "_")
                    {
                        UseBox = true,
                        Width = x + width - 5.5f,
                        Height = 0.0f,
                        LetterWidth = 1.0f,
                        LetterHeight = height / 10 - 0.35f,
                        BoxColor = (int)((color & 0xFFFFFF00) | (0x66 & ((color & 0x000000FF) / 2)))
                    };

                    _main = new PlayerTextDraw(player, new Vector2(x + 1.2f, y + 2.15f), "_")
                    {
                        UseBox = true,
                        Width = CalculatePercentage(),
                        Height = 0.0f,
                        LetterWidth = 1.0f,
                        LetterHeight = height / 10 - 0.35f,
                        BoxColor = color
                    };
                    break;
                case ProgressBarDirection.Left:
                    _back = new PlayerTextDraw(player, new Vector2(x, y), "_")
                    {
                        UseBox = true,
                        Width = x - width - 4.0f,
                        Height = 0.0f,
                        LetterWidth = 1.0f,
                        LetterHeight = height / 10,
                        BoxColor = 0x00000000 | (color & 0x000000FF)
                    };

                    _fill = new PlayerTextDraw(player, new Vector2(x - 1.2f, y + 2.15f), "_")
                    {
                        UseBox = true,
                        Width = x - width - 2.5f,
                        Height = 0.0f,
                        LetterWidth = 1.0f,
                        LetterHeight = height / 10 - 0.35f,
                        BoxColor = (int)((color & 0xFFFFFF00) | (0x66 & ((color & 0x000000FF) / 2)))
                    };

                    _main = new PlayerTextDraw(player, new Vector2(x - 1.2f, y + 2.15f), "_")
                    {
                        UseBox = true,
                        Width = CalculatePercentage(),
                        Height = 0.0f,
                        LetterWidth = 1.0f,
                        LetterHeight = height / 10 - 0.35f,
                        BoxColor = color
                    };
                    break;
                case ProgressBarDirection.Up:
                    _back = new PlayerTextDraw(player, new Vector2(x, y), "_")
                    {
                        UseBox = true,
                        Width = x - width - 4.0f,
                        Height = 0.0f,
                        LetterWidth = 1.0f,
                        LetterHeight = -((height / 10) * 1.02f) - 0.35f,
                        BoxColor = 0x00000000 | (color & 0x000000FF)
                    };

                    _fill = new PlayerTextDraw(player, new Vector2(x - 1.2f, y - 1.0f), "_")
                    {
                        UseBox = true,
                        Width = x - width - 2.5f,
                        Height = 0.0f,
                        LetterWidth = 1.0f,
                        LetterHeight = -(height / 10.0f) * 1.02f,
                        BoxColor = (int)((color & 0xFFFFFF00) | (0x66 & ((color & 0x000000FF) / 2)))
                    };

                    _main = new PlayerTextDraw(player, new Vector2(x - 1.2f, y - 1.0f), "_")
                    {
                        UseBox = true,
                        Width = x - width - 2.5f,
                        Height = 0.0f,
                        LetterWidth = 0.0f,
                        LetterHeight = CalculatePercentage(),
                        BoxColor = color
                    };
                    break;

                case ProgressBarDirection.Down:
                    _back = new PlayerTextDraw(player, new Vector2(x, y), "_")
                    {
                        UseBox = true,
                        Width = x - width - 4.0f,
                        Height = 0.0f,
                        LetterWidth = 1.0f,
                        LetterHeight = (height / 10) - 0.35f,
                        BoxColor = 0x00000000 | (color & 0x000000FF)
                    };

                    _fill = new PlayerTextDraw(player, new Vector2(x - 1.2f, y + 1.0f), "_")
                    {
                        UseBox = true,
                        Width = x - width - 2.5f,
                        Height = 0.0f,
                        LetterWidth = 1.0f,
                        LetterHeight = (height / 10.0f) - 0.55f,
                        BoxColor = (int)((color & 0xFFFFFF00) | (0x66 & ((color & 0x000000FF) / 2)))
                    };

                    _main = new PlayerTextDraw(player, new Vector2(x - 1.2f, y + 1.0f), "_")
                    {
                        UseBox = true,
                        Width = x - width - 2.5f,
                        Height = 0.0f,
                        LetterWidth = 0.0f,
                        LetterHeight = CalculatePercentage(),
                        BoxColor = color
                    };
                    break;
            }
        }

        public float X { get; private set; }
        public float Y { get; private set; }
        public float Width { get; private set; }
        public float Height { get; private set; }
        public Color Color { get; private set; }

        public float Max
        {
            get { return _max; }
            private set
            {
                _max = value;
                Redraw();
            }
        }

        public float Value
        {
            get { return _value; }
            set
            {
                _value = value;
                Redraw();
            }
        }

        public ProgressBarDirection Direction { get; private set; }

        private float CalculatePercentage()
        {
            float result = 0;

            switch (Direction)
            {
                case ProgressBarDirection.Right:
                    result = ((X - 3.0f) + (((((X - 2.0f) + Width) - X) / Max) * Value));
                    break;
                case ProgressBarDirection.Left:
                    result = ((X - 1.0f) - (((((X + 2.0f) - Width) - X) / Max) * -Value)) - 4.0f;
                    break;
                case ProgressBarDirection.Up:
                    result = -((((((Height / 10.0f) - 0.45f) * 1.02f) / Max) * Value) + 0.55f);
                    break;
                case ProgressBarDirection.Down:
                    result = ((((((Height / 10.0f) - 0.45f) * 1.02f) / Max) * Value) - 0.55f);
                    break;
            }

            return result;
        }

        private void Redraw()
        {
            if (_max < 0.1f) _max = 0.1f;
            _value = _value < 0 ? 0 : (_value > Max ? Max : _value);

            _main.UseBox = _value > 0.0f;

            switch (Direction)
            {
                case ProgressBarDirection.Right:
                case ProgressBarDirection.Left:
                    {
                        _main.Width = CalculatePercentage();
                    }
                    break;
                case ProgressBarDirection.Up:
                case ProgressBarDirection.Down:
                    {
                        _main.LetterHeight = CalculatePercentage();
                    }
                    break;
            }

            Show();
        }


        protected override void Dispose(bool disposing)
        {
            if (!IsDisposed) Hide();

            _back?.Dispose();
            _fill?.Dispose();
            _main?.Dispose();
        }

        public void Show()
        {
            //CheckDisposure();
            AssertNotDisposed();

            _back.Show();
            _fill.Show();
            _main.Show();
        }

        public void Hide()
        {
            //CheckDisposure();
            AssertNotDisposed();

            _back.Hide();
            _fill.Hide();
            _main.Hide();
        }

    }

    public enum ProgressBarDirection
    {
        Up,
        Down,
        Left,
        Right
    }
}
