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
namespace magnusi
{
	[DefaultEvent("TextChanged")]
	public class FlatTextBox : Control
	{
		private static List<WeakReference> __ENCList = new List<WeakReference>();
		private int W;
		private int H;
		private MouseState State;
		[AccessedThroughProperty("TB")]
		private TextBox _TB;
		private HorizontalAlignment _TextAlign;
		private int _MaxLength;
		private bool _ReadOnly;
		private bool _UseSystemPasswordChar;
		private bool _Multiline;
		private Color _BaseColor;
		private Color _TextColor;
		private Color _BorderColor;
		internal virtual TextBox TB
		{
			[DebuggerNonUserCode]
			get
			{
				return this._TB;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._TB = value;
			}
		}
		[Category("Options")]
		public HorizontalAlignment TextAlign
		{
			get
			{
				return this._TextAlign;
			}
			set
			{
				this._TextAlign = value;
				bool flag = this.TB != null;
				if (flag)
				{
					this.TB.TextAlign = value;
				}
			}
		}
		[Category("Options")]
		public int MaxLength
		{
			get
			{
				return this._MaxLength;
			}
			set
			{
				this._MaxLength = value;
				bool flag = this.TB != null;
				if (flag)
				{
					this.TB.MaxLength = value;
				}
			}
		}
		[Category("Options")]
		public bool ReadOnly
		{
			get
			{
				return this._ReadOnly;
			}
			set
			{
				this._ReadOnly = value;
				bool flag = this.TB != null;
				if (flag)
				{
					this.TB.ReadOnly = value;
				}
			}
		}
		[Category("Options")]
		public bool UseSystemPasswordChar
		{
			get
			{
				return this._UseSystemPasswordChar;
			}
			set
			{
				this._UseSystemPasswordChar = value;
				bool flag = this.TB != null;
				if (flag)
				{
					this.TB.UseSystemPasswordChar = value;
				}
			}
		}
		[Category("Options")]
		public bool Multiline
		{
			get
			{
				return this._Multiline;
			}
			set
			{
				this._Multiline = value;
				bool flag = this.TB != null;
				checked
				{
					if (flag)
					{
						this.TB.Multiline = value;
						if (value)
						{
							this.TB.Height = this.Height - 11;
						}
						else
						{
							this.Height = this.TB.Height + 11;
						}
					}
				}
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
				bool flag = this.TB != null;
				if (flag)
				{
					this.TB.Text = value;
				}
			}
		}
		[Category("Options")]
		public override Font Font
		{
			get
			{
				return base.Font;
			}
			set
			{
				base.Font = value;
				bool flag = this.TB != null;
				checked
				{
					if (flag)
					{
						this.TB.Font = value;
						Control arg_37_0 = this.TB;
						Point location = new Point(3, 5);
						arg_37_0.Location = location;
						this.TB.Width = this.Width - 6;
						flag = !this._Multiline;
						if (flag)
						{
							this.Height = this.TB.Height + 11;
						}
					}
				}
			}
		}
		[Category("Colors")]
		public Color TextColor
		{
			get
			{
				return this._TextColor;
			}
			set
			{
				this._TextColor = value;
			}
		}
		public override Color ForeColor
		{
			get
			{
				return this._TextColor;
			}
			set
			{
				this._TextColor = value;
			}
		}
		[DebuggerNonUserCode]
		private static void __ENCAddToList(object value)
		{
			List<WeakReference> _ENCList = FlatTextBox.__ENCList;
			bool flag = false;
			checked
			{
				try
				{
					Monitor.Enter(_ENCList, ref flag);
					bool flag2 = FlatTextBox.__ENCList.Count == FlatTextBox.__ENCList.Capacity;
					if (flag2)
					{
						int num = 0;
						int arg_44_0 = 0;
						int num2 = FlatTextBox.__ENCList.Count - 1;
						int num3 = arg_44_0;
						while (true)
						{
							int arg_95_0 = num3;
							int num4 = num2;
							if (arg_95_0 > num4)
							{
								break;
							}
							WeakReference weakReference = FlatTextBox.__ENCList[num3];
							flag2 = weakReference.IsAlive;
							if (flag2)
							{
								bool flag3 = num3 != num;
								if (flag3)
								{
									FlatTextBox.__ENCList[num] = FlatTextBox.__ENCList[num3];
								}
								num++;
							}
							num3++;
						}
						FlatTextBox.__ENCList.RemoveRange(num, FlatTextBox.__ENCList.Count - num);
						FlatTextBox.__ENCList.Capacity = FlatTextBox.__ENCList.Count;
					}
					FlatTextBox.__ENCList.Add(new WeakReference(RuntimeHelpers.GetObjectValue(value)));
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
		protected override void OnCreateControl()
		{
			base.OnCreateControl();
			bool flag = !this.Controls.Contains(this.TB);
			if (flag)
			{
				this.Controls.Add(this.TB);
			}
		}
		private void OnBaseTextChanged(object s, EventArgs e)
		{
			this.Text = this.TB.Text;
		}
		private void OnBaseKeyDown(object s, KeyEventArgs e)
		{
			bool flag = e.Control && e.KeyCode == Keys.A;
			if (flag)
			{
				this.TB.SelectAll();
				e.SuppressKeyPress = true;
			}
			flag = (e.Control && e.KeyCode == Keys.C);
			if (flag)
			{
				this.TB.Copy();
				e.SuppressKeyPress = true;
			}
		}
		protected override void OnResize(EventArgs e)
		{
			Control arg_12_0 = this.TB;
			Point location = new Point(5, 5);
			arg_12_0.Location = location;
			checked
			{
				this.TB.Width = this.Width - 10;
				bool multiline = this._Multiline;
				if (multiline)
				{
					this.TB.Height = this.Height - 11;
				}
				else
				{
					this.Height = this.TB.Height + 11;
				}
				base.OnResize(e);
			}
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
			this.TB.Focus();
			this.Invalidate();
		}
		protected override void OnMouseEnter(EventArgs e)
		{
			base.OnMouseEnter(e);
			this.State = MouseState.Over;
			this.TB.Focus();
			this.Invalidate();
		}
		protected override void OnMouseLeave(EventArgs e)
		{
			base.OnMouseLeave(e);
			this.State = MouseState.None;
			this.Invalidate();
		}
		public FlatTextBox()
		{
			FlatTextBox.__ENCAddToList(this);
			this.State = MouseState.None;
			this._TextAlign = HorizontalAlignment.Left;
			this._MaxLength = 32767;
			this._BaseColor = Color.FromArgb(45, 47, 49);
			this._TextColor = Color.FromArgb(192, 192, 192);
			this._BorderColor = Helpers._FlatColor;
			this.SetStyle(ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.SupportsTransparentBackColor | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
			this.DoubleBuffered = true;
			this.BackColor = Color.Transparent;
			this.TB = new TextBox();
			this.TB.Font = new Font("Segoe UI", 10f);
			this.TB.Text = this.Text;
			this.TB.BackColor = this._BaseColor;
			this.TB.ForeColor = this._TextColor;
			this.TB.MaxLength = this._MaxLength;
			this.TB.Multiline = this._Multiline;
			this.TB.ReadOnly = this._ReadOnly;
			this.TB.UseSystemPasswordChar = this._UseSystemPasswordChar;
			this.TB.BorderStyle = BorderStyle.None;
			Control arg_142_0 = this.TB;
			Point location = new Point(5, 5);
			arg_142_0.Location = location;
			checked
			{
				this.TB.Width = this.Width - 10;
				this.TB.Cursor = Cursors.IBeam;
				bool multiline = this._Multiline;
				if (multiline)
				{
					this.TB.Height = this.Height - 11;
				}
				else
				{
					this.Height = this.TB.Height + 11;
				}
				this.TB.TextChanged += new EventHandler(this.OnBaseTextChanged);
				this.TB.KeyDown += new KeyEventHandler(this.OnBaseKeyDown);
			}
		}
		protected override void OnPaint(PaintEventArgs e)
		{
			Helpers.B = new Bitmap(this.Width, this.Height);
			Helpers.G = Graphics.FromImage(Helpers.B);
			checked
			{
				this.W = this.Width - 1;
				this.H = this.Height - 1;
				Rectangle Base = new Rectangle(0, 0, this.W, this.H);
				Graphics g = Helpers.G;
				g.SmoothingMode = SmoothingMode.HighQuality;
				g.PixelOffsetMode = PixelOffsetMode.HighQuality;
				g.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
				g.Clear(this.BackColor);
				this.TB.BackColor = this._BaseColor;
				this.TB.ForeColor = this._TextColor;
				g.FillRectangle(new SolidBrush(this._BaseColor), Base);
				base.OnPaint(e);
				Helpers.G.Dispose();
				e.Graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
				e.Graphics.DrawImageUnscaled(Helpers.B, 0, 0);
				Helpers.B.Dispose();
			}
		}
	}
}
