using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Forms;
using color  = System.Drawing.Color;
using point = System.Drawing.Point;
using rectangle = System.Drawing.Rectangle;

namespace magnusi
{
	public class FlatAlertBox : Control
	{
		[Flags]
		public enum _Kind
		{
			Success = 0,
			Error = 1,
			Info = 2
		}
		private static List<WeakReference> __ENCList = new List<WeakReference>();
		private int W;
		private int H;
		private FlatAlertBox._Kind K;
		private string _Text;
		private MouseState State;
		private int X;
		[AccessedThroughProperty("T")]
		private System.Windows.Forms.Timer _T;
		private color  SuccessColor;
		private color  SuccessText;
		private color  ErrorColor;
		private color  ErrorText;
		private color  InfoColor;
		private color  InfoText;
		public virtual System.Windows.Forms.Timer T
		{
			[DebuggerNonUserCode]
			get
			{
				return this._T;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler value2 = new EventHandler(this.T_Tick);
				bool flag = this._T != null;
				if (flag)
				{
					this._T.Tick -= value2;
				}
				this._T = value;
				flag = (this._T != null);
				if (flag)
				{
					this._T.Tick += value2;
				}
			}
		}
		[Category("Options")]
		public FlatAlertBox._Kind kind
		{
			get
			{
				return this.K;
			}
			set
			{
				this.K = value;
			}
		}
		[Category("Options")]
		public override string Text
		{
			get
			{
				return base.Text;
			}
			set
			{
				base.Text = value;
				bool flag = this._Text != null;
				if (flag)
				{
					this._Text = value;
				}
			}
		}
		[Category("Options")]
		public new bool Visible
		{
			get
			{
				return !base.Visible;
			}
			set
			{
				base.Visible = value;
			}
		}
		[DebuggerNonUserCode]
		private static void __ENCAddToList(object value)
		{
			List<WeakReference> _ENCList = FlatAlertBox.__ENCList;
			bool flag = false;
			checked
			{
				try
				{
					Monitor.Enter(_ENCList, ref flag);
					bool flag2 = FlatAlertBox.__ENCList.Count == FlatAlertBox.__ENCList.Capacity;
					if (flag2)
					{
						int num = 0;
						int arg_44_0 = 0;
						int num2 = FlatAlertBox.__ENCList.Count - 1;
						int num3 = arg_44_0;
						while (true)
						{
							int arg_95_0 = num3;
							int num4 = num2;
							if (arg_95_0 > num4)
							{
								break;
							}
							WeakReference weakReference = FlatAlertBox.__ENCList[num3];
							flag2 = weakReference.IsAlive;
							if (flag2)
							{
								bool flag3 = num3 != num;
								if (flag3)
								{
									FlatAlertBox.__ENCList[num] = FlatAlertBox.__ENCList[num3];
								}
								num++;
							}
							num3++;
						}
						FlatAlertBox.__ENCList.RemoveRange(num, FlatAlertBox.__ENCList.Count - num);
						FlatAlertBox.__ENCList.Capacity = FlatAlertBox.__ENCList.Count;
					}
					FlatAlertBox.__ENCList.Add(new WeakReference(RuntimeHelpers.GetObjectValue(value)));
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
		protected override void OnTextChanged(EventArgs e)
		{
			base.OnTextChanged(e);
			this.Invalidate();
		}
		protected override void OnResize(EventArgs e)
		{
			base.OnResize(e);
			this.Height = 42;
		}
		public void ShowControl(FlatAlertBox._Kind Kind, string Str, int Interval)
		{
			this.K = Kind;
			this.Text = Str;
			this.Visible = true;
			this.T = new System.Windows.Forms.Timer();
			this.T.Interval = Interval;
			this.T.Enabled = true;
		}
		private void T_Tick(object sender, EventArgs e)
		{
			this.Visible = false;
			this.T.Enabled = false;
			this.T.Dispose();
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
		protected override void OnMouseMove(MouseEventArgs e)
		{
			base.OnMouseMove(e);
			this.X = e.X;
			this.Invalidate();
		}
		protected override void OnClick(EventArgs e)
		{
			base.OnClick(e);
			this.Visible = false;
		}
		public FlatAlertBox()
		{
			FlatAlertBox.__ENCAddToList(this);
			this.State = MouseState.None;
			this.SuccessColor = color .FromArgb(60, 85, 79);
			this.SuccessText = color .FromArgb(35, 169, 110);
			this.ErrorColor = color .FromArgb(87, 71, 71);
			this.ErrorText = color .FromArgb(254, 142, 122);
			this.InfoColor = color .FromArgb(70, 91, 94);
			this.InfoText = color .FromArgb(97, 185, 186);
			this.SetStyle(ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
			this.DoubleBuffered = true;
			this.BackColor = color .FromArgb(60, 70, 73);
			Size size = new Size(576, 42);
			this.Size = size;
			point location = new point(10, 61);
			this.Location = location;
			this.Font = new Font("Segoe UI", 10f);
			this.Cursor = Cursors.Hand;
		}
		protected override void OnPaint(PaintEventArgs e)
		{
			Helpers.B = new Bitmap(this.Width, this.Height);
			Helpers.G = Graphics.FromImage(Helpers.B);
			checked
			{
				this.W = this.Width - 1;
				this.H = this.Height - 1;
				rectangle Base = new rectangle (0, 0, this.W, this.H);
				Graphics g = Helpers.G;
				g.SmoothingMode = SmoothingMode.HighQuality;
				g.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
				g.Clear(this.BackColor);
				switch (this.K)
				{
				case FlatAlertBox._Kind.Success:
				{
					g.FillRectangle(new SolidBrush(this.SuccessColor), Base);
					Graphics arg_CC_0 = g;
					Brush arg_CC_1 = new SolidBrush(this.SuccessText);
					rectangle rectangle  = new rectangle (8, 9, 24, 24);
					arg_CC_0.FillEllipse(arg_CC_1, rectangle );
					Graphics arg_EF_0 = g;
					Brush arg_EF_1 = new SolidBrush(this.SuccessColor);
					rectangle = new rectangle (10, 11, 20, 20);
					arg_EF_0.FillEllipse(arg_EF_1, rectangle );
					Graphics arg_136_0 = g;
					string arg_136_1 = "Ã¼";
					Font arg_136_2 = new Font("Wingdings", 22f);
					Brush arg_136_3 = new SolidBrush(this.SuccessText);
					rectangle = new rectangle (7, 7, this.W, this.H);
					arg_136_0.DrawString(arg_136_1, arg_136_2, arg_136_3, rectangle , Helpers.NearSF);
					Graphics arg_177_0 = g;
					string arg_177_1 = this.Text;
					Font arg_177_2 = this.Font;
					Brush arg_177_3 = new SolidBrush(this.SuccessText);
					rectangle = new rectangle (48, 12, this.W, this.H);
					arg_177_0.DrawString(arg_177_1, arg_177_2, arg_177_3, rectangle , Helpers.NearSF);
					Graphics arg_1AE_0 = g;
					Brush arg_1AE_1 = new SolidBrush(color.FromArgb(35, color .Black));
					rectangle = new rectangle (this.W - 30, this.H - 29, 17, 17);
					arg_1AE_0.FillEllipse(arg_1AE_1, rectangle );
					Graphics arg_1FE_0 = g;
					string arg_1FE_1 = "r";
					Font arg_1FE_2 = new Font("Marlett", 8f);
					Brush arg_1FE_3 = new SolidBrush(this.SuccessColor);
					rectangle = new rectangle (this.W - 28, 16, this.W, this.H);
					arg_1FE_0.DrawString(arg_1FE_1, arg_1FE_2, arg_1FE_3, rectangle , Helpers.NearSF);
					MouseState state = this.State;
					bool flag = state == MouseState.Over;
					if (flag)
					{
						Graphics arg_269_0 = g;
						string arg_269_1 = "r";
						Font arg_269_2 = new Font("Marlett", 8f);
						Brush arg_269_3 = new SolidBrush(color.FromArgb(25, color .White));
						rectangle = new rectangle (this.W - 28, 16, this.W, this.H);
						arg_269_0.DrawString(arg_269_1, arg_269_2, arg_269_3, rectangle , Helpers.NearSF);
					}
					break;
				}
				case FlatAlertBox._Kind.Error:
				{
					g.FillRectangle(new SolidBrush(this.ErrorColor), Base);
					Graphics arg_2A5_0 = g;
					Brush arg_2A5_1 = new SolidBrush(this.ErrorText);
					rectangle rectangle  = new rectangle (8, 9, 24, 24);
					arg_2A5_0.FillEllipse(arg_2A5_1, rectangle );
					Graphics arg_2C8_0 = g;
					Brush arg_2C8_1 = new SolidBrush(this.ErrorColor);
					rectangle = new rectangle (10, 11, 20, 20);
					arg_2C8_0.FillEllipse(arg_2C8_1, rectangle );
					Graphics arg_310_0 = g;
					string arg_310_1 = "r";
					Font arg_310_2 = new Font("Marlett", 16f);
					Brush arg_310_3 = new SolidBrush(this.ErrorText);
					rectangle = new rectangle (6, 11, this.W, this.H);
					arg_310_0.DrawString(arg_310_1, arg_310_2, arg_310_3, rectangle , Helpers.NearSF);
					Graphics arg_351_0 = g;
					string arg_351_1 = this.Text;
					Font arg_351_2 = this.Font;
					Brush arg_351_3 = new SolidBrush(this.ErrorText);
					rectangle = new rectangle (48, 12, this.W, this.H);
					arg_351_0.DrawString(arg_351_1, arg_351_2, arg_351_3, rectangle , Helpers.NearSF);
					Graphics arg_388_0 = g;
					Brush arg_388_1 = new SolidBrush(color.FromArgb(35, color .Black));
					rectangle = new rectangle (this.W - 32, this.H - 29, 17, 17);
					arg_388_0.FillEllipse(arg_388_1, rectangle );
					Graphics arg_3D8_0 = g;
					string arg_3D8_1 = "r";
					Font arg_3D8_2 = new Font("Marlett", 8f);
					Brush arg_3D8_3 = new SolidBrush(this.ErrorColor);
					rectangle = new rectangle (this.W - 30, 17, this.W, this.H);
					arg_3D8_0.DrawString(arg_3D8_1, arg_3D8_2, arg_3D8_3, rectangle , Helpers.NearSF);
					MouseState state2 = this.State;
					bool flag = state2 == MouseState.Over;
					if (flag)
					{
						Graphics arg_443_0 = g;
						string arg_443_1 = "r";
						Font arg_443_2 = new Font("Marlett", 8f);
						Brush arg_443_3 = new SolidBrush(color.FromArgb(25, color .White));
						rectangle = new rectangle (this.W - 30, 15, this.W, this.H);
						arg_443_0.DrawString(arg_443_1, arg_443_2, arg_443_3, rectangle , Helpers.NearSF);
					}
					break;
				}
				case FlatAlertBox._Kind.Info:
				{
					g.FillRectangle(new SolidBrush(this.InfoColor), Base);
					Graphics arg_47F_0 = g;
					Brush arg_47F_1 = new SolidBrush(this.InfoText);
					rectangle rectangle  = new rectangle (8, 9, 24, 24);
					arg_47F_0.FillEllipse(arg_47F_1, rectangle );
					Graphics arg_4A2_0 = g;
					Brush arg_4A2_1 = new SolidBrush(this.InfoColor);
					rectangle = new rectangle (10, 11, 20, 20);
					arg_4A2_0.FillEllipse(arg_4A2_1, rectangle );
					Graphics arg_4EC_0 = g;
					string arg_4EC_1 = "Â¡";
					Font arg_4EC_2 = new Font("Segoe UI", 20f, FontStyle.Bold);
					Brush arg_4EC_3 = new SolidBrush(this.InfoText);
					rectangle = new rectangle (12, -4, this.W, this.H);
					arg_4EC_0.DrawString(arg_4EC_1, arg_4EC_2, arg_4EC_3, rectangle , Helpers.NearSF);
					Graphics arg_52D_0 = g;
					string arg_52D_1 = this.Text;
					Font arg_52D_2 = this.Font;
					Brush arg_52D_3 = new SolidBrush(this.InfoText);
					rectangle = new rectangle (48, 12, this.W, this.H);
					arg_52D_0.DrawString(arg_52D_1, arg_52D_2, arg_52D_3, rectangle , Helpers.NearSF);
					Graphics arg_564_0 = g;
					Brush arg_564_1 = new SolidBrush(color.FromArgb(35, color .Black));
					rectangle = new rectangle (this.W - 32, this.H - 29, 17, 17);
					arg_564_0.FillEllipse(arg_564_1, rectangle );
					Graphics arg_5B4_0 = g;
					string arg_5B4_1 = "r";
					Font arg_5B4_2 = new Font("Marlett", 8f);
					Brush arg_5B4_3 = new SolidBrush(this.InfoColor);
					rectangle = new rectangle (this.W - 30, 17, this.W, this.H);
					arg_5B4_0.DrawString(arg_5B4_1, arg_5B4_2, arg_5B4_3, rectangle , Helpers.NearSF);
					MouseState state3 = this.State;
					bool flag = state3 == MouseState.Over;
					if (flag)
					{
						Graphics arg_61F_0 = g;
						string arg_61F_1 = "r";
						Font arg_61F_2 = new Font("Marlett", 8f);
						Brush arg_61F_3 = new SolidBrush(color.FromArgb(25, color .White));
						rectangle = new rectangle (this.W - 30, 17, this.W, this.H);
						arg_61F_0.DrawString(arg_61F_1, arg_61F_2, arg_61F_3, rectangle , Helpers.NearSF);
					}
					break;
				}
				}
				base.OnPaint(e);
				Helpers.G.Dispose();
				e.Graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
				e.Graphics.DrawImageUnscaled(Helpers.B, 0, 0);
				Helpers.B.Dispose();
			}
		}
	}
}
