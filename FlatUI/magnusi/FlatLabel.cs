using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Forms;
namespace magnusi
{
	public class FlatLabel : Label
	{
		private static List<WeakReference> __ENCList = new List<WeakReference>();
		[DebuggerNonUserCode]
		private static void __ENCAddToList(object value)
		{
			List<WeakReference> _ENCList = FlatLabel.__ENCList;
			bool flag = false;
			checked
			{
				try
				{
					Monitor.Enter(_ENCList, ref flag);
					bool flag2 = FlatLabel.__ENCList.Count == FlatLabel.__ENCList.Capacity;
					if (flag2)
					{
						int num = 0;
						int arg_44_0 = 0;
						int num2 = FlatLabel.__ENCList.Count - 1;
						int num3 = arg_44_0;
						while (true)
						{
							int arg_95_0 = num3;
							int num4 = num2;
							if (arg_95_0 > num4)
							{
								break;
							}
							WeakReference weakReference = FlatLabel.__ENCList[num3];
							flag2 = weakReference.IsAlive;
							if (flag2)
							{
								bool flag3 = num3 != num;
								if (flag3)
								{
									FlatLabel.__ENCList[num] = FlatLabel.__ENCList[num3];
								}
								num++;
							}
							num3++;
						}
						FlatLabel.__ENCList.RemoveRange(num, FlatLabel.__ENCList.Count - num);
						FlatLabel.__ENCList.Capacity = FlatLabel.__ENCList.Count;
					}
					FlatLabel.__ENCList.Add(new WeakReference(RuntimeHelpers.GetObjectValue(value)));
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
		public FlatLabel()
		{
			FlatLabel.__ENCAddToList(this);
			this.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
			this.Font = new Font("Segoe UI", 8f);
			this.ForeColor = Color.White;
			this.BackColor = Color.Transparent;
			this.Text = this.Text;
		}
	}
}
