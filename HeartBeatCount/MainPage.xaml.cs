using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace HeartBeatCount
{
	/// <summary>
	/// An empty page that can be used on its own or navigated to within a Frame.
	/// </summary>
	public sealed partial class MainPage : Page
	{
		DateTime StartTime;
		DateTime EndTime;

		public MainPage()
		{
			this.InitializeComponent();
		}

		private void MeasureButton_Click(object sender, RoutedEventArgs e)
		{
			TimeSpan Timing;
			double HeartBeat;

			if (MeasureButton.Content.ToString() == "Start")
			{
				StartTime = DateTime.Now;
				MeasureButton.Content = "End";
			}
			else
			{
				EndTime = DateTime.Now;
				MeasureButton.Content = "Start";

				Timing = EndTime - StartTime;
				HeartBeat = Math.Round(30.0 / ((double)Timing.Seconds / 60.0));

				ResultTextBlock.Text = string.Format("{0} seconds, {1} beats per minute", Timing.Seconds.ToString(), HeartBeat);

				if (HeartBeat < 30)
				{
					ConclusionTextBlock.Text = "Veel te laag, waarschijnlijk niet goed gemeten.";
				}
				else if (HeartBeat < 50)
				{
					ConclusionTextBlock.Text = "Lage hartslag";
				}
				else if (HeartBeat < 75)
				{
					ConclusionTextBlock.Text = "Normale hartslag";
				}
				else
				{
					ConclusionTextBlock.Text = "Hoge hartslag";
				}
			}
		}
	}
}
