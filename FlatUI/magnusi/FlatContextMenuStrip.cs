using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Text;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Forms;
namespace magnusi
{
	public class FlatContextMenuStrip : ContextMenuStrip
	{
		public class TColorTable : ProfessionalColorTable
		{
			private Color BackColor;
			private Color CheckedColor;
			private Color BorderColor;
			[Category("Colors")]
			public Color _BackColor
			{
				get
				{
					return this.BackColor;
				}
				set
				{
					this.BackColor = value;
				}
			}
			[Category("Colors")]
			public Color _CheckedColor
			{
				get
				{
					return this.CheckedColor;
				}
				set
				{
					this.CheckedColor = value;
				}
			}
			[Category("Colors")]
			public Color _BorderColor
			{
				get
				{
					return this.BorderColor;
				}
				set
				{
					this.BorderColor = value;
				}
			}
			public override Color ButtonSelectedBorder
			{
				get
				{
					return this.BackColor;
				}
			}
			public override Color CheckBackground
			{
				get
				{
					return this.CheckedColor;
				}
			}
			public override Color CheckPressedBackground
			{
				get
				{
					return this.CheckedColor;
				}
			}
			public override Color CheckSelectedBackground
			{
				get
				{
					return this.CheckedColor;
				}
			}
			public override Color ImageMarginGradientBegin
			{
				get
				{
					return this.CheckedColor;
				}
			}
			public override Color ImageMarginGradientEnd
			{
				get
				{
					return this.CheckedColor;
				}
			}
			public override Color ImageMarginGradientMiddle
			{
				get
				{
					return this.CheckedColor;
				}
			}
			public override Color MenuBorder
			{
				get
				{
					return this.BorderColor;
				}
			}
			public override Color MenuItemBorder
			{
				get
				{
					return this.BorderColor;
				}
			}
			public override Color MenuItemSelected
			{
				get
				{
					return this.CheckedColor;
				}
			}
			public override Color SeparatorDark
			{
				get
				{
					return this.BorderColor;
				}
			}
			public override Color ToolStripDropDownBackground
			{
				get
				{
					return this.BackColor;
				}
			}
			public TColorTable()
			{
				this.BackColor = Color.FromArgb(45, 47, 49);
				this.CheckedColor = Helpers._FlatColor;
				this.BorderColor = Color.FromArgb(53, 58, 60);
			}
		}
		private static List<WeakReference> __ENCList = new List<WeakReference>();
		[DebuggerNonUserCode]
		private static void __ENCAddToList(object value)
		{
			List<WeakReference> _ENCList = FlatContextMenuStrip.__ENCList;
			bool flag = false;
			checked
			{
				try
				{
					Monitor.Enter(_ENCList, ref flag);
					bool flag2 = FlatContextMenuStrip.__ENCList.Count == FlatContextMenuStrip.__ENCList.Capacity;
					if (flag2)
					{
						int num = 0;
						int arg_44_0 = 0;
						int num2 = FlatContextMenuStrip.__ENCList.Count - 1;
						int num3 = arg_44_0;
						while (true)
						{
							int arg_95_0 = num3;
							int num4 = num2;
							if (arg_95_0 > num4)
							{
								break;
							}
							WeakReference weakReference = FlatContextMenuStrip.__ENCList[num3];
							flag2 = weakReference.IsAlive;
							if (flag2)
							{
								bool flag3 = num3 != num;
								if (flag3)
								{
									FlatContextMenuStrip.__ENCList[num] = FlatContextMenuStrip.__ENCList[num3];
								}
								num++;
							}
							num3++;
						}
						FlatContextMenuStrip.__ENCList.RemoveRange(num, FlatContextMenuStrip.__ENCList.Count - num);
						FlatContextMenuStrip.__ENCList.Capacity = FlatContextMenuStrip.__ENCList.Count;
					}
					FlatContextMenuStrip.__ENCList.Add(new WeakReference(RuntimeHelpers.GetObjectValue(value)));
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
		public FlatContextMenuStrip()
		{
			FlatContextMenuStrip.__ENCAddToList(this);
			this.Renderer = new ToolStripProfessionalRenderer(new FlatContextMenuStrip.TColorTable());
			this.ShowImageMargin = false;
			this.ForeColor = Color.White;
			this.Font = new Font("Segoe UI", 8f);
		}
		protected override void OnPaint(PaintEventArgs e)
		{
			base.OnPaint(e);
			e.Graphics.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
		}
	}
}
