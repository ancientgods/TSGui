using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
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
using color = System.Drawing.Color;
using rectangle = System.Drawing.Rectangle;
using point = System.Drawing.Point;

namespace magnusi
{
	public class FlatListBox : Control
	{
		private static List<WeakReference> __ENCList = new List<WeakReference>();
		[AccessedThroughProperty("ListBx")]
		private ListBox _ListBx;
		private string[] _items;
		private color  BaseColor;
		private color  _SelectedColor;
		public virtual ListBox ListBoxSkin
		{
			[DebuggerNonUserCode]
			get
			{
				return this._ListBx;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				DrawItemEventHandler value2 = new DrawItemEventHandler(this.Drawitem);
				bool flag = this._ListBx != null;
				if (flag)
				{
					this._ListBx.DrawItem -= value2;
				}
				this._ListBx = value;
				flag = (this._ListBx != null);
				if (flag)
				{
					this._ListBx.DrawItem += value2;
				}
			}
		}
		[Category("Options")]
		public string[] items
		{
			get
			{
				return this._items;
			}
			set
			{
				this._items = value;
				this.ListBoxSkin.Items.Clear();
				this.ListBoxSkin.Items.AddRange(value);
				this.Invalidate();
			}
		}
		[Category("Colors")]
		public color  SelectedColor
		{
			get
			{
				return this._SelectedColor;
			}
			set
			{
				this._SelectedColor = value;
			}
		}
		public string SelectedItem
		{
			get
			{
				return Conversions.ToString(this.ListBoxSkin.SelectedItem);
			}
		}
		public int SelectedIndex
		{
			get
			{
				return this.ListBoxSkin.SelectedIndex;
			}
		}
		[DebuggerNonUserCode]
		private static void __ENCAddToList(object value)
		{
			List<WeakReference> _ENCList = FlatListBox.__ENCList;
			bool flag = false;
			checked
			{
				try
				{
					Monitor.Enter(_ENCList, ref flag);
					bool flag2 = FlatListBox.__ENCList.Count == FlatListBox.__ENCList.Capacity;
					if (flag2)
					{
						int num = 0;
						int arg_44_0 = 0;
						int num2 = FlatListBox.__ENCList.Count - 1;
						int num3 = arg_44_0;
						while (true)
						{
							int arg_95_0 = num3;
							int num4 = num2;
							if (arg_95_0 > num4)
							{
								break;
							}
							WeakReference weakReference = FlatListBox.__ENCList[num3];
							flag2 = weakReference.IsAlive;
							if (flag2)
							{
								bool flag3 = num3 != num;
								if (flag3)
								{
									FlatListBox.__ENCList[num] = FlatListBox.__ENCList[num3];
								}
								num++;
							}
							num3++;
						}
						FlatListBox.__ENCList.RemoveRange(num, FlatListBox.__ENCList.Count - num);
						FlatListBox.__ENCList.Capacity = FlatListBox.__ENCList.Count;
					}
					FlatListBox.__ENCList.Add(new WeakReference(RuntimeHelpers.GetObjectValue(value)));
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

        protected override void OnDoubleClick(EventArgs e)
        {
            base.OnDoubleClick(e);
        }

		public void Clear()
		{
			this.ListBoxSkin.Items.Clear();
		}
		public void ClearSelected()
		{
			checked
			{
				int i = this.ListBoxSkin.SelectedItems.Count - 1;
				while (true)
				{
					int arg_46_0 = i;
					int num = 0;
					if (arg_46_0 < num)
					{
						break;
					}
					this.ListBoxSkin.Items.Remove(RuntimeHelpers.GetObjectValue(this.ListBoxSkin.SelectedItems[i]));
					i += -1;
				}
			}
		}
		public void Drawitem(object sender, DrawItemEventArgs e)
		{
			bool flag = e.Index < 0;
			checked
			{
				if (!flag)
				{
					e.DrawBackground();
					e.DrawFocusRectangle();
					e.Graphics.SmoothingMode = SmoothingMode.HighQuality;
					e.Graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;
					e.Graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
					e.Graphics.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
					flag = (Strings.InStr(e.State.ToString(), "Selected,", CompareMethod.Binary) > 0);
					if (flag)
					{
						Graphics arg_D2_0 = e.Graphics;
						Brush arg_D2_1 = new SolidBrush(this._SelectedColor);
						rectangle bounds = e.Bounds;
						rectangle bounds2 = new rectangle (bounds.X, e.Bounds.Y, e.Bounds.Width, e.Bounds.Height);
						arg_D2_0.FillRectangle(arg_D2_1, bounds2);
						Graphics arg_138_0 = e.Graphics;
						string arg_138_1 = " " + this.ListBoxSkin.Items[e.Index].ToString();
						Font arg_138_2 = new Font("Segoe UI", 8f);
						Brush arg_138_3 = Brushes.White;
						bounds = e.Bounds;
						float arg_138_4 = (float)bounds.X;
						bounds2 = e.Bounds;
						arg_138_0.DrawString(arg_138_1, arg_138_2, arg_138_3, arg_138_4, (float)(bounds2.Y + 2));
					}
					else
					{
						Graphics arg_19C_0 = e.Graphics;
						Brush arg_19C_1 = new SolidBrush(color.FromArgb(51, 53, 55));
						rectangle bounds2 = e.Bounds;
						rectangle bounds = new rectangle (bounds2.X, e.Bounds.Y, e.Bounds.Width, e.Bounds.Height);
						arg_19C_0.FillRectangle(arg_19C_1, bounds);
						Graphics arg_202_0 = e.Graphics;
						string arg_202_1 = " " + this.ListBoxSkin.Items[e.Index].ToString();
						Font arg_202_2 = new Font("Segoe UI", 8f);
						Brush arg_202_3 = Brushes.White;
						bounds = e.Bounds;
						float arg_202_4 = (float)bounds.X;
						bounds2 = e.Bounds;
						arg_202_0.DrawString(arg_202_1, arg_202_2, arg_202_3, arg_202_4, (float)(bounds2.Y + 2));
					}
					e.Graphics.Dispose();
				}
			}
		}
		protected override void OnCreateControl()
		{
			base.OnCreateControl();
			bool flag = !this.Controls.Contains(this.ListBoxSkin);
			if (flag)
			{
				this.Controls.Add(this.ListBoxSkin);
			}
		}
		public void AddRange(object[] items)
		{
			this.ListBoxSkin.Items.Remove("");
			this.ListBoxSkin.Items.AddRange(items);
		}
		public void AddItem(object item)
		{
			this.ListBoxSkin.Items.Remove("");
			this.ListBoxSkin.Items.Add(RuntimeHelpers.GetObjectValue(item));
		}
		public FlatListBox()
		{
			FlatListBox.__ENCAddToList(this);
			this.ListBoxSkin = new ListBox();
			this._items = new string[]
			{
				""
			};
			this.BaseColor = color .FromArgb(45, 47, 49);
			this._SelectedColor = Helpers._FlatColor;
			this.SetStyle(ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
			this.DoubleBuffered = true;
			this.ListBoxSkin.DrawMode = DrawMode.OwnerDrawFixed;
			this.ListBoxSkin.ScrollAlwaysVisible = false;
			this.ListBoxSkin.HorizontalScrollbar = false;
			this.ListBoxSkin.BorderStyle = BorderStyle.None;
			this.ListBoxSkin.BackColor = this.BaseColor;
			this.ListBoxSkin.ForeColor = color .White;
			Control arg_CE_0 = this.ListBoxSkin;
			point location = new point(3, 3);
			arg_CE_0.Location = location;
			this.ListBoxSkin.Font = new Font("Segoe UI", 8f);
			this.ListBoxSkin.ItemHeight = 20;
			this.ListBoxSkin.Items.Clear();
			this.ListBoxSkin.IntegralHeight = false;
			Size size = new Size(131, 101);
			this.Size = size;
			this.BackColor = this.BaseColor;
		}
		protected override void OnPaint(PaintEventArgs e)
		{
			Helpers.B = new Bitmap(this.Width, this.Height);
			Helpers.G = Graphics.FromImage(Helpers.B);
			rectangle Base = new rectangle (0, 0, this.Width, this.Height);
			Graphics g = Helpers.G;
			g.SmoothingMode = SmoothingMode.HighQuality;
			g.PixelOffsetMode = PixelOffsetMode.HighQuality;
			g.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
			g.Clear(this.BackColor);
			Control arg_86_0 = this.ListBoxSkin;
			Size size = checked(new Size(this.Width - 6, this.Height - 2));
			arg_86_0.Size = size;
			g.FillRectangle(new SolidBrush(this.BaseColor), Base);
			base.OnPaint(e);
			Helpers.G.Dispose();
			e.Graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
			e.Graphics.DrawImageUnscaled(Helpers.B, 0, 0);
			Helpers.B.Dispose();
		}
	}
}
