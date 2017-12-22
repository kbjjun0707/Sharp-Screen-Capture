using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Interop;

namespace Wpf_test {
	/// <summary>
	/// MainWindow.xaml에 대한 상호 작용 논리
	/// </summary>
	public partial class MainWindow : Window {
		public MainWindow() {
			InitializeComponent();
		}

		private void btncap_Click(object sender, RoutedEventArgs e) {
			Bitmap bmpScreenshot = new Bitmap(
				(int)SystemParameters.PrimaryScreenWidth, (int)SystemParameters.PrimaryScreenHeight,
				System.Drawing.Imaging.PixelFormat.Format32bppArgb);
			Graphics gfxScreenshot = Graphics.FromImage(bmpScreenshot);

			System.Drawing.Size size = new System.Drawing.Size((int)SystemParameters.PrimaryScreenWidth, 
				(int)SystemParameters.PrimaryScreenHeight);
			gfxScreenshot.CopyFromScreen(0, 0, 0, 0, size, CopyPixelOperation.SourceCopy);

			BitmapData bitmapData = bmpScreenshot.LockBits(
				new System.Drawing.Rectangle(0, 0,
				bmpScreenshot.Width, bmpScreenshot.Height),
				ImageLockMode.ReadOnly,
				System.Drawing.Imaging.PixelFormat.Format32bppArgb);

			imgcap.Source = BitmapSource.Create(bmpScreenshot.Width, bmpScreenshot.Height,
				bmpScreenshot.HorizontalResolution, bmpScreenshot.VerticalResolution,
				System.Windows.Media.PixelFormats.Bgra32, null,
				bitmapData.Scan0, 
				bmpScreenshot.Size.Height*bmpScreenshot.Width*4,
				bitmapData.Stride);
		}
	}
}
