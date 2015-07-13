using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Forms;
namespace magnusi
{
	[DefaultEvent("CheckedChanged")]
	public class RadioButton : Control
	{
		public delegate void CheckedChangedEventHandler(object sender);
		[Flags]
		public enum _Options
		{
			Style1 = 0,
			Style2 = 1
		}
		private static List<WeakReference> __ENCList = new List<WeakReference>();
		private MouseState State;
		private int W;
		private int H;
		private RadioButton._Options O;
		private bool _Checked;
		private RadioButton.CheckedChangedEventHandler CheckedChangedEvent;
		private Color _BaseColor;
		private Color _BorderColor;
		private Color _TextColor;
		public event RadioButton.CheckedChangedEventHandler CheckedChanged
		{
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			add
			{
				this.CheckedChangedEvent = (RadioButton.CheckedChangedEventHandler)Delegate.Combine(this.CheckedChangedEvent, value);
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			remove
			{
				this.CheckedChangedEvent = (RadioButton.CheckedChangedEventHandler)Delegate.Remove(this.CheckedChangedEvent, value);
			}
		}
		public bool Checked
		{
			get
			{
				return this._Checked;
			}
			set
			{
				this._Checked = value;
				this.InvalidateControls();
				RadioButton.CheckedChangedEventHandler checkedChangedEvent = this.CheckedChangedEvent;
				bool flag = checkedChangedEvent != null;
				if (flag)
				{
					checkedChangedEvent(this);
				}
				this.Invalidate();
			}
		}
		[Category("Options")]
		public RadioButton._Options Options
		{
			get
			{
				return this.O;
			}
			set
			{
				this.O = value;
			}
		}
		[DebuggerNonUserCode]
		private static void __ENCAddToList(object value)
		{
			List<WeakReference> _ENCList = RadioButton.__ENCList;
			bool flag = false;
			checked
			{
				try
				{
					Monitor.Enter(_ENCList, ref flag);
					bool flag2 = RadioButton.__ENCList.Count == RadioButton.__ENCList.Capacity;
					if (flag2)
					{
						int num = 0;
						int arg_44_0 = 0;
						int num2 = RadioButton.__ENCList.Count - 1;
						int num3 = arg_44_0;
						while (true)
						{
							int arg_95_0 = num3;
							int num4 = num2;
							if (arg_95_0 > num4)
							{
								break;
							}
							WeakReference weakReference = RadioButton.__ENCList[num3];
							flag2 = weakReference.IsAlive;
							if (flag2)
							{
								bool flag3 = num3 != num;
								if (flag3)
								{
									RadioButton.__ENCList[num] = RadioButton.__ENCList[num3];
								}
								num++;
							}
							num3++;
						}
						RadioButton.__ENCList.RemoveRange(num, RadioButton.__ENCList.Count - num);
						RadioButton.__ENCList.Capacity = RadioButton.__ENCList.Count;
					}
					RadioButton.__ENCList.Add(new WeakReference(RuntimeHelpers.GetObjectValue(value)));
				}
				finally
				{
					bool flag3 = flag;
					if (flag3)
					{
						Monitor.Exit(_ENCList);
					}
				}
			}
		}
		protected override void OnClick(EventArgs e)
		{
			bool flag = !this._Checked;
			if (flag)
			{
				this.Checked = true;
			}
			base.OnClick(e);
		}
		private void InvalidateControls()
		{
			bool flag = !this.IsHandleCreated || !this._Checked;
			if (!flag)
			{
				try
				{
					IEnumerator enumerator = this.Parent.Controls.GetEnumerator();
					while (enumerator.MoveNext())
					{
						Control C = (Control)enumerator.Current;
						flag = (C != this && C is RadioButton);
						if (flag)
						{
							((RadioButton)C).Checked = false;
							this.Invalidate();
						}
					}
				}
				finally
                {
				}
			}
		}
		protected override void OnCreateControl()
		{
			base.OnCreateControl();
			this.InvalidateControls();
		}
		protected override void OnResize(EventArgs e)
		{
			base.OnResize(e);
			this.Height = 22;
		}
		protected override void OnMouseDown(MouseEventArgs e)
		{
			base.OnMouseDown(e);
			this.State = MouseState.Down;
			this.Invalidate();
		}
		protected override void OnMouseUp(MouseEventArgs e)
		{
			base.OnMouseUp(e);
			this.State = MouseState.Over;
			this.Invalidate();
		}
		protected override void OnMouseEnter(EventArgs e)
		{
			base.OnMouseEnter(e);
			this.State = MouseState.Over;
			this.Invalidate();
		}
		protected override void OnMouseLeave(EventArgs e)
		{
			base.OnMouseLeave(e);
			this.State = MouseState.None;
			this.Invalidate();
		}
		public RadioButton()
		{
			RadioButton.__ENCAddToList(this);
			this.State = MouseState.None;
			this._BaseColor = Color.FromArgb(45, 47, 49);
			this._BorderColor = Helpers._FlatColor;
			this._TextColor = Color.FromArgb(243, 243, 243);
			this.SetStyle(ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
			this.DoubleBuffered = true;
			this.Cursor = Cursors.Hand;
			Size size = new Size(100, 22);
			this.Size = size;
			this.BackColor = Color.FromArgb(60, 70, 73);
			this.Font = new Font("Segoe UI", 10f);
		}
		protected override void OnPaint(PaintEventArgs e)
		{
			Helpers.B = new Bitmap(this.Width, this.Height);
			Helpers.G = Graphics.FromImage(Helpers.B);
			checked
			{
				this.W = this.Width - 1;
				this.H = this.Height - 1;
				Rectangle Base = new Rectangle(0, 2, this.Height - 5, this.Height - 5);
				Rectangle Dot = new Rectangle(4, 6, this.H - 12, this.H - 12);
				Graphics g = Helpers.G;
				g.SmoothingMode = SmoothingMode.HighQuality;
				g.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
				g.Clear(this.BackColor);
				switch (this.O)
				{
				case RadioButton._Options.Style1:
				{
					g.FillEllipse(new SolidBrush(this._BaseColor), Base);
					switch (this.State)
					{
					case MouseState.Over:
						g.DrawEllipse(new Pen(this._BorderColor), Base);
						break;
					case MouseState.Down:
						g.DrawEllipse(new Pen(this._BorderColor), Base);
						break;
					}
					bool @checked = this.Checked;
					if (@checked)
					{
						g.FillEllipse(new SolidBrush(this._BorderColor), Dot);
					}
					break;
				}
				case RadioButton._Options.Style2:
				{
					g.FillEllipse(new SolidBrush(this._BaseColor), Base);
					switch (this.State)
					{
					case MouseState.Over:
						g.DrawEllipse(new Pen(this._BorderColor), Base);
						g.FillEllipse(new SolidBrush(Color.FromArgb(118, 213, 170)), Base);
						break;
					case MouseState.Down:
						g.DrawEllipse(new Pen(this._BorderColor), Base);
						g.FillEllipse(new SolidBrush(Color.FromArgb(118, 213, 170)), Base);
						break;
					}
					bool @checked = this.Checked;
					if (@checked)
					{
						g.FillEllipse(new SolidBrush(this._BorderColor), Dot);
					}
					break;
				}
				}
				Graphics arg_22B_0 = g;
				string arg_22B_1 = this.Text;
				Font arg_22B_2 = this.Font;
				Brush arg_22B_3 = new SolidBrush(this._TextColor);
				Rectangle r = new Rectangle(20, 2, this.W, this.H);
				arg_22B_0.DrawString(arg_22B_1, arg_22B_2, arg_22B_3, r, Helpers.NearSF);
				base.OnPaint(e);
				Helpers.G.Dispose();
				e.Graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
				e.Graphics.DrawImageUnscaled(Helpers.B, 0, 0);
				Helpers.B.Dispose();
			}
		}
	}
}
