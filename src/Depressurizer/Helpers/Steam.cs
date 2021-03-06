﻿using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Depressurizer.Properties;

namespace Depressurizer.Helpers
{
	public static class Steam
	{
		#region Static Fields

		private static readonly List<int> IgnoreList = new List<int>();

		#endregion

		#region Properties

		private static Logger Logger => Logger.Instance;

		#endregion

		#region Public Methods and Operators

		/// <summary>
		///     Grabs the banner from the Steam store
		/// </summary>
		/// <param name="apps">AppId of the apps to fetch</param>
		public static async void GrabBanners(List<int> apps)
		{
			apps = apps.Distinct().ToList();
			await Task.Run(() =>
			{
				Parallel.ForEach(apps, FetchBanner);
			});
		}

		#endregion

		#region Methods

		private static void FetchBanner(int appId)
		{
			if ((appId <= 0) || File.Exists(Location.File.Banner(appId)) || IgnoreList.Contains(appId))
			{
				return;
			}

			string bannerLink = string.Format(CultureInfo.InvariantCulture, Constants.SteamStoreAppBanner, appId);
			try
			{
				using (WebClient webClient = new WebClient())
				{
					webClient.DownloadFile(bannerLink, Location.File.Banner(appId));
				}
			}
			catch (WebException we)
			{
				if (we.InnerException is IOException)
				{
					Thread.Sleep(100);
					FetchBanner(appId);
				}

				if (we.Response is HttpWebResponse errorResponse && (errorResponse.StatusCode != HttpStatusCode.NotFound))
				{
					throw;
				}
			}
			catch
			{
				Logger.Warn("Couldn't fetch banner for appId: {0}", appId);
				Debug.WriteLine("Couldn't fetch banner for appId: {0}", appId);
			}
		}

		#endregion
	}
}